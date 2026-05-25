// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DeviceProvisioningServices
{
    public partial class DeviceProvisioningServicesPrivateEndpointConnectionCollection : IEnumerable<DeviceProvisioningServicesPrivateEndpointConnectionResource>, IAsyncEnumerable<DeviceProvisioningServicesPrivateEndpointConnectionResource>
    {
        /// <summary>
        /// List private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}/privateEndpointConnections. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_ListPrivateEndpointConnections. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeviceProvisioningServicesPrivateEndpointConnectionResource"/> that may take multiple service requests to iterate over. </returns>
        // TODO: Remove this compatibility shim once https://github.com/Azure/azure-sdk-for-net/issues/59355 is fixed.
        public virtual AsyncPageable<DeviceProvisioningServicesPrivateEndpointConnectionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<DeviceProvisioningServicesPrivateEndpointConnectionData, DeviceProvisioningServicesPrivateEndpointConnectionResource>(new MicrosoftDevicesPrivateEndpointConnectionsListPrivateEndpointConnectionsAsyncCollectionResultOfT(
                _privateEndpointConnectionsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                context,
                "DeviceProvisioningServicesPrivateEndpointConnectionCollection.GetAll"), data => new DeviceProvisioningServicesPrivateEndpointConnectionResource(Client, data));
        }

        /// <summary>
        /// List private endpoint connection properties
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{resourceName}/privateEndpointConnections. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PrivateEndpointConnections_ListPrivateEndpointConnections. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-02-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeviceProvisioningServicesPrivateEndpointConnectionResource"/> that may take multiple service requests to iterate over. </returns>
        // TODO: Remove this compatibility shim once https://github.com/Azure/azure-sdk-for-net/issues/59355 is fixed.
        public virtual Pageable<DeviceProvisioningServicesPrivateEndpointConnectionResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<DeviceProvisioningServicesPrivateEndpointConnectionData, DeviceProvisioningServicesPrivateEndpointConnectionResource>(new MicrosoftDevicesPrivateEndpointConnectionsListPrivateEndpointConnectionsCollectionResultOfT(
                _privateEndpointConnectionsRestClient,
                Id.SubscriptionId,
                Id.ResourceGroupName,
                Id.Name,
                context,
                "DeviceProvisioningServicesPrivateEndpointConnectionCollection.GetAll"), data => new DeviceProvisioningServicesPrivateEndpointConnectionResource(Client, data));
        }

        IEnumerator<DeviceProvisioningServicesPrivateEndpointConnectionResource> IEnumerable<DeviceProvisioningServicesPrivateEndpointConnectionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        /// <param name="cancellationToken"> The cancellation token to use. </param>
        IAsyncEnumerator<DeviceProvisioningServicesPrivateEndpointConnectionResource> IAsyncEnumerable<DeviceProvisioningServicesPrivateEndpointConnectionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
