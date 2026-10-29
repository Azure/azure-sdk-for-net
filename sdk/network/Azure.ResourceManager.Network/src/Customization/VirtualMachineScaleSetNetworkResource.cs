// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    // Preserve the 1.15 aggregate Network facade over a Compute VMSS ID; the current generator no longer emits it.
    // Its generated list operations now live on ResourceGroupResource extensions rather than this released type.
    /// <summary>
    /// A class extending from the VirtualMachineScaleSetResource in Azure.ResourceManager.Compute along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="VirtualMachineScaleSetNetworkResource"/> from a <see cref="ResourceIdentifier"/> with a resource type of Microsoft.Compute/virtualMachineScaleSets.
    /// </summary>
    public partial class VirtualMachineScaleSetNetworkResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets";

        /// <summary> Initializes a new instance of VirtualMachineScaleSetNetworkResource for mocking. </summary>
        protected VirtualMachineScaleSetNetworkResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetNetworkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetNetworkResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ValidateResourceId(id);
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="virtualMachineScaleSetName"> The virtualMachineScaleSetName. </param>
        /// <returns> A resource identifier for the virtual machine scale set. </returns>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}";
            return new ResourceIdentifier(resourceId);
        }

        /// <param name="id"></param>
        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }
        // Keep both released data-returning methods as direct forwards to the generated
        // ResourceGroupResource.GetVirtualMachineScaleSetNetworkInterfaces[Async] extensions.
        /// <summary> Gets all network interfaces in a virtual machine scale set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetVirtualMachineScaleSetNetworkInterfacesAsync(Id.Name, cancellationToken);
        }
        /// <summary> Gets all network interfaces in a virtual machine scale set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetVirtualMachineScaleSetNetworkInterfaces(Id.Name, cancellationToken);
        }
        // The 1.15 GetAllPublicIPAddressData[Async] methods predate the ResourceGroupResource
        // GetVirtualMachineScaleSetPublicIPAddresses[Async] extensions, which were not exposed in 1.15.
        // Preserve the released facade methods as direct forwards to those new generated extensions.
        /// <summary> Gets all public IP addresses in a virtual machine scale set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetVirtualMachineScaleSetPublicIPAddressesAsync(Id.Name, cancellationToken);
        }
        /// <summary> Gets all public IP addresses in a virtual machine scale set. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetVirtualMachineScaleSetPublicIPAddresses(Id.Name, cancellationToken);
        }
    }
}
