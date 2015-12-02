using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersLib
{
    abstract public class GameManager
    {
        public Board gameBoard;

        protected GameManager()
        {
            gameBoard = new Board();
        }

        ~GameManager()
        {

        }

        

    }
}
