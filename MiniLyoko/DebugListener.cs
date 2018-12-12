using System;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{
    public class DebugListener
    {


        public static void Initialize()
        {
            XanaAwakenEvent.Subscribe(onXanaAwaken);
            XanaDefeatEvent.Subscribe(onXanaDefeat);
            TowerActivationEvent.Subscribe(onTowerActivation);
            TowerDeactivationEvent.Subscribe(onTowerDeactivation);
            TowerHijackEvent.Subscribe(onTowerHijacked);
        }

        private static void onXanaAwaken()
        {
            Console.WriteLine("Xana has launched an attack!");
        }

        private static void onTowerActivation(ITower tower) //TODO: Jack fix the activation listener.
        {
            Console.WriteLine("{0} activated {1} {2}",tower.Activator,tower.Sector.Name,tower.Number);
        }
        
        private static void onTowerHijacked(ITower tower, APIActivator oldActivator, APIActivator newActivator)
        {
            Console.WriteLine("{0} hijacked {1} {2} from {3}",tower.Activator,tower.Sector.Name,tower.Number,oldActivator);
        }

        private static void onTowerDeactivation(ITower tower)
        {
            Console.WriteLine("Tower {0} {1} has been deactivated.",tower.Sector.Name,tower.Number);
        }
        private static void onXanaDefeat()
        {
            Console.WriteLine("Xana has been defeated!");
        }
    }
}