// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Template.Perf
{
    public class DownloadTestOptions : SizeOptions
    {
        [Option("buffer", Default = false, HelpText = "Whether to buffer the response")]
        public bool Buffer { get; set; }
    }
}
