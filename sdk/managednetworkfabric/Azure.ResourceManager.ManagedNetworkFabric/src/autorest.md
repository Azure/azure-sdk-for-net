# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Azure.ResourceManager.ManagedNetworkFabric
namespace: Azure.ResourceManager.ManagedNetworkFabric
require: https://github.com/Azure/azure-rest-api-specs/blob/5476ceee2ed3364cdedec8e0d002d2e45389a8f0/specification/managednetworkfabric/resource-manager/readme.md
tag: package-2024-06-15-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
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
  ExternalNetwork: NetworkFabricExternalNetwork
  ExternalNetwork.properties.networkToNetworkInterconnectId: -|arm-id
  InternalNetwork: NetworkFabricInternalNetwork
  InternetGateway: NetworkFabricInternetGateway
  InternetGateway.properties.ipv4Address: IpV4Address
  InternetGatewayRule: NetworkFabricInternetGatewayRule
  IpCommunity: NetworkFabricIpCommunity
  IpExtendedCommunity: NetworkFabricIpExtendedCommunity
  IpPrefix: NetworkFabricIpPrefix
  L2IsolationDomain: NetworkFabricL2IsolationDomain
  ConnectedSubnetRoutePolicy.exportRoutePolicy: connectedExportRoutePolicy
  ConnectedSubnetRoutePolicyPatch.exportRoutePolicy: connectedExportRoutePolicy
  L3IsolationDomain: NetworkFabricL3IsolationDomain
  NeighborGroup: NetworkFabricNeighborGroup
  NetworkDevice.properties.managementIpv4Address: -|ip-address
  NetworkInterface.properties.ipv4Address: -|ip-address
  RoutePolicy: NetworkFabricRoutePolicy
  NetworkInterface: NetworkDeviceInterface
  Action: InternetGatewayRuleAction
  AdministrativeState: NetworkFabricAdministrativeState
  BooleanEnumProperty: NetworkFabricBooleanValue
  CommonPostActionResponseForDeviceUpdate: DeviceUpdateCommonPostActionResult
  CommonPostActionResponseForStateUpdate: StateUpdateCommonPostActionResult
  ConfigurationState: NetworkFabricConfigurationState
  ConfigurationType: NetworkFabricConfigurationType
  Condition: IPPrefixRuleCondition
  ControllerServices: NetworkFabricControllerServices
  DestinationProperties: NetworkTapDestinationProperties
  DestinationType: NetworkTapDestinationType
  DeviceAdministrativeState: NetworkDeviceAdministrativeState
  DeviceInterfaceProperties: NetworkDeviceInterfaceProperties
  EnableDisableState: AdministrativeEnableState
  Encapsulation: IsolationDomainEncapsulationType
  EncapsulationType: NetworkTapEncapsulationType
  ErrorResponse: NetworkFabricErrorResult
  Extension: StaticRouteConfigurationExtension
  ExternalNetworkPatchPropertiesOptionAProperties: ExternalNetworkPatchOptionAProperties
  ExternalNetworkPropertiesOptionAProperties: ExternalNetworkOptionAProperties
  IpCommunityIdList.ipCommunityIds: -|arm-id
  IpExtendedCommunityIdList.ipExtendedCommunityIds: -|arm-id
  GatewayType: InternetGatewayType
  FabricSkuType: NetworkFabricSkuType
  InterfaceType: NetworkDeviceInterfaceType
  IpGroupProperties: MatchConfigurationIPGroupProperties
  IPAddressType: NetworkFabricIPAddressType
  NeighborGroupDestination.ipv4Addresses: -|ip-address
  NetworkDevice.properties.networkRackId: -|arm-id
  NetworkInterfacePatch: NetworkDeviceInterfacePatch
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
  CommitBatchStatusResponse: CommitBatchStatusResult
  InternalNetworkBfdAdministrativeStateResponse: InternalNetworkBfdAdministrativeStateResult
  InternalNetworkBgpAdministrativeStateResponse: InternalNetworkBgpAdministrativeStateResult
  DiscardCommitBatchResponse: DiscardCommitBatchResult
  ArmConfigurationDiffResponse: ArmConfigurationDiffResult
  ExternalNetworkBfdAdministrativeStateResponse: ExternalNetworkBfdAdministrativeStateResult
  NniBfdAdministrativeStateResponse: NniBfdAdministrativeStateResult
  ViewDeviceConfigurationResponse: ViewDeviceConfigurationResult

directive:
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      $.NetworkDevice.properties.properties["x-ms-client-flatten"] = true;
      $.NetworkInterface.properties.properties["x-ms-client-flatten"] = true;
      $.NetworkDeviceSku.properties.properties["x-ms-client-flatten"] = true;
      $.AccessControlList.properties.properties["x-ms-client-flatten"] = true;
      $.NetworkFabricController.properties.properties["x-ms-client-flatten"] = true;
      $.NetworkFabric.properties.properties["x-ms-client-flatten"] = true;
      $.ExternalNetwork.properties.properties["x-ms-client-flatten"] = true;
      $.InternalNetwork.properties.properties["x-ms-client-flatten"] = true;
      $.InternetGateway.properties.properties["x-ms-client-flatten"] = true;
  # change some properties back to optional to overcome some breaking changes
  - from: managednetworkfabric.json
    where: $.definitions
    transform: >
      $.ExpressRouteConnectionInformation.required =  [ 'expressRouteCircuitId' ];
      $.BgpConfiguration.required = undefined;
      $.ExternalNetworkPropertiesOptionAProperties.required = undefined;
      $.OptionBLayer3Configuration.required = undefined;
      $.AccessControlListProperties.required = undefined;
  # Removing the operations that are not allowed for the end users.
  - remove-operation: InternetGateways_Delete
  - remove-operation: InternetGateways_Create
```
