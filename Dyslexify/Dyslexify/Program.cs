using System;
using System.Text.RegularExpressions;

namespace Dyslexify
{
    public class Program
    {
        static string BoldString(string text)
        {
            string[] words = Regex.Split(text, @"[\s\r,.\?]+");

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int halfway = word.Length / 2;
                bool isOdd = word.Length % 2 != 0;

                string firstHalf = word.Substring(0, halfway + (isOdd ? 1 : 0));
                string secondHalf = word.Substring(halfway);

                words[i] = $"\u001b[1m{firstHalf}\u001b[0m{secondHalf}";
            }

            return string.Join(" ", words);
        }

        public static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Please enter the text to convert");
                string text = Console.ReadLine();

                if (text == "quit")
                {
                   Environment.Exit(-1);
                }
                Console.WriteLine(BoldString(text));

            }
        }
           
    }
}
