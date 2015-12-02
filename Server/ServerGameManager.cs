using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ServerGameManager : CheckersLib.GameManager
    {
        /// <summary>
        /// Checks if the input move is legal. Checks by calling Board.getMoves to see if the move is listed in the returned list.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public bool ValidateMove( CheckersLib.Move move )
        {
            //Receive as input a players move
            //Check that the player matches
            if (this.gameBoard.getSpace(move.Start.Item1, move.Start.Item2) != move.Player)
                return false;
            //Quick check that endCheckersLib.Space is empty
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

        public bool checkWinningMoves(CheckersLib.Space player)
        {
            //Winning areas for each player
            //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
            //player 2 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]
            //player 3 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
            //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
            //player 5 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
            //player 6 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]

            //check player1
            if (player ==CheckersLib.Space.Player1)
            {
                //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
                for (int i = 13; i <= 16; i++)
                {
                    for (int j = 12; j >= (9 + (i - 13)); j--)
                    {
                        if (gameBoard.getSpace(i, 0) !=CheckersLib.Space.Player1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //check player2
            if (player ==CheckersLib.Space.Player2)
            {
                //player 2 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]
                for (int i = 9; i <= 12; i++)
                {
                    for (int j = 13; j <= (13 + (i - 9)); j++)
                    {
                        if (gameBoard.getSpace(i, j) !=CheckersLib.Space.Player2)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //check player3
            if (player ==CheckersLib.Space.Player3)
            {
                //player 3 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
                for (int i = 4; i <= 7; i++)
                {
                    for (int j = 9; j <= (12 - (i - 4)); j++)
                    {
                        if (gameBoard.getSpace(i, j) !=CheckersLib.Space.Player3)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //check player4
            if (player ==CheckersLib.Space.Player4)
            {
                //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 4; j <= (4 + i); j++)
                    {
                        if (gameBoard.getSpace(i, j) !=CheckersLib.Space.Player4)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            
            //check player5
            if (player ==CheckersLib.Space.Player5)
            {
                //player 5 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
                for (int i = 4; i <= 7; i++)
                {
                    for (int j = 0; j <= (3 - (i - 4)); j++)
                    {
                        if (gameBoard.getSpace(i, j) !=CheckersLib.Space.Player5)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            
            //check player4
            if (player ==CheckersLib.Space.Player6)
            {
                //player 6 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]
                for (int i = 9; i <= 12; i++)
                {
                    for (int j = 4; j <= (4 + (i - 9)); j++)
                    {
                        if (gameBoard.getSpace(i, j) !=CheckersLib.Space.Player6)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            return false;
        }
    }
}
