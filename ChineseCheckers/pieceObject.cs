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
            using (SolidBrush newPiece = new SolidBrush(_color))
            {
                e.Graphics.FillEllipse(newPiece, 3, 3, radius, radius);
            }
        }

        public int[] getPosition()
        {
            return position;
        }

        public Color getPieceColor()
        {
            return _color;
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
        {
            _color = newColor;
            BackColor = newColor;
        }

        public void setPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
            Location = new Point(x, y);
        }
    }
}
