using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EasyNetwork;

namespace ChineseCheckers
{
    class ClientGameManager : CheckersLib.GameManager
    {
        private Server.GameServer gameServer;
        private Thread serverThread;

        public ClientGameManager()
        { }

        ~ClientGameManager()
        {
            endServer();
        }

        public void SendMoveToServer(CheckersLib.Move move)
        { }

        public void HostGame()
        {
            endServer();
            gameServer = new Server.GameServer("tcp://*:30001");
            serverThread = new Thread(gameServer.Run);
            serverThread.Start();
            while (!serverThread.IsAlive);
        }

        public void JoinGame(/* IP address */)
        { }

        private void endServer()
        {
            if (gameServer != null)
                gameServer.Shutdown = true;
            if (serverThread != null && serverThread.IsAlive)
                serverThread.Join();
            gameServer = null;
            serverThread = null;
        }

    }
}
