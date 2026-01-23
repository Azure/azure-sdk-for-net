// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ElasticSan.Models
{
    // temperary util https://github.com/Azure/azure-sdk-for-net/issues/55203 is resolved
    public static partial class ArmElasticSanModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ElasticSan.ElasticSanVolumeGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="identity"> The identity of the resource. Current supported identity types: None, SystemAssigned, UserAssigned. </param>
        /// <param name="provisioningState"> State of the operation on the resource. </param>
        /// <param name="protocolType"> Type of storage target. </param>
        /// <param name="encryption"> Type of encryption. </param>
        /// <param name="encryptionProperties"> Encryption Properties describing Key Vault and Identity information. </param>
        /// <param name="virtualNetworkRules"> A collection of rules governing the accessibility from specific network locations. </param>
        /// <param name="privateEndpointConnections"> The list of Private Endpoint Connections. </param>
        /// <returns> A new <see cref="ElasticSan.ElasticSanVolumeGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ElasticSanVolumeGroupData ElasticSanVolumeGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ManagedServiceIdentity identity, ElasticSanProvisioningState? provisioningState, ElasticSanStorageTargetType? protocolType, ElasticSanEncryptionType? encryption, ElasticSanEncryptionProperties encryptionProperties, IEnumerable<ElasticSanVirtualNetworkRule> virtualNetworkRules, IEnumerable<ElasticSanPrivateEndpointConnectionData> privateEndpointConnections)
        {
            return ElasticSanVolumeGroupData(id, name, resourceType, systemData, identity, provisioningState, protocolType,encryption, encryptionProperties, virtualNetworkRules, privateEndpointConnections, enforceDataIntegrityCheckForIscsi:default);
        }
    }
}
