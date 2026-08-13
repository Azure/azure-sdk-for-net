// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;
using Azure.ResourceManager.ContainerInstance.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ContainerInstance
{
    public static partial class ContainerInstanceExtensions
    {
        // Backward-compat shims: prior generator exposed DeleteSubnetServiceAssociationLink as a ResourceGroupResource
        // extension taking (virtualNetworkName, subnetName). The new generator scopes the operation to a subnet
        // ResourceIdentifier on ArmClient. These shims forward to the resource-group mockable so the legacy public
        // API surface continues to compile.
        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupResource));
            }
            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).DeleteSubnetServiceAssociationLinkAsync(waitUntil, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> instance the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ArmOperation DeleteSubnetServiceAssociationLink(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            if (resourceGroupResource == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupResource));
            }
            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).DeleteSubnetServiceAssociationLink(waitUntil, virtualNetworkName, subnetName, cancellationToken);
        }
    }
}
