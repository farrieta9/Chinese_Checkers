﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckersLib;

namespace ChineseCheckers
{
    public partial class mainForm : Form
    {
        GameManager GM;
        Tutorial Tutorial = new Tutorial();
        
        public event PaintEventHandler paint;
        public pieceObject[] all_pieces = new pieceObject[121];
        public int count = 0;
        public pieceObject hold;
        protected bool gameHasStarted = false;
        public pieceObject reset1, reset2; // reset1 hold the old position, reset2 has the new position
        public bool made_move = false;
        public int waitTime;
        private bool messageExists = false;
        private Label gameMessage;

        public mainForm()
        {
            InitializeComponent();
        }

        private void helpTutorial_Click(object sender, EventArgs e)
        {
            string instruct = Tutorial.getInstructions();
            System.Windows.Forms.MessageBox.Show(instruct);
        }

        public void clearAllHighlighting()
        {
            for (int n = 0; n < count; n++)
            {
                all_pieces[n].removeHighlight();
            }
        }

        public void endTurnEvent(object sender, EventArgs e)
        {
            System.Console.WriteLine(GM.playersTurn + " has ended their turn.");
            
            //check if a player has won
            if (GM.checkWinningMoves())
            {
                displayMessage(getColor(GM.playersTurn).ToString() + " wins!", GM.playersTurn);
                System.Windows.Forms.MessageBox.Show(getColor(GM.playersTurn).ToString() + " is the winna winna chicken dinna!");
                // @todo End game and return to initial menu

                Application.Exit();
                return;
            }

            //if game is not over
            GM.nextPlayersTurn();
            reset1 = reset2 = null;
            made_move = false;

            //if the new player is an AI, take the turn
            if (GM.playerIsHuman[(int)GM.playersTurn - 2] == false)
            {
                displayMessage(getColor(GM.playersTurn).ToString() + " is thinking...", GM.playersTurn);
                Move move = GM.MakeNPCMove();

                GM.gameBoard.setSpace(move.End.Item1, move.End.Item2, move.Player);
                GM.gameBoard.setSpace(move.Start.Item1, move.Start.Item2, Space.Empty);
                getPieceObjectByPosition(move.End.Item1, move.End.Item2).setPieceColor(getColor(move.Player));
                getPieceObjectByPosition(move.Start.Item1, move.Start.Item2).setPieceColor(getColor(Space.Empty));
                mainForm.ActiveForm.Refresh();
                if(waitTime > 0)
                    System.Threading.Thread.Sleep(waitTime);
                endTurnEvent(this, null);
            }
            else
            {
                displayMessage(getColor(GM.playersTurn).ToString() + "'s turn", GM.playersTurn);
                //System.Windows.Forms.MessageBox.Show(GM.getPreviousPlayersTurn() + "'s turn is over. Next turn goes to: " + GM.getPlayersTurn());
            }
        }

