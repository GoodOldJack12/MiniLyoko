using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;
using MiniLyoko.Exceptions;

namespace MiniLyoko
{
    public class VirtualWorld : APIVirtualWorld
    {
        public VirtualWorld(string name, params ISector[] sectors) : base(name, sectors)
        {
            
        }

        public bool hasSector(string name)
        {
            return GetSector(name) != null;
        }

        public ISector GetSector(string name)
        {
            return Sectors.Find(sector=>sector.Name.Equals(name));
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
            List<Sector> randomSectors = Program.ShuffleList(Sectors.Cast<Sector>().ToList());
            
            Boolean found = false;
            foreach (Sector sector in randomSectors) {
                try {
                    sector.ActivateRandom(activator);
                    found = true;
                    break;
                }
                catch (NoFreeTowersException) {
                    //continue
                }
            }

            if (!found) {
                throw new NoFreeSectorsException(this);
            }
        }
    }
}