// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.AI.MetricsAdvisor.Perf
{
    public class MetricsAdvisorPerfOptions : PerfOptions
    {
        [Option("count", Default = 10, HelpText = "The number of items to get in listing requests")]
        public int Count { get; set; }
    }
}
