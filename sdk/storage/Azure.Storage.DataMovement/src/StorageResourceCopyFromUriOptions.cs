// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Options for <see cref="StorageResourceItem.CopyFromStreamAsync(Stream, long, bool, long, StorageResourceWriteToOffsetOptions, CancellationToken)"/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class StorageResourceCopyFromUriOptions
    {
        /// <summary>
        /// Optional. If a specific block id is wanted to send with the request when staging a block
        /// to the blob.
        ///
        /// Applies only to block blobs.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BlockId { get; internal set; }

        /// <summary>
        /// Optional.  Source authentication used to access the source blob.
        ///
        /// Only applies to copy operations, not local operations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HttpAuthorization SourceAuthentication { get; set; }

        /// <summary>
        /// Optional. Specifies the source properties to set in the destination.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageResourceItemProperties SourceProperties { get; set; }
    }
}
