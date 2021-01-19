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
    public class WeightedStringTests
    {
        private string _loc;
        public WeightedStringTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
        }

        [Fact]
        public void Test1()
        {
            var sw = new Stopwatch();
            
            string path = Path.Combine(_loc, @"weighted-strings");
            var files = Directory.EnumerateFiles(path, "*.1.txt");
            
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
                () => {
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i].ShouldBe(answers[i]);
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
                () => {
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
                () => {
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i].ShouldBe(answers[i]);
                    }
                }
            );
        }
    }
}
