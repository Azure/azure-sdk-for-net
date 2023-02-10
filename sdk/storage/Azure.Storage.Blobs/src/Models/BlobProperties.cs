// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Properties of a Blob.
    /// </summary>
    public partial class BlobProperties
    {
        /// <summary>
        /// Returns the date and time the blob was last modified. Any operation that modifies the blob,
        /// including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        public DateTimeOffset LastModified { get; }

        /// <summary>
        /// Returns the date and time the blob was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Object Replication Policy Id of the destination blob.
        /// </summary>
        public string ObjectReplicationDestinationPolicyId { get; }

        /// <summary>
        /// Parsed Object Replication Policy Id, Rule Id(s) and status of the source blob.
        /// </summary>
        public IList<ObjectReplicationPolicy> ObjectReplicationSourceProperties { get; }

        /// <summary>
        /// The blob's type.
        /// </summary>
        public BlobType BlobType { get; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob.
        /// This value can specify the time of a completed, aborted, or failed copy attempt. This header does
        /// not appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation,
        /// or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties,
        /// Put Blob, or Put Block List.
        /// </summary>
        public DateTimeOffset CopyCompletedOn { get; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or
        /// non-fatal copy operation failure. This header does not appear if this blob has never been the destination
        /// in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using
        /// Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription { get; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy
        /// operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId { get; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob
        /// operation where this blob was the destination blob. Can show between 0 and Content-Length bytes copied.
        /// This header does not appear if this blob has never been the destination in a Copy Blob operation, or
        /// if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put
        /// Blob, or Put Block List.
        /// </summary>
        public string CopyProgress { get; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob
        /// operation where this blob was the destination blob. This header does not appear if this blob has never
        /// been the destination in a Copy Blob operation, or if this blob has been modified after a concluded
        /// Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public Uri CopySource { get; }

        /// <summary>
        /// Legacy facade for <see cref="BlobCopyStatus"/>.
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CopyStatus CopyStatus => BlobCopyStatus ?? CopyStatus.Pending;

        /// <summary>
        /// State of the most recent copy operation identified by x-ms-copy-id, if any.
        /// </summary>
        public CopyStatus? BlobCopyStatus { get; }

        /// <summary>
        /// Included if the blob is incremental copy blob.
        /// </summary>
        public bool IsIncrementalCopy { get; }

        /// <summary>
        /// Included if the blob is incremental copy blob or incremental copy snapshot, if x-ms-copy-status is success.
        /// Snapshot time of the last successful incremental copy snapshot for this blob.
        /// </summary>
        public string DestinationSnapshot { get; }

        /// <summary>
        /// When a blob is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public LeaseDurationType LeaseDuration { get; }

        /// <summary>
        /// Lease state of the blob.
        /// </summary>
        public LeaseState LeaseState { get; }

        /// <summary>
        /// The current lease status of the blob.
        /// </summary>
        public LeaseStatus LeaseStatus { get; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; }

        /// <summary>
        /// The content type specified for the blob. The default content type is 'application/octet-stream'.
        /// </summary>
        public string ContentType { get; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is
        /// returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public string ContentEncoding { get; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header.
        /// The Content-Disposition response header field conveys additional information about how to process
        /// the response payload, and also can be used to attach additional metadata. For example, if set to
        /// attachment, it indicates that the user-agent should not display the response, but instead show a
        /// Save As dialog with a filename other than the blob name specified.
        /// </summary>
        public string ContentDisposition { get; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage { get; }

        /// <summary>
        /// This header is returned if it was previously specified for the blob.
        /// </summary>
        public string CacheControl { get; }

        /// <summary>
        /// The current sequence number for a page blob. This header is not returned for block blobs or append blobs.
        /// </summary>
        public long BlobSequenceNumber { get; }

        /// <summary>
        /// Indicates that the service supports requests for partial blob content.
        /// </summary>
        public string AcceptRanges { get; }

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        public int BlobCommittedBlockCount { get; }

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted
        /// using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if
        /// only parts of the blob/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the metadata. This header is only returned when the
        /// metadata was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; }

        /// <summary>
        /// Returns the name of the encryption scope used to encrypt the blob contents and application metadata.
        /// Note that the absence of this header implies use of the default account encryption scope.
        /// </summary>
        public string EncryptionScope { get; }

        /// <summary>
        /// The tier of page blob on a premium storage account or tier of block blob on blob storage LRS accounts.
        /// For a list of allowed premium page blob tiers, see
        /// <see href="https://docs.microsoft.com/azure/virtual-machines/windows/premium-storage#features" />. For general
        /// purpose v2 and blob storage account types, the valid values are:
        /// <list>
        ///  <item><description>Hot</description></item>
        ///  <item><description>Cool</description></item>
        ///  <item><description>Archive</description></item>
        /// </list>
        /// </summary>
        public string AccessTier { get; }

        /// <summary>
        /// For page blobs on a premium storage account only. If the access tier is not explicitly set on the blob,
        /// the tier is inferred based on its content length and this header will be returned with true value.
        /// </summary>
        public bool AccessTierInferred { get; }

        /// <summary>
        /// For blob storage LRS accounts, valid values are rehydrate-pending-to-hot/rehydrate-pending-to-cool.
        /// If the blob is being rehydrated and is not complete then this header is returned indicating that
        /// rehydrate is pending and also tells the destination tier.
        /// </summary>
        public string ArchiveStatus { get; }

        /// <summary>
        /// The time the tier was changed on the object. This is only returned if the tier on the block blob was ever set.
        /// </summary>
        public DateTimeOffset AccessTierChangedOn { get; }

        /// <summary>
        /// A DateTime value returned by the service that uniquely identifies the blob. The value of this header
        /// indicates the blob version, and may be used in subsequent requests to access this version of the blob.
        /// </summary>
        public string VersionId { get; }

        /// <summary>
        /// The value of this header indicates whether version of this blob is a current version, see also x-ms-version-id header.
        /// </summary>
        public bool IsLatestVersion { get; }

        /// <summary>
        /// The number of tags associated with the blob.
        /// </summary>
        public long TagCount { get; }

        /// <summary>
        /// The time this blob will expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; }

        /// <summary>
        /// If this blob has been sealed.
        /// </summary>
        public bool IsSealed { get; }

        /// <summary>
        /// If this blob is in rehydrate pending state, this indicates the rehydrate priority.
        /// </summary>
        public string RehydratePriority { get; }

        /// <summary>
        /// Returns the date and time the blob was read or written to.
        /// </summary>
        public DateTimeOffset LastAccessed { get; }

        /// <summary>
        /// The <see cref="BlobImmutabilityPolicy"/> associated with the blob.
        /// </summary>
        public BlobImmutabilityPolicy ImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// Indicates if the blob has a legal hold.
        /// </summary>
        public bool HasLegalHold { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BlobProperties()
        {
            Metadata = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            ObjectReplicationSourceProperties = new List<ObjectReplicationPolicy>();
        }

        /// <summary>
        /// Internal Constructor.
        /// </summary>
        internal BlobProperties(
            DateTimeOffset lastModified,
            DateTimeOffset createdOn,
            IDictionary<string, string> metadata,
            string objectReplicationDestinationPolicyId,
            IList<ObjectReplicationPolicy> objectReplicationSourceProperties,
            BlobType blobType,
            DateTimeOffset copyCompletedOn,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus? blobCopyStatus,
            bool isIncrementalCopy,
            string destinationSnapshot,
            LeaseDurationType leaseDuration,
            LeaseState leaseState,
            LeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            long blobSequenceNumber,
            string acceptRanges,
            int blobCommittedBlockCount,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string encryptionScope,
            string accessTier,
            bool accessTierInferred,
            string archiveStatus,
            DateTimeOffset accessTierChangedOn,
            string versionId,
            bool isLatestVersion,
            long tagCount,
            DateTimeOffset expiresOn,
            bool isSealed,
            string rehydratePriority,
            DateTimeOffset lastAccessed,
            BlobImmutabilityPolicy immutabilityPolicy,
            bool hasLegalHold)
        {
            LastModified = lastModified;
            LeaseStatus = leaseStatus;
            ContentLength = contentLength;
            ContentType = contentType;
            ETag = eTag;
            LeaseState = leaseState;
            ContentEncoding = contentEncoding;
            ContentDisposition = contentDisposition;
            ContentLanguage = contentLanguage;
            CacheControl = cacheControl;
            BlobSequenceNumber = blobSequenceNumber;
            LeaseDuration = leaseDuration;
            AcceptRanges = acceptRanges;
            DestinationSnapshot = destinationSnapshot;
            BlobCommittedBlockCount = blobCommittedBlockCount;
            IsIncrementalCopy = isIncrementalCopy;
            IsServerEncrypted = isServerEncrypted;
            BlobCopyStatus = blobCopyStatus;
            EncryptionKeySha256 = encryptionKeySha256;
            CopySource = copySource;
            EncryptionScope = encryptionScope;
            CopyProgress = copyProgress;
            AccessTier = accessTier;
            CopyId = copyId;
            AccessTierInferred = accessTierInferred;
            CopyStatusDescription = copyStatusDescription;
            ArchiveStatus = archiveStatus;
            CopyCompletedOn = copyCompletedOn;
            AccessTierChangedOn = accessTierChangedOn;
            BlobType = blobType;
            VersionId = versionId;
            ObjectReplicationSourceProperties = objectReplicationSourceProperties;
            IsLatestVersion = isLatestVersion;
            ObjectReplicationDestinationPolicyId = objectReplicationDestinationPolicyId;
            TagCount = tagCount;
            Metadata = metadata;
            ExpiresOn = expiresOn;
            CreatedOn = createdOn;
            IsSealed = isSealed;
            RehydratePriority = rehydratePriority;
            ContentHash = contentHash;
            LastAccessed = lastAccessed;
            ImmutabilityPolicy = immutabilityPolicy;
            HasLegalHold = hasLegalHold;
        }
    }
}
