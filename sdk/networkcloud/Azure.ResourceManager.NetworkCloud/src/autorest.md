# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: NetworkCloud
namespace: Azure.ResourceManager.NetworkCloud
require: https://github.com/Azure/azure-rest-api-specs/blob/073fed0ecce0a1f0c95d0c790e20b3670740507c/specification/networkcloud/resource-manager/readme.md
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
  # temporary workaround for https://github.com/Azure/autorest.csharp/issues/3546
  # remove new POST direction 'final-state-schema' until autorest core is upgraded
  - from: networkcloud.json
    where: $.paths.*.post['x-ms-long-running-operation-options']
    transform: >
      delete $['final-state-schema'];
  # The core library Azure.ResourceManager has been generated when the subscriptionId was not marked as an uuid.
  # v5 of common-types defines `subscriptionId` as `guid` format and needs to be removed in order to generate valid code.
  - from: types.json
    where: $.parameters.SubscriptionIdParameter
    transform: >
      delete $['format'];
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
