using System;

namespace MiniLyoko.Exceptions
{
    public class NoFreeSectorsException: Exception
    {
        private VirtualWorld _vworld;
        public NoFreeSectorsException(VirtualWorld virtualWorld)
        {
            _vworld = virtualWorld;
        }

        public VirtualWorld getVirtualWorld() {
            return _vworld;
        }

    }
}