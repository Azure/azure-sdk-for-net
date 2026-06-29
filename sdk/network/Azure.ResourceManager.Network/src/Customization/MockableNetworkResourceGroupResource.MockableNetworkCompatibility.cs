// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkResourceGroupResource type. </summary>
    public partial class MockableNetworkResourceGroupResource
    {
        /// <summary> Invokes the GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync compatibility operation. </summary>
        public virtual AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesByResourceGroupAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices compatibility operation. </summary>
        public virtual Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesByResourceGroup(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableResourceGroupDelegationsAsync compatibility operation. </summary>
        public virtual AsyncPageable<AvailableDelegation> GetAvailableResourceGroupDelegationsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableResourceGroupDelegationsAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableResourceGroupDelegations compatibility operation. </summary>
        public virtual Pageable<AvailableDelegation> GetAvailableResourceGroupDelegations(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableResourceGroupDelegations(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailablePrivateEndpointTypesByResourceGroupAsync compatibility operation. </summary>
        public virtual AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroupAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesByResourceGroupAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailablePrivateEndpointTypesByResourceGroup compatibility operation. </summary>
        public virtual Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroup(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesByResourceGroup(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableServiceAliasesByResourceGroupAsync compatibility operation. </summary>
        public virtual AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroupAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesByResourceGroupAsync(location.ToString(), cancellationToken);

        /// <summary> Invokes the GetAvailableServiceAliasesByResourceGroup compatibility operation. </summary>
        public virtual Pageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroup(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesByResourceGroup(location.ToString(), cancellationToken);
    }
}
