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
        private Board thisBoard = new Board();
        public mainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainForm_Paint(object sender, PaintEventArgs e)
        {  
            
            int width = 15;
            int del = 3;
            int ystart = 50;
            int xstart = ystart+4 * width;

            SolidBrush whiteSB = new SolidBrush(Color.White);

            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    if (Board.isSpace(i, j))
                    {
                        Space sp = thisBoard.getSpace(i, j);
                        int xPos = getXFromIndex(i, j, width, xstart, ystart);
                        int yPos = getYFromIndex(i, j, width, xstart, ystart);

                        e.Graphics.FillEllipse(whiteSB, xPos - del, yPos - del, width + 2 * del, width + 2 * del);

                        SolidBrush newPiece = new SolidBrush(getColor(sp));

                        e.Graphics.FillEllipse(newPiece, xPos, yPos, width, width);
                    }
                }
            }
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
    }
}
