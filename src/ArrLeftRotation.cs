using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static class ArrLeftRotation
{
    /*
      Inputs:
      #1 n d: the size of the array, number of left rotations
      #2 arr: the initial array of integers (n integers, separated by a space)
      
      Constraints
      1 <= n <= 10^5 (100,000)
      1 <= d <= n
      1 <= arr[i] <= 10^6 (1,000,000)

      Sample input:
      5 4
      1 2 3 4 5

      Sample output:
      5 1 2 3 4

      Explanation:
      Perform d=4 left rotations of arr

      Rotation result
      1st: 2 3 4 5 1
      2nd: 3 4 5 1 2
      3rd  4 5 1 2 3
      4th: 5 1 2 3 4

  */
    public static int[] Handle(int[] a, int d)
    {
        var n = a.Length;
        if (d > n)
        {
            d = d % n;
        }
        if (a.Length == d)
        {
            return a;
        }

        var output = new int[n];
        var dModn = d % n;

        for (int i = 0; i < n; i++)
        {
            output[(n - dModn + i) % n] = a[i];
        }

        return output;
    }
}