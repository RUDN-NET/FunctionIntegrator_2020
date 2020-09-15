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

        // ref - передача переменной по ссылке с возможностью прочитать её значение внутри метода и изменить его
        // out - позволяет установить значение переменной внутри метода, но не читать её исходное значение
        static void ReadValueFromConsole(out double value, string Message)
        {
            string str;
            do
            {
                Console.Write(Message);
                str = Console.ReadLine();
            }
            while (!double.TryParse(str, out value));
        }

        static double GetIntegralValue(double a, double b, double dx)
        {
            double sum = 0;
            var x = a;

            while (x <= b)
            {
                sum += Function(x) * dx;

                x += dx; // x = x + dx;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            // f(x) = 3 * x^2; [0; 1]

            double a = 0;
            double b = 1;
            double dx = 0.0001;

            ReadValueFromConsole(out a, "Введите значение a > ");
            ReadValueFromConsole(out b, "Введите значение b > ");
            ReadValueFromConsole(out dx, "Введите значение dx > ");

            if (a == b)
            {
                Console.WriteLine("Интеграл функции f(x) = 0");
                return;
            }

            if (b < a)
            {
                Console.WriteLine("Верхний предел интегрирования имеет значение меньше, чем нижний");
                return;
            }

            //double sum = 0;
            //var x = a;

            //int step_count = 0;
            //while (x <= b)
            //{
            //    step_count++;
            //    var f = Function(x);

            //    var dv = f * dx;

            //    sum += dv;

            //    x += dx; // x = x + dx;
            //}

            var sum = GetIntegralValue(a, b, dx);

            Console.WriteLine("Интеграл функции f(x) = {0}", sum);
            //Console.WriteLine("Число шагов интегрирования {0}", step_count);
        }
    }
}
