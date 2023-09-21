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
    [CodeGenSuppress("GetNetworkInterfaceVirtualMachineScaleSetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterfaceVirtualMachineScaleSet", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationsVirtualMachineScaleSetsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationsVirtualMachineScaleSets", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationVirtualMachineScaleSetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationVirtualMachineScaleSet", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddressesAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddresses", typeof(string), typeof(string), typeof(CancellationToken))]
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
        public virtual async Task<Response<NetworkInterfaceResource>> GetNetworkInterfaceAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetsRestClient.GetNetworkInterfaceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<NetworkInterfaceResource> GetNetworkInterface(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetsRestClient.GetNetworkInterface(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand, cancellationToken);
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
        public virtual AsyncPageable<NetworkInterfaceIPConfigurationResource> GetIPConfigurationsAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new NetworkInterfaceIPConfigurationResource(Client, NetworkInterfaceIPConfigurationData.DeserializeNetworkInterfaceIPConfigurationData(e)), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationsVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
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
        public virtual Pageable<NetworkInterfaceIPConfigurationResource> GetIPConfigurations(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new NetworkInterfaceIPConfigurationResource(Client, NetworkInterfaceIPConfigurationData.DeserializeNetworkInterfaceIPConfigurationData(e)), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationsVirtualMachineScaleSets", "value", "nextLink", cancellationToken);
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
        public virtual async Task<Response<NetworkInterfaceIPConfigurationResource>> GetIPConfigurationAsync(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetsRestClient.GetIPConfigurationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, expand, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<NetworkInterfaceIPConfigurationResource> GetIPConfiguration(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationVirtualMachineScaleSet");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetsRestClient.GetIPConfiguration(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, expand, cancellationToken);
                return Response.FromValue(new NetworkInterfaceIPConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about all public IP addresses in a virtual machine IP configuration in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_ListPublicIPAddresses</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The network interface name. </param>
        /// <param name="ipConfigurationName"> The IP configuration name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkInterfaceName"/> or <paramref name="ipConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkInterfaceName"/> or <paramref name="ipConfigurationName"/> is null. </exception>
        /// <returns> An async collection of <see cref="PublicIPAddressData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetVmsRestClient.CreateListPublicIPAddressesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetVmsRestClient.CreateListPublicIPAddressesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => PublicIPAddressData.DeserializePublicIPAddressData(e), _virtualMachineScaleSetVmsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetAllPublicIPAddressData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets information about all public IP addresses in a virtual machine IP configuration in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_ListPublicIPAddresses</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The network interface name. </param>
        /// <param name="ipConfigurationName"> The IP configuration name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkInterfaceName"/> or <paramref name="ipConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkInterfaceName"/> or <paramref name="ipConfigurationName"/> is null. </exception>
        /// <returns> A collection of <see cref="PublicIPAddressData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(string networkInterfaceName, string ipConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetVmsRestClient.CreateListPublicIPAddressesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetVmsRestClient.CreateListPublicIPAddressesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => PublicIPAddressData.DeserializePublicIPAddressData(e), _virtualMachineScaleSetVmsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetAllPublicIPAddressData", "value", "nextLink", cancellationToken);
        }
    }
}
