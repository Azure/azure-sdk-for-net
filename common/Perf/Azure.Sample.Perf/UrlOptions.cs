// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Sample.Perf
{
    public class UrlOptions : PerfOptions
    {
        [Option('u', "url", Required = true)]
        public string Url { get; set; }
    }
}
