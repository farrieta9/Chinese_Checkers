using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class GameServer
    {

        private EasyNetwork.Server server;
        private ServerGameManager gameManager = new ServerGameManager();

        public bool Shutdown { get; set; }

        public delegate void MessageHandler(object mes, Guid clientId);

        private Dictionary<Type, MessageHandler> MessageDictionary= new Dictionary<Type, MessageHandler>();


        public GameServer(String address)
        {
            server = new EasyNetwork.Server(address);
            Shutdown = false;
            MessageDictionary.Add(typeof(CheckersLib.Move), MoveMessageHandler);
            //todo other MessageHandlers must be made and added here in the same way
        }

        public void Run()
        {
            server.DataReceived += Server_DataReceived;
            server.Start();

            while (!Shutdown)
            {
                Thread.Sleep(1000);
            }

            server.Stop();
        }

        private void Server_DataReceived(object receivedObject, Guid clientId)
        {
            Console.WriteLine("Server received " + receivedObject.GetType().ToString() + " from: " + clientId.ToString());
            Type t = receivedObject.GetType();
            if (MessageDictionary.ContainsKey(t))
            {
                MessageDictionary[t].Invoke(receivedObject, clientId);
            }

        }

        private void MoveMessageHandler(object mes, Guid clientId)
        {
            CheckersLib.Move mv = (CheckersLib.Move)mes;
            if (gameManager.ValidateMove(mv))
            {
                //todo write code for this MessageHandler 
            }
        }
    }
}