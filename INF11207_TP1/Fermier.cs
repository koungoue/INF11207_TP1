using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public class Fermier : Personne
    {
        public Fermier(string Nom,string Contact, string Email) : base(Nom, Contact, Email)
        {

        }
        public override void Afficher()
        {
            Console.WriteLine($"Nom:{Nom}");
            Console.WriteLine($"Email:{Email}");
            Console.WriteLine($"Contact:{Contact}");
        }

    }
}
