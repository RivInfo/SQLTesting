using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIPiSLab1;

namespace ConsoleApp1
{
    class Model5:Model1
    {
        public override void Modulate(int minuts)
        {

            PoissonMetod poissonMetod = new PoissonMetod(_arrivalIntensity1);
            SignificantMetod significantMetod = new SignificantMetod(FlowIntensity2);

            for (int i = 0; i < minuts; i++)
            {
                if (i % 60d == 0)//прибытие машин каждый час
                {
                    _stopCount += GetPoissonNumber(poissonMetod);
                }

                if (_carIn)// машина в боксе
                {
                    if (_carInTime > 0)
                    {
                        _carInTime--;
                    }
                    else//машина выехала из бокса
                    {
                        _carIn = false;
                        _carRequer += 1;
                    }
                }

                if (!_carIn && _stopCount > 0)//машину на ремонт
                {
                    _stopCount -= 1;
                    _carIn = true;
                    _carInTime = GetSignificantNumber(significantMetod) * 60;
                }
            }
            Console.WriteLine($"Починено: {_carRequer}; В пуле: {_stopCount}; " +
                $"Машина в ремонте: {_carIn} Машин отправленно восвоясие: {_carOutNonR}");
        }
    }
}
