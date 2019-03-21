using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIS_Grupa11
{
    //Klasa prekidac
    public class Prekidac
    {
        private byte Stanje = 0;

        public bool PadTlak16B { get; set; } = false;
        public bool PadTlak14B { get; set; } = false;
        public bool PadTlak11B { get; set; } = false;
        public bool APUBlokada { get; set; } = false;
        public bool NeskladPolova { get; set; } = false;
        public bool LokalnoUpravljanje { get; set; } = false;

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
