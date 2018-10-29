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
        public bool Activated => Activator != APIActivator.NONE;
        public ISector Sector { get; }
        public APIActivator Activator { get; set; } = APIActivator.NONE;

       public void Activate(APIActivator activator)
        {
            if (!Activated && activator != APIActivator.NONE)
            {
                Activator = activator;
                TowerActivationEvent.Call(this, Activator.ToString());
            }
        }
        
        public void Deactivate()
        {
            if (Activated)
            {
                Activator = APIActivator.NONE;
                TowerDeactivationEvent.Call(this);
            }
        }

        public void Hijack(APIActivator newActivator)
        {
            if (Activated && newActivator != APIActivator.NONE)
            {
                APIActivator oldActivator = Activator;
                Activator = newActivator;
                TowerHijackEvent.Call(this, oldActivator, newActivator);
            }
        }
    }
}
