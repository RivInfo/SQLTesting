using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPiSLab1
{
    //метод рандома Пуассона
    class PoissonMetod : DistributionLaw
    {
        private double let;

        public PoissonMetod(double lyamda)
        {
            let = Math.Exp(-lyamda);
        }

        public override double Next()
        {
            double K = 0, P = 1;
            do
            {
                K++;
                P *= _rand.NextDouble();
            }
            while (P > let);
            return K - 1;
        }
    }
}
