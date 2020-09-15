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

            var x = 1;
            var y = Function(x);

            Console.WriteLine("Функция f(x) при x = " + x + " равна " + y);
        }
    }
}
