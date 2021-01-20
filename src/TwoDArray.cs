using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static class TwoDArray
{
    const char a = 'a';
    /*
        Sample Input:
        1 1 1 0 0 0
        0 1 0 0 0 0
        1 1 1 0 0 0
        0 0 2 4 4 0
        0 0 0 2 0 0
        0 0 1 2 4 0

        Sample Output: 19

        Input contains the following hourglasses:
        1 1 1  1 1 0  1 0 0  0 0 0
          1      0      0      0
        1 1 1  1 1 0  1 0 0  0 0 0

        0 1 0  1 0 0  0 0 0  0 0 0
          1      1      0      0
        0 0 2  0 2 4  2 4 4  4 4 0

        1 1 1  1 1 0  1 0 0  0 0 0
          0      2      4      4
        0 0 0  0 0 2  0 2 0  2 0 0

        0 0 2  0 2 4  2 4 4  4 4 0
          0      0      2      0
        0 0 1  0 1 2  1 2 4  2 4 0

        Hourglass with highest sum is (19):
        2 4 4
          2
        1 2 4

    */
    public static int Handle(int[][] grid)
    {
        return 0;
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