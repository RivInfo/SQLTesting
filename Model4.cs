using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIPiSLab1;

namespace ConsoleApp1
{
    class Model4 : Model1
    {
        private int _minutsBeforeCarAdd;
        private int _carRandomTime = 0;

        public Model4 (int minutsBeforeCarAdd = 70, int stopCount=4)
        {
            _minutsBeforeCarAdd = minutsBeforeCarAdd;
            _stopCount = stopCount;
        }

        public override void Modulate(int minuts)
        {
            PoissonMetod poissonMetod = new PoissonMetod(_arrivalIntensity1);
            SignificantMetod significantMetod = new SignificantMetod(FlowIntensity2);

            for (int i = 0; i < minuts; i++)
            {
                if (_carRandomTime <= 0)
                {
                    _stopCount += 1;
                    poissonNumberCount++;
                    _carRandomTime = _minutsBeforeCarAdd;
                    poissonNumberSum += _carRandomTime / 60d;
                }
                else
                {
                    _carRandomTime--;
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

                if (_stopCount > _stopPull)
                {
                    CarNonPulling(_stopCount - _stopPull);
                    _stopCount = _stopPull;
                }
            }
            Console.WriteLine($"Починено: {_carRequer}; В пуле: {_stopCount}; " +
                $"Машина в ремонте: {_carIn} Машин отправленно восвоясие: {_carOutNonR}");
        }
    }
}
