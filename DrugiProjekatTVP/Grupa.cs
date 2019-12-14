using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugiProjekatTVP
{
    class Grupa
    {
        private int id_grupe;
        private string naziv_grupe;

        public Grupa(int id_grupe, string naziv_grupe)
        {
            this.id_grupe = id_grupe;
            this.naziv_grupe = naziv_grupe;
        }

        public int Id_grupe { get => id_grupe; set => id_grupe = value; }
        public string Naziv_grupe { get => naziv_grupe; set => naziv_grupe = value; }

        public override string ToString()
        {
            return this.naziv_grupe;
        }

    }
}
