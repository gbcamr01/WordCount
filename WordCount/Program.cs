using System;
using FileProcessing;
using System.Linq;
using System.Net;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://archive.org/stream/TheLordOfTheRing1TheFellowshipOfTheRing/The+Lord+Of+The+Ring+1-The+Fellowship+Of+The+Ring_djvu.txt";

            WebClient webclient = new WebClient();
            Uri uri = new Uri(URL);
            
            try
            {
                IFileContent filecontent = new FileContent(webclient, uri);

                WordCount wc = new WordCount(filecontent);
                var topwords = wc.GetTopWords();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
