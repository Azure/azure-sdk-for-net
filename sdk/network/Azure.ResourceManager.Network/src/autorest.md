# AutoRest Configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml

azure-arm: true
library-name: Network
namespace: Azure.ResourceManager.Network
require: https://github.com/Azure/azure-rest-api-specs/blob/c712a519a493d13c1cd997aa4e5adbab8df76e85/specification/network/resource-manager/readme.md
#tag: package-2025-01-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
    # Not support generate samples from customized operations
    - VirtualMachineScaleSets_ListPublicIPAddresses
    - VirtualMachineScaleSets_ListNetworkInterfaces
    - VirtualMachineScaleSets_ListIPConfigurations
    - VirtualMachineScaleSets_GetIPConfiguration
    - VirtualMachineScaleSets_GetPublicIPAddress
    - VirtualMachineScaleSetVMs_ListPublicIPAddresses
    - VirtualMachineScaleSetVMs_ListNetworkInterfaces
    - VirtualMachineScaleSets_GetNetworkInterface
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
model-namespace: true
public-clients: false
head-as-boolean: false
resource-model-requires-type: false
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  Access: NetworkAccess
  AssociationAccessMode: NetworkSecurityPerimeterAssociationAccessMode
  AccessRuleDirection: NetworkSecurityPerimeterAccessRuleDirection
  Action: RouteMapAction
  ActionType: RuleMatchActionType
  ActiveConfigurationParameter.regions: -|azure-location
  ActiveConfigurationParameter: ActiveConfigurationContent
  ActiveConnectivityConfiguration.commitTime: CommittedOn
  ActiveConnectivityConfiguration.region: -|azure-location
  AddressSpace: VirtualNetworkAddressSpace
  AdminRule: NetworkAdminRule
  AdminRuleCollection: AdminRuleGroup
  AdminRuleCollectionListResult: AdminRuleGroupListResult
  AdminState: ExpressRouteGatewayAdminState
  ApplicationGateway.zones: AvailabilityZones
  ApplicationGatewayAvailableSslOptions: ApplicationGatewayAvailableSslOptionsInfo
  ApplicationGatewayBackendHttpSettings.properties.dedicatedBackendConnection: IsDedicatedBackendConnectionEnabled
  ApplicationGatewayBackendHttpSettings.properties.requestTimeout: RequestTimeoutInSeconds
  ApplicationGatewayBackendHttpSettings.properties.validateCertChainAndExpiry: IsValidateCertChainAndExpiryEnabled
  ApplicationGatewayBackendHttpSettings.properties.validateSNI: IsValidateSniEnabled
  ApplicationGatewayBackendSettings.properties.timeout: TimeoutInSeconds
  ApplicationGatewayConnectionDraining.drainTimeoutInSec: DrainTimeoutInSeconds
  ApplicationGatewayPrivateEndpointConnection.properties.privateLinkServiceConnectionState: connectionState
  ApplicationGatewayPrivateLinkIpConfiguration.properties.primary: IsPrimary
  ApplicationGatewayProbe.properties.interval: IntervalInSeconds
  ApplicationGatewayProbe.properties.timeout: TimeoutInSeconds
  ApplicationGatewayTierTypes.WAF: Waf
  ApplicationGatewayTierTypes.WAF_v2: WafV2
  ApplicationGatewayWafDynamicManifestResult: ApplicationGatewayWafDynamicManifest
  ApplicationGatewayWafDynamicManifestResultList: ApplicationGatewayWafDynamicManifestListResult
  AuthenticationMethod: NetworkAuthenticationMethod
  AzureFirewallApplicationRuleCollection: AzureFirewallApplicationRuleCollectionData
  AzureFirewallNatRuleCollection: AzureFirewallNatRuleCollectionData
  AzureFirewallNetworkRuleCollection: AzureFirewallNetworkRuleCollectionData
  AzureFirewallPacketCaptureResponse: AzureFirewallPacketCaptureResult
  AzureFirewallPacketCaptureResponseCode: AzureFirewallPacketCaptureResultCode
  ConfigurationGroup: NetworkConfigurationGroup
  ConfigurationType: NetworkConfigurationDeploymentType
  ConnectionMonitor: ConnectionMonitorInput
  ConnectionMonitorEndpoint.subscriptionId: -|uuid
  ConnectionMonitorResult: ConnectionMonitor
  ConnectionSharedKeyResult: VpnLinkConnectionSharedKey
  ConnectionState: NetworkConnectionState
  ConnectionStateSnapshot.connectionState: NetworkConnectionState
  ConnectionStatus: NetworkConnectionStatus
  ConnectivityHop: ConnectivityHopInfo
  ConnectivityInformation.connectionStatus: NetworkConnectionStatus
  ConnectivityIssue.context: Contexts
  ConnectivityIssue.type: ConnectivityIssueType
  ConnectivityIssue: ConnectivityIssueInfo
  Criterion: RouteCriterion
  CustomDnsConfigPropertiesFormat: CustomDnsConfigProperties
  CustomIpPrefix.properties.childCustomIpPrefixes: ChildCustomIpPrefixList
  CustomIpPrefix.properties.customIpPrefixParent: ParentCustomIpPrefix
  DefaultAdminRule: NetworkDefaultAdminRule
  Delegation: ServiceDelegation
  DelegationProperties: VirtualApplianceDelegationProperties
  DeleteOptions: IPAddressDeleteOption
  DeploymentStatus: NetworkManagerDeploymentState
  Direction: NetworkTrafficDirection
  EffectiveBaseSecurityAdminRule.id: ResourceId|arm-id
  EffectiveNetworkSecurityGroup.tagMap: tagToIPAddresses
  EndpointType: ConnectionMonitorEndpointType
  ExplicitProxy: FirewallPolicyExplicitProxy
  ExpressRouteGateway.properties.expressRouteConnections: ExpressRouteConnectionList
  FilterItems: IdpsQueryFilterItems
  FirewallPacketCaptureParameters: FirewallPacketCaptureRequestContent
  FirewallPolicyFilterRuleCollection: FirewallPolicyFilterRuleCollectionInfo
  FirewallPolicyNatRuleCollection: FirewallPolicyNatRuleCollectionInfo
  FirewallPolicyRuleCollection: FirewallPolicyRuleCollectionInfo
  FlowLogFormatParameters: FlowLogProperties
  Geo.NAM: Nam
  Geo: CidrAdvertisingGeoCode
  GetInboundRoutesParameters: VirtualHubInboundRoutesContent
  GetOutboundRoutesParameters: VirtualHubOutboundRoutesContent
  GroupMemberType: NetworkGroupMemberType
  HttpConfiguration: NetworkHttpConfiguration
  HttpConfigurationMethod: NetworkHttpConfigurationMethod
  HttpHeader: NetworkWatcherHttpHeader
  HttpMethod: NetworkWatcherHttpMethod
  Hub.resourceType: -|resource-type
  Hub: ConnectivityHub
  IdpsQueryObject: IdpsQueryContent
  InboundNatPool: LoadBalancerInboundNatPool
  InboundNatPoolPropertiesFormat: LoadBalancerInboundNatPoolProperties
  IntentContent: AnalysisRunIntentContent
  IpAllocation.properties.type: IPAllocationType
  IpAllocationListResult: NetworkIPAllocationListResult
  IPAllocationMethod: NetworkIPAllocationMethod
  IpAllocationType: NetworkIPAllocationType
  IPConfiguration: NetworkIPConfiguration
  IPConfigurationBgpPeeringAddress.ipconfigurationId: IPConfigurationId
  IPConfigurationBgpPeeringAddress: NetworkIPConfigurationBgpPeeringAddress
  IPConfigurationProfile: NetworkIPConfigurationProfile
  IPPrefixesList: LearnedIPPrefixesListResult
  IPRule: BastionHostIPRule
  IPTraffic: NetworkVerifierIPTraffic
  IpType: IpamIPType
  IPVersion: NetworkIPVersion
  IsGlobal: GlobalMeshSupportFlag
  IssueType: ConnectivityIssueType
  IsWorkloadProtected: WorkloadProtectedFlag
  LoadBalancerHealthPerRulePerBackendAddress.networkInterfaceIPConfigurationId: NetworkInterfaceIPConfigurationResourceId|arm-id
  LoadBalancingRulePropertiesFormat: LoadBalancingRuleProperties
  MigratedPools: MigrateLoadBalancerToIPBasedResult
  NspServiceTagsResource: NetworkSecurityPerimeterServiceTags
  NetworkManagerConnection.properties.networkManagerId: -|arm-id
  NetworkManagerDeploymentStatus.deploymentStatus: DeploymentState
  NetworkManagerDeploymentStatusParameter: NetworkManagerDeploymentStatusContent
  NetworkManagerSecurityGroupItem.networkGroupId: -|arm-id
  NetworkVirtualAppliance.properties.privateIpAddress: -|ip-address
  NetworkVirtualApplianceConnection.properties.routingConfiguration: ConnectionRoutingConfiguration
  NextStep: RouteMapNextStepBehavior
  OrderBy: IdpsQueryOrderBy
  Origin: IssueOrigin
  P2SConnectionConfiguration.properties.configurationPolicyGroupAssociations: ConfigurationPolicyGroups
  PacketCapture.properties.continuousCapture: IsContinuousCapture
  PacketCapture: PacketCaptureInput
  PacketCaptureResult.properties.continuousCapture: IsContinuousCapture
  PacketCaptureResult: PacketCapture
  Parameter: RouteMapActionParameter
  PoolAssociation: IpamPoolAssociation
  PoolUsage: IpamPoolUsage
  PreferredIPVersion: TestEvalPreferredIPVersion
  PrivateEndpointIPConfiguration.properties.privateIPAddress: -|ip-address
  PrivateEndpointVNetPolicies: PrivateEndpointVnetPolicies
  PrivateLinkServiceConnection.properties.privateLinkServiceConnectionState: connectionState
  PrivateLinkServiceConnection: NetworkPrivateLinkServiceConnection
  Protocol: NetworkWatcherProtocol
  ProtocolConfiguration.HTTPConfiguration: HttpProtocolConfiguration
  ProvisioningState: NetworkProvisioningState
  PublicIpDdosProtectionStatusResult.ddosProtectionPlanId: -|arm-id
  PublicIpDdosProtectionStatusResult.publicIpAddress: -|ip-address
  PublicIpDdosProtectionStatusResult.publicIpAddressId: -|arm-id
  QosDefinition: DscpQosDefinition
  QueryRequestOptions: NetworkManagementQueryContent
  QueryResults: IdpsSignatureListResult
  PerimeterAssociableResource: NetworkSecurityPerimeterAssociableResourceType
  PerimeterBasedAccessRule: NetworkSecurityPerimeterBasedAccessRule
  ResiliencyModel: ExpressRouteGatewayResiliencyModel
  Resource: NetworkTrackedResourceData
  ResourceBasics: IpamResourceBasics
  RoutingRule: NetworkManagerRoutingRule
  RoutingRuleCollection: NetworkManagerRoutingRules
  SecurityUserConfiguration: NetworkManagerSecurityUserConfiguration
  SecurityUserRule: NetworkManagerSecurityUserRule
  SecurityUserRuleCollection: NetworkManagerSecurityUserRules
  SensitivityType: ManagedRuleSensitivityType
  ServiceEndpointPropertiesFormat: ServiceEndpointProperties
  Severity: IssueSeverity
  SharedKeyProperties: VpnLinkConnectionSharedKeyProperties
  SignatureOverridesFilterValuesQuery: SignatureOverridesFilterValuesQueryContent
  SignatureOverridesFilterValuesResponse: SignatureOverridesFilterValuesResult
  SignaturesOverrides.id: -|arm-id
  SignaturesOverrides.type: -|resource-type
  SignaturesOverrides: PolicySignaturesOverridesForIdps
  SignaturesOverridesList: PolicySignaturesOverridesForIdpsListResult
  SignaturesOverridesProperties: PolicySignaturesOverridesForIdpsProperties
  SingleQueryResult: IdpsSignatureResult
  SlotType: SwapSlotType
  StaticMember: NetworkGroupStaticMember
  StaticMemberListResult: NetworkGroupStaticMemberListResult
  Subnet.properties.privateEndpointNetworkPolicies: PrivateEndpointNetworkPolicy
  Subnet.properties.privateLinkServiceNetworkPolicies: PrivateLinkServiceNetworkPolicy
  SubResource: NetworkSubResource
  SwapResource: CloudServiceSwap
  SwapResourceListResult: CloudServiceSwapListResult
  SwapResourceProperties: CloudServiceSwapProperties
  SyncMode: BackendAddressSyncMode
  TagsObject: NetworkTagsObject
  Topology: NetworkTopology
  TopologyResource: TopologyResourceInfo
  TrafficAnalyticsConfigurationProperties.trafficAnalyticsInterval: TrafficAnalyticsIntervalInMinutes
  TrafficAnalyticsProperties.networkWatcherFlowAnalyticsConfiguration: TrafficAnalyticsConfiguration
  TransportProtocol: LoadBalancingTransportProtocol
  TroubleshootingParameters.properties.storagePath: storageUri
  TunnelConnectionHealth.lastConnectionEstablishedUtcTime: lastConnectionEstablishedOn
  UsageName: NetworkUsageName
  UsagesListResult: NetworkUsagesListResult
  UsageUnit: NetworkUsageUnit
  UseHubGateway: HubGatewayUsageFlag
  VerifierWorkspace: NetworkVerifierWorkspace
  VerifierWorkspaceProperties: NetworkVerifierWorkspaceProperties
  VirtualApplianceIPConfigurationProperties.primary: IsPrimary
  VirtualNetwork.properties.privateEndpointVNetPolicies: PrivateEndpointVnetPolicy
  VirtualNetworkEncryption.enabled: IsEnabled
  VirtualNetworkGatewayNatRule.properties.type: VpnNatRuleType
  VirtualNetworkPeering.properties.peerCompleteVnets: AreCompleteVnetsPeered
  VirtualWAN.properties.type: VirtualWanType
  VpnAuthenticationType.AAD: Aad
  VpnClientConnectionHealthDetail.vpnConnectionDuration: vpnConnectionDurationInSeconds
  VpnClientParameters: VpnClientContent
  VpnGatewayNatRule.properties.type: VpnNatRuleType
  VpnPacketCaptureStartParameters: VpnPacketCaptureStartContent
  VpnPacketCaptureStopParameters: VpnPacketCaptureStopContent
  VpnPolicyMemberAttributeType.AADGroupId: AadGroupId

