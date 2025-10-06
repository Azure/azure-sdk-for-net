// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for <see cref="StorageResourceItem.CopyFromStreamAsync(Stream, long, bool, long, StorageResourceWriteToOffsetOptions, CancellationToken)"/>
    /// </summary>
    public class StorageResourceWriteToOffsetOptions
    {
        /// <summary>
        /// Optional. If a specific block id is wanted to send with the request when staging a block
        /// to the blob.
        ///
        /// Applies only to block blobs.
        /// </summary>
        public string BlockId { get; set; }

        /// <summary>
        /// Optional. Specifies the position to write to. Will default to 0 if not specified.
        /// </summary>
        public long? Position { get; set; }

        /// <summary>
        /// Optional. Specifies whether this write is for the initial chunk.
        /// </summary>
        public bool Initial { get; set; }

        /// <summary>
        /// Optional. Specifies the source properties to set in the destination.
        /// </summary>
        public StorageResourceItemProperties SourceProperties { get; set; }
    }
}
