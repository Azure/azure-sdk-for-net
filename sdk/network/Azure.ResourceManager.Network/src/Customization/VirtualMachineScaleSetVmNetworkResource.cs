// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Network
{
    public partial class VirtualMachineScaleSetVmNetworkResource
    {
        /// <summary>
        /// Get the specified network interface in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetNetworkInterface</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterfaceResource>> GetNetworkInterfaceVirtualMachineScaleSetAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.GetNetworkInterfaceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new NetworkInterfaceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified network interface in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetNetworkInterface</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterfaceResource> GetNetworkInterfaceVirtualMachineScaleSet(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.GetNetworkInterface(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand, cancellationToken);
                return Response.FromValue(new NetworkInterfaceResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified network interface ip configuration in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipConfigurations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListIpConfigurations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkInterfaceIPConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkInterfaceIPConfigurationResource> GetIPConfigurationsVirtualMachineScaleSetsAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.CreateListIPConfigurationsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.CreateListIPConfigurationsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new NetworkInterfaceIPConfigurationResource(Client, NetworkInterfaceIPConfigurationData.DeserializeNetworkInterfaceIPConfigurationData(e)), _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationsVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get the specified network interface ip configuration in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipConfigurations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListIpConfigurations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkInterfaceIPConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkInterfaceIPConfigurationResource> GetIPConfigurationsVirtualMachineScaleSets(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.CreateListIPConfigurationsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.CreateListIPConfigurationsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new NetworkInterfaceIPConfigurationResource(Client, NetworkInterfaceIPConfigurationData.DeserializeNetworkInterfaceIPConfigurationData(e)), _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationsVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Get the specified network interface ip configuration in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipConfigurations/{ipConfigurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetIpConfiguration</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The IP configuration name. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NetworkInterfaceIPConfigurationResource>> GetIPConfigurationVirtualMachineScaleSetAsync(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.GetIPConfigurationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new NetworkInterfaceIPConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified network interface ip configuration in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipConfigurations/{ipConfigurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetIpConfiguration</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The IP configuration name. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NetworkInterfaceIPConfigurationResource> GetIPConfigurationVirtualMachineScaleSet(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetVirtualMachineNetworkInterfaceIpconfigurationPublicipaddressVirtualMachineScaleSetsRestClient.GetIPConfiguration(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, expand, cancellationToken);
                return Response.FromValue(new NetworkInterfaceIPConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
