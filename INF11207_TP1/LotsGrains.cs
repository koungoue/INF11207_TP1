using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public class LotsGrains : IProduit

    {
        public int IdLots { get; set; }
        public DateTime DateFabrication { get; set; }
        public List<Grain> Grains { get; set; } = new List<Grain>();

        public LotsGrains(int IdLots, DateTime DteFabrication)
        {
            this.IdLots = IdLots;
            this.DateFabrication = DateFabrication;
        }
        public int CalculerQteGrains()
        { return Grains.Count; }
        public void AjouterGrain(Grain grain)
        {
            Grains.Add(grain);
        }
        public void RetirerGrain(Grain grain)
        { Grains.Remove(grain); }

    }
}
