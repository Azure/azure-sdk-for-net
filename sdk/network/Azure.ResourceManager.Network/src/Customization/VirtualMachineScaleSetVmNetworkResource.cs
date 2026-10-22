// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    // Preserve the 1.15 aggregate Network facade over a Compute VMSS VM ID; the current generator no longer emits it.
    // Generated equivalents are split between ResourceGroupResource extensions and native NIC/IP/public-IP child resources.
    /// <summary>
    /// A class extending from the VirtualMachineScaleSetVmResource in Azure.ResourceManager.Compute along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="VirtualMachineScaleSetVmNetworkResource"/> from a <see cref="ResourceIdentifier"/> with a resource type of Microsoft.Compute/virtualMachineScaleSets/virtualMachines.
    /// </summary>
    public partial class VirtualMachineScaleSetVmNetworkResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets/virtualMachines";

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVmNetworkResource"/> class for mocking. </summary>
        protected VirtualMachineScaleSetVmNetworkResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetVmNetworkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVmNetworkResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ValidateResourceId(id);
        }

        /// <summary> Generate the resource identifier of a <see cref="VirtualMachineScaleSetVmNetworkResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="virtualMachineScaleSetName"> The virtualMachineScaleSetName. </param>
        /// <param name="virtualmachineIndex"> The virtualmachineIndex. </param>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string virtualmachineIndex)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}";
            return new ResourceIdentifier(resourceId);
        }

        [Conditional("DEBUG")]
        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
            }
        }

        // Native VirtualMachineScaleSetNetworkInterfaceResource.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurations()
        // exposes GetAll[Async] returning resources. Both 1.15 methods project .Data to retain data elements and paging.
        /// <summary> Gets all IP configurations in a virtual machine scale set network interface. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationDataAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource, NetworkInterfaceIPConfigurationData>(
                GetNetworkInterfaceResource(networkInterfaceName).GetVirtualMachineScaleSetNetworkInterfaceIPConfigurations().GetAllAsync(expand, cancellationToken),
                resource => resource.Data);
        }

        /// <summary> Gets all IP configurations in a virtual machine scale set network interface. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationData(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource, NetworkInterfaceIPConfigurationData>(
                GetNetworkInterfaceResource(networkInterfaceName).GetVirtualMachineScaleSetNetworkInterfaceIPConfigurations().GetAll(expand, cancellationToken),
                resource => resource.Data);
        }

        // ResourceGroupResource.GetVirtualMachineScaleSetNetworkInterfaces(vmssName, vmIndex).GetAll[Async]
        // returns NIC resources; both released VM-scoped methods project .Data to retain NetworkInterfaceData elements.
        /// <summary> Gets all network interfaces in a virtual machine scale set virtual machine. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceResource, NetworkInterfaceData>(
                resourceGroup.GetVirtualMachineScaleSetNetworkInterfaces(Id.Parent.Name, Id.Name).GetAllAsync(cancellationToken),
                resource => resource.Data);
        }

        /// <summary> Gets all network interfaces in a virtual machine scale set virtual machine. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken = default)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceResource, NetworkInterfaceData>(
                resourceGroup.GetVirtualMachineScaleSetNetworkInterfaces(Id.Parent.Name, Id.Name).GetAll(cancellationToken),
                resource => resource.Data);
        }

        // Native VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource
        // .GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddresses().GetAll[Async] returns resources.
        // Both 1.15 methods project .Data to retain PublicIPAddressData elements and paging.
        /// <summary> Gets all public IP addresses in a virtual machine scale set network interface IP configuration. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));

            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource, PublicIPAddressData>(
                GetIPConfigurationResource(networkInterfaceName, ipConfigurationName).GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddresses().GetAllAsync(cancellationToken),
                resource => resource.Data);
        }

        /// <summary> Gets all public IP addresses in a virtual machine scale set network interface IP configuration. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));

            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource, PublicIPAddressData>(
                GetIPConfigurationResource(networkInterfaceName, ipConfigurationName).GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddresses().GetAll(cancellationToken),
                resource => resource.Data);
        }

        // Retain both 1.15 data getters over VirtualMachineScaleSetNetworkInterfaceResource.Get[Async]:
        // project .Value.Data and preserve the native raw response instead of returning the new resource wrapper.
        /// <summary> Gets the specified network interface in a virtual machine scale set. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterfaceData>> GetNetworkInterfaceDataAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));

            var response = await GetNetworkInterfaceResource(networkInterfaceName).GetAsync(expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        /// <summary> Gets the specified network interface in a virtual machine scale set. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterfaceData> GetNetworkInterfaceData(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));

            var response = GetNetworkInterfaceResource(networkInterfaceName).Get(expand, cancellationToken);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        // Retain both 1.15 data getters over VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource.Get[Async]:
        // project .Value.Data and preserve the native raw response instead of returning the new resource wrapper.
        /// <summary> Gets the specified network interface IP configuration in a virtual machine scale set. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterfaceIPConfigurationData>> GetIPConfigurationDataAsync(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));

            var response = await GetIPConfigurationResource(networkInterfaceName, ipConfigurationName).GetAsync(expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        /// <summary> Gets the specified network interface IP configuration in a virtual machine scale set. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterfaceIPConfigurationData> GetIPConfigurationData(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));

            var response = GetIPConfigurationResource(networkInterfaceName, ipConfigurationName).Get(expand, cancellationToken);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        // Native VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource.Get[Async] returns resources.
        // Preserve both 1.15 PublicIPAddressData getters by projecting .Value.Data and keeping the raw response.
        /// <summary> Gets the specified public IP address in a virtual machine scale set. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="publicIPAddressName"> The name of the public IP address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PublicIPAddressData>> GetPublicIPAddressDataAsync(string networkInterfaceName, string ipConfigurationName, string publicIPAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));
            Argument.AssertNotNullOrEmpty(publicIPAddressName, nameof(publicIPAddressName));

            var resource = Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource(
                VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, publicIPAddressName));
            var response = await resource.GetAsync(expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        /// <summary> Gets the specified public IP address in a virtual machine scale set. </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="publicIPAddressName"> The name of the public IP address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PublicIPAddressData> GetPublicIPAddressData(string networkInterfaceName, string ipConfigurationName, string publicIPAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));
            Argument.AssertNotNullOrEmpty(publicIPAddressName, nameof(publicIPAddressName));

            var resource = Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource(
                VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, publicIPAddressName));
            var response = resource.Get(expand, cancellationToken);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        private VirtualMachineScaleSetNetworkInterfaceResource GetNetworkInterfaceResource(string networkInterfaceName)
            => Client.GetVirtualMachineScaleSetNetworkInterfaceResource(VirtualMachineScaleSetNetworkInterfaceResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName));

        private VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource GetIPConfigurationResource(string networkInterfaceName, string ipConfigurationName)
            => Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationResource(VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName));
    }
}
