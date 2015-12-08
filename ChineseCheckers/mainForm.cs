using System;
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
            System.Console.WriteLine(GM.gameBoard.getWhosTurnItIs() + " has ended their turn.");
            
            if (GM.checkWinningMoves())
            {
                System.Windows.Forms.MessageBox.Show(GM.gameBoard.getPlayersTurn() + " is the winna winna chicken dinna!");
                // @todo End game and return to initial menu
            }
            GM.gameBoard.nextPlayersTurn();
            reset1 = reset2 = null;
            made_move = false;

            System.Windows.Forms.MessageBox.Show(GM.gameBoard.getPreviousPlayersTurn() + "'s turn is over. Next turn goes to: " + GM.gameBoard.getPlayersTurn());
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
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!gameHasStarted)
            {
                GM = new GameManager();

                Form currentForm = mainForm.ActiveForm;

                singlePlayerBtn.Hide();
                multiplayerBtn.Hide();
                chineseCheckersLabel.Hide();

                currentForm.BackgroundImage = null;
                currentForm.BackColor = Color.Black;
                currentForm.Width = 600;
                currentForm.Height = 650;
                InitializePieceControls();

                Button endTurn = new Button();
                endTurn.Location = new Point(20, 575);
                endTurn.Text = "End Turn";
                endTurn.BackColor = Color.Wheat;
                endTurn.Click += new EventHandler(endTurnEvent);
                this.Controls.Add(endTurn);

                Button resetTurn = new Button();
                resetTurn.Location = new Point(20, 542);
                resetTurn.Text = "Reset Turn";
                resetTurn.BackColor = Color.Wheat;
                resetTurn.Click += new EventHandler(resetTurnEvent);
                this.Controls.Add(resetTurn);

                gameHasStarted = true;
                System.Windows.Forms.MessageBox.Show("It's " + GM.gameBoard.getPlayersTurn() + "'s turn.");
            }
            else
            {
                System.Console.WriteLine("Game has already started.  Exit to begin a new game");
            }
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

            if (GM.gameBoard.getWhosTurnItIs() != playingPieceTurn && piece.getPieceColor() != Color.Gray)
            {
                System.Windows.Forms.MessageBox.Show("It's " + GM.gameBoard.getPlayersTurn() + "'s turn.");
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void multiplayerBtn_Click(object sender, EventArgs e)
        {
            newGameToolStripMenuItem_Click(sender, e);
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        { }
    }
}