keep-plural-resource-data:
- PolicySignaturesOverridesForIdps
- NetworkManagerRoutingRules
- NetworkManagerSecurityUserRules

models-to-treat-empty-string-as-null:
  - HopLink

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  'azureLocation': 'azure-location'
  'azureLocations': 'azure-location'
  'targetResourceId': 'arm-id'
  'vNetExtendedLocationResourceId': 'arm-id'
  'workspaceResourceId': 'arm-id'
  'targetNicResourceId': 'arm-id'
  'networkSecurityGroupId': 'arm-id'
  'storageId': 'arm-id'
  'vpnServerConfigurationResourceId': 'arm-id'
  'routeTableId': 'arm-id'
  'privateLinkServiceId': 'arm-id'
  'resourceId': 'arm-id'
  'serviceResources': 'arm-id'
  'linkedResourceType': 'resource-type'
  'data': 'any'
  'body': 'any'
  'validatedCertData': 'any'
  'publicCertData': 'any'
  '*Guid': 'uuid'
  '*Time': 'date-time'
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
  BGP: Bgp
  TCP: Tcp
  UDP: Udp
  ANY: Any
  LOA: Loa
  P2S: P2S|p2s
  IKEv1: IkeV1
  IKEv2: IkeV2
  IkeV2: IkeV2
  Stag: STag|stag
  Nsp: NetworkSecurityPerimeter

