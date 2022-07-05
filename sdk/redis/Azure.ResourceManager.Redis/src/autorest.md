# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Redis
namespace: Azure.ResourceManager.Redis
require: https://github.com/Azure/azure-rest-api-specs/blob/5419bfc41fe7a45955df3f342c4d5d81ea785a35/specification/redis/resource-manager/readme.md
tag: package-2021-06
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
  - from: redis.json
    where: $.paths..parameters[?(@.name === 'default')]
    transform: >
      $['x-ms-client-name'] = 'defaultName';
  - from: redis.json
    where: $.definitions
    transform: >
      $.OperationStatus.allOf = [
        {
          "$ref": "../../../../../common-types/resource-management/v2/types.json#/definitions/OperationStatusResult"
        }
      ];
      $.RedisResource['x-ms-client-name'] = 'Redis';
      delete $.OperationStatus.allOf; 

  # This must be revmoved after https://github.com/Azure/azure-sdk-for-net/issues/29636 was fixed
  - from: redis.json
    where: $.definitions
    transform: >
      delete $.OperationStatus.allOf; 

```