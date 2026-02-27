using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class KnnClassifieur:IClassifieur
    {
        private int k;
       
        private IDistance distances;
        private List<Grain_ble> train;
        private Trie tri_voisins;

        public KnnClassifieur(int k, IDistance distances, List<Grain_ble> train, Trie tri_voisins)
        {
            this.k = k;
            this.distances = distances;
            this.train = train;
            this.tri_voisins = tri_voisins;
        }
        public Variety Predire(Grain_ble graintest)
        {
            List<Voisins> voisins = new List<Voisins>();

            foreach (var grain in train)
            {
                double distance = distances.Calcul_distance(graintest, grain);
                voisins.Add(new Voisins(distance, grain.variety));
            }

            tri_voisins.Trier(voisins);


            int kama_count = 0;
            int rosa_count = 0;
            int canadian_count = 0;

            if (k == 1)
            {
                return voisins[0].variety;

            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    if (voisins[i].variety == Variety.Kama)
                    {
                        kama_count++;
                       

                    }
                    if (voisins[i].variety == Variety.Rosa)
                    {
                        rosa_count++;
                       

                    }
                    if (voisins[i].variety == Variety.Canadian)
                    {
                        canadian_count++;
                        

                    }
                    //Console.WriteLine("kamacount" + kama_count);
                    //Console.WriteLine("canadiancount" + canadian_count);
                    //Console.WriteLine("rosacount" + rosa_count);
                }
                if (kama_count == rosa_count && rosa_count == canadian_count)
                {
                    return voisins[0].variety;

                }
                if (kama_count > rosa_count && kama_count>canadian_count )
                {
                    return Variety.Kama;
                }else if( rosa_count > kama_count && rosa_count > canadian_count)
                {
                    return Variety.Rosa;
                }
                else if(canadian_count>kama_count && canadian_count>rosa_count)
                {
                    return Variety.Canadian;
                }
                else
                {
                    return voisins[0].variety;
                }

               
            }
           

        }

    }
}
