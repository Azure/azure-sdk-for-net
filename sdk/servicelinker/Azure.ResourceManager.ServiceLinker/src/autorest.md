# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ServiceLinker
namespace: Azure.ResourceManager.ServiceLinker
require: https://github.com/Azure/azure-rest-api-specs/blob/42ca0236ef14093f5aff0694efa34d5594e814a0/specification/servicelinker/resource-manager/readme.md
tag: package-2022-05-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  TargetServiceBase: TargetServiceBaseInfo
  AzureResource: AzureResourceInfo
  ConfluentBootstrapServer: ConfluentBootstrapServerInfo
  ConfluentSchemaRegistry: ConfluentSchemaRegistryInfo
  AzureResourcePropertiesBase: AzureResourceBaseProperties
  SecretInfoBase: SecretBaseInfo
  ValueSecretInfo: RawValueSecretInfo
  AuthInfoBase: AuthBaseInfo
  AuthType: LinkerAuthType
  SecretType: LinkerSecretType
  SecretStore: LinkerSecretStore
  ClientType: LinkerClientType
  ValidationResultItem: ValidationResultItemData


format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'keyVaultId': 'arm-id'
  'sourceId': 'arm-id'
  'targetId': 'arm-id'
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
  VNet: Vnet
  Etag: ETag

directive:
  - from: servicelinker.json
    where: $.definitions
    transform: >
      $.AzureResource.properties.id['x-ms-format'] = 'arm-id';
      $.TargetServiceBase.properties.type['x-ms-client-name'] = 'TargetServiceType';
      $.AzureResourcePropertiesBase.properties.type['x-ms-client-name'] = 'AzureResourceType';

```