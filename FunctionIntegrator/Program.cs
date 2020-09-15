/*
 
  Файл исходного кода
 
 */

using System;

namespace FunctionIntegrator
{
    /// <summary>Класс главной программы приложения</summary>
    class Program
    {
        /// <summary>Интегрируемая функция f(x)=3x^2</summary>
        /// <param name="x">Аргумент функции</param>
        /// <returns>Возвращаемое значение функции f(x)=3x^2</returns>
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
            if (a == b) return 0;
            if (dx < 0) dx = -dx;
            if (a < b) dx *= -1; // dx = dx * -1;

            double sum = 0;
            var x = a;

            while (x <= b)
            {
                sum += Function(x) * dx;
                x += dx; // x = x + dx;
            }

            return sum;
        }

        static void Swap(ref string s1, ref string s2)
        {
            var tmp = s1;
            s1 = s2;
            s2 = tmp;
        }

        static void Main(string[] args)
        {
            ReadValueFromConsole(out var a, "Введите значение a > ");
            ReadValueFromConsole(out double b, "Введите значение b > ");
            ReadValueFromConsole(out var dx, "Введите значение dx > ");

            var sum = GetIntegralValue(a, b, dx);

            Console.WriteLine("Интеграл функции f(x) = {0}", sum);
        }
    }
}
