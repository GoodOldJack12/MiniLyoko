using System;
using System.Collections.Generic;
using System.Linq;
using LyokoAPI;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoPluginLoader;
using MiniLyoko.Exceptions;

namespace MiniLyoko
{
    internal class Program
    {
        public static Network Network = new Network();
        public static APISuperScan SuperScan = APISuperScan.GetOrCreate();
        private static Random random = new Random();
        public static void Main(string[] args)
        {
            Console.Clear();
            var consoleLogger = LyokoLogger.Subscribe(msg => Console.WriteLine(msg));
            //DebugListener.Initialize();
            PluginLoader pluginLoader = new PluginLoader("Plugins");
            bool isInList = false;
            foreach (var plugin in pluginLoader.Plugins)
            {
                if (plugin.Name.Contains("logger")){
                    isInList = true;
                }
            }
            if (isInList)
            {
                LyokoLogger.Unsubscribe(consoleLogger);
            }
            Console.ReadKey();
            ShowMenu();
            pluginLoader.DisableAll();
        }


        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to MiniLyoko!\n Make your selection:");
            Console.WriteLine("1: Activate a random tower\n2: Activate a random HOPPER tower\n3: Activate a random JEREMIE tower\n4: Hijack a tower \n5: Deactivate all towers");
            
            if (Int32.TryParse(Console.ReadLine(),out var selection)) {
                DoSelection(selection);
            }
            else
            {
                Console.WriteLine("Selection wasn't a number!");
                Console.WriteLine("Press any key to return to the menu");
                Console.ReadKey();
                ShowMenu();
            }
        }

        private static void DoSelection(int selection)
        {
            try {
                switch (selection) {
                    case 1 : Network.ActivateRandom(); break;
                    case 2 : Network.ActivateRandom(APIActivator.HOPPER); break;
                    case 3 : Network.ActivateRandom(APIActivator.JEREMIE); break;
                    case 4 : HijackTower(); break;
                    case 5 : DeactivateAll(); break;
                    default: Console.WriteLine("Invalid selection!"); break;
                }
            } catch (NoFreeVirtualWorldsException e) {
                Console.WriteLine("There isn't any free tower in the Network!\n");
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
                Console.WriteLine("There aren't any XANA towers to hijack!");
            }
        }

        public static List<T> ShuffleList<T>(IList<T> originalList) {
            List<T> list = new List<T>(originalList);
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

    }
}
