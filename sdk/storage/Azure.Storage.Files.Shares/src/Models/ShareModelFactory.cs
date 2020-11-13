// Copyright (c) Microsoft Corporation. All rights reserved.
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
                numberOfHandlesClosed: numberOfHandlesClosed,
                numberOfHandlesFailedToClose: 0);

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
    }
}
