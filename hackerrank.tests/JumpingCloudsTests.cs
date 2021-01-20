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
    public class JumpingCloudsTests
    {
        private string _loc;
        private string _path;

        public JumpingCloudsTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
            _path = Path.Combine(_loc, @"jumping-clouds");
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
            
            var cnt = Convert.ToInt32(input[0]);
            var hops = new int[cnt];
            for (var j = 1; j < cnt; j++)
            {
                hops[j-1] = Convert.ToInt32(input[j]);
            }
            
            var result = JumpingClouds.Handle(hops);
            
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
            
            var cnt = Convert.ToInt32(input[0]);
            var hops = new int[cnt];
            for (var j = 1; j < cnt; j++)
            {
                hops[j-1] = Convert.ToInt32(input[j]);
            }

            var result = JumpingClouds.Handle(hops);
            
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            sw.Reset();

            var answers = File.ReadAllLines(ansrFile);
            var answer = Convert.ToInt32(answers.First());

            result.ShouldBe(answer);
        }
    }
}
