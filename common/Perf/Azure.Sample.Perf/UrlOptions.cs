using Azure.Test.PerfStress;
using CommandLine;

namespace System.PerfStress
{
    public class UrlOptions : PerfStressOptions
    {
        [Option('u', "url", Required = true)]
        public string Url { get; set; }
    }
}
