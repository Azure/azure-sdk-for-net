// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

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
        /// ProvisionedIngressMBps
        /// </summary>
        public int? ProvisionedIngressMBps { get; internal set; }

        /// <summary>
        /// ProvisionedEgressMBps.
        /// </summary>
        public int? ProvisionedEgressMBps { get; internal set; }

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
        /// Internal constructor.
        /// </summary>
        internal ShareProperties() { }
    }
}
