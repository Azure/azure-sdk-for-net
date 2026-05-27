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
    // These factory overloads preserve the model factory signatures shipped before the TypeSpec migration.
    // If the suppressions are removed, the generator emits overloads with incompatible required parameters
    // or Ipv4/Ipv6 parameter casing, which either breaks ApiCompat or conflicts with the custom overloads.
    [CodeGenSuppress("NetworkToNetworkInterconnectOptionBLayer3Configuration", typeof(string), typeof(string), typeof(string), typeof(string), typeof(long?), typeof(int?), typeof(long?))]
    [CodeGenSuppress("NetworkFabricAccessControlListData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(NetworkFabricConfigurationType?), typeof(Uri), typeof(CommunityActionType?), typeof(IEnumerable<AccessControlListMatchConfiguration>), typeof(IEnumerable<CommonDynamicMatchConfiguration>), typeof(DateTimeOffset?), typeof(NetworkFabricConfigurationState?), typeof(NetworkFabricProvisioningState?), typeof(NetworkFabricAdministrativeState?))]
    [CodeGenSuppress("NetworkFabricAccessControlListData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(NetworkFabricConfigurationType?), typeof(Uri), typeof(IEnumerable<AccessControlListMatchConfiguration>), typeof(IEnumerable<CommonDynamicMatchConfiguration>), typeof(DateTimeOffset?), typeof(NetworkFabricConfigurationState?), typeof(NetworkFabricProvisioningState?), typeof(NetworkFabricAdministrativeState?))]
    [CodeGenSuppress("NetworkFabricControllerData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(IDictionary<string, string>), typeof(AzureLocation), typeof(string), typeof(IEnumerable<ExpressRouteConnectionInformation>), typeof(IEnumerable<ExpressRouteConnectionInformation>), typeof(NetworkFabricControllerServices), typeof(NetworkFabricControllerServices), typeof(ManagedResourceGroupConfiguration), typeof(IEnumerable<ResourceIdentifier>), typeof(IsWorkloadManagementNetworkEnabled?), typeof(IEnumerable<ResourceIdentifier>), typeof(string), typeof(string), typeof(NetworkFabricControllerSKU?), typeof(NetworkFabricProvisioningState?), typeof(string), typeof(ManagedServiceIdentity))]
    [CodeGenSuppress("TerminalServerConfiguration", typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(IEnumerable<NetworkFabricSecretRotationStatus>))]
    [CodeGenSuppress("TerminalServerConfiguration", typeof(string), typeof(string), typeof(string), typeof(ResourceIdentifier), typeof(string), typeof(string), typeof(string), typeof(string))]
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

        /// <summary> Initializes a new instance of <see cref="Models.IPMatchCondition"/>. </summary>
        /// <param name="type"> IP Address type that needs to be matched. </param>
        /// <param name="prefixType"> IP Prefix Type that needs to be matched. </param>
        /// <param name="ipPrefixValues"> The list of IP Prefixes that need to be matched. </param>
        /// <param name="ipGroupNames"> The List of IP Group Names that need to be matched. </param>
        /// <returns> A new <see cref="Models.IPMatchCondition"/> instance for mocking. </returns>
        public static IPMatchCondition IPMatchCondition(SourceDestinationType? type = default, IPMatchConditionPrefixType? prefixType = default, IEnumerable<string> ipPrefixValues = default, IEnumerable<string> ipGroupNames = default)
        {
            ipPrefixValues ??= new ChangeTrackingList<string>();
            ipGroupNames ??= new ChangeTrackingList<string>();

            return new IPMatchCondition(type, prefixType, ipPrefixValues.ToList(), ipGroupNames.ToList(), additionalBinaryDataProperties: null);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="infrastructureExpressRouteConnections"> As part of an update, the Infrastructure ExpressRoute CircuitID should be provided to create and Provision a NFC. This Express route is dedicated for Infrastructure services. (This is a Mandatory attribute). </param>
        /// <param name="workloadExpressRouteConnections"> As part of an update, the workload ExpressRoute CircuitID should be provided to create and Provision a NFC. This Express route is dedicated for Workload services. (This is a Mandatory attribute). </param>
        /// <param name="infrastructureServices"> InfrastructureServices IP ranges. </param>
        /// <param name="workloadServices"> WorkloadServices IP ranges. </param>
        /// <param name="managedResourceGroupConfiguration"> Managed Resource Group configuration properties. </param>
        /// <param name="networkFabricIds"> The NF-ID will be an input parameter used by the NF to link and get associated with the parent NFC Service. </param>
        /// <param name="isWorkloadManagementNetworkEnabled"> A workload management network is required for all the tenant (workload) traffic. This traffic is only dedicated for Tenant workloads which are required to access internet or any other MSFT/Public endpoints. </param>
        /// <param name="tenantInternetGatewayIds"> List of tenant InternetGateway resource IDs. </param>
        /// <param name="ipv4AddressSpace"> IPv4 Network Fabric Controller Address Space. </param>
        /// <param name="ipv6AddressSpace"> IPv6 Network Fabric Controller Address Space. </param>
        /// <param name="nfcSku"> Network Fabric Controller SKU. </param>
        /// <param name="provisioningState"> Provides you the latest status of the NFC service, whether it is Accepted, updating, Succeeded or Failed. During this process, the states keep changing based on the status of NFC provisioning. </param>
        /// <param name="lastOperationDetails"> Details status of the last operation performed on the resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        /// <returns> A new <see cref="ManagedNetworkFabric.NetworkFabricControllerData"/> instance for mocking. </returns>
        public static NetworkFabricControllerData NetworkFabricControllerData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, string annotation = default, IEnumerable<ExpressRouteConnectionInformation> infrastructureExpressRouteConnections = default, IEnumerable<ExpressRouteConnectionInformation> workloadExpressRouteConnections = default, NetworkFabricControllerServices infrastructureServices = default, NetworkFabricControllerServices workloadServices = default, ManagedResourceGroupConfiguration managedResourceGroupConfiguration = default, IEnumerable<ResourceIdentifier> networkFabricIds = default, IsWorkloadManagementNetworkEnabled? isWorkloadManagementNetworkEnabled = default, IEnumerable<ResourceIdentifier> tenantInternetGatewayIds = default, string ipv4AddressSpace = default, string ipv6AddressSpace = default, NetworkFabricControllerSKU? nfcSku = default, NetworkFabricProvisioningState? provisioningState = default, string lastOperationDetails = default, ManagedServiceIdentity identity = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new NetworkFabricControllerData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                new NetworkFabricControllerProperties(
                    annotation,
                    (infrastructureExpressRouteConnections ?? new ChangeTrackingList<ExpressRouteConnectionInformation>()).ToList(),
                    (workloadExpressRouteConnections ?? new ChangeTrackingList<ExpressRouteConnectionInformation>()).ToList(),
                    infrastructureServices,
                    workloadServices,
                    managedResourceGroupConfiguration,
                    (networkFabricIds ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(),
                    isWorkloadManagementNetworkEnabled,
                    (tenantInternetGatewayIds ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(),
                    ipv4AddressSpace,
                    ipv6AddressSpace,
                    nfcSku,
                    new LastOperationProperties(lastOperationDetails, null),
                    provisioningState,
                    null),
                identity);
        }

        /// <summary> Initializes a new instance of <see cref="Models.TerminalServerConfiguration"/>. </summary>
        /// <param name="username"> Username for the terminal server connection. </param>
        /// <param name="password"> Password for the terminal server connection. </param>
        /// <param name="serialNumber"> Serial Number of Terminal server. </param>
        /// <param name="primaryIpv4Prefix"> IPv4 Address Prefix. </param>
        /// <param name="primaryIpv6Prefix"> IPv6 Address Prefix. </param>
        /// <param name="secondaryIpv4Prefix"> Secondary IPv4 Address Prefix. </param>
        /// <param name="secondaryIpv6Prefix"> Secondary IPv6 Address Prefix. </param>
        /// <param name="networkDeviceId"> ARM Resource ID used for the NetworkDevice. </param>
        /// <param name="secretRotationStatus"> Secret rotation status for the terminal server's secrets. </param>
        /// <returns> A new <see cref="Models.TerminalServerConfiguration"/> instance for mocking. </returns>
        public static TerminalServerConfiguration TerminalServerConfiguration(string username = default, string password = default, string serialNumber = default, string primaryIpv4Prefix = default, string primaryIpv6Prefix = default, string secondaryIpv4Prefix = default, string secondaryIpv6Prefix = default, ResourceIdentifier networkDeviceId = default, IEnumerable<NetworkFabricSecretRotationStatus> secretRotationStatus = default)
        {
            secretRotationStatus ??= new ChangeTrackingList<NetworkFabricSecretRotationStatus>();

            return new TerminalServerConfiguration(username, password, serialNumber, additionalBinaryDataProperties: null, primaryIpv4Prefix, primaryIpv6Prefix, secondaryIpv4Prefix, secondaryIpv6Prefix, networkDeviceId, secretRotationStatus.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.TerminalServerConfiguration"/>. </summary>
        /// <param name="username"> Username for the terminal server connection. </param>
        /// <param name="password"> Password for the terminal server connection. </param>
        /// <param name="serialNumber"> Serial Number of Terminal server. </param>
        /// <param name="networkDeviceId"> ARM Resource ID used for the NetworkDevice. </param>
        /// <param name="primaryIPv4Prefix"> IPv4 Address Prefix. </param>
        /// <param name="primaryIPv6Prefix"> IPv6 Address Prefix. </param>
        /// <param name="secondaryIPv4Prefix"> Secondary IPv4 Address Prefix. </param>
        /// <param name="secondaryIPv6Prefix"> Secondary IPv6 Address Prefix. </param>
        /// <returns> A new <see cref="Models.TerminalServerConfiguration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TerminalServerConfiguration TerminalServerConfiguration(string username, string password, string serialNumber, ResourceIdentifier networkDeviceId, string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix)
        {
            return TerminalServerConfiguration(username: username, password: password, serialNumber: serialNumber, primaryIpv4Prefix: primaryIPv4Prefix, primaryIpv6Prefix: primaryIPv6Prefix, secondaryIpv4Prefix: secondaryIPv4Prefix, secondaryIpv6Prefix: secondaryIPv6Prefix, networkDeviceId: networkDeviceId, secretRotationStatus: default);
        }
    }
}
