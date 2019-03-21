using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIS_Grupa11
{
    class APU
    {
        private byte Stanje = 0;
        public bool Prorada1P { get; set; } = false;
        public bool Prorada3P { get; set; } = false;
        public bool Blokada { get; set; } = false;

        public void Uklop()
        {
            if (Stanje == 0)
            {
                Stanje = 1;
            }
        }

        public void Isklop()
        {
            if (Stanje == 1)
            {
                Stanje = 0;
            }
        }

        public byte GetStanje()
        {
            return Stanje;
        }
    }
}
