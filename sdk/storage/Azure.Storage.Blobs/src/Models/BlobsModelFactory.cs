// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Azure.Core;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// This class holds BlobModelFactory overloads we need for backwards compatibility.
    /// </summary>
    [CodeGenType("StorageBlobsModelFactory")]
    public static partial class BlobsModelFactory
    {
        #region BlobContentInfo
        /// <summary> Initializes a new instance of <see cref="Models.UserDelegationKey"/>. </summary>
        /// <param name="signedObjectId"> The Azure Active Directory object ID in GUID format. </param>
        /// <param name="signedTenantId"> The Azure Active Directory tenant ID in GUID format. </param>
        /// <param name="signedStartsOn"> The date-time the key is active. </param>
        /// <param name="signedExpiresOn"> The date-time the key expires. </param>
        /// <param name="signedService"> Abbreviation of the Azure Storage service that accepts the key. </param>
        /// <param name="signedVersion"> The service version that created the key. </param>
        /// <param name="value"> The key as a base64 string. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="signedObjectId"/>, <paramref name="signedTenantId"/>, <paramref name="signedService"/>, <paramref name="signedVersion"/> or <paramref name="value"/> is null. </exception>
        /// <returns> A new <see cref="Models.UserDelegationKey"/> instance for mocking. </returns>
        public static UserDelegationKey UserDelegationKey(string signedObjectId = null, string signedTenantId = null, DateTimeOffset signedStartsOn = default, DateTimeOffset signedExpiresOn = default, string signedService = null, string signedVersion = null, string value = null)
        {
            if (signedObjectId == null)
            {
                throw new ArgumentNullException(nameof(signedObjectId));
            }
            if (signedTenantId == null)
            {
                throw new ArgumentNullException(nameof(signedTenantId));
            }
            if (signedService == null)
            {
                throw new ArgumentNullException(nameof(signedService));
            }
            if (signedVersion == null)
            {
                throw new ArgumentNullException(nameof(signedVersion));
            }
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new UserDelegationKey(
                signedObjectId,
                signedTenantId,
                signedStartsOn,
                signedExpiresOn,
                signedService,
                signedVersion,
                value);
        }

        /// <summary>
        /// Creates a new BlobContentInfo instance for mocking.
        /// </summary>
        public static BlobContentInfo BlobContentInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            byte[] contentHash,
            string versionId,
            string encryptionKeySha256,
            string encryptionScope,
            long blobSequenceNumber)
        {
            return new BlobContentInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                ContentHash = contentHash,
                VersionId = versionId,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionScope = encryptionScope,
                BlobSequenceNumber = blobSequenceNumber,
            };
        }

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
        #endregion

        #region BlobAppendInfo
        /// <summary>
        /// Creates a new BlobAppendInfo instance for mocking.
        /// </summary>
        public static BlobAppendInfo BlobAppendInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            byte[] contentHash,
            byte[] contentCrc64,
            string blobAppendOffset,
            int blobCommittedBlockCount,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string encryptionScope)
        {
            return new BlobAppendInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                ContentHash = contentHash,
                ContentCrc64 = contentCrc64,
                BlobAppendOffset = blobAppendOffset,
                BlobCommittedBlockCount = blobCommittedBlockCount,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionScope = encryptionScope,
            };
        }

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
        #endregion

        #region BlobProperties
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
            CopyStatus? blobCopyStatus = default,
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
            DateTimeOffset lastAccessed = default,
            BlobImmutabilityPolicy immutabilityPolicy = default,
            bool hasLegalHold = default)
                => new BlobProperties(
                    lastModified: lastModified,
                    createdOn: createdOn,
                    metadata: metadata,
                    objectReplicationDestinationPolicyId: objectReplicationDestinationPolicyId,
                    objectReplicationSourceProperties: objectReplicationSourceProperties,
                    blobType: blobType,
                    copyCompletedOn: copyCompletedOn,
                    copyStatusDescription: copyStatusDescription,
                    copyId: copyId,
                    copyProgress: copyProgress,
                    copySource: copySource,
                    blobCopyStatus: blobCopyStatus,
                    isIncrementalCopy: isIncrementalCopy,
                    destinationSnapshot: destinationSnapshot,
                    leaseDuration: leaseDuration,
                    leaseState: leaseState,
                    leaseStatus: leaseStatus,
                    contentLength: contentLength,
                    contentType: contentType,
                    eTag: eTag,
                    contentHash: contentHash,
                    contentEncoding: contentEncoding,
                    contentDisposition: contentDisposition,
                    contentLanguage: contentLanguage,
                    cacheControl: cacheControl,
                    blobSequenceNumber: blobSequenceNumber,
                    acceptRanges: acceptRanges,
                    blobCommittedBlockCount: blobCommittedBlockCount,
                    isServerEncrypted: isServerEncrypted,
                    encryptionKeySha256: encryptionKeySha256,
                    encryptionScope: encryptionScope,
                    accessTier: accessTier,
                    accessTierInferred: accessTierInferred,
                    archiveStatus: archiveStatus,
                    accessTierChangedOn: accessTierChangedOn,
                    versionId: versionId,
                    isLatestVersion: isLatestVersion,
                    tagCount: tagCount,
                    expiresOn: expiresOn,
                    isSealed: isSealed,
                    rehydratePriority: rehydratePriority,
                    lastAccessed: lastAccessed,
                    immutabilityPolicy: immutabilityPolicy,
                    hasLegalHold: hasLegalHold);

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
            byte[] contentHash,
            DateTimeOffset lastAccessed,
            BlobImmutabilityPolicy immutabilityPolicy,
            bool hasLegalHold)
                => new BlobProperties(
                    lastModified: lastModified,
                    createdOn: createdOn,
                    metadata: metadata,
                    objectReplicationDestinationPolicyId: objectReplicationDestinationPolicyId,
                    objectReplicationSourceProperties: objectReplicationSourceProperties,
                    blobType: blobType,
                    copyCompletedOn: copyCompletedOn,
                    copyStatusDescription: copyStatusDescription,
                    copyId: copyId,
                    copyProgress: copyProgress,
                    copySource: copySource,
                    blobCopyStatus: copyStatus,
                    isIncrementalCopy: isIncrementalCopy,
                    destinationSnapshot: destinationSnapshot,
                    leaseDuration: leaseDuration,
                    leaseState: leaseState,
                    leaseStatus: leaseStatus,
                    contentLength: contentLength,
                    contentType: contentType,
                    eTag: eTag,
                    contentHash: contentHash,
                    contentEncoding: contentEncoding,
                    contentDisposition: contentDisposition,
                    contentLanguage: contentLanguage,
                    cacheControl: cacheControl,
                    blobSequenceNumber: blobSequenceNumber,
                    acceptRanges: acceptRanges,
                    blobCommittedBlockCount: blobCommittedBlockCount,
                    isServerEncrypted: isServerEncrypted,
                    encryptionKeySha256: encryptionKeySha256,
                    encryptionScope: encryptionScope,
                    accessTier: accessTier,
                    accessTierInferred: accessTierInferred,
                    archiveStatus: archiveStatus,
                    accessTierChangedOn: accessTierChangedOn,
                    versionId: versionId,
                    isLatestVersion: isLatestVersion,
                    tagCount: tagCount,
                    expiresOn: expiresOn,
                    isSealed: isSealed,
                    rehydratePriority: rehydratePriority,
                    lastAccessed: lastAccessed,
                    immutabilityPolicy: immutabilityPolicy,
                    hasLegalHold: hasLegalHold);

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
            byte[] contentHash ,
            DateTimeOffset lastAccessed)
                => new BlobProperties(
                    lastModified: lastModified,
                    createdOn: createdOn,
                    metadata: metadata,
                    objectReplicationDestinationPolicyId: objectReplicationDestinationPolicyId,
                    objectReplicationSourceProperties: objectReplicationSourceProperties,
                    blobType: blobType,
                    copyCompletedOn: copyCompletedOn,
                    copyStatusDescription: copyStatusDescription,
                    copyId: copyId,
                    copyProgress: copyProgress,
                    copySource: copySource,
                    blobCopyStatus: copyStatus,
                    isIncrementalCopy: isIncrementalCopy,
                    destinationSnapshot: destinationSnapshot,
                    leaseDuration: leaseDuration,
                    leaseState: leaseState,
                    leaseStatus: leaseStatus,
                    contentLength: contentLength,
                    contentType: contentType,
                    eTag: eTag,
                    contentHash: contentHash,
                    contentEncoding: contentEncoding,
                    contentDisposition: contentDisposition,
                    contentLanguage: contentLanguage,
                    cacheControl: cacheControl,
                    blobSequenceNumber: blobSequenceNumber,
                    acceptRanges: acceptRanges,
                    blobCommittedBlockCount: blobCommittedBlockCount,
                    isServerEncrypted: isServerEncrypted,
                    encryptionKeySha256: encryptionKeySha256,
                    encryptionScope: encryptionScope,
                    accessTier: accessTier,
                    accessTierInferred: accessTierInferred,
                    archiveStatus: archiveStatus,
                    accessTierChangedOn: accessTierChangedOn,
                    versionId: versionId,
                    isLatestVersion: isLatestVersion,
                    tagCount: tagCount,
                    expiresOn: expiresOn,
                    isSealed: isSealed,
                    rehydratePriority: rehydratePriority,
                    lastAccessed: lastAccessed,
                    immutabilityPolicy: new BlobImmutabilityPolicy(), // Not provided, see non-deprecated model
                    hasLegalHold: false); // Not provided, see non-deprecated model

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
                => new BlobProperties(
                    lastModified: lastModified,
                    createdOn: createdOn,
                    metadata: metadata,
                    objectReplicationDestinationPolicyId: objectReplicationDestinationPolicyId,
                    objectReplicationSourceProperties: objectReplicationSourceProperties,
                    blobType: blobType,
                    copyCompletedOn: copyCompletedOn,
                    copyStatusDescription: copyStatusDescription,
                    copyId: copyId,
                    copyProgress: copyProgress,
                    copySource: copySource,
                    blobCopyStatus: copyStatus,
                    isIncrementalCopy: isIncrementalCopy,
                    destinationSnapshot: destinationSnapshot,
                    leaseDuration: leaseDuration,
                    leaseState: leaseState,
                    leaseStatus: leaseStatus,
                    contentLength: contentLength,
                    contentType: contentType,
                    eTag: eTag,
                    contentHash: contentHash,
                    contentEncoding: contentEncoding,
                    contentDisposition: contentDisposition,
                    contentLanguage: contentLanguage,
                    cacheControl: cacheControl,
                    blobSequenceNumber: blobSequenceNumber,
                    acceptRanges: acceptRanges,
                    blobCommittedBlockCount: blobCommittedBlockCount,
                    isServerEncrypted: isServerEncrypted,
                    encryptionKeySha256: encryptionKeySha256,
                    encryptionScope: encryptionScope,
                    accessTier: accessTier,
                    accessTierInferred: accessTierInferred,
                    archiveStatus: archiveStatus,
                    accessTierChangedOn: accessTierChangedOn,
                    versionId: versionId,
                    isLatestVersion: isLatestVersion,
                    tagCount: tagCount,
                    expiresOn: expiresOn,
                    isSealed: isSealed,
                    rehydratePriority: rehydratePriority,
                    lastAccessed: default, // Not provided, see non-deprecated model
                    immutabilityPolicy: new BlobImmutabilityPolicy(), // Not provided, see non-deprecated model
                    hasLegalHold: false); // Not provided, see non-deprecated model

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
                => new BlobProperties(
                    lastModified: lastModified,
                    createdOn: createdOn,
                    metadata: metadata,
                    objectReplicationDestinationPolicyId: default, // Not provided, see non-deprecated model
                    objectReplicationSourceProperties: default, // Not provided, see non-deprecated model
                    blobType: blobType,
                    copyCompletedOn: copyCompletedOn,
                    copyStatusDescription: copyStatusDescription,
                    copyId: copyId,
                    copyProgress: copyProgress,
                    copySource: copySource,
                    blobCopyStatus: copyStatus,
                    isIncrementalCopy: isIncrementalCopy,
                    destinationSnapshot: destinationSnapshot,
                    leaseDuration: leaseDuration,
                    leaseState: leaseState,
                    leaseStatus: leaseStatus,
                    contentLength: contentLength,
                    contentType: contentType,
                    eTag: eTag,
                    contentHash: contentHash,
                    contentEncoding: contentEncoding,
                    contentDisposition: contentDisposition,
                    contentLanguage: contentLanguage,
                    cacheControl: cacheControl,
                    blobSequenceNumber: blobSequenceNumber,
                    acceptRanges: acceptRanges,
                    blobCommittedBlockCount: blobCommittedBlockCount,
                    isServerEncrypted: isServerEncrypted,
                    encryptionKeySha256: encryptionKeySha256,
                    encryptionScope: encryptionScope,
                    accessTier: accessTier,
                    accessTierInferred: accessTierInferred,
                    archiveStatus: archiveStatus,
                    accessTierChangedOn: accessTierChangedOn,
                    versionId: default, // Not provided, see non-deprecated model
                    isLatestVersion: default, // Not provided, see non-deprecated model
                    tagCount: default, // Not provided, see non-deprecated model
                    expiresOn: default, // Not provided, see non-deprecated model
                    isSealed: default, // Not provided, see non-deprecated model
                    rehydratePriority: default, // Not provided, see non-deprecated model
                    lastAccessed: default, // Not provided, see non-deprecated model
                    immutabilityPolicy: new BlobImmutabilityPolicy(), // Not provided, see non-deprecated model
                    hasLegalHold: false); // Not provided, see non-deprecated model

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
                => new BlobProperties(
                    lastModified: lastModified,
                    createdOn: createdOn,
                    metadata: metadata,
                    objectReplicationDestinationPolicyId: default, // Not provided, see non-deprecated model
                    objectReplicationSourceProperties: default, // Not provided, see non-deprecated model
                    blobType: blobType,
                    copyCompletedOn: copyCompletedOn,
                    copyStatusDescription: copyStatusDescription,
                    copyId: copyId,
                    copyProgress: copyProgress,
                    copySource: copySource,
                    blobCopyStatus: copyStatus,
                    isIncrementalCopy: isIncrementalCopy,
                    destinationSnapshot: destinationSnapshot,
                    leaseDuration: leaseDuration,
                    leaseState: leaseState,
                    leaseStatus: leaseStatus,
                    contentLength: contentLength,
                    contentType: contentType,
                    eTag: eTag,
                    contentHash: contentHash,
                    contentEncoding: contentEncoding,
                    contentDisposition: contentDisposition,
                    contentLanguage: contentLanguage,
                    cacheControl: cacheControl,
                    blobSequenceNumber: blobSequenceNumber,
                    acceptRanges: acceptRanges,
                    blobCommittedBlockCount: blobCommittedBlockCount,
                    isServerEncrypted: isServerEncrypted,
                    encryptionKeySha256: encryptionKeySha256,
                    encryptionScope: default, // Not provided, see non-deprecated model
                    accessTier: accessTier,
                    accessTierInferred: accessTierInferred,
                    archiveStatus: archiveStatus,
                    accessTierChangedOn: accessTierChangedOn,
                    versionId: default, // Not provided, see non-deprecated model
                    isLatestVersion: default, // Not provided, see non-deprecated model
                    tagCount: default, // Not provided, see non-deprecated model
                    expiresOn: default, // Not provided, see non-deprecated model
                    isSealed: default, // Not provided, see non-deprecated model
                    rehydratePriority: default, // Not provided, see non-deprecated model
                    lastAccessed: default, // Not provided, see non-deprecated model
                    immutabilityPolicy: new BlobImmutabilityPolicy(), // Not provided, see non-deprecated model
                    hasLegalHold: false // Not provided, see non-deprecated model
                    );
        #endregion

        #region BlobItemProperties
        /// <summary>
        /// Creates a new BlobItemProperties instance for mocking.
        /// </summary>
        public static BlobItemProperties BlobItemProperties(
            bool accessTierInferred,
            bool? serverEncrypted = default,
            string contentType = default,
            string contentEncoding = default,
            string contentLanguage = default,
            byte[] contentHash = default,
            string contentDisposition = default,
            string cacheControl = default,
            long? blobSequenceNumber = default,
            BlobType? blobType = default,
            LeaseStatus? leaseStatus = default,
            LeaseState? leaseState = default,
            LeaseDurationType? leaseDuration = default,
            string copyId = default,
            CopyStatus? copyStatus = default,
            Uri copySource = default,
            string copyProgress = default,
            string copyStatusDescription = default,
            long? contentLength = default,
            bool? incrementalCopy = default,
            string destinationSnapshot = default,
            int? remainingRetentionDays = default,
            AccessTier? accessTier = default,
            DateTimeOffset? lastModified = default,
            ArchiveStatus? archiveStatus = default,
            string customerProvidedKeySha256 = default,
            string encryptionScope = default,
            long? tagCount = default,
            DateTimeOffset? expiresOn = default,
            bool? isSealed = default,
            RehydratePriority? rehydratePriority = default,
            DateTimeOffset? lastAccessedOn = default,
            ETag? eTag = default,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? copyCompletedOn = default,
            DateTimeOffset? deletedOn = default,
            DateTimeOffset? accessTierChangedOn = default)
        {
            return new BlobItemProperties()
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
                LastAccessedOn = lastAccessedOn,
                ETag = eTag,
                CreatedOn = createdOn,
                CopyCompletedOn = copyCompletedOn,
                DeletedOn = deletedOn,
                AccessTierChangedOn = accessTierChangedOn,
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
        #endregion

        #region BlockInfo
        /// <summary>
        /// Creates a new BlockInfo instance for mocking.
        /// </summary>
        public static BlockInfo BlockInfo(
            byte[] contentHash,
            byte[] contentCrc64,
            string encryptionKeySha256,
            string encryptionScope)
        {
            return new BlockInfo()
            {
                ContentHash = contentHash,
                ContentCrc64 = contentCrc64,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionScope = encryptionScope,
            };
        }

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
        #endregion

        #region PageInfo
        /// <summary>
        /// Creates a new PageInfo instance for mocking.
        /// </summary>
        public static PageInfo PageInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            byte[] contentHash,
            byte[] contentCrc64,
            long blobSequenceNumber,
            string encryptionKeySha256,
            string encryptionScope)
        {
            return new PageInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                ContentHash = contentHash,
                ContentCrc64 = contentCrc64,
                BlobSequenceNumber = blobSequenceNumber,
                EncryptionKeySha256 = encryptionKeySha256,
                EncryptionScope = encryptionScope,
            };
        }

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
        #endregion

        #region BlobContainerProperties
        /// <summary>
        /// Creates a new BlobContainerProperties instance for mocking.
        /// </summary>
        public static BlobContainerProperties BlobContainerProperties(
            DateTimeOffset lastModified,
            ETag eTag,
            LeaseState? leaseState = default,
            LeaseDurationType? leaseDuration = default,
            PublicAccessType? publicAccess = default,
            bool? hasImmutabilityPolicy = default,
            LeaseStatus? leaseStatus = default,
            string defaultEncryptionScope = default,
            bool? preventEncryptionScopeOverride = default,
            DateTimeOffset? deletedOn = default,
            int? remainingRetentionDays = default,
            IDictionary<string, string> metadata = default,
            bool? hasLegalHold = default)
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
                DeletedOn = deletedOn,
                RemainingRetentionDays = remainingRetentionDays,
                Metadata = metadata,
                HasLegalHold = hasLegalHold,
            };
        }

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
        #endregion

        #region BlobCopyInfo
        /// <summary>
        /// Creates a new BlobCopyInfo instance for mocking.
        /// </summary>
        public static BlobCopyInfo BlobCopyInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            string versionId,
            string copyId,
            CopyStatus copyStatus)
        {
            return new BlobCopyInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                VersionId = versionId,
                CopyId = copyId,
                CopyStatus = copyStatus,
            };
        }

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
        #endregion

        #region BlobItem
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
           List<ObjectReplicationPolicy> objectReplicationSourcePolicies = default,
           bool? hasVersionsOnly = default)
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
                ObjectReplicationSourceProperties = objectReplicationSourcePolicies,
                HasVersionsOnly = hasVersionsOnly
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
           string versionId,
           bool? isLatestVersion,
           IDictionary<string, string> metadata,
           IDictionary<string, string> tags,
           List<ObjectReplicationPolicy> objectReplicationSourcePolicies)
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
        #endregion

        #region BlobSnapshotInfo
        /// <summary>
        /// Creates a new BlobSnapshotInfo instance for mocking.
        /// </summary>
        public static BlobSnapshotInfo BlobSnapshotInfo(
            string snapshot,
            ETag eTag,
            DateTimeOffset lastModified,
            string versionId,
            bool isServerEncrypted)
        {
            return new BlobSnapshotInfo()
            {
                Snapshot = snapshot,
                ETag = eTag,
                LastModified = lastModified,
                VersionId = versionId,
                IsServerEncrypted = isServerEncrypted,
            };
        }

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
        #endregion

        #region BlobInfo
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
        #endregion

        #region BlobContainerItem
        /// <summary>
        /// Creates a new BlobContainerItem instance for mocking.
        /// </summary>
        public static BlobContainerItem BlobContainerItem(
            string name,
            BlobContainerProperties properties,
            bool? isDeleted = default,
            string versionId = default)
        {
            return new BlobContainerItem()
            {
                Name = name,
                Properties = properties,
                IsDeleted = isDeleted,
                VersionId = versionId,
            };
        }

        /// <summary>
        /// Creates a new BlobContainerInfo instance for mocking.
        /// </summary>
        public static BlobContainerInfo BlobContainerInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            return new BlobContainerInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }

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
        #endregion

        #region BlobQueryError
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
        #endregion

        #region GetBlobTagResult
        /// <summary>
        /// Creates a new GetBlobTagResult instance for mocking.
        /// </summary>
        public static GetBlobTagResult GetBlobTagResult(Tags tags)
            => new GetBlobTagResult
            {
                Tags = tags
            };
        #endregion

        #region TaggedBlobItem
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
        #endregion

        #region ObjectReplicationPolicy
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
        #endregion

        #region ObjectReplicationRule
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
        #endregion

        #region BlobDownloadDetails
        /// <summary>
        /// Creates a new BlobDownloadDetails instance for mocking.
        /// </summary>
        public static BlobDownloadDetails BlobDownloadDetails(
            BlobType blobType = default,
            long contentLength = default,
            string contentType = default,
            byte[] contentHash = default,
            DateTimeOffset lastModified = default,
            IDictionary<string, string> metadata = default,
            string contentRange = default,
            string contentEncoding = default,
            string cacheControl = default,
            string contentDisposition = default,
            string contentLanguage = default,
            long blobSequenceNumber = default,
            DateTimeOffset copyCompletedOn = default,
            string copyStatusDescription = default,
            string copyId = default,
            string copyProgress = default,
            Uri copySource = default,
            CopyStatus copyStatus = default,
            LeaseDurationType leaseDuration = default,
            LeaseState leaseState = default,
            LeaseStatus leaseStatus = default,
            string acceptRanges = default,
            int blobCommittedBlockCount = default,
            bool isServerEncrypted = default,
            string encryptionKeySha256 = default,
            string encryptionScope = default,
            byte[] blobContentHash = default,
            long tagCount = default,
            string versionId = default,
            bool isSealed = default,
            IList<ObjectReplicationPolicy> objectReplicationSourceProperties = default,
            string objectReplicationDestinationPolicy = default,
            bool hasLegalHold = default,
            DateTimeOffset createdOn = default,
            ETag eTag = default)
            => new BlobDownloadDetails
            {
                BlobType = blobType,
                ContentLength = contentLength,
                ContentType = contentType,
                ContentHash = contentHash,
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
                ObjectReplicationDestinationPolicyId = objectReplicationDestinationPolicy,
                HasLegalHold = hasLegalHold,
                CreatedOn = createdOn,
                ETag = eTag
            };

        /// <summary>
        /// Creates a new BlobDownloadDetails instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobDownloadDetails BlobDownloadDetails(
            BlobType blobType,
            long contentLength,
            string contentType,
            byte[] contentHash,
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
            string objectReplicationDestinationPolicy,
            bool hasLegalHold,
            DateTimeOffset createdOn)
            => new BlobDownloadDetails
            {
                BlobType = blobType,
                ContentLength = contentLength,
                ContentType = contentType,
                ContentHash = contentHash,
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
                ObjectReplicationDestinationPolicyId = objectReplicationDestinationPolicy,
                HasLegalHold = hasLegalHold,
                CreatedOn = createdOn
            };

        /// <summary>
        /// Creates a new BlobDownloadDetails instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Creates a new BlobDownloadDetails instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobDownloadDetails BlobDownloadDetails(
            BlobType blobType,
            long contentLength,
            string contentType,
            byte[] contentHash,
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
                BlobType = blobType,
                ContentLength = contentLength,
                ContentType = contentType,
                ContentHash = contentHash,
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
        #endregion

        #region AccountInfo
        /// <summary>
        /// Creates a new AccountInfo instance for mocking.
        /// </summary>
        public static AccountInfo AccountInfo(
            SkuName skuName,
            AccountKind accountKind,
            bool isHierarchicalNamespaceEnabled)
        {
            return new AccountInfo()
            {
                SkuName = skuName,
                AccountKind = accountKind,
                IsHierarchicalNamespaceEnabled = isHierarchicalNamespaceEnabled,
            };
        }

        /// <summary>
        /// Creates a new AccountInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AccountInfo AccountInfo(
            SkuName skuName,
            AccountKind accountKind)
        {
            return new AccountInfo()
            {
                SkuName = skuName,
                AccountKind = accountKind,
            };
        }
        #endregion

        #region BlobContainerAccessPolicy
        /// <summary>
        /// Creates a new BlobContainerAccessPolicy instance for mocking.
        /// </summary>
        public static BlobContainerAccessPolicy BlobContainerAccessPolicy(
            PublicAccessType blobPublicAccess,
            ETag eTag,
            DateTimeOffset lastModified,
            IEnumerable<BlobSignedIdentifier> signedIdentifiers)
        {
            return new BlobContainerAccessPolicy()
            {
                BlobPublicAccess = blobPublicAccess,
                ETag = eTag,
                LastModified = lastModified,
                SignedIdentifiers = signedIdentifiers,
            };
        }
        #endregion

        #region PageBlobInfo
        /// <summary>
        /// Creates a new PageBlobInfo instance for mocking.
        /// </summary>
        public static PageBlobInfo PageBlobInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            long blobSequenceNumber)
        {
            return new PageBlobInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                BlobSequenceNumber = blobSequenceNumber,
            };
        }
        #endregion

        #region BlobBlock
        /// <summary>
        /// Creates a new BlobBlock instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobBlock BlobBlock(
            string name,
            int size)
        {
            return new BlobBlock(name, size);
        }

        /// <summary>
        /// Creates a new BlobBlock instance for mocking.
        /// </summary>
        public static BlobBlock BlobBlock(
            string name,
            long size)
        {
            return new BlobBlock(name, size);
        }
        #endregion

        #region BlobGeoReplication
        /// <summary>
        /// Creates a new BlobGeoReplication instance for mocking.
        /// </summary>
        public static BlobGeoReplication BlobGeoReplication(
            BlobGeoReplicationStatus status,
            DateTimeOffset? lastSyncedOn = default)
            => new BlobGeoReplication(status, lastSyncedOn);
        #endregion

        #region BlobInfo
        /// <summary>
        /// Creates a new BlobInfo instance for mocking.
        /// </summary>
        public static BlobInfo BlobInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            return new BlobInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }
        #endregion

        #region BlobLease
        /// <summary>
        /// Creates a new BlobLease instance for mocking.
        /// </summary>
        public static BlobLease BlobLease(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            string leaseId)
        {
            return new BlobLease()
            {
                ETag = eTag,
                LastModified = lastModified,
                LeaseId = leaseId,
            };
        }
        #endregion

        #region BlobServiceStatistics
        /// <summary>
        /// Creates a new BlobServiceStatistics instance for mocking.
        /// </summary>
        public static BlobServiceStatistics BlobServiceStatistics(
            Azure.Storage.Blobs.Models.BlobGeoReplication geoReplication = default)
        {
            return new BlobServiceStatistics(geoReplication);
        }
        #endregion

        #region BlockList
        /// <summary>
        /// Creates a new BlockList instance for mocking.
        /// </summary>
        public static BlockList BlockList(
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> committedBlocks = default,
            System.Collections.Generic.IEnumerable<Azure.Storage.Blobs.Models.BlobBlock> uncommittedBlocks = default)
        {
            return new BlockList()
            {
                CommittedBlocks = committedBlocks,
                UncommittedBlocks = uncommittedBlocks,
            };
        }
        #endregion

        #region UserDelegationKey
        /// <summary>
        /// Creates a new UserDelegationKey instance for mocking.
        /// </summary>
        public static UserDelegationKey UserDelegationKey(
            string signedObjectId,
            string signedTenantId,
            string signedService,
            string signedVersion,
            string value,
            DateTimeOffset signedExpiresOn,
            DateTimeOffset signedStartsOn)
        {
            return new UserDelegationKey(
                signedObjectId,
                signedTenantId,
                signedStartsOn,
                signedExpiresOn,
                signedService,
                signedVersion,
                value);
        }
        #endregion

        #region BlobHierarchyItem
        /// <summary>
        /// Creates a new BlobHierarchyItem instance for mocking.
        /// </summary>
        public static BlobHierarchyItem BlobHierarchyItem(
            string prefix,
            BlobItem blob) =>
            new BlobHierarchyItem(prefix, blob);
        #endregion

        #region BlobDownloadInfo
        /// <summary>
        /// Creates a new BlobDownloadInfo instance for mocking.
        /// </summary>
        public static BlobDownloadInfo BlobDownloadInfo(
            DateTimeOffset lastModified = default,
            long blobSequenceNumber = default,
            BlobType blobType = default,
#pragma warning disable CA1801 // Review unused parameters
            byte[] contentCrc64 = default,
#pragma warning restore CA1801 // Review unused parameters
            string contentLanguage = default,
            string copyStatusDescription = default,
            string copyId = default,
            string copyProgress = default,
            Uri copySource = default,
            CopyStatus copyStatus = default,
            string contentDisposition = default,
            LeaseDurationType leaseDuration = default,
            string cacheControl = default,
            LeaseState leaseState = default,
            string contentEncoding = default,
            LeaseStatus leaseStatus = default,
            byte[] contentHash = default,
            string acceptRanges = default,
            ETag eTag = default,
            int blobCommittedBlockCount = default,
            string contentRange = default,
            bool isServerEncrypted = default,
            string contentType = default,
            string encryptionKeySha256 = default,
            string encryptionScope = default,
            long contentLength = default,
            byte[] blobContentHash = default,
            string versionId = default,
            IDictionary<string, string> metadata = default,
            Stream content = default,
            DateTimeOffset copyCompletionTime = default,
            long tagCount = default,
            DateTimeOffset lastAccessed = default)
        {
            return new BlobDownloadInfo
            {
                BlobType = blobType,
                ContentLength = contentLength,
                Content = content,
                ContentType = contentType,
                ContentHash = contentHash,
                Details = new BlobDownloadDetails
                {
                    BlobType = blobType,
                    ContentLength = contentLength,
                    ContentType = contentType,
                    ContentHash = contentHash,
                    LastModified = lastModified,
                    Metadata = metadata,
                    ContentRange = contentRange,
                    ETag = eTag,
                    ContentEncoding = contentEncoding,
                    CacheControl = cacheControl,
                    ContentDisposition = contentDisposition,
                    ContentLanguage = contentLanguage,
                    BlobSequenceNumber = blobSequenceNumber,
                    CopyCompletedOn = copyCompletionTime,
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
                    LastAccessed = lastAccessed
                }
            };
        }

        /// <summary>
        /// Creates a new BlobDownloadInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobDownloadInfo BlobDownloadInfo(
            DateTimeOffset lastModified,
            long blobSequenceNumber,
            BlobType blobType,
