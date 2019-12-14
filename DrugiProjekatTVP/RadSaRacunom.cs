using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjekatTVP
{
    class RadSaRacunom
    {
        private Artikal artikal;
        private int kolicina;

        public RadSaRacunom(Artikal artikal, int kolicina)
        {
            this.artikal = artikal;
            this.kolicina = kolicina;
        }
        public override string ToString()
        {
            return artikal.Naziv_artikla + "     " + artikal.Cena + "din     " + artikal.Popust + "%        x" + this.kolicina;
        }
        public int Kolicina { get => kolicina; set => kolicina = value; }
        internal Artikal Artikal { get => artikal; set => artikal = value; }
    }
}
