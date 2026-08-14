# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: AppConfiguration
namespace: Azure.ResourceManager.AppConfiguration
require: https://github.com/Azure/azure-rest-api-specs/blob/b72e0199fa3242d64b0b49f38e71586066a8c048/specification/appconfiguration/resource-manager/readme.md
# tag: package-2024-05-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  # Snapshot is immutable once created, there won't be any update method on it. Skip generating the sample test on this method, so it will pass the build.
  - Snapshots_Create
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true
deserialize-null-collection-as-null-value: true

#mgmt-debug:
#  show-serialized-names: true

no-property-type-replacement: RegenerateKeyContent

rename-mapping:
  ApiKey.lastModified: LastModifiedOn
  ApiKey.readOnly: IsReadOnly
  AuthenticationMode: DataPlaneProxyAuthenticationMode
  CompositionType: SnapshotCompositionType
  DeletedConfigurationStore.properties.purgeProtectionEnabled: IsPurgeProtectionEnabled
  DeletedConfigurationStore.properties.configurationStoreId: -|arm-id
  NameAvailabilityStatus.nameAvailable: IsNameAvailable
  KeyValue.properties.lastModified: LastModifiedOn
  KeyValue.properties.locked: IsLocked
  KeyValueFilter: SnapshotKeyValueFilter
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
  PrivateLinkDelegation: DataPlaneProxyPrivateLinkDelegation
  Replica: AppConfigurationReplica
  ReplicaProvisioningState: AppConfigurationReplicaProvisioningState
  Snapshot.properties.created: CreatedOn
  Snapshot.properties.expires: ExpireOn

prepend-rp-prefix:
  - ActionsRequired
  - CreateMode
  - DataPlaneProxyProperties
  - KeyValue
  - KeyValueListResult
  - KeyVaultProperties
  - ProvisioningState
  - PublicNetworkAccess
  - RegenerateKeyParameters
  - Snapshot
  - SnapshotStatus

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
  ETag: ETag|eTag

request-path-to-parent:
  /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/deletedConfigurationStores: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/locations/{location}/deletedConfigurationStores/{configStoreName}
directive:
  - from: v2/types.json
    where: $.definitions.ErrorResponse
    transform: >
      $["x-ms-client-name"] = "ErrorResponseV2";
  - from: v5/types.json
    where: $.definitions.ErrorResponse
    transform: >
      $["x-ms-client-name"] = "ErrorResponseV5";
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
```
