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
        private Graphics pieceGraphics;
        private SolidBrush brush;
        private Rectangle rect;
        private Color _color;
        private int xPos;
        private int yPos;
        public int[] position = new int[2];
        public bool highlighted = false;

        public pieceObject(Graphics pGraphics, Color color, int i, int j)
        {            
            brush = new SolidBrush(color);
            pieceGraphics = pGraphics;
            //_color = color;
            position[0] = i;
            position[1] = j;
        }

        public Graphics getPieceGraphics()
        {
            return pieceGraphics;
        }

        public void setPieceGraphics(SolidBrush brush, Rectangle rect)
        {
            pieceGraphics.FillEllipse(brush, rect);
        }

        public int[] getPosition()
        {
            return position;
        }

        public void setPosition(int x, int y)
        {
            xPos = x;
            yPos = y;
            Location = new Point(x, y);
        }

        public Color getPieceColor()
        {
            return brush.Color;
            //return _color;
        }

        public void setPieceColor(Color newColor)
        {
            brush = new SolidBrush(newColor);
            pieceGraphics.FillEllipse(brush, rect);
            //_color = newColor;
            BackColor = newColor;            
        }

        public void highlight()
        {
            BackColor = ControlPaint.Light(_color, 1);
            highlighted = true;
        }

        public void removeHighlight()
        {
            BackColor = brush.Color;
            //BackColor = _color;
            highlighted = false;
        }

        

        
    }
}
