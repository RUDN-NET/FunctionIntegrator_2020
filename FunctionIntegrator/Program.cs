using System;

namespace FunctionIntegrator
{
    class Program
    {


        static void Main(string[] args)
        {
            // f(x) = 3 * x^2; [0; 1]

            //const double a = 0;
            //const double b = 1;

            Console.WriteLine("В программу передано аргументов " + args.Length);

            for (var i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Аргумент " + i + " = " + args[i]);
            }
        }
    }
}
