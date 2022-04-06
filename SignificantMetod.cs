using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPiSLab1
{
    //Формирование последовательности случайных чисел с показательным распределением.
    class SignificantMetod : DistributionLaw
    {
        private double _lyamda;

        public SignificantMetod(double lyamda)
        {
            _lyamda = lyamda;
        }

        public override double Next()
        {
            return -(1.0 / _lyamda) * Math.Log(_rand.NextDouble());
        }
    }
}
