// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Diagnostics;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing an AutoRest-era Network VMSS parent resource.
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
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName)
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
                throw new ArgumentException(string.Format("Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        [ForwardsClientCalls]
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceResource, NetworkInterfaceData>(resourceGroup.GetVirtualMachineScaleSetNetworkInterfacesAsync(Id.Name, cancellationToken), resource => resource.Data);
        }

        [ForwardsClientCalls]
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceResource, NetworkInterfaceData>(resourceGroup.GetVirtualMachineScaleSetNetworkInterfaces(Id.Name, cancellationToken), resource => resource.Data);
        }

        [ForwardsClientCalls]
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(CancellationToken cancellationToken)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetVirtualMachineScaleSetPublicIPAddressesAsync(Id.Name, cancellationToken);
        }

        [ForwardsClientCalls]
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(CancellationToken cancellationToken)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return resourceGroup.GetVirtualMachineScaleSetPublicIPAddresses(Id.Name, cancellationToken);
        }
    }
}
