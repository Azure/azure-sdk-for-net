// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Search.Models
{
    public partial class SharedSearchServicePrivateLinkResourceProperties
    {
        /// <summary> Status of the shared private link resource. </summary>
        [WirePath("status")]
        public SearchServiceSharedPrivateLinkResourceStatus? Status { get; set; }

        /// <summary> The provisioning state of the shared private link resource. </summary>
        [WirePath("provisioningState")]
        public SearchServiceSharedPrivateLinkResourceProvisioningState? ProvisioningState { get; set; }

        /// <summary> Status of the shared private link resource (backward compat alias). </summary>
        [WirePath("status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServiceSharedPrivateLinkResourceStatus? SharedPrivateLinkResourceStatus
        {
            get => Status;
            set => Status = value;
        }

        /// <summary> The provisioning state of the shared private link resource (backward compat alias). </summary>
        [WirePath("provisioningState")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchServiceSharedPrivateLinkResourceProvisioningState? SharedPrivateLinkResourceProvisioningState
        {
            get => ProvisioningState;
            set => ProvisioningState = value;
        }

        /// <summary> The resource ID of the resource the shared private link resource is for. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier PrivateLinkResourceIdentifier
        {
            get => PrivateLinkResourceId != null ? new ResourceIdentifier(PrivateLinkResourceId) : null;
            set => PrivateLinkResourceId = value?.ToString();
        }

        /// <summary> Optional. Can be used to specify the Azure Resource Manager location of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureLocation? ResourceAzureLocation
        {
            get => ResourceRegion != null ? new AzureLocation(ResourceRegion) : null;
            set => ResourceRegion = value?.ToString();
        }
    }
}
