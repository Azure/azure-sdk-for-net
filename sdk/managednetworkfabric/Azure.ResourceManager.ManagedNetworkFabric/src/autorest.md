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
  DestinationProperties: NetworkTapDestinationProperties
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

directive:
  - from: NetworkFabricControllers.json
    where: $.definitions
    transform:
      $.ExpressRouteConnectionInformation.required =  [ 'expressRouteCircuitId' ];
  # Removing the operations that are not allowed for the end users.
  - remove-operation: InternetGateways_Delete
  - remove-operation: InternetGateways_Create
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
