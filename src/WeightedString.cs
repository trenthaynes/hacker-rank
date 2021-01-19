using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static class WeightedString
{
    public static string[] Handle(string s, int[] queries)
    {
        var output = new string[queries.Length];
        var mapping = new Dictionary<int, string>();
        var cnt = 1;

        mapping.Add(char.ToUpper(s[0]) - 64, "Yes");

        for (int i = 1; i < s.Length; i++)
        {
            cnt = s[i-1] == s[i] ? cnt + 1 : 1;
            mapping.TryGetValue((char.ToUpper(s[i]) - 64) * cnt, out string val);
            if (val == null)
            {
                mapping.Add((char.ToUpper(s[i]) - 64) * cnt, "Yes");
            }
        }

        for (int j = 0; j < queries.Length; j++)
        {
            mapping.TryGetValue(queries[j], out string val);
            output[j] = val != null ? val : "No";
        }

        return output;
    }
}