using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public class Fermier : Personne
    {

        public int IdFermier { get; set; }


        public List<LotsGrains> Lots { get; } = new List<LotsGrains>();
            public Fermier(int idFermier, string Nom,string Contact, string Email):base(Nom,Contact,Email)
        { this.IdFermier = idFermier; }
        public LotsGrains CreerLot(int IdLot, DateTime dateFabrication, List<Grain> grains)
        {
            LotsGrains lot = new LotsGrains(IdLot, dateFabrication);
            foreach (Grain g in grains)
            { lot.Grains.Add(g); }
            Lots.Add(lot);
            return lot;
        }

    }
}
