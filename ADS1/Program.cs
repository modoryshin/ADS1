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

                    Console.WriteLine("Wrong type.\n");

                else if (m <= 0)

                    Console.WriteLine("Invalid size.\n");

            } while (!ok || m <= 0);

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

            for (int n = 1; n < m; n++)

            {

                x2 = 24 * n - x0 - 2 * x1;

                x0 = x1;

                x1 = x2;

            }

            w.Stop();

            Console.WriteLine("Result equals {0}. Time needed equals {1}. \n", x0, w.ElapsedTicks);

            w.Reset();

        }

        static void Recursion(int[] mas)

        {
            if (mas[2] < mas[3])
            {
                Stopwatch w = new Stopwatch();
                w.Start();
                int x2 = 24 * mas[2] - 2 * mas[1] - mas[0];
                mas[0] = mas[1];
                mas[1] = x2;
                mas[2]++;
                w.Stop();
                mas[4] = mas[4] + Convert.ToInt32(w.ElapsedTicks);
                w.Reset();
                Recursion(mas);
            }
            else
            {
                Console.WriteLine("Result equals {0}. Time needed equals {1}. \n", mas[0], mas[4]);
            }
        }

        static void Formula(int n)

        {

            Console.WriteLine("By formula:");

            Stopwatch w = new Stopwatch();

            w.Start();

            double x = ((-8) * n + 7) * Math.Pow(-1, n) + 6 * n - 6;

            w.Stop();

            Console.WriteLine("Result equals {0}. Time needed equals {1}. \n", x, w.ElapsedTicks);

        }

        static void Main(string[] args)

        {
            bool e = false;
            string end;
            do
            {
                int m = Number();

                Formula(m);

                Iterations(m);

                Console.WriteLine("By the recursive method:");
                int[] mas = new int[5] { 1,1,0,m,0};
                Recursion(mas);
                Console.WriteLine("To end this session enter (exit).");
                end = Console.ReadLine();
                if (end == "exit" || end == "учше")
                    e = true;
            } while (e != true);

            Console.ReadKey();

        }

    }

}



