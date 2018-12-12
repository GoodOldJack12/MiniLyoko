using System;
using LyokoAPI;
using LyokoPluginLoader;

namespace MiniLyoko
{
    internal class Program
    {
        public static Network Network = new Network();
        public static APISuperScan SuperScan = APISuperScan.GetOrCreate();
        public static void Main(string[] args)
        {
            Console.Clear();
            //DebugListener.Initialize();
            PluginLoader pluginLoader = new PluginLoader("Plugins");
            Console.ReadKey();
            ShowMenu();
            
        }


        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mini Lyoko!\n Make your selection:");
            Console.WriteLine("1: Activate a random tower\n2: deactivate all towers");
            
            if (Int32.TryParse(Console.ReadLine(),out var selection))
            {
                DoSelection(selection);
            }
            else
            {
                Console.WriteLine("Selection wasnt a number!");
            }
        }

        private static void DoSelection(int selection)
        {
            switch (selection)
            {
                case 1 : Network.ActivateRandom(); break;
                case 2 : DeactivateAll(); break;
                default: Console.WriteLine("Invalid selection!"); break;
            }

            Console.WriteLine("Press any key to return to the menu");
            Console.ReadKey();
            ShowMenu();
        }

        private static void DeactivateAll()
        {
            foreach (var registeredTower in SuperScan.GetAllRegisteredTowers())
            {
                (registeredTower as Tower)?.Deactivate();
            }
        }
    
    }
}
