using System;
using LyokoAPI.Events;
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
        }

        private static void onXanaAwaken(ITower tower)
        {
            Console.WriteLine("Xana has launched an attack, it activated: {0} {1}",tower.Sector.Name,tower.Number);
        }

        private static void onTowerActivation(ITower tower)
        {
            Console.WriteLine("{0} activated {1} {2}",tower.Activator,tower.Sector.Name,tower.Number);
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