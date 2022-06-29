# AutoRest Configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
library-name: Network
namespace: Azure.ResourceManager.Network
require: https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/readme.md
tag: package-track2-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
model-namespace: true
public-clients: false
head-as-boolean: false
resource-model-requires-type: false

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
  FlowLogFormatParameters: FlowLogFormat
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
  Direction: TrafficDirection
  Origin: IssueOrigin
  Severity: IssueSeverity
  Protocol: NetworkWatcherProtocol
  Access: NetworkAccess
  Resource: NetworkTrackedResourceData

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'locations': 'azure-location'
  'azureLocation': 'azure-location'
  'azureLocations': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Etag: ETag
  BGP: Bgp

#TODO: remove after we resolve why DdosCustomPolicy has no list
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/ddosCustomPolicies/{ddosCustomPolicyName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/vpnGateways/{gatewayName}/vpnConnections/{connectionName}/vpnLinkConnections/{linkConnectionName}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/securityRules/{securityRuleName}: SecurityRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkSecurityGroups/{networkSecurityGroupName}/defaultSecurityRules/{defaultSecurityRuleName}: DefaultSecurityRule

override-operation-name:
  ApplicationGateways_ListAvailableWafRuleSets: GetApplicationGatewayAvailableWafRuleSetsAsync
  VirtualNetworkGateways_VpnDeviceConfigurationScript: VpnDeviceConfigurationScript

directive:
  - remove-operation: 'PutBastionShareableLink'
  - remove-operation: 'DeleteBastionShareableLink'
  - remove-operation: 'GetBastionShareableLink'
  - remove-operation: 'GetActiveSessions'
  - remove-operation: 'DisconnectActiveSessions'
  - remove-operation: 'ApplicationGateways_ListAvailableSslOptions'
  - remove-operation: 'ApplicationGateways_ListAvailableSslPredefinedPolicies'
  - remove-operation: 'ApplicationGateways_GetSslPredefinedPolicy'
  - from: virtualNetworkGateway.json
    where: $.definitions
    transform: >
      $.BgpPeerStatus.properties.connectedDuration['x-ms-format'] = 'duration-constant';
      $.VirtualNetworkGatewayPropertiesFormat.properties.vNetExtendedLocationResourceId['x-ms-format'] = 'arm-id';
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
      $.VirtualWanVpnProfileParameters.properties.vpnServerConfigurationResourceId['x-ms-format'] = 'arm-id';
  - from: virtualWan.json
    where: $.definitions.VpnServerConfigurationProperties.properties.name
    transform: 'return undefined'
    reason: The same property is defined in VpnServerConfiguration and service only returns value there.
  - from: virtualWan.json
    where: $.definitions.VpnServerConfigurationProperties.properties.etag
    transform: 'return undefined'
    reason: The same property is defined in VpnServerConfiguration and service only returns value there.
  - from: swagger-document
    where: $.definitions..resourceGuid
    transform: >
      $['format'] = 'uuid';
  - from: swagger-document
    where: $.definitions..targetResourceId
    transform: >
      $['x-ms-format'] = 'arm-id';
  - from: swagger-document
    where: $.definitions..resourceId
    transform: >
      $['x-ms-format'] = 'arm-id';
  - from: azureFirewall.json
    where: $.definitions
    transform: >
      $.AzureFirewallIpGroups.properties.id['x-ms-format'] = 'arm-id';
  - from: networkWatcher.json
    where: $.definitions
    transform: >
      $.FlowLogPropertiesFormat.properties.targetResourceGuid['format'] = 'uuid';
      $.NetworkInterfaceAssociation.properties.id['x-ms-format'] = 'arm-id';
      $.SubnetAssociation.properties.id['x-ms-format'] = 'arm-id';
      $.PacketCaptureResult.properties.type = {
        'readOnly': true,
        'type': 'string',
        'description': 'Resource type.'
      };
      $.ConnectionMonitorWorkspaceSettings.properties.workspaceResourceId['x-ms-format'] = 'arm-id';
      $.TrafficAnalyticsConfigurationProperties.properties.workspaceResourceId['x-ms-format'] = 'arm-id';
      $.EvaluatedNetworkSecurityGroup.properties.networkSecurityGroupId['x-ms-format'] = 'arm-id';
      $.VerificationIPFlowParameters.properties.targetNicResourceId['x-ms-format'] = 'arm-id';
      $.NextHopParameters.properties.targetNicResourceId['x-ms-format'] = 'arm-id';
      $.NextHopResult.properties.routeTableId['x-ms-format'] = 'arm-id';
      $.PacketCaptureStorageLocation.properties.storageId['x-ms-format'] = 'arm-id';
      $.TroubleshootingProperties.properties.storageId['x-ms-format'] = 'arm-id';
      $.FlowLogProperties.properties.storageId['x-ms-format'] = 'arm-id';
      $.FlowLogPropertiesFormat.properties.storageId['x-ms-format'] = 'arm-id';
  - from: usage.json
    where: $.definitions
    transform: >
      $.Usage.properties.id['x-ms-format'] = 'arm-id';
  - from: virtualNetwork.json
    where: $.definitions
    transform: >
        $.ServiceAssociationLinkPropertiesFormat.properties.linkedResourceType['x-ms-format'] = 'resource-type';
        $.ServiceAssociationLinkPropertiesFormat.properties.link['x-ms-format'] = 'arm-id';
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
# shorten 'privateLinkServiceConnectionState' property name
  - from: privateEndpoint.json
    where: $.definitions
    transform: >
      $.PrivateLinkServiceConnectionProperties.properties.privateLinkServiceId['x-ms-format'] = 'arm-id';
  - from: serviceEndpointPolicy.json
    where: $.definitions
    transform: >
      $.ServiceEndpointPolicyDefinitionPropertiesFormat.properties.serviceResources.items['x-ms-format'] = 'arm-id';

```

### Tag: package-track2-preview

4 definitions regarding `compute` service are ignored in this release.

These settings apply only when `--tag=package-track2-preview` is specified on the command line.

```yaml $(tag) == 'package-track2-preview'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/applicationGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/applicationSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/availableDelegations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/availableServiceAliases.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/azureFirewall.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/azureFirewallFqdnTag.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/azureWebCategory.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/bastionHost.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/checkDnsAvailability.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/cloudServiceNetworkInterface.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/cloudServicePublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/customIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/ddosCustomPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/ddosProtectionPlan.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/dscpConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/endpointService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/expressRouteCircuit.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/expressRouteCrossConnection.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/expressRoutePort.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/firewallPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/ipAllocation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/ipGroups.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/loadBalancer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/natGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/network.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/networkInterface.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/networkProfile.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/networkSecurityGroup.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/networkVirtualAppliance.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/networkWatcher.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/operation.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/privateEndpoint.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/privateLinkService.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/publicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/publicIpPrefix.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/routeFilter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/routeTable.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/securityPartnerProvider.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/serviceCommunity.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/serviceEndpointPolicy.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/serviceTags.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/usage.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/virtualNetwork.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/virtualNetworkGateway.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/virtualNetworkTap.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/virtualRouter.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/virtualWan.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/vmssNetworkInterface.json
#   - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/vmssPublicIpAddress.json
  - https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/Microsoft.Network/stable/2021-02-01/webapplicationfirewall.json
```
