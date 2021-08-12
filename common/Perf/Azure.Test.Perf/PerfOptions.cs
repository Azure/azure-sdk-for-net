// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;
using System;

namespace Azure.Test.Perf
{
    public class PerfOptions : PerfOptionsBase
    {
        [Option('x', "test-proxy", HelpText = "URI of TestProxy Server")]
        public Uri TestProxy { get; set; }
    }
}
