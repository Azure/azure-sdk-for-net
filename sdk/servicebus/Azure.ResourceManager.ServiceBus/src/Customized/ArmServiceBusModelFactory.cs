// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Workaround for generator bug: https://github.com/Azure/azure-sdk-for-net/issues/57254
//
// The generator's ProcessTypeForBackCompatibility discards flattened property
// values (passes `default` for the Properties wrapper) when the baseline SDK
// had the same @@flattenProperty params in a different order. These overloads
// provide correct implementations with the baseline param order.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.ResourceManager.ServiceBus.Models
{
    public static partial class ArmServiceBusModelFactory
    {
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The Private Endpoint resource for this Connection. </param>
        /// <param name="connectionState"> Details about the state of the connection. </param>
        /// <param name="provisioningState"> Provisioning state of the Private Endpoint Connection. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public static ServiceBusPrivateEndpointConnectionData ServiceBusPrivateEndpointConnectionData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, ResourceIdentifier privateEndpointId = default, ServiceBusPrivateLinkServiceConnectionState connectionState = default, ServiceBusPrivateEndpointConnectionProvisioningState? provisioningState = default, AzureLocation? location = default)
        {
            return new ServiceBusPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                privateEndpointId is null && connectionState is null && provisioningState is null
                    ? default
                    : new PrivateEndpointConnectionProperties(
                        new PrivateEndpoint(privateEndpointId, null),
                        connectionState,
                        provisioningState,
                        null),
                location);
        }

        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Properties of SKU. </param>
        /// <param name="identity"> Properties of BYOK Identity description. </param>
        /// <param name="provisioningState"> Provisioning state of the namespace. </param>
        /// <param name="status"> Status of the namespace. </param>
        /// <param name="createdOn"> The time the namespace was created. </param>
        /// <param name="updatedOn"> The time the namespace was updated. </param>
        /// <param name="serviceBusEndpoint"> Endpoint you can use to perform Service Bus operations. </param>
        /// <param name="metricId"> Identifier for Azure Insights metrics. </param>
        /// <param name="encryption"> Properties of BYOK Encryption description. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections. </param>
        /// <param name="disableLocalAuth"> This property disables SAS authentication for the Service Bus namespace. </param>
        /// <param name="alternateName"> Alternate name for namespace. </param>
        public static ServiceBusNamespacePatch ServiceBusNamespacePatch(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, ServiceBusSku sku = default, ManagedServiceIdentity identity = default, string provisioningState = default, string status = default, DateTimeOffset? createdOn = default, DateTimeOffset? updatedOn = default, string serviceBusEndpoint = default, string metricId = default, ServiceBusEncryption encryption = default, IEnumerable<ServiceBusPrivateEndpointConnectionData> privateEndpointConnections = default, bool? disableLocalAuth = default, string alternateName = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new ServiceBusNamespacePatch(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && status is null && createdOn is null && updatedOn is null && serviceBusEndpoint is null && metricId is null && encryption is null && privateEndpointConnections is null && disableLocalAuth is null && alternateName is null
                    ? default
                    : new SBNamespaceUpdateProperties(
                        provisioningState,
                        status,
                        createdOn,
                        updatedOn,
                        serviceBusEndpoint,
                        metricId,
                        encryption,
                        (privateEndpointConnections ?? new ChangeTrackingList<ServiceBusPrivateEndpointConnectionData>()).ToList(),
                        disableLocalAuth,
                        alternateName,
                        null),
                sku,
                identity);
        }
    }
}
