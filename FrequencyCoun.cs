using System;
using System.Collections.Generic;

namespace FrequencyCounter
{
    class Frequency
    {
        public static Dictionary<string, int> CountFrequency(string input)
        {
            Dictionary<string, int> count = new Dictionary<string, int>();
            string[] words = input.Split(" ");

            foreach (string w in words)
            {
                string word = w;

                if (!char.IsLetter(word[word.Length - 1]))
                {
                    word = word.Substring(0, word.Length - 1);
                }

                if (count.ContainsKey(word))
                {
                    count[word]++;
                }
                else
                {
                    count[word] = 1;
                }
            }

            return count;
        }
    }
}
