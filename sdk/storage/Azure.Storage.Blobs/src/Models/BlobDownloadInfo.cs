// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The details and Content returned from downloading a blob
    /// </summary>
    public class BlobDownloadInfo : IDisposable, IDownloadedContent
    {
        /// <summary>
        /// The blob's type.
        /// </summary>
        public BlobType BlobType { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content { get; internal set; }

        /// <summary>
        /// The media type of the body of the response. For Download Blob this is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Details returned when downloading a Blob
        /// </summary>
        public BlobDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal BlobDownloadInfo() { }

        ///// <summary>
        ///// Creates a new DownloadInfo backed by FlattenedDownloadProperties
        ///// </summary>
        ///// <param name="flattened">The FlattenedDownloadProperties returned with the request</param>
        //internal BlobDownloadInfo(FlattenedDownloadProperties flattened)
        //{
        //    _flattened = flattened;
        //    Details = new BlobDownloadDetails() {
        //        LastModified = flattened.LastModified,
        //        Metadata = flattened.Metadata,
        //        ContentRange = flattened.ContentRange,
        //        ETag = flattened.ETag,
        //        ContentEncoding = flattened.ContentEncoding,
        //        CacheControl = flattened.CacheControl,
        //        ContentDisposition = flattened.ContentDisposition,
        //        ContentLanguage = flattened.ContentLanguage,
        //        BlobSequenceNumber = flattened.BlobSequenceNumber,
        //        CopyCompletedOn = flattened.CopyCompletionTime,
        //        CopyStatusDescription = flattened.CopyStatusDescription,
        //        CopyId = flattened.CopyId,
        //        CopyProgress = flattened.CopyProgress,
        //        CopySource = flattened.CopySource,
        //        CopyStatus = flattened.CopyStatus,
        //        LeaseDuration = flattened.LeaseDuration,
        //        LeaseState = flattened.LeaseState,
        //        LeaseStatus = flattened.LeaseStatus,
        //        AcceptRanges = flattened.AcceptRanges,
        //        BlobCommittedBlockCount = flattened.BlobCommittedBlockCount,
        //        IsServerEncrypted = flattened.IsServerEncrypted,
        //        EncryptionKeySha256 = flattened.EncryptionKeySha256,
        //        EncryptionScope = flattened.EncryptionScope,
        //        BlobContentHash = flattened.BlobContentHash,
        //        TagCount = flattened.TagCount,
        //        VersionId = flattened.VersionId,
        //        IsSealed = flattened.IsSealed,
        //        ObjectReplicationSourceProperties =
        //            flattened.ObjectReplicationRules?.Count > 0
        //            ? BlobExtensions.ParseObjectReplicationIds(flattened.ObjectReplicationRules)
        //            : null,
        //        ObjectReplicationDestinationPolicyId = flattened.ObjectReplicationPolicyId,
        //        LastAccessed = flattened.LastAccessed
        //    };
        //}

        /// <summary>
        /// Disposes the BlobDownloadInfo by calling Dispose on the underlying Content stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
