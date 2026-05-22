// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenSuppress("NetworkToNetworkInterconnectOptionBLayer3Configuration", typeof(string), typeof(string), typeof(string), typeof(string), typeof(long?), typeof(int?), typeof(long?))]
    [CodeGenSuppress("NetworkFabricPatch", typeof(IDictionary<string, string>), typeof(string), typeof(int?), typeof(int?), typeof(string), typeof(string), typeof(long?), typeof(TerminalServerPatchableProperties), typeof(ManagementNetworkConfigurationPatchableProperties), typeof(StorageAccountPatchConfiguration), typeof(int?), typeof(IEnumerable<ResourceIdentifier>), typeof(IEnumerable<ResourceIdentifier>), typeof(UniqueRouteDistinguisherPatchProperties), typeof(IEnumerable<FeatureFlagProperties>), typeof(AuthorizedTransceiverPatchProperties), typeof(QosConfigurationState?), typeof(ManagedServiceIdentityPatch))]
    [CodeGenSuppress("NetworkFabricAccessControlListData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(NetworkFabricConfigurationType?), typeof(Uri), typeof(CommunityActionType?), typeof(IEnumerable<AccessControlListMatchConfiguration>), typeof(IEnumerable<CommonDynamicMatchConfiguration>), typeof(DateTimeOffset?), typeof(NetworkFabricConfigurationState?), typeof(NetworkFabricProvisioningState?), typeof(NetworkFabricAdministrativeState?))]
    [CodeGenSuppress("NetworkFabricAccessControlListData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(NetworkFabricConfigurationType?), typeof(Uri), typeof(IEnumerable<AccessControlListMatchConfiguration>), typeof(IEnumerable<CommonDynamicMatchConfiguration>), typeof(DateTimeOffset?), typeof(NetworkFabricConfigurationState?), typeof(NetworkFabricProvisioningState?), typeof(NetworkFabricAdministrativeState?))]
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.NetworkToNetworkInterconnectOptionBLayer3Configuration"/>. </summary>
        /// <param name="primaryIPv4Prefix"> IPv4 Address Prefix. </param>
        /// <param name="primaryIPv6Prefix"> IPv6 Address Prefix. </param>
        /// <param name="secondaryIPv4Prefix"> Secondary IPv4 Address Prefix. </param>
        /// <param name="secondaryIPv6Prefix"> Secondary IPv6 Address Prefix. </param>
        /// <param name="peerAsn"> ASN of PE devices for CE/PE connectivity.Example : 28. </param>
        /// <param name="vlanId"> VLAN for CE/PE Layer 3 connectivity.Example : 501. </param>
        /// <param name="fabricAsn"> ASN of CE devices for CE/PE connectivity. </param>
        /// <returns> A new <see cref="Models.NetworkToNetworkInterconnectOptionBLayer3Configuration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkToNetworkInterconnectOptionBLayer3Configuration NetworkToNetworkInterconnectOptionBLayer3Configuration(string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, long? peerAsn, int? vlanId, long? fabricAsn)
        {
            return new NetworkToNetworkInterconnectOptionBLayer3Configuration(
                primaryIPv4Prefix,
                primaryIPv6Prefix,
                secondaryIPv4Prefix,
                secondaryIPv6Prefix,
                additionalBinaryDataProperties: null,
                peerAsn.GetValueOrDefault(),
                vlanId.GetValueOrDefault(),
                fabricAsn,
                default,
                default,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="Models.NetworkFabricPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="rackCount"> Number of compute racks associated to Network Fabric. </param>
        /// <param name="serverCountPerRack"> Number of servers.Possible values are from 1-16. </param>
        /// <param name="ipv4Prefix"> IPv4Prefix for Management Network. Example: 10.1.0.0/19. </param>
        /// <param name="ipv6Prefix"> IPv6Prefix for Management Network. Example: 3FFE:FFFF:0:CD40::/59. </param>
        /// <param name="fabricASN"> ASN of CE devices for CE/PE connectivity. </param>
        /// <param name="terminalServerConfiguration"> Network and credentials configuration already applied to terminal server. </param>
        /// <param name="managementNetworkConfiguration"> Configuration to be used to setup the management network. </param>
        /// <param name="storageAccountConfiguration"> Bring your own storage account configurations for Network Fabric. </param>
        /// <param name="hardwareAlertThreshold"> Hardware alert threshold percentage. Possible values are from 20 to 100. </param>
        /// <param name="controlPlaneAcls"> Control Plane Access Control List ARM resource IDs. </param>
        /// <param name="trustedIpPrefixes"> Trusted IP Prefix ARM resource IDs. </param>
        /// <param name="uniqueRdConfiguration"> Unique Route Distinguisher configuration. </param>
        /// <param name="featureFlags"> NetworkFabric feature flag configuration information. </param>
        /// <param name="authorizedTransceiver"> Authorized transciever configuration for NetworkFabric. </param>
        /// <param name="qosConfigurationState"> QoS configuration state. Default is Disabled. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <returns> A new <see cref="Models.NetworkFabricPatch"/> instance for mocking. </returns>
        public static NetworkFabricPatch NetworkFabricPatch(IDictionary<string, string> tags = default, string annotation = default, int? rackCount = default, int? serverCountPerRack = default, string ipv4Prefix = default, string ipv6Prefix = default, long? fabricASN = default, NetworkFabricPatchablePropertiesTerminalServerConfiguration terminalServerConfiguration = default, ManagementNetworkConfigurationPatchableProperties managementNetworkConfiguration = default, StorageAccountPatchConfiguration storageAccountConfiguration = default, int? hardwareAlertThreshold = default, IEnumerable<ResourceIdentifier> controlPlaneAcls = default, IEnumerable<ResourceIdentifier> trustedIpPrefixes = default, UniqueRouteDistinguisherPatchProperties uniqueRdConfiguration = default, IEnumerable<FeatureFlagProperties> featureFlags = default, AuthorizedTransceiverPatchProperties authorizedTransceiver = default, QosConfigurationState? qosConfigurationState = default, ManagedServiceIdentityPatch identity = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            NetworkFabricPatchablePropertiesTerminalServerConfiguration terminalServerPatchableProperties = terminalServerConfiguration is null
                ? default
                : new NetworkFabricPatchablePropertiesTerminalServerConfiguration
                {
                    Username = terminalServerConfiguration.Username,
                    Password = terminalServerConfiguration.Password,
                    SerialNumber = terminalServerConfiguration.SerialNumber,
                    PrimaryIpv4Prefix = terminalServerConfiguration.PrimaryIpv4Prefix,
                    PrimaryIpv6Prefix = terminalServerConfiguration.PrimaryIpv6Prefix,
                    SecondaryIpv4Prefix = terminalServerConfiguration.SecondaryIpv4Prefix,
                    SecondaryIpv6Prefix = terminalServerConfiguration.SecondaryIpv6Prefix
                };
            ManagementNetworkConfigurationPatchableProperties managementNetworkPatchConfiguration = managementNetworkConfiguration is null
                ? default
                : new ManagementNetworkConfigurationPatchableProperties
                {
                    InfrastructureVpnConfiguration = managementNetworkConfiguration.InfrastructureVpnConfiguration,
                    WorkloadVpnConfiguration = managementNetworkConfiguration.WorkloadVpnConfiguration
                };

            return new NetworkFabricPatch(tags, additionalBinaryDataProperties: null, annotation is null && rackCount is null && serverCountPerRack is null && ipv4Prefix is null && ipv6Prefix is null && fabricASN is null && terminalServerPatchableProperties is null && managementNetworkPatchConfiguration is null && storageAccountConfiguration is null && hardwareAlertThreshold is null && controlPlaneAcls is null && trustedIpPrefixes is null && uniqueRdConfiguration is null && featureFlags is null && authorizedTransceiver is null && qosConfigurationState is null ? default : new NetworkFabricPatchProperties(
                annotation,
                rackCount,
                serverCountPerRack,
                ipv4Prefix,
                ipv6Prefix,
                fabricASN,
                terminalServerPatchableProperties,
                managementNetworkPatchConfiguration,
                storageAccountConfiguration,
                hardwareAlertThreshold,
                (controlPlaneAcls ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(),
                (trustedIpPrefixes ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(),
                uniqueRdConfiguration,
                new QosPatchProperties(qosConfigurationState, null),
                (featureFlags ?? new ChangeTrackingList<FeatureFlagProperties>()).ToList(),
                authorizedTransceiver,
                null), identity);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkFabricAccessControlListData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="configurationType"> Input method to configure Access Control List. </param>
        /// <param name="aclsUri"> Access Control List file URL. </param>
        /// <param name="defaultAction"> Default action that needs to be applied when no condition is matched. Example: Permit | Deny. </param>
        /// <param name="matchConfigurations"> List of match configurations. </param>
        /// <param name="dynamicMatchConfigurations"> List of dynamic match configurations. </param>
        /// <param name="lastSyncedOn"> The last synced timestamp. </param>
        /// <param name="configurationState"> Configuration state of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="administrativeState"> Administrative state of the resource. </param>
        /// <returns> A new <see cref="ManagedNetworkFabric.NetworkFabricAccessControlListData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricAccessControlListData NetworkFabricAccessControlListData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, NetworkFabricConfigurationType? configurationType, Uri aclsUri, CommunityActionType? defaultAction, IEnumerable<AccessControlListMatchConfiguration> matchConfigurations, IEnumerable<CommonDynamicMatchConfiguration> dynamicMatchConfigurations, DateTimeOffset? lastSyncedOn, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricAccessControlListData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, annotation: annotation, configurationType: configurationType.GetValueOrDefault(), aclsUri: aclsUri, defaultAction: defaultAction, matchConfigurations: matchConfigurations, dynamicMatchConfigurations: dynamicMatchConfigurations, lastSyncedOn: lastSyncedOn, aclType: default, deviceRole: default, networkFabricIds: default, controlPlaneAclConfiguration: default, configurationState: configurationState, provisioningState: provisioningState, administrativeState: administrativeState, globalAccessControlListActionsEnableCount: default, lastOperationDetails: default);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkFabricAccessControlListData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="configurationType"> Input method to configure Access Control List. </param>
        /// <param name="aclsUri"> Access Control List file URL. </param>
        /// <param name="matchConfigurations"> List of match configurations. </param>
        /// <param name="dynamicMatchConfigurations"> List of dynamic match configurations. </param>
        /// <param name="lastSyncedOn"> The last synced timestamp. </param>
        /// <param name="configurationState"> Configuration state of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="administrativeState"> Administrative state of the resource. </param>
        /// <returns> A new <see cref="ManagedNetworkFabric.NetworkFabricAccessControlListData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricAccessControlListData NetworkFabricAccessControlListData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, NetworkFabricConfigurationType? configurationType, Uri aclsUri, IEnumerable<AccessControlListMatchConfiguration> matchConfigurations, IEnumerable<CommonDynamicMatchConfiguration> dynamicMatchConfigurations, DateTimeOffset? lastSyncedOn, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return NetworkFabricAccessControlListData(id: id, name: name, resourceType: resourceType, systemData: systemData, tags: tags, location: location, annotation: annotation, configurationType: configurationType.GetValueOrDefault(), aclsUri: aclsUri, defaultAction: default, matchConfigurations: matchConfigurations, dynamicMatchConfigurations: dynamicMatchConfigurations, lastSyncedOn: lastSyncedOn, aclType: default, deviceRole: default, networkFabricIds: default, controlPlaneAclConfiguration: default, configurationState: configurationState, provisioningState: provisioningState, administrativeState: administrativeState, globalAccessControlListActionsEnableCount: default, lastOperationDetails: default);
        }
    }
}
