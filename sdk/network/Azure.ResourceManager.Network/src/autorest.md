# AutoRest Configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
library-name: Network
namespace: Azure.ResourceManager.Network
require: https://github.com/Azure/azure-rest-api-specs/blob/ae5f241249f12e87e94e184ae5430518ac061a51/specification/network/resource-manager/readme.md
# tag: package-2022-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
model-namespace: true
public-clients: false
head-as-boolean: false
resource-model-requires-type: false

# mgmt-debug: 
#   show-serialized-names: true

rename-mapping:
  ConnectionMonitor: ConnectionMonitorInput
  ConnectionMonitorResult: ConnectionMonitor
  PacketCapture: PacketCaptureInput
  PacketCaptureResult: PacketCapture
  IPConfigurationBgpPeeringAddress.ipconfigurationId: IPConfigurationId
  VirtualNetworkGatewayNatRule.properties.type: VpnNatRuleType   # VirtualNetworkGatewayNatRuleProperties is flatten in VirtualNetworkGatewayNatRule
  SubResource: NetworkSubResource
  ProvisioningState: NetworkProvisioningState
  IpAllocation.properties.type: IPAllocationType
  VirtualWAN.properties.type: VirtualWanType
  VpnGatewayNatRule.properties.type: VpnNatRuleType
  Topology: NetworkTopology
  TopologyResource: TopologyResourceInfo
  TrafficAnalyticsConfigurationProperties.trafficAnalyticsInterval: TrafficAnalyticsIntervalInMinutes
  TroubleshootingParameters.properties.storagePath: storageUri
  ProtocolConfiguration.HTTPConfiguration: HttpProtocolConfiguration
  FlowLogFormatParameters: FlowLogProperties
  TrafficAnalyticsProperties.networkWatcherFlowAnalyticsConfiguration: TrafficAnalyticsConfiguration
  UsageName: NetworkUsageName
  UsagesListResult: NetworkUsagesListResult
  Delegation: ServiceDelegation
  Subnet.properties.privateEndpointNetworkPolicies: PrivateEndpointNetworkPolicy
  Subnet.properties.privateLinkServiceNetworkPolicies: PrivateLinkServiceNetworkPolicy
  AzureFirewallApplicationRuleCollection: AzureFirewallApplicationRuleCollectionData
  AzureFirewallNatRuleCollection: AzureFirewallNatRuleCollectionData
  AzureFirewallNetworkRuleCollection: AzureFirewallNetworkRuleCollectionData
  FirewallPolicyRuleCollection: FirewallPolicyRuleCollectionInfo
  FirewallPolicyNatRuleCollection: FirewallPolicyNatRuleCollectionInfo
  FirewallPolicyFilterRuleCollection: FirewallPolicyFilterRuleCollectionInfo
  ApplicationGateway.zones: AvailabilityZones
  ApplicationGatewayPrivateEndpointConnection.properties.privateLinkServiceConnectionState: connectionState
  ApplicationGatewayBackendHttpSettings.properties.requestTimeout: RequestTimeoutInSeconds
  ApplicationGatewayConnectionDraining.drainTimeoutInSec: DrainTimeoutInSeconds
  ApplicationGatewayProbe.properties.interval: IntervalInSeconds
  ApplicationGatewayProbe.properties.timeout: TimeoutInSeconds
  ApplicationGatewayPrivateLinkIpConfiguration.properties.primary: IsPrimary
  PrivateLinkServiceConnection.properties.privateLinkServiceConnectionState: connectionState
  DeleteOptions: IPAddressDeleteOption
  TransportProtocol: LoadBalancingTransportProtocol
  UsageUnit: NetworkUsageUnit
  Direction: NetworkTrafficDirection
  Origin: IssueOrigin
  Severity: IssueSeverity
  Protocol: NetworkWatcherProtocol
  Access: NetworkAccess
  Resource: NetworkTrackedResourceData
  ConnectivityIssue.context: Contexts
  VpnClientConnectionHealthDetail.vpnConnectionDuration: vpnConnectionDurationInSeconds
  VpnClientConnectionHealthDetail.VpnConnectionTime: vpnConnectedOn
  TunnelConnectionHealth.lastConnectionEstablishedUtcTime: lastConnectionEstablishedOn
  ConnectivityIssue.type: ConnectivityIssueType
  HttpHeader: NetworkWatcherHttpHeader
  HttpMethod: NetworkWatcherHttpMethod
  HttpConfiguration: NetworkHttpConfiguration
  HttpConfigurationMethod: NetworkHttpConfigurationMethod
  IPVersion: NetworkIPVersion
  IPConfiguration: NetworkIPConfiguration
  IPConfigurationProfile: NetworkIPConfigurationProfile
  IPConfigurationBgpPeeringAddress: NetworkIPConfigurationBgpPeeringAddress
  IPAllocationMethod: NetworkIPAllocationMethod
  IpAllocationType: NetworkIPAllocationType
  IpAllocationListResult: NetworkIPAllocationListResult
  AuthenticationMethod: NetworkAuthenticationMethod
  ConnectionStateSnapshot.connectionState: NetworkConnectionState
  ConnectivityInformation.connectionStatus: NetworkConnectionStatus
  DscpConfigurationPropertiesFormat.protocol: NetworkProtocolType
  CustomDnsConfigPropertiesFormat: CustomDnsConfigProperties
  ProtocolCustomSettingsFormat: ProtocolCustomSettings
  ServiceEndpointPropertiesFormat: ServiceEndpointProperties
  ConnectionStatus: NetworkConnectionStatus
  IssueType: ConnectivityIssueType
  PrivateLinkServiceConnection: NetworkPrivateLinkServiceConnection
  ConnectivityHop: ConnectivityHopInfo
  ConnectivityIssue: ConnectivityIssueInfo
  PreferredIPVersion: TestEvalPreferredIPVersion
  InboundNatPool: LoadBalancerInboundNatPool
  TagsObject: NetworkTagsObject
  EndpointType: ConnectionMonitorEndpointType
  ConnectionState: NetworkConnectionState
  ApplicationGatewayAvailableSslOptions: ApplicationGatewayAvailableSslOptionsInfo
  EffectiveNetworkSecurityGroup.tagMap: tagToIPAddresses
  Action: RouteMapAction
  ActionType: RuleMatchActionType
  ActiveConfigurationParameter: ActiveConfigurationContent
  ActiveConfigurationParameter.regions: -|azure-location
  ActiveConnectivityConfiguration.region: -|azure-location
  ActiveConnectivityConfiguration.commitTime: CommittedOn
  AdminRule: NetworkAdminRule
  ApplicationGatewayBackendSettings.properties.timeout: TimeoutInSeconds
  ApplicationGatewayTierTypes.WAF: Waf
  ApplicationGatewayTierTypes.WAF_v2: WafV2
  ConfigurationGroup: NetworkConfigurationGroup
  ConfigurationType: NetworkConfigurationDeploymentType
  Criterion: RouteCriterion
  DefaultAdminRule: NetworkDefaultAdminRule
  EffectiveBaseSecurityAdminRule.id: ResourceId|arm-id
  ExplicitProxy: FirewallPolicyExplicitProxy
  IdpsQueryObject: IdpsQueryContent
  FilterItems: IdpsQueryFilterItems
  OrderBy: IdpsQueryOrderBy
  Geo: CidrAdvertisingGeoCode
  Geo.NAM: Nam
  Hub: ConnectivityHub
  IsGlobal: GlobalMeshSupportFlag
  IsWorkloadProtected: WorkloadProtectedFlag
  NextStep: RouteMapNextStepBehavior
  Parameter: RouteMapActionParameter
  QosDefinition: DscpQosDefinition
  QueryResults: IdpsSignatureListResult
  SingleQueryResult: IdpsSignatureResult
  QueryRequestOptions: NetworkManagementQueryContent
  SignatureOverridesFilterValuesQuery: SignatureOverridesFilterValuesQueryContent
  SignatureOverridesFilterValuesResponse: SignatureOverridesFilterValuesResult
  SlotType: SwapSlotType
  UseHubGateway: HubGatewayUsageFlag
  VirtualNetworkEncryption.enabled: IsEnabled
  VpnPolicyMemberAttributeType.AADGroupId: AadGroupId
  CustomIpPrefix.properties.customIpPrefixParent: ParentCustomIpPrefix
  CustomIpPrefix.properties.childCustomIpPrefixes: ChildCustomIpPrefixList
  VpnAuthenticationType.AAD: Aad
  ApplicationGatewayWafDynamicManifestResult: ApplicationGatewayWafDynamicManifest
  ApplicationGatewayWafDynamicManifestResultList: ApplicationGatewayWafDynamicManifestListResult
  SignaturesOverrides: PolicySignaturesOverridesForIdps
  SignaturesOverrides.id: -|arm-id
  SignaturesOverrides.type: -|resource-type
  SignaturesOverridesList: PolicySignaturesOverridesForIdpsListResult
  SignaturesOverridesProperties: PolicySignaturesOverridesForIdpsProperties
  StaticMember: NetworkGroupStaticMember
  StaticMemberListResult: NetworkGroupStaticMemberListResult
  AdminRuleCollection: AdminRuleGroup
  AdminRuleCollectionListResult: AdminRuleGroupListResult
  NetworkManagerConnection.properties.networkManagerId: -|arm-id
  SwapResource: CloudServiceSwap
  SwapResourceProperties: CloudServiceSwapProperties
  SwapResourceListResult: CloudServiceSwapListResult
  Hub.resourceType: -|resource-type
  DelegationProperties: VirtualApplianceDelegationProperties
  DeploymentStatus: NetworkManagerDeploymentState
  NetworkManagerDeploymentStatus.deploymentStatus: DeploymentState
  NetworkManagerDeploymentStatusParameter: NetworkManagerDeploymentStatusContent
  GetInboundRoutesParameters: VirtualHubInboundRoutesContent
  GetOutboundRoutesParameters: VirtualHubOutboundRoutesContent
  IPPrefixesList: LearnedIPPrefixesListResult
  NetworkManagerSecurityGroupItem.networkGroupId: -|arm-id
  PrivateEndpointIPConfiguration.properties.privateIPAddress: -|ip-address
  PublicIpDdosProtectionStatusResult.publicIpAddressId: -|arm-id
  PublicIpDdosProtectionStatusResult.publicIpAddress: -|ip-address
  PublicIpDdosProtectionStatusResult.ddosProtectionPlanId: -|arm-id
  VpnClientParameters: VpnClientContent
  VpnPacketCaptureStopParameters: VpnPacketCaptureStopContent
  VpnPacketCaptureStartParameters: VpnPacketCaptureStartContent
  ExpressRouteGateway.properties.expressRouteConnections: ExpressRouteConnectionList

