// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.EventHubs.Models
{
    public static partial class ArmEventHubsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsSchemaGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="updatedAtUtc"> Exact time the Schema Group was updated. </param>
        /// <param name="createdAtUtc"> Exact time the Schema Group was created. </param>
        /// <param name="eTag"> The ETag value. </param>
        /// <param name="groupProperties"> dictionary object for SchemaGroup group properties. </param>
        /// <param name="schemaCompatibility"></param>
        /// <param name="schemaType"></param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsSchemaGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsSchemaGroupData EventHubsSchemaGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? updatedAtUtc, DateTimeOffset? createdAtUtc, ETag? eTag, IDictionary<string, string> groupProperties, EventHubsSchemaCompatibility? schemaCompatibility, EventHubsSchemaType? schemaType, AzureLocation? location)
        {
            return EventHubsSchemaGroupData(id, name, resourceType, systemData, location, updatedAtUtc, createdAtUtc, eTag, groupProperties, schemaCompatibility, schemaType);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="partitionIds"> Current number of shards on the Event Hub. </param>
        /// <param name="createdOn"> Exact time the Event Hub was created. </param>
        /// <param name="updatedOn"> The exact time the message was updated. </param>
        /// <param name="partitionCount"> Number of partitions created for the Event Hub, allowed values are from 1 to 32 partitions. </param>
        /// <param name="status"> Enumerates the possible values for the status of the Event Hub. </param>
        /// <param name="userMetadata"> Gets and Sets Metadata of User. </param>
        /// <param name="captureDescription"> Properties of capture description. </param>
        /// <param name="retentionDescription"> Event Hub retention settings. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubData EventHubData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<string> partitionIds, DateTimeOffset? createdOn, DateTimeOffset? updatedOn, long? partitionCount, EventHubEntityStatus? status, string userMetadata, CaptureDescription captureDescription, RetentionDescription retentionDescription, AzureLocation? location)
        {
            return EventHubData(id, name, resourceType, systemData, location, partitionIds, createdOn, updatedOn, partitionCount, status, captureDescription, retentionDescription, messageTimestampType: default, identifier: default, userMetadata);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsApplicationGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isEnabled"> Determines if Application Group is allowed to create connection with namespace or not. Once the isEnabled is set to false, all the existing connections of application group gets dropped and no new connections will be allowed. </param>
        /// <param name="clientAppGroupIdentifier"> The Unique identifier for application group.Supports SAS(SASKeyName=KeyName) or AAD(AADAppID=Guid). </param>
        /// <param name="policies">
        /// List of group policies that define the behavior of application group. The policies can support resource governance scenarios such as limiting ingress or egress traffic.
        /// Please note <see cref="EventHubsApplicationGroupPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="EventHubsThrottlingPolicy"/>.
        /// </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsApplicationGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsApplicationGroupData EventHubsApplicationGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? isEnabled, string clientAppGroupIdentifier, IEnumerable<EventHubsApplicationGroupPolicy> policies, AzureLocation? location)
        {
            return EventHubsApplicationGroupData(id, name, resourceType, systemData, location, isEnabled, clientAppGroupIdentifier, policies);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsAuthorizationRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="rights"> The rights associated with the rule. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsAuthorizationRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsAuthorizationRuleData EventHubsAuthorizationRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<EventHubsAccessRight> rights, AzureLocation? location)
        {
            return EventHubsAuthorizationRuleData(id, name, resourceType, systemData, location, rights);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Properties of the cluster SKU. </param>
        /// <param name="createdOn"> The UTC time when the Event Hubs Cluster was created. </param>
        /// <param name="provisioningState"> Provisioning state of the Cluster. </param>
        /// <param name="updatedOn"> The UTC time when the Event Hubs Cluster was last updated. </param>
        /// <param name="metricId"> The metric ID of the cluster resource. Provided by the service and not modifiable by the user. </param>
        /// <param name="status"> Status of the Cluster resource. </param>
        /// <param name="supportsScaling"> A value that indicates whether Scaling is Supported. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsClusterData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsClusterData EventHubsClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, EventHubsClusterSku sku, DateTimeOffset? createdOn, EventHubsClusterProvisioningState? provisioningState, DateTimeOffset? updatedOn, string metricId, string status, bool? supportsScaling)
        {
            return EventHubsClusterData(id, name, resourceType, systemData, tags, location, sku, createdOn, provisioningState, updatedOn, metricId, status, supportsScaling, confidentialComputeMode: default);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsConsumerGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="createdOn"> Exact time the message was created. </param>
        /// <param name="updatedOn"> The exact time the message was updated. </param>
        /// <param name="userMetadata"> User Metadata is a placeholder to store user-defined string data with maximum length 1024. e.g. it can be used to store descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsConsumerGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsConsumerGroupData EventHubsConsumerGroupData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, DateTimeOffset? createdOn, DateTimeOffset? updatedOn, string userMetadata, AzureLocation? location)
        {
            return EventHubsConsumerGroupData(id, name, resourceType, systemData, location, createdOn, updatedOn, userMetadata);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsDisasterRecoveryData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of the Alias(Disaster Recovery configuration) - possible values 'Accepted' or 'Succeeded' or 'Failed'. </param>
        /// <param name="partnerNamespace"> ARM Id of the Primary/Secondary eventhub namespace name, which is part of GEO DR pairing. </param>
        /// <param name="alternateName"> Alternate name specified when alias and namespace names are same. </param>
        /// <param name="role"> role of namespace in GEO DR - possible values 'Primary' or 'PrimaryNotReplicating' or 'Secondary'. </param>
        /// <param name="pendingReplicationOperationsCount"> Number of entities pending to be replicated. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsDisasterRecoveryData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsDisasterRecoveryData EventHubsDisasterRecoveryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, EventHubsDisasterRecoveryProvisioningState? provisioningState, string partnerNamespace, string alternateName, EventHubsDisasterRecoveryRole? role, long? pendingReplicationOperationsCount, AzureLocation? location)
        {
            return EventHubsDisasterRecoveryData(id, name, resourceType, systemData, location, provisioningState, partnerNamespace, alternateName, role, pendingReplicationOperationsCount);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsNamespaceData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> Properties of sku resource. </param>
        /// <param name="identity"> Properties of BYOK Identity description. </param>
        /// <param name="minimumTlsVersion"> The minimum TLS version for the cluster to support, e.g. '1.2'. </param>
        /// <param name="provisioningState"> Provisioning state of the Namespace. </param>
        /// <param name="status"> Status of the Namespace. </param>
        /// <param name="createdOn"> The time the Namespace was created. </param>
        /// <param name="updatedOn"> The time the Namespace was updated. </param>
        /// <param name="serviceBusEndpoint"> Endpoint you can use to perform Service Bus operations. </param>
        /// <param name="clusterArmId"> Cluster ARM ID of the Namespace. </param>
        /// <param name="metricId"> Identifier for Azure Insights metrics. </param>
        /// <param name="isAutoInflateEnabled"> Value that indicates whether AutoInflate is enabled for eventhub namespace. </param>
        /// <param name="publicNetworkAccess"> This determines if traffic is allowed over public network. By default it is enabled. </param>
        /// <param name="maximumThroughputUnits"> Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units. ( '0' if AutoInflateEnabled = true). </param>
        /// <param name="kafkaEnabled"> Value that indicates whether Kafka is enabled for eventhub namespace. </param>
        /// <param name="zoneRedundant"> Enabling this property creates a Standard Event Hubs Namespace in regions supported availability zones. </param>
        /// <param name="encryption"> Properties of BYOK Encryption description. </param>
        /// <param name="privateEndpointConnections"> List of private endpoint connections. </param>
        /// <param name="disableLocalAuth"> This property disables SAS authentication for the Event Hubs namespace. </param>
        /// <param name="alternateName"> Alternate name specified when alias and namespace names are same. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsNamespaceData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsNamespaceData EventHubsNamespaceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, EventHubsSku sku, ManagedServiceIdentity identity, EventHubsTlsVersion? minimumTlsVersion, string provisioningState, string status, DateTimeOffset? createdOn, DateTimeOffset? updatedOn, string serviceBusEndpoint, ResourceIdentifier clusterArmId, string metricId, bool? isAutoInflateEnabled, EventHubsPublicNetworkAccess? publicNetworkAccess, int? maximumThroughputUnits, bool? kafkaEnabled, bool? zoneRedundant, EventHubsEncryption encryption, IEnumerable<EventHubsPrivateEndpointConnectionData> privateEndpointConnections, bool? disableLocalAuth, string alternateName)
        {
            return EventHubsNamespaceData(id, name, resourceType, systemData, tags, location, sku, identity, minimumTlsVersion, provisioningState, status, createdOn, updatedOn, serviceBusEndpoint, clusterArmId, metricId, isAutoInflateEnabled, publicNetworkAccess, maximumThroughputUnits, kafkaEnabled, zoneRedundant, encryption, privateEndpointConnections, disableLocalAuth, alternateName);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsNetworkRuleSetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="trustedServiceAccessEnabled"> Value that indicates whether Trusted Service Access is Enabled or not. </param>
        /// <param name="defaultAction"> Default Action for Network Rule Set. </param>
        /// <param name="virtualNetworkRules"> List VirtualNetwork Rules. </param>
        /// <param name="ipRules"> List of IpRules. </param>
        /// <param name="publicNetworkAccess"> This determines if traffic is allowed over public network. By default it is enabled. If value is SecuredByPerimeter then Inbound and Outbound communication is controlled by the network security perimeter and profile's access rules. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsNetworkRuleSetData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsNetworkRuleSetData EventHubsNetworkRuleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? trustedServiceAccessEnabled, EventHubsNetworkRuleSetDefaultAction? defaultAction, IEnumerable<EventHubsNetworkRuleSetVirtualNetworkRules> virtualNetworkRules, IEnumerable<EventHubsNetworkRuleSetIPRules> ipRules, EventHubsPublicNetworkAccessFlag? publicNetworkAccess, AzureLocation? location)
        {
            return EventHubsNetworkRuleSetData(id, name, resourceType, systemData, location, trustedServiceAccessEnabled, defaultAction, virtualNetworkRules, ipRules, publicNetworkAccess);
        }

        /// <summary> Initializes a new instance of <see cref="Models.EventHubsNetworkSecurityPerimeterConfiguration"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of NetworkSecurityPerimeter configuration propagation. </param>
        /// <param name="provisioningIssues"> List of Provisioning Issues if any. </param>
        /// <param name="networkSecurityPerimeter"> NetworkSecurityPerimeter related information. </param>
        /// <param name="resourceAssociation"> Information about resource association. </param>
        /// <param name="profile"> Information about current network profile. </param>
        /// <param name="isBackingResource"> True if the EventHub namespace is backed by another Azure resource and not visible to end users. </param>
        /// <param name="applicableFeatures"> Indicates that the NSP controls related to backing association are only applicable to a specific feature in backing resource's data plane. </param>
        /// <param name="parentAssociationName"> Source Resource Association name. </param>
        /// <param name="sourceResourceId"> ARM Id of source resource. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="Models.EventHubsNetworkSecurityPerimeterConfiguration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsNetworkSecurityPerimeterConfiguration EventHubsNetworkSecurityPerimeterConfiguration(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, EventHubsNetworkSecurityPerimeterConfigurationProvisioningState? provisioningState, IEnumerable<EventHubsProvisioningIssue> provisioningIssues, EventHubsNetworkSecurityPerimeter networkSecurityPerimeter, EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation resourceAssociation, EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile profile, bool? isBackingResource, IEnumerable<string> applicableFeatures, string parentAssociationName, ResourceIdentifier sourceResourceId, AzureLocation? location)
        {
            return EventHubsNetworkSecurityPerimeterConfiguration(id, name, resourceType, systemData, location, provisioningState, provisioningIssues, networkSecurityPerimeter, resourceAssociation, profile, isBackingResource, applicableFeatures, parentAssociationName, sourceResourceId);
        }

        /// <summary> Initializes a new instance of <see cref="EventHubs.EventHubsPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The Private Endpoint resource for this Connection. </param>
        /// <param name="connectionState"> Details about the state of the connection. </param>
        /// <param name="provisioningState"> Provisioning state of the Private Endpoint Connection. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="EventHubs.EventHubsPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static EventHubsPrivateEndpointConnectionData EventHubsPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId, EventHubsPrivateLinkServiceConnectionState connectionState, EventHubsPrivateEndpointConnectionProvisioningState? provisioningState, AzureLocation? location)
        {
            return EventHubsPrivateEndpointConnectionData(id, name, resourceType, systemData, location, privateEndpointId, connectionState, provisioningState);
        }
    }
}
