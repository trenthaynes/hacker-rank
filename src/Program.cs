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
                        twoDArray(_sw);
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
                    case ConsoleKey.NumPad4:
                        twoDArray(_sw);
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
                {"Newest: 2D Array DS", 0},
                {"Weighted Uniform Strings", 1},
                {"Jumping on Clouds", 2},
                {"Repeated String", 3},
                {"2D Array DS", 4},
            };

            Console.WriteLine($"{Environment.NewLine}Enter a menu number:");
            foreach (var opt in menuOpts)
            {
                Console.WriteLine($"{opt.Value}: {opt.Key}");
            }
            Console.WriteLine("");
        }

        static void rotateLeft(Stopwatch sw)
        {
            var descr = $@"
            *****     Rotate Array Left     *****

            Inputs:
            #1 n d: the size of the array, number of left rotations
            #2 arr: the initial array of integers (n integers, separated by a space)
            
            Constraints
            1 <= n <= 10^5 (100,000)
            1 <= d <= n
            1 <= arr[i] <= 10^6 (1,000,000)

            Sample input:
            5 4
            1 2 3 4 5

            Sample output:
            5 1 2 3 4

            Explanation:
            Perform d=4 left rotations of arr

            Rotation result
            1st: 2 3 4 5 1
            2nd: 3 4 5 1 2
            3rd  4 5 1 2 3
            4th: 5 1 2 3 4
            ";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);
            Console.WriteLine("Enter the length of the array...");
            var arrLen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of rotations...");
            int rotates = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter array of numbers...");
            int[] arr = new int[arrLen];
            var qs = Console.ReadLine().Split(' ');
            for (int i = 0; i < qs.Length; i++)
            {
                arr[i] = Convert.ToInt32(qs[i]);
            }

            sw.Start();
            var result = ArrLeftRotation.Handle(arr, rotates);
            sw.Stop();

            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine($"The rotated arrary is:{Environment.NewLine}{result}");
        }

        static void twoDArray(Stopwatch sw)
        {
            var descr = $@"
            *****     2D Array - DS     *****
            Given a 6x6 2D array, Arr.
            1 1 1 0 0 0
            0 1 0 0 0 0
            1 1 1 0 0 0
            0 0 0 0 0 0
            0 0 0 0 0 0
            0 0 0 0 0 0

            An hourglass in A is a subset of values with indices falling in this pattern in Arr's graphical representation.
            a b c
              d
            e f g

            There are 16 hourglass in Arr.  An hourglass sum is the sum of the values at each indices. Print the maximum hourglass sum in Arr.
            The array will always be 6x6.

            Arr = 
            -9 -9 -9  1  1  1
             0 -9  0  4  3  2
            -9 -9 -9  1  2  3
             0  0  8  6  6  0
             0  0  0 -2  0  0
             0  0  1  2  4  0

            The 16 sums are: -63, -34, -9, 12, -10, 0, 28, 23, -27, -11, -2, 10, 9, 17, 25, 18
            The max sum is: 28, starting from Arr[1][3].{Environment.NewLine}";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);

            var input = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"Enter row {i + 1}...");
                input[i] = Array.ConvertAll(Console.ReadLine().Split(' '), tarr => Convert.ToInt32(tarr));
            }

            sw.Start();
            var result = TwoDArray.Handle(input);
            sw.Stop();

            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine($"The number of 'a' found is {result}.");
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
