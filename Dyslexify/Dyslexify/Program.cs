using Console_Exts;
using System;

namespace Dyslexify
{

    public class Program
    {
        static String boldString(String text)
        {
            text = "A bunch of random words strung together";
            //split the text into an array of strings
            String[] words = text.Split(" ");

            //iterate through array of strings
            for (int i = 0; i < words.Length; i++)
            {
                // assign word at index to a variable
                String word = words[i];
                //get half
                int halfWay = word.Length / 2;
                bool isOdd = word.Length % 2 != 0;

                String firstHalf = word.Substring(0, halfWay + (isOdd ? 1: 0));
                String secondHalf = word.Substring(halfWay);

                words[i] = $"\u001b[1m{firstHalf}\u001b[0m{secondHalf}";

            }

            return string.Join(" ", words);
        }
        public static void Main(string[] args)
        {
            
            Console.Out.WriteLine(boldString("A Random bunch of text strung together"));
        }
    }

}
