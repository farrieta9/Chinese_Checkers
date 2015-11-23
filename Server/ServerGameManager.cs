using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerGameManager : CheckersLib.GameManager
    {
        ServerGameManager()
        {
            
        }

        ~ServerGameManager()
        {

        }

        private void ValidateMove()
        {
            //Recieve as input a players move
            //If it is legal for that piece to move to that location
            //return true
            //else
            //return false
        }

        private void updatePlayerMove()
        {
            
        }

        private void MakeNPCMove()
        {
            //scan through all the players pieces calling list legal moves on each one, and recording the move which will move a piece the farthest
            //when finished with scan, make the move that has been saved
        }
    }
}
