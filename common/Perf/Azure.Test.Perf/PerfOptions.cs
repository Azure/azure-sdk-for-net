// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Test.Perf
{
    public class PerfOptions
    {
        [Option('d', "duration", Default = 10, HelpText = "Duration of test in seconds")]
        public int Duration { get; set; }

        [Option("host", HelpText = "Host to redirect HTTP requests")]
        public string Host { get; set; }

        [Option("insecure", HelpText = "Allow untrusted SSL certs")]
        public bool Insecure { get; set; }

        [Option('i', "iterations", Default = 1, HelpText = "Number of iterations of main test loop")]
        public int Iterations { get; set; }

        [Option("job-statistics", HelpText = "Print job statistics (used by automation)")]
        public bool JobStatistics { get; set; }

        [Option('l', "latency", HelpText = "Track and print per-operation latency statistics")]
        public bool Latency { get; set; }

        [Option("no-cleanup", HelpText = "Disables test cleanup")]
        public bool NoCleanup { get; set; }

        [Option('p', "parallel", Default = 1, HelpText = "Number of operations to execute in parallel")]
        public int Parallel { get; set; }

        [Option("port", HelpText = "Port to redirect HTTP requests")]
        public int? Port { get; set; }

        [Option('r', "rate", HelpText = "Target throughput (ops/sec)")]
        public int? Rate { get; set; }

        [Option("status-interval", Default = 1, HelpText = "Interval to write status to console in seconds")]
        public int StatusInterval { get; set; }

        [Option("sync", HelpText = "Runs sync version of test")]
        public bool Sync { get; set; }

        [Option('w', "warmup", Default = 5, HelpText = "Duration of warmup in seconds")]
        public int Warmup { get; set; }
    }
}
