// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    public partial class MockableNetworkResourceGroupResource
    {
        // Keep the released historical names for binary compatibility.
        // The PrivateLinkService suffix is redundant; these aliases forward to the preferred shorter generated names.
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityByResourceGroup instead.")]
        public virtual ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityByResourceGroup(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public virtual CloudServiceSwapCollection GetCloudServiceSwaps(string cloudServiceName)
            => Client.GetCloudServiceSwaps(new ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}"));
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Response<CloudServiceSwapResource> GetCloudServiceSwap(string cloudServiceName, CancellationToken cancellationToken)
            => GetCloudServiceSwaps(cloudServiceName).Get(cancellationToken);
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityByResourceGroupAsync instead.")]
        public virtual Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityByResourceGroupAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwapAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<CloudServiceSwapResource>> GetCloudServiceSwapAsync(string cloudServiceName, CancellationToken cancellationToken)
            => await GetCloudServiceSwaps(cloudServiceName).GetAsync(cancellationToken).ConfigureAwait(false);
        // Preserve the released signatures from before the optional detailLevel parameter was introduced.
        // Supply its typed default to select the generated overloads without changing the supported behavior.
        /// <summary> Invokes the GetLoadBalancerAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<LoadBalancerResource>> GetLoadBalancerAsync(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
            => await GetLoadBalancerAsync(loadBalancerName, expand, default(LoadBalancerDetailLevel?), cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetLoadBalancer compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Response<LoadBalancerResource> GetLoadBalancer(string loadBalancerName, string expand = null, CancellationToken cancellationToken = default)
            => GetLoadBalancer(loadBalancerName, expand, default(LoadBalancerDetailLevel?), cancellationToken);

        // The previous GA exposed APIs for deprecated Cloud Service network interface operations. These members are retained solely to mitigate breaking changes; the operations are no longer generated or supported.
        /// <summary> Gets a collection of network interfaces for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual NetworkInterfaceCollection GetNetworkInterfaces(string cloudServiceName, string roleInstanceName)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets a network interface for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual Response<NetworkInterfaceResource> GetNetworkInterface(string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets a network interface for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual Task<Response<NetworkInterfaceResource>> GetNetworkInterfaceAsync(string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets all network interfaces for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual Pageable<NetworkInterfaceData> GetCloudServiceNetworkInterfaces(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets all network interfaces for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual AsyncPageable<NetworkInterfaceData> GetCloudServiceNetworkInterfacesAsync(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets all public IP addresses for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service public IP address operation is deprecated and no longer supported. There is no replacement.")]
        public virtual Pageable<PublicIPAddressData> GetCloudServicePublicIPAddresses(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service public IP address operation is deprecated and no longer supported.");

        /// <summary> Gets all public IP addresses for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service public IP address operation is deprecated and no longer supported. There is no replacement.")]
        public virtual AsyncPageable<PublicIPAddressData> GetCloudServicePublicIPAddressesAsync(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service public IP address operation is deprecated and no longer supported.");

        // String-location overloads were introduced in 1.16.0; alternateType restores the generated 1.15.0 AzureLocation APIs.
        // Retain the string signatures for released API and mocking compatibility, including their input validation.
        // Explicit AzureLocation construction selects the generated overload rather than recursing into these adapters.
        // Auto-approved private link adapters also preserve the shorter 1.16.0 names.
        /// <summary> Gets auto-approved private link services by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroupAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServicesAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Gets auto-approved private link services by resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices with an AzureLocation instead.")]
        public virtual Pageable<AutoApprovedPrivateLinkService> GetAutoApprovedPrivateLinkServicesByResourceGroup(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAutoApprovedPrivateLinkServicesByResourceGroupPrivateLinkServices(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableResourceGroupDelegationsAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableResourceGroupDelegationsAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AvailableDelegation> GetAvailableResourceGroupDelegationsAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableResourceGroupDelegationsAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableResourceGroupDelegations compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableResourceGroupDelegations with an AzureLocation instead.")]
        public virtual Pageable<AvailableDelegation> GetAvailableResourceGroupDelegations(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableResourceGroupDelegations(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailablePrivateEndpointTypesByResourceGroupAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypesByResourceGroupAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroupAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailablePrivateEndpointTypesByResourceGroupAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailablePrivateEndpointTypesByResourceGroup compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailablePrivateEndpointTypesByResourceGroup with an AzureLocation instead.")]
        public virtual Pageable<AvailablePrivateEndpointType> GetAvailablePrivateEndpointTypesByResourceGroup(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailablePrivateEndpointTypesByResourceGroup(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableServiceAliasesByResourceGroupAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliasesByResourceGroupAsync with an AzureLocation instead.")]
        public virtual AsyncPageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroupAsync(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableServiceAliasesByResourceGroupAsync(new AzureLocation(location), cancellationToken);
        }

        /// <summary> Invokes the GetAvailableServiceAliasesByResourceGroup compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated and it will be removed in a future version. Please use GetAvailableServiceAliasesByResourceGroup with an AzureLocation instead.")]
        public virtual Pageable<AvailableServiceAlias> GetAvailableServiceAliasesByResourceGroup(string location, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(location, nameof(location));
            return GetAvailableServiceAliasesByResourceGroup(new AzureLocation(location), cancellationToken);
        }
    }
}
