// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    [CodeGenSuppress("NetworkToNetworkInterconnectOptionBLayer3Configuration", typeof(string), typeof(string), typeof(string), typeof(string), typeof(long?), typeof(int?), typeof(long?))]
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
