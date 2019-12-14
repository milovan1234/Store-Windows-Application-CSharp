using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjekatTVP
{
    class Artikal
    {
        private int id_artikla;
        private string naziv_artikla;
        private double cena;
        private int popust;
        private int id_grupe;

        public Artikal(int id_artikla, string naziv_artikla, double cena, int popust)
        {
            this.Id_artikla = id_artikla;
            this.Naziv_artikla = naziv_artikla;
            this.Cena = cena;
            this.Popust = popust;
        }
        public Artikal(int id_artikla, string naziv_artikla, double cena, int popust,int id_grupe)
        {
            this.Id_artikla = id_artikla;
            this.Naziv_artikla = naziv_artikla;
            this.Cena = cena;
            this.Popust = popust;
            this.Id_grupe = id_grupe;
        }
        public int Id_artikla { get => id_artikla; set => id_artikla = value; }
        public string Naziv_artikla { get => naziv_artikla; set => naziv_artikla = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Popust { get => popust; set => popust = value; }
        public int Id_grupe { get => id_grupe; set => id_grupe = value; }

        public override string ToString()
        {
            return "Naziv artikla: " + this.Naziv_artikla + "   Cena: " + this.Cena + "din   Popust: " + this.Popust + "%";
        }
    }
}
