using System;
using LyokoAPI;
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
            DebugListener.Initialize();
            IVirtualWorld lyoko = new APIVirtualWorld("lyoko");
            ISector lyokoForest = new APISector(lyoko, "Forest");
            ISector lyokoIce = new APISector(lyoko, "Ice");
            ISector lyokoDesert = new APISector(lyoko, "Desert");
            ISector lyokoMountain = new APISector(lyoko, "Mountain");
            ISector lyokoSector5 = new APISector(lyoko, "Sector5");
            Tower lyokoSector51 = new Tower(1, lyokoSector5);
            Tower lyokoIce2 = new Tower(2, lyokoIce);
            Tower lyokoDesert3 = new Tower(3, lyokoDesert);
            Tower lyokoMountain4 = new Tower(4, lyokoMountain);
            Tower lyokoForest5 = new Tower(5, lyokoForest);
            lyokoSector51.Activate(APIActivator.XANA);
            lyokoIce2.Activate(APIActivator.XANA);
            lyokoDesert3.Activate(APIActivator.XANA);
            lyokoMountain4.Activate(APIActivator.XANA);
            lyokoForest5.Activate(APIActivator.XANA);
            lyokoSector51.Hijack(APIActivator.HOPPER);
            lyokoIce2.Deactivate();
            lyokoDesert3.Deactivate();
            lyokoMountain4.Deactivate();
            lyokoForest5.Deactivate();
        }
    }
}
