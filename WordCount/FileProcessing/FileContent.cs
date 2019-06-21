using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FileProcessing
{
    /// <summary>
    /// Class to manage the file and retrieve the contents via async call
    /// Use async in case the file size is large!
    /// </summary>
    public class FileContent : IFileContent
    {
        public WebClient Webclient { get; set; }
        public Uri Uri { get; set; }
        public string DataContent { get; set; }
        public char[] FileDelimiters { get; set; } = new char[] { ',', '.', '\t', '\r', '\n', '/', '\\', ' ', '\"', ':', ';', '|', ')', '(', '#', '<', '>', '{', '}', '!', '=', '-', '_', '+', '&', '?', };
        public string FileName { get; set; }

        //added for unit test
        public FileContent() { }

        /// <summary>
        /// Class constructor to get data from file
        /// </summary>
        /// <param name="filename">file name of data to retrieve</param>
        public FileContent(string filename)
        {
            this.FileName = filename;
            StartAsync(filename);
        }

        /// <summary>
        /// Class constructor to get data from URL
        /// </summary>
        /// <param name="webclient">Inject webclient into class</param>
        /// <param name="uri">URI of data to retrieve</param>
        public FileContent(WebClient webclient, Uri uri)
        {
            this.Uri = uri;
            this.Webclient = webclient;
            Start(uri);
        }

        /// <summary>
        /// Async call to get the URL as a large string
        /// </summary>
        public async void StartAsync(Uri uri)
        {
            var start = await GetContentsAsync(uri);
        }

        /// <summary>
        /// Async call to get the file contents as a large string
        /// </summary>
        /// <param name="filename"></param>
        public async void StartAsync(string filename)
        {
            var start = await GetContentsAsync(filename);
        }

        /// <summary>
        /// Call to get the URL as a string
        /// </summary>
        public void Start(string filename)
        {
            GetContents(filename);
        }

        /// <summary>
        /// Call to get the URL as a string
        /// </summary>
        public void Start(Uri uri)
        {
            GetContents(uri);
        }

        /// <summary>
        /// Load the file into a string buffer. Use async call in case file is large! 
        /// </summary>
        /// <param name="filename">Name of file to load</param>
        /// <returns></returns>
        public async Task<string> GetContentsAsync(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    Console.WriteLine($"Loading data asynchronously from file:{filename}");
                    DataContent = await File.ReadAllTextAsync(filename);
                }
                catch (Exception) { }
            }
            return DataContent;
        }

        /// <summary>
        /// Load the URI into a string buffer. Use async call in case data is large! 
        /// </summary>
        /// <param name="uri">URI of the text file to load</param>
        /// <returns></returns>
        public async Task<string> GetContentsAsync(Uri uri)
        {
            try
            {
                Console.WriteLine($"Loading data asynchronously from URL:{uri.AbsolutePath}");
                DataContent = await Webclient.DownloadStringTaskAsync(uri);
            }
            catch (Exception) { }
            return DataContent;
        }

        /// <summary>
        /// Load the URI into a string buffer. Use async call in case data is large! 
        /// </summary>
        /// <param name="uri">URI of the text file to load</param>
        /// <returns></returns>
        public void GetContents(Uri uri)
        {
            try
            {
                Console.WriteLine($"Loading data from URL:{uri.AbsolutePath}");
                DataContent = Webclient.DownloadString(uri);
            }
            catch (Exception) { }
            
        }

        /// <summary>
        /// Load the filename into a string buffer. Use async call in case data is large! 
        /// </summary>
        /// <param name="filename">file name of the text file to load</param>
        /// <returns></returns>
        public void GetContents(string filename)
        {
            try
            {
                Console.WriteLine($"Loading data from file:{filename}");
                DataContent = File.ReadAllText(filename);
            }
            catch (Exception) { }
            
        }
    }
}
