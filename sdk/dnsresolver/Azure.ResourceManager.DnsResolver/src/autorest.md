# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
# TODO REPLACE WITH PUBLIC LINK
require: https://github.com/jamesvoongms/jamesvoong-azure-rest-api-specs/tree/108c4eed0da1236a63ad6c0d18c33fdd14f8e439/specification/dnsresolver/resource-manager/readme.md
tag: package-2025-01
library-name: dnsresolver
namespace: Azure.ResourceManager.DnsResolver
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  sample: true
  output-folder: $(this-folder)/../samples/Generated
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
  Action: DnsResolverDomainListBulkAction

directive:
  - from: dnsresolver.json
    where: $.definitions
    transform: >
      $.VirtualNetworkDnsForwardingRuleset.properties.id['x-ms-format'] = 'arm-id';
```
