using System;
using System.Collections.Generic;
using System.Linq;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;
using MiniLyoko.Exceptions;

namespace MiniLyoko
{
    public class Sector : APISector
    {
        public Sector(IVirtualWorld world, string name, int towers) : base(world,name)
        {
            /*if (!world.Sectors.Contains(this))
            {
                world.Sectors.Add(this);
            }
            */
            for (int i = 1; i < towers+1; i++)
            {
                Towers.Add(new Tower(i,this));
            }        
        }

        public Sector(string virtualworldName, string sectorName, int towers) : base(virtualworldName, sectorName, towers)
        {
        }

        public Tower GetTower(int number)
        {
            return Towers.Find(tower=>tower.Number.Equals(number)) as Tower;
        }

        public bool HasTower(int number)
        {
            return GetTower(number) != null;
        }

        public void ActivateTower(int number, APIActivator activator)
        {
            GetTower(number).Activate(activator);
        }

        public void ActivateRandom(APIActivator activator = APIActivator.XANA)
        {
            List<Tower> randomTowers = Program.ShuffleList(Towers.Cast<Tower>().ToList());
            
            Boolean found = false;
            foreach (Tower tower in randomTowers) {
                if (!tower.Activated) {
                    tower.Activate(activator);
                    found = true;
                    break;
                }
            }

            if (!found) {
                throw new NoFreeTowersException(this);
            }
        }
    }
}