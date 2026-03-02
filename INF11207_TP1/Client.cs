using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public class Client:Personne
    {
        public string Adresse {  get; set; }
        public Client(string nom, string adresse,string contact,string email) : base(nom, email, contact)
        {
            this.Adresse = adresse;
        }

        public override void Afficher()
        {
            Console.WriteLine($"Nom:{Nom}");
            Console.WriteLine($"Email:{Email}");
            Console.WriteLine($"Contact:{Contact}");
            Console.WriteLine($"Adresse:{ Adresse}");
        }
    }
}
