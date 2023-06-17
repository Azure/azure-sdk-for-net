# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: RecoveryServicesSiteRecovery
namespace: Azure.ResourceManager.RecoveryServicesSiteRecovery
require: https://github.com/Azure/azure-rest-api-specs/blob/95fb710c0025b325306898a3210333eaaf5d5e62/specification/recoveryservicessiterecovery/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

mgmt-debug: 
  show-serialized-names: true

rename-mapping:
  Alert: SiteRecoveryAlert
  AlertProperties: SiteRecoveryAlertProperties
  AlertCollection: SiteRecoveryAlertListResult
  Fabric: SiteRecoveryFabric
  Job: SiteRecoveryJob
  JobErrorDetails: SiteRecoveryJobErrorDetails
  LogicalNetwork: SiteRecoveryLogicalNetwork
  MigrationItem: SiteRecoveryMigrationItem
  MigrationItemCollection: SiteRecoveryMigrationItemListResult
  MigrationItemProperties: SiteRecoveryMigrationItemProperties
  MigrationRecoveryPoint: SiteRecoveryMigrationRecoveryPoint
  MigrationRecoveryPointCollection: SiteRecoveryMigrationRecoveryPointListResult
  Network: SiteRecoveryNetwork
  NetworkProperties: SiteRecoveryNetworkProperties
  NetworkCollection: SiteRecoveryNetworkListResult
  NetworkMapping: SiteRecoveryNetworkMapping
  Policy: SiteRecoveryPolicy
  PolicyProperties: SiteRecoveryPolicyProperties
  ProtectableItem: SiteRecoveryProtectableItem
  ProtectionContainer: SiteRecoveryProtectionContainer
  ProtectionContainerMapping: SiteRecoveryProtectionContainerMapping
  RecoveryPlan: SiteRecoveryRecoveryPlan
  RecoveryPoint: SiteRecoveryPoint
  RecoveryServicesProvider: SiteRecoveryServicesProvider
  StorageClassification: SiteRecoveryStorageClassification
  StorageClassificationMapping: SiteRecoveryStorageClassificationMapping
  VaultSetting: SiteRecoveryVaultSetting
  VCenter: SiteRecoveryVCenter
  ReplicationAppliance: SiteRecoveryAppliance
  ApplianceCollection: SiteRecoveryApplianceListResult
  ApplianceSpecificDetails: SiteRecoveryApplianceSpecificDetails
  ASRTask: AsrTask
  ConfigurationSettings: SiteRecoveryReplicationProviderSettings
  CreateNetworkMappingInputProperties: SiteRecoveryCreateReplicationNetworkMappingProperties
  CreateProtectionContainerInputProperties: SiteRecoveryCreateProtectionContainerProperties
  CreateProtectionContainerMappingInputProperties: SiteRecoveryCreateProtectionContainerMappingProperties
  InMageRcmFailbackReplicationDetails.targetvCenterId: TargetVCenterId
  SecurityType: VirtualMachineSecurityType
  A2ACrossClusterMigrationReplicationDetails.primaryFabricLocation: -|azure-location
  A2AVmManagedDiskInputDetails: A2AVmManagedDiskDetails
  A2AProtectedDiskDetails.resyncRequired: IsResyncRequired
  A2AProtectedManagedDiskDetails.recoveryTargetDiskId: -|arm-id
  A2AProtectedManagedDiskDetails.recoveryReplicaDiskId: -|arm-id
  A2AProtectedManagedDiskDetails.recoveryOrignalTargetDiskId: -|arm-id
  A2AProtectedManagedDiskDetails.resyncRequired: IsResyncRequired
  A2AProtectionIntentDiskInputDetails: A2AProtectionIntentDiskDetails
  A2AProtectionIntentManagedDiskInputDetails: A2AProtectionIntentManagedDiskDetails
  A2AVmDiskInputDetails: A2AVmDiskDetails
  AddDisksInput: SiteRecoveryAddDisksContent
  AddDisksInputProperties: SiteRecoveryAddDisksProperties
  AddDisksProviderSpecificInput: SiteRecoveryAddDisksProviderSpecificContent
  AddVCenterRequestProperties: SiteRecoveryAddVCenterRequestProperties
  AddVCenterRequestProperties.ipAddress: -|ip-address
  AddRecoveryServicesProviderInputProperties: SiteRecoveryAddRecoveryServicesProviderProperties
  AgentAutoUpdateStatus: SiteRecoveryAgentAutoUpdateStatus
  AgentDetails: SiteRecoveryAgentDetails
  AgentDiskDetails: SiteRecoveryAgentDiskDetails
  AgentVersionStatus: SiteRecoveryAgentVersionStatus
  ApplyRecoveryPointInput: SiteRecoveryApplyRecoveryPointContent
  ApplyRecoveryPointInputProperties: SiteRecoveryApplyRecoveryPointProperties
  ApplyRecoveryPointProviderSpecificInput: SiteRecoveryApplyRecoveryPointProviderSpecificContent
  AzureFabricCreationInput: SiteRecoveryFabricProviderCreationContent
  AzureFabricSpecificDetails: SiteRecoveryFabricProviderSpecificDetails
  AzureFabricSpecificDetails.containerIds: -|arm-id
  AzureToAzureCreateNetworkMappingInput: A2ACreateNetworkMappingContent
  AzureToAzureNetworkMappingSettings: A2ANetworkMappingSettings
  AzureToAzureUpdateNetworkMappingInput: A2AUpdateNetworkMappingContent
  AzureToAzureVmSyncedConfigDetails: A2AVmSyncedConfigDetails
  AzureVmDiskDetails: SiteRecoveryVmDiskDetails
  ComputeSizeErrorDetails: SiteRecoveryComputeSizeErrorDetails
  CreatePolicyInputProperties: SiteRecoveryCreatePolicyProperties
  CreateProtectionIntentProperties: ReplicationCreateProtectionIntentProperties
  CreateProtectionIntentProviderSpecificDetails: ReplicationCreateProtectionIntentProviderDetail
  CreateRecoveryPlanInputProperties: SiteRecoveryCreateRecoveryPlanProperties
  DataStore: SiteRecoveryDataStore
  DataStore.uuid: -|uuid
  DataSyncStatus: SiteRecoveryDataSyncStatus
  DisableProtectionInputProperties: DisableProtectionProperties
  DiskAccountType: SiteRecoveryDiskAccountType
  DiskDetails: SiteRecoveryDiskDetails
  DiskEncryptionInfo: SiteRecoveryDiskEncryptionInfo
  DiskEncryptionKeyInfo: SiteRecoveryDiskEncryptionKeyInfo
  DiskReplicationProgressHealth: SiteRecoveryDiskReplicationProgressHealth
  DiskVolumeDetails: SiteRecoveryDiskVolumeDetails
  DraDetails: SiteRecoveryDraDetails
  DraDetails.lastHeartbeatUtc: LastHeartbeatReceivedOn
  EnableMigrationInputProperties: EnableMigrationProperties
  EnableProtectionInputProperties: EnableProtectionProperties
  EncryptionDetails: SiteRecoveryEncryptionDetails
  EthernetAddressType: SiteRecoveryEthernetAddressType
  Event: SiteRecoveryEvent
  EventCollection: SiteRecoveryListResult
  EventProperties: SiteRecoveryEventProperties
  EventProperties.timeOfOccurrence: OccurredOn
  EventProviderSpecificDetails: SiteRecoveryEventProviderSpecificDetails
  EventSpecificDetails: SiteRecoveryEventSpecificDetails
  ExtendedLocation: SiteRecoveryExtendedLocation
  ExtendedLocationType: SiteRecoveryExtendedLocationType
  FabricCollection: SiteRecoveryFabricListResult
  FabricCreationInputProperties: SiteRecoveryFabricCreationProperties
  FabricProperties: SiteRecoveryFabricProperties
  FabricReplicationGroupTaskDetails: SiteRecoveryFabricReplicationGroupTaskDetails
  FabricSpecificCreateNetworkMappingInput: SiteRecoveryFabricSpecificCreateNetworkMappingContent
  FabricSpecificCreationInput: SiteRecoveryFabricSpecificCreationContent
  FabricSpecificDetails: SiteRecoveryFabricSpecificDetails
  FabricSpecificUpdateNetworkMappingInput: SiteRecoveryFabricSpecificUpdateNetworkMappingContent
  FailoverDeploymentModel: SiteRecoveryFailoverDeploymentModel
  FailoverJobDetails: SiteRecoveryFailoverJobDetails
  FailoverProcessServerRequest: SiteRecoveryFailoverProcessServerContent
  FailoverProcessServerRequestProperties: SiteRecoveryFailoverProcessServerProperties
  FailoverReplicationProtectedItemDetails: SiteRecoveryFailoverReplicationProtectedItemDetails
  GroupTaskDetails: SiteRecoveryGroupTaskDetails
  HealthError: SiteRecoveryHealthError
  HealthErrorCategory: SiteRecoveryHealthErrorCategory
  HealthErrorCustomerResolvability: SiteRecoveryHealthErrorCustomerResolvability
  HealthErrorSummary: SiteRecoveryHealthErrorSummary
  HyperVReplicaAzureDiskInputDetails: HyperVReplicaAzureDiskDetails
  HyperVReplicaAzureEnableProtectionInput.hvHostVmId: HyperVHostVmId
  HyperVReplicaAzureEnableProtectionInput.targetAzureSubnetId: -|arm-id
  HyperVReplicaAzureReprotectInput.hvHostVmId: HyperVHostVmId
  HyperVReplicaAzureReprotectInput.vHDId: VhdId
  IdentityProviderDetails: SiteRecoveryIdentityProviderDetails
  IdentityProviderInput: SiteRecoveryIdentityProviderContent
  InMageAzureV2DiskInputDetails: InMageAzureV2DiskDetails
  InMageAzureV2ProtectedDiskDetails.psDataInMegaBytes: PSDataInMegaBytes
  InMageAzureV2ProtectedDiskDetails.resyncLastDataTransferTimeUTC: ResyncLastDataTransferOn
  InMageAzureV2SwitchProviderDetails.targetVaultId: -|arm-id
  InMageAzureV2SwitchProviderDetails.targetResourceId: -|arm-id
  InMageAzureV2SwitchProviderInput.targetVaultID: -|arm-id
  InMageProtectedDiskDetails.psDataInMB: PSDataInMB
  InMageRcmDiscoveredProtectedVmDetails.createdTimestamp: CreatedOn
  InMageRcmDiscoveredProtectedVmDetails.updatedTimestamp: UpdatedOn
  InMageRcmFailbackDiscoveredProtectedVmDetails.createdTimestamp: CreatedOn
  InMageRcmFailbackDiscoveredProtectedVmDetails.updatedTimestamp: UpdatedOn
  InMageRcmFailbackDiscoveredProtectedVmDetails.lastDiscoveryTimeInUtc: LastDiscoveredOn
  InMageRcmFailbackMobilityAgentDetails.lastHeartbeatUtc: LastHeartbeatReceivedOn
  InMageRcmFailbackProtectedDiskDetails.lastSyncTime: LastSyncedOn
  InMageRcmFailbackReplicationDetails.azureVirtualMachineId: -|arm-id
  InMageRcmFailbackSyncDetails.lastDataTransferTimeUtc: LastDataTransferOn|date-time
  InMageRcmFailbackSyncDetails.startTime: StartOn|date-time
  InMageRcmFailbackSyncDetails.lastRefreshTime: LastRefreshOn|date-time
  InMageRcmMobilityAgentDetails.lastHeartbeatUtc: LastHeartbeatReceivedOn

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ResourceGroupId': 'arm-id'
  '*FabricObjectId': 'arm-id'
  '*ArmId': 'arm-id'
  'RecoveryContainerId': 'arm-id'
  '*AvailabilitySetId': 'arm-id'
  '*ProximityPlacementGroupId': 'arm-id'
  '*StorageAccountId': 'arm-id'
  '*VirtualMachineScaleSetId': 'arm-id'
  '*NetworkId': 'arm-id'
  '*CapacityReservationGroupId': 'arm-id'
  '*KeyVaultId': 'arm-id'
  '*FabricLocation': 'azure-location'
  '*DiskEncryptionSetId': 'arm-id'
  'PrimaryLocation': 'azure-location'
  'RecoveryLocation': 'azure-location'
  '*PolicyId': 'arm-id'
  '*RecoveryPointId': 'arm-id'
  '*FabricId': 'arm-id'
  'JobId': 'arm-id'
  'ProtectableItemId': 'arm-id'
  '*IPAddress': 'ip-address'
  '*IPAddresses': 'ip-address'

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
  ExpiryOn: ExpireOn
  ExpiryDate: ExpireOn
  Input: Content

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
