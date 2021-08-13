// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Sample.Perf.Batch
{
    public class MockReceiverOptions : PerfOptions
    {
        [Option("max-message-count", Default = 10)]
        public int MaxMessageCount { get; set; }

        [Option("min-message-count", Default = 0)]
        public int MinMessageCount { get; set; }
    }
}
