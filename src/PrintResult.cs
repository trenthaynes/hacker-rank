using System;
using System.Collections.Generic;

public class PrintResult
{
    public PrintResult()
    {
        Answers = new Dictionary<int, List<int[]>>();
    }
    public TimeSpan Elapsed { get; set; }
    public string Result { get; set; }
    public int[] ResultArray { get; set; }
    public Dictionary<int, List<int[]>> Answers { get; set; }
}