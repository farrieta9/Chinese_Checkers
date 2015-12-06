using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckersLib
{
    public enum Space {None, Empty, Player1, Player2, Player3, Player4, Player5, Player6 }
    
    public class Board
    {
        public static Space[,] StartingBoard = new Space[17, 17] {
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1, Space.Player1, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1, Space.Player1, Space.Player1, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            { Space.Player6, Space.Player6, Space.Player6, Space.Player6,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player2, Space.Player2, Space.Player2, Space.Player2,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None, Space.Player6, Space.Player6, Space.Player6,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player2, Space.Player2, Space.Player2,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None, Space.Player6, Space.Player6,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player2, Space.Player2,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None, Space.Player6,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player2,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player5,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player3,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player5, Space.Player5,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player3, Space.Player3,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player5, Space.Player5, Space.Player5,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player3, Space.Player3, Space.Player3,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player5, Space.Player5, Space.Player5, Space.Player5,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player3, Space.Player3, Space.Player3, Space.Player3},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4, Space.Player4, Space.Player4, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4, Space.Player4, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None}
        };

        public Space playersTurn = Space.Player1;

        public Board(Board SB)
        {
            setBoard(SB.currBoard);
        }

        public Board(Space[,] SB)
        {
            setBoard(SB);
        }

        public Board()
        {
            setBoard(StartingBoard);
        }

        public static Space getStartSpace(int i, int j)
        {
            if(i >= 0 && i < 17 && j >= 0 && j < 17)
                return StartingBoard[i, j];
            return Space.None;
        }

        public static bool isSpace(int i, int j)
        {
            return getStartSpace(i, j) != Space.None;
        }

        public bool isEmpty(int i, int j)
        {
            return getSpace(i, j) == Space.Empty;
        }

        public bool isPlayer(int i, int j)
        {
            var s = getSpace(i, j);
            return  s != Space.Empty && s != Space.None;
        }

        private Space[,] currBoard;

        public Space getSpace(int i, int j)
        {
            if (i >= 0 && i < 17 && j >= 0 && j < 17)
                return currBoard[i, j];
            return Space.None;
        }

        public bool setSpace(int i, int j, Space sp)
        {
            if (validLocation(i, j) && currBoard[i, j] != Space.None && sp != Space.None)
            {
                currBoard[i, j] = sp;
                return true;
            }
            return false;
        }

        public void setBoard(Space[,] SB)
        {
            currBoard = new Space[17, 17];
            for(int i = 0; i < 17; ++i)
            {
                for (int j = 0; j < 17; ++j)
                {
                    currBoard[i, j] = SB[i, j];
                }
            }
        }

        public Space[,] getBoard()
        {
            return currBoard;
        }

        public List<Tuple<int, int>> getMoves(int i, int j)
        {
            List<Tuple<int, int>> l = new List<Tuple<int, int>>();
            if (!isPlayer(i, j)) return l;

            bool[,] map = new bool[17, 17];
            map[i, j] = true;

            Queue<Tuple<int, int>> jump = new Queue<Tuple<int, int>>();

            //walking
            for (int id = -1; id <= 1; ++id)
            {
                for (int jd = -1; jd <= 1; ++jd)
                {
                    if (id + jd == 0) continue;
                    if (isEmpty(i + id, j + jd))
                        l.Add(new Tuple<int, int>(i + id, j + jd));
                    else
                        jump.Enqueue(new Tuple<int, int>(i + 2 * id, j + 2 * jd));

                }
            }

            //jumping
            while (jump.Count > 0)
            {
                Tuple<int, int> next = jump.Dequeue();
                int ii = next.Item1;
                int jj = next.Item2;
                if (isEmpty(ii, jj) && !map[ii, jj])
                {
                    map[ii, jj] = true;
                    l.Add(next);
                    for(int id = -1; id <= 1; ++id)
                    {
                        for (int jd = -1; jd <= 1; ++jd)
                        {
                            if (id + jd == 0) continue;
                            if (isPlayer(ii + id, jj + jd))
                                jump.Enqueue(new Tuple<int, int>(ii + 2 * id, jj + 2 * jd));
                        }
                    }
                }
            }
            return l;

        }

        public List<Move> getPlayerMoves(Space player)
        {
            List<Move> moves= new List<Move>();
            for (int i = 0; i < 17; ++i)
            {
                for (int j = 0; j < 17; ++j)
                {
                    if(currBoard[i,j] == player)
                    {
                        Tuple<int, int> start = new Tuple<int, int>(i, j);
                        List<Tuple<int, int>>  movelist =getMoves(i, j);
                        foreach(Tuple<int, int> end in movelist)
                        {
                            Move mv = new Move();
                            mv.End = end;
                            mv.Start = start;
                            mv.Player = player;
                            moves.Add(mv);
                        }
                    }
                }
            }
            return moves;
        }

        public String getPlayersTurn()
        {
            switch (playersTurn)
            {
                case Space.Player1:
                    return "Orange";
                case Space.Player2:
                    return "Yellow";
                case Space.Player3:
                    return "Green";
                case Space.Player4:
                    return "Blue";
                case Space.Player5:
                    return "Purple";
                case Space.Player6:
                    return "Red";
                default:
                    return "none";
            }
        }

        public String getPreviousPlayersTurn()
        {
            switch (playersTurn)
            {
                case Space.Player1:
                    return "Red";
                case Space.Player2:
                    return "Orange";
                case Space.Player3:
                    return "Yellow";
                case Space.Player4:
                    return "Green";
                case Space.Player5:
                    return "Blue";
                case Space.Player6:
                    return "Purple";
                default:
                    return "none";
            }
        }

        private bool validLocation(int i, int j)
        {
            return i >= 0 && i < 17 && j >= 0 && j < 17;
        }

        public Space getWhosTurnItIs()
        {
            return playersTurn;
        }

        public void nextPlayersTurn()
        {
            if (playersTurn == Space.Player1)
                playersTurn = Space.Player2;
            else if (playersTurn == Space.Player2)
                playersTurn = Space.Player3;
            else if (playersTurn == Space.Player3)
                playersTurn = Space.Player4;
            else if (playersTurn == Space.Player4)
                playersTurn = Space.Player5;
            else if (playersTurn == Space.Player5)
                playersTurn = Space.Player6;
            else if (playersTurn == Space.Player6)
                playersTurn = Space.Player1;
            else
            {
                playersTurn = Space.None;
                System.Console.WriteLine("Error,  players turn has been set to None/null");
            }
        }
    }
}
