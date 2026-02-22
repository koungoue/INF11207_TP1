using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Program
    {
        static void Main(string[] args)
        {//Creation Ferme
            Ferme ferme = new Ferme("Soleil", "50 RUE DANSE LEVIS");
            ferme.Afficher();

            //Creation Fermier
            Fermier fermier = new Fermier(001, "David", "418-524-7521", "fermier@gmail.com");
            //creation des grains
            Grain g1 = new Grain("Rosa", 12, 5, 6, 4, 6, 9);
            Grain g2 = new Grain("Canadian", 12, 9, 5, 8, 6, 3);

            //creer un lot
            LotsGrains lot1 = new LotsGrains(1, DateTime.Now);
            lot1.AjouterGrain(g2);
            lot1.AjouterGrain(g1);
            //Ajouter un lot dans la ferme 
            ferme.AjouterLot(lot1);

            Console.WriteLine($"Quantite de grains = {lot1.CalculerQteGrains()}");



        }
    }
}
