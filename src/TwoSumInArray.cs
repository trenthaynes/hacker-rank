using System;
using System.Collections.Generic;
using System.Linq;

public static class TwoSumInArray
{
    public static int[] Handle(int[] arr, int target)
    {
        return find_sum(arr.ToList(), target).ToArray();
    }

    public static List<int> Handle(List<int> arr, int target)
    {
        return find_sum(arr, target);
    }

    private static List<int> find_sum(List<int> numbers, int target)
    {
        // check that there are at least 2 elements
        if (numbers.Count <= 1)
        {
            return new List<int> { -1, -1 };
        }

        //  get a list of the unique values in the list, and their indices
        var ht = buildHashTable(numbers);

        //  look for the diff of a given number in the hashtable
        for (int i = 0; i < numbers.Count; i++)
        {
            var keyLU = numbers[i];
            var diff = target - keyLU;

            //  does the HT have the value we need?
            if (ht.ContainsKey(diff))
            {
                //  need to verify that the current index is unique
                //  because value can be duplicated in the list
                //  but returned indices must be unique
                var indices = ht[diff];
                int? idx = indices.FirstOrDefault(x => x != i);
                if (idx.HasValue)
                {
                    return new List<int> { i, idx.Value };
                }
            }
        }
        return new List<int> { -1, -1 };
    }

    private static Dictionary<int, List<int?>> buildHashTable(List<int> input)
    {
        var ht = new Dictionary<int, List<int?>>();

        for (int i = 0; i < input.Count; i++)
        {
            var kVal = input[i];
            if (ht.ContainsKey(kVal))
            {
                var lst = ht[kVal];
                lst.Add(i);
                ht[kVal] = lst;
            }
            else
            {
                var vList = new List<int?> { i };
                ht.Add(kVal, vList);
            }
        }

        return ht;
    }
}