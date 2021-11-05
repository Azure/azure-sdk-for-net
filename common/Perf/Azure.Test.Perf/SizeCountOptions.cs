// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Test.Perf
{
    public class SizeCountOptions : PerfOptions
    {
        [Option('s', "size", Default = 1024, HelpText = "Size of payload (in bytes)")]
        public long Size { get; set; }

        [Option('c', "count", Default = 10, HelpText = "Number of items")]
        public int Count { get; set; }
    }
}
