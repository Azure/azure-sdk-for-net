// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.KeyVault.Models
{
    public static partial class ArmKeyVaultModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.KeyVaultPrivateLinkResourceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="groupId"> Group identifier of private link resource. </param>
        /// <param name="requiredMembers"> Required member names of private link resource. </param>
        /// <param name="requiredZoneNames"> Required DNS zone names of the the private link resource. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <returns> A new <see cref="Models.KeyVaultPrivateLinkResourceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KeyVaultPrivateLinkResourceData KeyVaultPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string groupId, IEnumerable<string> requiredMembers, IEnumerable<string> requiredZoneNames, AzureLocation? location, IReadOnlyDictionary<string, string> tags)
        {
            return new KeyVaultPrivateLinkResourceData(
                id,
                name,
                resourceType,
                systemData,
                location,
                tags,
                groupId,
                requiredMembers.ToList(),
                requiredZoneNames.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="KeyVault.ManagedHsmPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="sku"> SKU details. </param>
        /// <param name="identity"> Managed service identity (system assigned and/or user assigned identities). </param>
        /// <returns> A new <see cref="KeyVault.ManagedHsmPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedHsmPrivateEndpointConnectionData ManagedHsmPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ResourceIdentifier privateEndpointId, ManagedHsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState, ManagedHsmPrivateEndpointConnectionProvisioningState? provisioningState, ManagedHsmSku sku, ManagedServiceIdentity identity)
        {
            return new ManagedHsmPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                tags,
                location,
                sku,
                identity,
                etag,
                privateEndpoint: ResourceManagerModelFactory.SubResource(privateEndpointId),
                privateLinkServiceConnectionState,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="privateLinkServiceConnectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="sku"> SKU details. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.KeyVault.ManagedHsmPrivateEndpointConnectionData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedHsmPrivateEndpointConnectionData ManagedHsmPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ETag? etag, ResourceIdentifier privateEndpointId, ManagedHsmPrivateLinkServiceConnectionState privateLinkServiceConnectionState, ManagedHsmPrivateEndpointConnectionProvisioningState? provisioningState, ManagedHsmSku sku)
        {
            return ManagedHsmPrivateEndpointConnectionData(id, name, resourceType, systemData, tags, location, etag, privateEndpointId, privateLinkServiceConnectionState, provisioningState, sku, identity: default);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="groupId"> Group identifier of private link resource. </param>
        /// <param name="requiredMembers"> Required member names of private link resource. </param>
        /// <param name="requiredZoneNames"> Required DNS zone names of the the private link resource. </param>
        /// <param name="sku"> SKU details. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.KeyVault.Models.ManagedHsmPrivateLinkResourceData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedHsmPrivateLinkResourceData ManagedHsmPrivateLinkResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string groupId, IEnumerable<string> requiredMembers, IEnumerable<string> requiredZoneNames, ManagedHsmSku sku)
        {
            return ManagedHsmPrivateLinkResourceData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, groupId: groupId, requiredMembers: requiredMembers, requiredZoneNames: requiredZoneNames, sku: sku, identity: default);
        }

        /// <summary> Initializes a new instance of <see cref="KeyVault.KeyVaultPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="etag"> Modified whenever there is a change in the state of private endpoint connection. </param>
        /// <param name="privateEndpointId"> Properties of the private endpoint object. </param>
        /// <param name="connectionState"> Approval state of the private link connection. </param>
        /// <param name="provisioningState"> Provisioning state of the private endpoint connection. </param>
        /// <param name="location"> Azure location of the key vault resource. </param>
        /// <param name="tags"> Tags assigned to the key vault resource. </param>
        /// <returns> A new <see cref="KeyVault.KeyVaultPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KeyVaultPrivateEndpointConnectionData KeyVaultPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ETag? etag, ResourceIdentifier privateEndpointId, KeyVaultPrivateLinkServiceConnectionState connectionState, KeyVaultPrivateEndpointConnectionProvisioningState? provisioningState, AzureLocation? location, IReadOnlyDictionary<string, string> tags)
        {
            return new KeyVaultPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                location,
                tags,
                etag,
                privateEndpoint: ResourceManagerModelFactory.SubResource(privateEndpointId),
                connectionState,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.KeyVault.ManagedHsmData" />. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="properties"> Properties of the managed HSM. </param>
        /// <param name="sku"> SKU details. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.KeyVault.ManagedHsmData" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagedHsmData ManagedHsmData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ManagedHsmProperties properties, ManagedHsmSku sku)
        {
            return ManagedHsmData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, properties: properties, sku: sku, identity: default);
        }
    }
}
