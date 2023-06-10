using System.Text.RegularExpressions;

namespace Dyslexify
{
    public class Program
    {

        static string BoldString(string text)
        {
            //create an array of words which uses regex
            //to split words after any punctuation
            String[] words = Regex.Split(text, @"[\s\r,.\?]+");

            //iterate through array words
            for (int i = 0; i < words.Length; i++)
            {

                //assign word at each index to a variable
                string word = words[i];
                //figure out if the amount of characters is odd or even
                bool isOdd = word.Length % 2 != 0;

                //figure out how far half way of word, checks if odd returns
                //incremented value or 0 
                int halfway = word.Length / 2 + (isOdd ? 1 : 0);

                //get the first half of the word 
                string firstHalf = word.Substring(0, halfway);
                //get the second half of the word
                string secondHalf = word.Substring(halfway);
                // When assigning each word to index,
                // interpolate string with the first half 
                // bolded, then unbold the second half
                words[i] = $"\u001b[1m{firstHalf}\u001b[0m{secondHalf}";
            }
            //joins all the words of the array back.
            return String.Join(" ", words);
        }
        static void createFile(string path, string text)
        {
            try
            {

                text = "<html>\n<head>\n<style>\nbody { font-weight: bold; }\n</style>" +
                    "</head>\n<body>\n" + BoldString(text) +"\n" + "</body>\n</html>";

                MakeDocument(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        static void MakeDocument(String text)
        {
            ChromePdfRenderer chromeRenderer = new ChromePdfRenderer();
            PdfDocument pdf = chromeRenderer.RenderHtmlAsPdf(text);
            pdf.SaveAs("pdfExample.pdf");
            //String path = "C:\\Users\\libro\\source\\repos\\NewRepo\\Dyslexify\\Dyslexify\\word.docx";



        }
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\libro\\source\\repos\\NewRepo\\Dyslexify\\Dyslexify\\file.html";

            while (true)
            {
                Console.WriteLine("Please enter the text to convert");
                string text = Console.ReadLine();

                if (text == "quit")
                {
                    break;
                    Environment.Exit(-1);
                }
                Console.WriteLine(BoldString(text));
                createFile(path, BoldString(text));

                ChromePdfRenderer chromeRenderer = new ChromePdfRenderer();
                PdfDocument pdf = chromeRenderer.RenderHtmlAsPdf(text);
                pdf.SaveAs("pdfExample.pdf");

            }
        }

    }
}
