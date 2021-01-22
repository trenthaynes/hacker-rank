using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static class QueueBribes
{
    /*
    1 <= t <= 10
    1 <= n <= 10^5 (100,000)
    Each person can bribe MAX 2 people.

    Given: 
        t = 2
        n1 = 5
        q1 = [2, 1, 5, 3, 4]
        n2 = 5
        q2 = [2, 5, 1, 3, 4]

    Output:
        3
        Too chaotic
    
    Explanation:

    Test Case #1 - Initial state 
    1, 2, 3, 4, 5
    Person 5 moves 1 position ahead by bribing person 4
    1, 2, 3, 5, 4
    Person 5 moves 1 position ahead by bribing person 3
    1, 2, 5, 3, 4
    Person 2 moves 1 position ahead by bribing person 1
    2, 1, 5, 3, 4
    Final state, after 3 bribing opertions:
    2, 1, 5, 3, 4

    Test Case #2 - Final state
    2, 5, 1, 3, 4
    Person 5 had to bribe 3 people to get to the 2nd spot,
    which is not allowed.  Max bribes is 2.
    */
    public static string Handle(int[] q)
    {


        return string.Empty;
    }
}