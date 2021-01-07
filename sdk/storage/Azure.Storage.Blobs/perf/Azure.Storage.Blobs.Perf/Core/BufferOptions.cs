//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf.Core
{
    public class BufferOptions : SizeOptions
    {
        [Option("buffer", Default = false, HelpText = "Whether to buffer the response")]
        public bool Buffer { get; set; }
    }
}
