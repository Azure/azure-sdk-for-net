# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ccdf0b74eedb671fe038ed1a30a9be9f911ebc4f/specification/dnsresolver/resource-manager/readme.md

library-name: dnsresolver

namespace: Azure.ResourceManager.DnsResolver

clear-output-folder: true

skip-csproj: true

output-folder: Generated/

mgmt-debug:
    show-request-path: true
 
directive:
  - from: swagger-document
    where: $.definitions.InboundEndpointProperties.properties.ipConfigurations
    transform: $['x-ms-client-name'] = 'iPConfigurations'
  - from: swagger-document
    where: $.definitions.IpConfiguration
    transform: $['x-ms-client-name'] = 'IPConfiguration'
  - from: swagger-document
    where: $.definitions.IpConfiguration.properties.privateIpAddress
    transform: $['x-ms-client-name'] = 'privateIPAddress'
  - from: swagger-document
    where: $.definitions.IpConfiguration.properties.privateIpAllocationMethod
    transform: $['x-ms-client-name'] = 'privateIPAllocationMethod'
  - from: swagger-document
    where: $.definitions.IpConfiguration.properties.privateIpAllocationMethod
    transform: >
      $['x-ms-enum'] = {
          "name": "IPAllocationMethod",
          "modelAsString": true
      }
  - from: swagger-document
    where: $.definitions.TargetDnsServer.properties.ipAddress
    transform: $['x-ms-client-name'] = 'iPAddress'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsResolvers/{dnsResolverName}'].patch.parameters[3]
    transform: $['name'] = 'options'
  - from: swagger-document
    where: $.definitions.DnsResolverPatch
    transform: $['x-ms-client-name'] = 'DnsResolverUpdateOptions'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsResolvers/{dnsResolverName}/inboundEndpoints/{inboundEndpointName}'].patch.parameters[4]
    transform: $['name'] = 'options'
  - from: swagger-document
    where: $.definitions.InboundEndpointPatch
    transform: $['x-ms-client-name'] = 'InboundEndpointUpdateOptions'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsResolvers/{dnsResolverName}/outboundEndpoints/{outboundEndpointName}'].patch.parameters[4]
    transform: $['name'] = 'options'
  - from: swagger-document
    where: $.definitions.OutboundEndpointPatch
    transform: $['x-ms-client-name'] = 'OutboundEndpointUpdateOptions'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsForwardingRulesets/{dnsForwardingRulesetName}'].patch.parameters[3]
    transform: $['name'] = 'options'
  - from: swagger-document
    where: $.definitions.DnsForwardingRulesetPatch
    transform: $['x-ms-client-name'] = 'DnsForwardingRulesetUpdateOptions'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsForwardingRulesets/{dnsForwardingRulesetName}/forwardingRules/{forwardingRuleName}'].patch.parameters[4]
    transform: $['name'] = 'options'
  - from: swagger-document
    where: $.definitions.ForwardingRulePatch
    transform: $['x-ms-client-name'] = 'ForwardingRuleUpdateOptions'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsForwardingRulesets/{dnsForwardingRulesetName}/virtualNetworkLinks/{virtualNetworkLinkName}'].patch.parameters[4]
    transform: $['name'] = 'options'
  - from: swagger-document
    where: $.definitions.VirtualNetworkLinkPatch
    transform: $['x-ms-client-name'] = 'VirtualNetworkLinkUpdateOptions'
```
