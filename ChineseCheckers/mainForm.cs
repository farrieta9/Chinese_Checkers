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
        public mainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            int width = 15;
            int height = 15;
            int xPos = 250;
            int yPos = 50;

            //Player 1
            List<SolidBrush> playerOne = new List<SolidBrush>();
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    xPos = 250;
                    yPos = 50;
                }
                else if (i == 1)
                {
                    xPos = 230; yPos = 80;
                }
                else if (i == 2)
                {
                    xPos = 270; yPos = 80;
                }
                else if (i == 3)
                {
                    xPos = 210; yPos = 105;
                }
                else if (i == 4)
                {
                    xPos = 250; yPos = 105;
                }
                else if (i == 5)
                {
                    xPos = 290; yPos = 105;
                }
                else if (i == 6)
                {
                    xPos = 190; yPos = 130;
                }
                else if (i == 7)
                {
                    xPos = 230; yPos = 130;
                }
                else if (i == 8)
                {
                    xPos = 270; yPos = 130;
                }
                else if (i == 9)
                {
                    xPos = 310; yPos = 130;
                }
                SolidBrush newPiece = new SolidBrush(Color.Blue);
                playerOne.Add(newPiece);
                e.Graphics.FillEllipse(newPiece, xPos, yPos, width, height);

                //Player 2
            }
        }*/

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {
            int xstart = 100;
            int ystart = 50;
            int width = 15;
            int height = 15;

            List<SolidBrush> playerOne = new List<SolidBrush>();
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (Board.isSpace(i, j))
                    {
                        Space sp = thisBoard.getSpace(i, j);
                        int xPos = xstart + (2 * j - i) * width;
                        int yPos = ystart + (2 * i) * width;
                        SolidBrush newPiece = new SolidBrush(getColor(sp));

                        playerOne.Add(newPiece);
                        e.Graphics.FillEllipse(newPiece, xPos, yPos, width, height);
                    }
                }
            }
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
            return Color.Brown;
        }
    }
}
