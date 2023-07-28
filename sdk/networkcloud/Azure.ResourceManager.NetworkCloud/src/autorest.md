# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkCloud
namespace: Azure.ResourceManager.NetworkCloud
require: https://github.com/Azure/azure-rest-api-specs/blob/64efc48302878a07d1d1231eaed0ca9cadfaf037/specification/networkcloud/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

# 'tenantId': 'uuid' cannot be used globally as it break our list clusters API where tenantId sometimes is an empty string
format-by-name-rules:
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  ImageRepositoryCredentials.registryUrl: registryUriString

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
  - from: networkcloud.json
    where: $.definitions
    transform:
      $.ClusterAvailableUpgradeVersion.properties.expectedDuration['x-ms-format'] = 'duration';
  # The `password` is not required as it return null from service side
  - from: networkcloud.json
    where: $.definitions
    transform:
      $.AdministrativeCredentials.required =  [ 'username' ];
      $.ImageRepositoryCredentials.required = [
        'username',
        'registryUrl'
      ];
      $.ServicePrincipalInformation.required = [
        'tenantId',
        'principalId',
        'applicationId'
      ];
  # `delete` transformations are to remove APIs/methods that result in Access Denied for end users.
  - remove-operation: BareMetalMachines_CreateOrUpdate
  - remove-operation: BareMetalMachines_Delete
  - remove-operation: Racks_CreateOrUpdate
  - remove-operation: Racks_Delete
  - remove-operation: StorageAppliances_CreateOrUpdate
  - remove-operation: StorageAppliances_Delete

```
