using System;
using LyokoAPI;
using LyokoAPI.VirtualStructures;
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
            pluginLoader.DisableAll();
        }


        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mini Lyoko!\n Make your selection:");
            Console.WriteLine("1: Activate a random tower\n2: activate a random HOPPER tower\n3: activate a random JEREMIE tower\n4: Hijack a tower \n5: deactivate all towers");
            
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
                case 2 : Network.ActivateRandom(APIActivator.HOPPER); break;
                case 3 : Network.ActivateRandom(APIActivator.JEREMIE);break;
                case 4 : HijackTower();break;
                case 5 : DeactivateAll(); break;
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

        private static void HijackTower()
        {
            if (SuperScan.XanaIsAttacking)
            {
                (SuperScan.XanaTowers[0] as Tower)?.Hijack(APIActivator.JEREMIE);
            }
            else
            {
                Console.WriteLine("There aren't any xana towers to hijack.");
            }
        }
        
    
    }
}
