using System;

namespace FunctionIntegrator
{
    class Program
    {
        static double Function(double x)
        {
            var result = x * x;
            result = result * 3;
            return result;
        }

        static void Main(string[] args)
        {
            // f(x) = 3 * x^2; [0; 1]

            const double a = 0;
            const double b = 1;
            const double dx = 0.0001;

            double x;
            //string x_str;
            //do
            //{
            //    Console.Write("Введите значение переменной x > ");
            //    x_str = Console.ReadLine();
            //}
            //while (!double.TryParse(x_str, out x));

            //var y = Function(x);

            //Console.WriteLine("Функция f(x) при x = " + x + " равна " + y);

            double sum = 0;
            x = a;

            int step_count = 0;
            while (x <= b)
            {
                step_count++;
                var f = Function(x);

                var dv = f * dx;

                sum += dv;

                x += dx; // x = x + dx;
            }

            Console.WriteLine("Интеграл функции f(x) = {0}", sum);
            Console.WriteLine("Число шагов интегрирования {0}", step_count);

            const double expected_result = 1;

            var error = expected_result - sum;

            var rel_err = error / expected_result;

            //Console.WriteLine("Ошибка составила " + error + " (" + rel_err + ")");
            Console.WriteLine("Ошибка составила {0:f3} ({1:p2})", error, rel_err);
        }
    }
}
