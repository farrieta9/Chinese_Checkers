using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CheckersLib
{
    enum Space {None, Empty, Player1, Player2, Player3, Player4, Player5, Player6 }
    class Board
    {
        public static Space[,] StartingBoard = new Space[17, 17] {
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1, Space.Player1, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player1, Space.Player1, Space.Player1, Space.Player1,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None},
            { Space.Player2, Space.Player2, Space.Player2, Space.Player2,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player6, Space.Player6, Space.Player6, Space.Player6,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None, Space.Player2, Space.Player2, Space.Player2,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player6, Space.Player6, Space.Player6,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None, Space.Player2, Space.Player2,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player6, Space.Player6,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None, Space.Player2,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player6,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player3,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player5,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player3, Space.Player3,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player5, Space.Player5,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player3, Space.Player3, Space.Player3,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player5, Space.Player5, Space.Player5,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None, Space.Player3, Space.Player3, Space.Player3, Space.Player3,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty,   Space.Empty, Space.Player5, Space.Player5, Space.Player5, Space.Player5},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4, Space.Player4, Space.Player4, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4, Space.Player4, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None},
            {    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None,    Space.None, Space.Player4,    Space.None,    Space.None,    Space.None,    Space.None}
        };

        public static Space getStartSpace(int i, int j)
        {
            if(i>=0 && i< 17 && j >= 0 && j < 17)
                return StartingBoard[i, j];
            return Space.None;
        }

        public static bool isSpace(int i, int j)
        {
            return getStartSpace(i, j) != Space.None;
        }
    }
}
