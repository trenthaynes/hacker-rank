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
    public class QueueBribesTests
    {
        private string _loc;
        private string _path;

        public QueueBribesTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
            _path = Path.Combine(_loc, @"queue-bribes");
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
            var caseCnt = Convert.ToInt32(input[0]);
            var cases = new List<int[]>();
            var lim = caseCnt * 2;

            var output = new string[caseCnt];
            for (int i = 2; i <= lim; i = i + 2)
            {
                cases.Add(Array.ConvertAll(input[i].Split(' '), tarr => Convert.ToInt32(tarr)));
            }
            for (int j = 0; j < caseCnt; j++)
            {
                output[j] = QueueBribes.Handle(cases[j]);
            }
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            output.ShouldSatisfyAllConditions(() =>
            {
                for (int i = 0; i < output.Length; i++)
                {
                    output[i].ShouldBe(answers[i]);
                }
            });
        }


    }
}
