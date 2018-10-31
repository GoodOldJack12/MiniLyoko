using System;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{
    public class VirtualWorld : APIVirtualWorld
    {
        public VirtualWorld(string name, params ISector[] sectors) : base(name, sectors)
        {
            
        }

        public bool hasSector(string name)
        {
            return GetSector(Name) != null;
        }

        public ISector GetSector(string name)
        {
            return Sectors.Find(sector=>sector.Name.Equals(Name));
        }

        public void ActivateTower(string sector, int number, APIActivator activator)
        {
            if (hasSector(Name))
            {
               (GetSector(sector) as Sector)?.ActivateTower(number,activator);
            }
        }

        public void ActivateRandom(APIActivator activator = APIActivator.XANA)
        {
            int randomint = new Random().Next(Sectors.Count);
            Sector sector = Sectors[randomint] as Sector;
            sector?.ActivateRandom(activator);
        }

    }
}