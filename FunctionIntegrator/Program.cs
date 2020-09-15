using System;

namespace FunctionIntegrator
{
    class Program
    {
        static double Function(double x)
        {
            return x;
        }

        static void Main(string[] args)
        {
            // f(x) = 3 * x^2; [0; 1]

            const double a = 0;
            const double b = 1;

            var y = Function(1);

            Console.WriteLine("Функция f(x) при x = 1 равна " + y);
        }
    }
}
