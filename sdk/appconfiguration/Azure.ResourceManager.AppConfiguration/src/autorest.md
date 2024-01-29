# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/e8c4e082948a49ef5dc8acf6c5b9d581b603370e/specification/appconfiguration/resource-manager/readme.md
tag: package-2023-03-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

no-property-type-replacement: RegenerateKeyContent

rename-mapping:
  ApiKey.lastModified: LastModifiedOn
  ApiKey.readOnly: IsReadOnly
  DeletedConfigurationStore.properties.purgeProtectionEnabled: IsPurgeProtectionEnabled
  DeletedConfigurationStore.properties.configurationStoreId: -|arm-id
  NameAvailabilityStatus.nameAvailable: IsNameAvailable
  KeyValue.properties.lastModified: LastModifiedOn
  KeyValue.properties.locked: IsLocked
  ApiKey: AppConfigurationStoreApiKey
  ApiKeyListResult: AppConfigurationStoreApiKeyListResult
  CheckNameAvailabilityParameters: AppConfigurationNameAvailabilityContent
  ConfigurationResourceType: AppConfigurationResourceType
  ConfigurationStore: AppConfigurationStore
  ConfigurationStoreListResult: AppConfigurationStoreListResult
  ConnectionStatus: AppConfigurationPrivateLinkServiceConnectionStatus
  DeletedConfigurationStore: DeletedAppConfigurationStore
  EncryptionProperties: AppConfigurationStoreEncryptionProperties
  NameAvailabilityStatus: AppConfigurationNameAvailabilityResult
  PrivateEndpointConnectionReference: AppConfigurationPrivateEndpointConnectionReference
  Replica: AppConfigurationReplica
  ReplicaProvisioningState: AppConfigurationReplicaProvisioningState

prepend-rp-prefix:
  - ActionsRequired
  - CreateMode
  - KeyValue
  - KeyValueListResult
  - KeyVaultProperties
  - ProvisioningState
  - PublicNetworkAccess
  - RegenerateKeyParameters

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'eTag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

request-path-to-parent:
  /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/deletedConfigurationStores: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}
directive:
  - from: swagger-document
    where: $.definitions.EncryptionProperties
    transform: >
      $.properties.keyVaultProperties["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.ConfigurationStoreProperties
    transform: >
      $.properties.privateEndpointConnections["x-nullable"] = true;
  - rename-operation:
      from: Operations_CheckNameAvailability
      to: CheckAppConfigurationNameAvailability

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/keyValues/{keyValueName}
````