#pragma warning disable CA1801 // Review unused parameters
            byte[] contentCrc64,
#pragma warning restore CA1801 // Review unused parameters
            string contentLanguage,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            string contentDisposition,
            LeaseDurationType leaseDuration,
            string cacheControl,
            LeaseState leaseState,
            string contentEncoding,
            LeaseStatus leaseStatus,
            byte[] contentHash,
            string acceptRanges,
            ETag eTag,
            int blobCommittedBlockCount,
            string contentRange,
            bool isServerEncrypted,
            string contentType,
            string encryptionKeySha256,
            string encryptionScope,
            long contentLength,
            byte[] blobContentHash,
            string versionId,
            IDictionary<string, string> metadata,
            Stream content,
            DateTimeOffset copyCompletionTime,
            long tagCount)
        {
            return new BlobDownloadInfo
            {
                BlobType = blobType,
                ContentLength = contentLength,
                Content = content,
                ContentType = contentType,
                ContentHash = contentHash,
                Details = new BlobDownloadDetails
                {
                    BlobType = blobType,
                    ContentLength = contentLength,
                    ContentType = contentType,
                    ContentHash = contentHash,
                    LastModified = lastModified,
                    Metadata = metadata,
                    ContentRange = contentRange,
                    ETag = eTag,
                    ContentEncoding = contentEncoding,
                    CacheControl = cacheControl,
                    ContentDisposition = contentDisposition,
                    ContentLanguage = contentLanguage,
                    BlobSequenceNumber = blobSequenceNumber,
                    CopyCompletedOn = copyCompletionTime,
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
                }
            };
        }

        /// <summary>
        /// Creates a new BlobDownloadInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobDownloadInfo BlobDownloadInfo(
            DateTimeOffset lastModified,
            long blobSequenceNumber,
            BlobType blobType,
