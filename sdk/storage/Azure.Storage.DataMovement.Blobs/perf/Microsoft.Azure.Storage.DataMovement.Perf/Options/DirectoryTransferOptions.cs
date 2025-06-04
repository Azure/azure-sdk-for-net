// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Microsoft.Azure.Storage.DataMovement.Perf
{
    public class DirectoryTransferOptions : PerfOptions
    {
        [Option('c', "count", Default = 10, HelpText = "Number of items in each transfer.")]
        public int Count { get; set; }

        [Option('s', "size", Default = 1024, HelpText = "Size of each file (in bytes)")]
        public long Size { get; set; }

        [Option("chunk-size", HelpText = "The chunk/block size to use during transfers (in bytes)")]
        public long? ChunkSize { get; set; }

        [Option("concurrency", HelpText = "The max concurrency to use during each transfer.")]
        public int? Concurrency { get; set; }

        // Override warmup to set default to 0
        [Option('w', "warmup", Default = 0, HelpText = "Duration of warmup in seconds")]
        public new int Warmup { get; set; }
    }
}
