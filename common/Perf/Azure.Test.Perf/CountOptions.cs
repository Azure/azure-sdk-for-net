using CommandLine;

namespace Azure.Test.PerfStress
{
    public class CountOptions : PerfStressOptions
    {
        [Option('c', "count", Default = 10, HelpText = "Number of items")]
        public int Count { get; set; }
    }
}
