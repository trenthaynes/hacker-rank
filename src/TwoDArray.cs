using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static class TwoDArray
{
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

        Constraints
        -9 <= Arr[i][j] <= 9
         0 <=    i,j    <= 5
  */
    public static int Handle(int[][] arr)
    {
        var maxVal = -64;
        for (var y = 0; y <= 3; y++)
        {
            for (var x = 0; x <= 3; x++)
            {
                var sum = arr[y][x] + arr[y][x + 1] + arr[y][x + 2];
                sum += arr[y + 1][x + 1];
                sum += arr[y + 2][x] + arr[y + 2][x + 1] + arr[y + 2][x + 2];
                maxVal = Math.Max(sum, maxVal);
            }
        }
        return maxVal;
    }
}