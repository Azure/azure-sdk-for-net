// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The result of a GetLayout operation, containing the blob's layout
    /// information along with properties from the response headers.
    /// </summary>
    public class BlobLayoutInfo
    {
        internal BlobLayoutInfo() { }

        /// <summary>
        /// The blob layout ranges.
        /// </summary>
        public BlobLayoutRanges Ranges { get; internal set; }

        /// <summary>
        /// The blob layout endpoints.
        /// </summary>
        public BlobLayoutEndpoints Endpoints { get; internal set; }

        /// <summary>
        /// The continuation marker used for this request.
        /// </summary>
        public string Marker { get; internal set; }

        /// <summary>
        /// If the number of ranges exceeds MaxResults, a NextMarker is returned
        /// for use in subsequent requests to continue listing.
        /// </summary>
        public string NextMarker { get; internal set; }

        /// <summary>
        /// The maximum number of ranges returned per request.
        /// </summary>
        public int? MaxResults { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was last modified. Any operation that modifies the blob,
        /// including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; internal set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Object Replication Policy Id of the destination blob.
        /// </summary>
        public string ObjectReplicationDestinationPolicyId { get; internal set; }

        /// <summary>
        /// Parsed Object Replication Policy Id, Rule Id(s) and status of the source blob.
        /// </summary>
        public IList<ObjectReplicationPolicy> ObjectReplicationSourceProperties { get; internal set; }

        /// <summary>
        /// The blob's type.
        /// </summary>
        public BlobType BlobType { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob.
        /// </summary>
        public DateTimeOffset CopyCompletedOn { get; internal set; }

        /// <summary>
        /// Describes the cause of the last fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation.
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob operation.
        /// </summary>
        public Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus? BlobCopyStatus { get; internal set; }

        /// <summary>
        /// Included if the blob is incremental copy blob.
        /// </summary>
        public bool IsIncrementalCopy { get; internal set; }

        /// <summary>
        /// Included if the blob is incremental copy blob or incremental copy snapshot,
        /// if x-ms-copy-status is success. Snapshot time of the last successful incremental copy snapshot for this blob.
        /// </summary>
        public string DestinationSnapshot { get; internal set; }

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public LeaseDurationType LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public LeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public LeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the blob. The default content type is 'application/octet-stream'.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is
        /// returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// This header is returned if it was previously specified for the blob.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs.
        /// </summary>
        public long BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted
        /// using the specified algorithm. Otherwise, the value is set to false.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the metadata. This header is only returned when the
        /// metadata was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// Returns the name of the encryption scope used to encrypt the blob contents and application metadata.
        /// Note that the absence of this header implies use of the default account encryption scope.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// The tier of page blob on a premium storage account or tier of block blob on blob storage LRS accounts.
        /// </summary>
        public string AccessTier { get; internal set; }

        /// <summary>
        /// For page blobs on a premium storage account only. If the access tier is not explicitly set on the blob,
        /// the tier is inferred based on its content length and this header will be returned with true value.
        /// </summary>
        public bool AccessTierInferred { get; internal set; }

        /// <summary>
        /// The underlying tier of a smart tier blob. Only returned if the blob is in Smart tier.
        /// </summary>
        public string SmartAccessTier { get; internal set; }

        /// <summary>
        /// For blob storage LRS accounts, valid values are rehydrate-pending-to-hot/rehydrate-pending-to-cool.
        /// If the blob is being rehydrated and is not complete then this header is returned indicating that
        /// rehydrate is pending and also tells the destination tier.
        /// </summary>
        public string ArchiveStatus { get; internal set; }

        /// <summary>
        /// The time the tier was changed on the object. This is only returned if the tier on the block blob was ever set.
        /// </summary>
        public DateTimeOffset AccessTierChangedOn { get; internal set; }

        /// <summary>
        /// A DateTime value returned by the service that uniquely identifies the blob. The value of this header
        /// indicates the blob version, and may be used in subsequent requests to access this version of the blob.
        /// </summary>
        public string VersionId { get; internal set; }

        /// <summary>
        /// The value of this header indicates whether version of this blob is a current version.
        /// </summary>
        public bool IsLatestVersion { get; internal set; }

        /// <summary>
        /// The number of tags associated with the blob.
        /// </summary>
        public long TagCount { get; internal set; }

        /// <summary>
        /// The time this blob will expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; internal set; }

        /// <summary>
        /// If this blob has been sealed.
        /// </summary>
        public bool IsSealed { get; internal set; }

        /// <summary>
        /// If this blob is in rehydrate pending state, this indicates the rehydrate priority.
        /// </summary>
        public string RehydratePriority { get; internal set; }

        /// <summary>
        /// Returns the date and time the blob was read or written to.
        /// </summary>
        public DateTimeOffset LastAccessed { get; internal set; }

        /// <summary>
        /// The <see cref="BlobImmutabilityPolicy"/> associated with the blob.
        /// </summary>
        public BlobImmutabilityPolicy ImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// Indicates if the blob has a legal hold.
        /// </summary>
        public bool HasLegalHold { get; internal set; }

        /// <summary>
        /// The content length of the blob.
        /// </summary>
        public long BlobContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the blob.
        /// </summary>
        public string BlobContentType { get; internal set; }

        /// <summary>
        /// The content encoding specified for the blob.
        /// </summary>
        public string BlobContentEncoding { get; internal set; }

        /// <summary>
        /// The content MD5 of the blob.
        /// </summary>
        public byte[] BlobContentMD5 { get; internal set; }

        /// <summary>
        /// The creation time of the blob.
        /// </summary>
        public DateTimeOffset BlobCreatedOn { get; internal set; }
    }
}
