using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using CheckersLib;

namespace ChineseCheckers
{
    public class pieceObject : UserControl
    {
        private Graphics pieceGraphics;
        private SolidBrush brush;
        private Rectangle rectangle;
        private Color _color;
        private int xPos;
        private int yPos;
        public int[] position = new int[2];
        public bool highlighted = false;

        public pieceObject(Graphics graph, Rectangle rect, Color color, int i, int j)
        {
            pieceGraphics = graph;
            brush = new SolidBrush(color);
            rectangle = rect;            
            _color = color;
            position[0] = i;
            position[1] = j;
        }

        public Graphics getPieceGraphics()
        {
            return pieceGraphics;
        }

        public void setPieceGraphics(SolidBrush newBrush, Rectangle rect)
        {
            pieceGraphics = CreateGraphics();
            brush = newBrush;
            rectangle = rect;
            pieceGraphics.FillEllipse(brush, rectangle);
        }

        public void setPieceGraphics(Graphics graph)
        {
            pieceGraphics = graph;
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
            return _color;
        }

        public void setPieceColor(Color newColor)
        {
            brush = new SolidBrush(newColor);

            _color = newColor;
            BackColor = newColor;            
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

        

        
    }
}
