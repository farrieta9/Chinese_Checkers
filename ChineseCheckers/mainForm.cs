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
using System.Threading;

namespace ChineseCheckers
{

    public partial class mainForm : Form
    {
        ClientGameManager GM;
        
        public event PaintEventHandler paint;
        public pieceObject[] all_pieces = new pieceObject[121];
        public int count = 0;

        public mainForm()
        {
            InitializeComponent();
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
            System.Console.WriteLine("You have ended your turn!");

            //This part is not done
            Move move = null;
            GM.SendMoveToServer(move);
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
            for(int i = 0; i < 17; i++)
            {
                for(int j = 0; j < 17; j++)
                {
                    if(Board.isSpace(i, j))
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
            System.Console.WriteLine("There are " + count + " pieces");
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GM = new ClientGameManager();

            Form currentForm = mainForm.ActiveForm;

            singlePlayerBtn.Hide();
            joinBtn.Hide();
            hostBtn.Hide();
                    
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
        }

        void pieceClicked(object sender, EventArgs e)
        {
            clearAllHighlighting();
            pieceObject piece = (pieceObject)sender;
            //piece.setPieceColor(Color.White);
            System.Console.WriteLine("Position: " + piece.Location + "Color: " + piece.BackColor);
            int[] p = piece.getPosition();
            System.Console.WriteLine("Position Array: " + p[0] + ", " + p[1]);
            List<Tuple<int, int>> moves = GM.gameBoard.getMoves(p[0], p[1]);
            foreach(Tuple<int, int> m in moves)
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

        private void hostBtn_Click(object sender, EventArgs e)
        {
            GM = new ClientGameManager();
            GM.HostGame();
        } 

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        { }
    }
}

public class pieceObject : UserControl
{
    private Color _color;
    private int radius = 15;
    private int xPos;
    private int yPos;
    public int[] position = new int[2];
    public bool highlighted = false;
    public pieceObject(Color color, int i, int j)
    {
        _color = color;
        position[0] = i;
        position[1] = j;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using(SolidBrush newPiece = new SolidBrush(_color))
        {
            e.Graphics.FillEllipse(newPiece, 3, 3, radius, radius);
        }
    }

    public int[] getPosition()
    {
        return position;
    }

    public void highlight()
    {
        BackColor = ControlPaint.Light(_color, 1);
        highlighted = true;
    }

    public void removeHighlight()
    {
        BackColor = _color;
        highlighted = false;
    }

    public void setPieceColor(Color newColor)
    {   _color = newColor;
        BackColor = newColor;
    }

    public void setPosition(int x, int y)
    {
        xPos = x;
        yPos = y;
        Location = new Point(x, y);
    }
}