keep-plural-resource-data:
- PolicySignaturesOverridesForIdps

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

rename-rules:
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

override-operation-name:
  ApplicationGateways_ListAvailableWafRuleSets: GetAppGatewayAvailableWafRuleSets
  VirtualNetworkGateways_VpnDeviceConfigurationScript: VpnDeviceConfigurationScript
  VirtualHubBgpConnections_ListLearnedRoutes: GetLearnedRoutesVirtualHubBgpConnection
  VirtualHubBgpConnections_ListAdvertisedRoutes: GetAdvertisedRoutesVirtualHubBgpConnection
  ApplicationGateways_ListAvailableSslOptions: GetApplicationGatewayAvailableSslOptions
  ApplicationGateways_ListAvailableSslPredefinedPolicies: GetApplicationGatewayAvailableSslPredefinedPolicies
  ApplicationGateways_GetSslPredefinedPolicy: GetApplicationGatewaySslPredefinedPolicy
  VirtualNetworkGateways_Generatevpnclientpackage: GenerateVpnClientPackage

directive:
  - remove-operation: 'PutBastionShareableLink'
  - remove-operation: 'DeleteBastionShareableLink'
  - remove-operation: 'GetBastionShareableLink'
  - remove-operation: 'GetActiveSessions'
  - remove-operation: 'DisconnectActiveSessions'
  - remove-operation: 'VirtualNetworks_ListDdosProtectionStatus'
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
  - from: vmssPublicIpAddress.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  - from: vmssNetworkInterface.json
    where: $.paths
    transform: >
      for (var path in $)
      {
          delete $[path];
      }
  - from: vmssNetworkInterface.json
    where: $.definitions
    transform: >
      for (var def in $)
      {
          delete $[def];
      }
  - from: vmssNetworkInterface.json
    where: $.parameters
    transform: >
      for (var param in $)
      {
          delete $[param];
      }
```
