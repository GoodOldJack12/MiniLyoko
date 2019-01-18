using System;

namespace MiniLyoko.Exceptions
{
    public class NoFreeTowersException: Exception
    {
        private Sector _sector;
        public NoFreeTowersException(Sector sector) {
            _sector = sector;
        }

        public Sector getSector() {
            return _sector;
        }

    }
}