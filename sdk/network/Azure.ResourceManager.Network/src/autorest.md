# AutoRest Configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
library-name: Network
namespace: Azure.ResourceManager.Network
require: https://github.com/Azure/azure-rest-api-specs/blob/7384176da46425e7899708f263e0598b851358c2/specification/network/resource-manager/readme.md
tag: package-track2-preview

output-folder: Generated/
clear-output-folder: true

modelerfour:
    lenient-model-deduplication: true
model-namespace: true
public-clients: false
head-as-boolean: false
flatten-payloads: false
#TODO: remove after we resolve why DdosCustomPolicy has no list
list-exception:
  DdosCustomPolicies
operation-group-to-resource-type:
    # applicationgateway.json
    ApplicationGatewayPrivateLinkResources: Microsoft.Network/applicationGateways/privateLinkResources
    ApplicationGatewayAvailableServiceVariables: Microsoft.Network/applicationGatewayAvailableServerVariables
    ApplicationGatewayAvailableRequestHeaders: Microsoft.Network/applicationGatewayAvailableRequestHeaders
    AppicationGatewayAvailableResponseHeaders: Microsoft.Network/applicationGatewayAvailableResponseHeaders
    ApplicationGatewayAvailableWafRuleSets: Microsoft.Network/applicationGatewayAvailableWafRuleSets
    ApplicationGatewayAvailableSslOptions: Microsoft.Network/applicationGatewayAvailableSslOptions/default
    ApplicationGatewayAvailableSslPredefinedPolicies: Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies
    AvailableDelegations: Microsoft.Network/locations/availableDelegations
    AvailableServiceAliases: Microsoft.Network/locations/availableServiceAliases
    # azureFirewallFqdnTag.json
    AzureFirewallFqdnTags: Microsoft.Network/azureFirewallFqdnTags
    AvailableEndpointServices: Microsoft.Network/locations/virtualNetworkAvailableEndpointServices
    PeerExpressRouteCircuitConnections: Microsoft.Network/expressRouteCircuits/peerings/peerConnections
    ExpressRouteServiceProviders: Microsoft.Network/expressRouteServiceProviders
    ExpressRoutePortsLocations: Microsoft.Network/ExpressRoutePortsLocations
    ExpressRouteLinks: Microsoft.Network/ExpressRoutePorts/links
    # bastionHost.json
    # BastionShareableLinks: Microsoft.Network/bastionHosts/bastionShareableLinks
    # ActiveSessions: Microsoft.Network/bastionHosts/activeSessions
    # checkDnsAvailability.json
    DnsNameAvailabilities: Microsoft.Network/locations/CheckDnsNameAvailability
    # loadBalancer.json
    LoadBalancerFrontendIPConfigurations: Microsoft.Network/loadBalancers/frontendIPConfigurations
    LoadBalancerLoadBalancingRules: Microsoft.Network/loadBalancers/loadBalancingRules
    LoadBalancerOutboundRules: Microsoft.Network/loadBalancers/outboundRules
    LoadBalancerNetworkInterfaces: Microsoft.Network/loadBalancers/networkInterfaces
    LoadBalancerProbes: Microsoft.Network/loadBalancers/probes
    # network.json
    # NetworkInterfaces: Microsoft.Comupte/cloudServices/networkIntefaces
    NetworkInterfaceIPConfigurations: Microsoft.Network/networkInterfaces/ipConfigurations
    NetworkInterfaceLoadBalancers: Microsoft.Network/networkInterfaces/loadBalancers
    # networkSecurityGroup.json
    DefaultSecurityRules: Microsoft.Network/networkSecurityGroups/defaultSecurityRules
    # networkVirtualAppliance.json
    VirtualApplianceSkus: Microsoft.Network/networkVirtualApplianceSkus
    InboundSecurityRule: Microsoft.Network/networkVirtualAppliances/inboundSecurityRules
    # InboundSecurityRule: Microsoft.Network/networkVirtualAppliances/inboundSecurityRules
    # operation.json
    Operations: Microsoft.Network/operations
    # privateEndpoint.json
    AvailablePrivateEndpointTypes: Microsoft.Network/locations/availablePrivateEndpointTypes
    # serviceCommunity.json
    BgpServiceCommunities: Microsoft.Network/bgpServiceCommunities
    # serviceTags.json
    ServiceTags: Microsoft.Network/locations/serviceTags
    # usage.json
    Usages: Microsoft.Network/locations/usages
    # virtualNetwork.json
    # VirtualNetworkUsage: Microsoft.Network/virtualNetworks/usages
    ResourceNavigationLinks: Microsoft.Network/virtualNetworks/subnets/ResourceNavigationLinks
    ServiceAssociationLinks: Microsoft.Network/virtualNetworks/subnets/ServiceAssociationLinks
    # virtualWan.json
    VpnSiteLinks: Microsoft.Network/vpnSites/vpnSiteLinks
    VpnSiteLinkConnections: Microsoft.Network/vpnGateways/vpnConnections/vpnLinkConnections
    VpnSitesConfiguration: Microsoft.Network/virtualWans/vpnConfiguration
    VpnServerConfigurationsAssociatedWithVirtualWan: Microsoft.Network/virtualWans
    SupportedSecurityProviders: Microsoft.Network/virtualWans/supportedSecurityProviders
    VpnLinkConnections: Microsoft.Network/vpnGateways/vpnConnections/vpnLinkConnections
    VirtualWanVpnServerConfigurationVpnProfiles: Microsoft.Network/virtualWans/GenerateVpnProfile
    # azureWebCategory.json
    WebCategories: Microsoft.Network/azureWebCategories
