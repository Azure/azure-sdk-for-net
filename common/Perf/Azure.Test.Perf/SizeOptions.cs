using Azure.Test.PerfStress;
using CommandLine;

namespace Azure.Test.PerfStress
{
    public class SizeOptions : PerfStressOptions
    {
        [Option('s', "size", Default = 1024, HelpText = "Size of payload (in bytes)")]
        public long Size { get; set; }
    }
}
