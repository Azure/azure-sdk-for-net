﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    public static partial class ShareModelFactory
    {
        /// <summary>
        /// Creates a new StorageClosedHandlesSegment instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageClosedHandlesSegment StorageClosedHandlesSegment(
            string marker,
            int numberOfHandlesClosed)
            => StorageClosedHandlesSegment(
                marker: marker,
                numberOfHandlesClosed: numberOfHandlesClosed);

        /// <summary>
        /// Creates a new ShareProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareProperties ShareProperties(
            DateTimeOffset? lastModified,
            ETag? eTag,
            int? provisionedIops,
            int? provisionedIngressMBps,
            int? provisionedEgressMBps,
            DateTimeOffset? nextAllowedQuotaDowngradeTime,
            DateTimeOffset? deletedOn,
            int? remainingRetentionDays,
            int? quotaInGB,
            IDictionary<string, string> metadata)
            => new ShareProperties()
            {
                LastModified = lastModified,
                ETag = eTag,
                ProvisionedIops = provisionedIops,
                ProvisionedIngressMBps = provisionedIngressMBps,
                ProvisionedEgressMBps = provisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = nextAllowedQuotaDowngradeTime,
                DeletedOn = deletedOn,
                RemainingRetentionDays = remainingRetentionDays,
                QuotaInGB = quotaInGB,
                Metadata = metadata,
            };

        /// <summary>
        /// Creates a new ShareProperties instance for mocking.
        /// </summary>
        public static ShareProperties ShareProperties(
            string accessTier = default,
            DateTimeOffset? lastModified = default,
            int? provisionedIops = default,
            int? provisionedIngressMBps = default,
            int? provisionedEgressMBps = default,
            DateTimeOffset? nextAllowedQuotaDowngradeTime = default,
            DateTimeOffset? deletedOn = default,
            int? remainingRetentionDays = default,
            ETag? eTag = default,
            DateTimeOffset? accessTierChangeTime = default,
            string accessTierTransitionState = default,
            ShareLeaseStatus? leaseStatus = default,
            ShareLeaseState? leaseState = default,
            ShareLeaseDuration? leaseDuration = default,
            int? quotaInGB = default,
            IDictionary<string, string> metadata = default,
            ShareProtocols? protocols = default,
            ShareRootSquash? rootSquash = default)
            => new ShareProperties()
            {
                AccessTier = accessTier,
                LastModified = lastModified,
                ProvisionedIops = provisionedIops,
                ProvisionedIngressMBps = provisionedIngressMBps,
                ProvisionedEgressMBps = provisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = nextAllowedQuotaDowngradeTime,
                DeletedOn = deletedOn,
                RemainingRetentionDays = remainingRetentionDays,
                ETag = eTag,
                AccessTierChangeTime = accessTierChangeTime,
                AccessTierTransitionState = accessTierTransitionState,
                LeaseStatus = leaseStatus,
                LeaseState = leaseState,
                LeaseDuration = leaseDuration,
                QuotaInGB = quotaInGB,
                Metadata = metadata,
                Protocols = protocols,
                RootSquash = rootSquash
            };

        /// <summary>
        /// Creates a new ShareProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareProperties ShareProperties(
            string accessTier,
            DateTimeOffset? lastModified,
            int? provisionedIops,
            int? provisionedIngressMBps,
            int? provisionedEgressMBps,
            DateTimeOffset? nextAllowedQuotaDowngradeTime,
            DateTimeOffset? deletedOn,
            int? remainingRetentionDays,
            ETag? eTag,
            DateTimeOffset? accessTierChangeTime,
            string accessTierTransitionState,
            ShareLeaseStatus? leaseStatus,
            ShareLeaseState? leaseState,
            ShareLeaseDuration? leaseDuration,
            int? quotaInGB,
            IDictionary<string, string> metadata)
            => new ShareProperties()
            {
                AccessTier = accessTier,
                LastModified = lastModified,
                ProvisionedIops = provisionedIops,
                ProvisionedIngressMBps = provisionedIngressMBps,
                ProvisionedEgressMBps = provisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = nextAllowedQuotaDowngradeTime,
                DeletedOn = deletedOn,
                RemainingRetentionDays = remainingRetentionDays,
                ETag = eTag,
                AccessTierChangeTime = accessTierChangeTime,
                AccessTierTransitionState = accessTierTransitionState,
                LeaseStatus = leaseStatus,
                LeaseState = leaseState,
                LeaseDuration = leaseDuration,
                QuotaInGB = quotaInGB,
                Metadata = metadata,
            };

        /// <summary>
        /// Creates a new ShareProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareProperties ShareProperties(
            DateTimeOffset? lastModified,
            ETag? eTag,
            int? provisionedIops,
            int? provisionedIngressMBps,
            int? provisionedEgressMBps,
            DateTimeOffset? nextAllowedQuotaDowngradeTime,
            int? quotaInGB,
            IDictionary<string, string> metadata)
            => new ShareProperties()
            {
                LastModified = lastModified,
                ETag = eTag,
                ProvisionedIops = provisionedIops,
                ProvisionedIngressMBps = provisionedIngressMBps,
                ProvisionedEgressMBps = provisionedEgressMBps,
                NextAllowedQuotaDowngradeTime = nextAllowedQuotaDowngradeTime,
                QuotaInGB = quotaInGB,
                Metadata = metadata,
            };

        /// <summary>
        /// Creates a new ShareProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareProperties ShareProperties(
            DateTimeOffset? lastModified,
            ETag? eTag,
            int? quotaInGB,
            IDictionary<string, string> metadata)
            => ShareProperties(
                lastModified: lastModified,
                eTag: eTag,
                quotaInGB: quotaInGB,
                metadata: metadata);

        /// <summary>
        /// Creates a new ShareItem instance for mocking.
        /// </summary>
        public static ShareItem ShareItem(
            string name,
            ShareProperties properties,
            string snapshot = null,
            bool? isDeleted = null,
            string versionId = null)
        {
            return new ShareItem()
            {
                Name = name,
                Properties = properties,
                Snapshot = snapshot,
                IsDeleted = isDeleted,
                VersionId = versionId
            };
        }

        /// <summary>
        /// Creates a new ShareItem instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareItem ShareItem(
            string name,
            ShareProperties properties,
            string snapshot)
        {
            return new ShareItem()
            {
                Name = name,
                Properties = properties,
                Snapshot = snapshot,
            };
        }

        /// <summary>
        /// Creates a new ShareFileHandle instance for mocking.
        /// </summary>
        public static ShareFileHandle ShareFileHandle(
            string handleId,
            string path,
            string fileId,
            string sessionId,
            string clientIp,
            string parentId = default,
            DateTimeOffset? openedOn = default,
            DateTimeOffset? lastReconnectedOn = default)
            =>  new ShareFileHandle(
                handleId,
                path,
                fileId,
                parentId,
                sessionId,
                clientIp,
                openedOn,
                lastReconnectedOn);

        /// <summary>
        /// Creates a new ShareFileCopyInfo instance for mocking.
        /// </summary>
        public static ShareFileCopyInfo ShareFileCopyInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            string copyId,
            CopyStatus copyStatus)
        {
            return new ShareFileCopyInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                CopyId = copyId,
                CopyStatus = copyStatus,
            };
        }

        /// <summary>
        /// Creates a new PermissionInfo instance for mocking.
        /// </summary>
        public static PermissionInfo PermissionInfo(
            string filePermissionKey)
        {
            return new PermissionInfo()
            {
                FilePermissionKey = filePermissionKey,
            };
        }

        /// <summary>
        /// Creates a new ShareFileLease instance for mocking.
        /// </summary>
        public static ShareFileLease ShareFileLease(
            ETag eTag,
            DateTimeOffset lastModified,
            string leaseId)
        {
            return new ShareFileLease()
            {
                ETag = eTag,
                LastModified = lastModified,
                LeaseId = leaseId,
            };
        }

        /// <summary>
        /// Creates a new ShareFileUploadInfo instance for mocking.
        /// </summary>
        public static ShareFileUploadInfo ShareFileUploadInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            byte[] contentHash,
            bool isServerEncrypted)
        {
            return new ShareFileUploadInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                ContentHash = contentHash,
                IsServerEncrypted = isServerEncrypted,
            };
        }

        /// <summary>
        /// Creates a new ShareInfo instance for mocking.
        /// </summary>
        public static ShareInfo ShareInfo(
            ETag eTag,
            DateTimeOffset lastModified)
        {
            return new ShareInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }

        /// <summary>
        /// Creates a new ShareSnapshotInfo instance for mocking.
        /// </summary>
        public static ShareSnapshotInfo ShareSnapshotInfo(
            string snapshot,
            ETag eTag,
            DateTimeOffset lastModified)
        {
            return new ShareSnapshotInfo()
            {
                Snapshot = snapshot,
                ETag = eTag,
                LastModified = lastModified,
            };
        }

        /// <summary>
        /// Creates a new ShareStatistics instance for mocking.
        /// </summary>
        public static ShareStatistics ShareStatistics(
            long shareUsageInBytes)
        {
            return new ShareStatistics()
            {
                ShareUsageInBytes = shareUsageInBytes,
            };
        }

        /// <summary>
        /// Creates a new StorageClosedHandlesSegment instance for mocking.
        /// </summary>
        public static StorageClosedHandlesSegment StorageClosedHandlesSegment(
            string marker,
            int numberOfHandlesClosed,
            int numberOfHandlesFailedToClose)
        {
            return new StorageClosedHandlesSegment()
            {
                Marker = marker,
                NumberOfHandlesClosed = numberOfHandlesClosed,
                NumberOfHandlesFailedToClose = numberOfHandlesFailedToClose,
            };
        }

        /// <summary>
        /// Creates a new FileLeaseReleaseInfo instance for mocking.
        /// </summary>
        public static FileLeaseReleaseInfo FileLeaseReleaseInfo(
            ETag eTag,
            DateTimeOffset lastModified)
        {
            return new FileLeaseReleaseInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }
    }
}
