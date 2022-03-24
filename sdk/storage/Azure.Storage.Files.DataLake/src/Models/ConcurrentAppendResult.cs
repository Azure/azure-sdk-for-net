// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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

        /// <summary>
        /// Fast Path session data.
        /// </summary>
        public string FastPathSessionData { get; internal set; }

        /// <summary>
        /// Fast Path session data expires on.
        /// </summary>
        public DateTimeOffset? FastPathSessionDataExpiresOn { get; internal set; }
    }
}
