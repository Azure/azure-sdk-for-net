// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for
    /// <see cref="AppendBlobClient.AppendBlockFromUriAsync(System.Uri, AppendBlobAppendBlockFromUriOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class AppendBlobAppendBlockFromUriOptions
    {
        /// <summary>
        /// Optionally only upload the bytes of the blob in the
        /// sourceUri in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single append block.
        /// </summary>
        public HttpRange SourceRange { get; set; }

        /// <summary>
        /// Optional MD5 hash of the append block content from the
        /// sourceUri.  This hash is used to verify the
        /// integrity of the block during transport of the data from the Uri.
        /// When this hash is specified, the storage service compares the hash
        /// of the content that has arrived from the sourceUri
        /// with this value.  Note that this md5 hash is not stored with the
        /// blob.  If the two hashes do not match, the operation will fail
        /// with a <see cref="RequestFailedException"/>.
        /// </summary>
        public byte[] SourceContentHash { get; set; }

        /// <summary>
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data to this append blob.
        /// </summary>
        public AppendBlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </summary>
        public AppendBlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional.  Source authentication used to access the source blob.
        /// </summary>
        public HttpAuthorization SourceAuthentication { get; set; }

        /// <summary>
        /// Optional, only applicable (but required) when the source is Azure Storage Files and using token authentication.
        /// Used to indicate the intent of the request.
        /// </summary>
        public FileShareTokenIntent? SourceShareTokenIntent { get; set; }
    }
}
