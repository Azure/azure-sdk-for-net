# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://github.com/Azure/azure-rest-api-specs/blob/b26a190235f162b15d77dad889d104d06871fb4f/specification/dnsresolver/resource-manager/readme.md
#tag: package-preview-2023-07
library-name: dnsresolver
namespace: Azure.ResourceManager.DnsResolver
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  sample: false #true
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

partial-resources:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}: VirtualNetwork

override-operation-name:
  DnsResolvers_ListByVirtualNetwork: GetDnsResolvers
  DnsForwardingRulesets_ListByVirtualNetwork: GetDnsForwardingRulesets

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*IPAddress': 'ip-address'
  'ResourceGuid': 'uuid'

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
  DnsForwardingRulesetName: rulesetName

rename-mapping:
  ProvisioningState: DnsResolverProvisioningState
  ForwardingRule: DnsForwardingRule
  ForwardingRuleState: DnsForwardingRuleState
  ForwardingRule.properties.forwardingRuleState: DnsForwardingRuleState
  ForwardingRulePatch.properties.forwardingRuleState: DnsForwardingRuleState
  InboundEndpoint: DnsResolverInboundEndpoint
  IpConfiguration: InboundEndpointIpConfiguration
  IpAllocationMethod: InboundEndpointIPAllocationMethod
  OutboundEndpoint: DnsResolverOutboundEndpoint
  VirtualNetworkLink: DnsForwardingRulesetVirtualNetworkLink
  ActionType: DnsSecurityRuleActionType

directive:
  - from: dnsresolver.json
    where: $.definitions
    transform: >
      $.VirtualNetworkDnsForwardingRuleset.properties.id['x-ms-format'] = 'arm-id';
```
