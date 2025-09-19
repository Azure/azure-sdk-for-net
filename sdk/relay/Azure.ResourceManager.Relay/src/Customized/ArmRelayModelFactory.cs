// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Relay.Models
{
    public static partial class ArmRelayModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Relay.WcfRelayData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isDynamic"> Returns true if the relay is dynamic; otherwise, false. </param>
        /// <param name="createdOn"> The time the WCF relay was created. </param>
        /// <param name="updatedOn"> The time the namespace was updated. </param>
        /// <param name="listenerCount"> The number of listeners for this relay. Note that min :1 and max:25 are supported. </param>
        /// <param name="relayType"> WCF relay type. </param>
        /// <param name="isClientAuthorizationRequired"> Returns true if client authorization is needed for this relay; otherwise, false. </param>
        /// <param name="isTransportSecurityRequired"> Returns true if transport security is needed for this relay; otherwise, false. </param>
        /// <param name="userMetadata"> The usermetadata is a placeholder to store user-defined string data for the WCF Relay endpoint. For example, it can be used to store descriptive data, such as list of teams and their contact information. Also, user-defined configuration settings can be stored. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="Relay.WcfRelayData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WcfRelayData WcfRelayData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? isDynamic = null, DateTimeOffset? createdOn = null, DateTimeOffset? updatedOn = null, int? listenerCount = null, RelayType? relayType = null, bool? isClientAuthorizationRequired = null, bool? isTransportSecurityRequired = null, string userMetadata = null, AzureLocation? location = null)
            => WcfRelayData(id, name, resourceType, systemData, location, isDynamic, createdOn, updatedOn, listenerCount, relayType, isClientAuthorizationRequired, isTransportSecurityRequired, userMetadata);

        /// <summary> Initializes a new instance of <see cref="Relay.RelayPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The Private Endpoint resource for this Connection. </param>
        /// <param name="connectionState"> Details about the state of the connection. </param>
        /// <param name="provisioningState"> Provisioning state of the Private Endpoint Connection. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="Relay.RelayPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RelayPrivateEndpointConnectionData RelayPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId = null, RelayPrivateLinkServiceConnectionState connectionState = null, RelayPrivateEndpointConnectionProvisioningState? provisioningState = null, AzureLocation? location = null)
            => RelayPrivateEndpointConnectionData(id, name, resourceType, systemData, location, privateEndpointId, connectionState, provisioningState);

        /// <summary> Initializes a new instance of <see cref="Relay.RelayHybridConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="createdOn"> The time the hybrid connection was created. </param>
        /// <param name="updatedOn"> The time the namespace was updated. </param>
        /// <param name="listenerCount"> The number of listeners for this hybrid connection. Note that min : 1 and max:25 are supported. </param>
        /// <param name="isClientAuthorizationRequired"> Returns true if client authorization is needed for this hybrid connection; otherwise, false. </param>
        /// <param name="userMetadata"> The usermetadata is a placeholder to store user-defined string data for the hybrid connection endpoint. For example, it can be used to store descriptive data, such as a list of teams and their contact information. Also, user-defined configuration settings can be stored. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="Relay.RelayHybridConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RelayHybridConnectionData RelayHybridConnectionData(ResourceIdentifier id, string name = null, ResourceType resourceType = default, SystemData systemData = null, DateTimeOffset? createdOn = null, DateTimeOffset? updatedOn = null, int? listenerCount = null, bool? isClientAuthorizationRequired = null, string userMetadata = null, AzureLocation? location = null)
            => RelayHybridConnectionData(id, name, resourceType, systemData, location, createdOn, updatedOn, listenerCount, isClientAuthorizationRequired, userMetadata);

        /// <summary> Initializes a new instance of <see cref="Relay.RelayAuthorizationRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="rights"> The rights associated with the rule. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="Relay.RelayAuthorizationRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static RelayAuthorizationRuleData RelayAuthorizationRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<RelayAccessRight> rights = null, AzureLocation? location = null)
            => RelayAuthorizationRuleData(id, name, resourceType, systemData, location, rights);
    }
}
