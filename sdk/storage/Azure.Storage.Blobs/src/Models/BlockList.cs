// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// A block blob's <see cref="BlockList"/> returned from
    /// <see cref="BlockBlobClient.GetBlockListAsync"/>.
    /// </summary>
    public partial class BlockList
    {
        /// <summary>
        /// Gets the date and time the container was last modified.  Any
        /// operation that modifies the blob, including an update of the
        /// blob's metadata or properties, changes the last-modified time of
        /// the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The <see cref="Azure.ETag"/> contains a value that you can use to
        /// perform operations conditionally. If the request version is
        /// 2011-08-18 or newer, the  ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The media type of the body of the response. For the
        /// <see cref=" Specialized.BlockBlobClient.GetBlockListAsync"/>
        /// operation this is 'application/xml'.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The size of the blob, in bytes.
        /// </summary>
        public long BlobContentLength { get; internal set; }

        /// <summary>
        /// CommittedBlocks.
        /// </summary>
        public IEnumerable<BlobBlock> CommittedBlocks { get; internal set; }

        /// <summary>
        /// UncommittedBlocks.
        /// </summary>
        public IEnumerable<BlobBlock> UncommittedBlocks { get; internal set; }
    }
}
