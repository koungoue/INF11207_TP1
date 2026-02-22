using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INF11207_TP1
{
    public class Grain
    {public string Variety {  get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double KernelLenght {  get; set; }
        public double KernelWidth {  get; set; }    
        public double AsymetryCoefficient {  get; set; }
        public double GrooveLenght { get; set; }

        public Grain(string variety, double area, double perimeter, double kernelLenght, double kernelWidth,
            double asymetryCoefficient, double grooveLenght)
        {
            Variety = variety;
            Area = area;
            Perimeter = perimeter;
            KernelLenght = kernelLenght;
            KernelWidth = kernelWidth;
            AsymetryCoefficient = asymetryCoefficient;
            GrooveLenght = grooveLenght;
        }
    }
}
