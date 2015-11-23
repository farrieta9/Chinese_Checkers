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

        private bool ValidateMove( CheckersLib.Move move )
        {
            //Recieve as input a players move
            //Check that the player matches
            if (this.gameBoard.getSpace(move.Start.Item1, move.Start.Item2) != move.Player)
                return false;
            //Quick check that end space is empty
            if (!this.gameBoard.isEmpty(move.End.Item1, move.End.Item2))
                return false;
            //If it is legal for that piece to move to that location, return true
            if (this.gameBoard.getMoves(move.Start.Item1, move.Start.Item2).Contains(move.End))
                return true;
            else
                return false;
        }

        private void updatePlayerMove()
        {
            //receive move
            //make changes to the board
            //push move to other players
        }

        private /* CheckersLib.Move */ void MakeNPCMove()
        {
            //scan through all the players pieces calling list legal moves on each one, and recording the move which will move a piece the farthest
            //when finished with scan, make the move that has been saved
        }
    }
}
