// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary> The ArchiveStatus. </summary>
    public enum ArchiveStatus
    {
        /// <summary> rehydrate-pending-to-hot. </summary>
        RehydratePendingToHot,
        /// <summary> rehydrate-pending-to-cool. </summary>
        RehydratePendingToCool,
        /// <summary> rehydrate-pending-to-cold. </summary>
        RehydratePendingToCold
    }
}
