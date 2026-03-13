// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Search.Models
{
    // Backward-compat wrapper properties that expose Status and ProvisioningState
    // as custom enums instead of the generated readonly structs.
    public partial class SharedSearchServicePrivateLinkResourceProperties
    {
        /// <summary> Status of the shared private link resource. Valid values are Pending, Approved, Rejected or Disconnected. </summary>
        [WirePath("status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServiceSharedPrivateLinkResourceStatus? Status { get; set; }

        /// <summary> The provisioning state of the shared private link resource. Valid values are Updating, Deleting, Failed, Succeeded or Incomplete. </summary>
        [WirePath("provisioningState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServiceSharedPrivateLinkResourceProvisioningState? ProvisioningState { get; set; }
    }
}