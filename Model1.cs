using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIPiSLab1;

namespace ConsoleApp1
{
    class Model1
    {
        protected int _stopPull = 3;
        protected int _stopCount = 0;
        protected bool _carIn = false;
        protected double _carInTime = 0;

        protected double _arrivalIntensity1 = 0.85;
        protected double _averageServiceTime2 = 1.05;


        protected int _carRequer = 0;
        protected int _carOutNonR = 0;

        protected double FlowIntensity2 => 1 / _averageServiceTime2;

        public Model1()
        {

        }

        public virtual void Modulate(int minuts)
        {
            //if (minuts < 60)
            //    throw new ArgumentOutOfRangeException();

            //int iteretionLenth = minuts / 60;

            PoissonMetod poissonMetod = new PoissonMetod(_arrivalIntensity1);
            SignificantMetod significantMetod = new SignificantMetod(FlowIntensity2);

            for (int i = 0; i < minuts; i++)
            {
                if(i%60d == 0)//прибытие машин каждый час
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

                if(!_carIn && _stopCount>0)//машину на ремонт
                {
                    _stopCount -= 1;
                    _carIn = true;
                    _carInTime = GetSignificantNumber(significantMetod) * 60;
                }               

                if(_stopCount > _stopPull)
                { 
                    CarNonPulling(_stopCount - _stopPull);
                    _stopCount = _stopPull;
                }
            }
            Console.WriteLine($"Починено: {_carRequer}; В пуле: {_stopCount}; " +
                $"Машина в ремонте: {_carIn} Машин отправленно восвоясие: {_carOutNonR}");
        }

        protected void CarNonPulling(int count)
        {
            _carOutNonR += count;
        }

        protected int poissonNumberCount = 0;
        protected double poissonNumberSum = 0;

        public double GetArrivalIntensity1()
        {
            if (poissonNumberCount != 0)
                return (double)poissonNumberSum / poissonNumberCount;
            else
                return _arrivalIntensity1;
        }

        protected int GetPoissonNumber(PoissonMetod poissonMetod)
        {
            poissonNumberCount++;
            int num = (int)poissonMetod.Next();
            poissonNumberSum += num;
            return num;
        }

        protected int significantCount = 0;
        protected double significantSum = 0;

        public double GetAverageServiceTime2()
        {
            if (significantCount != 0)
                return significantSum / significantCount;
            else
                return _averageServiceTime2;
        }

        protected double GetSignificantNumber(SignificantMetod significantMetod)
        {
            significantCount++;
            double num = significantMetod.Next();
            significantSum += num;
            return num;
        }
    }
}
