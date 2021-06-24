using System;
using System.Collections.Generic;
using System.Linq;

public static class IntersectionOf3Arrays
{
    public static int[] Handle(int[] a, int[] b, int[] c)
    {
        return find_intersection(a.ToList(), b.ToList(), c.ToList()).ToArray();
    }

    public static List<int> Handle(List<int> a, List<int> b, List<int> c)
    {
        return find_intersection(a, b, c);
    }

    private static List<int> find_intersection(List<int> arr1, List<int> arr2, List<int> arr3)
    {
        var arrI = new List<int>();
        var a1 = arr1.Count;
        var a2 = arr2.Count;
        var a3 = arr3.Count;
        var useBin = true;

        if (a1 == 0 || a2 == 0 || a3 == 0)
        {
            return new List<int> { -1 };
        }


        if (a1 <= 10 || a2 <= 10 || a3 <= 10)
        {
            useBin = false;
        }

        if (a1 <= a2 && a1 <= a3)
        {
            if (a2 <= a3)
            {
                // 1, 2, 3
                arrI = (useBin) ? get_intersection_binary(arr1, arr3) : get_intersection_linear(arr1, arr3);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }

                if (arrI.Count >= a2)
                {
                    arrI = (useBin) ? get_intersection_binary(arr2, arrI) : get_intersection_linear(arr2, arrI);
                }
                else
                {
                    arrI = (useBin) ? get_intersection_binary(arrI, arr2) : get_intersection_linear(arrI, arr2);
                }

                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
            else
            {
                // 1, 3, 2
                arrI = (useBin) ? get_intersection_binary(arr1, arr2) : get_intersection_linear(arr1, arr2);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }

                if (arrI.Count >= a3)
                {
                    arrI = (useBin) ? get_intersection_binary(arr3, arrI) : get_intersection_linear(arr3, arrI);
                }
                else
                {
                    arrI = (useBin) ? get_intersection_binary(arrI, arr3) : get_intersection_linear(arrI, arr3);
                }

                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
        }

        if (a2 <= a1 && a2 <= a3)
        {
            if (a1 <= a3)
            {
                // 2, 1, 3
                arrI = (useBin) ? get_intersection_binary(arr2, arr3) : get_intersection_linear(arr2, arr3);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }

                if (arrI.Count >= a1)
                {
                    arrI = (useBin) ? get_intersection_binary(arr1, arrI) : get_intersection_linear(arr1, arrI);
                }
                else
                {
                    arrI = (useBin) ? get_intersection_binary(arrI, arr1) : get_intersection_linear(arrI, arr1);
                }

                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
            else
            {
                // 2, 3, 1
                arrI = (useBin) ? get_intersection_binary(arr2, arr1) : get_intersection_linear(arr2, arr1);
                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }

                if (arrI.Count >= a2)
                {
                    arrI = (useBin) ? get_intersection_binary(arr3, arrI) : get_intersection_linear(arr3, arrI);
                }
                else
                {
                    arrI = (useBin) ? get_intersection_binary(arrI, arr3) : get_intersection_linear(arrI, arr3);
                }

                if (arrI.Count == 0)
                {
                    return new List<int> { -1 };
                }
                return arrI;
            }
        }

        if (a2 <= a1)
        {
            // 3, 2, 1
            arrI = (useBin) ? get_intersection_binary(arr3, arr1) : get_intersection_linear(arr3, arr1);
            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }

            if (arrI.Count >= a2)
            {
                arrI = (useBin) ? get_intersection_binary(arr2, arrI) : get_intersection_linear(arr2, arrI);
            }
            else
            {
                arrI = (useBin) ? get_intersection_binary(arrI, arr2) : get_intersection_linear(arrI, arr2);
            }

            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }
            return arrI;
        }
        else
        {
            // 3, 1, 2
            arrI = get_intersection_binary(arr3, arr2);
            arrI = (useBin) ? get_intersection_binary(arr3, arr2) : get_intersection_linear(arr3, arr2);
            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }

            if (arrI.Count >= a1)
            {
                arrI = (useBin) ? get_intersection_binary(arr1, arrI) : get_intersection_linear(arr1, arrI);
            }
            else
            {
                arrI = (useBin) ? get_intersection_binary(arrI, arr1) : get_intersection_linear(arrI, arr1);
            }

            if (arrI.Count == 0)
            {
                return new List<int> { -1 };
            }
            return arrI;
        }

    }

    private static List<int> get_intersection_linear(List<int> a, List<int> b)
    {
        var tmpSet = new List<int>();
        var idxA = 0;
        var idxB = 0;
        var lenA = a.Count;
        var lenB = b.Count;

        while (idxA < lenA && idxB < lenB)
        {
            if (a[idxA] < b[idxB])
            {
                idxA++;
            }
            else if (a[idxA] > b[idxB])
            {
                idxB++;
            }
            else
            {
                tmpSet.Add(a[idxA]);
                idxA++;
                idxB++;
            }
        }
        return tmpSet;
    }

    private static List<int> get_intersection_binary(List<int> a1, List<int> a2)
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
            Console.WriteLine($"start:{start}, fin:{fin}, val:{val}");
            var result = a2.BinarySearch(start, fin - start, val, null);
            if (result == -1)
            {
                start = 0;
            }
            else
            {
                tmpSet.Add(val);
                start = result + 1;
            }
            i++;
        }

        return tmpSet;
    }

    private static int bsearch(List<int> arr, int low, int high, int val, int cntr, int idx)
    {
        cntr++;
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
                return bsearch(arr, low, mid - 1, val, cntr, idx);
            }

            return bsearch(arr, mid + 1, high, val, cntr, idx);
        }
        return -1;
    }
}