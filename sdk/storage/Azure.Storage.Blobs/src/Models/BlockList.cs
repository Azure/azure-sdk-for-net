// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// A block blob's <see cref="BlockList"/> returned from 
    /// <see cref="Azure.Storage.Blobs.BlockBlobClient.GetBlockListAsync"/>.
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
        /// The <see cref="ETag"/> contains a value that you can use to
        /// perform operations conditionally. If the request version is 
        /// 2011-08-18 or newer, the  ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// The media type of the body of the response. For the
        /// <see cref=" Azure.Storage.Blobs.BlockBlobClient.GetBlockListAsync"/> 
        /// operation this is 'application/xml'.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The size of the blob, in bytes.
        /// </summary>
        public long BlobContentLength { get; internal set; }
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// BlobRestClient response extensions
    /// </summary>
    static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the internal GetBlockListOperation response into a BlockList.
        /// </summary>
        /// <param name="response">The original response.</param>
        /// <returns>The BlockList response.</returns>
        internal static Response<BlockList> ToBlockList(this Response<GetBlockListOperation> response)
        {
            var blocks = response.Value.Body;
            blocks.LastModified = response.Value.LastModified;
            blocks.ETag = response.Value.ETag;
            blocks.ContentType = response.Value.ContentType;
            blocks.BlobContentLength = response.Value.BlobContentLength;
            return new Response<BlockList>(response.GetRawResponse(), blocks);
        }
    }
}
