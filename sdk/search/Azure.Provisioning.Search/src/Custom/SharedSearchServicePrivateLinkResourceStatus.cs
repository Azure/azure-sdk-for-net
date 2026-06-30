// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Search
{
    /// <summary> Status of the shared private link resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchServiceSharedPrivateLinkResourceStatus instead.")]
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