#pragma warning disable CA1801 // Review unused parameters
            byte[] contentCrc64,
#pragma warning restore CA1801 // Review unused parameters
            string contentLanguage,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            string contentDisposition,
            LeaseDurationType leaseDuration,
            string cacheControl,
            LeaseState leaseState,
            string contentEncoding,
            LeaseStatus leaseStatus,
            byte[] contentHash,
            string acceptRanges,
            ETag eTag,
            int blobCommittedBlockCount,
            string contentRange,
            bool isServerEncrypted,
            string contentType,
            string encryptionKeySha256,
            string encryptionScope,
            long contentLength,
            byte[] blobContentHash,
            IDictionary<string, string> metadata,
            Stream content,
            DateTimeOffset copyCompletionTime)
        {
            return new BlobDownloadInfo
            {
                BlobType = blobType,
                ContentLength = contentLength,
                Content = content,
                ContentType = contentType,
                ContentHash = contentHash,
                Details = new BlobDownloadDetails
                {
                    BlobType = blobType,
                    ContentLength = contentLength,
                    ContentType = contentType,
                    ContentHash = contentHash,
                    LastModified = lastModified,
                    Metadata = metadata,
                    ContentRange = contentRange,
                    ETag = eTag,
                    ContentEncoding = contentEncoding,
                    CacheControl = cacheControl,
                    ContentDisposition = contentDisposition,
                    ContentLanguage = contentLanguage,
                    BlobSequenceNumber = blobSequenceNumber,
                    CopyCompletedOn = copyCompletionTime,
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
                }
            };
        }

        /// <summary>
        /// Creates a new BlobDownloadInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BlobDownloadInfo BlobDownloadInfo(
            DateTimeOffset lastModified,
            long blobSequenceNumber,
            BlobType blobType,
