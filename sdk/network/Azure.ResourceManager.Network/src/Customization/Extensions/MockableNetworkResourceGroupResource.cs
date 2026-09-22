// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for the MockableNetworkResourceGroupResource type. </summary>
    public partial class MockableNetworkResourceGroupResource
    {
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, global::System.Threading.CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityByResourceGroup(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public virtual global::Azure.ResourceManager.Network.CloudServiceSwapCollection GetCloudServiceSwaps(global::System.String cloudServiceName)
            => Client.GetCloudServiceSwaps(new global::Azure.Core.ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}"));
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource> GetCloudServiceSwap(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => GetCloudServiceSwaps(cloudServiceName).Get(cancellationToken);
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync compatibility operation. </summary>
        public virtual global::System.Threading.Tasks.Task<global::Azure.ResourceManager.ArmOperation<global::Azure.ResourceManager.Network.Models.PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(global::Azure.WaitUntil waitUntil, global::Azure.Core.AzureLocation location, global::Azure.ResourceManager.Network.Models.CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, global::System.Threading.CancellationToken cancellationToken)
            => CheckPrivateLinkServiceVisibilityByResourceGroupAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwapAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.CloudServiceSwapResource>> GetCloudServiceSwapAsync(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken)
            => await GetCloudServiceSwaps(cloudServiceName).GetAsync(cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetLoadBalancerAsync compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual async global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource>> GetLoadBalancerAsync(global::System.String loadBalancerName, global::System.String expand = null, global::System.Threading.CancellationToken cancellationToken = default)
            => await GetLoadBalancerAsync(loadBalancerName, expand, default(global::Azure.ResourceManager.Network.Models.LoadBalancerDetailLevel?), cancellationToken).ConfigureAwait(false);
        /// <summary> Invokes the GetLoadBalancer compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.LoadBalancerResource> GetLoadBalancer(global::System.String loadBalancerName, global::System.String expand = null, global::System.Threading.CancellationToken cancellationToken = default)
            => GetLoadBalancer(loadBalancerName, expand, default(global::Azure.ResourceManager.Network.Models.LoadBalancerDetailLevel?), cancellationToken);

        // The previous GA exposed APIs for deprecated Cloud Service network interface operations. These members are retained solely to mitigate breaking changes; the operations are no longer generated or supported.
        /// <summary> Gets a collection of network interfaces for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::Azure.ResourceManager.Network.NetworkInterfaceCollection GetNetworkInterfaces(global::System.String cloudServiceName, global::System.String roleInstanceName)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets a network interface for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceResource> GetNetworkInterface(global::System.String cloudServiceName, global::System.String roleInstanceName, global::System.String networkInterfaceName, global::System.String expand = null, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets a network interface for a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Azure.ResourceManager.Network.NetworkInterfaceResource>> GetNetworkInterfaceAsync(global::System.String cloudServiceName, global::System.String roleInstanceName, global::System.String networkInterfaceName, global::System.String expand = null, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets all network interfaces for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.NetworkInterfaceData> GetCloudServiceNetworkInterfaces(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets all network interfaces for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service network interface operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.NetworkInterfaceData> GetCloudServiceNetworkInterfacesAsync(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service network interface operation is deprecated and no longer supported.");

        /// <summary> Gets all public IP addresses for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service public IP address operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::Azure.Pageable<global::Azure.ResourceManager.Network.PublicIPAddressData> GetCloudServicePublicIPAddresses(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service public IP address operation is deprecated and no longer supported.");

        /// <summary> Gets all public IP addresses for a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete because the Cloud Service public IP address operation is deprecated and no longer supported. There is no replacement.")]
        public virtual global::Azure.AsyncPageable<global::Azure.ResourceManager.Network.PublicIPAddressData> GetCloudServicePublicIPAddressesAsync(global::System.String cloudServiceName, global::System.Threading.CancellationToken cancellationToken = default)
            => throw new NotSupportedException("The Cloud Service public IP address operation is deprecated and no longer supported.");
    }
}
