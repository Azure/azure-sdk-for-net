// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// DataLakeModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class DataLakeModelFactory
    {
        #region DataLakeFileReadResult
        /// <summary>
        /// Creates a new <see cref="DataLakeFileReadResult"/> instance for mocking.
        /// </summary>
        public static DataLakeFileReadResult DataLakeFileReadResult(
            BinaryData content,
            FileDownloadDetails details)
            => new DataLakeFileReadResult()
            {
                Content = content,
                Details = details
            };
        #endregion DataLakeFileReadResult

        #region DataLakeFileReadStreamingResult
        /// <summary>
        /// Creates a new <see cref="DataLakeFileReadStreamingResult"/> instance for mocking.
        /// </summary>
        public static DataLakeFileReadStreamingResult DataLakeFileReadStreamingResult(
            Stream content,
            FileDownloadDetails details)
            => new DataLakeFileReadStreamingResult()
            {
                Content = content,
                Details = details
            };
        #endregion DataLakeFileReadStreamingResult

        #region FileDownloadDetails
        /// <summary>
        /// Creates a new FileDownloadDetails instance for mocking.
        /// </summary>
        public static FileDownloadDetails FileDownloadDetails(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            string contentRange,
            ETag eTag,
            string contentEncoding,
            string cacheControl,
            string contentDisposition,
            string contentLanguage,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            byte[] contentHash,
            DateTimeOffset createdOn,
            string encryptionContext,
            IList<PathAccessControlItem> accessControlList
            )
            => new FileDownloadDetails()
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentRange = contentRange,
                ETag = eTag,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
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
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                ContentHash = contentHash,
                CreatedOn = createdOn,
                EncryptionContext = encryptionContext,
                AccessControlList = accessControlList
            };

        /// <summary>
        /// Creates a new <see cref="Models.FileDownloadDetails"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileDownloadDetails FileDownloadDetails(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            string contentRange,
            ETag eTag,
            string contentEncoding,
            string cacheControl,
            string contentDisposition,
            string contentLanguage,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            byte[] contentHash,
            DateTimeOffset createdOn,
            string encryptionContext)
            => new FileDownloadDetails()
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentRange = contentRange,
                ETag = eTag,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
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
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                ContentHash = contentHash,
                CreatedOn = createdOn,
                EncryptionContext = encryptionContext
            };

        /// <summary>
        /// Creates a new <see cref="Models.FileDownloadDetails"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileDownloadDetails FileDownloadDetails(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            string contentRange,
            ETag eTag,
            string contentEncoding,
            string cacheControl,
            string contentDisposition,
            string contentLanguage,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            byte[] contentHash,
            DateTimeOffset createdOn)
            => new FileDownloadDetails()
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentRange = contentRange,
                ETag = eTag,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
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
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                ContentHash = contentHash,
                CreatedOn = createdOn,
            };

        /// <summary>
        /// Creates a new <see cref="Models.FileDownloadDetails"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileDownloadDetails FileDownloadDetails(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            string contentRange,
            ETag eTag,
            string contentEncoding,
            string cacheControl,
            string contentDisposition,
            string contentLanguage,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            byte[] contentHash)
            => new FileDownloadDetails()
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentRange = contentRange,
                ETag = eTag,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
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
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                ContentHash = contentHash
            };
        #endregion FileDownloadDetails

        #region FileDownloadInfo
        /// <summary>
        /// Creates a new <see cref="FileDownloadInfo"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileDownloadInfo FileDownloadInfo(
            long contentLength,
            Stream content,
            byte[] contentHash,
            FileDownloadDetails properties)
            => new FileDownloadInfo()
            {
                ContentLength = contentLength,
                Content = content,
                ContentHash = contentHash,
                Properties = properties
            };
        #endregion FileDownloadInfo

        #region FileSystemInfo
        /// <summary>
        /// Creates a new <see cref="FileSystemInfo"/> instance for mocking.
        /// </summary>
        public static FileSystemInfo FileSystemInfo(
            ETag etag,
            DateTimeOffset lastModified)
            => new FileSystemInfo()
            {
                ETag = etag,
                LastModified = lastModified
            };
        #endregion FileSystemInfo

        #region FileSystemItem
        /// <summary>
        /// Creates a new FileSystemItem instance for mocking.
        /// </summary>
        public static FileSystemItem FileSystemItem(
            string name = default,
            bool? isDeleted = default,
            string versionId = default,
            FileSystemProperties properties = default)
            => new FileSystemItem()
            {
                Name = name,
                IsDeleted = isDeleted,
                VersionId = versionId,
                Properties = properties
            };

        /// <summary>
        /// Creates a new FileSystemItem" instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileSystemItem FileSystemItem(
            string name,
            FileSystemProperties properties)
            => new FileSystemItem()
            {
                Name = name,
                Properties = properties
            };
        #endregion FileSystemItem

        #region FileSystemProperties
        /// <summary>
        /// Creates a new FileSystemProperties instance for mocking.
        /// </summary>
        public static FileSystemProperties FileSystemProperties(
            DateTimeOffset lastModified = default,
            DataLakeLeaseStatus? leaseStatus = default,
            DataLakeLeaseState? leaseState = default,
            DataLakeLeaseDuration? leaseDuration = default,
            PublicAccessType? publicAccess = default,
            bool? hasImmutabilityPolicy = default,
            bool? hasLegalHold = default,
            ETag eTag = default,
            IDictionary<string, string> metadata = default,
            DateTimeOffset? deletedOn = default,
            int? remainingRetentionDays = default)
            => new FileSystemProperties()
            {
                LastModified = lastModified,
                LeaseStatus = leaseStatus,
                LeaseState = leaseState,
                LeaseDuration = leaseDuration,
                PublicAccess = publicAccess,
                HasImmutabilityPolicy = hasImmutabilityPolicy,
                HasLegalHold = hasLegalHold,
                ETag = eTag,
                Metadata = metadata,
                DeletedOn = deletedOn,
                RemainingRetentionDays = remainingRetentionDays
            };

        /// <summary>
        /// Creates a new FileSystemProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileSystemProperties FileSystemProperties(
            DateTimeOffset lastModified,
            DataLakeLeaseStatus? leaseStatus,
            DataLakeLeaseState? leaseState,
            DataLakeLeaseDuration? leaseDuration,
            PublicAccessType? publicAccess,
            bool? hasImmutabilityPolicy,
            bool? hasLegalHold,
            ETag eTag)
            => new FileSystemProperties()
            {
                LastModified = lastModified,
                LeaseStatus = leaseStatus,
                LeaseState = leaseState,
                LeaseDuration = leaseDuration,
                PublicAccess = publicAccess,
                HasImmutabilityPolicy = hasImmutabilityPolicy,
                HasLegalHold = hasLegalHold,
                ETag = eTag
            };
        #endregion FileSystemProperties

        #region Lease
        /// <summary>
        /// Creates a new <see cref="DataLakeLease"/> instance for mocking.
        /// </summary>
        public static DataLakeLease Lease(
            ETag eTag,
            DateTimeOffset lastModified,
            string leaseId,
            int? leaseTime)
            => new DataLakeLease()
            {
                ETag = eTag,
                LastModified = lastModified,
                LeaseId = leaseId,
                LeaseTime = leaseTime
            };
        #endregion Lease

        #region PathAccessControl
        /// <summary>
        /// Creates a new <see cref="PathAccessControl"/> instance for mocking.
        /// </summary>
        public static PathAccessControl PathAccessControl(
            string owner,
            string group,
            PathPermissions permissions,
            IList<PathAccessControlItem> acl)
            => new PathAccessControl()
            {
                Owner = owner,
                Group = group,
                Permissions = permissions,
                AccessControlList = acl
            };
        #endregion PathAccessControl

        #region PathContentInfo
        /// <summary>
        /// Creates a new <see cref="PathContentInfo"/> instance for mocking.
        /// </summary>
        public static PathContentInfo PathContentInfo(
            string contentHash,
            ETag eTag,
            DateTimeOffset lastModified,
            string acceptRanges,
            string cacheControl,
            string contentDisposition,
            string contentEncoding,
            string contentLanguage,
            long contentLength,
            string contentRange,
            string contentType,
            IDictionary<string, string> metadata)
            => new PathContentInfo()
            {
                ContentHash = contentHash,
                ETag = eTag,
                LastModified = lastModified,
                AcceptRanges = acceptRanges,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentEncoding = contentEncoding,
                ContentLanguage = contentLanguage,
                ContentLength = contentLength,
                ContentRange = contentRange,
                ContentType = contentType,
                Metadata = metadata
            };
        #endregion PathContentInfo

        #region PathCreateInfo
        /// <summary>
        /// Creates a new <see cref="PathCreateInfo"/> instance for mocking.
        /// </summary>
        public static PathCreateInfo PathCreateInfo(
            PathInfo pathInfo,
            string continuation)
            => new PathCreateInfo()
            {
                PathInfo = pathInfo,
                Continuation = continuation
            };
        #endregion PathCreateInfo

        #region PathInfo
        /// <summary>
        /// Creates a new <see cref="PathInfo"/> instance for mocking.
        /// </summary>
        public static PathInfo PathInfo(
            ETag eTag,
            DateTimeOffset lastModified)
            => new PathInfo()
            {
                ETag = eTag,
                LastModified = lastModified
            };
        #endregion PathInfo

        #region PathItem
        /// <summary>
        /// Creates a new PathItem instance for mocking.
        /// </summary>
        public static PathItem PathItem(
            string name,
            bool? isDirectory,
            DateTimeOffset lastModified,
            ETag eTag,
            long? contentLength,
            string owner,
            string group,
            string permissions,
            DateTimeOffset? createdOn,
            DateTimeOffset? expiresOn,
            string encryptionContext)
            => new PathItem()
            {
                Name = name,
                IsDirectory = isDirectory,
                LastModified = lastModified,
                ETag = eTag,
                ContentLength = contentLength,
                Owner = owner,
                Group = group,
                Permissions = permissions,
                CreatedOn = createdOn,
                ExpiresOn = expiresOn,
                EncryptionContext = encryptionContext
            };

        /// <summary>
        /// Creates a new PathItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PathItem PathItem(
            string name,
            bool? isDirectory,
            DateTimeOffset lastModified,
            ETag eTag,
            long? contentLength,
            string owner,
            string group,
            string permissions,
            DateTimeOffset? createdOn,
            DateTimeOffset? expiresOn)
            => new PathItem()
            {
                Name = name,
                IsDirectory = isDirectory,
                LastModified = lastModified,
                ETag = eTag,
                ContentLength = contentLength,
                Owner = owner,
                Group = group,
                Permissions = permissions,
                CreatedOn = createdOn,
                ExpiresOn = expiresOn
            };

        /// <summary>
        /// Creates a new PathItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PathItem PathItem(
            string name,
            bool? isDirectory,
            DateTimeOffset lastModified,
            ETag eTag,
            long? contentLength,
            string owner,
            string group,
            string permissions)
            => new PathItem()
            {
                Name = name,
                IsDirectory = isDirectory,
                LastModified = lastModified,
                ETag = eTag,
                ContentLength = contentLength,
                Owner = owner,
                Group = group,
                Permissions = permissions
            };
        #endregion PathItem

        #region PathProperties
        /// <summary>
        /// Creates a new PathProperties instance for mocking.
        /// </summary>
        public static PathProperties PathProperties(
            DateTimeOffset lastModified,
            DateTimeOffset creationTime,
            IDictionary<string, string> metadata,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            bool isIncrementalCopy,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string accessTier,
            string archiveStatus,
            DateTimeOffset accessTierChangeTime,
            bool isDirectory,
            string encryptionContext,
            string owner,
            string group,
            string permissions,
            IList<PathAccessControlItem> accessControlList)
            => new PathProperties()
            {
                LastModified = lastModified,
                CreatedOn = creationTime,
                Metadata = metadata,
                CopyCompletedOn = copyCompletionTime,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsIncrementalCopy = isIncrementalCopy,
                LeaseDuration = leaseDuration,
                LeaseState = leaseState,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                AcceptRanges = acceptRanges,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                AccessTier = accessTier,
                ArchiveStatus = archiveStatus,
                AccessTierChangedOn = accessTierChangeTime,
                IsDirectory = isDirectory,
                EncryptionContext = encryptionContext,
                Owner = owner,
                Group = group,
                Permissions = permissions,
                AccessControlList = accessControlList,
            };

        /// <summary>
        /// Creates a new PathProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PathProperties PathProperties(
            DateTimeOffset lastModified,
            DateTimeOffset creationTime,
            IDictionary<string, string> metadata,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            bool isIncrementalCopy,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string accessTier,
            string archiveStatus,
            DateTimeOffset accessTierChangeTime,
            bool isDirectory,
            string encryptionContext,
            string owner,
            string group,
            string permissions)
            => new PathProperties()
            {
                LastModified = lastModified,
                CreatedOn = creationTime,
                Metadata = metadata,
                CopyCompletedOn = copyCompletionTime,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsIncrementalCopy = isIncrementalCopy,
                LeaseDuration = leaseDuration,
                LeaseState = leaseState,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                AcceptRanges = acceptRanges,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                AccessTier = accessTier,
                ArchiveStatus = archiveStatus,
                AccessTierChangedOn = accessTierChangeTime,
                IsDirectory = isDirectory,
                EncryptionContext = encryptionContext,
                Owner = owner,
                Group = group,
                Permissions = permissions
            };

        /// <summary>
        /// Creates a new PathProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PathProperties PathProperties(
            DateTimeOffset lastModified,
            DateTimeOffset creationTime,
            IDictionary<string, string> metadata,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            bool isIncrementalCopy,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string accessTier,
            string archiveStatus,
            DateTimeOffset accessTierChangeTime,
            bool isDirectory,
            string encryptionContext)
            => new PathProperties()
            {
                LastModified = lastModified,
                CreatedOn = creationTime,
                Metadata = metadata,
                CopyCompletedOn = copyCompletionTime,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsIncrementalCopy = isIncrementalCopy,
                LeaseDuration = leaseDuration,
                LeaseState = leaseState,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                AcceptRanges = acceptRanges,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                AccessTier = accessTier,
                ArchiveStatus = archiveStatus,
                AccessTierChangedOn = accessTierChangeTime,
                IsDirectory = isDirectory,
                EncryptionContext = encryptionContext
            };

        /// <summary>
        /// Creates a new PathProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PathProperties PathProperties(
            DateTimeOffset lastModified,
            DateTimeOffset creationTime,
            IDictionary<string, string> metadata,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            bool isIncrementalCopy,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string accessTier,
            string archiveStatus,
            DateTimeOffset accessTierChangeTime,
            bool isDirectory)
            => new PathProperties()
            {
                LastModified = lastModified,
                CreatedOn = creationTime,
                Metadata = metadata,
                CopyCompletedOn = copyCompletionTime,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsIncrementalCopy = isIncrementalCopy,
                LeaseDuration = leaseDuration,
                LeaseState = leaseState,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                AcceptRanges = acceptRanges,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                AccessTier = accessTier,
                ArchiveStatus = archiveStatus,
                AccessTierChangedOn = accessTierChangeTime,
                IsDirectory = isDirectory
            };

        /// <summary>
        /// Creates a new PathProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PathProperties PathProperties(
            DateTimeOffset lastModified,
            DateTimeOffset creationTime,
            IDictionary<string, string> metadata,
            DateTimeOffset copyCompletionTime,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            bool isIncrementalCopy,
            DataLakeLeaseDuration leaseDuration,
            DataLakeLeaseState leaseState,
            DataLakeLeaseStatus leaseStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            string contentEncoding,
            string contentDisposition,
            string contentLanguage,
            string cacheControl,
            string acceptRanges,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string accessTier,
            string archiveStatus,
            DateTimeOffset accessTierChangeTime)
            => new PathProperties()
            {
                LastModified = lastModified,
                CreatedOn = creationTime,
                Metadata = metadata,
                CopyCompletedOn = copyCompletionTime,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsIncrementalCopy = isIncrementalCopy,
                LeaseDuration = leaseDuration,
                LeaseState = leaseState,
                LeaseStatus = leaseStatus,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CacheControl = cacheControl,
                AcceptRanges = acceptRanges,
                IsServerEncrypted = isServerEncrypted,
                EncryptionKeySha256 = encryptionKeySha256,
                AccessTier = accessTier,
                ArchiveStatus = archiveStatus,
                AccessTierChangedOn = accessTierChangeTime
            };
        #endregion PathProperties

        #region UserDelegationKey
        /// <summary>
        /// Creates a new <see cref="UserDelegationKey(string, string, DateTimeOffset, DateTimeOffset, string, string, string, string)"/> instance for mocking.
        /// </summary>
        public static UserDelegationKey UserDelegationKey(
            string signedObjectId = default,
            string signedTenantId = default,
            DateTimeOffset signedStart = default,
            DateTimeOffset signedExpiry = default,
            string signedService = default,
            string signedVersion = default,
            string signedDelegatedUserTenantId = default,
            string value = default)
            => new UserDelegationKey()
            {
                SignedObjectId = signedObjectId,
                SignedTenantId = signedTenantId,
                SignedStartsOn = signedStart,
                SignedExpiresOn = signedExpiry,
                SignedService = signedService,
                SignedVersion = signedVersion,
                Value = value,
                SignedDelegatedUserTenantId = signedDelegatedUserTenantId
            };

        /// <summary>
        /// Creates a new <see cref="UserDelegationKey(string, string, DateTimeOffset, DateTimeOffset, string, string, string)"/> instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UserDelegationKey UserDelegationKey(
            string signedObjectId,
            string signedTenantId,
            DateTimeOffset signedStart,
            DateTimeOffset signedExpiry,
            string signedService,
            string signedVersion,
            string value)
            => new UserDelegationKey()
            {
                SignedObjectId = signedObjectId,
                SignedTenantId = signedTenantId,
                SignedStartsOn = signedStart,
                SignedExpiresOn = signedExpiry,
                SignedService = signedService,
                SignedVersion = signedVersion,
                Value = value
            };
        #endregion UserDelegationKey

        #region DataLakeQueryError
        /// <summary>
        /// Creates a new BlobQueryError instance for mocking.
        /// </summary>
        public static DataLakeQueryError DataLakeQueryError(
            string name = default,
            string description = default,
            bool isFatal = default,
            long position = default)
            => new DataLakeQueryError
            {
                Name = name,
                Description = description,
                IsFatal = isFatal,
                Position = position
            };
        #endregion DataLakeQueryError

        #region GetPathTagResult
        /// <summary>
        /// Creates a new GetPathTagResult for mocking.
        /// </summary>
        // https://github.com/Azure/azure-sdk-for-net/issues/52168
        internal static GetPathTagResult GetPathTagResult(
            Tags tags)
            => new GetPathTagResult()
            {
                Tags = tags
            };
        #endregion GetPathTagResult
    }
}
