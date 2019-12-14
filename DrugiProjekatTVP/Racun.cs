using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjekatTVP
{
    class Racun
    {
        private int id_racuna;
        private double cena;
        private DateTime datum;
        private DateTime vreme;

        public Racun(int id_racuna, double cena, DateTime datum, DateTime vreme)
        {
            this.Id_racuna = id_racuna;
            this.Cena = cena;
            this.Datum = datum;
            this.Vreme = vreme;
        }

        public int Id_racuna { get => id_racuna; set => id_racuna = value; }
        public double Cena { get => cena; set => cena = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }

        public override string ToString()
        {
            return id_racuna + " " + cena + " " + datum + " " + vreme;
        }
    }
}
