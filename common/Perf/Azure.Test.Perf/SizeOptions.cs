// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Test.Perf
{
    public class SizeOptions : PerfStressOptions
    {
        [Option('s', "size", Default = 1024, HelpText = "Size of payload (in bytes)")]
        public long Size { get; set; }
    }
}
