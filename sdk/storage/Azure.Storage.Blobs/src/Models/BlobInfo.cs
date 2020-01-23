// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Storage.Blobs.Models;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// BlobInfo
    /// </summary>
    public partial class BlobInfo
    {
        /// <summary>
        /// The current sequence number for a page blob. This header is not
        /// returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }
    }

    /// <summary>
    /// The details and Content returned from downloading a blob
    /// </summary>
    public partial class BlobDownloadInfo : IDisposable
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedDownloadProperties _flattened;

        /// <summary>
        /// The blob's type.
        /// </summary>
        public BlobType BlobType => _flattened.BlobType;

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength => _flattened.ContentLength;

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content => _flattened.Content;

        /// <summary>
        /// The media type of the body of the response. For Download Blob this is 'application/octet-stream'
        /// </summary>
        public string ContentType => _flattened.ContentType;

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash => _flattened.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Details returned when downloading a Blob
        /// </summary>
        public BlobDownloadDetails Details { get; private set; }

        /// <summary>
        /// Creates a new DownloadInfo backed by FlattenedDownloadProperties
        /// </summary>
        /// <param name="flattened">The FlattenedDownloadProperties returned with the request</param>
        internal BlobDownloadInfo(FlattenedDownloadProperties flattened)
        {
            _flattened = flattened;
            Details = new BlobDownloadDetails() { _flattened = flattened };
        }

        /// <summary>
        /// Disposes the BlobDownloadInfo by calling Dispose on the underlying Content stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Details returned when downloading a Blob
    /// </summary>
    public partial class BlobDownloadDetails
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedDownloadProperties _flattened;

        /// <summary>
        /// Returns the date and time the container was last modified. Any operation that modifies the blob, including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified => _flattened.LastModified;

        /// <summary>
        /// x-ms-meta
        /// </summary>
        public IDictionary<string, string> Metadata => _flattened.Metadata;

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the blob by setting the 'Range' request header.
        /// </summary>
        public string ContentRange => _flattened.ContentRange;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally. If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag => _flattened.ETag;

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header
        /// </summary>
        public string ContentEncoding => _flattened.ContentEncoding;

        /// <summary>
        /// This header is returned if it was previously specified for the blob.
        /// </summary>
        public string CacheControl => _flattened.CacheControl;

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header. The Content-Disposition response header field conveys additional information about how to process the response payload, and also can be used to attach additional metadata. For example, if set to attachment, it indicates that the user-agent should not display the response, but instead show a Save As dialog with a filename other than the blob name specified.
        /// </summary>
        public string ContentDisposition => _flattened.ContentDisposition;

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage => _flattened.ContentLanguage;

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs
        /// </summary>
        public long BlobSequenceNumber => _flattened.BlobSequenceNumber;

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob. This value can specify the time of a completed, aborted, or failed copy attempt. This header does not appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public DateTimeOffset CopyCompletedOn => _flattened.CopyCompletionTime;

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or non-fatal copy operation failure. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription => _flattened.CopyStatusDescription;

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId => _flattened.CopyId;

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation where this blob was the destination blob. Can show between 0 and Content-Length bytes copied. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyProgress => _flattened.CopyProgress;

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob operation where this blob was the destination blob. This header does not appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public Uri CopySource => _flattened.CopySource;

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus CopyStatus => _flattened.CopyStatus;

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public LeaseDurationType LeaseDuration => _flattened.LeaseDuration;

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public LeaseState LeaseState => _flattened.LeaseState;

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public LeaseStatus LeaseStatus => _flattened.LeaseStatus;

        /// <summary>
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges => _flattened.AcceptRanges;

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount => _flattened.BlobCommittedBlockCount;

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if only parts of the blob/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted => _flattened.IsServerEncrypted;

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the blob. This header is only returned when the blob was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 => _flattened.EncryptionKeySha256;

        /// <summary>
        /// If the blob has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole blob's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] BlobContentHash => _flattened.BlobContentHash;
#pragma warning restore CA1819 // Properties should not return arrays
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobDownloadInfo instance for mocking.
        /// </summary>
        public static BlobDownloadInfo BlobDownloadInfo(
            System.DateTimeOffset lastModified = default,
            long blobSequenceNumber = default,
            Azure.Storage.Blobs.Models.BlobType blobType = default,
            byte[] contentCrc64 = default,
            string contentLanguage = default,
            string copyStatusDescription = default,
            string copyId = default,
            string copyProgress = default,
            System.Uri copySource = default,
            Azure.Storage.Blobs.Models.CopyStatus copyStatus = default,
            string contentDisposition = default,
            Azure.Storage.Blobs.Models.LeaseDurationType leaseDuration = default,
            string cacheControl = default,
            Azure.Storage.Blobs.Models.LeaseState leaseState = default,
            string contentEncoding = default,
            Azure.Storage.Blobs.Models.LeaseStatus leaseStatus = default,
            byte[] contentHash = default,
            string acceptRanges = default,
            ETag eTag = default,
            int blobCommittedBlockCount = default,
            string contentRange = default,
            bool isServerEncrypted = default,
            string contentType = default,
            string encryptionKeySha256 = default,
            long contentLength = default,
            byte[] blobContentHash = default,
            System.Collections.Generic.IDictionary<string, string> metadata = default,
            System.IO.Stream content = default,
            System.DateTimeOffset copyCompletionTime = default)
        {
            return new BlobDownloadInfo(
                new FlattenedDownloadProperties()
                {
                    LastModified = lastModified,
                    BlobSequenceNumber = blobSequenceNumber,
                    BlobType = blobType,
                    ContentCrc64 = contentCrc64,
                    ContentLanguage = contentLanguage,
                    CopyStatusDescription = copyStatusDescription,
                    CopyId = copyId,
                    CopyProgress = copyProgress,
                    CopySource = copySource,
                    CopyStatus = copyStatus,
                    ContentDisposition = contentDisposition,
                    LeaseDuration = leaseDuration,
                    CacheControl = cacheControl,
                    LeaseState = leaseState,
                    ContentEncoding = contentEncoding,
                    LeaseStatus = leaseStatus,
                    ContentHash = contentHash,
                    AcceptRanges = acceptRanges,
                    ETag = eTag,
                    BlobCommittedBlockCount = blobCommittedBlockCount,
                    ContentRange = contentRange,
                    IsServerEncrypted = isServerEncrypted,
                    ContentType = contentType,
                    EncryptionKeySha256 = encryptionKeySha256,
                    ContentLength = contentLength,
                    BlobContentHash = blobContentHash,
                    Metadata = metadata,
                    Content = content,
                    CopyCompletionTime = copyCompletionTime
                }
            );
        }
    }
}