operation-group-to-resource:
    # applicationgateway.json
    ApplicationGatewayPrivateLinkResources: NonResource
    ApplicationGatewayAvailableServiceVariables: NonResource
    ApplicationGatewayAvailableRequestHeaders: NonResource
    AppicationGatewayAvailableResponseHeaders: NonResource
    ApplicationGatewayAvailableWafRuleSets: NonResource
    ApplicationGatewayAvailableSslOptions: NonResource
    ApplicationGatewayAvailableSslPredefinedPolicies: NonResource
    AvailableDelegations: NonResource
    AvailableServiceAliases: NonResource
    AzureFirewallFqdnTags: NonResource
    # NetworkInterfaces: NetworkInteface
    AvailableEndpointServices: NonResource
    PeerExpressRouteCircuitConnections: NonResource
    ExpressRouteServiceProviders: NonResource
    ExpressRoutePortsLocations: NonResource
    ExpressRouteLinks: NonResource
    # bastionHost.json
    # BastionShareableLinks: NonResource
    # ActiveSessions: NonResource
    # checkDnsAvailability.json
    DnsNameAvailabilities: NonResource
    # loadBalancer.json
    LoadBalancerFrontendIPConfigurations: NonResource
    LoadBalancerLoadBalancingRules: NonResource
    LoadBalancerOutboundRules: NonResource
    LoadBalancerNetworkInterfaces: NonResource
    LoadBalancerProbes: NonResource
    # network.json
    NetworkInterfaceIPConfigurations: NonResource
    NetworkInterfaceLoadBalancers: NonResource
    # networkSecurityGroup.json
    DefaultSecurityRules: NonResource
    # networkVirtualAppliance.json
    VirtualApplianceSkus: NonResource
    InboundSecurityRule: NonResource
    # networkWatcher.json
    PacketCaptures: PacketCapture
    ConnectionMonitors: ConnectionMonitor
    # operations.json
    Operations: NonResource
    # privateEndpoint.json
    AvailablePrivateEndpointTypes: NonResource
    # serviceCommunity.json
    BgpServiceCommunities: NonResource
    # serviceTags.json
    ServiceTags: NonResource
    # usage.json
    Usages: NonResource
    # virtualNetwork.json
    # VirtualNetworkUsage: NonResource
    ResourceNavigationLinks: NonResource
    ServiceAssociationLinks: NonResource
    # virtualWan.json
    VpnSiteLinks: NonResource
    VpnSitesConfiguration: NonResource
    VpnServerConfigurationsAssociatedWithVirtualWan: NonResource
    VpnSiteLinkConnections: NonResource
    SupportedSecurityProviders: NonResource
    VpnLinkConnections: NonResource
    VirtualWanVpnServerConfigurationVpnProfiles: NonResource
    # azureWebCategory.json
    WebCategories: NonResource
operation-group-to-parent:
    AvailableDelegations: resourceGroups
    # bastionHost.json
    # BastionShareableLinks: BastionHosts
    # ActiveSessions: BastionHosts
    # checkDnsAvailability.json
    DnsNameAvailabilities: subscriptions
    # networkinferface.json
    # NetworkInterfaces: ResourceGroup
    # NetworkInterfaceIPConfigurations: NetworkInterface
    # NetworkInterfaceLoadBalancers: NetworkInterface
    # NetworkInterfaceTapConfigurations: NetworkInterface
    LoadBalancerFrontendIPConfigurations: Microsoft.Network/loadBalancers
    # networkSecurityGroup.json
    DefaultSecurityRules: Microsoft.Network/networkSecurityGroups
    # endpoint.json
    InboundSecurityRule: Microsoft.Network/networkVirtualAppliances
    AvailableEndpointServices: subscriptions
    AvailablePrivateEndpointTypes: subscriptions
    ServiceTags: subscriptions
    Usages: subscriptions
    # virtualWan.json
    VpnServerConfigurationsAssociatedWithVirtualWan: Microsoft.Network/virtualWans
    VpnSitesConfiguration: Microsoft.Network/virtualWans
    VirtualWanVpnServerConfigurationVpnProfiles: Microsoft.Network/virtualWans
    # azureWebCategory.json
    WebCategories: subscriptions
