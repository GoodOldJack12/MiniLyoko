using System.Runtime.CompilerServices;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{

public class Tower : ITower
    {
        public Tower(int number, ISector sector)
        {
            Number = number;
            Sector = sector;
        }
        public int Number { get; }
        public bool Activated { get; set; }
        public ISector Sector { get; }
        public APIActivator Activator { get; set; }

        public void activate(APIActivator activator)
        {
            if (!Activated)
            {
                Activated = true;
                Activator = activator;
                TowerActivationEvent.Call(this, Activator.ToString());
            }
        }
        
        public void deactivate(APIActivator activator)
        {
            if (Activated)
            {
                Activated = false;
                Activator = APIActivator.NONE;
                TowerDeactivationEvent.Call(this);
            }
        }

        public void hijack(APIActivator activator)
        {
            if (Activated)
            {
                Activator = activator;
                TowerDeactivationEvent.Call(this);
                TowerActivationEvent.Call(this, Activator.ToString());
            }
        }
    }
}