        public void exitEvent(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void resetTurnEvent(object sender, EventArgs e) //  Swapping the new position with the old position.
        {
            if(reset1 != null && reset2 != null)
            {
                //Swapping the piece color
                Color temp = reset2.getPieceColor();
                reset2.setPieceColor(reset1.getPieceColor());
                reset1.setPieceColor(temp);

                //Moving the pieces on the board
                GM.gameBoard.setSpace(reset2.getPosition()[0], reset2.getPosition()[1],
                    GM.gameBoard.getSpace(reset1.getPosition()[0], reset1.getPosition()[1]));
                // GM.gameBoard.setSpace(piece.getPosition()[0], piece.getPosition()[1], playingPieceTurn);

                GM.gameBoard.setSpace(reset1.getPosition()[0], reset1.getPosition()[1], Space.Empty);
                reset1 = null;
                reset2 = null;
                clearAllHighlighting();
                made_move = false;
                return;
            }
            else
            {
                System.Console.WriteLine("Nothing to undo");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public pieceObject getPieceObjectByPosition(int i, int j)
        {
            for (int n = 0; n < count; n++)
            {
                int[] p = all_pieces[n].getPosition();
                if (p[0] == i && p[1] == j)
                {
                    System.Console.WriteLine("Found a match!");
                    System.Console.WriteLine("Received: " + i + ", " + j + "  Matched with: " + p[0] + ", " + p[1]);
                    return all_pieces[n];
                }
            }
            return null;
        }

        private int getYFromIndex(int i, int j, int width, int xstart, int ystart)
        {
            return ystart + (2 * i) * width;
        }

        private int getIFromXY(int x, int y, int width, int xstart, int ystart)
        {
            return (y - ystart + width) / (2 * width);
        }

        private int getXFromIndex(int i, int j, int width, int xstart, int ystart)
        {
            return xstart + (2 * j - i) * width;
        }

        private int getJFromXY(int x, int y, int width, int xstart, int ystart)
        {
            int i = getIFromXY(x, y, width, xstart, ystart);
            return (((x - xstart + width / 2) / width) + i) / 2;
        }

        private Color getColor(Space sp)
        {
            switch (sp)
            {
                case Space.Player1:
                    return Color.Orange;
                case Space.Player2:
                    return Color.Yellow;
                case Space.Player3:
                    return Color.Green;
                case Space.Player4:
                    return Color.Blue;
                case Space.Player5:
                    return Color.Purple;
                case Space.Player6:
                    return Color.Red;
            }
            return Color.Gray;
        }

        public void InitializePieceControls()
        {
            int width = 15;
            int del = 3;
            int ystart = 50;
            int xstart = ystart + 4 * width;

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (Board.isSpace(i, j))
                    {
                        Space sp = GM.gameBoard.getSpace(i, j);
                        int xPos = getXFromIndex(i, j, width, xstart, ystart);
                        int yPos = getYFromIndex(i, j, width, xstart, ystart);

                        pieceObject piece = new pieceObject(getColor(sp), i, j);
                        piece.Click += pieceClicked;
                        piece.Size = new System.Drawing.Size(20, 20);
                        piece.Location = new System.Drawing.Point(xPos - del, yPos - del);

                        piece.BackColor = getColor(sp);
                        this.Controls.Add(piece);
                        all_pieces[count] = piece;
                        count++;
                    }
                }
            }
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Make the gui non resizable.
            System.Console.WriteLine("There are " + count + " pieces");
            //count = 0;
        }

        

        void pieceClicked(object sender, EventArgs e)
        {
            if (made_move)
            {
                System.Console.WriteLine("You have already made a move");
                return;
            }
            pieceObject piece = (pieceObject)sender;
            Space playingPieceTurn = GM.gameBoard.getSpace(piece.getPosition()[0], piece.getPosition()[1]);
            System.Console.WriteLine("This piece belongs to: " + playingPieceTurn);

            if (GM.playersTurn != playingPieceTurn && piece.getPieceColor() != Color.Gray)
            {
                System.Windows.Forms.MessageBox.Show("It's " + GM.getPlayersTurn() + "'s turn.");
                return;
                //System.Windows.Forms.MessageBox.Show("Its not your turn");
            }


            if (piece.highlighted)
            {
                System.Console.WriteLine("You have selected a highlighted piece.");

                //Swapping the piece color

                Color temp = piece.getPieceColor();
                piece.setPieceColor(hold.getPieceColor());
                hold.setPieceColor(temp);

                //Moving the pieces on the board
                GM.gameBoard.setSpace(piece.getPosition()[0], piece.getPosition()[1],
                GM.gameBoard.getSpace(hold.getPosition()[0], hold.getPosition()[1]));
               // GM.gameBoard.setSpace(piece.getPosition()[0], piece.getPosition()[1], playingPieceTurn);

                GM.gameBoard.setSpace(hold.getPosition()[0], hold.getPosition()[1], Space.Empty);

                reset1 = piece;
                reset2 = hold;

                clearAllHighlighting();
                made_move = true;
                return;
            }
            clearAllHighlighting();
            hold = piece;

            System.Console.WriteLine("Position: " + piece.Location + "Color: " + piece.BackColor);
            int[] p = piece.getPosition();
            System.Console.WriteLine("Position Array: " + p[0] + ", " + p[1]);
            List<Tuple<int, int>> moves = GM.gameBoard.getMoves(p[0], p[1]);

            foreach (Tuple<int, int> m in moves)
            {
                System.Console.WriteLine(m + " is a legal move");
                pieceObject legalPiece = getPieceObjectByPosition(m.Item1, m.Item2);
                legalPiece.highlight();
                System.Console.WriteLine("Space: " + GM.gameBoard.getSpace(p[0], p[1]));
            }
        }     

        private void startGameBtn_Click(object sender, EventArgs e)
        {
            if (numHumansBox.SelectedIndex < 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select the number of players.");
                return;
            }

            GM = new GameManager();
            GM.StartGame(numHumansBox.SelectedIndex);
            waitTime = waitBetweenTurns.Value;

            clearForm();
            InitializePieceControls();
            createGameButtons();
            gameHasStarted = true;
            displayGameStartMessage();

            //if the first player is an AI, take the first turn
            if (GM.playerIsHuman[(int)GM.playersTurn - 2] == false)
            {
                Move move = GM.MakeNPCMove();

                GM.gameBoard.setSpace(move.End.Item1, move.End.Item2, move.Player);
                GM.gameBoard.setSpace(move.Start.Item1, move.Start.Item2, Space.Empty);
                getPieceObjectByPosition(move.End.Item1, move.End.Item2).setPieceColor(getColor(move.Player));
                getPieceObjectByPosition(move.Start.Item1, move.Start.Item2).setPieceColor(getColor(Space.Empty));
                mainForm.ActiveForm.Refresh();
                System.Threading.Thread.Sleep(500);
                endTurnEvent(this, null);
            }
        }

        private void numHumansBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            numNPCbox.Text = (6 - numHumansBox.SelectedIndex).ToString();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        { }

        private void clearForm()
        {
            Form currentForm = mainForm.ActiveForm;

            chineseCheckersLabel.Hide();
            numHumansBox.Hide();
            numNPCbox.Hide();
            startGameBtn.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            waitBetweenTurns.Hide();

            currentForm.BackgroundImage = null;
            currentForm.BackColor = Color.Black;
            currentForm.Width = 600;
            currentForm.Height = 650;
        }

        private void createGameButtons()
        {
            Button endTurn = new Button();
            endTurn.Location = new Point(500, 575);
            endTurn.Text = "End Turn";
            endTurn.BackColor = Color.Wheat;
            endTurn.Click += new EventHandler(endTurnEvent);
            this.Controls.Add(endTurn);

            Button resetTurn = new Button();
            resetTurn.Location = new Point(500, 542);
            resetTurn.Text = "Reset Turn";
            resetTurn.BackColor = Color.Wheat;
            resetTurn.Click += new EventHandler(resetTurnEvent);
            this.Controls.Add(resetTurn);
        }

        private void displayGameStartMessage()
        {
            StringBuilder message = new StringBuilder("The human players are: \n");
            for (int i = 0; i < 6; i++)
            {
                if (GM.playerIsHuman[i] == true)
                {
                    message.Append(getColor((Space)(i + 2)).ToString());
                    message.Append("\n");
                }
            }
            message.Append(getColor(GM.playersTurn).ToString());
            message.Append(" will start.");
            System.Windows.Forms.MessageBox.Show(message.ToString());
            displayMessage(getColor(GM.playersTurn).ToString() + " starts.", GM.playersTurn);
        }

        private void displayMessage(string message, Space player)
        {
            if (!messageExists)
            {
                gameMessage = label6;
                gameMessage.Location = new Point(50, 550);
                //gameMessage.BackColor = Color.White;
                gameMessage.Show();
                messageExists = true;
            }
            gameMessage.Text = message;
            gameMessage.ForeColor = getColor(player);
        }
    }
}



