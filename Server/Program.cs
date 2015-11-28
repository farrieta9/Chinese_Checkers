﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // Is "tcp://*:3000" just local. If so this should be changed but will work for testing.
            GameServer gameServer = new GameServer("tcp://*:3000");

            gameServer.Run();
        }
    }
}
