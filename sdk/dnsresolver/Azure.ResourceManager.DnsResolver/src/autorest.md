# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://github.com/Azure/azure-rest-api-specs/blob/8600539fa5ba6c774b4454a401d9cd3cf01a36a7/specification/dnsresolver/resource-manager/readme.md
# tag: package-2025-05 - Commented to default to latest
library-name: dnsresolver
namespace: Azure.ResourceManager.DnsResolver
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  sample: false # Current issue with virtual network dns resolver resouce autogen that is being addressed in autorest repo https://github.com/Azure/autorest.csharp/issues/5134
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

# mgmt-debug:
#   show-serialized-names: true

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
  VirtualNetworkDnsForwardingRuleset.id: -|arm-id
```
