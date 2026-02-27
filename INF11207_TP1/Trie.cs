using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Trie:ITrie
    {
        public void Trier(List<Voisins> voisins)
        {
            int i, j, min;
            
            for (i = 0; i < voisins.Count-1; i++)
            {
                min = i;
                for (j = i+1; j <voisins.Count; j++)
                {
                    if (voisins[j].distance < voisins[min].distance)
                    {
                        min = j;
                    }
                }
                if (min != j)
                {
                  var temp = voisins[min];
                    voisins[min]=voisins[i];
                    voisins[i] = temp;
                }

            
            }
        }
    }
}
