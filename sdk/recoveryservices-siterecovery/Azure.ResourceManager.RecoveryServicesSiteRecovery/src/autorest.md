# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: RecoveryServicesSiteRecovery
namespace: Azure.ResourceManager.RecoveryServicesSiteRecovery
require: https://github.com/Azure/azure-rest-api-specs/blob/d1eb4e42e24016044e150c0fb8f0dc6c1182b5f5/specification/recoveryservicessiterecovery/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

rename-mapping:
  Alert: ReplicationAlert
  AlertProperties: ReplicationAlertProperties
  AlertCollection: ReplicationAlertListResult
  Event: SiteRecoveryEvent
  Fabric: SiteRecoveryFabric
  Job: SiteRecoveryJob
  LogicalNetwork: ReplicationLogicalNetwork
  MigrationItem: ReplicationMigrationItem
  MigrationRecoveryPointCollection: MigrationRecoveryPointListResult
  Network: ReplicationNetwork
  NetworkProperties: ReplicationNetworkProperties
  NetworkMapping: ReplicationNetworkMapping
  Policy: ReplicationPolicy
  PolicyProperties: ReplicationPolicyProperties
  ProtectableItem: ReplicationProtectableItem
  ProtectionContainer: ReplicationProtectionContainer
  ProtectionContainerMapping: ReplicationProtectionContainerMapping
  RecoveryPlan: ReplicationRecoveryPlan
  RecoveryPoint: SiteRecoveryPoint
  RecoveryServicesProvider: SiteRecoveryServicesProvider
  StorageClassification: ReplicationStorageClassification
  StorageClassificationMapping: ReplicationStorageClassificationMapping
  VaultSetting: ReplicationVaultSetting
  VCenter: ReplicationVCenter
  AddDisksInput: AddDisksContent
  AddRecoveryServicesProviderInputProperties: AddSiteRecoveryServicesProviderProperties
  AddVCenterRequestProperties: AddReplicationVCenterRequestProperties
  ApplianceCollection: ReplicationApplianceListResult
  ApplianceSpecificDetails: ReplicationApplianceSpecificDetails
  ApplyRecoveryPointInput: ApplySiteRecoveryPointContent
  ApplyRecoveryPointInputProperties: ApplySiteRecoveryPointProperties
  ApplyRecoveryPointProviderSpecificInput: ApplySiteRecoveryPointProviderSpecificContent
  ASRTask: AsrTask
  ConfigureAlertRequestProperties: ConfigureReplicationAlertCreationProperties
  ConfigurationSettings: ReplicationProviderSettings
  CreateNetworkMappingInputProperties: ReplicationNetworkMappingCreationProperties
  CreateProtectionContainerInputProperties: ReplicationProtectionContainerCreationProperties
  CreateProtectionContainerMappingInputProperties: ReplicationProtectionContainerMappingProperties
  ReplicationProviderSpecificContainerCreationInput: ReplicationProviderSpecificContainerCreationContent
  InMageRcmFailbackReplicationDetails.targetvCenterId: TargetVCenterId

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
  LRS: Lrs
  SSD: Ssd
  Vmware: VMware|vmware
  VCPUs: VCpus
  Vcenter: VCenter

request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs/export: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs/{jobName}

directive:
  - remove-operation: Operations_List
  # Because can't rename the purge operation, so have to make this change to avoid compiling error.
  # Issue filed here: https://github.com/Azure/autorest.csharp/issues/2743
  - remove-operation: ReplicationFabrics_Purge
  - remove-operation: ReplicationRecoveryServicesProviders_Purge
  # Why the `client` value can't be processing correctly but only `method`?
  - from: service.json
    where: $.parameters
    transform: >
      $.ResourceGroupName['x-ms-parameter-location'] = 'method';
      $.ResourceName['x-ms-parameter-location'] = 'method';

```
