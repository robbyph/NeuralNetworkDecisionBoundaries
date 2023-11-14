using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFromScratch
{
    internal class NeuralNetwork
    {
        double weight_1_1, weight_2_1;
        double weight_1_2, weight_2_2;
        double bias_1, bias_2;

        public int Classify(double input_1, double input_2)
        {
            double output_1 = input_1 * weight_1_1 + input_2 * weight_2_1 + bias_1;
            double output_2 = input_1 * weight_1_2 + input_2 * weight_2_2 + bias_2;

            return (output_1 > output_2) ? 0 : 1;
        }

        public void Visualize(double graphX, double graphY)
        {
            int predictedClass = Classify(graphX, graphY);


        }
    }
}
