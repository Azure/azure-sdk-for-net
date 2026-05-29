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
    public static partial class ArmManagedNetworkFabricModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.InternalNetworkBgpConfiguration"/>. </summary>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="bfdConfiguration"> BFD configuration properties. </param>
        /// <param name="defaultRouteOriginate"> Originate a defaultRoute. Ex: "True" | "False". </param>
        /// <param name="allowAS"> Allows for routes to be received and processed even if the router detects its own ASN in the AS-Path. 0 is disable, Possible values are 1-10, default is 2. </param>
        /// <param name="allowASOverride"> Enable Or Disable state. </param>
        /// <param name="fabricAsn"> ASN of Network Fabric. Example: 65048. </param>
        /// <param name="peerAsn"> Peer ASN. Example: 65047. </param>
        /// <param name="ipv4ListenRangePrefixes"> List of BGP IPv4 Listen Range prefixes. </param>
        /// <param name="ipv6ListenRangePrefixes"> List of BGP IPv6 Listen Ranges prefixes. </param>
        /// <param name="ipv4NeighborAddress"> List with stringified IPv4 Neighbor Addresses. </param>
        /// <param name="ipv6NeighborAddress"> List with stringified IPv6 Neighbor Address. </param>
        /// <returns> A new <see cref="Models.InternalNetworkBgpConfiguration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use BgpConfiguration instead.")]
        public static InternalNetworkBgpConfiguration InternalNetworkBgpConfiguration(string annotation, BfdConfiguration bfdConfiguration, NetworkFabricBooleanValue? defaultRouteOriginate, int? allowAS, AllowASOverride? allowASOverride, long? fabricAsn, long? peerAsn, IEnumerable<string> ipv4ListenRangePrefixes, IEnumerable<string> ipv6ListenRangePrefixes, IEnumerable<NeighborAddress> ipv4NeighborAddress, IEnumerable<NeighborAddress> ipv6NeighborAddress)
            => new InternalNetworkBgpConfiguration(annotation, additionalBinaryDataProperties: null, bfdConfiguration, defaultRouteOriginate, allowAS, allowASOverride, fabricAsn, peerAsn, (ipv4ListenRangePrefixes ?? new ChangeTrackingList<string>()).ToList(), (ipv6ListenRangePrefixes ?? new ChangeTrackingList<string>()).ToList(), (ipv4NeighborAddress ?? new ChangeTrackingList<NeighborAddress>()).ToList(), (ipv6NeighborAddress ?? new ChangeTrackingList<NeighborAddress>()).ToList(), bmpConfiguration: default, v4OverV6BgpSession: default, v6OverV4BgpSession: default);

        /// <summary> Initializes a new instance of <see cref="Models.InternalNetworkBgpConfiguration"/>. </summary>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="bfdConfiguration"> BFD configuration properties. </param>
        /// <param name="defaultRouteOriginate"> Originate a defaultRoute. Ex: "True" | "False". </param>
        /// <param name="allowAS"> Allows for routes to be received and processed even if the router detects its own ASN in the AS-Path. 0 is disable, Possible values are 1-10, default is 2. </param>
        /// <param name="allowASOverride"> Enable Or Disable state. </param>
        /// <param name="fabricAsn"> ASN of Network Fabric. Example: 65048. </param>
        /// <param name="peerAsn"> Peer ASN. Example: 65047. </param>
        /// <param name="iPv4ListenRangePrefixes"> List of BGP IPv4 Listen Range prefixes. </param>
        /// <param name="iPv6ListenRangePrefixes"> List of BGP IPv6 Listen Ranges prefixes. </param>
        /// <param name="iPv4NeighborAddress"> List with stringified IPv4 Neighbor Addresses. </param>
        /// <param name="iPv6NeighborAddress"> List with stringified IPv6 Neighbor Address. </param>
        /// <param name="bmpConfiguration"> Bmp configuration properties. </param>
        /// <param name="v4OverV6BgpSession"> State. </param>
        /// <param name="v6OverV4BgpSession"> State. </param>
        /// <returns> A new <see cref="Models.InternalNetworkBgpConfiguration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use BgpConfiguration instead.")]
        public static InternalNetworkBgpConfiguration InternalNetworkBgpConfiguration(string annotation = default, BfdConfiguration bfdConfiguration = default, NetworkFabricBooleanValue? defaultRouteOriginate = default, int? allowAS = default, AllowASOverride? allowASOverride = default, long? fabricAsn = default, long? peerAsn = default, IEnumerable<string> iPv4ListenRangePrefixes = default, IEnumerable<string> iPv6ListenRangePrefixes = default, IEnumerable<NeighborAddress> iPv4NeighborAddress = default, IEnumerable<NeighborAddress> iPv6NeighborAddress = default, InternalNetworkBmpProperties bmpConfiguration = default, NetworkFabricV4OverV6BgpSessionState? v4OverV6BgpSession = default, NetworkFabricV6OverV4BgpSessionState? v6OverV4BgpSession = default)
            => new InternalNetworkBgpConfiguration(annotation, additionalBinaryDataProperties: null, bfdConfiguration, defaultRouteOriginate, allowAS, allowASOverride, fabricAsn, peerAsn, (iPv4ListenRangePrefixes ?? new ChangeTrackingList<string>()).ToList(), (iPv6ListenRangePrefixes ?? new ChangeTrackingList<string>()).ToList(), (iPv4NeighborAddress ?? new ChangeTrackingList<NeighborAddress>()).ToList(), (iPv6NeighborAddress ?? new ChangeTrackingList<NeighborAddress>()).ToList(), bmpConfiguration, v4OverV6BgpSession, v6OverV4BgpSession);

        /// <summary> Network and credential configuration currently applied on terminal server. </summary>
        /// <param name="networkToNetworkInterconnectId"> ARM Resource ID of the Network To Network Interconnect. </param>
        /// <param name="administrativeState"> Administrative state of the resource. </param>
        /// <param name="peeringOption"> Peering option list. </param>
        /// <param name="optionBProperties"> option B properties. </param>
        /// <param name="optionAProperties"> option A properties. </param>
        /// <returns> A new <see cref="Models.VpnConfigurationProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use the overload with VpnOptionAProperties instead.")]
        public static VpnConfigurationProperties VpnConfigurationProperties(ResourceIdentifier networkToNetworkInterconnectId = default, NetworkFabricAdministrativeState? administrativeState = default, PeeringOption peeringOption = default, OptionBProperties optionBProperties = default, VpnConfigurationOptionAProperties optionAProperties = default)
        {
            return new VpnConfigurationProperties(
                networkToNetworkInterconnectId,
                administrativeState,
                peeringOption,
                optionBProperties,
                optionAProperties?.ToVpnOptionAProperties(),
                additionalBinaryDataProperties: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.InternalNetworkStaticRouteConfiguration"/>. </summary>
        /// <param name="bfdConfiguration"> BFD configuration properties. </param>
        /// <param name="iPv4Routes"> List of IPv4 Routes. </param>
        /// <param name="iPv6Routes"> List of IPv6 Routes. </param>
        /// <param name="extension"> Extension. Example: NoExtension | NPB. </param>
        /// <returns> A new <see cref="Models.InternalNetworkStaticRouteConfiguration"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use StaticRouteConfiguration instead.")]
        public static InternalNetworkStaticRouteConfiguration InternalNetworkStaticRouteConfiguration(BfdConfiguration bfdConfiguration = default, IEnumerable<StaticRouteProperties> iPv4Routes = default, IEnumerable<StaticRouteProperties> iPv6Routes = default, StaticRouteConfigurationExtension? extension = default)
            => new InternalNetworkStaticRouteConfiguration(bfdConfiguration, (iPv4Routes ?? new ChangeTrackingList<StaticRouteProperties>()).ToList(), (iPv6Routes ?? new ChangeTrackingList<StaticRouteProperties>()).ToList(), extension, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkFabricInternalNetworkData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="annotation"> Switch configuration description. </param>
        /// <param name="mtu"> Maximum transmission unit. Default value is 1500. </param>
        /// <param name="connectedIPv4Subnets"> List of Connected IPv4 Subnets. </param>
        /// <param name="connectedIPv6Subnets"> List of connected IPv6 Subnets. </param>
        /// <param name="importRoutePolicyId"> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </param>
        /// <param name="exportRoutePolicyId"> ARM Resource ID of the RoutePolicy. This is used for the backward compatibility. </param>
        /// <param name="importRoutePolicy"> Import Route Policy either IPv4 or IPv6. </param>
        /// <param name="exportRoutePolicy"> Export Route Policy either IPv4 or IPv6. </param>
        /// <param name="ingressAclId"> Ingress Acl. ARM resource ID of Access Control Lists. </param>
        /// <param name="egressAclId"> Egress Acl. ARM resource ID of Access Control Lists. </param>
        /// <param name="isMonitoringEnabled"> To check whether monitoring of internal network is enabled or not. </param>
        /// <param name="extension"> Extension. Example: NoExtension | NPB. </param>
        /// <param name="vlanId"> Vlan identifier. Example: 1001. </param>
        /// <param name="bgpConfiguration"> BGP configuration properties. </param>
        /// <param name="staticRouteConfiguration"> Static Route Configuration properties. </param>
        /// <param name="configurationState"> Configuration state of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="administrativeState"> Administrative state of the resource. </param>
        /// <returns> A new <see cref="ManagedNetworkFabric.NetworkFabricInternalNetworkData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use the overload with BgpConfiguration bgpSettings instead.")]
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
                bgpSettings: bgpConfiguration,
                staticRouteSettings: staticRouteConfiguration,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);
        }

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
        [Obsolete("This method is obsolete and will be removed in a future version. Use OptionBLayer3Configuration instead.")]
        public static NetworkToNetworkInterconnectOptionBLayer3Configuration NetworkToNetworkInterconnectOptionBLayer3Configuration(string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix, long? peerAsn, int? vlanId, long? fabricAsn)
        {
            return new NetworkToNetworkInterconnectOptionBLayer3Configuration(
                primaryIPv4Prefix,
                primaryIPv6Prefix,
                secondaryIPv4Prefix,
                secondaryIPv6Prefix,
                additionalBinaryDataProperties: null,
                peerAsn,
                vlanId,
                fabricAsn,
                default,
                default,
                default);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkToNetworkInterconnectData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="nniType"> Type of NNI used. Example: CE | NPB. </param>
        /// <param name="isManagementType"> Configuration to use NNI for Infrastructure Management. Example: True/False. </param>
        /// <param name="useOptionB"> Based on this option layer3 parameters are mandatory. Example: True/False. </param>
        /// <param name="layer2Configuration"> Common properties for Layer2 Configuration. </param>
        /// <param name="optionBLayer3Configuration"> Common properties for Layer3Configuration. </param>
        /// <param name="npbStaticRouteConfiguration"> NPB Static Route Configuration properties. </param>
        /// <param name="importRoutePolicy"> Import Route Policy configuration. </param>
        /// <param name="exportRoutePolicy"> Export Route Policy configuration. </param>
        /// <param name="egressAclId"> Egress Acl. ARM resource ID of Access Control Lists. </param>
        /// <param name="ingressAclId"> Ingress Acl. ARM resource ID of Access Control Lists. </param>
        /// <param name="configurationState"> Configuration state of the resource. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="administrativeState"> Administrative state of the resource. </param>
        /// <returns> A new <see cref="ManagedNetworkFabric.NetworkToNetworkInterconnectData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use the overload with OptionBLayer3Configuration optionBLayer3Settings instead.")]
        public static NetworkToNetworkInterconnectData NetworkToNetworkInterconnectData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, NniType? nniType, IsManagementType? isManagementType, NetworkFabricBooleanValue useOptionB, Layer2Configuration layer2Configuration, NetworkToNetworkInterconnectOptionBLayer3Configuration optionBLayer3Configuration, NpbStaticRouteConfiguration npbStaticRouteConfiguration, ImportRoutePolicyInformation importRoutePolicy, ExportRoutePolicyInformation exportRoutePolicy, ResourceIdentifier egressAclId, ResourceIdentifier ingressAclId, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
            => NetworkToNetworkInterconnectData(
                id: id,
                name: name,
                resourceType: resourceType,
                systemData: systemData,
                nniType: nniType,
                isManagementType: isManagementType,
                useOptionB: useOptionB,
                layer2Configuration: layer2Configuration,
                optionBLayer3Settings: optionBLayer3Configuration,
                npbStaticRouteConfiguration: npbStaticRouteConfiguration,
                importRoutePolicy: importRoutePolicy,
                exportRoutePolicy: exportRoutePolicy,
                egressAclId: egressAclId,
                ingressAclId: ingressAclId,
                configurationState: configurationState,
                provisioningState: provisioningState,
                administrativeState: administrativeState);

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.")]
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
        [Obsolete("This method is obsolete and will be removed in a future version. Use NetworkFabricTerminalServerConfiguration instead.")]
        public static TerminalServerConfiguration TerminalServerConfiguration(string username, string password, string serialNumber, ResourceIdentifier networkDeviceId, string primaryIPv4Prefix, string primaryIPv6Prefix, string secondaryIPv4Prefix, string secondaryIPv6Prefix)
        {
            return TerminalServerConfiguration(username: username, password: password, serialNumber: serialNumber, primaryIpv4Prefix: primaryIPv4Prefix, primaryIpv6Prefix: primaryIPv6Prefix, secondaryIpv4Prefix: secondaryIPv4Prefix, secondaryIpv6Prefix: secondaryIPv6Prefix, networkDeviceId: networkDeviceId, secretRotationStatus: default);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkDeviceInterfaceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkDeviceInterfaceData NetworkDeviceInterfaceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string annotation, string physicalIdentifier, string connectedTo, NetworkDeviceInterfaceType? interfaceType, System.Net.IPAddress ipv4Address, string ipv6Address, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return new NetworkDeviceInterfaceData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                new NetworkInterfaceProperties(annotation, null, physicalIdentifier, connectedTo, interfaceType, ipv4Address, ipv6Address, default, default, default, default, provisioningState, administrativeState, default),
                identity: default);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkFabricData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future version. Use the overload with NetworkFabricTerminalServerConfiguration instead.")]
        public static NetworkFabricData NetworkFabricData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, string networkFabricSku, string fabricVersion, IEnumerable<string> routerIds, ResourceIdentifier networkFabricControllerId, int? rackCount, int serverCountPerRack, string ipv4Prefix, string ipv6Prefix, long fabricAsn, TerminalServerConfiguration terminalServerConfiguration, ManagementNetworkConfigurationProperties managementNetworkConfiguration, IEnumerable<string> racks, IEnumerable<string> l2IsolationDomains, IEnumerable<string> l3IsolationDomains, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return new NetworkFabricData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                new NetworkFabricProperties(
                    annotation,
                    null,
                    networkFabricSku,
                    fabricVersion,
                    (routerIds ?? new ChangeTrackingList<string>()).ToList(),
                    default,
                    default,
                    networkFabricControllerId,
                    rackCount,
                    serverCountPerRack,
                    ipv4Prefix,
                    ipv6Prefix,
                    fabricAsn,
                    terminalServerConfiguration?.ToNetworkFabricTerminalServerConfiguration(),
                    managementNetworkConfiguration,
                    (racks ?? new ChangeTrackingList<string>()).ToList(),
                    (l2IsolationDomains ?? new ChangeTrackingList<string>()).ToList(),
                    (l3IsolationDomains ?? new ChangeTrackingList<string>()).ToList(),
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    default,
                    configurationState,
                    provisioningState,
                    administrativeState,
                    default),
                identity: default);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkFabricInternetGatewayRuleData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricInternetGatewayRuleData NetworkFabricInternetGatewayRuleData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, InternetGatewayRules ruleProperties, NetworkFabricProvisioningState? provisioningState, IEnumerable<ResourceIdentifier> internetGatewayIds)
        {
            return new NetworkFabricInternetGatewayRuleData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                new InternetGatewayRuleProperties(annotation, null, ruleProperties, default, provisioningState, (internetGatewayIds ?? new ChangeTrackingList<ResourceIdentifier>()).Select(id => id?.ToString()).ToList()));
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkFabricL2IsolationDomainData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkFabricL2IsolationDomainData NetworkFabricL2IsolationDomainData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, ResourceIdentifier networkFabricId, int vlanId, int? mtu, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
        {
            return new NetworkFabricL2IsolationDomainData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                new L2IsolationDomainProperties(annotation, null, networkFabricId, vlanId, mtu, default, default, default, configurationState, provisioningState, administrativeState),
                identity: default);
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkRackData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NetworkRackData NetworkRackData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, NetworkRackType? networkRackType, ResourceIdentifier networkFabricId, IEnumerable<ResourceIdentifier> networkDevices, NetworkFabricProvisioningState? provisioningState)
        {
            return new NetworkRackData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                new NetworkRackProperties(annotation, null, networkRackType, networkFabricId, (networkDevices ?? new ChangeTrackingList<ResourceIdentifier>()).ToList(), default, provisioningState, default));
        }

        /// <summary> Initializes a new instance of <see cref="ManagedNetworkFabric.NetworkTapData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CS0618 // Preserve obsolete compatibility overload.
        [Obsolete("This method is obsolete and will be removed in a future version. Use the overload with NetworkTapDestinationProperties destinations instead.")]
        public static NetworkTapData NetworkTapData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string annotation, ResourceIdentifier networkPacketBrokerId, ResourceIdentifier sourceTapRuleId, IEnumerable<NetworkTapPropertiesDestinationsItem> destinations, NetworkTapPollingType? pollingType, NetworkFabricConfigurationState? configurationState, NetworkFabricProvisioningState? provisioningState, NetworkFabricAdministrativeState? administrativeState)
#pragma warning restore CS0618
        {
            return new NetworkTapData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags ?? new ChangeTrackingDictionary<string, string>(),
                location,
                new NetworkTapProperties(annotation, null, networkPacketBrokerId, sourceTapRuleId, default, (destinations ?? new ChangeTrackingList<NetworkTapPropertiesDestinationsItem>()).Cast<NetworkTapDestinationProperties>().ToList(), pollingType, default, configurationState, provisioningState, administrativeState),
                identity: default);
        }
    }
}
