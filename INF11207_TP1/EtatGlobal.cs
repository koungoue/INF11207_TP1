using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace INF11207_TP1
{
    internal class EtatGlobal
    {
        public EtatGlobal() { }
        public int K {  get; set; }
        public string IDistance {  get; set; }
        public DateTime DateTime { get; set; }
        public int TrainCount {  get; set; }
        public int TestCount { get; set; }
        public double Exactitude {  get; set; } 
        public int[,] MatriceConfusion {  get; set; }
    }
}
