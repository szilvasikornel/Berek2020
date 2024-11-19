using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berek2020
{
    internal class Ber
    {
        public string Nev { get; set; }
        public bool Nem { get; set; }
        public string Reszleg { get; set; } 
        public int Belepes { get; set; }
        public int Penz {  get; set; }

        public Ber(string sor)
        {
            var v = sor.Split(';');
            Nev = v[0];
            Nem = v[1] == "férfi";
            Reszleg = v[2];
            Belepes = int.Parse(v[3]);
            Penz = int.Parse(v[4]);
        }

        public override string ToString()
        {
            return $"{Nev,18} | {Nem,5} | {Reszleg,15} | {Belepes,5} | {Penz,8}";
        }
    }
}
