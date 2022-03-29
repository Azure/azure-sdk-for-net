// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;
using System;

namespace Azure.Sample.Perf
{
    public class UriOptions : PerfOptions
    {
        [Option('u', "uri", Required = true)]
        public Uri Uri { get; set; }
    }
}
