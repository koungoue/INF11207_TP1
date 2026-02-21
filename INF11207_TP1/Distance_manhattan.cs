using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    internal class Distance_manhattan:IDistance
    {
        public double Calcul_distance(Grain_ble graintrain, Grain_ble graintest)
        {
            double somme = 0;

            somme += Math.Abs(graintrain.Area - graintest.Area);
            somme += Math.Abs(graintrain.Perimeter - graintest.Perimeter);
            somme += Math.Abs(graintrain.Compactness - graintest.Compactness);
            somme += Math.Abs(graintrain.Kernel_Length - graintest.Kernel_Length);
            somme += Math.Abs(graintrain.Kernel_Width - graintest.Kernel_Width);
            somme += Math.Abs(graintrain.Asymmetry_Coefficient - graintest.Asymmetry_Coefficient);
            somme += Math.Abs(graintrain.Groove_Length - graintest.Groove_Length);

            return somme;


        }
    }
}
