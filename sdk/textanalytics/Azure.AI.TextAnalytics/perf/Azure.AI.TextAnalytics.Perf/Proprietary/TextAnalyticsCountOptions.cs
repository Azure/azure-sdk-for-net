// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.AI.TextAnalytics.Perf
{
    public class TextAnalyticsCountOptions : PerfOptions
    {
        [Option('c', "count", Default = 1000, HelpText = "Number of items")]
        public int Count { get; set; }
    }
}
