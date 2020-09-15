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

        static void Initialize(out string str, string Pattern, int Count)
        {
            str = "";
            for (var i = 0; i < Count; i++)
                str += Pattern;
        }

        static void InitializeRef(ref string str)
        {
            
        }

        static void Main(string[] args)
        {
            //var s1 = "S1";
            //var s2 = "S2";

            //Initialize(out s1, "Hello", 5);

            //Swap(ref s1, ref s2);

            //Console.WriteLine("s1 = {0}", s1);
            //Console.WriteLine("s2 = {0}", s2);

            //return;

            //f(x) = 3 * x ^ 2;[0; 1]

            //double a = 0;
            //double b = 1;
            //double dx = 0.0001;

            ReadValueFromConsole(out var a, "Введите значение a > ");
            ReadValueFromConsole(out double b, "Введите значение b > ");
            ReadValueFromConsole(out var dx, "Введите значение dx > ");

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
