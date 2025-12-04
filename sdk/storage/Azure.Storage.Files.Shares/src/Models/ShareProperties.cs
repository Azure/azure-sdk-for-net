// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Properties of a share.
    /// </summary>
    public class ShareProperties
    {
        /// <summary>
        /// Last-Modified.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Etag.
        /// </summary>
        public ETag? ETag { get; internal set; }

        /// <summary>
        /// ProvisionedIops.
        /// </summary>
        public int? ProvisionedIops { get; internal set; }

        /// <summary>
        /// ProvisionedIngressMBps.
        /// This property is deprecated.  See <see cref="ProvisionedBandwidthMiBps"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ProvisionedIngressMBps { get; internal set; }

        /// <summary>
        /// ProvisionedEgressMBps.
        /// This property is deprecated.  See <see cref="ProvisionedBandwidthMiBps"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ProvisionedEgressMBps { get; internal set; }

        /// <summary>
        /// Provisioned bandwidth in metabits/second.
        /// Only applicable to premium file accounts.
        /// </summary>
        public int? ProvisionedBandwidthMiBps { get; internal set;  }

        /// <summary>
        /// NextAllowedQuotaDowngradeTime.
        /// </summary>
        public DateTimeOffset? NextAllowedQuotaDowngradeTime { get; internal set; }

        /// <summary>
        /// DeletedTime.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// RemainingRetentionDays.
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// AccessTier.
        /// </summary>
        public string AccessTier { get; internal set; }

        /// <summary>
        /// AccessTierChangeTime.
        /// </summary>
        public DateTimeOffset? AccessTierChangeTime { get; internal set; }

        /// <summary>
        /// AccessTierTransitionState.
        /// </summary>
        public string AccessTierTransitionState { get; internal set; }

        /// <summary>
        /// The current lease status of the share.
        /// </summary>
        public ShareLeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// Lease state of the share.
        /// </summary>
        public ShareLeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// When a share is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public ShareLeaseDuration? LeaseDuration { get; internal set; }

        /// <summary>
        /// EnabledProtocols.
        /// </summary>
        public ShareProtocols? Protocols { get; internal set; }

        /// <summary>
        /// RootSquash.
        /// </summary>
        public ShareRootSquash? RootSquash { get; internal set; }

        /// <summary>
        /// QuotaInGB.
        /// </summary>
        public int? QuotaInGB { get; internal set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Optional. Supported in version 2023-08-03 and above.  Only applicable for premium file storage accounts.
        /// Specifies whether the snapshot virtual directory should be accessible at the root of share mount point when NFS is enabled.
        /// If not specified, the default is true.
        /// </summary>
        public bool? EnableSnapshotVirtualDirectoryAccess { get; internal set; }

        /// <summary>
        ///  Optional. Supported in version 2024-11-04 and above.  Only applicable for premium file storage accounts.
        ///  This property enables paid bursting on premium file storage accounts.
        /// </summary>
        public bool? EnablePaidBursting { get; internal set; }

        /// <summary>
        ///  Optional. Supported in version 2024-11-04 and above.  Only applicable for premium file storage accounts.
        ///  Default if not specified is the maximum IOPS the file share can support. Current maximum for a file share is 102,400 IOPS.
        /// </summary>
        public long? PaidBurstingMaxIops { get; internal set; }

        /// <summary>
        ///  Optional. Supported in version 2024-11-04 and above.  Only applicable for premium file storage accounts.
        ///  Default if not specified is the maximum throughput the file share can support. Current maximum for a file share is 10,340 MiB/sec.
        /// </summary>
        public long? PaidBurstingMaxBandwidthMibps { get; internal set; }

        /// <summary>
        /// Only applicable to provisioned v2 storage accounts.
        /// The calculated burst IOPS of the share.
        /// </summary>
        public long? IncludedBurstIops { get; internal set; }

        /// <summary>
        /// Only applicable to provisioned v2 storage accounts.
        /// The calculated maximum burst credits. This is not the current burst credit level, but the maximum burst credits the share can have.
        /// </summary>
        public long? MaxBurstCreditsForIops { get; internal set; }

        /// <summary>
        /// Only applicable to provisioned v2 storage accounts.
        /// The time the share can be downgraded to lower provisioned IOPs.
        /// </summary>
        public DateTimeOffset? NextAllowedProvisionedIopsDowngradeTime { get; internal set; }

        /// <summary>
        /// Only applicable to provisioned v2 storage accounts.
        /// The time the shaare can be downgraded to lower provisioned bandwidth.
        /// </summary>
        public DateTimeOffset? NextAllowedProvisionedBandwidthDowngradeTime { get; internal set; }

        ///// <summary>
        ///// Optional, default value is true.  Ony applicable to SMB shares.
        ///// Specifies whether granting of new directory leases for directories present in a share are to be enabled or disabled.
        ///// An input of true specifies that granting of new directory leases is to be allowed.
        ///// An input of false specifies that granting of new directory leases is to be blocked.
        ///// </summary>
        //public bool? EnableDirectoryLease { get; internal set; }

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal ShareProperties() { }
    }
}
