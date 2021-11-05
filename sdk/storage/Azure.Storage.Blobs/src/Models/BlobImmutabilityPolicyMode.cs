// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// The BlobImmutabilityPolicyMode.
    /// </summary>
    public enum BlobImmutabilityPolicyMode
    {
        /// <summary>
        /// Blob does not have an immutability policy.
        /// </summary>
        Mutable,

        /// <summary>
        /// Blob has an unlocked immutability policy.
        /// This means the immutability policy can be modified or deleted.
        /// </summary>
        Unlocked,

        /// <summary>
        /// Blob has a locked immutability policy.
        /// This means the immutability policy cannot be modified or deleted until
        /// it expires.
        /// </summary>
        Locked
    }
}
