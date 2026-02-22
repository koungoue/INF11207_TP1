using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Ferme
    {
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public List<LotsGrains> Lots { get; } = new List<LotsGrains>();


        public Ferme(string Nom, string Adresse)
        {
            this.Nom = Nom;
            this.Adresse = Adresse;
        }
        public void AjouterLot(LotsGrains lot)
        { Lots.Add(lot); }

        public void RetirerLot(LotsGrains lot)
        { Lots.Remove(lot); }
        public int CalculerNombreLots()
        { return Lots.Count; }

        public void Afficher()
        { Console.WriteLine($"Ferme {Nom} situe a {Adresse}"); }
    }
}
