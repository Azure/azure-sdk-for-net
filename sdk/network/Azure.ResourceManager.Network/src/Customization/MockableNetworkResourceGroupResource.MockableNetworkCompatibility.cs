// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkResourceGroupResource
    {
        public virtual AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesByResourceGroupAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices(AzureLocation location, CancellationToken cancellationToken)
            => GetAutoApprovedPrivateLinkServicesByResourceGroup(location.ToString(), cancellationToken);

        public virtual AsyncPageable<AvailableDelegation> GetAvailableResourceGroupDelegationsAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableResourceGroupDelegationsAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AvailableDelegation> GetAvailableResourceGroupDelegations(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableResourceGroupDelegations(location.ToString(), cancellationToken);

        public virtual AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroupAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesByResourceGroupAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroup(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailablePrivateEndpointTypesByResourceGroup(location.ToString(), cancellationToken);

        public virtual AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroupAsync(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesByResourceGroupAsync(location.ToString(), cancellationToken);

        public virtual Pageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroup(AzureLocation location, CancellationToken cancellationToken)
            => GetAvailableServiceAliasesByResourceGroup(location.ToString(), cancellationToken);
    }
}
