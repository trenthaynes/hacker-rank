using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        weightedStrings(_sw);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        jumpingClouds(_sw);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        repeatedString(_sw);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        twoDArray(_sw);
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        rotateLeft(_sw);
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        queueBribes(_sw);
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        intersectionArrays(_sw);
                        break;
                    case ConsoleKey.D8:
                    case ConsoleKey.NumPad8:
                        twoSumInArray(_sw);
                        break;
                    case ConsoleKey.D9:
                    case ConsoleKey.NumPad9:
                        twoSumInSortedArray(_sw);
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
                {"Weighted Uniform Strings", 1},
                {"Jumping on Clouds", 2},
                {"Repeated String", 3},
                {"2D Array DS", 4},
                {"Rotate Left", 5},
                {"Queue Bribes", 6},
                {"Intersection of 3 Arrays", 7},
                {"2 Sum in an Array", 8},
                {"2 Sum in a Sorted Array", 9},
            };

            Console.WriteLine($"{Environment.NewLine}Enter a menu number:");
            foreach (var opt in menuOpts)
            {
                Console.WriteLine($"{opt.Value}: {opt.Key}");
            }
            Console.WriteLine("");
        }

        static void twoSumInArray(Stopwatch sw)
        {
            var descr = @"
Given an array and a target number, find the indices of the two values from the array that sum up to the given target number.
The function returns an array of size two where the two elements specify the input array indices whose values sum up to the given target number.
In case when no answer exists, return an array of size two with both values equal to -1, i.e., [-1, -1].
In case when multiple answers exist, you may return any of them.
The order of the returned indices does not matter. 
A single index cannot be used twice.

Input: [5, 3, 10, 45, 1], 6
Output: [0, 4]

Input: [4, 1, 5, 0, -1], 10
Output: [-1, -1]
            ";

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);

            Console.WriteLine("Enter the number of test cases...");
            var caseCnt = Convert.ToInt32(Console.ReadLine());
            var input = new List<(int, int[])>();
            var output = new List<PrintResult>();
            for (int i = 0; i < caseCnt; i++)
            {
                Console.WriteLine($"Enter the target value for test case {i}...");
                var target = Console.ReadLine();
                Console.WriteLine($"Enter array for test case {i}...");
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), tarr => Convert.ToInt32(tarr));
                input.Add((Convert.ToInt32(target), temp));
            }

            for (int i = 0; i < input.Count; i++)
            {
                sw.Start();
                var result = TwoSumInArray.Handle(input[i].Item2, input[i].Item1);
                sw.Stop();
                output.Add(new PrintResult
                {
                    Elapsed = sw.Elapsed,
                    Result = string.Join(",", result)
                });
            }

            var sb = new StringBuilder();
            foreach (var item in output)
            {
                sb.AppendLine($"Elapsed: {item.Elapsed} - Result: [{item.Result}]");
            }
            Console.WriteLine($"The test case results:{Environment.NewLine}{string.Join('\n', sb.ToString())}");
        }

        static void twoSumInSortedArray(Stopwatch sw)
        {
            var descr = @"
Given an array sorted in non-decreasing order and a target number, find the indices of the two values from the array that sum up to the given target number.
The function returns an array of size two where the two elements specify the input array indices whose values sum up to the given target number.
In case when no answer exists, return an array of size two with both values equal to -1, i.e., [-1, -1].
In case when multiple answers exist, you may return any of them.
The order of the indices returned does not matter. 
A single index cannot be used twice.

Input: [1, 2, 3, 5, 10], 7
Output: [1, 3]
Sum of the elements at index 1 and 3 is 7.
            ";

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);

            Console.WriteLine("Enter the number of test cases...");
            var caseCnt = Convert.ToInt32(Console.ReadLine());
            var input = new List<(int, int[])>();
            var output = new List<PrintResult>();
            for (int i = 0; i < caseCnt; i++)
            {
                Console.WriteLine($"Enter the target value for test case {i}...");
                var target = Console.ReadLine();
                Console.WriteLine($"Enter array for test case {i}...");
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), tarr => Convert.ToInt32(tarr));
                input.Add((Convert.ToInt32(target), temp));
            }

            for (int i = 0; i < input.Count; i++)
            {
                sw.Start();
                var result = TwoSumInArray.Handle(input[i].Item2, input[i].Item1);
                sw.Stop();
                output.Add(new PrintResult
                {
                    Elapsed = sw.Elapsed,
                    Result = string.Join(",", result)
                });
            }

            var sb = new StringBuilder();
            foreach (var item in output)
            {
                sb.AppendLine($"Elapsed: {item.Elapsed} - Result: [{item.Result}]");
            }
            Console.WriteLine($"The test case results:{Environment.NewLine}{string.Join('\n', sb.ToString())}");
        }


        static void intersectionArrays(Stopwatch sw)
        {
            var descr = @"
*****     Intersection of 3 Arrays     *****
            
Find the intersection of 3 arrays
            ";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);

            Console.WriteLine("Enter the number of test cases...");
            var caseCnt = Convert.ToInt32(Console.ReadLine());
            var input = new int[(caseCnt * 3) - 1][];
            var output = new int[caseCnt - 1][];
            for (int i = 0; i < caseCnt; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var idx = i * 3 + j;
                    Console.WriteLine($"Enter array {j + 1} for test {(i + 1)}...");
                    input[idx] = Array.ConvertAll(Console.ReadLine().Split(' '), tarr => Convert.ToInt32(tarr));
                }
            }

            sw.Start();
            for (int i = 0; i < caseCnt; i++)
            {
                var a1 = input[(i * 3)];
                var a2 = input[(i * 3 + 1)];
                var a3 = input[(i * 3 + 2)];
                output[i] = (IntersectionOf3Arrays.Handle(a1.ToList(), a2.ToList(), a3.ToList())).ToArray();
            }
            sw.Stop();

            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            var msg = string.Empty;
            foreach (var arr in output)
            {
                msg += $"{(string.Join(",", arr))}\n";
            }
            Console.WriteLine($"The test case results:{Environment.NewLine}{string.Join('\n', msg)}");
        }

        static void queueBribes(Stopwatch sw)
        {
            var descr = @"
*****     Rotate Array Left     *****
            
It is New Year's Day and people are in line for the Wonderland rollercoaster ride. Each person wears a sticker 
indicating their initial position in the queue from 1 to N. Any person can bribe the person directly in front of 
them to swap positions, but they still wear their original sticker. One person can bribe at most two others.

Determine the minimum number of bribes that took place to get to a given queue order. Print the number of 
bribes, or, if anyone has bribed more than two people, print 'Too chaotic'.
            ";
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(descr);

            Console.WriteLine("Enter the number of test cases...");
            var caseCnt = Convert.ToInt32(Console.ReadLine());
            var input = new int[caseCnt][];
            var output = new string[caseCnt];
            for (int i = 0; i < caseCnt; i++)
            {
                Console.WriteLine($"Enter the length of the array for test case {i}...");
                var cnt = Console.ReadLine();
                Console.WriteLine($"Enter array for test case {i}...");
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), tarr => Convert.ToInt32(tarr));
                input[i] = temp;
            }

            sw.Start();
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = QueueBribes.Handle(input[i]);
            }
            sw.Stop();

            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine($"The test case results:{Environment.NewLine}{string.Join('\n', output)}");
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
            Console.WriteLine($"The rotated arrary is:{Environment.NewLine}{string.Join(' ', result)}");
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
