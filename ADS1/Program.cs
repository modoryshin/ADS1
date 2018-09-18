using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ADS1
{
    class Program
    {
        static int Number()
        { 
            bool ok;
            int m = 0;
            do
            {
                Console.WriteLine("Enter desired number.");
                ok = Int32.TryParse(Console.ReadLine(), out m);
                if (!ok)
                    Console.WriteLine("Wrong type.");
                else if (m <= 0)
                    Console.WriteLine("Invalid size.");
            } while (!ok||m<=0);
            return m;
        }
        static void Iterations(int m)
        {
            Console.WriteLine("By numerous iterations in a cycle:");
            Stopwatch w = new Stopwatch();
            int x0 = 1, x1 = 1;
            w.Start();
            int x2 = 0 - x0 - 2 * x1;
            x0 = x1;
                x1 = x2;
            for(int n = 1; n < m; n++)
            {
                x2 = 24 * n - x0 - 2 * x1;
                x0 = x1;
                x1 = x2;
            }
            w.Stop();
            Console.WriteLine("Result equals {0}. Time needed equals {1}.", x0,w.ElapsedMilliseconds);
            w.Reset();
        }
        static void Recursion(int n, int m, int x0, int x1)
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            if (n < m)
            {
                int x2 = 24 * n - x0 - 2 * x1;
                x0 = x1;
                x1 = x2;
                n++;
                Recursion(n, m, x0, x1);
            }
            else
            {
                Console.WriteLine("Result equals {0}. Time needed equals {1}.", x0,w.ElapsedMilliseconds);
                w.Reset();
            }
        }
        static void Formula(int n)
        {
            Console.WriteLine("By formula:");
            Stopwatch w = new Stopwatch();
            w.Start();
            double x = ((-8) * n + 7) * Math.Pow(-1, n) + 6 * n - 6;
            w.Stop();
            Console.WriteLine("Result equals {0}. Time needed equals {1}.",x,w.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            int m = Number();
            Formula(m);
            Iterations(m);
            Console.WriteLine("By the recursive method:");
            Recursion(0, m, 1, 1);
            Console.ReadKey();
        }
    }
}
