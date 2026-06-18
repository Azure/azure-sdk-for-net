// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

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

        /// <summary> Invokes the GetAllIPConfigurationDataAsync compatibility operation. </summary>
        public virtual AsyncPageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            return new AsyncPageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource, NetworkInterfaceIPConfigurationData>(
                GetVirtualMachineScaleSetNetworkInterfaceResource(virtualMachineScaleSetName, Id.Name).GetVirtualMachineScaleSetNetworkInterfaceIPConfigurations().GetAllAsync(virtualMachineScaleSetName, virtualmachineIndex, Id.Name, cancellationToken: cancellationToken),
                resource => resource.Data);
        }

        /// <summary> Invokes the GetAllIPConfigurationData compatibility operation. </summary>
        public virtual Pageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationData(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            return new PageableWrapper<VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource, NetworkInterfaceIPConfigurationData>(
                GetVirtualMachineScaleSetNetworkInterfaceResource(virtualMachineScaleSetName, Id.Name).GetVirtualMachineScaleSetNetworkInterfaceIPConfigurations().GetAll(virtualMachineScaleSetName, virtualmachineIndex, Id.Name, cancellationToken: cancellationToken),
                resource => resource.Data);
        }

        /// <summary> Invokes the GetAllNetworkInterfaceDataAsync compatibility operation. </summary>
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new VirtualMachineScaleSetNetworkInterfacesGetVirtualMachineScaleSetVMNetworkInterfacesAsyncCollectionResultOfT(
                CreateVirtualMachineScaleSetVmNetworkRestClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "VirtualMachineScaleSetVmNetworkResource.GetAllNetworkInterfaceData");
        }

        /// <summary> Invokes the GetAllNetworkInterfaceData compatibility operation. </summary>
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new VirtualMachineScaleSetNetworkInterfacesGetVirtualMachineScaleSetVMNetworkInterfacesCollectionResultOfT(
                CreateVirtualMachineScaleSetVmNetworkRestClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                Id.Parent.Name,
                Id.Name,
                context,
                "VirtualMachineScaleSetVmNetworkResource.GetAllNetworkInterfaceData");
        }

        /// <summary> Invokes the GetAllPublicIPAddressDataAsync compatibility operation. </summary>
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new VmssVmPublicIPAddressesAsyncCollectionResultOfT(
                CreateVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressesRestClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                virtualMachineScaleSetName,
                virtualmachineIndex,
                "nic1",
                "ip1",
                context,
                "VirtualMachineScaleSetVmNetworkResource.GetAllPublicIPAddressData");
        }

        /// <summary> Invokes the GetAllPublicIPAddressData compatibility operation. </summary>
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(string virtualMachineScaleSetName, string virtualmachineIndex, CancellationToken cancellationToken)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new VmssVmPublicIPAddressesCollectionResultOfT(
                CreateVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressesRestClient(),
                Guid.Parse(Id.SubscriptionId),
                Id.ResourceGroupName,
                virtualMachineScaleSetName,
                virtualmachineIndex,
                "nic1",
                "ip1",
                context,
                "VirtualMachineScaleSetVmNetworkResource.GetAllPublicIPAddressData");
        }

        /// <summary> Invokes the GetNetworkInterfaceDataAsync compatibility operation. </summary>
        public virtual async Task<Response<NetworkInterfaceData>> GetNetworkInterfaceDataAsync(string virtualMachineScaleSetName, string networkInterfaceName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateVirtualMachineScaleSetVmNetworkRestClient().CreateGetVirtualMachineScaleSetNetworkInterfaceRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, null, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(NetworkInterfaceData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the GetNetworkInterfaceData compatibility operation. </summary>
        public virtual Response<NetworkInterfaceData> GetNetworkInterfaceData(string virtualMachineScaleSetName, string networkInterfaceName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateVirtualMachineScaleSetVmNetworkRestClient().CreateGetVirtualMachineScaleSetNetworkInterfaceRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, null, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(NetworkInterfaceData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the GetIPConfigurationDataAsync compatibility operation. </summary>
        public virtual async Task<Response<NetworkInterfaceIPConfigurationData>> GetIPConfigurationDataAsync(string virtualMachineScaleSetName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken)
        {
            var resource = Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationResource(VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, ipConfigurationName));
            var response = await resource.GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        /// <summary> Invokes the GetIPConfigurationData compatibility operation. </summary>
        public virtual Response<NetworkInterfaceIPConfigurationData> GetIPConfigurationData(string virtualMachineScaleSetName, string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken)
        {
            var resource = Client.GetVirtualMachineScaleSetNetworkInterfaceIPConfigurationResource(VirtualMachineScaleSetNetworkInterfaceIPConfigurationResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName, ipConfigurationName));
            var response = resource.Get(cancellationToken: cancellationToken);
            return Response.FromValue(response.Value.Data, response.GetRawResponse());
        }

        /// <summary> Invokes the GetPublicIPAddressDataAsync compatibility operation. </summary>
        public virtual async Task<Response<PublicIPAddressData>> GetPublicIPAddressDataAsync(string virtualMachineScaleSetName, string virtualmachineIndex, string networkInterfaceName, string publicIpAddressName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetPublicIPAddressData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressesRestClient().CreateGetVirtualMachineScaleSetPublicIPAddressRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, virtualmachineIndex, networkInterfaceName, "ip1", publicIpAddressName, null, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(PublicIPAddressData.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Invokes the GetPublicIPAddressData compatibility operation. </summary>
        public virtual Response<PublicIPAddressData> GetPublicIPAddressData(string virtualMachineScaleSetName, string virtualmachineIndex, string networkInterfaceName, string publicIpAddressName, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = CreateClientDiagnostics().CreateScope("VirtualMachineScaleSetVmNetworkResource.GetPublicIPAddressData");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = CreateVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressesRestClient().CreateGetVirtualMachineScaleSetPublicIPAddressRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, virtualMachineScaleSetName, virtualmachineIndex, networkInterfaceName, "ip1", publicIpAddressName, null, context);
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

        private VirtualMachineScaleSetNetworkInterfaces CreateVirtualMachineScaleSetVmNetworkRestClient()
            => new VirtualMachineScaleSetNetworkInterfaces(CreateClientDiagnostics(), Pipeline, Endpoint, "2018-10-01");

        private VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddresses CreateVirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddressesRestClient()
            => new VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddresses(CreateClientDiagnostics(), Pipeline, Endpoint, "2018-10-01");

        private VirtualMachineScaleSetNetworkInterfaceResource GetVirtualMachineScaleSetNetworkInterfaceResource(string virtualMachineScaleSetName, string networkInterfaceName)
            => Client.GetVirtualMachineScaleSetNetworkInterfaceResource(VirtualMachineScaleSetNetworkInterfaceResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, virtualMachineScaleSetName, Id.Name, networkInterfaceName));
    }
}
