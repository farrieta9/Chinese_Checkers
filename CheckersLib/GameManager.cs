using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersLib
{
    public class GameManager
    {
        public Board gameBoard;

        /// <summary>
        /// Stores the player whos turn it is currently.
        /// </summary>
        public Space playersTurn;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameManager()
        {
            gameBoard = new Board();
            playersTurn = Space.None;
        }

        public GameManager(Board GB)
        {
            gameBoard = GB;
        }

        ~GameManager()
        {

        }

        /// <summary>
        /// Checks if the input move is legal. Checks by calling Board.getMoves to see if the move is listed in the returned list.
        /// </summary>
        /// <param name="move"></param>
        /// <returns>True if it is a valid move.</returns>
        public bool ValidateMove(CheckersLib.Move move)
        {
            //Receive as input a players move
            //Check that it is that players turn
            if (move.Player != this.playersTurn)
                return false;
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

        //scan through all the players pieces calling list legal moves on each one, and recording the move which will move a piece the farthest
        //when finished with scan, make the move that has been saved
        private CheckersLib.Move MakeNPCMove()
        {
            List<Move> moves = gameBoard.getPlayerMoves(player);
            int bestscore = 0;
            Move m = moves.First();
            foreach (Move curr in moves)
            {
                int cs = Score(curr);
                if (cs >= bestscore)
                {
                    bestscore = cs;
                    m = curr;
                }

            }
            return m;
        }

        /// <summary> Checks all 6 players to determine if one of them wins </summary> 
        /// <returns> true if a player has won, false otherwise </returns>
        public bool checkWinningMoves()
        {
            //Winning areas for each player
            //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
            //player 2 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]
            //player 3 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
            //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
            //player 5 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
            //player 6 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]

            bool winner = false;
            Space currPlayer = gameBoard.getWhosTurnItIs();

            if (currPlayer == Space.Player1)
            {
                winner = checkPlayer1(currPlayer);
            }
            else if (currPlayer == Space.Player2)
            {
                winner = checkPlayer2(currPlayer);
            }
            else if (currPlayer == Space.Player3)
            {
                winner = checkPlayer3(currPlayer);
            }
            else if (currPlayer == Space.Player4)
            {
                winner = checkPlayer4(currPlayer);
            }
            else if (currPlayer == Space.Player5)
            {
                winner = checkPlayer5(currPlayer);
            }
            else if (currPlayer == Space.Player6)
            {
                winner = checkPlayer6(currPlayer);
            }

            return winner;
        } // end method checkWinningMoves

        // Check if Player 1 has all her pieces in the winning spaces
        public bool checkPlayer1(Space player)
        {                    
            //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
            for (int i = 13; i <= 16; ++i)
            {
                for (int j = 12; j >= 9 + (i - 13); --j)
                {
                    // why was this at gameboard.getSpace(0, i)?! Took so long to test this...
                    Space checkPlayer = gameBoard.getSpace(i, j);
                    if (checkPlayer != Space.Player1)
                    {
                        return false;
                    }
                }
            }                           

            return true;
        }

        // Check if Player 2 has all her pieces in the winning spaces
        public bool checkPlayer2(Space player)
        {
            //player 2 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]
            for (int i = 9; i <= 12; ++i)
            {
                for (int j = 4; j <= 4 + (i - 9); ++j)
                {
                    if (gameBoard.getSpace(i, j) != Space.Player2)
                    {
                        return false;
                    }
                }
            }                

            return true;
        }

        // Check if Player 3 has all her pieces in the winning spaces
        public bool checkPlayer3(Space player)
        {
            //player 3 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
            for (int i = 4; i <= 7; ++i)
            {
                for (int j = 3; j >= i - 4; --j)
                {
                    if (gameBoard.getSpace(i, j) != Space.Player3)
                    {
                        return false;
                    }
                }
            }                

            return true;
        }

        // Check if Player 4 has all her pieces in the winning spaces
        public bool checkPlayer4(Space player)
        {
            //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
            for (int i = 0; i <= 3; i++)
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

        // Check if Player 5 has all her pieces in the winning spaces
        public bool checkPlayer5(Space player)
        {
            //player 5 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
            for (int i = 4; i <= 7; i++)
            {
                for (int j = 9 + (i - 4); j <= 12; j++)
                {
                    if (gameBoard.getSpace(i, j) != Space.Player5)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Check if Player 6 has all her pieces in the winning spaces
        public bool checkPlayer6(Space player)
        {
            //player 6 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]
            for (int i = 9; i <= 12; i++)
            {
                for (int j = 13; j <= (13 + (i - 9)); j++)
                {
                    if (gameBoard.getSpace(i, j) != Space.Player6)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int Score(Move mv)
        {
            int delx = mv.End.Item1 - mv.Start.Item1;
            int dely = mv.End.Item2 - mv.Start.Item2;
            switch (mv.Player)
            {
                case Space.Player1:
                    return dely;
                case Space.Player2:
                    return dely- delx;
                case Space.Player3:
                    return delx;
                case Space.Player4:
                    return -dely;
                case Space.Player5:
                    return delx- dely;
                case Space.Player6:
                    return -delx;
                default:
                    return 0;
            }
        }
    } // end Class GameManager
} // end namespace
