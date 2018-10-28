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
            
        }
    }
}
