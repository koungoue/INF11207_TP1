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
        public Client(string nom, string adresse,string contact,string email):base(nom,email,contact)
        { this.Adresse = adresse; }
        public void Commander(LotsGrains produit,int Quantite)
        {
            if (produit == null) {
                Console.WriteLine("produit non disponible"); }
                    return;
            if (Quantite <= 0) 
            {Console.WriteLine( "Quantite non applicable");
                return;
            }
            Console.WriteLine($"Client{Nom},Contact{Contact},Email{Email}),Adresse{Adresse}" +
                $" a commande {Quantite} unites du lot {produit.IdLots}");

        }
    }
}
