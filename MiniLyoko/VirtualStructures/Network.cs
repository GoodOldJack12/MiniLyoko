using System.Collections.Generic;
using LyokoAPI.VirtualStructures.Interfaces;

namespace MiniLyoko
{
    public class Network
    {
        private bool seeded = false;
        public List<IVirtualWorld> Vworlds { get; }
        public Network()
        {
            Seed();
        }

        public IVirtualWorld GetWorld(string name)
        {
            return Vworlds.Find(vworld => vworld.Name.Equals(name));
        }

        public bool HasWorld(string name)
        {
            return GetWorld(name) != null;
        }
        


        private void Seed()
        {
            if (seeded)
            {
                VirtualWorld lyoko = new VirtualWorld("Lyoko");
                Sector iceSector = new Sector(lyoko, "ice",10);
                Sector forestSector = new Sector(lyoko, "forest",10);
                Sector carthageSector = new Sector(lyoko,"carthage",1);
                Sector desertSector = new Sector(lyoko, "desert",10);
            
                Vworlds.Add(lyoko);
            
                VirtualWorld forestReplica = new VirtualWorld("ForestReplica");
                Sector forestreplicasector = new Sector(forestReplica,"forest",10);

                Vworlds.Add(forestReplica);
                seeded = true;
            }
            
        }
        
        
    }
}