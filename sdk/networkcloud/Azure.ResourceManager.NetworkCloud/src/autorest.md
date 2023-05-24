# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkCloud
namespace: Azure.ResourceManager.NetworkCloud
require: https://github.com/Azure/azure-rest-api-specs/blob/c94569d116a82ee11a94c5dfb190650dd675a1bf/specification/networkcloud/resource-manager/readme.md
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
  - remove-operation: HybridAksClusters_CreateOrUpdate
  - remove-operation: HybridAksClusters_Delete
  - remove-operation: Racks_CreateOrUpdate
  - remove-operation: Racks_Delete
  - remove-operation: StorageAppliances_CreateOrUpdate
  - remove-operation: StorageAppliances_Delete

```
