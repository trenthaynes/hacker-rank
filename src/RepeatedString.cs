using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static class RepeatedString
{
    const char a = 'a';
    /*
        1 <= s.Length <= 100
        1 <= n <= 10^12
    
        Given: s = 'aba', n = 10
        Substring becomes: 'abaabaabaa'
        Return value: 7

        Given: s = 'a', n = 1000000000000
        Substring becomes 'aaaa...' (1 trillion times)
        Return value: 1000000000000
    */
    public static long Handle(string s, long n)
    {
        var countInS = CountIn(s, a, s.Length);
        var remainder = n % s.Length;
        var repeatS = n / s.Length;
        var countInRemainder = CountIn(s, a, (int)remainder);
        
        return countInS * repeatS + countInRemainder;
    }

    public static int CountIn(string val, char find, int end)
    {
        int total = 0;
        for(int i = 0; i < end; i++)
        {
            if(val[i] == find)
            {
                total++;
            }
        }
        return total;
    }
}