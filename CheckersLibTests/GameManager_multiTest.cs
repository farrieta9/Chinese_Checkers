using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckersLib
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckWinPlayer1()
        {
            GameManager GM = new GameManager();
            GM.playersTurn = Space.Player1;

            // check Player1 win
            //player 1 [13][9,10,11,12]  [14][10,11,12]  [15][11,12]     [16][12]
            Space player1 = Space.Player1;

            GM.gameBoard.setSpace(13, 9, player1);
            GM.gameBoard.setSpace(13, 10, player1);
            GM.gameBoard.setSpace(13, 11, player1);
            GM.gameBoard.setSpace(13, 12, player1);

            Assert.AreEqual(player1, GM.gameBoard.getSpace(13, 9));

            GM.gameBoard.setSpace(14, 10, player1);
            GM.gameBoard.setSpace(14, 11, player1);
            GM.gameBoard.setSpace(14, 12, player1);

            GM.gameBoard.setSpace(15, 11, player1);
            GM.gameBoard.setSpace(15, 12, player1);

            GM.gameBoard.setSpace(16, 12, player1);

            Assert.AreEqual(player1, GM.gameBoard.getSpace(13, 9));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(13, 10));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(13, 11));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(13, 12));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(14, 10));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(14, 11));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(14, 12));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(15, 11));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(15, 12));
            Assert.AreEqual(player1, GM.gameBoard.getSpace(16, 12));


            Assert.IsTrue(GM.checkWinningMoves());
        }

        [TestMethod]
        public void CheckWinPlayer2()
        {
            GameManager GM = new GameManager();
            GM.playersTurn = Space.Player1;

            // Check Player2 win
            //player 2 [9][4]            [10][4,5]       [11][4,5,6]     [12][4,5,6,7]
            Space player2 = Space.Player2;
            GM.nextPlayersTurn();
            Assert.AreEqual(player2, GM.playersTurn);

            GM.gameBoard.setSpace(12, 7, player2);
            GM.gameBoard.setSpace(12, 6, player2);
            GM.gameBoard.setSpace(12, 5, player2);
            GM.gameBoard.setSpace(12, 4, player2);

            Assert.AreEqual(player2, GM.gameBoard.getSpace(12, 7));

            GM.gameBoard.setSpace(11, 6, player2);
            GM.gameBoard.setSpace(11, 5, player2);
            GM.gameBoard.setSpace(11, 4, player2);

            GM.gameBoard.setSpace(10, 5, player2);
            GM.gameBoard.setSpace(10, 4, player2);

            GM.gameBoard.setSpace(9, 4, player2);

            Assert.IsTrue(GM.checkWinningMoves());

        }

        [TestMethod]
        public void CheckWinPlayer3()
        {
            GameManager GM = new GameManager();
            GM.playersTurn = Space.Player1;

            // Check Player3 win
            //player 3 [4][0,1,2,3]      [5][1,2,3]      [6][2,3]        [7][3]
            Space player3 = Space.Player3;
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            Assert.AreEqual(player3, GM.playersTurn);

            GM.gameBoard.setSpace(4, 0, player3);
            GM.gameBoard.setSpace(4, 1, player3);
            GM.gameBoard.setSpace(4, 2, player3);
            GM.gameBoard.setSpace(4, 3, player3);

            Assert.AreEqual(player3, GM.gameBoard.getSpace(4, 0));

            GM.gameBoard.setSpace(5, 1, player3);
            GM.gameBoard.setSpace(5, 2, player3);
            GM.gameBoard.setSpace(5, 3, player3);

            GM.gameBoard.setSpace(6, 2, player3);
            GM.gameBoard.setSpace(6, 3, player3);

            GM.gameBoard.setSpace(7, 3, player3);

            Assert.IsTrue(GM.checkWinningMoves());

        }

        [TestMethod]
        public void CheckWinPlayer4()
        {
            GameManager GM = new GameManager();
            GM.playersTurn = Space.Player1;

            // Check Player4 Win
            //player 4 [0][4]            [1][4,5]        [2][4,5,6]      [3][4,5,6,7]
            Space player4 = Space.Player4;
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            Assert.AreEqual(player4, GM.playersTurn);

            GM.gameBoard.setSpace(3, 7, player4);
            GM.gameBoard.setSpace(3, 6, player4);
            GM.gameBoard.setSpace(3, 5, player4);
            GM.gameBoard.setSpace(3, 4, player4);

            Assert.AreEqual(player4, GM.gameBoard.getSpace(3, 7));

            GM.gameBoard.setSpace(2, 6, player4);
            GM.gameBoard.setSpace(2, 5, player4);
            GM.gameBoard.setSpace(2, 4, player4);

            GM.gameBoard.setSpace(1, 5, player4);
            GM.gameBoard.setSpace(1, 4, player4);

            GM.gameBoard.setSpace(0, 4, player4);

            Assert.IsTrue(GM.checkWinningMoves());

        }

        [TestMethod]
        public void CheckWinPlayer5()
        {
            GameManager GM = new GameManager();
            GM.playersTurn = Space.Player1;

            // Check Player5 win
            //player 5 [4][9,10,11,12]   [5][10,11,12]   [6][11,12]      [7][12]
            Space player5 = Space.Player5;
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            Assert.AreEqual(player5, GM.playersTurn);

            GM.gameBoard.setSpace(4, 9, player5);
            GM.gameBoard.setSpace(4, 10, player5);
            GM.gameBoard.setSpace(4, 11, player5);
            GM.gameBoard.setSpace(4, 12, player5);

            Assert.AreEqual(player5, GM.gameBoard.getSpace(4, 9));

            GM.gameBoard.setSpace(5, 10, player5);
            GM.gameBoard.setSpace(5, 11, player5);
            GM.gameBoard.setSpace(5, 12, player5);

            GM.gameBoard.setSpace(6, 11, player5);
            GM.gameBoard.setSpace(6, 12, player5);

            GM.gameBoard.setSpace(7, 12, player5);

            Assert.IsTrue(GM.checkWinningMoves());

        }

        [TestMethod]
        public void CheckWinPlayer6()
        {
            GameManager GM = new GameManager();
            GM.playersTurn = Space.Player1;

            // Check Player6 win
            //player 6 [9][13]           [10][13,14]     [11][13,14,15]  [12][13,14,15,16]
            Space player6 = Space.Player6;
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            GM.nextPlayersTurn();
            Assert.AreEqual(player6, GM.playersTurn);

            GM.gameBoard.setSpace(12, 13, player6);
            GM.gameBoard.setSpace(12, 14, player6);
            GM.gameBoard.setSpace(12, 15, player6);
            GM.gameBoard.setSpace(12, 16, player6);

            Assert.AreEqual(player6, GM.gameBoard.getSpace(12, 13));

            GM.gameBoard.setSpace(11, 13, player6);
            GM.gameBoard.setSpace(11, 14, player6);
            GM.gameBoard.setSpace(11, 15, player6);

            GM.gameBoard.setSpace(10, 13, player6);
            GM.gameBoard.setSpace(10, 14, player6);

            GM.gameBoard.setSpace(9, 13, player6);

            Assert.IsTrue(GM.checkWinningMoves());
        }


    } // end class UnitTest
} // end namespace CheckersLib
