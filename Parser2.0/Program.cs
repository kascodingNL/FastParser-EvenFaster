using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CustomIntParser
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterations = 50000;
            if (args.Length == 0)
            {
                Console.WriteLine("Please give an iteration count, default = 50000");
            }
            else
            {
                iterations = IntParseFast(args[0]);
            }

            Console.WriteLine("Testing with " + iterations + " iterations");

            /*Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            for (int i = 0; i < 50000; i++)
            {
                int customParsed = IntParseFast("95858");
            }
            Console.WriteLine("Test 1 took " + watch1.Elapsed);
            watch1.Stop();

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();

            for (int i = 0; i < 50000; i++)
            {
                int parsed = 0;
                parsed = int.Parse("95858");
            }
            Console.WriteLine("Test 2 took " + watch2.Elapsed);
            watch2.Stop();*/

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("Creating Execution thread...");
            Thread thread = new Thread(() => TestJob(iterations));
            watch.Stop();

            Console.WriteLine("Created Execution Thread in " + watch.Elapsed);
            thread.Start();

            WhileLoop();
        }

        public static void TestJob(int iterations)
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");

            Stopwatch totalTime = new Stopwatch();
            totalTime.Start();

            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            for (int i = 0; i < iterations; i++)
            {
                int customParsed = IntParseFast("95858");
            }
            watch1.Stop();

            double ns = 1000000000.0 * (double)watch1.ElapsedTicks / Stopwatch.Frequency;
            double ms = ns / 1000000.0;

            Console.WriteLine("Test 1 took " + ns + " nanoseconds(or " + ms + "ms).");

            Console.WriteLine("");

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();

            for (int i = 0; i < iterations; i++)
            {
                int parsed = 0;
                parsed = int.Parse("95858");
            }

            double ns1 = 1000000000.0 * (double)watch2.ElapsedTicks / Stopwatch.Frequency;
            double ms1 = ns1 / 1000000.0;
            Console.WriteLine("Test 2 took " + ns1 + " nanoseconds(or " + ms1 +"ms).");
            watch2.Stop();

            Console.WriteLine("");

            Stopwatch watch3 = new Stopwatch();
            watch3.Start();

            for (int i = 0; i < iterations; i++)
            {
                int parsed = 0;
                int.TryParse("95858", out parsed);
            }

            double ns2 = 1000000000.0 * (double)watch3.ElapsedTicks / Stopwatch.Frequency;
            double ms2 = ns2 / 1000000.0;
            Console.WriteLine("Test 3 took " + ns2 + " nanoseconds(or " + ms2 + "ms).");
            watch3.Stop();

            totalTime.Stop();
            Console.WriteLine("Total test took " + totalTime.Elapsed);
        }

        public static void WhileLoop()
        {
            while (true)
            {
                Thread.Sleep(1);
            }
        }

        private static int IntParseFast(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                result = 10 * result + (c - 48);
            }
            return result;
        }
    }
}
