// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace System.PerfStress
{
    public class UrlOptions : PerfStressOptions
    {
        [Option('u', "url", Required = true)]
        public string Url { get; set; }
    }
}
