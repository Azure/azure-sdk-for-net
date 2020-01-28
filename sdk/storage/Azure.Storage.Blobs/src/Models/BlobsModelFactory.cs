// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// This class holds BlobModelFactory overloads we need for backwards compatibility.
    /// </summary>
    public partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobAppendInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobAppendInfo BlobAppendInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            byte[] contentCrc64,
            string blobAppendOffset,
            int blobCommittedBlockCount,
            bool isServerEncrypted,
            string encryptionKeySha256)
            => new BlobAppendInfo()
                {
                    ETag = eTag,
                    LastModified = lastModified,
                    ContentHash = contentHash,
                    ContentCrc64 = contentCrc64,
                    BlobAppendOffset = blobAppendOffset,
                    BlobCommittedBlockCount = blobCommittedBlockCount,
                    IsServerEncrypted = isServerEncrypted,
                    EncryptionKeySha256 = encryptionKeySha256
                };

        /// <summary>
        /// Creates a new BlobContentInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobContentInfo BlobContentInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            string encryptionKeySha256,
            long blobSequenceNumber)
                => new BlobContentInfo()
                {
                    ETag = eTag,
                    LastModified = lastModified,
                    ContentHash = contentHash,
                    EncryptionKeySha256 = encryptionKeySha256,
                    BlobSequenceNumber = blobSequenceNumber,
                };

        /// <summary>
        /// Creates a new BlobItemProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobItemProperties BlobItemProperties(
            bool accessTierInferred,
            Uri copySource,
            string contentType,
            string contentEncoding,
            string contentLanguage,
            byte[] contentHash,
            string contentDisposition,
            string cacheControl ,
            long? blobSequenceNumber ,
            BlobType? blobType,
            LeaseStatus? leaseStatus,
            LeaseState? leaseState,
            LeaseDurationType? leaseDuration,
            string copyId,
            CopyStatus? copyStatus,
            long? contentLength,
            string copyProgress,
            string copyStatusDescription,
            bool? serverEncrypted,
            bool? incrementalCopy,
            string destinationSnapshot,
            int? remainingRetentionDays,
            AccessTier? accessTier,
            DateTimeOffset? lastModified,
            ArchiveStatus? archiveStatus,
            string customerProvidedKeySha256,
            ETag? eTag,
            DateTimeOffset? createdOn,
            DateTimeOffset? copyCompletedOn,
            DateTimeOffset? deletedOn,
            DateTimeOffset? accessTierChangedOn)
                => new BlobItemProperties()
                {
                    AccessTierInferred = accessTierInferred,
                    CopyProgress = copyProgress,
                    ContentType = contentType,
                    ContentEncoding = contentEncoding,
                    ContentLanguage = contentLanguage,
                    ContentHash = contentHash,
                    ContentDisposition = contentDisposition,
                    CacheControl = cacheControl,
                    BlobSequenceNumber = blobSequenceNumber,
                    BlobType = blobType,
                    LeaseStatus = leaseStatus,
                    LeaseState = leaseState,
                    LeaseDuration = leaseDuration,
                    CopyId = copyId,
                    CopyStatus = copyStatus,
                    CopySource = copySource,
                    ContentLength = contentLength,
                    CopyStatusDescription = copyStatusDescription,
                    ServerEncrypted = serverEncrypted,
                    IncrementalCopy = incrementalCopy,
                    DestinationSnapshot = destinationSnapshot,
                    RemainingRetentionDays = remainingRetentionDays,
                    AccessTier = accessTier,
                    LastModified = lastModified,
                    ArchiveStatus = archiveStatus,
                    CustomerProvidedKeySha256 = customerProvidedKeySha256,
                    ETag = eTag,
                    CreatedOn = createdOn,
                    CopyCompletedOn = copyCompletedOn,
                    DeletedOn = deletedOn,
                    AccessTierChangedOn = accessTierChangedOn,
                };

        /// <summary>
        /// Creates a new BlobProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobProperties BlobProperties(
            DateTimeOffset lastModified,
            LeaseDurationType leaseDuration,
            LeaseState leaseState,
            LeaseStatus leaseStatus,
            long contentLength,
            string destinationSnapshot,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            bool isIncrementalCopy,
            string cacheControl,
            CopyStatus copyStatus,
            long blobSequenceNumber,
            Uri copySource,
            string acceptRanges,
            string copyProgress,
            int blobCommittedBlockCount,
            string copyId,
            bool isServerEncrypted,
            string copyStatusDescription,
            string encryptionKeySha256,
            DateTimeOffset copyCompletedOn,
            string accessTier,
            BlobType blobType,
            bool accessTierInferred,
            IDictionary<string, string> metadata,
            string archiveStatus,
            DateTimeOffset createdOn,
            DateTimeOffset accessTierChangedOn,
            string contentType)
                => new BlobProperties()
                {
                    LastModified = lastModified,
                    LeaseState = leaseState,
                    LeaseStatus = leaseStatus,
                    ContentLength = contentLength,
                    LeaseDuration = leaseDuration,
                    ETag = eTag,
                    ContentHash = contentHash,
                    ContentEncoding = contentEncoding,
                    ContentDisposition = contentDisposition,
                    ContentLanguage = contentLanguage,
                    DestinationSnapshot = destinationSnapshot,
                    CacheControl = cacheControl,
                    IsIncrementalCopy = isIncrementalCopy,
                    BlobSequenceNumber = blobSequenceNumber,
                    CopyStatus = copyStatus,
                    AcceptRanges = acceptRanges,
                    CopySource = copySource,
                    BlobCommittedBlockCount = blobCommittedBlockCount,
                    CopyProgress = copyProgress,
                    IsServerEncrypted = isServerEncrypted,
                    CopyId = copyId,
                    EncryptionKeySha256 = encryptionKeySha256,
                    CopyStatusDescription = copyStatusDescription,
                    CopyCompletedOn = copyCompletedOn,
                    AccessTier = accessTier,
                    BlobType = blobType,
                    AccessTierInferred = accessTierInferred,
                    Metadata = metadata,
                    ArchiveStatus = archiveStatus,
                    CreatedOn = createdOn,
                    AccessTierChangedOn = accessTierChangedOn,
                    ContentType = contentType,
                };

        /// <summary>
        /// Creates a new BlockInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlockInfo BlockInfo(
            byte[] contentHash,
            byte[] contentCrc64,
            string encryptionKeySha256)
                => new BlockInfo()
                {
                    ContentHash = contentHash,
                    ContentCrc64 = contentCrc64,
                    EncryptionKeySha256 = encryptionKeySha256,
                };

        /// <summary>
        /// Creates a new PageInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PageInfo PageInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            byte[] contentHash,
            byte[] contentCrc64,
            long blobSequenceNumber,
            string encryptionKeySha256)
                => new PageInfo()
                {
                    ETag = eTag,
                    LastModified = lastModified,
                    ContentHash = contentHash,
                    ContentCrc64 = contentCrc64,
                    BlobSequenceNumber = blobSequenceNumber,
                    EncryptionKeySha256 = encryptionKeySha256,
                };

        /// <summary>
        /// Creates a new BlobContainerProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobContainerProperties BlobContainerProperties(
            DateTimeOffset lastModified,
            ETag eTag,
            LeaseStatus? leaseStatus,
            LeaseState? leaseState,
            LeaseDurationType? leaseDuration,
            PublicAccessType? publicAccess,
            bool? hasImmutabilityPolicy,
            bool? hasLegalHold,
            IDictionary<string, string> metadata)
                => new BlobContainerProperties()
                {
                    LastModified = lastModified,
                    ETag = eTag,
                    LeaseState = leaseState,
                    LeaseDuration = leaseDuration,
                    PublicAccess = publicAccess,
                    LeaseStatus = leaseStatus,
                    HasLegalHold = hasLegalHold,
                    Metadata = metadata,
                    HasImmutabilityPolicy = hasImmutabilityPolicy,
                };
    }
}
