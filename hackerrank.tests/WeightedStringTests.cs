using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;
using Shouldly;

namespace hackerrank.tests
{
    public class WeightedStringTests
    {
        [Fact]
        public void Test1()
        {
            var sw = new Stopwatch();
            var loc = Environment.CurrentDirectory;
            string path = Path.Combine(loc, @"weighted-strings");
            var files = Directory.EnumerateFiles(path, "*.1.txt");
            var testFile = files.First(f => f.StartsWith("test"));
            var ansrFile = files.First(f => f.StartsWith("answer"));
            
            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);
            Console.WriteLine($"Total Queries: {input.Length - 1}");
            var str = input[0];
            var cnt = input[1];
            var qs = new List<int>();
            for (var j = 2; j < input.Length; j++)
            {
                qs.Add(Convert.ToInt32(input[j]));
            }
            var result = WeightedString.Handle(str, qs.ToArray());
            
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            result.Length.ShouldBeSameAs(cnt);
        }
    }
}
