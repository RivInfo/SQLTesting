using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Теоретическая оценка");
            AutoDiagnosePost ap = new AutoDiagnosePost();
            ap.PrintAllMetrics();
            /*Первый тест*/
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("---------------------------- " + i + " ----------------------");
                Model1 model1 = new Model1();
                model1.Modulate(1000);
                ap = new AutoDiagnosePost(model1.GetArrivalIntensity1(), model1.GetAverageServiceTime2());
                ap.PrintAllMetrics();
            }

            /*Второй тест*/
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("---------------------------- " + i + " ----------------------");
            //    Model1 model1 = new Model2();
            //    model1.Modulate(1000);
            //    ap = new AutoDiagnosePost(model1.GetArrivalIntensity1(), model1.GetAverageServiceTime2());
            //    ap.PrintAllMetrics();
            //}

            /*Третий тест*/
            //for (int i = 0; i < 15; i++)
            //{
            //    Console.WriteLine("---------------------------- " + i + " ----------------------");
            //    Model1 model1 = new Model3();
            //    model1.Modulate(1000);
            //    ap = new AutoDiagnosePost(model1.GetArrivalIntensity1(), model1.GetAverageServiceTime2());
            //    ap.PrintAllMetrics();
            //}


            /*Четвёртый тест*/
            //Console.WriteLine();
            //Console.WriteLine("Тесты с временем поступления заявок 70 минут, а число стоянок 4.");
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("---------------------------- " + i + " ----------------------");
            //    Model1 model1 = new Model4(70, 4);
            //    model1.Modulate(1000);
            //    ap = new AutoDiagnosePost(model1.GetArrivalIntensity1(), model1.GetAverageServiceTime2());
            //    ap.PrintAllMetrics();
            //}
            //Console.WriteLine();
            //Console.WriteLine("Тесты с временем поступления заявок 60 минут, а число стоянок 2.");
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("---------------------------- " + i + " ----------------------");
            //    Model1 model1 = new Model4(60, 2);
            //    model1.Modulate(1000);
            //    ap = new AutoDiagnosePost(model1.GetArrivalIntensity1(), model1.GetAverageServiceTime2());
            //    ap.PrintAllMetrics();
            //}


            /*Пятый тест*/
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("---------------------------- " + i + " ----------------------");
                Model1 model1 = new Model5();
                model1.Modulate(1000);
                ap = new AutoDiagnosePost(model1.GetArrivalIntensity1(), model1.GetAverageServiceTime2());
                ap.PrintAllMetrics();
            }
        }
    }
}
