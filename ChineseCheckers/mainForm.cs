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
        private Board thisBoard = new Board();
        public event PaintEventHandler paint;
        public int x = 50; //This is only here for testing purposes.
        public int y = 50;
        public mainForm()
        {
            InitializeComponent();
            InitializePieceControls();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                        Space sp = thisBoard.getSpace(i, j);
                        int xPos = getXFromIndex(i, j, width, xstart, ystart);
                        int yPos = getYFromIndex(i, j, width, xstart, ystart);

                        pieceObject piece = new pieceObject(getColor(sp));
                        piece.Click += myButton_Click;
                        piece.Size = new System.Drawing.Size(20, 20);
                        piece.Location = new System.Drawing.Point(xPos - del, yPos - del);

                        piece.BackColor = getColor(sp);
                        this.Controls.Add(piece);
                    }
                }
            }
        }

        void myButton_Click(object sender, EventArgs e)
        {
            pieceObject piece = (pieceObject)sender;
            piece.setPieceColor(Color.White);
            System.Console.WriteLine("Position: " + piece.Location + "Color: " + piece.BackColor);
            piece.setPosition(this.x, this.y);
            this.x += 20;
            this.y += 20;
        }
        
        //private void mainForm_Paint(object sender, PaintEventArgs e)
        //{
        //    /*pieceObject piece = new pieceObject();
        //    EventHandler myHandler = new EventHandler(myButton_Click);
        //    piece.Click += myHandler;
        //    piece.Location = new System.Drawing.Point(20, 20);
        //    piece.Size = new System.Drawing.Size(20, 20);
        //    this.Controls.Add(piece);
        //    */

        //    int width = 15;
        //    int del = 3;
        //    int ystart = 50;
        //    int xstart = ystart+4 * width;

        //    SolidBrush whiteSB = new SolidBrush(Color.White);

        //    for (int i = 0; i < 17; i++)
        //    {
        //        for (int j = 0; j < 17; j++)
        //        {
        //            if (Board.isSpace(i, j))
        //            {
        //                Space sp = thisBoard.getSpace(i, j);
        //                int xPos = getXFromIndex(i, j, width, xstart, ystart);
        //                int yPos = getYFromIndex(i, j, width, xstart, ystart);

        //                pieceObject piece = new pieceObject(e, xPos - del, yPos - del, getColor(sp));
        //                EventHandler myhandler = new EventHandler((a, b)=>myButton_Click(sender, e, piece));
        //                piece.Click += myhandler;
        //                piece.Size = new System.Drawing.Size(20, 20);
        //                piece.Location = new System.Drawing.Point(xPos - del, yPos - del);
        //                //piece.BackColor = Color.Transparent;
        //                //piece.ForeColor = Color.Transparent;
        //                piece.BackColor = getColor(sp);

        //                this.Controls.Add(piece);

        //                //e.Graphics.FillEllipse(whiteSB, xPos - del, yPos - del, width + 2 * del, width + 2 * del);

        //                //SolidBrush newPiece = new SolidBrush(getColor(sp));

        //                //e.Graphics.FillEllipse(newPiece, xPos, yPos, width, width);
        //            }
        //        }
        //    }
        //}

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
            return (((x - xstart+ width/2) / width) + i) / 2;
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

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form currentForm = mainForm.ActiveForm;
            currentForm.BackgroundImage = null;
            currentForm.BackColor = Color.Black;
            currentForm.Width = 600;
            currentForm.Height = 650;
            Button endTurn = new Button();
            endTurn.Location = new Point(485, 575);
            endTurn.Text = "End Turn";
            endTurn.BackColor = Color.Wheat;
            endTurn.Click += new EventHandler(endTurnEvent);
            this.Controls.Add(endTurn);
        }

        public void endTurnEvent(object sender, EventArgs e)
        {
            System.Console.WriteLine("You have ended your turn!");
        }
    }
}


public class pieceObject : UserControl
{
    private Color _color;
    private int radius = 15;
    private int xPos;
    private int yPos;
    public pieceObject(Color color) { _color = color; }

    protected override void OnPaint(PaintEventArgs e)
    {
        using(SolidBrush newPiece = new SolidBrush(_color))
        {
            e.Graphics.FillEllipse(newPiece, 3, 3, radius, radius);
        }
    }
    public Color getPieceColor() { return _color; }
    public int getRadius() { return radius; }
    public int getXPos() { return xPos; }
    public int getYPos() { return yPos; }
    
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

