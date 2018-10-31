using System;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{
    public class Sector : APISector
    {
        public Sector(IVirtualWorld world, string name, params ITower[] towers) : base(world, name, towers)
        {
        } 
        public Sector(IVirtualWorld world, string name, int towers) : this(world,name)
        {
            if (!world.Sectors.Contains(this))
            {
                world.Sectors.Add(this);
            }
            for (int i = 1; i < towers+1; i++)
            {
                Towers.Add(new Tower(i,this));
            }        
        }

        public Sector(string virtualworldName, string sectorName, params ITower[] towers) : base(virtualworldName, sectorName, towers)
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
            int randomint = new Random().Next(Towers.Count)+1;
            GetTower(randomint)?.Activate(activator);
        }
    }
}