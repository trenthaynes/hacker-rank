using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public static class JumpingClouds
{
    public static int Handle(int[] c)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        var path = new List<int>();
        for (int i = 0; i < c.Length; i++)
        {
            if (c[i]==1)
            {
                continue;
            }
            if (path.Count == 0)
            {
                path.Add(c[i]);
            }
            else
            {
                if (i < c.Length - 1 && c[i+1] == 0)
                {
                    path.Add(c[i+1]);
                    i = i + 1;
                }
                else
                {
                    path.Add(c[i]);
                }
            }
        }
        
        return path.Count;
    }
}