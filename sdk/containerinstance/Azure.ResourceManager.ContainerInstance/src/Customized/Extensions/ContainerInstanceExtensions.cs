// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ContainerInstance
{
    // Workaround for generator bug https://github.com/Azure/azure-sdk-for-net/issues/58204:
    // DeleteSubnetServiceAssociationLink is generated on SubscriptionResource scope instead of
    // ResourceGroupResource scope due to case-sensitive route matching ("/resourcegroups/" vs "/resourceGroups/").
    // We suppress the incorrect extension methods and add correct ones on ResourceGroupResource.
    [CodeGenSuppress("DeleteSubnetServiceAssociationLinkAsync", typeof(SubscriptionResource), typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteSubnetServiceAssociationLink", typeof(SubscriptionResource), typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class ContainerInstanceExtensions
    {
        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="resourceGroupResource"> The resource group resource. </param>
        /// <param name="waitUntil"> Specifies whether to wait for the operation to complete. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static async Task<ArmOperation> DeleteSubnetServiceAssociationLinkAsync(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            return await GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).DeleteSubnetServiceAssociationLinkAsync(waitUntil, virtualNetworkName, subnetName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Delete container group virtual network association links. </summary>
        /// <param name="resourceGroupResource"> The resource group resource. </param>
        /// <param name="waitUntil"> Specifies whether to wait for the operation to complete. </param>
        /// <param name="virtualNetworkName"> The name of the virtual network. </param>
        /// <param name="subnetName"> The name of the subnet. </param>
        /// <param name="cancellationToken"> The cancellation token. </param>
        public static ArmOperation DeleteSubnetServiceAssociationLink(this ResourceGroupResource resourceGroupResource, WaitUntil waitUntil, string virtualNetworkName, string subnetName, CancellationToken cancellationToken = default)
        {
            return GetMockableContainerInstanceResourceGroupResource(resourceGroupResource).DeleteSubnetServiceAssociationLink(waitUntil, virtualNetworkName, subnetName, cancellationToken);
        }
    }
}
