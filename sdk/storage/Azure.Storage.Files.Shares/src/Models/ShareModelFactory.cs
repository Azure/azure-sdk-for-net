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
        /// Creates a new FileLeaseReleaseInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileLeaseReleaseInfo FileLeaseReleaseInfo(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified)
        {
            return new FileLeaseReleaseInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
            };
        }

        /// <summary>
        /// Creates a new ShareFileLease instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareFileLease ShareFileLease(
            Azure.ETag eTag,
            System.DateTimeOffset lastModified,
            string leaseId)
        {
            return new ShareFileLease()
            {
                ETag = eTag,
                LastModified = lastModified,
                LeaseId = leaseId,
            };
        }
    }
}
