// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceResourceGroupResource
    {
        // Backward-compat shim: prior generator exposed DeleteSubnetServiceAssociationLink on the resource group
        // mockable. The new generator classifies the operation as an extension non-resource method scoped to a
        // subnet ResourceIdentifier and exposes it on MockableContainerInstanceArmClient. These shims preserve the
        // legacy API surface by constructing the subnet scope from the current resource group identifier and
        // forwarding to the new ArmClient-scoped implementation.
        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier scope = SubnetResourceIdentifier(virtualNetworkName, subnetName);
            return await GetArmClientMockable().DeleteSubnetServiceAssociationLinkAsync(waitUntil, scope, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation DeleteSubnetServiceAssociationLink(WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            ResourceIdentifier scope = SubnetResourceIdentifier(virtualNetworkName, subnetName);
            return GetArmClientMockable().DeleteSubnetServiceAssociationLink(waitUntil, scope, cancellationToken);
        }

        private MockableContainerInstanceArmClient GetArmClientMockable()
        {
            return Client.GetCachedClient(c => new MockableContainerInstanceArmClient(c, ResourceIdentifier.Root));
        }

        private ResourceIdentifier SubnetResourceIdentifier(string virtualNetworkName, string subnetName)
        {
            return new ResourceIdentifier($"{Id}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}");
        }
    }
}
