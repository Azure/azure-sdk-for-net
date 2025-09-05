# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Migration.Assessment
namespace: Azure.ResourceManager.Migration.Assessment
require: https://github.com/Azure/azure-rest-api-specs/blob/56b8f400c8c9f20f8137fa12c37d25bcfdeb7725/specification/migrate/resource-manager/Microsoft.Migrate/AssessmentProjects/readme.md
tag: package-2023-03
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

rename-mapping:
  AssessedDisk: MigrationAssessedDisk
  AssessedDiskData: MigrationAssessedDataDisk
  AssessedMachine.properties.createdTimestamp: CreatedOn
  AssessedMachine.properties.updatedTimestamp: UpdatedOn
  AssessedMachine: MigrationAssessedMachine
  AssessedMachineType: MigrationAssessedMachineType
  AssessedSqlDatabaseV2.properties.createdTimestamp: CreatedOn
  AssessedSqlDatabaseV2.properties.updatedTimestamp: UpdatedOn
  AssessedSqlDatabaseV2: MigrationAssessedSqlDatabaseV2
  AssessedSqlInstanceV2.properties.createdTimestamp: CreatedOn
  AssessedSqlInstanceV2.properties.updatedTimestamp: UpdatedOn
  AssessedSqlInstanceV2: MigrationAssessedSqlInstanceV2
  AssessedSqlMachine.properties.createdTimestamp: CreatedOn
  AssessedSqlMachine.properties.updatedTimestamp: UpdatedOn
  AssessedSqlMachine: MigrationAssessedSqlMachine
  AssessedSqlRecommendedEntity: MigrationAssessedSqlRecommendedEntity
  Assessment.properties.createdTimestamp: CreatedOn
  Assessment.properties.pricesTimestamp: PricesQueriedOn
  Assessment.properties.updatedTimestamp: UpdatedOn
  Assessment: MigrationAssessment
  AssessmentOptions: MigrationAssessmentOptions
  AssessmentProject.properties.assessmentSolutionId: -|arm-id
  AssessmentProject.properties.createdTimestamp: CreateOn
  AssessmentProject.properties.customerWorkspaceId: -|arm-id
  AssessmentProject.properties.updatedTimestamp: UpdatedOn
  AssessmentProject: MigrationAssessmentProject
  AssessmentProjectSummary.properties.lastAssessmentTimestamp: LastAssessedOn
  AssessmentProjectSummary: MigrationAssessmentProjectSummary
  AssessmentProjectUpdate.properties.assessmentSolutionId: -|arm-id
  AssessmentProjectUpdate.properties.customerWorkspaceId: -|arm-id
  AssessmentStage: MigrationAssessmentStage
  AssessmentStatus: MigrationAssessmentStatus
  AssessmentType: MigrationAssessmentType
  AvsAssessedMachine.properties.createdTimestamp: CreatedOn
  AvsAssessedMachine.properties.updatedTimestamp: UpdatedOn
  AvsAssessedMachine: MigrationAvsAssessedMachine
  AvsAssessment.properties.createdTimestamp: CreatedOn
  AvsAssessment.properties.pricesTimestamp: PricesQueriedOn
  AvsAssessment.properties.updatedTimestamp: UpdatedOn
  AvsAssessment: MigrationAvsAssessment
  AvsAssessmentOptions: MigrationAvsAssessmentOptions
  AvsSkuOptions: AssessmentAvsSkuConfig
  AzureAvsNodeType: AssessmentAvsNodeType
  AzureAvsNodeType.AV36: Av36
  AzureAvsSuitabilityExplanation: AvsSuitabilityExplanation
  AzureAvsVmSuitabilityDetail: AvsVmSuitabilityDetail
  AzureAvsVmSuitabilityExplanation: AvsVmSuitabilityExplanation
  AzureCurrency: AssessmentCurrency
  AzureDiskSize: AssessmentDiskSize
  AzureDiskSize.StandardSSD_E1: StandardSsdE1
  AzureDiskSize.StandardSSD_E10: StandardSsdE10
  AzureDiskSize.StandardSSD_E15: StandardSsdE15
  AzureDiskSize.StandardSSD_E2: StandardSsdE2
  AzureDiskSize.StandardSSD_E20: StandardSsdE20
  AzureDiskSize.StandardSSD_E3: StandardSsdE3
  AzureDiskSize.StandardSSD_E30: StandardSsdE30
  AzureDiskSize.StandardSSD_E4: StandardSsdE4
  AzureDiskSize.StandardSSD_E40: StandardSsdE40
  AzureDiskSize.StandardSSD_E50: StandardSsdE50
  AzureDiskSize.StandardSSD_E6: StandardSsdE6
  AzureDiskSize.StandardSSD_E60: StandardSsdE60
  AzureDiskSize.StandardSSD_E70: StandardSsdE70
  AzureDiskSize.StandardSSD_E80: StandardSsdE80
  AzureDiskSuitabilityDetail: AssessmentDiskSuitabilityDetail
  AzureDiskSuitabilityExplanation: AssessmentSuitabilityExplanation
  AzureDiskType: AssessmentDiskType
  AzureVmFamily:  AssessmentVmFamily
  AzureHybridUseBenefit: AssessmentHybridUseBenefit
  AzureManagedDiskSkuDTO: AssessmentManagedDiskSkuDTO
  AzureManagedDiskSkuDTODiskRedundancy: ManagedDiskSkuDTODiskRedundancy
  AzureManagedDiskSkuDTODiskType: ManagedDiskSkuDTODiskType
  AzureNetworkAdapterSuitabilityDetail: NetworkAdapterSuitabilityDetail
  AzureNetworkAdapterSuitabilityExplanation: NetworkAdapterSuitabilityExplanation
  AzureOfferCode: AssessmentOfferCode
  AzureOfferCode.MSAZR0003P: MSAZR0003P
  AzureOfferCode.MSAZR0022P: MSAZR0022P
  AzureOfferCode.MSAZR0023P: MSAZR0023P
  AzureOfferCode.MSAZR0025P: MSAZR0025P
  AzureOfferCode.MSAZR0029P: MSAZR0029P
  AzureOfferCode.MSAZR0036P: MSAZR0036P
  AzureOfferCode.MSAZR0044P: MSAZR0044P
  AzureOfferCode.MSAZR0059P: MSAZR0059P
  AzureOfferCode.MSAZR0060P: MSAZR0060P
  AzureOfferCode.MSAZR0062P: MSAZR0062P
  AzureOfferCode.MSAZR0063P: MSAZR0063P
  AzureOfferCode.MSAZR0064P: MSAZR0064P
  AzureOfferCode.MSAZR0111P: MSAZR0111P
  AzureOfferCode.MSAZR0120P: MSAZR0120P
  AzureOfferCode.MSAZR0121P: MSAZR0121P
  AzureOfferCode.MSAZR0122P: MSAZR0122P
  AzureOfferCode.MSAZR0123P: MSAZR0123P
  AzureOfferCode.MSAZR0124P: MSAZR0124P
  AzureOfferCode.MSAZR0125P: MSAZR0125P
  AzureOfferCode.MSAZR0126P: MSAZR0126P
  AzureOfferCode.MSAZR0127P: MSAZR0127P
  AzureOfferCode.MSAZR0128P: MSAZR0128P
  AzureOfferCode.MSAZR0129P: MSAZR0129P
  AzureOfferCode.MSAZR0130P: MSAZR0130P
  AzureOfferCode.MSAZR0144P: MSAZR0144P
  AzureOfferCode.MSAZR0148P: MSAZR0148P
  AzureOfferCode.MSAZR0149P: MSAZR0149P
  AzureOfferCode.MSAZR0243P: MSAZR0243P
  AzureOfferCode.MSAZRDE0003P: MSAZRDE0003P
  AzureOfferCode.MSAZRDE0044P: MSAZRDE0044P
  AzureOfferCode.MSAZRUSGOV0003P: MSAZRUSGOV0003P
  AzureOfferCode.MSMCAZR0044P: MSMCAZR0044P
  AzureOfferCode.MSMCAZR0059P: MSMCAZR0059P
  AzureOfferCode.MSMCAZR0060P: MSMCAZR0060P
  AzureOfferCode.MSMCAZR0063P: MSMCAZR0063P
  AzureOfferCode.MSMCAZR0120P: MSMCAZR0120P
  AzureOfferCode.MSMCAZR0121P: MSMCAZR0121P
  AzureOfferCode.MSMCAZR0125P: MSMCAZR0125P
  AzureOfferCode.MSMCAZR0128P: MSMCAZR0128P
  AzurePricingTier: AssessmentPricingTier
  AzureQuorumWitnessDTO: QuorumWitnessDTO
  AzureQuorumWitnessDTOQuorumWitnessType: QuorumWitnessDTOQuorumWitnessType
  AzureReservedInstance: AssessmentReservedInstance
  AzureSecurityOfferingType: AssessmentSecurityOfferingType
  AzureSecurityOfferingType.NO: No
  AzureSecurityOfferingType.MDC: Mdc
  AzureSqlDataBaseType: AssessmentSqlDataBaseType
  AzureSqlIaasSkuDTO: AssessmentAzureSqlIaasSkuDTO
  AzureSqlInstanceType: AssessmentSqlInstanceType
  AzureSqlPaasSkuDTO: AssessmentSqlPaasSkuDTO
  AzureSqlPurchaseModel: AssessmentSqlPurchaseModel
  AzureSqlPurchaseModel.DTU: Dtu
  AzureSqlServiceTier: AssessmentSqlServiceTier
  AzureStorageRedundancy: AssessmentStorageRedundancy
  AzureVirtualMachineSkuDTO: AssessmentVmSkuDTO
  AzureVmSize: AssessmentVmSize
  AzureVmSuitabilityDetail: AssessmentVmSuitabilityDetail
  AzureVmSuitabilityExplanation: AssessmentVmSuitabilityExplanation
  CollectorAgentPropertiesBase.lastHeartbeatUtc: LastHeartbeatOn
  CompatibilityLevel: AssessedDatabaseCompatibilityLevel
  CostComponent: AssessmentCostComponent
  CostComponentName: AssessmentCostComponentName
  DownloadUrl: AssessmentReportDownloadUri
  EntityUptime: AssessmentEntityUptime
  EnvironmentType: AssessmentEnvironmentType
  Error.updatedTimeStamp: UpdatedOn
  ErrorSummary: AssessmentErrorSummary
  Group.properties.createdTimestamp: CreatedOn
  Group.properties.updatedTimestamp: UpdatedOn
  GroupBodyProperties: MigrateGroupUpdateProperties
  GroupUpdateOperation: MigrateGroupUpdateOperationType
  HypervCollector.properties.createdTimestamp: CreatedOn
  HypervCollector.properties.updatedTimestamp: UpdatedOn
  ImportCollector.properties.createdTimestamp: CreatedOn
  ImportCollector.properties.updatedTimestamp: UpdatedOn
  Machine.properties.createdTimestamp: CreatedOn
  Machine.properties.updatedTimestamp: UpdatedOn
  MachineBootType.EFI: Efi
  MachineBootType: AssessedMachineBootType
  OptimizationLogic: SqlOptimizationLogic
  Percentile: PercentileOfUtilization
  ProcessorInfo: AssessedMachineProcessorInfo
  ProductSupportStatus: AssessmentProductSupportStatus
  ProjectStatus: AssessmentProjectStatus
  RecommendedSuitability: AssessedSqlRecommendedSuitability
  ServerCollector.properties.createdTimestamp: CreatedOn
  ServerCollector.properties.updatedTimestamp: UpdatedOn
  SqlAssessmentOptions: MigrationSqlAssessmentOptions
  SqlAssessmentV2.properties.createdTimestamp: CreatedOn
  SqlAssessmentV2.properties.enableHadrAssessment: IsHadrAssessmentEnabled
  SqlAssessmentV2.properties.pricesTimestamp: PricesQueriedOn
  SqlAssessmentV2.properties.updatedTimestamp: UpdatedOn
  SqlAssessmentV2: MigrationSqlAssessmentV2
  SqlAssessmentV2IaasSuitabilityData: SqlAssessmentV2IaasSuitabilityDetails
  SqlAssessmentV2PaasSuitabilityData: SqlAssessmentV2PaasSuitabilityDetails
  SqlAssessmentV2Summary: MigrationSqlAssessmentV2Summary
  SqlAssessmentV2SummaryData: SqlAssessmentV2SummaryDetails
  SqlCollector.properties.createdTimestamp: CreatedOn
  SqlCollector.properties.updatedTimestamp: UpdatedOn
  SqlDbSettings: AssessmentSqlDbSettings
  SqlFCIMetadata: AssessmentSqlFciMetadata
  SqlFCIMetadataState: AssessmentSqlFciMetadataState
  SqlFCIState: AssessmentSqlFciState
  SqlMiSettings: AssessmentSqlMISettings
  SqlMigrationGuidelineCategory.FailoverCluterInstanceGuideLine: FailoverCluterInstanceGuideLine
  SqlPaaSTargetOptions: SqlPaasTargetConfig
  SqlServerLicense: AssessmentSqlServerLicense
  SqlVmSettings: AssessmentSqlVmSettings
  TimeRange: AssessmentTimeRange
  UltraDiskAssessmentOptions: UltraDiskAssessmentConfig
  UpdateGroupBody: MigrateGroupUpdateContent
  VmFamilyOptions: AssessmentVmFamilyConfig
  VmUptime: AssessmentVmUptime
  VmwareCollector.properties.createdTimestamp: CreatedOn
  VmwareCollector.properties.updatedTimestamp: UpdatedOn
  WorkloadSummary: AssessmentWorkloadSummary

