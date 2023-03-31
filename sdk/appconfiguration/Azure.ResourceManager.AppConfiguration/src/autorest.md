# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/d7b7399fb1e1a328b49cd6a998714c6efb877bf2/specification/appconfiguration/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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
````
