﻿using System;
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
            Space s = getSpace(i, j);
            Space goal = opp(s);
            if (s==Space.Empty || s == Space.None) return l;

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
                    {
                        Space n = getStartSpace(i + id, j + jd);
                        if ((n == s) || (n == goal) || (n==Space.Empty))
                        {
                            l.Add(new Tuple<int, int>(i + id, j + jd));
                        }
                    }
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
                    Space n = getStartSpace(ii, jj);
                    if ((n == s) || (n == goal) || (n == Space.Empty))
                    {
                        l.Add(next);
                    }
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

        private Space opp(Space s)
        {
            switch (s)
            {
                case Space.Player1:
                    return Space.Player4;
                case Space.Player2:
                    return Space.Player5;
                case Space.Player3:
                    return Space.Player6;
                case Space.Player4:
                    return Space.Player1;
                case Space.Player5:
                    return Space.Player2;
                case Space.Player6:
                    return Space.Player3;
                default:
                    return Space.Empty;
            }
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

        

        private bool validLocation(int i, int j)
        {
            return i >= 0 && i < 17 && j >= 0 && j < 17;
        }

    }
}
