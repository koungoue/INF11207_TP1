using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Distance_euclidienne:IDistance
    {
        public double Calcul_distance(Grain_ble graintrain,Grain_ble graintest)
        {
            double somme = 0;

            somme += Math.Pow(graintrain.Area - graintest.Area, 2);
            somme += Math.Pow(graintrain.Perimeter - graintest.Perimeter, 2);
            somme += Math.Pow(graintrain.Compactness - graintest.Compactness, 2);
            somme += Math.Pow(graintrain.Kernel_Length - graintest.Kernel_Length, 2);
            somme += Math.Pow(graintrain.Kernel_Width - graintest.Kernel_Width, 2);
            somme += Math.Pow(graintrain.Asymmetry_Coefficient - graintest.Asymmetry_Coefficient, 2);
            somme += Math.Pow(graintrain.Groove_Length - graintest.Groove_Length, 2);

            return Math.Sqrt(somme);

            
        }
    }
}
