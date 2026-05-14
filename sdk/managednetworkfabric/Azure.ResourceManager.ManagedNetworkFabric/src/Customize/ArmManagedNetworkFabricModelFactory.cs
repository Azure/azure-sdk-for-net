// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0419 // Ambiguous reference in cref attribute

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // Backward compatibility overloads for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added parameters to several model factory methods. These overloads preserve
    // the v1.1.2 method signatures by delegating to the new methods with default values for new parameters.
    /// <summary> Model factory for models. </summary>
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricInternetGatewayData NetworkFabricInternetGatewayData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, ResourceIdentifier internetGatewayRuleId, IPAddress ipv4Address, int? port, InternetGatewayType typePropertiesType, ResourceIdentifier networkFabricControllerId, NetworkFabricProvisioningState? provisioningState)
        {
            return NetworkFabricInternetGatewayData(id, name, resourceType, systemData, tags, location, annotation, internetGatewayRuleId, ipv4Address, port, typePropertiesType, networkFabricControllerId, provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="Models.ExternalNetworkPatchOptionAProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ExternalNetworkPatchOptionAProperties ExternalNetworkPatchOptionAProperties(string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, int? mtu, int? vlanId, long? fabricAsn, long? peerAsn, BfdConfiguration bfdConfiguration, ResourceIdentifier ingressAclId, ResourceIdentifier egressAclId)
        {
            return ExternalNetworkPatchOptionAProperties(
                primaryIPv4Prefix: primaryIPv4Prefix,
                primaryIPv6Prefix: primaryIPv6Prefix,
                secondaryIPv4Prefix: secondaryIPv4Prefix,
                secondaryIPv6Prefix: secondaryIPv6Prefix,
                mtu: mtu,
                vlanId: vlanId,
                fabricAsn: fabricAsn,
                peerAsn: peerAsn,
                bfdConfiguration: default,
                ingressAclId: ingressAclId,
                egressAclId: egressAclId,
                bmpConfigurationState: default,
                v4OverV6BgpSession: default,
                v6OverV4BgpSession: default,
                nativeIPv4PrefixLimits: default,
                nativeIPv6PrefixLimits: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InternalNetworkBgpConfiguration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static InternalNetworkBgpConfiguration InternalNetworkBgpConfiguration(string annotation, BfdConfiguration bfdConfiguration, NetworkFabricBooleanValue? defaultRouteOriginate, int? allowAS, AllowASOverride? allowASOverride, long? fabricAsn, long? peerAsn, IEnumerable<string> ipv4ListenRangePrefixes, IEnumerable<string> ipv6ListenRangePrefixes, IEnumerable<NeighborAddress> ipv4NeighborAddress, IEnumerable<NeighborAddress> ipv6NeighborAddress)
        {
            BgpConfiguration result = BgpConfiguration(
                annotation: annotation,
                bfdConfiguration: bfdConfiguration,
                defaultRouteOriginate: defaultRouteOriginate,
                allowAS: allowAS,
                allowASOverride: allowASOverride,
                fabricAsn: fabricAsn,
                peerAsn: peerAsn,
                ipv4ListenRangePrefixes: ipv4ListenRangePrefixes,
                ipv6ListenRangePrefixes: ipv6ListenRangePrefixes,
                ipv4NeighborAddress: ipv4NeighborAddress,
                ipv6NeighborAddress: ipv6NeighborAddress);

            return new InternalNetworkBgpConfiguration();
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetworkToNetworkInterconnectOptionBLayer3Configuration"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkToNetworkInterconnectOptionBLayer3Configuration NetworkToNetworkInterconnectOptionBLayer3Configuration(string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, long? peerAsn, int? vlanId, long? fabricAsn)
        {
            OptionBLayer3Configuration result = OptionBLayer3Configuration(
                primaryIPv4Prefix: primaryIPv4Prefix,
                primaryIPv6Prefix: primaryIPv6Prefix,
                secondaryIPv4Prefix: secondaryIPv4Prefix,
                secondaryIPv6Prefix: secondaryIPv6Prefix,
                peerAsn: peerAsn,
                vlanId: vlanId,
                fabricAsn: fabricAsn);

            return new NetworkToNetworkInterconnectOptionBLayer3Configuration();
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetworkToNetworkInterconnectPatch"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkToNetworkInterconnectPatch NetworkToNetworkInterconnectPatch(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, Layer2Configuration layer2Configuration, OptionBLayer3Configuration optionBLayer3Configuration, NpbStaticRouteConfiguration npbStaticRouteConfiguration, ImportRoutePolicyInformation importRoutePolicy, ExportRoutePolicyInformation exportRoutePolicy, ResourceIdentifier egressAclId, ResourceIdentifier ingressAclId)
        {
            return NetworkToNetworkInterconnectPatch(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                layer2Configuration: default,
                optionBLayer3Configuration: default,
                npbStaticRouteConfiguration: default,
                staticRouteConfiguration: default,
                importRoutePolicy: default,
                exportRoutePolicy: default,
                egressAclId: egressAclId,
                ingressAclId: ingressAclId,
                microBfdState: default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.VpnConfigurationProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VpnConfigurationProperties VpnConfigurationProperties(ResourceIdentifier networkToNetworkInterconnectId, NetworkFabricAdministrativeState? administrativeState, PeeringOption peeringOption, OptionBProperties optionBProperties, VpnConfigurationOptionAProperties optionAProperties)
        {
            return VpnConfigurationProperties(
                networkToNetworkInterconnectId: networkToNetworkInterconnectId,
                administrativeState: administrativeState,
                peeringOption: peeringOption,
                optionBProperties: (OptionBProperties)default,
                optionAProperties: (VpnConfigurationOptionAProperties)default);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricControllerData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricControllerData NetworkFabricControllerData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, IEnumerable<ExpressRouteConnectionInformation> infrastructureExpressRouteConnections, IEnumerable<ExpressRouteConnectionInformation> workloadExpressRouteConnections, NetworkFabricControllerServices infrastructureServices, NetworkFabricControllerServices workloadServices, ManagedResourceGroupConfiguration managedResourceGroupConfiguration, IEnumerable<ResourceIdentifier> networkFabricIds, bool? isWorkloadManagementNetwork, IsWorkloadManagementNetworkEnabled? isWorkloadManagementNetworkEnabled, IEnumerable<ResourceIdentifier> tenantInternetGatewayIds, string ipv4AddressSpace, string ipv6AddressSpace, NetworkFabricControllerSKU? nfcSku, NetworkFabricProvisioningState? provisioningState)
        {
            return NetworkFabricControllerData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                identity: default,
                annotation: annotation,
                infrastructureExpressRouteConnections: infrastructureExpressRouteConnections,
                workloadExpressRouteConnections: workloadExpressRouteConnections,
                infrastructureServices: infrastructureServices,
                workloadServices: workloadServices,
                managedResourceGroupConfiguration: managedResourceGroupConfiguration,
                networkFabricIds: networkFabricIds,
                isWorkloadManagementNetworkEnabled: isWorkloadManagementNetworkEnabled,
                tenantInternetGatewayIds: tenantInternetGatewayIds,
                ipv4AddressSpace: ipv4AddressSpace,
                ipv6AddressSpace: ipv6AddressSpace,
                nfcSku: nfcSku,
                lastOperationDetails: default,
                provisioningState: provisioningState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricExternalNetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricExternalNetworkData NetworkFabricExternalNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string annotation, ResourceIdentifier importRoutePolicyId, ResourceIdentifier exportRoutePolicyId, ImportRoutePolicy importRoutePolicy, ExportRoutePolicy exportRoutePolicy, ResourceIdentifier networkToNetworkInterconnectId, PeeringOption peeringOption, L3OptionBProperties optionBProperties, ExternalNetworkOptionAProperties optionAProperties, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricExternalNetworkData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                annotation: annotation,
                networkToNetworkInterconnectId: networkToNetworkInterconnectId,
                importRoutePolicy: importRoutePolicy,
                exportRoutePolicy: exportRoutePolicy,
                peeringOption: peeringOption,
                optionBProperties: optionBProperties,
                optionAProperties: optionAProperties,
                staticRouteConfiguration: default,
                lastOperationDetails: default,
                networkFabricId: default,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternalNetworkData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricInternalNetworkData NetworkFabricInternalNetworkData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string annotation, int? mtu, IEnumerable<ConnectedSubnet> connectedIPv4Subnets, IEnumerable<ConnectedSubnet> connectedIPv6Subnets, ResourceIdentifier importRoutePolicyId, ResourceIdentifier exportRoutePolicyId, ImportRoutePolicy importRoutePolicy, ExportRoutePolicy exportRoutePolicy, ResourceIdentifier ingressAclId, ResourceIdentifier egressAclId, IsMonitoringEnabled? isMonitoringEnabled, StaticRouteConfigurationExtension? extension, int vlanId, InternalNetworkBgpConfiguration bgpConfiguration, InternalNetworkStaticRouteConfiguration staticRouteConfiguration, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricInternalNetworkData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                annotation: annotation,
                extension: extension,
                mtu: mtu,
                connectedIPv4Subnets: connectedIPv4Subnets,
                connectedIPv6Subnets: connectedIPv6Subnets,
                importRoutePolicy: importRoutePolicy,
                exportRoutePolicy: exportRoutePolicy,
                ingressAclId: ingressAclId,
                egressAclId: egressAclId,
                isMonitoringEnabled: isMonitoringEnabled,
                vlanId: vlanId,
                bgpConfiguration: bgpConfiguration,
                staticRouteConfiguration: staticRouteConfiguration,
                nativeIPv4PrefixLimits: default,
                nativeIPv6PrefixLimits: default,
                lastOperationDetails: default,
                networkFabricId: default,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricL3IsolationDomainData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricL3IsolationDomainData NetworkFabricL3IsolationDomainData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, RedistributeConnectedSubnet? redistributeConnectedSubnets, RedistributeStaticRoute? redistributeStaticRoutes, AggregateRouteConfiguration aggregateRouteConfiguration, ConnectedSubnetRoutePolicy connectedSubnetRoutePolicy, ResourceIdentifier networkFabricId, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricL3IsolationDomainData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                identity: default,
                annotation: annotation,
                redistributeConnectedSubnets: redistributeConnectedSubnets,
                redistributeStaticRoutes: redistributeStaticRoutes,
                aggregateRouteConfiguration: aggregateRouteConfiguration,
                connectedSubnetRoutePolicy: connectedSubnetRoutePolicy,
                networkFabricId: networkFabricId,
                staticRouteExportRoutePolicy: default,
                uniqueRds: default,
                v4RoutePrefixLimit: default,
                v6RoutePrefixLimit: default,
                lastOperationDetails: default,
                exportPolicies: default,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkTapData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkTapData NetworkTapData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, ResourceIdentifier networkPacketBrokerId, ResourceIdentifier sourceTapRuleId, IEnumerable<NetworkTapPropertiesDestinationsItem> destinations, NetworkTapPollingType? pollingType, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkTapData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                identity: default,
                annotation: annotation,
                networkPacketBrokerId: networkPacketBrokerId,
                sourceTapRuleId: sourceTapRuleId,
                networkFabricIds: default,
                destinations: destinations,
                pollingType: pollingType,
                lastOperationDetails: default,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkTapRuleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkTapRuleData NetworkTapRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, NetworkFabricConfigurationType? configurationType, Uri tapRulesUri, IEnumerable<NetworkTapRuleMatchConfiguration> matchConfigurations, IEnumerable<CommonDynamicMatchConfiguration> dynamicMatchConfigurations, ResourceIdentifier networkTapId, PollingIntervalInSecond? pollingIntervalInSeconds, DateTimeOffset? lastSyncedOn, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkTapRuleData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                tags: tags,
                location: location,
                identity: default,
                annotation: annotation,
                configurationType: configurationType ?? default,
                tapRulesUri: tapRulesUri,
                identitySelector: default,
                matchConfigurations: matchConfigurations,
                dynamicMatchConfigurations: dynamicMatchConfigurations,
                networkTapId: networkTapId,
                networkTapIds: default,
                pollingIntervalInSeconds: pollingIntervalInSeconds.HasValue ? (int?)int.Parse(pollingIntervalInSeconds.Value.ToString()) : default,
                lastSyncedOn: lastSyncedOn,
                globalNetworkTapRuleActions: default,
                lastOperationDetails: default,
                networkFabricIds: default,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }

        /// <summary> Initializes a new instance of <see cref="NetworkToNetworkInterconnectData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkToNetworkInterconnectData NetworkToNetworkInterconnectData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, NniType? nniType, IsManagementType? isManagementType, NetworkFabricBooleanValue useOptionB, Layer2Configuration layer2Configuration, NetworkToNetworkInterconnectOptionBLayer3Configuration optionBLayer3Configuration, NpbStaticRouteConfiguration npbStaticRouteConfiguration, ImportRoutePolicyInformation importRoutePolicy, ExportRoutePolicyInformation exportRoutePolicy, ResourceIdentifier egressAclId, ResourceIdentifier ingressAclId, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkToNetworkInterconnectData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                nniType: nniType,
                isManagementType: isManagementType,
                useOptionB: useOptionB,
                layer2Configuration: layer2Configuration,
                optionBLayer3Configuration: optionBLayer3Configuration,
                npbStaticRouteConfiguration: npbStaticRouteConfiguration,
                staticRouteConfiguration: default,
                importRoutePolicy: importRoutePolicy,
                exportRoutePolicy: exportRoutePolicy,
                egressAclId: egressAclId,
                ingressAclId: ingressAclId,
                microBfdState: default,
                conditionalDefaultRouteConfiguration: default,
                lastOperationDetails: default,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }
    }
}
