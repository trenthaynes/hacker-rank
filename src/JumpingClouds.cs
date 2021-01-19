using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public static class JumpingClouds
{
    public static int Handle(int[] c)
    {
        var hops = 0;
        for (int i = 1; i < c.Length; i++)
        {
            Console.WriteLine($"Pos {i}, Value of c[i]:{c[i]}");
            if (i < c.Length-1 && c[i+1]==0)
            {
                // move 2
                hops++;
                i = i + 1;
            }
            else
            {
                // move 1
                hops++;
            }
        }
        
        return hops;
    }
}