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

namespace Azure.ResourceManager.ServiceBus.Models
{
    public static partial class ArmServiceBusModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ServiceBus.MigrationConfigurationData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of Migration Configuration. </param>
        /// <param name="pendingReplicationOperationsCount"> Number of entities pending to be replicated. </param>
        /// <param name="targetServiceBusNamespace"> Existing premium Namespace ARM Id name which has no entities, will be used for migration. </param>
        /// <param name="postMigrationName"> Name to access Standard Namespace after migration. </param>
        /// <param name="migrationState"> State in which Standard to Premium Migration is, possible values : Unknown, Reverting, Completing, Initiating, Syncing, Active. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="ServiceBus.MigrationConfigurationData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MigrationConfigurationData MigrationConfigurationData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string provisioningState, long? pendingReplicationOperationsCount, ResourceIdentifier targetServiceBusNamespace, string postMigrationName, string migrationState, AzureLocation? location)
        {
            return new MigrationConfigurationData(
                id,
                name,
                resourceType,
                systemData,
                provisioningState,
                location,
                pendingReplicationOperationsCount,
                targetServiceBusNamespace,
                postMigrationName,
                migrationState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ServiceBus.ServiceBusAuthorizationRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="rights"> The rights associated with the rule. </param>
        /// <returns> A new <see cref="ServiceBus.ServiceBusAuthorizationRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusAuthorizationRuleData ServiceBusAuthorizationRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IEnumerable<ServiceBusAccessRight> rights, AzureLocation? location)
        {
            rights ??= new List<ServiceBusAccessRight>();

            return new ServiceBusAuthorizationRuleData(
                id,
                name,
                resourceType,
                systemData,
                location,
                rights?.ToList(),
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ServiceBus.ServiceBusDisasterRecoveryData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> Provisioning state of the Alias(Disaster Recovery configuration) - possible values 'Accepted' or 'Succeeded' or 'Failed'. </param>
        /// <param name="pendingReplicationOperationsCount"> Number of entities pending to be replicated. </param>
        /// <param name="partnerNamespace"> ARM Id of the Primary/Secondary eventhub namespace name, which is part of GEO DR pairing. </param>
        /// <param name="alternateName"> Primary/Secondary eventhub namespace name, which is part of GEO DR pairing. </param>
        /// <param name="role"> role of namespace in GEO DR - possible values 'Primary' or 'PrimaryNotReplicating' or 'Secondary'. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="ServiceBus.ServiceBusDisasterRecoveryData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusDisasterRecoveryData ServiceBusDisasterRecoveryData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ServiceBusDisasterRecoveryProvisioningState? provisioningState, long? pendingReplicationOperationsCount, string partnerNamespace, string alternateName, ServiceBusDisasterRecoveryRole? role, AzureLocation? location)
        {
            return new ServiceBusDisasterRecoveryData(
                id,
                name,
                resourceType,
                systemData,
                location,
                provisioningState,
                pendingReplicationOperationsCount,
                partnerNamespace,
                alternateName,
                role,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ServiceBus.ServiceBusNetworkRuleSetData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="isTrustedServiceAccessEnabled"> Value that indicates whether Trusted Service Access is Enabled or not. </param>
        /// <param name="defaultAction"> Default Action for Network Rule Set. </param>
        /// <param name="virtualNetworkRules"> List VirtualNetwork Rules. </param>
        /// <param name="ipRules"> List of IpRules. </param>
        /// <param name="publicNetworkAccess"> This determines if traffic is allowed over public network. By default it is enabled. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="ServiceBus.ServiceBusNetworkRuleSetData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusNetworkRuleSetData ServiceBusNetworkRuleSetData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, bool? isTrustedServiceAccessEnabled, ServiceBusNetworkRuleSetDefaultAction? defaultAction, IEnumerable<ServiceBusNetworkRuleSetVirtualNetworkRules> virtualNetworkRules, IEnumerable<ServiceBusNetworkRuleSetIPRules> ipRules, ServiceBusPublicNetworkAccessFlag? publicNetworkAccess, AzureLocation? location)
        {
            virtualNetworkRules ??= new List<ServiceBusNetworkRuleSetVirtualNetworkRules>();
            ipRules ??= new List<ServiceBusNetworkRuleSetIPRules>();

            return new ServiceBusNetworkRuleSetData(
                id,
                name,
                resourceType,
                systemData,
                location,
                isTrustedServiceAccessEnabled,
                defaultAction,
                virtualNetworkRules?.ToList(),
                ipRules?.ToList(),
                publicNetworkAccess,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ServiceBus.ServiceBusPrivateEndpointConnectionData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="privateEndpointId"> The Private Endpoint resource for this Connection. </param>
        /// <param name="connectionState"> Details about the state of the connection. </param>
        /// <param name="provisioningState"> Provisioning state of the Private Endpoint Connection. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="ServiceBus.ServiceBusPrivateEndpointConnectionData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusPrivateEndpointConnectionData ServiceBusPrivateEndpointConnectionData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ResourceIdentifier privateEndpointId, ServiceBusPrivateLinkServiceConnectionState connectionState, ServiceBusPrivateEndpointConnectionProvisioningState? provisioningState, AzureLocation? location)
        {
            return new ServiceBusPrivateEndpointConnectionData(
                id,
                name,
                resourceType,
                systemData,
                location,
                privateEndpointId != null ? ResourceManagerModelFactory.WritableSubResource(privateEndpointId) : null,
                connectionState,
                provisioningState,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="ServiceBus.ServiceBusRuleData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="action"> Represents the filter actions which are allowed for the transformation of a message that have been matched by a filter expression. </param>
        /// <param name="filterType"> Filter type that is evaluated against a BrokeredMessage. </param>
        /// <param name="sqlFilter"> Properties of sqlFilter. </param>
        /// <param name="correlationFilter"> Properties of correlationFilter. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <returns> A new <see cref="ServiceBus.ServiceBusRuleData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ServiceBusRuleData ServiceBusRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, ServiceBusFilterAction action, ServiceBusFilterType? filterType, ServiceBusSqlFilter sqlFilter, ServiceBusCorrelationFilter correlationFilter, AzureLocation? location)
        {
            return new ServiceBusRuleData(
                id,
                name,
                resourceType,
                systemData,
                location,
                action,
                filterType,
                sqlFilter,
                correlationFilter,
                serializedAdditionalRawData: null);
        }
    }
}
