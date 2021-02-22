// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Properties of a container.
    /// </summary>
    public class BlobContainerProperties
    {
        /// <summary>
        /// Last-Modified.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// LeaseStatus.
        /// </summary>
        public LeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// LeaseState.
        /// </summary>
        public LeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// LeaseDuration.
        /// </summary>
        public LeaseDurationType? LeaseDuration { get; internal set; }

        /// <summary>
        /// PublicAccess.
        /// </summary>
        public PublicAccessType? PublicAccess { get; internal set; }

        /// <summary>
        /// HasImmutabilityPolicy.
        /// </summary>
        public bool? HasImmutabilityPolicy { get; internal set; }

        /// <summary>
        /// HasLegalHold.
        /// </summary>
        public bool? HasLegalHold { get; internal set; }

        /// <summary>
        /// DefaultEncryptionScope.
        /// </summary>
        public string DefaultEncryptionScope { get; internal set; }

        /// <summary>
        /// DenyEncryptionScopeOverride.
        /// </summary>
        public bool? PreventEncryptionScopeOverride { get; internal set; }

        /// <summary>
        /// DeletedTime.
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// RemainingRetentionDays.
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// ETag.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Creates a new BlobContainerProperties instance.
        /// </summary>
        internal BlobContainerProperties()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new BlobContainerProperties instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal BlobContainerProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Metadata = new System.Collections.Generic.Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            }
        }
    }
}
