// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Blobs.Models
{
    /// <summary> The status of the secondary location. </summary>
    public enum BlobGeoReplicationStatus
    {
        /// <summary> live. </summary>
        Live,
        /// <summary> bootstrap. </summary>
        Bootstrap,
        /// <summary> unavailable. </summary>
        Unavailable
    }
}
