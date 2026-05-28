// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Storage.Blobs.Specialized;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlockBlobClient.SyncUploadFromUri(Uri, bool, CancellationToken)"/>.
    /// </summary>
    public class BlobSyncUploadFromUriOptions
    {
        /// <summary>
        /// The copy source blob properties behavior.  If true, the properties
        /// of the source blob will be copied to the new blob.  Default is true.
        /// </summary>
        public bool? CopySourceBlobProperties { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this append blob.
        /// </summary>
        public Metadata Metadata { get; set; }

        /// <summary>
        /// Options tags to set for this block blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copyig of data to this Block Blob.
        /// </summary>
        public BlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </summary>
        public BlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on the
        /// Block Blob.
        /// </summary>
        public AccessTier? AccessTier { get; set; }

        /// <summary>
        /// Optional. An MD5 hash of the content. This hash is used to verify the integrity of the content during
        /// transport. When this header is specified, the storage service compares the hash of the content that has arrived
        /// with this header value. Note that this MD5 hash is not stored with the blob.If the two hashes do not match, the
        /// operation will fail.
        /// </summary>
        public byte[] ContentHash { get; set; }

        /// <summary>
        /// Optional.  Source authentication used to access the source blob.
        /// </summary>
        public HttpAuthorization SourceAuthentication { get; set; }

        /// <summary>
        /// Optional.  Indicates if the source blob's tags should be copied to the destination blob,
        /// or replaced on the destination blob with the tags specified by <see cref="Tags"/>.
        /// Default is to replace.
        /// </summary>
        public BlobCopySourceTagsMode? CopySourceTagsMode { get; set; }

        /// <summary>
        /// Optional, only applicable (but required) when the source is Azure Storage Files and using token authentication.
        /// Used to indicate the intent of the request.
        /// </summary>
        public FileShareTokenIntent? SourceShareTokenIntent { get; set; }
    }
}
