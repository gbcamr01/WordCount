using System;
using System.Linq;
using System.Collections.Generic;
using FileProcessing;

namespace WordCount
{
       public class WordCount : IWordCount
        {
            private IFileContent FileContent { get; set; }

            /// <summary>
            /// Constructor Inject the filecontent interface member type
            /// </summary>
            /// <param name="filecontent"></param>
            ///
            public WordCount(IFileContent filecontent)
            {
                this.FileContent = filecontent;
            }

            /// <summary>
            /// Return the number of words in the text as a dictionary (word,count)
            /// </summary>
            /// <param name="limit">return the top 'limit' (default is 10) entries</param>
            /// <returns></returns>
            public IDictionary<string, int> GetTopWords(int limit = 10)
            {
                Dictionary<string,int> filesplit = null;
                try
                {
                if (!string.IsNullOrWhiteSpace(FileContent.DataContent))
                {
                    try
                    {
                        //Use PLINQ to determine and group number of words in the text
                        filesplit = FileContent.DataContent.Split(FileContent.FileDelimiters, StringSplitOptions.RemoveEmptyEntries)
                        .AsParallel()
                        .GroupBy(word => word, StringComparer.OrdinalIgnoreCase)
                        .OrderByDescending(groupedword => groupedword.Count())
                        .Take(limit)
                        .ToDictionary(groupedword => groupedword.Key, groupedword => groupedword.Count());
                    }
                    catch (Exception) { }
                }
            }
                catch (Exception) { }
                return filesplit;
            }
        }
    }

    

