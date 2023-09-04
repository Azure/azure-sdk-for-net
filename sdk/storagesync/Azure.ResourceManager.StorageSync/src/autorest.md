# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: StorageSync
namespace: Azure.ResourceManager.StorageSync
require: https://github.com/ankushbindlish2/azure-rest-api-specs/blob/e98964a41ed956313897c815c9a56056802c2008/specification/storagesync/resource-manager/readme.md
#tag: package-2022-09
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug: 
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  '*TenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'resourceLocation': 'azure-location'
  'serviceLocation': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceId': 'arm-id'
  'clusterId': 'uuid'
  'serverId': 'uuid'
  'storageSyncServiceUid': 'uuid'
  'uniqueId': 'uuid'
  'lastOperationId': 'uuid'
  'serverCertificate': 'any'

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
  HeartBeat: Heartbeat

prepend-rp-prefix:
  - Workflow
  - WorkflowStatus
  - FeatureStatus
  - OperationDirection
  - RegisteredServer
  - ServerEndpoint

rename-mapping:
  RestoreFileSpec.isdir: IsDirectory
  CloudEndpoint.properties.backupEnabled: IsBackupEnabled
  PostBackupResponse: CloudEndpointPostBackupResult
  BackupRequest: CloudEndpointBackupContent
  RegisteredServer.properties.agentVersionExpirationDate: AgentVersionExpireOn
  SyncGroup: StorageSyncGroup
  CheckNameAvailabilityParameters: StorageSyncNameAvailabilityContent
  CheckNameAvailabilityResult: StorageSyncNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  NameAvailabilityReason: StorageSyncNameUnavailableReason
  Type: StorageSyncResourceType
  CloudEndpointChangeEnumerationActivity.totalSizeBytes: TotalSizeInBytes
  CloudEndpointChangeEnumerationStatus.completedTimestamp: CompletedOn
  CloudEndpointChangeEnumerationActivity.startedTimestamp: StartedOn
  ServerEndpointBackgroundDataDownloadActivity.startedTimestamp: StartedOn
  CloudEndpointLastChangeEnumerationStatus.namespaceSizeBytes: NamespaceSizeInBytes
  CloudEndpointLastChangeEnumerationStatus.startedTimestamp: StartedOn
  CloudEndpointLastChangeEnumerationStatus.completedTimestamp: CompletedOn
  CloudTieringSpaceSavings.volumeSizeBytes: VolumeSizeInBytes
  CloudTieringSpaceSavings.cachedSizeBytes: CachedSizeInBytes
  CloudTieringSpaceSavings.spaceSavingsBytes: SpaceSavingsInBytes
  CloudTieringSpaceSavings.totalSizeCloudBytes: CloudTotalSizeInBytes
  Workflow.properties.createdTimestamp: CreatedOn
  Workflow.properties.lastStatusTimestamp: LastStatusUpdatedOn
  ServerEndpointCloudTieringStatus.healthLastUpdatedTimestamp: HealthLastUpdatedOn

override-operation-name:
  CloudEndpoints_restoreheartbeat: RestoreHeartbeat
  StorageSyncServices_CheckNameAvailability: CheckStorageSyncNameAvailability

directive:
  - remove-operation: OperationStatus_Get
  - remove-operation: LocationOperationStatus
  - from: storagesync.json
    where: $.definitions..lastUpdatedTimestamp
    transform: >
      $['x-ms-client-name'] = 'LastUpdatedOn';
  - from: storagesync.json
    where: $.paths..parameters[?(@.name == 'serverId')]
    transform: >
      $.format = 'uuid';
```
