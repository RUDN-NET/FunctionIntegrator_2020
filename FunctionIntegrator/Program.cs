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

            double a = 0;
            double b = 1;
            double dx = 0.0001;

            string a_str;
            do
            {
                Console.Write("Введите значение a > ");
                a_str = Console.ReadLine();
            }
            while (!double.TryParse(a_str, out a));

            string b_str;
            do
            {
                Console.Write("Введите значение b > ");
                b_str = Console.ReadLine();
            }
            while (!double.TryParse(b_str, out b));

            string dx_str;
            do
            {
                Console.Write("Введите значение dx > ");
                dx_str = Console.ReadLine();
            }
            while (!double.TryParse(dx_str, out dx));

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

            double sum = 0;
            var x = a;

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
        }
    }
}
