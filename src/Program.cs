using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace weighted_uniform_strings
{
    class Program
    {
        private static Stopwatch _sw;
        static void Main(string[] args)
        {
            _sw = new Stopwatch();
            var menuOpts = new Dictionary<string, int>
            {
                {"Weighted Uniform Strings", 1},
                {"Jumping on Clouds", 2},
            };

            Console.WriteLine("Enter the number:");
            foreach (var opt in menuOpts)
            {
                Console.WriteLine($"{opt.Value}: {opt.Key}");
            }
            var optVal = Console.ReadLine();
            switch (optVal)
            {
                case "1":
                    weightedStrings(_sw);
                break;
                case "2":
                    jumpingClouds(_sw);
                break;
            }
        }

        static void weightedStrings(Stopwatch sw)
        {
            Console.WriteLine("weigh and calc uniform strings in a provided string, determine which query values exist in the calculated uniform string weights.");
            Console.WriteLine("Enter the string to process and weigh...");
            var strToProcess = Console.ReadLine();
            Console.WriteLine("Enter the total number of weights to query for...");
            int queryCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter array of weights to query for...");
            int[] queries = new int[queryCount];
            var qs = Console.ReadLine().Split(' ');
            for (int i = 0; i < qs.Length; i++)
            {
                queries[i] = Convert.ToInt32(qs[i]);
            }
            var result = WeightedString.Handle(strToProcess, queries);
        }

        static void jumpingClouds(Stopwatch sw)
        {
            var descr = $@"     
            There is a new mobile game that starts with consecutively numbered clouds. Some of the clouds are thunderheads and others are cumulus.
            The player can jump on any cumulus cloud having a number that is equal to the number of the current cloud plus 1 or 2.
            The player must avoid the thunderheads. Determine the minimum number of jumps it will take to jump from the starting postion to the last cloud. 
            It is always possible to win the game.
            For each game, you will get an array of clouds numbered 0 if they are safe or 1 if they must be avoided.{Environment.NewLine}";
            Console.WriteLine(descr);
            Console.WriteLine("Press ANY key to continue.");
            Console.Read();
            var loc = Environment.CurrentDirectory;
            string path = Path.Combine(loc, @"jumping-clouds");
            var files = Directory.EnumerateFiles(path, "*.txt");
            foreach (var f in files)
            {
                sw.Start();
                Console.WriteLine($"processing {f}");
                var input = File.ReadAllLines(f);
                var n = Convert.ToInt32(input[0]);
                var c = Array.ConvertAll(input[1].Split(' '), cTmp => Convert.ToInt32(cTmp));
                if (n != c.Length)
                {
                    break;
                }
                var result = JumpingClouds.Handle(c);
                sw.Stop();
                Console.WriteLine($"Elapsed: {sw.Elapsed}");
                sw.Reset();
            }
        }
    }    
}
