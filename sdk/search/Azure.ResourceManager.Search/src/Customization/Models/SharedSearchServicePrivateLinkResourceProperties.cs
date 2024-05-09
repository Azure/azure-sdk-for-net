// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    /// <summary> Describes the properties of an existing Shared Private Link Resource managed by the search service. </summary>
    public partial class SharedSearchServicePrivateLinkResourceProperties
    {
        /// <summary> Status of the shared private link resource. Valid values are Pending, Approved, Rejected or Disconnected. </summary>
        [WirePath("status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SharedSearchServicePrivateLinkResourceStatus? Status
        {
            get => SharedPrivateLinkResourceStatus.ToString().ToSharedSearchServicePrivateLinkResourceStatus();
            set => SharedPrivateLinkResourceStatus = value?.ToSerialString();
        }
        /// <summary> The provisioning state of the shared private link resource. Valid values are Updating, Deleting, Failed, Succeeded or Incomplete. </summary>
        [WirePath("provisioningState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SharedSearchServicePrivateLinkResourceProvisioningState? ProvisioningState
        {
            get => SharedPrivateLinkResourceProvisioningState.ToString().ToSharedSearchServicePrivateLinkResourceProvisioningState();
            set => SharedPrivateLinkResourceProvisioningState = value?.ToSerialString();
        }
    }
}
