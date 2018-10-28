using System;
using LyokoAPI.API;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            LyokoAPI.LyokoAPI.EnsureInitialized();
            DebugListener.Initialize();
            IVirtualWorld lyoko = new APIVirtualWorld("lyoko");
            ISector lyokoForest = new APISector(lyoko, "Forest");
            Tower lyokoForest5 = new Tower(5, lyokoForest);
            lyokoForest5.activate(APIActivator.HOPPER);
            lyokoForest5.hijack(APIActivator.XANA);
        }
    }
}
