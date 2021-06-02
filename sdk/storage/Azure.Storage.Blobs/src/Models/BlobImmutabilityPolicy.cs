// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for setting the Immutability Policy of a Blob, Blob Snapshot, or Blob Version.
    /// </summary>
    public class BlobImmutabilityPolicy
    {
        /// <summary>
        /// The date and time when the Immutability Policy expires.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; set; }

        /// <summary>
        /// The mode of the Immutability Policy.  Valid values are <see cref="BlobImmutabilityPolicyMode.Locked"/> and
        /// <see cref="BlobImmutabilityPolicyMode.Unlocked"/>.
        /// </summary>
        public BlobImmutabilityPolicyMode? PolicyMode { get; set; }
    }
}
