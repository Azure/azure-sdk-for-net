// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Search
{
    /// <summary> Status of the shared private link resource. </summary>
    public enum SharedSearchServicePrivateLinkResourceStatus
    {
        /// <summary> Pending. </summary>
        Pending,
        /// <summary> Approved. </summary>
        Approved,
        /// <summary> Rejected. </summary>
        Rejected,
        /// <summary> Disconnected. </summary>
        Disconnected,
    }
}
