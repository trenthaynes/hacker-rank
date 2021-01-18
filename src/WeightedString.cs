using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public static class WeightedString
{
    public static string[] Handle(string s, int[] queries)
    {
        var stopWatch2 = new Stopwatch();
        var stack = new StringBuilder();
        var unisWt = new Dictionary<string, int>();
        var output = new List<string>();
        var lastC = s[0];
        stopWatch2.Start();
        for(int x = 0; x < s.Length; x++)
        {
            var c = char.ToLower(s[x]);
            if (stack.Length == 0 || lastC == c)
            {
                stack.Append(c);
                lastC = c;
                try
                {
                    unisWt.Add(stack.ToString(), GetWt(lastC, stack.Length));
                }
                catch (System.ArgumentException)
                {
                    // suppress the exception
                    Console.WriteLine("duplicate string found");
                }
            }
            else
            {
                stack.Clear();
                stack.Append(c);
                lastC = c;
                try
                {
                    unisWt.Add(stack.ToString(), GetWt(lastC, stack.Length));    
                }
                catch (System.ArgumentException)
                {
                    // suppress the exception
                    Console.WriteLine("duplicate string found");
                }
            }
        }
        stopWatch2.Stop();
        Console.WriteLine($"Generated {unisWt.Count} uniform strings.");
        Console.WriteLine($"Elapsed: {stopWatch2.Elapsed}");
        stopWatch2.Reset();
        stopWatch2.Start();
        for(int j = 0; j < queries.Length; j++)
        {
            if(unisWt.ContainsValue(queries[j]))
            {
                output.Add("Yes");
            }
            else
            {
                output.Add("No");
            }
        }
        stopWatch2.Stop();
        Console.WriteLine($"Elapsed: {stopWatch2.Elapsed}");
        return output.ToArray();
    }

    static int GetWt(char val, int len)
    {
        return (char.ToUpper(val) - 64) * len;
    }
}