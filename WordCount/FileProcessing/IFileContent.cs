using System;
using System.Net;
using System.Threading.Tasks;

namespace FileProcessing
{
    public interface IFileContent
    {
        WebClient Webclient { get; set; }
        //Uri Uri { get; set; }
        string DataContent { get; set; }
        string FileName { get; set; }
        char[] FileDelimiters { get; set; }
        Task<string> GetContentsAsync(Uri uri);
        Task<string> GetContentsAsync(string filename);
        void GetContents(Uri uri);
        void GetContents(string filename);




    }
}
