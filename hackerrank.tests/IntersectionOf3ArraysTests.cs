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

        public struct TestResult
        {
            public int[] TestOutput;
            public int[] TestAnswer;
        }

        [Fact]
        public void Test_22()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"intersection-arrays");
            var testFile = Directory.EnumerateFiles(path, "test22.txt").FirstOrDefault();
            var answerFile = Directory.EnumerateFiles(path, "answer22.txt").FirstOrDefault();
            var answer = new int[0];
            var answerTmp = new List<int>();
            var arr1 = new int[0];
            var arr2 = new int[0];
            var arr3 = new int[0];
            var arrSize = 0;
            int cntr;
            string line;
            string sizeStr;

            using (var fileStream = File.OpenRead(answerFile))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        answerTmp.Add(Int32.Parse(line));
                    }
                    answer = answerTmp.ToArray();
                }
            }

            using (var fileStream = File.OpenRead(testFile))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr1 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr1[cntr] = Int32.Parse(line);
                            }
                        }
                    }

                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr2 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr2[cntr] = Int32.Parse(line);
                            }
                        }
                    }

                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr3 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr3[cntr] = Int32.Parse(line);
                            }
                        }
                    }
                }
            }

            sw.Start();
            var output = IntersectionOf3Arrays.Handle(arr1, arr2, arr3).ToArray();
            sw.Stop();
            Console.WriteLine($"Test 22 - Elapsed: {sw.Elapsed}");
            var aLen = answer.Length;
            var oLen = output.Length;
            output.ShouldSatisfyAllConditions(
                () => aLen.Equals(oLen).ShouldBeTrue($"aLen:{aLen}, oLen:{oLen}"),
                () =>
                {
                    for (var i = 0; i < aLen; i++)
                    {
                        (answer[i] == output[i]).ShouldBeTrue($"i:{i}, answer[i]:{answer[i]}, output[1]:{output[i]}");
                    }
                }
            );
        }

        [Fact]
        public void Test_21()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"intersection-arrays");
            var testFile = Directory.EnumerateFiles(path, "test21.txt").FirstOrDefault();
            var answerFile = Directory.EnumerateFiles(path, "answer21.txt").FirstOrDefault();
            var answer = new int[0];
            var answerTmp = new List<int>();
            var arr1 = new int[0];
            var arr2 = new int[0];
            var arr3 = new int[0];
            var arrSize = 0;
            int cntr;
            string line;
            string sizeStr;

            using (var fileStream = File.OpenRead(answerFile))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        answerTmp.Add(Int32.Parse(line));
                    }
                    answer = answerTmp.ToArray();
                }
            }

            using (var fileStream = File.OpenRead(testFile))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr1 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr1[cntr] = Int32.Parse(line);
                            }
                        }
                    }

                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr2 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr2[cntr] = Int32.Parse(line);
                            }
                        }
                    }

                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr3 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr3[cntr] = Int32.Parse(line);
                            }
                        }
                    }
                }
            }

            sw.Start();
            var output = IntersectionOf3Arrays.Handle(arr1, arr2, arr3).ToArray();
            sw.Stop();
            Console.WriteLine($"Test 21 - Elapsed: {sw.Elapsed}");
            var aLen = answer.Length;
            var oLen = output.Length;
            output.ShouldSatisfyAllConditions(
                () => aLen.Equals(oLen).ShouldBeTrue($"aLen:{aLen}, oLen:{oLen}"),
                () =>
                {
                    for (var i = 0; i < aLen; i++)
                    {
                        (answer[i] == output[i]).ShouldBeTrue($"i:{i}, answer[i]:{answer[i]}, output[1]:{output[i]}");
                    }
                }
            );
        }

        [Fact]
        public void Test_20()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"intersection-arrays");
            var testFile = Directory.EnumerateFiles(path, "test20.txt").FirstOrDefault();
            var answerFile = Directory.EnumerateFiles(path, "answer20.txt").FirstOrDefault();
            var answer = new int[0];
            var answerTmp = new List<int>();
            var arr1 = new int[0];
            var arr2 = new int[0];
            var arr3 = new int[0];
            var arrSize = 0;
            int cntr;
            string line;
            string sizeStr;

            using (var fileStream = File.OpenRead(answerFile))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        answerTmp.Add(Int32.Parse(line));
                    }
                    answer = answerTmp.ToArray();
                }
            }

            using (var fileStream = File.OpenRead(testFile))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr1 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr1[cntr] = Int32.Parse(line);
                            }
                        }
                    }

                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr2 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr2[cntr] = Int32.Parse(line);
                            }
                        }
                    }

                    sizeStr = streamReader.ReadLine();
                    if (sizeStr != null)
                    {
                        Int32.TryParse(sizeStr, out arrSize);
                        arr3 = new int[arrSize];
                        for (cntr = 0; cntr < arrSize; cntr++)
                        {
                            line = streamReader.ReadLine();
                            if (line != null)
                            {
                                arr3[cntr] = Int32.Parse(line);
                            }
                        }
                    }
                }
            }

            sw.Start();
            var output = IntersectionOf3Arrays.Handle(arr1, arr2, arr3).ToArray();
            sw.Stop();
            Console.WriteLine($"Test 20 - Elapsed: {sw.Elapsed}");
            var aLen = answer.Length;
            var oLen = output.Length;
            output.ShouldSatisfyAllConditions(
                () => aLen.Equals(oLen).ShouldBeTrue($"aLen:{aLen}, oLen:{oLen}"),
                () =>
                {
                    for (var i = 0; i < aLen; i++)
                    {
                        (answer[i] == output[i]).ShouldBeTrue($"i:{i}, answer[i]:{answer[i]}, output[1]:{output[i]}");
                    }
                }
            );
        }

        [Fact]
        public void Test()
        {
            var sw = new Stopwatch();

            string path = Path.Combine(_loc, @"intersection-arrays");
            var testFiles = Directory.EnumerateFiles(path, "test.??.txt");
            var results = new Dictionary<int, TestResult>();
            int[] answer;
            var list1 = new List<int>();
            var list2 = new List<int>();
            var list3 = new List<int>();
            var testCount = 1;

            foreach (var test in testFiles)
            {
                var testNum = test.Substring(test.Length - 6, 2);
                Console.WriteLine($"processing Test {testNum}");
                var allLines = File.ReadAllLines(test);
                var idx = 0;
                var lineCount = allLines.Length;

                int arrSize = 0;
                var inputList = new Dictionary<int, int[]>();
                var isArr = false;
                var arrCnt = 1;

                if (lineCount == 0)
                {
                    Console.WriteLine($"Skipping Test {testNum}");
                    testCount++;
                    continue;
                }

                if (lineCount == 4)
                {
                    inputList.Add(1, null);
                    inputList.Add(2, null);
                    inputList.Add(3, null);
                    inputList.Add(4, new int[] { -1 });
                }

                var line = allLines[idx];
                if (lineCount > 4)
                {
                    //  line 0
                    if (idx == 0)
                    {
                        //  arr 1 size
                        Int32.TryParse(line, out arrSize);
                        idx++;
                    }

                    //  line 1
                    if (idx == 1)
                    {
                        //  if arr size 0, there is no array to populate
                        if (arrSize > 0)
                        {
                            // this line is an array
                            line = allLines[idx];
                            inputList.Add(arrCnt, Array.ConvertAll(line.Split(' '), tarr => Convert.ToInt32(tarr)));
                        }
                        else
                        {
                            // this line is actually next array size
                            Int32.TryParse(line, out arrSize);
                            // Add an empty arr for this ine
                            inputList.Add(arrCnt, null);
                            isArr = true;
                        }
                        idx++;
                        arrCnt++;
                    }

                    while (idx < lineCount)
                    {
                        //  get the line   
                        line = allLines[idx];
                        if (!isArr)
                        {
                            // this is the answer array
                            if (idx == lineCount - 1)
                            {
                                inputList.Add(arrCnt, Array.ConvertAll(line.Split(','), tarr => Convert.ToInt32(tarr)));
                            }
                            else  // this is array size
                            {
                                Int32.TryParse(line, out arrSize);
                                isArr = true;
                            }
                        }
                        else
                        {
                            if (arrSize > 0)
                            {
                                // this line is an array
                                inputList.Add(arrCnt, Array.ConvertAll(line.Split(' '), tarr => Convert.ToInt32(tarr)));
                                isArr = false;
                            }
                            else
                            {
                                // this line is actually next array size
                                Int32.TryParse(line, out arrSize);
                                // Add an empty arr for this ine
                                inputList.Add(arrCnt, null);
                                isArr = true;
                            }
                            arrCnt++;
                        }
                        idx++;
                    }
                }

                for (int i = 1; i < 4; i++)
                {
                    var tmp = inputList.FirstOrDefault(il => il.Key == i).Value;
                    if (i == 1)
                    {
                        list1 = tmp != null ? tmp.ToList() : new List<int>();
                        continue;
                    }
                    if (i == 2)
                    {
                        list2 = tmp != null ? tmp.ToList() : new List<int>();
                        continue;
                    }
                    list3 = tmp != null ? tmp.ToList() : new List<int>();
                }
                answer = inputList.FirstOrDefault(i => i.Key == 4).Value;
                sw.Start();
                var output = IntersectionOf3Arrays.Handle(list1, list2, list3).ToArray();
                sw.Stop();
                Console.WriteLine($"Test {testNum} - Elapsed: {sw.Elapsed}");
                var tResult = new TestResult { TestAnswer = answer, TestOutput = output };
                results.Add(testCount, tResult);
                sw.Reset();
                testCount++;
            }

            foreach (var result in results)
            {
                Console.WriteLine($"Results for Test {result.Key} \n Test Output:[{(string.Join(",", result.Value.TestOutput))}] \n Test Answer:[{(string.Join(",", result.Value.TestAnswer))}]");
                result.ShouldSatisfyAllConditions(
                    () =>
                    {
                        foreach (var item in result.Value.TestOutput)
                        {
                            result.Value.TestAnswer.Contains(item).ShouldBeTrue();
                        }
                    }
                );
            }
        }
    }
}
