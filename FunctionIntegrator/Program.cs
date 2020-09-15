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

            Console.Write("Введите значение переменной x > ");
            var x_str = Console.ReadLine();
            double x;

            //int.Parse()
            //int.TryParse()
            //long.Parse()
            //byte.Parse()
            //double.Parse()
            //float.Parse()
            //bool.Parse()

            if (!double.TryParse(x_str, out x))
            {
                Console.WriteLine("Введённая строка имела неверный формат");
                return;
            }

            var y = Function(x);

            Console.WriteLine("Функция f(x) при x = " + x + " равна " + y);
        }
    }
}
