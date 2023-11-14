using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFromScratch
{
    internal class Fruit
    {
        public double SpotSize { get; set; }
        public double SpikeLength { get; set; }
        public int IsSafe { get; set; } //0 = dangerous, 1 = safe
        public int Class { get; set; }
        public Fruit(int safety, double spotSize, double spotLength) 
        { 
            IsSafe = safety; 
            SpotSize = spotSize; 
            SpikeLength = spotLength;
        }


    }
}
