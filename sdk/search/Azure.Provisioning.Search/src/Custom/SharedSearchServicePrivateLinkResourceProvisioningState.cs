// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Search
{
    /// <summary> The provisioning state of the shared private link resource. </summary>
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
