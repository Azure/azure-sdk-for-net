# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Azure.ResourceManager.ManagedNetworkFabric
namespace: Azure.ResourceManager.ManagedNetworkFabric
require: https://github.com/Azure/azure-rest-api-specs/blob/0691ac4b0e05c8ca3bde2f8a33f036c12282fa25/specification/managednetworkfabric/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
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

directive:
  - from: NetworkFabricControllers.json
    where: $.definitions
    transform:
      $.ExpressRouteConnectionInformation.required =  [ 'expressRouteCircuitId' ];

  # CodeGen don't support some definitions in v4 & v5 common types, here is an issue https://github.com/Azure/autorest.csharp/issues/3537 opened to fix this problem
  - from: v5/types.json
    where: $.definitions
    transform: >
      delete $.Resource.properties.id.format;

  - from: v5/types.json
    where: $.parameters
    transform: >
      delete $.SubscriptionIdParameter.format;

  - from: InternetGatewayRules.json
    where: $.definitions.RuleProperties.properties.action
    transform: >
      $['x-ms-enum']['name'] = 'InternetGatewayRuleAction';

  # Removing the operations that are not allowed for the end users.
  - remove-operation: InternetGateways_Delete
  - remove-operation: InternetGateways_Create
```