prepend-rp-prefix:
  # Correct the violations of the naming rules
  - Group
  - HypervCollector
  - ImportCollector
  - Machine
  - ServerCollector
  - SqlCollector
  - VmwareCollector
  - CloudSuitability
  - ComputeTier
  - Disk
  - Error
  - GroupStatus
  - GroupType
  - HardwareGeneration
  - NetworkAdapter
  - OsLicense
  - ProvisioningState
  - TargetType
  - TimeRange

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*ArmId': 'arm-id'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
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
  Vmware: VMware
  Hyperv: HyperV
  DTO: Dto
  SSD: Ssd
  Db: DB
  SqlMi: SqlMI
  Ea: EA
  LRS: Lrs
  ZRS: Zrs

directive:
  # Use double instead of float for all properties
  - from: migrate.json
    where: $.definitions..[?(@.format === 'float')]
    transform: >
      $.format = 'double'
  # Correct the AzureLocation refs
  - from: migrate.json
    where: $.definitions
    transform: >
      delete $.AvsAssessmentOptionsProperties.properties.reservedInstanceSupportedLocations.items['$ref'];
      $.AvsAssessmentOptionsProperties.properties.reservedInstanceSupportedLocations.items['type'] = 'string';
      $.AvsAssessmentOptionsProperties.properties.reservedInstanceSupportedLocations.items['x-ms-format'] = 'azure-location';
      delete $.AvsAssessmentProperties.properties.azureLocation['$ref'];
      $.AvsAssessmentProperties.properties.azureLocation['type'] = 'string';
      $.AvsAssessmentProperties.properties.azureLocation['x-ms-format'] = 'azure-location';
      delete $.AvsSkuOptions.properties.targetLocations.items['$ref'];
      $.AvsSkuOptions.properties.targetLocations.items['type'] = 'string';
      $.AvsSkuOptions.properties.targetLocations.items['x-ms-format'] = 'azure-location';
      $.MachineAssessmentProperties.properties.azureLocation['x-ms-format'] = 'azure-location';
      $.SqlAssessmentV2Properties.properties.azureLocation['x-ms-format'] = 'azure-location';
      delete $.SqlAssessmentOptionsProperties.properties.savingsPlanSupportedLocations.items['$ref'];
      $.SqlAssessmentOptionsProperties.properties.savingsPlanSupportedLocations.items['type'] = 'string';
      $.SqlAssessmentOptionsProperties.properties.savingsPlanSupportedLocations.items['x-ms-format'] = 'azure-location';
      delete $.SqlAssessmentOptionsProperties.properties.savingsPlanSupportedLocationsForPaas.items['$ref'];
      $.SqlAssessmentOptionsProperties.properties.savingsPlanSupportedLocationsForPaas.items['type'] = 'string';
      $.SqlAssessmentOptionsProperties.properties.savingsPlanSupportedLocationsForPaas.items['x-ms-format'] = 'azure-location';
      delete $.SqlAssessmentOptionsProperties.properties.reservedInstanceSupportedLocationsForIaas.items['$ref'];
      $.SqlAssessmentOptionsProperties.properties.reservedInstanceSupportedLocationsForIaas.items['type'] = 'string';
      $.SqlAssessmentOptionsProperties.properties.reservedInstanceSupportedLocationsForIaas.items['x-ms-format'] = 'azure-location';
      delete $.SqlAssessmentOptionsProperties.properties.reservedInstanceSupportedLocations.items['$ref'];
      $.SqlAssessmentOptionsProperties.properties.reservedInstanceSupportedLocations.items['type'] = 'string';
      $.SqlAssessmentOptionsProperties.properties.reservedInstanceSupportedLocations.items['x-ms-format'] = 'azure-location';
      delete $.SqlAssessmentV2Properties.properties.disasterRecoveryLocation['$ref'];
      $.SqlAssessmentV2Properties.properties.disasterRecoveryLocation['type'] = 'string';
      $.SqlAssessmentV2Properties.properties.disasterRecoveryLocation['x-ms-format'] = 'azure-location';
      delete $.SqlPaaSTargetOptions.properties.targetLocations.items['$ref'];
      $.SqlPaaSTargetOptions.properties.targetLocations.items['type'] = 'string';
      $.SqlPaaSTargetOptions.properties.targetLocations.items['x-ms-format'] = 'azure-location';
```
