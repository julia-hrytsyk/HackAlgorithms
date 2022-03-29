using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'sherlockAndAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    //static int combination(int n, int k=2)
    //{
    //    //n!/(n-m)! * m!
    //    int res = 1;
    //    //n!/m!
    //    for (int i = k+1; i <= n; i++)
    //    {
    //        res *= i;
    //    }
    //    //../(n-m)!

    //    int nm = 1;
    //    for (int i = 2; i <= n-k; i++)
    //    {
    //        nm *= i;
    //    }

    //    return res/nm;
    //}

    public static int sherlockAndAnagrams(string s)
    {
        var dict = new Dictionary<string, int>();
        int combinations = 0;
        //Fill dict with anagrams
        for (int j = 0; j < s.Length; ++j)
        {
            if (dict.ContainsKey(s[j].ToString()))
            {
                dict[s[j].ToString()]++;
            }
            else
            {
                dict[s[j].ToString()] = 1;
            }
        }

        string sorted;
        for (int i = 2; i < s.Length; ++i)
        {
            for (int j = 0; j < s.Length - i + 1; ++j)
            {
                sorted = String.Concat(s.Substring(j, i).OrderBy(c => c));
                if (dict.ContainsKey(sorted))
                {
                    dict[sorted]++;
                }
                else
                {
                    dict[sorted] = 1;
                }
            }
        }

        //Calc combinations count
        foreach (var key in dict.Keys)
        {
            if (dict[key] > 1)
            {
                combinations += (dict[key] * (dict[key] - 1) / 2);
            }
        }

        return combinations;
    }

}

class Algorithm
{
    public static void Main(string[] args)
    {

        string s = Console.ReadLine();

        int result = Result.sherlockAndAnagrams(s);

        Console.WriteLine(result);

    }
}
