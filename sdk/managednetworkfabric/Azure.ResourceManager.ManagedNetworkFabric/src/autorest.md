# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Azure.ResourceManager.ManagedNetworkFabric
namespace: Azure.ResourceManager.ManagedNetworkFabric
require: https://github.com/Azure/azure-rest-api-specs/blob/1a3542f46375ced453982cf69f035d9a9a3924d5/specification/managednetworkfabric/resource-manager/readme.md
#tag: package-2025-07-15
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  MAT: Mat
  RMA: Rma
  GRE: Gre
  ASN: Asn
  TCP: Tcp
  UDP: Udp
  NPB: Npb
  ZTP: Ztp

rename-mapping:
  AccessControlList: NetworkFabricAccessControlList
  AccessControlListsListResult: AccessControlListsResult
  ExternalNetwork: NetworkFabricExternalNetwork
  ExternalNetwork.properties.networkToNetworkInterconnectId: -|arm-id
  InternalNetwork: NetworkFabricInternalNetwork
  InternetGateway: NetworkFabricInternetGateway
  InternetGateway.properties.ipv4Address: IpV4Address
  InternetGatewayRule: NetworkFabricInternetGatewayRule
  InternetGatewayRule.properties.internetGatewayIds: -|arm-id
  IpCommunity: NetworkFabricIpCommunity
  IpExtendedCommunity: NetworkFabricIpExtendedCommunity
  IpPrefix: NetworkFabricIpPrefix
  L2IsolationDomain: NetworkFabricL2IsolationDomain
  L3IsolationDomain: NetworkFabricL3IsolationDomain
  NeighborGroup: NetworkFabricNeighborGroup
  NetworkDevice.properties.managementIpv4Address: -|ip-address
  NetworkInterface.properties.ipv4Address: -|ip-address
  RoutePolicy: NetworkFabricRoutePolicy
  NetworkInterface: NetworkDeviceInterface
  Action: InternetGatewayRuleAction
  AddressFamilyTypeL: NetworkFabricAddressFamilyType
  AdministrativeState: NetworkFabricAdministrativeState
  AnnotationResource: AnnotationResourceProperties
  BooleanEnumProperty: NetworkFabricBooleanValue
  CommonPostActionResponseForDeviceUpdate: DeviceUpdateCommonPostActionResult
  CommonPostActionResponseForStateUpdate: StateUpdateCommonPostActionResult
  ConfigurationState: NetworkFabricConfigurationState
  ConfigurationType: NetworkFabricConfigurationType
  Condition: IPPrefixRuleCondition
  ControllerServices: NetworkFabricControllerServices
  DestinationProperties: NetworkTapPropertiesDestinationsItem
  DestinationType: NetworkTapDestinationType
  DeviceAdministrativeState: NetworkDeviceAdministrativeState
  DeviceInterfaceProperties: NetworkDeviceInterfaceProperties
  EnableDisableOnResources: UpdateAdministrativeStateOnResources
  EnableDisableOnResources.resourceIds: -|arm-id
  EnableDisableState: AdministrativeEnableState
  Encapsulation: IsolationDomainEncapsulationType
  EncapsulationType: NetworkTapEncapsulationType
  ErrorResponse: NetworkFabricErrorResult
  Extension: StaticRouteConfigurationExtension
  ExternalNetworkPatchPropertiesOptionAProperties: ExternalNetworkPatchOptionAProperties
  ExternalNetworkPropertiesOptionAProperties: ExternalNetworkOptionAProperties
  InternalNetworkPropertiesBgpConfiguration: InternalNetworkBgpConfiguration
  InternalNetworkPropertiesStaticRouteConfiguration: InternalNetworkStaticRouteConfiguration
  IpCommunityIdList.ipCommunityIds: -|arm-id
  IpExtendedCommunityIdList.ipExtendedCommunityIds: -|arm-id
  GatewayType: InternetGatewayType
  FabricSkuType: NetworkFabricSkuType
  InterfaceType: NetworkDeviceInterfaceType
  IpGroupProperties: MatchConfigurationIPGroupProperties
  IPAddressType: NetworkFabricIPAddressType
  NeighborGroupDestination.ipv4Addresses: -|ip-address
  NetworkDevice.properties.networkRackId: -|arm-id
  NetworkFabricController.properties.workloadManagementNetwork: IsWorkloadManagementNetwork
  NetworkInterfacePatch: NetworkDeviceInterfacePatch
  NetworkInterfacesList: NetworkDeviceInterfacesList
  NetworkTapRule.properties.networkTapId: -|arm-id
  NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration: NetworkToNetworkInterconnectOptionBLayer3Configuration
  NfcSku: NetworkFabricControllerSKU
  PollingType: NetworkTapPollingType
  PortCondition: NetworkFabricPortCondition
  PortType: NetworkFabricPortType
  PrefixType: IPMatchConditionPrefixType
  ProvisioningState: NetworkFabricProvisioningState
  RebootProperties: NetworkDeviceRebootContent
  RebootType: NetworkDeviceRebootType
  RuleProperties: InternetGatewayRules
  StatementConditionProperties.ipPrefixId: -|arm-id
  TerminalServerConfiguration.networkDeviceId: -|arm-id
  UpdateAdministrativeState: UpdateAdministrativeStateContent
  UpdateDeviceAdministrativeState: UpdateDeviceAdministrativeStateContent
  UpdateVersion: NetworkFabricUpdateVersionContent
  ValidateAction: NetworkFabricValidateAction
  ValidateConfigurationProperties: ValidateConfigurationContent
  ValidateConfigurationResponse: ValidateConfigurationResult
  ArmConfigurationDiffOperationResponse: ArmConfigurationDiffOperationResult
  CommitBatchStatusOperationResponse: CommitBatchStatusOperationResult
  CommitConfigurationResponse: CommitConfigurationResult
  DiscardCommitBatchOperationResponse: DiscardCommitBatchOperationResult
  ExternalNetworkUpdateBfdAdministrativeStateResponse: ExternalNetworkUpdateBfdAdministrativeStateResult
  GetTopologyResponse: GetTopologyResult
  InternalNetworkUpdateBfdAdministrativeStateResponse: InternalNetworkUpdateBfdAdministrativeStateResult
  InternalNetworkUpdateBgpAdministrativeStateResponse: InternalNetworkUpdateBgpAdministrativeStateResult
  NeighborGroupResyncResponse: NeighborGroupResyncResult
  NetworkBootstrapDeviceRebootResponse: NetworkBootstrapDeviceRebootResult
  NetworkBootstrapDeviceRefreshConfigurationResponse: NetworkBootstrapDeviceRefreshConfigurationResult
  NetworkBootstrapDeviceResyncPasswordsResponse: NetworkBootstrapDeviceResyncPasswordsResult
  NetworkBootstrapDeviceUpdateAdministrativeStateResponse: NetworkBootstrapDeviceUpdateAdministrativeStateResult
  NetworkBootstrapDeviceUpgradeResponse: NetworkBootstrapDeviceUpgradeResult
  NetworkDeviceRefreshConfigurationResponse: NetworkDeviceRefreshConfigurationResult
  NetworkDeviceResyncPasswordsResponse: NetworkDeviceResyncPasswordsResult
  NetworkDeviceRunRwCommandResponse: NetworkDeviceRunRwCommandResult
  NetworkDeviceUpdateAdministrativeStateResponse: NetworkDeviceUpdateAdministrativeStateResult
  NetworkDeviceUpgradeResponse: NetworkDeviceUpgradeResult
  NetworkFabricResyncCertificatesResponse: NetworkFabricResyncCertificatesResult
  NetworkFabricResyncPasswordsResponse: NetworkFabricResyncPasswordsResult
  NetworkFabricRotateCertificatesResponse: NetworkFabricRotateCertificatesResult
  NetworkFabricRotatePasswordsResponse: NetworkFabricRotatePasswordsResult
  NetworkTapResyncResponse: NetworkTapResyncResult
  NetworkTapRuleResyncResponse: NetworkTapRuleResyncResult
  NniUpdateBfdAdministrativeStateResponse: NniUpdateBfdAdministrativeStateResult
  UpdateAdministrativeStateResponse: UpdateAdministrativeStateResult
  ViewDeviceConfigurationOperationResponse: ViewDeviceConfigurationOperationResult
  VpnConfigurationPatchablePropertiesOptionAProperties: VpnConfigurationPatchableOptionAProperties
  VpnConfigurationPropertiesOptionAProperties: VpnConfigurationOptionAProperties
  StaticRouteRoutePolicy.properties.exportRoutePolicy: StaticRouteExportRoutePolicy
  StaticRouteRoutePolicyPatch.properties.exportRoutePolicy: StaticRouteExportRoutePolicyPatch
  DestinationPatchProperties: NetworkTapPatchableParametersDestinationsItem
  ManagementNetworkPatchConfiguration: ManagementNetworkConfigurationPatchableProperties
  TerminalServerPatchConfiguration: NetworkFabricPatchablePropertiesTerminalServerConfiguration
  VpnOptionAProperties: VpnConfigurationOptionAProperties
  VpnOptionAPatchProperties: VpnConfigurationPatchableOptionAProperties
  VpnOptionBProperties: OptionBProperties
  StatementConditionProperties.ipExtendedCommunityIds: -|arm-id