#TODO: remove after we resolve why DdosCustomPolicy has no list
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/ddosCustomPolicies/{ddosCustomPolicyName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/vpnConnections/{connectionName}/vpnLinkConnections/{linkConnectionName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}: SecurityRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/defaultSecurityRules/{defaultSecurityRuleName}: DefaultSecurityRule

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default
- /subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies
- /subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/{predefinedPolicyName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses/{publicIpAddressName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}/networkInterfaces/{networkInterfaceName}/ipConfigurations/{ipConfigurationName}
# This part is for generate partial class in network
# - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}/networkInterfaces/{networkInterfaceName}
# - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}/networkInterfaces/{networkInterfaceName}/ipconfigurations/{ipConfigurationName}/publicipaddresses/{publicIpAddressName}

# This part is for generate partial class in network
partial-resources:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}: VirtualMachineScaleSet
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{virtualMachineScaleSetName}/virtualMachines/{virtualmachineIndex}: VirtualMachineScaleSetVm
  # /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}: CloudService
  # /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/cloudServices/{cloudServiceName}/roleInstances/{roleInstanceName}: CloudServiceRoleInstance

override-operation-name:
  ApplicationGateways_ListAvailableWafRuleSets: GetAppGatewayAvailableWafRuleSets
  VirtualNetworkGateways_VpnDeviceConfigurationScript: VpnDeviceConfigurationScript
  VirtualHubBgpConnections_ListLearnedRoutes: GetVirtualHubBgpConnectionLearnedRoutes
  VirtualHubBgpConnections_ListAdvertisedRoutes: GetVirtualHubBgpConnectionAdvertisedRoutes
  ApplicationGateways_ListAvailableSslOptions: GetApplicationGatewayAvailableSslOptions
  ApplicationGateways_ListAvailableSslPredefinedPolicies: GetApplicationGatewayAvailableSslPredefinedPolicies
  ApplicationGateways_GetSslPredefinedPolicy: GetApplicationGatewaySslPredefinedPolicy
  VirtualNetworkGateways_Generatevpnclientpackage: GenerateVpnClientPackage
  VirtualHubs_GetEffectiveVirtualHubRoutes: GetVirtualHubEffectiveRoutes
  VirtualHubs_GetOutboundRoutes: GetVirtualHubOutboundRoutes
  VirtualHubs_GetInboundRoutes: GetVirtualHubInboundRoutes
  VirtualMachineScaleSets_ListNetworkInterfaces: GetNetworkInterfaces
  VirtualMachineScaleSets_ListPublicIPAddresses: GetPublicIPAddresses
  VirtualMachineScaleSets_GetPublicIPAddress: GetPublicIPAddress
  VirtualMachineScaleSets_GetNetworkInterface: GetNetworkInterface
  VirtualMachineScaleSetVMs_ListNetworkInterfaces: GetNetworkInterfaces
  VirtualMachineScaleSetVMs_ListPublicIPAddresses: GetPublicIPAddresses
  Generatevirtualwanvpnserverconfigurationvpnprofile: GenerateVirtualWanVpnServerConfigurationVpnProfile

suppress-abstract-base-class:
- BaseAdminRuleData

directive:
  - remove-operation: 'PutBastionShareableLink'
  - remove-operation: 'DeleteBastionShareableLink'
  - remove-operation: 'GetBastionShareableLink'
  - remove-operation: 'GetActiveSessions'
  - remove-operation: 'DisconnectActiveSessions'
  - remove-operation: 'VirtualNetworks_ListDdosProtectionStatus'
  - remove-operation: 'NetworkSecurityPerimeterAssociations_Reconcile'
  - remove-operation: 'NetworkSecurityPerimeterAccessRules_Reconcile'
  - remove-operation: 'NetworkSecurityPerimeterOperationStatuses_Get'
  # This part is for generate partial class in network
  # these operations are renamed because their api-versions are different from others in the same operation group
  # - rename-operation:
  #     from: NetworkInterfaces_ListCloudServiceRoleInstanceNetworkInterfaces
  #     to: CloudServiceRoleInstance_ListNetworkInterfaces
  # - rename-operation:
  #     from: NetworkInterfaces_ListCloudServiceNetworkInterfaces
  #     to: CloudService_ListNetworkInterfaces
  # - rename-operation:
  #     from: NetworkInterfaces_GetCloudServiceNetworkInterface
  #     to: CloudService_GetNetworkInterface
  # - rename-operation:
  #     from: PublicIPAddresses_ListCloudServicePublicIPAddresses
  #     to: CloudService_ListIpConfigurations
  # - rename-operation:
  #     from: PublicIPAddresses_ListCloudServiceRoleInstancePublicIPAddresses
  #     to: CloudServiceRoleInstance_ListIpConfigurations
  # - rename-operation:
  #     from: PublicIPAddresses_GetCloudServicePublicIPAddress
  #     to: CloudService_GetPublicIPAddress
  - rename-operation:
      from: NetworkInterfaces_ListVirtualMachineScaleSetVMNetworkInterfaces
      to: VirtualMachineScaleSetVMs_ListNetworkInterfaces
  - rename-operation:
      from: NetworkInterfaces_ListVirtualMachineScaleSetNetworkInterfaces
      to: VirtualMachineScaleSets_ListNetworkInterfaces
  - rename-operation:
      from: NetworkInterfaces_GetVirtualMachineScaleSetNetworkInterface
      to: VirtualMachineScaleSets_GetNetworkInterface
  - rename-operation:
      from: NetworkInterfaces_ListVirtualMachineScaleSetIpConfigurations
      to: VirtualMachineScaleSets_ListIpConfigurations
  - rename-operation:
      from: NetworkInterfaces_GetVirtualMachineScaleSetIpConfiguration
      to: VirtualMachineScaleSets_GetIpConfiguration
  - rename-operation:
      from: PublicIPAddresses_ListVirtualMachineScaleSetPublicIPAddresses
      to: VirtualMachineScaleSets_ListPublicIPAddresses
  - rename-operation:
      from: PublicIPAddresses_ListVirtualMachineScaleSetVMPublicIPAddresses
      to: VirtualMachineScaleSetVMs_ListPublicIPAddresses
  - rename-operation:
      from: PublicIPAddresses_GetVirtualMachineScaleSetPublicIPAddress
      to: VirtualMachineScaleSets_GetPublicIPAddress
  - from: serviceEndpointPolicy.json
    where: $.definitions
    transform: >
      $.ServiceEndpointPolicyDefinition.properties['type']['readOnly'] = true;
    reason: Resource type should be readonly for this resource.
  - from: virtualNetworkGateway.json
    where: $.definitions
    transform: >
      $.BgpPeerStatus.properties.connectedDuration['x-ms-format'] = 'duration-constant';
      $.DhGroup['x-ms-enum']['name'] = 'DHGroup';
      $.DhGroup['x-ms-enum']['values'] = [
        { value: 'None',        name: 'None' },
        { value: 'DHGroup1',    name: 'DHGroup1' },
        { value: 'DHGroup2',    name: 'DHGroup2' },
        { value: 'DHGroup14',   name: 'DHGroup14' },
        { value: 'DHGroup2048', name: 'DHGroup2048' },
        { value: 'ECP256',      name: 'Ecp256' },
        { value: 'ECP384',      name: 'Ecp384' },
        { value: 'DHGroup24',   name: 'DHGroup24' }
      ];
      $.IkeEncryption['x-ms-enum']['values'] = [
        { value: 'DES',         name: 'Des' },
        { value: 'DES3',        name: 'Des3' },
        { value: 'AES128',      name: 'Aes128' },
        { value: 'AES192',      name: 'Aes192' },
        { value: 'AES256',      name: 'Aes256' },
        { value: 'GCMAES256',   name: 'GcmAes256' },
        { value: 'GCMAES128',   name: 'GcmAes128' }
      ];
      $.IkeIntegrity['x-ms-enum']['values'] = [
        { value: 'MD5',         name: 'MD5' },
        { value: 'SHA1',        name: 'Sha1' },
        { value: 'SHA256',      name: 'Sha256' },
        { value: 'SHA384',      name: 'Sha384' },
        { value: 'GCMAES256',   name: 'GcmAes256' },
        { value: 'GCMAES128',   name: 'GcmAes128' }
      ];
      $.IpsecEncryption['x-ms-enum']['values'] = [
        { value: 'None',        name: 'None' },
        { value: 'DES',         name: 'Des' },
        { value: 'DES3',        name: 'Des3' },
        { value: 'AES128',      name: 'Aes128' },
        { value: 'AES192',      name: 'Aes192' },
        { value: 'AES256',      name: 'Aes256' },
        { value: 'GCMAES128',   name: 'GcmAes128' },
        { value: 'GCMAES192',   name: 'GcmAes192' },
        { value: 'GCMAES256',   name: 'GcmAes256' }
      ];
      $.IpsecIntegrity['x-ms-enum']['values'] = [
        { value: 'MD5',         name: 'MD5' },
        { value: 'SHA1',        name: 'Sha1' },
        { value: 'SHA256',      name: 'Sha256' },
        { value: 'SHA384',      name: 'Sha384' },
        { value: 'GCMAES256',   name: 'GcmAes256' },
        { value: 'GCMAES128',   name: 'GcmAes128' }
      ];
      $.PfsGroup['x-ms-enum']['values'] = [
        { value: 'None',        name: 'None' },
        { value: 'PFS1',        name: 'Pfs1' },
        { value: 'PFS2',        name: 'Pfs2' },
        { value: 'PFS2048',     name: 'Pfs2048' },
        { value: 'ECP256',      name: 'Ecp256' },
        { value: 'ECP384',      name: 'Ecp384' },
        { value: 'PFS24',       name: 'Pfs24' },
        { value: 'PFS14',       name: 'Pfs14' },
        { value: 'PFSMM',       name: 'Pfs' }
      ];
  - from: network.json
    where: $.definitions
    transform: >
      $.Resource.properties.id['x-ms-format'] = 'arm-id';
      $.Resource.properties.type['x-ms-format'] = 'resource-type';
      $.SubResource.properties.id['x-ms-format'] = 'arm-id';
  - from: network.json
    where: $.definitions
    transform: >
      $.NetworkResource = {
        'properties': {
            'id': {
              'type': 'string',
              'description': 'Resource ID.',
              'x-ms-format': 'arm-id'
            },
            'name': {
              'type': 'string',
              'description': 'Resource name.'
            },
            'type': {
              'readOnly': true,
              'type': 'string',
              'description': 'Resource type.',
              'x-ms-format': 'resource-type'
            }
          },
        'description': 'Common resource representation.',
        'x-ms-azure-resource': true,
        'x-ms-client-name': 'NetworkResourceData'
      };
      $.NetworkWritableResource = {
        'properties': {
            'id': {
              'type': 'string',
              'description': 'Resource ID.',
              'x-ms-format': 'arm-id'
            },
            'name': {
              'type': 'string',
              'description': 'Resource name.'
            },
            'type': {
              'type': 'string',
              'description': 'Resource type.',
              'x-ms-format': 'resource-type'
            }
          },
        'description': 'Common resource representation.',
        'x-ms-azure-resource': true,
        'x-ms-client-name': 'NetworkWritableResourceData'
      }
    reason: Add network versions of Resource (id, name are not read-only). The original (Network)Resource definition is actually a TrackedResource.
  - from: swagger-document
    where: $.definitions[?(@.allOf && @.properties.name && !@.properties.type)]
    transform: >
      if ($.allOf[0]['$ref'].includes('network.json#/definitions/SubResource'))
      {
        $.properties.type = {
          'readOnly': true,
          'type': 'string',
          'description': 'Resource type.'
        };
      }
    reason: Add missing type property in swagger definition which exists in service response.
  - from: swagger-document
    where: $.definitions[?(@.allOf && @.properties.name && !@.properties.name.readOnly && @.properties.type)]
    transform: >
      if ($.allOf[0]['$ref'].includes('network.json#/definitions/SubResource'))
      {
        if ($.properties.type.readOnly)
          $.allOf[0]['$ref'] = $.allOf[0]['$ref'].replace('SubResource', 'NetworkResource');
        else
          $.allOf[0]['$ref'] = $.allOf[0]['$ref'].replace('SubResource', 'NetworkWritableResource');
        delete $.properties.name;
        delete $.properties.type;
      }
    reason: Resources with id, name and type should inherit from NetworkResource/NetworkWritableResource instead of SubResource.
  - from: virtualWan.json
    where: $.definitions
    transform: >
      delete $.VpnServerConfigurationProperties.properties.name;
      delete $.VpnServerConfigurationProperties.properties.etag;
    reason: The same property is defined in VpnServerConfiguration and service only returns value there.
  - from: azureFirewall.json
    where: $.definitions
    transform: >
      $.AzureFirewallIpGroups.properties.id['x-ms-format'] = 'arm-id';
  - from: networkWatcher.json
    where: $.definitions
    transform: >
      $.NetworkInterfaceAssociation.properties.id['x-ms-format'] = 'arm-id';
      $.SubnetAssociation.properties.id['x-ms-format'] = 'arm-id';
      $.PacketCaptureResult.properties.type = {
        'readOnly': true,
        'type': 'string',
        'description': 'Resource type.'
      };
  - from: usage.json
    where: $.definitions
    transform: >
      $.Usage.properties.id['x-ms-format'] = 'arm-id';
  - from: virtualNetwork.json
    where: $.definitions
    transform: >
      $.VirtualNetworkUsage.properties.id['x-ms-format'] = 'arm-id';
  - from: virtualWan.json
    where: $.definitions
    transform: >
      $.VpnGatewayIpConfiguration.properties.id['x-ms-format'] = 'arm-id';
  - from: endpointService.json
    where: $.definitions
    transform: >
      $.EndpointServiceResult.properties.type['x-ms-format'] = 'resource-type';
      delete $.EndpointServiceResult.allOf;
      $.EndpointServiceResult.properties.id = {
          'readOnly': true,
          'type': 'string',
          'description': 'Resource ID.',
          'x-ms-format': 'arm-id'
      };
    reason: id should be read-only.
  - from: virtualNetwork.json
    where: $.definitions
    transform: >
      $.ResourceNavigationLinkFormat.properties.link['x-ms-format'] = 'arm-id';
      $.ServiceAssociationLinkPropertiesFormat.properties.link['x-ms-format'] = 'arm-id';
  - from: networkInterface.json # a temporary fix for issue https://github.com/Azure/azure-sdk-for-net/issues/34094
    where: $.definitions.EffectiveNetworkSecurityGroup.properties.tagMap.type
    transform: return "object";
  # To workaround breaking change
  - from: routeTable.json
    where: $.definitions
    transform: >
      delete $.RoutePropertiesFormat.properties.hasBgpOverride.readOnly;
  # This part is for generate partial class in network
  # Remove all files that not belong to Network
  - from: cloudServiceNetworkInterface.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  - from: cloudServicePublicIpAddress.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  # disable the flatten and add additional properties to its properties object
  - from: loadBalancer.json
    where: $.definitions
    transform: >
      $.LoadBalancingRule.properties.properties["x-ms-client-flatten"] = false;
      $.LoadBalancingRulePropertiesFormat.additionalProperties = true;
      $.InboundNatPool.properties.properties["x-ms-client-flatten"] = false;
      $.InboundNatPoolPropertiesFormat.additionalProperties = true;
  # - from: vmssPublicIpAddress.json
  #   where: $.paths
  #   transform: >
  #     for (var path in $)
  #     {
  #         delete $[path];
  #     }
  # - from: vmssNetworkInterface.json
  #   where: $.paths
  #   transform: >
  #     for (var path in $)
  #     {
  #         delete $[path];
  #     }
  # - from: vmssNetworkInterface.json
  #   where: $.definitions
  #   transform: >
  #     for (var def in $)
  #     {
  #         delete $[def];
  #     }
  # - from: vmssNetworkInterface.json
  #   where: $.parameters
  #   transform: >
  #     for (var param in $)
  #     {
  #         delete $[param];
  #     }

  # Remove the format of id which break current type replacement logic, issue https://github.com/Azure/azure-sdk-for-net/issues/47589 opened to track this requirement.
  - from: network.json
    where: $.definitions
    transform: >
      delete $.CommonResource.properties.id.format;
```
