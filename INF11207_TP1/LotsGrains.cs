using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public class LotsGrains : IProduit

    {
        public Double poids { get; set; }
        public string type { get; set; }
        

        public LotsGrains(Double poids, string type)
        {
            this.poids=poids;
            this.type=type;
        }
        public Double CalculerPrix()
        {

            return poids * 15; ;
        }
        
       

    }
}
