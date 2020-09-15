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
            if (a > b) dx *= -1; // dx = dx * -1;

            double sum = 0;
            var x = a;

            while (x <= b)
            {
                sum += Function(x) * dx;
                x += dx; // x = x + dx;
            }

            return sum;
        }

        static double GetIntegralValue(Func<double, double> f, double a, double b, double dx)
        {
            if (a == b) return 0;
            if (dx < 0) dx = -dx;
            if (a > b) dx *= -1; // dx = dx * -1;

            double sum = 0;
            var x = a;

            while (x <= b)
            {
                sum += f(x) * dx;
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
            // Action - для процедур без параметров
            // Action<string> для процедур с одной переменной строкового типа
            // Action<int> для процедур с одной переменной целочисленного типа
            // Action<int, string> для процедур с первой переменной целого типа и второй переменной строкового типа

            // Func<int> - функция без параметров, возвращающая целое число
            // Func<string, int> - функция с одной переменной строкового типа, возвращающая целое число

            // Всё это вместе называется делегатами!

            //PrinterHelloWorld();
            //PrinterQWE();
            //Printer123();

            //Action printer = PrinterHelloWorld;
            //printer();
            //printer = Printer123;
            //printer();
            //Action<string> string_printer = PrinterWithTime;
            //string_printer("Hello from RUDN!");

            //// Правило преобразования string -> int
            //Func<string, int> string_2_int = GetStringLength;

            //Console.WriteLine(string_2_int("Hello from RUDN!"));

            //return;

            ReadValueFromConsole(out var a, "Введите значение a > ");
            ReadValueFromConsole(out double b, "Введите значение b > ");
            ReadValueFromConsole(out var dx, "Введите значение dx > ");

            string message;

            if (a > 0)
            {
                message = "Переменная а больше нуля";
            }
            else
            {
                message = "Переменная а меньше, либо равна нулю";
            }

            Printer(message);

            //string msg = a > 0 ? "Переменная а больше нуля" : "Переменная а меньше, либо равна нулю";
            // условие ? если_истина : если_ложь
            //Printer(a > 0 ? "Переменная а больше нуля" : "Переменная а меньше, либо равна нулю");

            var sum = GetIntegralValue(a, b, dx);

            var integral_of_sin = GetIntegralValue(Math.Sin, 0, Math.PI / 2, 0.0001);

            Func<double, double> function = x => 3 * x * x;
            // "x => 3 * x * x" - лямбда-выражение

            // f(x) = 5 * sin(2*pi*x - 3) + 7

            var integral_of_func = GetIntegralValue(
                x => 5 * Math.Sin(2 * Math.PI * x - 3) + 7, // подинтегральное выражение 5 * sin(2*pi*x - 3) + 7
                0, 5,  // интервал интегрирования от 0 до 5
                0.001); // шаг интегрирования 

            Func<double, double> f1 = Math.Sin; // f1(x) = sin(x);
            Func<double, double> f2 = x => 2 * x + 3; // f2(x) = 2x + 3;

            Func<double, double> f3 = Add(f1, f2);
            Func<double, double> f4 = Sub(f3, f1);
            Func<double, double> f5 = Mul(f3, f2);
            Func<double, double> f6 = Comb(f3, f1);

            Func<double, double> f7 = Add(f1, x => x * x); // f7(x) = sin(x) + x^2

            // f3 = f1 + f2 -- f3(x) = f1(x) + f2(x);
            // f4 = f1 - f2 -- f3(x) = f1(x) - f2(x);
            // f5 = f1 * f2 -- f3(x) = f1(x) * f2(x);
            // f6(x) = f1(f2(x));

            Console.WriteLine("Интеграл функции f(x) = {0}", sum);
        }

        static void PrinterHelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        static void PrinterQWE()
        {
            Console.WriteLine("QWE");
        }

        static void Printer123()
        {
            Console.WriteLine("123");
        }

        static void Printer(string Message)
        {
            Console.WriteLine(Message);
        }
        static void PrinterWithTime(string Message)
        {
            Console.WriteLine("{0}:{1}", DateTime.Now, Message);
        }

        static int GetStringLength(string str)
        {
            return str.Length;
        }

        // --------------------------------------------------------------------

        static Func<double, double> Add(Func<double, double> a, Func<double, double> b)
        {
            Func<double, double> result = x => a(x) + b(x);
            return result;
        }

        static Func<double, double> Sub(Func<double, double> a, Func<double, double> b)
        {
            Func<double, double> result = x => a(x) - b(x);
            return result;
        }

        static Func<double, double> Mul(Func<double, double> a, Func<double, double> b)
        {
            Func<double, double> result = x => a(x) * b(x);
            return result;
        }

        static Func<double, double> Comb(Func<double, double> a, Func<double, double> b)
        {
            Func<double, double> result = x => a(b(x));
            return result;
        }
    }
}
