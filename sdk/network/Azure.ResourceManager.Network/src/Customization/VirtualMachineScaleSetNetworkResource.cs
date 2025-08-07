// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("GetPublicIPAddressesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetPublicIPAddresses", typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterfacesAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkInterfaces", typeof(CancellationToken))]
    public partial class VirtualMachineScaleSetNetworkResource
    {
        /// <summary>
        /// Gets information about all public IP addresses on a virtual machine scale set level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/publicipaddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListPublicIPAddresses</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PublicIPAddressData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PublicIPAddressData> GetAllPublicIPAddressDataAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListPublicIPAddressesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListPublicIPAddressesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => PublicIPAddressData.DeserializePublicIPAddressData(e), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetNetworkResource.GetAllPublicIPAddressData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets information about all public IP addresses on a virtual machine scale set level.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/publicipaddresses</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListPublicIPAddresses</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PublicIPAddressData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PublicIPAddressData> GetAllPublicIPAddressData(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListPublicIPAddressesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListPublicIPAddressesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => PublicIPAddressData.DeserializePublicIPAddressData(e), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetNetworkResource.GetAllPublicIPAddressData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all network interfaces in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/networkInterfaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListNetworkInterfaces</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkInterfaceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkInterfaceData> GetAllNetworkInterfaceDataAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListNetworkInterfacesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListNetworkInterfacesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => NetworkInterfaceData.DeserializeNetworkInterfaceData(e), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetNetworkResource.GetAllNetworkInterfaceData", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets all network interfaces in a virtual machine scale set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/networkInterfaces</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>VirtualMachineScaleSets_ListNetworkInterfaces</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkInterfaceData" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkInterfaceData> GetAllNetworkInterfaceData(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _virtualMachineScaleSetsRestClient.CreateListNetworkInterfacesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _virtualMachineScaleSetsRestClient.CreateListNetworkInterfacesNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => NetworkInterfaceData.DeserializeNetworkInterfaceData(e), _virtualMachineScaleSetsClientDiagnostics, Pipeline, "VirtualMachineScaleSetNetworkResource.GetAllNetworkInterfaceData", "value", "nextLink", cancellationToken);
        }
    }
}