singleton-resource: ConnectionSharedKey
directive:
  # rename Operation to RestApi
  - rename-model:
      from: Operation
      to: RestApi
#   networkWatcher.json:
  - rename-model:
      from: ConnectionMonitor
      to: ConnectionMonitorInput
  - rename-model:
      from: ConnectionMonitorResult
      to: ConnectionMonitor
  - rename-model:
      from: PacketCapture
      to: PacketCaptureInput
  - rename-model:
      from: PacketCaptureResult
      to: PacketCapture
# applicationgateway.json
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableServerVariables"].get.operationId
    transform: return "ApplicationGatewayAvailableServiceVariables_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableRequestHeaders"].get.operationId
    transform: return "ApplicationGatewayAvailableRequestHeaders_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableResponseHeaders"].get.operationId
    transform: return "AppicationGatewayAvailableResponseHeaders_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableWafRuleSets"].get.operationId
    transform: return "ApplicationGatewayAvailableWafRuleSets_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default"].get.operationId
    transform: return "ApplicationGatewayAvailableSslOptions_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies"].get.operationId
    transform: return "ApplicationGatewayAvailableSslPredefinedPolicies_List"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/applicationGatewayAvailableSslOptions/default/predefinedPolicies/{predefinedPolicyName}"].get.operationId
    transform: return "ApplicationGatewayAvailableSslPredefinedPolicies_Get"
# TODO: ADO 6044
#  - from: swagger-document
#    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/bastionHosts/{bastionHostName}/createShareableLinks"].post.operationId
#    transform: return "BastionHosts_CreateShareableLinks"
#    reason: Original 'operationId' doesn't follow pattern
#  - from: swagger-document
#    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/bastionHosts/{bastionHostName}/deleteShareableLinks"].post.operationId
#    transform: return "BastionHosts_DeleteShareableLinks"
#    reason: Original 'operationId' doesn't follow pattern
#  - from: swagger-document
#    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/bastionHosts/{bastionHostName}/getShareableLinks"].post.operationId
#    transform: return "BastionHosts_GetShareableLinks"
#    reason: Original 'operationId' doesn't follow pattern
#  - from: swagger-document
#    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/bastionHosts/{bastionHostName}/getActiveSessions"].post.operationId
#    transform: return "BastionHosts_GetActiveSessions"
#    reason: Original 'operationId' doesn't follow pattern
#  - from: swagger-document
#    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/bastionHosts/{bastionHostName}/disconnectActiveSessions"].post.operationId
#    transform: return "BastionHosts_DisconnectActiveSessions"
#    reason: Original 'operationId' doesn't follow pattern
  - remove-operation: "PutBastionShareableLink"
  - remove-operation: "DeleteBastionShareableLink"
  - remove-operation: "GetBastionShareableLink"
  - remove-operation: "GetActiveSessions"
  - remove-operation: "DisconnectActiveSessions"
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/locations/{location}/availableDelegations"].get.operationId
    transform: return "AvailableDelegations_ListByResourceGroup"
    reason: Original 'operationId' is not good, it's actually returned the same type resource but under different context
# checkDnsAvailability.json
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/providers/Microsoft.Network/locations/{location}/CheckDnsNameAvailability"].get.operationId
    transform: return "DnsNameAvailabilities_Check"
    reason: Original 'operationId' doesn't follow pattern
# virtualWan.json
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualWans/{virtualWANName}/supportedSecurityProviders"].get.operationId
    transform: return "SupportedSecurityProviders_List"
    reason: Original 'operationId' doesn't follow pattern
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualWans/{virtualWANName}/GenerateVpnProfile"].post.operationId
    transform: return "VirtualWanVpnServerConfigurationVpnProfiles_Generate"
    reason: Original 'operationId' doesn't follow pattern
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}/bgpConnections/{connectionName}"].get.operationId
    transform: return "VirtualHubBgpConnections_Get"
    reason: Original 'operationId' doesn't follow pattern
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}/bgpConnections/{connectionName}"].put.operationId
    transform: return "VirtualHubBgpConnections_CreateOrUpdate"
    reason: Original 'operationId' doesn't follow pattern
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}/bgpConnections/{connectionName}"].delete.operationId
    transform: return "VirtualHubBgpConnections_Delete"
    reason: Original 'operationId' doesn't follow pattern
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
