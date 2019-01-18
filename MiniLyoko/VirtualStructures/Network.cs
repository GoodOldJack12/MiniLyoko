using System;
using System.Collections.Generic;
using System.Linq;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;
using MiniLyoko.Exceptions;

namespace MiniLyoko
{
    public class Network
    {
        private bool seeded = false;
        public List<VirtualWorld> Vworlds { get; private set; }
        public Network()
        {
            Seed();
        }

        public VirtualWorld GetWorld(string name)
        {
            return Vworlds.Find(vworld => vworld.Name.Equals(name));
        }

        public bool HasWorld(string name)
        {
            return GetWorld(name) != null;
        }
        


        private void Seed()
        {
            if (!seeded)
            {
                Vworlds = new List<VirtualWorld>();
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

        private void ActivateTower(string virtualworld, string sector, int number, APIActivator activator)
        {
            if (HasWorld(virtualworld))
            {
                GetWorld(virtualworld).ActivateTower(sector,number,activator);
            }
        }

        public void ActivateRandom(string vworld,APIActivator activator = APIActivator.XANA)
        {
            GetWorld(vworld)?.ActivateRandom(activator);
        }

        public void ActivateRandom(APIActivator activator = APIActivator.XANA)
        {
            List<VirtualWorld> randomVworlds = Program.ShuffleList(Vworlds);
            
            Boolean found = false;
            foreach (VirtualWorld virtualWorld in randomVworlds) {
                try {
                    if (!found) {
                        virtualWorld.ActivateRandom(activator);
                        found = true;
                    }
                }
                catch (NoFreeSectorsException) {
                    //continue
                }
            }

            if (!found) {
                throw new NoFreeVirtualWorldsException();
            }
        }
        
    }
}