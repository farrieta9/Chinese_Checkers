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

        public bool checkWinningMoves(Space player)
        {
            //Winning areas for each player
            //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
            //player 2 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]
            //player 3 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
            //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
            //player 5 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
            //player 6 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]

            //check player1
            if (player == Space.Player1)
            {
                //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
                for (int i = 13; i <= 16; i++)
                {
                    for (int j = 12; j >= (9 + (i - 13)); j--)
                    {
                        if (gameBoard.getSpace(i, 0) != Space.Player1)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //check player2
            if (player == Space.Player2)
            {
                //player 2 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]
                for (int i = 9; i <= 12; i++)
                {
                    for (int j = 13; j <= (13 + (i - 9)); j++)
                    {
                        if (gameBoard.getSpace(i, j) != Space.Player2)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //check player3
            if (player == Space.Player3)
            {
                //player 3 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
                for (int i = 4; i <= 7; i++)
                {
                    for (int j = 9; j <= (12 - (i - 4)); j++)
                    {
                        if (gameBoard.getSpace(i, j) != Space.Player3)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            //check player4
            if (player == Space.Player4)
            {
                //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 4; j <= (4 + i); j++)
                    {
                        if (gameBoard.getSpace(i, j) != Space.Player4)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            
            //check player5
            if (player == Space.Player5)
            {
                //player 5 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
                for (int i = 4; i <= 7; i++)
                {
                    for (int j = 0; j <= (3 - (i - 4)); j++)
                    {
                        if (gameBoard.getSpace(i, j) != Space.Player5)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            
            //check player4
            if (player == Space.Player6)
            {
                //player 6 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]
                for (int i = 9; i <= 12; i++)
                {
                    for (int j = 4; j <= (4 + (i - 9)); j++)
                    {
                        if (gameBoard.getSpace(i, j) != Space.Player6)
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
