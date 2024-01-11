using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class Problem
{
    public static void Main(string[] args)
    {
        String line;
        line = Console.ReadLine();
        int[] input = line.Split().Select(str => int.Parse(str)).ToArray();
        int n = input[0];
        int c = input[1];
        int k = input[2];
        String s = Console.ReadLine();
        long out_ = Count(n, c, k, s);
        Console.Out.WriteLine(out_);
    }

    public static long Count(int n, int c, int k, String s)
    {
        long splitCount = 0;
        //7
        //4
        //3
        //2
        //2
        //2
        //1
        List<int[]> combinators = new List<int[]>();
        for(int groupSize= 1; groupSize <= s.Length; groupSize++)
        {
            //string pattern = "\\d{1," + groupSize +"}";
            string groupPattern = "(\\d{" + groupSize + "})";
            string restPattern = "(\\w+)";
            for(int i = 1; i * groupSize < s.Length; i++)
            {
                string pattern = Enumerable.Repeat(groupPattern, i).Aggregate((acc, item) => acc + item) + restPattern;
                Regex regex = new Regex(pattern);
                var match = regex.Match(s);
                if (match.Success == false)
                {
                    continue;
                }

                var matchedGroups = match.Groups.AsReadOnly().Skip(1);
                if (matchedGroups.All(g => (g.Success && int.Parse(g.Value) <= c)))
                {
                    combinators.Add(matchedGroups.Select(g => int.Parse(g.Value)).ToArray());
                    splitCount += matchedGroups.Count();
                }
            }
        }
                //splitCount += Factorial(n)
        return splitCount;
    }

    private static long Combinatorics(int n, int r)
    {
        if (r == 2)
        {
            if (n == 2) return 1;
            if (n == 3) return 3;
            if (n == 4) return 6;
            if (n == 5) return 10;
            if (n == 6) return 15;
            if (n == 7) return 21;
            if (n == 8) return 28;
            if (n == 9) return 36;
            if (n == 10) return 45;
        }

        return FactorialDivision(n, n - r) / Factorial(r);
    }

    private static long FactorialDivision(int topFactorial, int divisorFactorial)
    {
        long result = 1;
        for (int i = topFactorial; i > divisorFactorial; i--)
        {
            result *= i;
        }

        return result;
    }

    private static long Factorial(int n)
    {
        if (n <= 1)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }
}

