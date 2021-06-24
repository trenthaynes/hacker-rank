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
    public class TwoSumInArrayTests
    {
        private string _loc;
        public TwoSumInArrayTests()
        {
            _loc = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location.Replace("bin\\Debug\\netcoreapp3.1", string.Empty));
        }

        public struct TestResult
        {
            public int[] TestOutput;
            public int[] TestAnswer;
        }

        [Fact]
        public void TwoSumInArray_Test()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"two-sum-in-array");
            var testFiles = Directory.EnumerateFiles(path, "test.*.txt");
            var inputArr = new int[0];
            var target = 0;
            var rawAnswers = new List<int>();
            var answers = new Dictionary<int, List<int[]>>();
            var answersArr = new int[1];
            var arrSize = 0;
            int cntr;
            int testCnt = 0;
            string line;
            string sizeStr;
            var output = new List<PrintResult>();

            foreach (var testFile in testFiles)
            {
                testCnt++;
                using (var fileStream = File.OpenRead(testFile))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        sizeStr = streamReader.ReadLine();
                        if (sizeStr != null)
                        {
                            Int32.TryParse(sizeStr, out arrSize);
                            inputArr = new int[arrSize];
                            for (cntr = 0; cntr < arrSize; cntr++)
                            {
                                line = streamReader.ReadLine();
                                if (line != null)
                                {
                                    inputArr[cntr] = Int32.Parse(line);
                                }
                            }
                        }

                        line = streamReader.ReadLine();
                        if (line != null)
                        {
                            Int32.TryParse(line, out target);
                        }

                        while ((line = streamReader.ReadLine()) != null)
                        {
                            Int32.TryParse(line, out int ans);
                            rawAnswers.Add(ans);
                        }
                    }
                }

                var arList = new List<int[]>();
                for (int i = 0; i < rawAnswers.Count; i++)
                {
                    if (i == 0 || i % 2 == 0)
                    {
                        answersArr[0] = rawAnswers[i];
                        answersArr[1] = rawAnswers[i + 1];
                        arList.Add(answersArr);
                    }
                }
                var arrs = ().ToArray();
                answers.Add(target, arList);

                sw.Start();
                var result = TwoSumInArray.Handle(inputArr, target);
                sw.Stop();

                output.Add(new PrintResult
                {
                    Elapsed = sw.Elapsed,
                    ResultArray = result,
                    Answers = answers,
                    Result = $"Elapsed: {sw.Elapsed}{Environment.NewLine}Target:{target}{Environment.NewLine}Result:[{(string.Join(",", result))}]{Environment.NewLine}Answers:[{()}]"
                });
            }

            // int[] z = (from array in new[] { a, b, c } from arr in array select arr).ToArray();

            output.ShouldSatisfyAllConditions(
                () =>
                {
                    foreach (var ans in output)
                    {
                        Console.WriteLine($"{ans.Result}");
                        var dictAns = ans.Answers[0];
                        foreach (var arr in dictAns)
                        {
                            (arr.Any(a1 => a1 == ans.ResultArray[0]) && arr.Any(a2 => a2 == ans.ResultArray[1])).ShouldBeTrue();
                        }
                    }
                }
            );
        }
    }
}
