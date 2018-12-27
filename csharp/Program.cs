using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            longestPalindromicSubstring("My dad is a racecar athlete");
        }

        static void longestPalindromicSubstring(string str)
        {
            int len = str.Length;
            int maxLength = 1;
            var subStrings = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                subStrings[i] = new bool[len];
                subStrings[i][i] = true;
            }
            int start = 0;
            for (int i = 0; i < len - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    subStrings[i][i + 1] = true;
                    maxLength = 2;
                    start = i;
                }
            }
            for (int k = 3; k <= len; k++)
            {
                for (int i = 0; i < len - k + 1; i++)
                {
                    int j = i + k - 1;
                    if (subStrings[i + 1][j - 1] && str[i] == str[j])
                    {
                        subStrings[i][j] = true;
                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            Console.WriteLine($"maxLength: {maxLength}. Longest palindrome substring is: {str.Substring(start, maxLength)}");
        }
    }
}
