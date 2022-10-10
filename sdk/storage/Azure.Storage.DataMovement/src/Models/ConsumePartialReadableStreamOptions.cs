// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Options for <see cref="StorageResource.ConsumePartialOffsetReadableStream(long, long, Stream, ConsumePartialReadableStreamOptions, CancellationToken)"/>
    /// </summary>
    public class ConsumePartialReadableStreamOptions
    {
        /// <summary>
        /// Optional. If a specific block id is wanted to send with the request when staging a block
        /// to the blob.
        ///
        /// Applies only to blobs.
        /// </summary>
        public string BlockId { get; internal set; }
    }
}
