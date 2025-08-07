# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ElasticSan
namespace: Azure.ResourceManager.ElasticSan
require: https://github.com/Azure/azure-rest-api-specs/blob/3db6867b8e524ea6d1bc7a3bbb989fe50dd2f184/specification/elasticsan/resource-manager/readme.md
#tag: package-2024-07-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  MBps: Mbps
  LRS: Lrs
  ZRS: Zrs
  XMs: Xms

prepend-rp-prefix:
  - EncryptionType
  - Name
  - Tier
  - Volume
  - VolumeCreateOption
  - VolumeGroup
  - VolumeGroupList
  - VolumeList
  - SkuInformationList
  - SkuLocationInfo
  - Snapshot
  - KeyVaultProperties
  - EncryptionProperties
  - PublicNetworkAccess
  - StorageTargetType
  - DeleteType
  - VirtualNetworkRule
  - EncryptionIdentity
  - NetworkRuleSet
  - ScaleUpProperties
  - DeleteRetentionPolicy

rename-mapping:
  Volume.properties.volumeId: -|uuid
  VirtualNetworkRule.id: -|arm-id
  EncryptionIdentity.userAssignedIdentity: -|arm-id
  Action: ElasticSanVirtualNetworkRuleAction
  OperationalStatus: ResourceOperationalStatus
  ProvisioningStates: ElasticSanProvisioningState
  State: ElasticSanVirtualNetworkRuleState
  SKUCapability: ElasticSanSkuCapability
  SourceCreationData: ElasticSanVolumeDataSourceInfo
  SnapshotCreationData: SnapshotCreationInfo
  DiskSnapshotList: DiskSnapshotListContent
  PolicyState: ElasticSanDeleteRetentionPolicyState
  PreValidationResponse: ElasticSanPreValidationResult
  VolumeNameList: ElasticSanVolumeNameListContent
  XMsDeleteSnapshots: ElasticSanDeleteSnapshotsUnderVolume
  XMsAccessSoftDeletedResources: ElasticSanAccessSoftDeletedVolume
  XMsForceDelete: ElasticSanForceDeleteVolume

directive:
- from: elasticsan.json
  where: $.definitions.SourceCreationData.properties.sourceId
  transform: $["x-ms-format"] = "arm-id";
- from: elasticsan.json
  where: $.definitions.SnapshotCreationData.properties.sourceId
  transform: $["x-ms-format"] = "arm-id";
- from: elasticsan.json
  where: $.definitions.ManagedByInfo.properties.resourceId
  transform: $["x-ms-format"] = "arm-id";
- from: elasticsan.json
  where: $.paths..parameters[?(@.name=='x-ms-force-delete')]
  transform: >
    $['x-ms-client-name'] = 'ForceDelete';
- from: elasticsan.json
  where: $.paths..parameters[?(@.name=='x-ms-access-soft-deleted-resources')]
  transform: >
    $['x-ms-client-name'] = 'AccessSoftDeletedResources';
- from: elasticsan.json
  where: $.paths..parameters[?(@.name=='x-ms-delete-snapshots')]
  transform: >
    $['x-ms-client-name'] = 'DeleteSnapshots';
```
