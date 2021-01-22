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
    public class ArrLeftRotationTests
    {
        private string _loc;
        private string _path;

        public ArrLeftRotationTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
            _path = Path.Combine(_loc, @"arr-rotate");
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
            var temp = Array.ConvertAll(input[0].Split(' '), tarr => Convert.ToInt32(tarr));
            var arrLen = temp[0];
            var rotates = temp[1];
            var arr = Array.ConvertAll(input[1].Split(' '), tarr => Convert.ToInt32(tarr));
            var result = ArrLeftRotation.Handle(arr, rotates);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = answers.First();
            var resultStr = string.Join(' ', result);

            resultStr.ShouldBe(answer);
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
            var temp = Array.ConvertAll(input[0].Split(' '), tarr => Convert.ToInt32(tarr));
            var arrLen = temp[0];
            var rotates = temp[1];
            var arr = Array.ConvertAll(input[1].Split(' '), tarr => Convert.ToInt32(tarr));
            var result = ArrLeftRotation.Handle(arr, rotates);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = answers.First();
            var resultStr = string.Join(' ', result);

            resultStr.ShouldBe(answer);
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
            var temp = Array.ConvertAll(input[0].Split(' '), tarr => Convert.ToInt32(tarr));
            var arrLen = temp[0];
            var rotates = temp[1];
            var arr = Array.ConvertAll(input[1].Split(' '), tarr => Convert.ToInt32(tarr));
            var result = ArrLeftRotation.Handle(arr, rotates);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = answers.First();
            var resultStr = string.Join(' ', result);

            resultStr.ShouldBe(answer);
        }

        [Fact]
        public void Test4()
        {
            var sw = new Stopwatch();

            var files = Directory.EnumerateFiles(_path, "*.4.txt");

            var testFile = files.First(f => Path.GetFileName(f).Contains("test"));
            var ansrFile = files.First(f => Path.GetFileName(f).Contains("answer"));

            sw.Start();
            Console.WriteLine($"processing {testFile}");
            var input = File.ReadAllLines(testFile);
            var temp = Array.ConvertAll(input[0].Split(' '), tarr => Convert.ToInt32(tarr));
            var arrLen = temp[0];
            var rotates = temp[1];
            var arr = Array.ConvertAll(input[1].Split(' '), tarr => Convert.ToInt32(tarr));
            var result = ArrLeftRotation.Handle(arr, rotates);

            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = answers.First();
            var resultStr = string.Join(' ', result);

            resultStr.ShouldBe(answer);
        }
    }
}
