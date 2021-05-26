using System;
using System.Collections.Generic;
using System.Linq;

public static class IntersectionOf3Arrays
{
    public static int[] Handle(int[] a, int[] b, int[] c)
    {
        return find_intersection(a.ToList(), b.ToList(), c.ToList()).ToArray();
    }

    private static List<int> find_intersection(List<int> arr1, List<int> arr2, List<int> arr3)
    {
        var arrI = new List<int>();
        var a1 = arr1.Count;
        var a2 = arr2.Count;
        var a3 = arr3.Count;

        if (a1 < a2 && a1 < a3)
        {
            if (a2 < a3)
            {
                // 1, 2, 3
                arrI = get_intersection(arr1, arr2);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                arrI = get_intersection(arrI, arr3);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
            else
            {
                // 1, 3, 2
                arrI = get_intersection(arr1, arr3);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                arrI = get_intersection(arrI, arr2);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
        }

        if (a2 < arr1.Count && a2 < a3)
        {
            if (a1 < a3)
            {
                // 2, 1, 3
                arrI = get_intersection(arr2, arr1);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                arrI = get_intersection(arrI, arr3);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
            else
            {
                // 2, 3, 1
                arrI = get_intersection(arr2, arr3);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                arrI = get_intersection(arrI, arr1);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
        }

        if (a2 < a1)
        {
            // 3, 2, 1
            arrI = get_intersection(arr3, arr2);
            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }
            arrI = get_intersection(arrI, arr1);
            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }
            return arrI;
        }
        else
        {
            // 3, 1, 2
            arrI = get_intersection(arr3, arr1);
            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }
            arrI = get_intersection(arrI, arr2);
            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }
            return arrI;
        }

    }

    private static List<int> get_intersection(List<int> a1, List<int> a2)
    {
        var tmpSet = new List<int>();
        var i = 0;
        var len = a1.Count;
        var start = 0;
        var fin = a2.Count;

        // linear against a1, binary against a2
        while (i < len)
        {
            var val = a1[i];
            var result = bsearch(a2, start, fin, val);
            if (result == -1)
            {
                start = 0;
            }
            else
            {
                tmpSet.Add(val);
                start = result + 1;
            }
        }

        return tmpSet;
    }

    private static int bsearch(List<int> arr, int low, int high, int val)
    {
        var mid = -1;
        if (high >= low)
        {
            mid = low + (high - low) / 2;
            if (arr[mid] == val)
            {
                return mid;
            }

            if (arr[mid] > val)
            {
                return bsearch(arr, low, mid - 1, val);
            }

            return bsearch(arr, mid + 1, high, val);
        }
        return -1;
    }
}