// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Test.Perf
{
    public class CountOptions : PerfOptions
    {
        [Option('c', "count", Default = 10, HelpText = "Number of items")]
        public int Count { get; set; }
    }
}
