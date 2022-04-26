// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Test.Perf
{
    public class PageSizeCountOptions : CountOptions
    {
        [Option("max-page-size", HelpText = "Maximum page size per call")]
        public int? MaxPageSize { get; set; }
    }
}
