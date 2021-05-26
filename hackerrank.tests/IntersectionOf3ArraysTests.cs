using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;
using Shouldly;
using System.Reflection;

namespace hackerrank.tests
{
    public class IntersectionOf3ArraysTests
    {
        private string _loc;
        public IntersectionOf3ArraysTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
        }

        [Fact]
        public void Test1()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"intersection-arrays");
            var files = Directory.EnumerateFiles(path, "*.1.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");

            var allLines = File.ReadAllLines(testFile);
            var inputArrs = new int[2][];
            var iaCnt = 0;

            for (int i = 0; i < allLines.Length; i++)
            {
                var str = allLines[i];
                var cnt = Convert.ToInt32(str);
                int[] arr;
                if (cnt != 0)
                {

                    i++;
                    arr = Array.ConvertAll(allLines[i].Split(' '), tarr => Convert.ToInt32(tarr));
                }
                else
                {
                    arr = new int[0];
                }
                inputArrs[iaCnt] = arr;
                if (i != 0 || i % 2 != 0)
                {
                    iaCnt++;
                }
            }

            var output = (IntersectionOf3Arrays.Handle(inputArrs[0], inputArrs[1], inputArrs[2])).ToList();

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();
            var answers = File.ReadAllLines(ansrFile);

            output.ShouldSatisfyAllConditions(
                () =>
                {
                    foreach (var item in output)
                    {
                        item.ShouldNotBe(0);
                    }
                }
            );
        }

        [Fact]
        public void Test2()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"weighted-strings");
            var files = Directory.EnumerateFiles(path, "*.2.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);
            Console.WriteLine($"Total Queries: {input.Length - 1}");
            var str = input[0];
            var cnt = Convert.ToInt32(input[1]);
            var qs = new List<int>();
            for (var j = 2; j < input.Length; j++)
            {
                qs.Add(Convert.ToInt32(input[j]));
            }
            var result = WeightedString.Handle(str, qs.ToArray());

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();
            var answers = File.ReadAllLines(ansrFile);

            result.ShouldSatisfyAllConditions(
                () => result.Length.ShouldBe(cnt),
                () =>
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i].ShouldBe(answers[i]);
                    }
                }
            );
        }

        [Fact]
        public void Test3()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"weighted-strings");
            var files = Directory.EnumerateFiles(path, "*.3.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);
            Console.WriteLine($"Total Queries: {input.Length - 1}");
            var str = input[0];
            var cnt = Convert.ToInt32(input[1]);
            var qs = new List<int>();
            for (var j = 2; j < input.Length; j++)
            {
                qs.Add(Convert.ToInt32(input[j]));
            }
            var result = WeightedString.Handle(str, qs.ToArray());

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();
            var answers = File.ReadAllLines(ansrFile);

            result.ShouldSatisfyAllConditions(
                () => result.Length.ShouldBe(cnt),
                () =>
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i].ShouldBe(answers[i]);
                    }
                }
            );
        }
    }
}
