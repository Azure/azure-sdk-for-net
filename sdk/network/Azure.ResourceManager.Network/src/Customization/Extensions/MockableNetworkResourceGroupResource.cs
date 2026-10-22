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
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibility instead.")]
        public virtual ArmOperation<PrivateLinkServiceVisibility> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkService(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => CheckPrivateLinkServiceVisibility(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
        /// <summary> Invokes the GetCloudServiceSwaps compatibility operation. </summary>
        public virtual CloudServiceSwapCollection GetCloudServiceSwaps(string cloudServiceName)
            => Client.GetCloudServiceSwaps(new ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}"));
        /// <summary> Invokes the GetCloudServiceSwap compatibility operation. </summary>
        [ForwardsClientCalls]
        public virtual Response<CloudServiceSwapResource> GetCloudServiceSwap(string cloudServiceName, CancellationToken cancellationToken)
            => GetCloudServiceSwaps(cloudServiceName).Get(cancellationToken);
        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public virtual Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);
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
    }
}
