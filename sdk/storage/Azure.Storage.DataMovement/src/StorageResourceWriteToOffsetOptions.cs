﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for <see cref="StorageResourceSingle.WriteFromStreamAsync(Stream, long, bool, long, long, StorageResourceWriteToOffsetOptions, CancellationToken)"/>
    /// </summary>
    public class StorageResourceWriteToOffsetOptions
    {
        /// <summary>
        /// Optional. If a specific block id is wanted to send with the request when staging a block
        /// to the blob.
        ///
        /// Applies only to block blobs.
        /// </summary>
        public string BlockId { get; internal set; }
    }
}
