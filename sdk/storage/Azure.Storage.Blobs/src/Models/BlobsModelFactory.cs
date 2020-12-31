// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tags = System.Collections.Generic.IDictionary<string, string>;

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
            ETag eTag,
            DateTimeOffset lastModified,
            byte[] contentHash,
            string encryptionKeySha256,
            string encryptionScope,
            long blobSequenceNumber)
            => new BlobContentInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                ContentHash = contentHash,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionScope = encryptionScope,
                BlobSequenceNumber = blobSequenceNumber,
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
        /// Creates a new BlobProperties instance for mocking.
        /// </summary>
        public static BlobProperties BlobProperties(
            DateTimeOffset lastModified = default,
            LeaseStatus leaseStatus = default,
            long contentLength = default,
            string contentType = default,
            ETag eTag = default,
            LeaseState leaseState = default,
            string contentEncoding = default,
            string contentDisposition = default,
            string contentLanguage = default,
            string cacheControl = default,
            long blobSequenceNumber = default,
            LeaseDurationType leaseDuration = default,
            string acceptRanges = default,
            string destinationSnapshot = default,
            int blobCommittedBlockCount = default,
            bool isIncrementalCopy = default,
            bool isServerEncrypted = default,
            CopyStatus copyStatus = default,
            string encryptionKeySha256 = default,
            Uri copySource = default,
            string encryptionScope = default,
            string copyProgress = default,
            string accessTier = default,
            string copyId = default,
            bool accessTierInferred = default,
            string copyStatusDescription = default,
            string archiveStatus = default,
            DateTimeOffset copyCompletedOn = default,
            DateTimeOffset accessTierChangedOn = default,
            BlobType blobType = default,
            string versionId = default,
            IList<ObjectReplicationPolicy> objectReplicationSourceProperties = default,
            bool isLatestVersion = default,
            string objectReplicationDestinationPolicyId = default,
            long tagCount = default,
            IDictionary<string, string> metadata = default,
            DateTimeOffset expiresOn = default,
            DateTimeOffset createdOn = default,
            bool isSealed = default,
            string rehydratePriority = default,
            byte[] contentHash = default,
            DateTimeOffset lastAccessed = default)
        {
            return new BlobProperties()
            {
                LastModified = lastModified,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                LeaseState = leaseState,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                BlobSequenceNumber = blobSequenceNumber,
                LeaseDuration = leaseDuration,
                AcceptRanges = acceptRanges,
                DestinationSnapshot = destinationSnapshot,
                BlobCommittedBlockCount = blobCommittedBlockCount,
                IsIncrementalCopy = isIncrementalCopy,
                IsServerEncrypted = isServerEncrypted,
                CopyStatus = copyStatus,
                EncryptionKeySha256 = encryptionKeySha256,
                CopySource = copySource,
                EncryptionScope = encryptionScope,
                CopyProgress = copyProgress,
                AccessTier = accessTier,
                CopyId = copyId,
                AccessTierInferred = accessTierInferred,
                CopyStatusDescription = copyStatusDescription,
                ArchiveStatus = archiveStatus,
                CopyCompletedOn = copyCompletedOn,
                AccessTierChangedOn = accessTierChangedOn,
                BlobType = blobType,
                VersionId = versionId,
                ObjectReplicationSourceProperties = objectReplicationSourceProperties,
                IsLatestVersion = isLatestVersion,
                ObjectReplicationDestinationPolicyId = objectReplicationDestinationPolicyId,
                TagCount = tagCount,
                Metadata = metadata,
                ExpiresOn = expiresOn,
                CreatedOn = createdOn,
                IsSealed = isSealed,
                RehydratePriority = rehydratePriority,
                ContentHash = contentHash,
                LastAccessed = lastAccessed
            };
        }

        /// <summary>
        /// Creates a new BlobItemProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobItemProperties BlobItemProperties(
            bool accessTierInferred,
            bool? serverEncrypted,
            string contentType,
            string contentEncoding,
            string contentLanguage,
            byte[] contentHash,
            string contentDisposition,
            string cacheControl,
            long? blobSequenceNumber,
            BlobType? blobType,
            LeaseStatus? leaseStatus,
            LeaseState? leaseState,
            LeaseDurationType? leaseDuration,
            string copyId,
            CopyStatus? copyStatus,
            Uri copySource,
            string copyProgress,
            string copyStatusDescription,
            long? contentLength,
            bool? incrementalCopy,
            string destinationSnapshot,
            int? remainingRetentionDays,
            AccessTier? accessTier,
            DateTimeOffset? lastModified,
            ArchiveStatus? archiveStatus,
            string customerProvidedKeySha256,
            string encryptionScope,
            long? tagCount,
            DateTimeOffset? expiresOn,
            bool? isSealed,
            RehydratePriority? rehydratePriority,
            ETag? eTag,
            DateTimeOffset? createdOn,
            DateTimeOffset? copyCompletedOn,
            DateTimeOffset? deletedOn,
            DateTimeOffset? accessTierChangedOn)
            => new BlobItemProperties()
            {
                AccessTierInferred = accessTierInferred,
                ServerEncrypted = serverEncrypted,
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
                CopyProgress = copyProgress,
                CopyStatusDescription = copyStatusDescription,
                ContentLength = contentLength,
                IncrementalCopy = incrementalCopy,
                DestinationSnapshot = destinationSnapshot,
                RemainingRetentionDays = remainingRetentionDays,
                AccessTier = accessTier,
                LastModified = lastModified,
                ArchiveStatus = archiveStatus,
                CustomerProvidedKeySha256 = customerProvidedKeySha256,
                EncryptionScope = encryptionScope,
                TagCount = tagCount,
                ExpiresOn = expiresOn,
                IsSealed = isSealed,
                RehydratePriority = rehydratePriority,
                ETag = eTag,
                CreatedOn = createdOn,
                CopyCompletedOn = copyCompletedOn,
                DeletedOn = deletedOn,
                AccessTierChangedOn = accessTierChangedOn,
            };

        /// <summary>
        /// Creates a new BlobItemProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobItemProperties BlobItemProperties(
            bool accessTierInferred,
            string copyProgress,
            string contentType,
            string contentEncoding,
            string contentLanguage,
            byte[] contentHash ,
            string contentDisposition,
            string cacheControl,
            long? blobSequenceNumber,
            BlobType? blobType,
            LeaseStatus? leaseStatus,
            LeaseState? leaseState,
            LeaseDurationType? leaseDuration,
            string copyId,
            CopyStatus? copyStatus,
            Uri copySource,
            long? contentLength,
            string copyStatusDescription,
            bool? serverEncrypted,
            bool? incrementalCopy,
            string destinationSnapshot,
            int? remainingRetentionDays,
            AccessTier? accessTier,
            DateTimeOffset? lastModified,
            ArchiveStatus? archiveStatus,
            string customerProvidedKeySha256,
            string encryptionScope,
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
                EncryptionScope = encryptionScope,
                ETag = eTag,
                CreatedOn = createdOn,
                CopyCompletedOn = copyCompletedOn,
                DeletedOn = deletedOn,
                AccessTierChangedOn = accessTierChangedOn,
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
            LeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            LeaseState leaseState,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            long blobSequenceNumber,
            LeaseDurationType leaseDuration,
            string acceptRanges,
            string destinationSnapshot,
            int blobCommittedBlockCount,
            bool isIncrementalCopy,
            bool isServerEncrypted,
            CopyStatus copyStatus,
            string encryptionKeySha256,
            Uri copySource,
            string encryptionScope,
            string copyProgress,
            string accessTier,
            string copyId,
            bool accessTierInferred,
            string copyStatusDescription,
            string archiveStatus,
            DateTimeOffset copyCompletedOn,
            DateTimeOffset accessTierChangedOn,
            BlobType blobType,
            string versionId,
            IList<ObjectReplicationPolicy> objectReplicationSourceProperties,
            bool isLatestVersion,
            string objectReplicationDestinationPolicyId,
            long tagCount,
            IDictionary<string, string> metadata,
            DateTimeOffset expiresOn,
            DateTimeOffset createdOn,
            bool isSealed,
            string rehydratePriority,
            byte[] contentHash)
        {
            return new BlobProperties()
            {
                LastModified = lastModified,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                LeaseState = leaseState,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                BlobSequenceNumber = blobSequenceNumber,
                LeaseDuration = leaseDuration,
                AcceptRanges = acceptRanges,
                DestinationSnapshot = destinationSnapshot,
                BlobCommittedBlockCount = blobCommittedBlockCount,
                IsIncrementalCopy = isIncrementalCopy,
                IsServerEncrypted = isServerEncrypted,
                CopyStatus = copyStatus,
                EncryptionKeySha256 = encryptionKeySha256,
                CopySource = copySource,
                EncryptionScope = encryptionScope,
                CopyProgress = copyProgress,
                AccessTier = accessTier,
                CopyId = copyId,
                AccessTierInferred = accessTierInferred,
                CopyStatusDescription = copyStatusDescription,
                ArchiveStatus = archiveStatus,
                CopyCompletedOn = copyCompletedOn,
                AccessTierChangedOn = accessTierChangedOn,
                BlobType = blobType,
                VersionId = versionId,
                ObjectReplicationSourceProperties = objectReplicationSourceProperties,
                IsLatestVersion = isLatestVersion,
                ObjectReplicationDestinationPolicyId = objectReplicationDestinationPolicyId,
                TagCount = tagCount,
                Metadata = metadata,
                ExpiresOn = expiresOn,
                CreatedOn = createdOn,
                IsSealed = isSealed,
                RehydratePriority = rehydratePriority,
                ContentHash = contentHash,
            };
        }

        /// <summary>
        /// Creates a new BlobProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobProperties BlobProperties(
            DateTimeOffset lastModified,
            LeaseState leaseState,
            LeaseStatus leaseStatus,
            long contentLength,
            LeaseDurationType leaseDuration,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string destinationSnapshot,
            string cacheControl,
            bool isIncrementalCopy,
            long blobSequenceNumber,
            CopyStatus copyStatus,
            string acceptRanges,
            Uri copySource,
            int blobCommittedBlockCount,
            string copyProgress,
            bool isServerEncrypted,
            string copyId,
            string encryptionKeySha256,
            string copyStatusDescription,
            string encryptionScope,
            DateTimeOffset copyCompletedOn,
            string accessTier,
            BlobType blobType,
            bool accessTierInferred,
            IDictionary<string, string> metadata,
            string archiveStatus,
            DateTimeOffset createdOn,
            DateTimeOffset accessTierChangedOn,
            string contentType)
        {
            return new BlobProperties()
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
                EncryptionScope = encryptionScope,
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
        }

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

        /// <summary>
        /// Creates a new BlobCopyInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobCopyInfo BlobCopyInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            string copyId,
            CopyStatus copyStatus)
            => new BlobCopyInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                CopyId = copyId,
                CopyStatus = copyStatus,
            };

        /// <summary>
        /// Creates a new BlobItem instance for mocking.
        /// </summary>
        public static BlobItem BlobItem(
           string name = default,
           bool deleted = default,
           BlobItemProperties properties = default,
           string snapshot = default,
           string versionId = default,
           bool? isLatestVersion = default,
           IDictionary<string, string> metadata = default,
           IDictionary<string, string> tags = default,
           List<ObjectReplicationPolicy> objectReplicationSourcePolicies = default)
        {
            return new BlobItem()
            {
                Name = name,
                Deleted = deleted,
                Properties = properties,
                Snapshot = snapshot,
                VersionId = versionId,
                IsLatestVersion = isLatestVersion,
                Metadata = metadata,
                Tags = tags,
                ObjectReplicationSourceProperties = objectReplicationSourcePolicies
            };
        }

        /// <summary>
        /// Creates a new BlobItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobItem BlobItem(
            string name,
            bool deleted,
            BlobItemProperties properties,
            string snapshot,
            IDictionary<string, string> metadata)
            => new BlobItem()
            {
                Name = name,
                Deleted = deleted,
                Properties = properties,
                Snapshot = snapshot,
                Metadata = metadata,
            };

        /// <summary>
        /// Creates a new BlobSnapshotInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobSnapshotInfo BlobSnapshotInfo(
            string snapshot,
            ETag eTag,
            DateTimeOffset lastModified,
            bool isServerEncrypted)
            => new BlobSnapshotInfo()
            {
                Snapshot = snapshot,
                ETag = eTag,
                LastModified = lastModified,
                IsServerEncrypted = isServerEncrypted,
            };

        /// <summary>
        /// Creates a new BlobInfo instance for mocking.
        /// </summary>
        public static BlobInfo blobInfo(
            ETag eTag = default,
            DateTimeOffset lastModifed = default,
            long blobSequenceNumber = default,
            string versionId = default) =>
            new BlobInfo
            {
                ETag = eTag,
                LastModified = lastModifed,
                BlobSequenceNumber = blobSequenceNumber,
                VersionId = versionId
            };

        /// <summary>
        /// Creates a new BlobContainerItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobContainerItem BlobContainerItem(
            string name,
            BlobContainerProperties properties)
            => new BlobContainerItem()
            {
                Name = name,
                Properties = properties
            };

        /// <summary>
        /// Creates a new BlobContainerProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobContainerProperties BlobContainerProperties(
            DateTimeOffset lastModified,
            ETag eTag,
            LeaseState? leaseState,
            LeaseDurationType? leaseDuration,
            PublicAccessType? publicAccess,
            bool? hasImmutabilityPolicy,
            LeaseStatus? leaseStatus,
            string defaultEncryptionScope,
            bool? preventEncryptionScopeOverride,
            IDictionary<string, string> metadata,
            bool? hasLegalHold)
        {
            return new BlobContainerProperties()
            {
                LastModified = lastModified,
                ETag = eTag,
                LeaseState = leaseState,
                LeaseDuration = leaseDuration,
                PublicAccess = publicAccess,
                HasImmutabilityPolicy = hasImmutabilityPolicy,
                LeaseStatus = leaseStatus,
                DefaultEncryptionScope = defaultEncryptionScope,
                PreventEncryptionScopeOverride = preventEncryptionScopeOverride,
                Metadata = metadata,
                HasLegalHold = hasLegalHold,
            };
        }

        /// <summary>
        /// Creates a new BlobQueryError instance for mocking.
        /// </summary>
        public static BlobQueryError BlobQueryError(
            string name = default,
            string description = default,
            bool isFatal = default,
            long position = default)
            => new BlobQueryError
            {
                Name = name,
                Description = description,
                IsFatal = isFatal,
                Position = position
            };

        /// <summary>
        /// Creates a new GetBlobTagResult instance for mocking.
        /// </summary>
        public static GetBlobTagResult GetBlobTagResult(Tags tags)
            => new GetBlobTagResult
            {
                Tags = tags
            };

        /// <summary>
        /// Creates a new BlobTagItem instance for mocking.
        /// </summary>
        public static TaggedBlobItem TaggedBlobItem(
            string blobName = default,
            string blobContainerName = default,
            Tags tags = default)
            => new TaggedBlobItem
            {
                BlobName = blobName,
                BlobContainerName = blobContainerName,
                Tags = tags
            };

        /// <summary>
        /// Creates a new BlobTagItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TaggedBlobItem TaggedBlobItem(
            string blobName = default,
            string blobContainerName = default)
            => new TaggedBlobItem
            {
                BlobName = blobName,
                BlobContainerName = blobContainerName
            };

        /// <summary>
        /// Creates a new ObjectReplicationPolicy instance for mocking.
        /// </summary>
        public static ObjectReplicationPolicy ObjectReplicationPolicy(
            string policyId,
            IList<ObjectReplicationRule> rules)
            => new ObjectReplicationPolicy
            {
                PolicyId = policyId,
                Rules = rules
            };

        /// <summary>
        /// Creates a new ObjectReplicationRule instance for mocking.
        /// </summary>
        public static ObjectReplicationRule ObjectReplicationRule(
            string ruleId,
            ObjectReplicationStatus replicationStatus)
            => new ObjectReplicationRule
            {
                RuleId = ruleId,
                ReplicationStatus = replicationStatus
            };

        /// <summary>
        /// Creates a new BlobDownloadDetails instance for mocking.
        /// </summary>
        public static BlobDownloadDetails BlobDownloadDetails(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            string contentRange,
            string contentEncoding,
            string cacheControl,
            string contentDisposition,
            string contentLanguage,
            long blobSequenceNumber,
            DateTimeOffset copyCompletedOn,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            LeaseDurationType leaseDuration,
            LeaseState leaseState,
            LeaseStatus leaseStatus,
            string acceptRanges,
            int blobCommittedBlockCount,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string encryptionScope,
            byte[] blobContentHash,
            long tagCount,
            string versionId,
            bool isSealed,
            IList<ObjectReplicationPolicy> objectReplicationSourceProperties,
            string objectReplicationDestinationPolicy)
            => new BlobDownloadDetails
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentRange = contentRange,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                BlobSequenceNumber = blobSequenceNumber,
                CopyCompletedOn = copyCompletedOn,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                LeaseDuration = leaseDuration,
                LeaseState = leaseState,
                LeaseStatus = leaseStatus,
                AcceptRanges = acceptRanges,
                BlobCommittedBlockCount = blobCommittedBlockCount,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionScope = encryptionScope,
                BlobContentHash = blobContentHash,
                TagCount = tagCount,
                VersionId = versionId,
                IsSealed = isSealed,
                ObjectReplicationSourceProperties = objectReplicationSourceProperties,
                ObjectReplicationDestinationPolicyId = objectReplicationDestinationPolicy
            };

        /// <summary>
        /// Creates a new BlobContainerProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobContainerProperties BlobContainerProperties(
            DateTimeOffset lastModified,
            ETag eTag,
            LeaseState? leaseState,
            LeaseDurationType? leaseDuration,
            PublicAccessType? publicAccess,
            LeaseStatus? leaseStatus,
            bool? hasLegalHold,
            string defaultEncryptionScope,
            bool? preventEncryptionScopeOverride,
            IDictionary<string, string> metadata,
            bool? hasImmutabilityPolicy)
            => new BlobContainerProperties()
            {
                LastModified = lastModified,
                ETag = eTag,
                LeaseState = leaseState,
                LeaseDuration = leaseDuration,
                PublicAccess = publicAccess,
                LeaseStatus = leaseStatus,
                HasLegalHold = hasLegalHold,
                DefaultEncryptionScope = defaultEncryptionScope,
                PreventEncryptionScopeOverride = preventEncryptionScopeOverride,
                Metadata = metadata,
                HasImmutabilityPolicy = hasImmutabilityPolicy,
            };

        /// <summary>
        /// Creates a new AccountInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AccountInfo AccountInfo(
            Azure.Storage.Blobs.Models.SkuName skuName,
            Azure.Storage.Blobs.Models.AccountKind accountKind)
        {
            return new AccountInfo()
            {
                SkuName = skuName,
                AccountKind = accountKind,
            };
        }
    }
}
