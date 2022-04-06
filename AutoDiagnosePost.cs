using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AutoDiagnosePost
    {
        private int _autoStopCount = 3;
        private double _arrivalIntensity1 = 0.85;
        private double _averageServiceTime2 = 1.05;
        private double[] _systemProbabilities4;
        private double[] _averageCarStay9;
        private double[] _averageLengthTimeStaysInQueue10;
        private double[] _queueLength11;

        private double FlowIntensity2 => 1 / _averageServiceTime2;
        private double ReducedTrafficFlowRate3 => _arrivalIntensity1 / FlowIntensity2;
        private double DenialOfServiceProbability5 => 
            _systemProbabilities4[_systemProbabilities4.Length-1];
        private double RelativeBandwidth6 => 1 - DenialOfServiceProbability5;
        private double AbsoluteBandwidth7 => _arrivalIntensity1 * RelativeBandwidth6;

        public AutoDiagnosePost(double arrivalIntensity1 = 0.85, double averageServiceTime2 = 1.05) 
        {
            _arrivalIntensity1 = arrivalIntensity1;
            _averageServiceTime2 = averageServiceTime2;

            FinalySystemProbabilitiesCalculate4();
            AverageLS8();
            AverageCarStay9();
            AverageLengthTimeStaysInQueue10();
            QueueLength11();
        }

        private void FinalySystemProbabilitiesCalculate4()
        {
            _systemProbabilities4 = new double[_autoStopCount+1];

            _systemProbabilities4[0] = (1 + ReducedTrafficFlowRate3) /
                Math.Pow(1 + ReducedTrafficFlowRate3, _autoStopCount + 1);

            for (int i = 1; i < _systemProbabilities4.Length; i++)
            {
                _systemProbabilities4[i] = _systemProbabilities4[0] *
                    Math.Pow(ReducedTrafficFlowRate3, i);
            }
        }

        private double AverageLS8()
        {
            return ReducedTrafficFlowRate3 * (1 - (_autoStopCount + 1) *
                Math.Pow(ReducedTrafficFlowRate3, _autoStopCount) +
                _autoStopCount * Math.Pow(ReducedTrafficFlowRate3, _autoStopCount + 1)) /
                ((1- ReducedTrafficFlowRate3)*
                (1-Math.Pow(ReducedTrafficFlowRate3, _autoStopCount + 1)));
        }

        private void AverageCarStay9()
        {
            _averageCarStay9 = new double[_systemProbabilities4.Length];
            double avergeL = AverageLS8();
            for (int i = 0; i < _systemProbabilities4.Length; i++)
            {
                _averageCarStay9[i] = avergeL / (_arrivalIntensity1 * (1 - _systemProbabilities4[i]));
            }
        }

        private void AverageLengthTimeStaysInQueue10()
        {
            _averageLengthTimeStaysInQueue10 = new double[_systemProbabilities4.Length];
            for (int i = 0; i < _systemProbabilities4.Length; i++)
            {
                _averageLengthTimeStaysInQueue10[i] = _averageCarStay9[i] - 1 / FlowIntensity2;
            }
        }

        private void QueueLength11()
        {
            _queueLength11 = new double[_systemProbabilities4.Length];
            for (int i = 0; i < _systemProbabilities4.Length; i++)
            {
                _queueLength11[i] = _arrivalIntensity1 * (1 - _systemProbabilities4[i]) 
                    * _averageLengthTimeStaysInQueue10[i];
            }
        }

        public void PrintAllMetrics()
        {
            Console.WriteLine($"Интенсивность прибытия: {_arrivalIntensity1:f4}; " +
                $"Cреднее время обслуживания: {_averageServiceTime2:f4}");

            Console.WriteLine($"Приведенная интенсивность потока автомобилей : {ReducedTrafficFlowRate3:f4}");

            //for (int i = 0; i < _systemProbabilities4.Length; i++)
            //    Console.WriteLine($"_systemProbabilities4 P{i}: {_systemProbabilities4[i]:f4}");

            //Console.WriteLine($"Вероятность отказа в обслуживании заявки: {DenialOfServiceProbability5:f4}");
            //Console.WriteLine($"Относительная пропускная способность: {RelativeBandwidth6:f4}");
            //Console.WriteLine($"Абсолютная пропускная способность: {AbsoluteBandwidth7:f4}");
            //Console.WriteLine($"Среднее число находящихся в СМО заявок: {AverageLS8():f4}");
            //for (int i = 0; i < _averageCarStay9.Length; i++)
            //    Console.WriteLine($"Среднее время пребывания заявки в СМО W{i}: {_averageCarStay9[i]:f4}");
            //for (int i = 0; i < _averageLengthTimeStaysInQueue10.Length; i++)
            //    Console.WriteLine($"Средняя продолжительность пребывания заявки в СМО " +
            //        $"W{i}: {_averageLengthTimeStaysInQueue10[i]:f4}");
            //for (int i = 0; i < _queueLength11.Length; i++)
            //    Console.WriteLine($"Среднее число заявок в очереди W{i}: {_queueLength11[i]:f4}");

        }
    }
}