#pragma warning disable CA1801 // Review unused parameters
            byte[] contentCrc64,
#pragma warning restore CA1801 // Review unused parameters
            string contentLanguage,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            string contentDisposition,
            LeaseDurationType leaseDuration,
            string cacheControl,
            LeaseState leaseState,
            string contentEncoding,
            LeaseStatus leaseStatus,
            byte[] contentHash,
            string acceptRanges,
            ETag eTag,
            int blobCommittedBlockCount,
            string contentRange,
            bool isServerEncrypted,
            string contentType,
            string encryptionKeySha256,
            long contentLength,
            byte[] blobContentHash,
            IDictionary<string, string> metadata,
            Stream content,
            DateTimeOffset copyCompletionTime)
        {
            return new BlobDownloadInfo
            {
                BlobType = blobType,
                ContentLength = contentLength,
                Content = content,
                ContentType = contentType,
                ContentHash = contentHash,
                Details = new BlobDownloadDetails
                {
                    BlobType = blobType,
                    ContentLength = contentLength,
                    ContentType = contentType,
                    ContentHash = contentHash,
                    LastModified = lastModified,
                    Metadata = metadata,
                    ContentRange = contentRange,
                    ETag = eTag,
                    ContentEncoding = contentEncoding,
                    CacheControl = cacheControl,
                    ContentDisposition = contentDisposition,
                    ContentLanguage = contentLanguage,
                    BlobSequenceNumber = blobSequenceNumber,
                    CopyCompletedOn = copyCompletionTime,
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
                    BlobContentHash = blobContentHash,
                }
            };
        }
        #endregion

        #region BlobDownloadDataResult
        /// <summary>
        /// Creates a new BlobDownloadDataResult instance for mocking.
        /// </summary>
        public static BlobDownloadResult BlobDownloadResult(
            BinaryData content = default,
            BlobDownloadDetails details = default)
        {
            return new BlobDownloadResult()
            {
                Content = content,
                Details = details,
            };
        }
        #endregion

        #region BlobDownloadStreamingResult
        /// <summary>
        /// Creates a new BlobDownloadStreamingResult instance for mocking.
        /// </summary>
        public static BlobDownloadStreamingResult BlobDownloadStreamingResult(
            Stream content = default,
            BlobDownloadDetails details = default)
        {
            return new BlobDownloadStreamingResult()
            {
                Content = content,
                Details = details,
            };
        }
        #endregion

        #region PageRangesInfo
        /// <summary>
        /// Creates a new PageRangesInfo instance for mocking.
        /// </summary>
        public static PageRangesInfo PageRangesInfo(
            DateTimeOffset lastModified,
            ETag eTag,
            long blobContentLength,
            IEnumerable<HttpRange> pageRanges,
            IEnumerable<HttpRange> clearRanges)
        {
            return new PageRangesInfo
            {
                LastModified = lastModified,
                ETag = eTag,
                BlobContentLength = blobContentLength,
                PageRanges = pageRanges,
                ClearRanges = clearRanges
            };
        }
        #endregion
    }
}
