# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Logic
namespace: Azure.ResourceManager.Logic
require: https://github.com/Azure/azure-rest-api-specs/blob/353d84dac009c19ae776c25eb361f07e85f26c8d/specification/logic/resource-manager/readme.md
tag: package-2019-05
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Logic/workflows/{workflowName}/runs/{runName}/operations/{operationId}

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
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
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

directive:
  - from: logic.json
    where: $.definitions
    transform: >
      $.RetryHistory.properties.error['x-ms-client-name'] = 'ErrorResponse';
      $.OpenAuthenticationAccessPolicies.properties.policies['x-ms-client-name'] = 'AccessPolicies';

```