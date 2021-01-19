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
            
            Console.Clear();
            var done = false;
            do
            {
                printMenu();
                Console.Write("Menu # (Press ESC to exit):");
                var optVal = Console.ReadKey(true).Key;
                switch (optVal)
                {
                    case ConsoleKey.NumPad0:
                        repeatedString(_sw);
                        break;
                    case ConsoleKey.NumPad1:
                        weightedStrings(_sw);
                        break;
                    case ConsoleKey.NumPad2:
                        jumpingClouds(_sw);
                        break;
                    case ConsoleKey.NumPad3:
                        repeatedString(_sw);
                        break;
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                }
            } while (!done);
            Environment.Exit(0);
        }

        private static void printMenu()
        {
            var menuOpts = new Dictionary<string, int>
            {
                {"Newest: Repeated String", 0},
                {"Weighted Uniform Strings", 1},
                {"Jumping on Clouds", 2},
                {"Repeated String", 3},
            };

            Console.WriteLine($"{Environment.NewLine}Enter a menu number:");
            foreach (var opt in menuOpts)
            {
                Console.WriteLine($"{opt.Value}: {opt.Key}");
            }
            Console.WriteLine("");
        }

        static void weightedStrings(Stopwatch sw)
        {
            Console.Clear();
            Console.WriteLine("");
            var descr = @"
            *****     WEIGHTED UNIFORM STRINGS     *****
            Weigh and calc uniform strings in a provided string, determine which query values exist in the calculated uniform string weights.
            ";
            Console.WriteLine(descr);
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
            sw.Start();
            var result = WeightedString.Handle(strToProcess, queries);
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine("Queries result:");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{queries[i]}  -  {result[i]}");
            }
        }

        static void jumpingClouds(Stopwatch sw)
        {
            var descr = $@"     
            *****     JUMPING CLOUDS     *****
            There is a new mobile game that starts with consecutively numbered clouds. Some of the clouds are thunderheads and others are cumulus.
            The player can jump on any cumulus cloud having a number that is equal to the number of the current cloud plus 1 or 2.
            The player must avoid the thunderheads. Determine the minimum number of jumps it will take to jump from the starting postion to the last cloud. 
            It is always possible to win the game.
            For each game, you will get an array of clouds numbered 0 if they are safe or 1 if they must be avoided.{Environment.NewLine}";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);
            Console.WriteLine("Enter the total number of clouds...");
            int cloudCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter array of clouds (0 for cumulus, 1 for thunderhead)...");
            int[] clouds = new int[cloudCount];
            var qs = Console.ReadLine().Split(' ');
            for (int i = 0; i < qs.Length; i++)
            {
                clouds[i] = Convert.ToInt32(qs[i]);
            }
            sw.Start();
            var result = JumpingClouds.Handle(clouds);
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine($"The shortest path took {result} hops.");
        }

        static void repeatedString(Stopwatch sw)
        {
            var descr = $@"
            *****     REPEATED STRING     *****
            There is a string, S, of lowercase English letters that is repeated infinitely many times. 
            Given an integer, N, find and print the number of letter a's in the first  letters of the infinite string.
            Example: S = 'abcac', N = 10
            The substring we consider is 'abcacabcac', the first 10 characters of the infinite string. There are 4 occurrences of 'a; in the substring.{Environment.NewLine}";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);
            Console.WriteLine("Enter the string to repeat...");
            var strToProcess = Console.ReadLine();
            Console.WriteLine("the number of characters to consider...");
            int chrCount = Convert.ToInt32(Console.ReadLine());
            
            sw.Start();
            var result = RepeatedString.Handle(strToProcess, chrCount);
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine($"The number of 'a' found is {result}.");
        }
    }    
}
