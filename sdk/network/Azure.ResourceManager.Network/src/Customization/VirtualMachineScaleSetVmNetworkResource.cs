// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing an AutoRest-era Network VMSS VM parent resource.
    /// </summary>
    public partial class VirtualMachineScaleSetVmNetworkResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Compute/virtualMachineScaleSets/virtualMachines";

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmNetworkResource for mocking. </summary>
        protected VirtualMachineScaleSetVmNetworkResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetVmNetworkResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVmNetworkResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            ValidateResourceId(id);
        }

        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="virtualMachineScaleSetName"> The virtualMachineScaleSetName. </param>
        /// <param name="virtualmachineIndex"> The virtualmachineIndex. </param>
        /// <returns> A resource identifier for the virtual machine scale set VM. </returns>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string virtualmachineIndex)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}";
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

        public virtual AsyncPageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource, NetworkInterfaceIPConfigurationData>(
                resourceGroup.GetVirtualMachineScaleSetIpConfigurationsAsync(virtualMachineScaleSetName, virtualmachineIndex, "nic1", cancellationToken: cancellationToken),
                resource => resource.Data);
        }

        public virtual Pageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationData(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            var resourceGroup = Client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName));
            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource, NetworkInterfaceIPConfigurationData>(
                resourceGroup.GetVirtualMachineScaleSetIpConfigurations(virtualMachineScaleSetName, virtualmachineIndex, "nic1", cancellationToken: cancellationToken),
                resource => resource.Data);
        }

        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceData, NetworkInterfaceData>(
                new VirtualMachineScaleSetVmNetworkGetVirtualMachineScaleSetVMNetworkInterfacesAsyncCollectionResultOfT(
                    CreateVirtualMachineScaleSetVmNetworkRestClient(),
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Name,
                    Id.Name,
                    context,
                    "VirtualMachineScaleSetVmNetworkResource.GetAllNetworkInterfaceData"),
                data => data);
        }

        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceData, NetworkInterfaceData>(
                new VirtualMachineScaleSetVmNetworkGetVirtualMachineScaleSetVMNetworkInterfacesCollectionResultOfT(
                    CreateVirtualMachineScaleSetVmNetworkRestClient(),
                    Guid.Parse(Id.SubscriptionId),
                    Id.ResourceGroupName,
                    Id.Parent.Name,
                    Id.Name,
                    context,
                    "VirtualMachineScaleSetVmNetworkResource.GetAllNetworkInterfaceData"),
                data => data);
        }

        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PublicIPAddressesGetVirtualMachineScaleSetVMPublicIPAddressesAsyncCollectionResultOfT(
                CreatePublicIPAddressesRestClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                virtualMachineScaleSetName,
                virtualmachineIndex,
                "nic1",
                "ip1",
                context,
                "VirtualMachineScaleSetVmNetworkResource.GetAllPublicIPAddressData");
        }

        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PublicIPAddressesGetVirtualMachineScaleSetVMPublicIPAddressesCollectionResultOfT(
                CreatePublicIPAddressesRestClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                virtualMachineScaleSetName,
                virtualmachineIndex,
                "nic1",
                "ip1",
                context,
                "VirtualMachineScaleSetVmNetworkResource.GetAllPublicIPAddressData");
        }

        public virtual async Task<Response<NetworkInterfaceData>> GetNetworkInterfaceDataAsync(string virtualMachineScaleSetName, string networkInterfaceName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateVirtualMachineScaleSetVmNetworkRestClient().CreateGetVirtualMachineScaleSetNetworkInterfaceRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, null, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue((NetworkInterfaceData)VirtualMachineScaleSetNetworkInterfaceData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<NetworkInterfaceData> GetNetworkInterfaceData(string virtualMachineScaleSetName, string networkInterfaceName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateVirtualMachineScaleSetVmNetworkRestClient().CreateGetVirtualMachineScaleSetNetworkInterfaceRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, null, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue((NetworkInterfaceData)VirtualMachineScaleSetNetworkInterfaceData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<NetworkInterfaceIPConfigurationData>> GetIPConfigurationDataAsync(string virtualMachineScaleSetName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken)
        {
            var resource = Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationResource(VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, ipConfigurationName));
            var response = await resource.GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue((NetworkInterfaceIPConfigurationData)response.Value.Data, response.GetRawResponse());
        }

        public virtual Response<NetworkInterfaceIPConfigurationData> GetIPConfigurationData(string virtualMachineScaleSetName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken)
        {
            var resource = Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationResource(VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, ipConfigurationName));
            var response = resource.Get(cancellationToken: cancellationToken);
            return Response.FromValue((NetworkInterfaceIPConfigurationData)response.Value.Data, response.GetRawResponse());
        }

        public virtual async Task<Response<PublicIPAddressData>> GetPublicIPAddressDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, string networkInterfaceName, string publicIpAddressName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetPublicIPAddressData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreatePublicIPAddressesRestClient().CreateGetVirtualMachineScaleSetPublicIPAddressRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, virtualmachineIndex, networkInterfaceName, "ip1", publicIpAddressName, null, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(PublicIPAddressData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<PublicIPAddressData> GetPublicIPAddressData(string virtualMachineScaleSetName, string virtualmachineIndex, string networkInterfaceName, string publicIpAddressName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetPublicIPAddressData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreatePublicIPAddressesRestClient().CreateGetVirtualMachineScaleSetPublicIPAddressRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, virtualmachineIndex, networkInterfaceName, "ip1", publicIpAddressName, null, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(PublicIPAddressData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private ClientDiagnostics CreateClientDiagnostics()
            => new ClientDiagnostics("Azure.ResourceManager.Network", ProviderConstants.DefaultProviderNamespace, Diagnostics);

        private VirtualMachineScaleSetVmNetwork CreateVirtualMachineScaleSetVmNetworkRestClient()
            => new VirtualMachineScaleSetVmNetwork(CreateClientDiagnostics(), Pipeline, Endpoint, "2018-10-01");

        private PublicIPAddresses CreatePublicIPAddressesRestClient()
            => new PublicIPAddresses(CreateClientDiagnostics(), Pipeline, Endpoint, "2018-10-01");
    }
}
