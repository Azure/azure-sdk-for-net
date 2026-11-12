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

        // The released resource-group owner accepts a cloud service name; native access requires its Compute scope ID.
        // Keep the virtual entry points while delegating collection and singleton operations to the native collection.
        /// <summary> Gets the swap collection for the specified cloud service. </summary>
        public virtual CloudServiceSwapCollection GetCloudServiceSwaps(string resourceName)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            return Client.GetCloudServiceSwaps(new ResourceIdentifier($"{Id}/providers/Microsoft.Compute/cloudServices/{resourceName}"));
        }

        /// <summary> Gets the swap resource for the specified cloud service. </summary>
        [ForwardsClientCalls]
        public virtual Response<CloudServiceSwapResource> GetCloudServiceSwap(string resourceName, CancellationToken cancellationToken = default)
            => GetCloudServiceSwaps(resourceName).Get(cancellationToken);

        /// <summary> Invokes the CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use CheckPrivateLinkServiceVisibilityAsync instead.")]
        public virtual Task<ArmOperation<PrivateLinkServiceVisibility>> CheckPrivateLinkServiceVisibilityByResourceGroupPrivateLinkServiceAsync(WaitUntil waitUntil, AzureLocation location, CheckPrivateLinkServiceVisibilityRequest checkPrivateLinkServiceVisibilityRequest, CancellationToken cancellationToken = default)
            => CheckPrivateLinkServiceVisibilityAsync(waitUntil, location, checkPrivateLinkServiceVisibilityRequest, cancellationToken);

        /// <summary> Gets the swap resource for the specified cloud service. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<CloudServiceSwapResource>> GetCloudServiceSwapAsync(string resourceName, CancellationToken cancellationToken = default)
            => GetCloudServiceSwaps(resourceName).GetAsync(cancellationToken);
    }
}
