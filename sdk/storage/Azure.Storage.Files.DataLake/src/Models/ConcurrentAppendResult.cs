// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The result of the Concurrent Append operation.
    /// </summary>
    public class ConcurrentAppendResult
    {
        /// <summary>
        /// The number of blocks that have been commited to this Append File.
        /// </summary>
        public long CommittedBlockCount { get; internal set; }
    }
}
