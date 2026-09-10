// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Search
{
    /// <summary> The provisioning state of the shared private link resource. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchServiceSharedPrivateLinkResourceProvisioningState instead.")]
    public enum SharedSearchServicePrivateLinkResourceProvisioningState
    {
        /// <summary> Updating. </summary>
        Updating,
        /// <summary> Deleting. </summary>
        Deleting,
        /// <summary> Failed. </summary>
        Failed,
        /// <summary> Succeeded. </summary>
        Succeeded,
        /// <summary> Incomplete. </summary>
        Incomplete,
    }
}
