using System;
using LyokoAPI.API;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ITower tower = new APITower("lyoko", "ice", 1, true);
            tower.Activator = LyokoParser.ParseActivator("XANA");
            Console.WriteLine(tower.Sector.Name);
            Console.WriteLine(tower.Number);
        }
    }
}
