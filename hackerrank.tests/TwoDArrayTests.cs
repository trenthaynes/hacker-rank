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
    public class TwoDArrayTests
    {
        private string _loc;
        private string _path;

        public TwoDArrayTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
            _path = Path.Combine(_loc, @"two-d-array");
        }

        [Fact]
        public void Test1()
        {
            var sw = new Stopwatch();

            var files = Directory.EnumerateFiles(_path, "*.1.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);

            var grid = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                grid[i] = Array.ConvertAll(input[i].Split(' '), tarr => Convert.ToInt32(tarr));
            }

            var result = TwoDArray.Handle(grid);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = Convert.ToInt32(answers.First());

            result.ShouldBe(answer);
        }

        [Fact]
        public void Test2()
        {
            var sw = new Stopwatch();

            var files = Directory.EnumerateFiles(_path, "*.2.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);

            var grid = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                grid[i] = Array.ConvertAll(input[i].Split(' '), tarr => Convert.ToInt32(tarr));
            }

            var result = TwoDArray.Handle(grid);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = Convert.ToInt32(answers.First());

            result.ShouldBe(answer);
        }

        [Fact]
        public void Test3()
        {
            var sw = new Stopwatch();

            var files = Directory.EnumerateFiles(_path, "*.3.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);

            var grid = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                grid[i] = Array.ConvertAll(input[i].Split(' '), tarr => Convert.ToInt32(tarr));
            }

            var result = TwoDArray.Handle(grid);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = Convert.ToInt32(answers.First());

            result.ShouldBe(answer);
        }
    }
}