directive:
  - from: NetworkFabricControllers.json
    where: $.definitions
    transform:
      $.ExpressRouteConnectionInformation.required =  [ 'expressRouteCircuitId' ];
  # Removing the operations that are not allowed for the end users.
  - remove-operation: InternetGateways_Delete
  - remove-operation: InternetGateways_Create
  # Group A: Restore NetworkRackPatch as base type for Patch types (TagsUpdate → NetworkRackPatch in allOf)
  # Uses SWAGGER names (pre-rename). Types that already use NetworkRackPatch in swagger are included but won't match.
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      var patchTypes = [
        "NetworkDevicePatchParameters", "AccessControlListPatch", "NetworkFabricControllerPatch",
        "InternetGatewayPatch", "IpCommunityPatch", "IpExtendedCommunityPatch", "IpPrefixPatch",
        "L2IsolationDomainPatch", "L3IsolationDomainPatch", "NeighborGroupPatch",
        "NetworkFabricPatch", "RoutePolicyPatch", "NetworkPacketBrokerPatch",
        "NetworkTapPatch", "NetworkTapRulePatch"
      ];
      for (var idx = 0; idx < patchTypes.length; idx++) {
        var name = patchTypes[idx];
        if ($[name] && $[name].allOf) {
          for (var j = 0; j < $[name].allOf.length; j++) {
            var r = $[name].allOf[j];
            if (r["$ref"] && r["$ref"].indexOf("TagsUpdate") >= 0) {
              r["$ref"] = "#/definitions/NetworkRackPatch";
            }
          }
        }
      }
  # Group A special: InternetGatewayRulePatch has no allOf (tags is inline), add allOf to NetworkRackPatch
  - from: managednetworkfabric.json
    where: $.definitions.InternetGatewayRulePatch
    transform: >
      if (!$.allOf) $.allOf = [];
      $.allOf.push({"$ref": "#/definitions/NetworkRackPatch"});
      if ($.properties && $.properties.tags) delete $.properties.tags;
  # Create OptionAProperties as a standalone base type for VPN Option A types (backward compat).
  # In v1.1.2, OptionAProperties was a standalone type (no base class) with peerASN, vlanId, mtu, bfdConfiguration.
  # VPN Option A types extended it; ExternalNetwork Option A types extended Layer3IpPrefixProperties separately.
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      var vpnOa = $["VpnOptionAProperties"];
      if (vpnOa && vpnOa.properties) {
        var d = {};
        d.type = "object";
        d.description = "Option A properties.";
        d.properties = {};
        if (vpnOa.properties.peerASN) d.properties.peerASN = vpnOa.properties.peerASN;
        if (vpnOa.properties.vlanId) d.properties.vlanId = vpnOa.properties.vlanId;
        if (vpnOa.properties.mtu) d.properties.mtu = vpnOa.properties.mtu;
        if (vpnOa.properties.bfdConfiguration) d.properties.bfdConfiguration = vpnOa.properties.bfdConfiguration;
        $["OptionAProperties"] = d;
      }
  # Group B: Restore Layer3IpPrefixProperties as base type for ExternalNetwork Option A types (swagger names)
  - from: managednetworkfabric.json
    where: $.definitions.ExternalNetworkPropertiesOptionAProperties
    transform: >
      if (!$.allOf) $.allOf = [];
      $.allOf.push({"$ref": "#/definitions/Layer3IpPrefixProperties"});
      if ($.properties) {
        delete $.properties["primaryIpv4Prefix"];
        delete $.properties["primaryIpv6Prefix"];
        delete $.properties["secondaryIpv4Prefix"];
        delete $.properties["secondaryIpv6Prefix"];
      }
  - from: managednetworkfabric.json
    where: $.definitions.ExternalNetworkPatchPropertiesOptionAProperties
    transform: >
      if (!$.allOf) $.allOf = [];
      $.allOf.push({"$ref": "#/definitions/Layer3IpPrefixProperties"});
      if ($.properties) {
        delete $.properties["primaryIpv4Prefix"];
        delete $.properties["primaryIpv6Prefix"];
        delete $.properties["secondaryIpv4Prefix"];
        delete $.properties["secondaryIpv6Prefix"];
      }
  # VPN Option A types: change allOf to use OptionAProperties for backward compat hierarchy.
  # Also copy IPv4/IPv6 prefix properties from Layer3IpPrefixProperties as own properties
  # (they were own properties in v1.1.2's VpnConfigurationOptionAProperties).
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      var l3 = $["Layer3IpPrefixProperties"];
      var vpnOa = $["VpnOptionAProperties"];
      if (vpnOa && l3 && l3.properties && vpnOa.properties) {
        for (var p in l3.properties) {
          if (!vpnOa.properties[p]) vpnOa.properties[p] = l3.properties[p];
        }
        if (vpnOa.allOf) {
          for (var i = 0; i < vpnOa.allOf.length; i++) {
            if (vpnOa.allOf[i]["$ref"] && vpnOa.allOf[i]["$ref"].indexOf("Layer3IpPrefixProperties") >= 0) {
              vpnOa.allOf[i]["$ref"] = "#/definitions/OptionAProperties";
            }
          }
        }
        delete vpnOa.properties["peerASN"];
        delete vpnOa.properties["vlanId"];
        delete vpnOa.properties["mtu"];
        delete vpnOa.properties["bfdConfiguration"];
      }
      var vpnOaP = $["VpnOptionAPatchProperties"];
      if (vpnOaP && l3 && l3.properties && vpnOaP.properties) {
        for (var p in l3.properties) {
          if (!vpnOaP.properties[p]) vpnOaP.properties[p] = l3.properties[p];
        }
        if (vpnOaP.allOf) {
          for (var i = 0; i < vpnOaP.allOf.length; i++) {
            if (vpnOaP.allOf[i]["$ref"] && (vpnOaP.allOf[i]["$ref"].indexOf("Layer3IpPrefixPatchProperties") >= 0 || vpnOaP.allOf[i]["$ref"].indexOf("Layer3IpPrefixProperties") >= 0)) {
              vpnOaP.allOf[i]["$ref"] = "#/definitions/OptionAProperties";
            }
          }
        }
        delete vpnOaP.properties["peerASN"];
        delete vpnOaP.properties["vlanId"];
        delete vpnOaP.properties["mtu"];
        delete vpnOaP.properties["bfdConfiguration"];
      }
  # Group C item 1: Create IpCommunityAddOperationProperties (→ IPCommunityAddOperationProperties in C#)
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      if ($["ActionIpCommunityProperties"] && $["ActionIpCommunityProperties"].properties && $["ActionIpCommunityProperties"].properties.add) {
        var d1 = {};
        d1.type = "object";
        d1.description = "IP Community add operation properties.";
        d1.properties = {};
        d1.properties.add = $["ActionIpCommunityProperties"].properties.add;
        $["IpCommunityAddOperationProperties"] = d1;
        if (!$["ActionIpCommunityProperties"].allOf) $["ActionIpCommunityProperties"].allOf = [];
        $["ActionIpCommunityProperties"].allOf.push({"$ref": "#/definitions/IpCommunityAddOperationProperties"});
        delete $["ActionIpCommunityProperties"].properties.add;
      }
  # Group C item 2: Create IpExtendedCommunityAddOperationProperties (→ IPExtendedCommunityAddOperationProperties in C#)
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      if ($["ActionIpExtendedCommunityProperties"] && $["ActionIpExtendedCommunityProperties"].properties && $["ActionIpExtendedCommunityProperties"].properties.add) {
        var d2 = {};
        d2.type = "object";
        d2.description = "IP Extended Community add operation properties.";
        d2.properties = {};
        d2.properties.add = $["ActionIpExtendedCommunityProperties"].properties.add;
        $["IpExtendedCommunityAddOperationProperties"] = d2;
        if (!$["ActionIpExtendedCommunityProperties"].allOf) $["ActionIpExtendedCommunityProperties"].allOf = [];
        $["ActionIpExtendedCommunityProperties"].allOf.push({"$ref": "#/definitions/IpExtendedCommunityAddOperationProperties"});
        delete $["ActionIpExtendedCommunityProperties"].properties.add;
      }
  # Group C item 3: Restore IpCommunityIdList as base for StatementConditionProperties (both exist as top-level defs)
  - from: managednetworkfabric.json
    where: $.definitions.StatementConditionProperties
    transform: >
      if ($.properties && $.properties.ipCommunityIds) {
        if (!$.allOf) $.allOf = [];
        $.allOf.push({"$ref": "#/definitions/IpCommunityIdList"});
        delete $.properties.ipCommunityIds;
      }
  # Group C item 4: Create TerminalServerPatchableProperties and restore as base of TerminalServerConfiguration
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      if ($["TerminalServerConfiguration"] && $["TerminalServerConfiguration"].properties && $["TerminalServerConfiguration"].properties.username) {
        var d4 = {};
        d4.type = "object";
        d4.description = "Terminal server patchable properties.";
        d4.properties = {};
        d4.properties.username = $["TerminalServerConfiguration"].properties.username;
        d4.properties.password = $["TerminalServerConfiguration"].properties.password;
        d4.properties.serialNumber = $["TerminalServerConfiguration"].properties.serialNumber;
        $["TerminalServerPatchableProperties"] = d4;
        if (!$["TerminalServerConfiguration"].allOf) $["TerminalServerConfiguration"].allOf = [];
        $["TerminalServerConfiguration"].allOf.push({"$ref": "#/definitions/TerminalServerPatchableProperties"});
        delete $["TerminalServerConfiguration"].properties.username;
        delete $["TerminalServerConfiguration"].properties.password;
        delete $["TerminalServerConfiguration"].properties.serialNumber;
      }
  # Group C item 5: Restore ResourceData as base for NetworkToNetworkInterconnectPatch (ProxyResourceBase → common-types ProxyResource)
  - from: managednetworkfabric.json
    where: $.definitions.NetworkToNetworkInterconnectPatch
    transform: >
      if ($.allOf) {
        for (var i = 0; i < $.allOf.length; i++) {
          if ($.allOf[i]["$ref"] && $.allOf[i]["$ref"].indexOf("ProxyResourceBase") >= 0) {
            $.allOf[i]["$ref"] = "../../../../../common-types/resource-management/v5/types.json#/definitions/ProxyResource";
          }
        }
      }
  # Create sub-type definitions for backward compatibility (these definitions were removed in the new swagger)
  # Existing rename-mappings map them to the old C# names.
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      if ($["BgpConfiguration"]) {
        var d1 = {};
        d1.type = "object";
        d1.description = "Internal network BGP configuration.";
        d1.allOf = [{"$ref": "#/definitions/BgpConfiguration"}];
        $["InternalNetworkPropertiesBgpConfiguration"] = d1;
      }
      if ($["StaticRouteConfiguration"]) {
        var d2 = {};
        d2.type = "object";
        d2.description = "Internal network static route configuration.";
        d2.allOf = [{"$ref": "#/definitions/StaticRouteConfiguration"}];
        $["InternalNetworkPropertiesStaticRouteConfiguration"] = d2;
      }
      if ($["OptionBLayer3Configuration"]) {
        var d3 = {};
        d3.type = "object";
        d3.description = "NNI option B layer 3 configuration.";
        d3.allOf = [{"$ref": "#/definitions/OptionBLayer3Configuration"}];
        $["NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration"] = d3;
      }
  # Change Data type property $refs to use the sub-type definitions
  - from: managednetworkfabric.json
    where: $.definitions.InternalNetworkProperties
    transform: >
      if ($.properties && $.properties.bgpConfiguration) $.properties.bgpConfiguration["$ref"] = "#/definitions/InternalNetworkPropertiesBgpConfiguration";
      if ($.properties && $.properties.staticRouteConfiguration) $.properties.staticRouteConfiguration["$ref"] = "#/definitions/InternalNetworkPropertiesStaticRouteConfiguration";
  - from: managednetworkfabric.json
    where: $.definitions.NetworkToNetworkInterconnectProperties
    transform: >
      if ($.properties && $.properties.optionBLayer3Configuration) $.properties.optionBLayer3Configuration["$ref"] = "#/definitions/NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration";
  # Create NetworkTapDestinationProperties base type and set up inheritance hierarchy.
  # The old API had NetworkTapDestinationProperties as base, with NetworkTapPropertiesDestinationsItem and
  # NetworkTapPatchableParametersDestinationsItem both inheriting from it (no additional properties).
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      if ($["DestinationProperties"]) {
        var base = {};
        base.type = "object";
        base.description = "Network Tap destination properties.";
        base.properties = JSON.parse(JSON.stringify($["DestinationProperties"].properties));
        $["NetworkTapDestinationProperties"] = base;
        delete $["DestinationProperties"].properties;
        delete $["DestinationProperties"].required;
        $["DestinationProperties"].allOf = [{"$ref": "#/definitions/NetworkTapDestinationProperties"}];
      }
      if ($["DestinationPatchProperties"]) {
        delete $["DestinationPatchProperties"].properties;
        delete $["DestinationPatchProperties"].required;
        $["DestinationPatchProperties"].allOf = [{"$ref": "#/definitions/NetworkTapDestinationProperties"}];
      }
  # Patch type $ref replacements: use non-Patch types for backward compatibility.
  # When moving to TypeSpec, use @@alternateType instead.
  - from: managednetworkfabric.json
    where: $.definitions.ExternalNetworkPatchProperties
    transform: >
      if ($.properties) {
        $.properties.exportRoutePolicy["$ref"] = "#/definitions/ExportRoutePolicy";
        $.properties.importRoutePolicy["$ref"] = "#/definitions/ImportRoutePolicy";
        $.properties.optionBProperties["$ref"] = "#/definitions/L3OptionBProperties";
      }
  - from: managednetworkfabric.json
    where: $.definitions.ExternalNetworkPatchPropertiesOptionAProperties
    transform: >
      if ($.properties && $.properties.bfdConfiguration) $.properties.bfdConfiguration["$ref"] = "#/definitions/BfdConfiguration";
  - from: managednetworkfabric.json
    where: $.definitions.InternalNetworkPatchProperties
    transform: >
      if ($.properties) {
        if ($.properties.bgpConfiguration) $.properties.bgpConfiguration["$ref"] = "#/definitions/BgpConfiguration";
        if ($.properties.staticRouteConfiguration) $.properties.staticRouteConfiguration["$ref"] = "#/definitions/StaticRouteConfiguration";
        if ($.properties.connectedIPv4Subnets && $.properties.connectedIPv4Subnets.items) $.properties.connectedIPv4Subnets.items["$ref"] = "#/definitions/ConnectedSubnet";
        if ($.properties.connectedIPv6Subnets && $.properties.connectedIPv6Subnets.items) $.properties.connectedIPv6Subnets.items["$ref"] = "#/definitions/ConnectedSubnet";
      }
  - from: managednetworkfabric.json
    where: $.definitions.L3IsolationDomainPatchProperties
    transform: >
      if ($.properties) {
        if ($.properties.aggregateRouteConfiguration) $.properties.aggregateRouteConfiguration["$ref"] = "#/definitions/AggregateRouteConfiguration";
        if ($.properties.connectedSubnetRoutePolicy) $.properties.connectedSubnetRoutePolicy["$ref"] = "#/definitions/ConnectedSubnetRoutePolicy";
      }
  - from: managednetworkfabric.json
    where: $.definitions.NetworkToNetworkInterconnectPatchProperties
    transform: >
      if ($.properties) {
        if ($.properties.exportRoutePolicy) $.properties.exportRoutePolicy["$ref"] = "#/definitions/ExportRoutePolicyInformation";
        if ($.properties.importRoutePolicy) $.properties.importRoutePolicy["$ref"] = "#/definitions/ImportRoutePolicyInformation";
        if ($.properties.layer2Configuration) $.properties.layer2Configuration["$ref"] = "#/definitions/Layer2Configuration";
        if ($.properties.npbStaticRouteConfiguration) $.properties.npbStaticRouteConfiguration["$ref"] = "#/definitions/NpbStaticRouteConfiguration";
        if ($.properties.optionBLayer3Configuration) $.properties.optionBLayer3Configuration["$ref"] = "#/definitions/OptionBLayer3Configuration";
      }
  - from: managednetworkfabric.json
    where: $.definitions.NeighborGroupPatchProperties
    transform: >
      if ($.properties && $.properties.destination) $.properties.destination["$ref"] = "#/definitions/NeighborGroupDestination";
  - from: managednetworkfabric.json
    where: $.definitions.VpnConfigurationPatchableProperties
    transform: >
      if ($.properties && $.properties.optionBProperties) $.properties.optionBProperties["$ref"] = "#/definitions/VpnOptionBProperties";
  - from: managednetworkfabric.json
    where: $.definitions.AccessControlListPatchProperties
    transform: >
      if ($.properties) {
        if ($.properties.matchConfigurations && $.properties.matchConfigurations.items) $.properties.matchConfigurations.items["$ref"] = "#/definitions/AccessControlListMatchConfiguration";
        if ($.properties.dynamicMatchConfigurations && $.properties.dynamicMatchConfigurations.items) $.properties.dynamicMatchConfigurations.items["$ref"] = "#/definitions/CommonDynamicMatchConfiguration";
      }
  - from: managednetworkfabric.json
    where: $.definitions.NetworkTapRulePatchProperties
    transform: >
      if ($.properties) {
        if ($.properties.dynamicMatchConfigurations && $.properties.dynamicMatchConfigurations.items) $.properties.dynamicMatchConfigurations.items["$ref"] = "#/definitions/CommonDynamicMatchConfiguration";
        if ($.properties.matchConfigurations && $.properties.matchConfigurations.items) $.properties.matchConfigurations.items["$ref"] = "#/definitions/NetworkTapRuleMatchConfiguration";
      }
  - from: managednetworkfabric.json
    where: $.definitions.RoutePolicyPatchableProperties
    transform: >
      if ($.properties && $.properties.statements && $.properties.statements.items) $.properties.statements.items["$ref"] = "#/definitions/RoutePolicyStatementProperties";
  # Add exportRoutePolicyId property back to ConnectedSubnetRoutePolicy for backward compatibility.
  # The old API had this as a flat ResourceIdentifier property. The new swagger restructured it as a nested object.
  # Adding it back prevents AutoRest from auto-flattening the container and keeps the property public.
  - from: managednetworkfabric.json
    where: $.definitions.ConnectedSubnetRoutePolicy
    transform: >
      $.properties.exportRoutePolicyId = {type: "string", format: "arm-id", description: "ARM Resource ID of the RoutePolicy. Backward compatible property."};
  # Make InternetGatewayProperties.type required (was non-nullable in old API v1.1.2).
  - from: managednetworkfabric.json
    where: $.definitions.InternetGatewayProperties
    transform: >
      if (!$.required) $.required = [];
      if ($.required.indexOf("type") === -1) $.required.push("type");
  # Remove configurationType from NetworkTapRuleProperties required (was nullable in old API v1.1.2).
  - from: managednetworkfabric.json
    where: $.definitions.NetworkTapRuleProperties
    transform: >
      if ($.required) $.required = $.required.filter(function(r) { return r !== "configurationType"; });
  # Restore pollingIntervalInSeconds as an extensible enum (PollingIntervalInSecond) for backward compatibility.
  # The new swagger changed it to a plain integer, but the old API had it as an extensible enum struct.
  - from: managednetworkfabric.json
    where: $.definitions.NetworkTapRuleProperties.properties.pollingIntervalInSeconds
    transform: >
      $.enum = [30, 60, 90, 120];
      $["x-ms-enum"] = {name: "PollingIntervalInSecond", modelAsString: true};
  # TerminalServerPatchConfiguration: make it extend TerminalServerPatchableProperties for backward compat hierarchy
  - from: managednetworkfabric.json
    where: $.definitions.TerminalServerPatchConfiguration
    transform: >
      if ($.properties && $.properties.username) {
        if (!$.allOf) $.allOf = [];
        $.allOf.push({"$ref": "#/definitions/TerminalServerPatchableProperties"});
        delete $.properties.username;
        delete $.properties.password;
        delete $.properties.serialNumber;
      }
  # Rename action operations whose return types changed from generic (StateUpdateCommonPostActionResult/DeviceUpdateCommonPostActionResult)
  # to specific result types. Old method signatures are preserved via customization code for backward compatibility.
  - from: swagger-document
    where: $.paths.*.*
    transform: >
      const renames = {
        "NetworkInterfaces_UpdateAdministrativeState": "NetworkInterfaces_UpdateAdministrativeStateWithTypedResult",
        "NetworkDevices_UpdateAdministrativeState": "NetworkDevices_UpdateAdministrativeStateWithTypedResult",
        "NetworkDevices_Reboot": "NetworkDevices_RebootWithTypedResult",
        "NetworkDevices_RefreshConfiguration": "NetworkDevices_RefreshConfigurationWithTypedResult",
        "AccessControlLists_UpdateAdministrativeState": "AccessControlLists_UpdateAdministrativeStateWithTypedResult",
        "ExternalNetworks_UpdateAdministrativeState": "ExternalNetworks_UpdateAdministrativeStateWithTypedResult",
        "ExternalNetworks_UpdateStaticRouteBfdAdministrativeState": "ExternalNetworks_UpdateStaticRouteBfdAdministrativeStateWithTypedResult",
        "InternalNetworks_UpdateAdministrativeState": "InternalNetworks_UpdateAdministrativeStateWithTypedResult",
        "InternalNetworks_UpdateBgpAdministrativeState": "InternalNetworks_UpdateBgpAdministrativeStateWithTypedResult",
        "InternalNetworks_UpdateStaticRouteBfdAdministrativeState": "InternalNetworks_UpdateStaticRouteBfdAdministrativeStateWithTypedResult",
        "L2IsolationDomains_UpdateAdministrativeState": "L2IsolationDomains_UpdateAdministrativeStateWithTypedResult",
        "L3IsolationDomains_UpdateAdministrativeState": "L3IsolationDomains_UpdateAdministrativeStateWithTypedResult",
        "NetworkFabrics_CommitConfiguration": "NetworkFabrics_CommitConfigurationWithTypedResult",
        "NetworkFabrics_Deprovision": "NetworkFabrics_DeprovisionWithTypedResult",
        "NetworkFabrics_Provision": "NetworkFabrics_ProvisionWithTypedResult",
        "NetworkFabrics_RefreshConfiguration": "NetworkFabrics_RefreshConfigurationWithTypedResult",
        "NetworkFabrics_UpdateInfraManagementBfdConfiguration": "NetworkFabrics_UpdateInfraManagementBfdConfigurationWithTypedResult",
        "NetworkFabrics_UpdateWorkloadManagementBfdConfiguration": "NetworkFabrics_UpdateWorkloadManagementBfdConfigurationWithTypedResult",
        "RoutePolicies_UpdateAdministrativeState": "RoutePolicies_UpdateAdministrativeStateWithTypedResult",
        "NetworkTaps_Resync": "NetworkTaps_ResyncWithTypedResult",
        "NetworkTaps_UpdateAdministrativeState": "NetworkTaps_UpdateAdministrativeStateWithTypedResult",
        "NetworkTapRules_Resync": "NetworkTapRules_ResyncWithTypedResult",
        "NetworkToNetworkInterconnects_UpdateAdministrativeState": "NetworkToNetworkInterconnects_UpdateAdministrativeStateWithTypedResult",
        "NetworkToNetworkInterconnects_UpdateNpbStaticRouteBfdAdministrativeState": "NetworkToNetworkInterconnects_UpdateNpbStaticRouteBfdAdministrativeStateWithTypedResult",
        "NetworkFabrics_GetTopology": "NetworkFabrics_GetTopologyWithTypedResult"
      };
      if ($.operationId && renames[$.operationId]) {
        $.operationId = renames[$.operationId];
      }
  # Rename exportRoutePolicy on StaticRouteRoutePolicy to avoid name collision with ConnectedSubnetRoutePolicy.exportRoutePolicy after flattening
  - from: managednetworkfabric.json
    where: $.definitions.StaticRouteRoutePolicy.properties
    transform: >
      $["staticRouteExportRoutePolicy"] = $["exportRoutePolicy"];
      delete $["exportRoutePolicy"];
  - from: managednetworkfabric.json
    where: $.definitions.StaticRouteRoutePolicyPatch.properties
    transform: >
      $["staticRouteExportRoutePolicy"] = $["exportRoutePolicy"];
      delete $["exportRoutePolicy"];
```
