// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlockBlobClient.StageBlockFromUriAsync(System.Uri, string, StageBlockFromUriOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class StageBlockFromUriOptions
    {
        /// <summary>
        /// Optionally uploads only the bytes of the blob in the
        /// sourceUri in the specified range.  If this is
        /// not specified, the entire source blob contents are uploaded as a
        /// single block.
        /// </summary>
        public HttpRange SourceRange { get; set; }

        /// <summary>
        /// Optional MD5 hash of the block content from the
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
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </summary>
        public RequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the staging of this block.
        /// </summary>
        public BlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional.  Source authentication used to access the source blob.
        /// </summary>
        public HttpAuthorization SourceAuthentication { get; set; }

        /// <summary>
        /// Optional, only applicable (but required) when the source is Azure Storage Files and using token authentication.
        /// Used to indicate the intent of the request.
        /// </summary>
        public FileShareTokenIntent? SourceShareTokenIntent { get; set; }

        /// <summary>
        /// Optional. Specifies the source customer provided key to use to encrypt the source blob.
        /// Applicable only for service version 2026-02-06 or later.
        /// </summary>
        public CustomerProvidedKey? SourceCustomerProvidedKey { get; set; }
    }
}
