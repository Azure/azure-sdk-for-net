# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/37072829f795ce840b8085035e8adf4721602f34/specification/dnsresolver/resource-manager/readme.md
library-name: dnsresolver
namespace: Azure.ResourceManager.DnsResolver
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*IPAddress': 'ip-address'
  'ResourceGuid': 'uuid'

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

directive:
  - from: dnsresolver.json
    where: $.definitions
    transform: >
      $.VirtualNetworkDnsForwardingRuleset.properties.id['x-ms-format'] = 'arm-id';
```
