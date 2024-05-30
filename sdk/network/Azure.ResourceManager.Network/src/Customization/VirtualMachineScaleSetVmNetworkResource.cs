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
    [CodeGenSuppress("GetIPConfigurationsVirtualMachineScaleSetsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationsVirtualMachineScaleSets", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationVirtualMachineScaleSetAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationVirtualMachineScaleSet", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddressesAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddresses", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddress", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddressAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterfacesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterfaces", typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterfaceAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterface", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurationsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIPConfigurations", typeof(string), typeof(string), typeof(CancellationToken))]
    public partial class VirtualMachineScaleSetVmNetworkResource
    {
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
        /// <returns> An async collection of <see cref="NetworkInterfaceIPConfigurationData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationDataAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => NetworkInterfaceIPConfigurationData.DeserializeNetworkInterfaceIPConfigurationData(e), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetAllIPConfigurationData", "value", "nextLink", cancellationToken);
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
        /// <returns> A collection of <see cref="NetworkInterfaceIPConfigurationData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkInterfaceIPConfigurationData> GetAllIPConfigurationData(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListIPConfigurationsNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e =>  NetworkInterfaceIPConfigurationData.DeserializeNetworkInterfaceIPConfigurationData(e), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetAllIPConfigurationData", "value", "nextLink", cancellationToken);
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
        public virtual async Task<Response<NetworkInterfaceIPConfigurationData>> GetIPConfigurationDataAsync(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationData");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetsRestClient.GetIPConfigurationAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
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
        public virtual Response<NetworkInterfaceIPConfigurationData> GetIPConfigurationData(string networkInterfaceName, string ipConfigurationName, string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetIPConfigurationData");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetsRestClient.GetIPConfiguration(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, expand, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified public IP address in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses/{publicIpAddressName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetPublicIPAddress</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="publicIPAddressName"> The name of the public IP Address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkInterfaceName"/>, <paramref name="ipConfigurationName"/> or <paramref name="publicIPAddressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkInterfaceName"/>, <paramref name="ipConfigurationName"/> or <paramref name="publicIPAddressName"/> is null. </exception>
        public virtual async Task<Response<PublicIPAddressData>> GetPublicIPAddressDataAsync(string networkInterfaceName, string ipConfigurationName, string publicIPAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));
            Argument.AssertNotNullOrEmpty(publicIPAddressName, nameof(publicIPAddressName));

            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetPublicIPAddressData");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetsRestClient.GetPublicIPAddressAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, publicIPAddressName, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the specified public IP address in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses/{publicIpAddressName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_GetPublicIPAddress</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="networkInterfaceName"> The name of the network interface. </param>
        /// <param name="ipConfigurationName"> The name of the IP configuration. </param>
        /// <param name="publicIPAddressName"> The name of the public IP Address. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkInterfaceName"/>, <paramref name="ipConfigurationName"/> or <paramref name="publicIPAddressName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkInterfaceName"/>, <paramref name="ipConfigurationName"/> or <paramref name="publicIPAddressName"/> is null. </exception>
        public virtual Response<PublicIPAddressData> GetPublicIPAddressData(string networkInterfaceName, string ipConfigurationName, string publicIPAddressName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));
            Argument.AssertNotNullOrEmpty(ipConfigurationName, nameof(ipConfigurationName));
            Argument.AssertNotNullOrEmpty(publicIPAddressName, nameof(publicIPAddressName));

            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetPublicIPAddressData");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetsRestClient.GetPublicIPAddress(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, ipConfigurationName, publicIPAddressName, expand, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
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

        /// <summary>
        /// Gets information about all network interfaces in a virtual machine in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_ListNetworkInterfaces</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkInterfaceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetVmsRestClient.CreateListNetworkInterfacesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetVmsRestClient.CreateListNetworkInterfacesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => NetworkInterfaceData.DeserializeNetworkInterfaceData(e), _virtualMachineScaleSetVmsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetAllNetworkInterfaceData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets information about all network interfaces in a virtual machine in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSetVMs_ListNetworkInterfaces</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkInterfaceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetVmsRestClient.CreateListNetworkInterfacesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetVmsRestClient.CreateListNetworkInterfacesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => NetworkInterfaceData.DeserializeNetworkInterfaceData(e), _virtualMachineScaleSetVmsClientDiagnostics, Pipeline, "VirtualMachineScaleSetVmNetworkResource.GetAllNetworkInterfaceData", "value", "nextLink", cancellationToken);
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
        /// <exception cref="ArgumentException"> <paramref name="networkInterfaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual async Task<Response<NetworkInterfaceData>> GetNetworkInterfaceDataAsync(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));

            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceData");
            scope.Start();
            try
            {
                var response = await _virtualMachineScaleSetsRestClient.GetNetworkInterfaceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
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
        /// <exception cref="ArgumentException"> <paramref name="networkInterfaceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkInterfaceName"/> is null. </exception>
        public virtual Response<NetworkInterfaceData> GetNetworkInterfaceData(string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkInterfaceName, nameof(networkInterfaceName));

            using var scope = _virtualMachineScaleSetsClientDiagnostics.CreateScope("VirtualMachineScaleSetVmNetworkResource.GetNetworkInterfaceData");
            scope.Start();
            try
            {
                var response = _virtualMachineScaleSetsRestClient.GetNetworkInterface(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, networkInterfaceName, expand, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
