# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataProtectionBackup
namespace: Azure.ResourceManager.DataProtectionBackup
require: https://github.com/Azure/azure-rest-api-specs/blob/34499b0aa7b61a0e96a37d28aa282c9d2c345122/specification/dataprotection/resource-manager/Microsoft.DataProtection/DataProtection/readme.md
#tag: package-2025-07-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

# mgmt-debug:
#  show-serialized-names: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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
  ETag: ETag|eTag
  PIN: Pin

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}/deleteProtectedItemRequests/{requestName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}/deleteResourceGuardProxyRequests/{requestName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}/disableSoftDeleteRequests/{requestName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}/getBackupSecurityPINRequests/{requestName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}/updateProtectedItemRequests/{requestName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataProtection/resourceGuards/{resourceGuardsName}/updateProtectionPolicyRequests/{requestName}

override-operation-name:
  BackupInstances_AdhocBackup: TriggerAdhocBackup
  RestorableTimeRanges_Find: FindRestorableTimeRange
  BackupInstances_TriggerRehydrate: TriggerRehydration
  BackupInstances_ValidateForRestore: ValidateRestore
  BackupInstances_ValidateForBackup: ValidateAdhocBackup
  ResourceGuards_GetDefaultDeleteProtectedItemRequestsObject: GetDeleteProtectedItemObject
  ResourceGuards_GetDeleteProtectedItemRequestsObjects: GetDeleteProtectedItemObjects
  ResourceGuards_GetDefaultDeleteResourceGuardProxyRequestsObject: GetDeleteResourceGuardProxyObject
  ResourceGuards_GetDeleteResourceGuardProxyRequestsObjects: GetDeleteResourceGuardProxyObjects
  ResourceGuards_GetDefaultDisableSoftDeleteRequestsObject: GetDisableSoftDeleteObject
  ResourceGuards_GetDisableSoftDeleteRequestsObjects: GetDisableSoftDeleteObjects
  ResourceGuards_GetDefaultBackupSecurityPinRequestsObject: GetBackupSecurityPinObject
  ResourceGuards_GetBackupSecurityPinRequestsObjects: GetBackupSecurityPinObjects
  ResourceGuards_GetDefaultUpdateProtectedItemRequestsObject: GetUpdateProtectedItemObject
  ResourceGuards_GetUpdateProtectedItemRequestsObjects: GetUpdateProtectedItemObjects
  ResourceGuards_GetDefaultUpdateProtectionPolicyRequestsObject: GetUpdateProtectionPolicyObject
  ResourceGuards_GetUpdateProtectionPolicyRequestsObjects: GetUpdateProtectionPolicyObjects
  DataProtection_CheckFeatureSupport: CheckDataProtectionBackupFeatureSupport
  BackupVaults_CheckNameAvailability: CheckDataProtectionBackupVaultNameAvailability
  FetchCrossRegionRestoreJob_Get: GetCrossRegionRestoreJob
  FetchCrossRegionRestoreJobs_List: GetCrossRegionRestoreJobs
  FetchSecondaryRecoveryPoints_List: GetSecondaryRecoveryPoints

rename-mapping:
  AbsoluteDeleteOption: DataProtectionBackupAbsoluteDeleteSetting
  AbsoluteMarker: BackupAbsoluteMarker
  AdHocBackupRuleOptions: AdhocBackupRules
  AdHocBackupRuleOptions.triggerOption: BackupTrigger
  AdhocBackupTriggerOption: AdhocBackupTriggerSetting
  AdhocBasedTaggingCriteria: AdhocBasedBackupTaggingCriteria
  AdhocBasedTriggerContext: AdhocBasedBackupTriggerContext
  AdhocBasedTriggerContext.taggingCriteria: AdhocBackupRetention
  AdlsBlobBackupDatasourceParameters: AdlsBlobBackupDataSourceSettings
  AKSVolumeTypes: DataProtectionAksVolumeType
  AlertsState: AzureMonitorAlertsState
  AuthCredentials: DataProtectionBackupAuthCredentials
  AzureBackupDiscreteRecoveryPoint: DataProtectionBackupDiscreteRecoveryPointProperties
  AzureBackupDiscreteRecoveryPoint.expiryTime: ExpireOn
  AzureBackupDiscreteRecoveryPoint.recoveryPointTime: RecoverOn
  AzureBackupFindRestorableTimeRangesRequest: BackupFindRestorableTimeRangeContent
  AzureBackupFindRestorableTimeRangesRequest.endTime: EndOn|date-time
  AzureBackupFindRestorableTimeRangesRequest.startTime: StartOn|date-time
  AzureBackupFindRestorableTimeRangesResponse: BackupFindRestorableTimeRangeResultProperties
  AzureBackupFindRestorableTimeRangesResponseResource: BackupFindRestorableTimeRangeResult
  AzureBackupJob: DataProtectionBackupJobProperties
  AzureBackupJob.backupInstanceId: -|arm-id
  AzureBackupJob.dataSourceId: -|arm-id
  AzureBackupJob.dataSourceLocation: -|azure-location
  AzureBackupJob.duration: -|duration-constant
  AzureBackupJob.policyId: -|arm-id
  AzureBackupJob.progressEnabled: IsProgressEnabled
  AzureBackupJobResource: DataProtectionBackupJob
  AzureBackupParams: DataProtectionBackupSettings
  AzureBackupRecoveryPoint: DataProtectionBackupRecoveryPointProperties
  AzureBackupRecoveryPointBasedRestoreRequest: BackupRecoveryPointBasedRestoreContent
  AzureBackupRecoveryPointResource: DataProtectionBackupRecoveryPoint
  AzureBackupRecoveryTimeBasedRestoreRequest: BackupRecoveryTimeBasedRestoreContent
  AzureBackupRecoveryTimeBasedRestoreRequest.recoveryPointTime: RecoverOn|date-time
  AzureBackupRehydrationRequest: BackupRehydrationContent
  AzureBackupRehydrationRequest.rehydrationRetentionDuration: -|duration
  AzureBackupRestoreRequest: BackupRestoreContent
  AzureBackupRestoreRequest.sourceResourceId: -|arm-id
  AzureBackupRestoreWithRehydrationRequest: BackupRestoreWithRehydrationContent
  AzureBackupRestoreWithRehydrationRequest.rehydrationRetentionDuration: -|duration
  AzureBackupRule: DataProtectionBackupRule
  AzureMonitorAlertSettings.alertsForAllJobFailures: AlertSettingsForAllJobFailures
  AzureOperationalStoreParameters: OperationalDataStoreSettings
  AzureOperationalStoreParameters.resourceGroupId: -|arm-id
  AzureRetentionRule: DataProtectionRetentionRule
  BackupCriteria: DataProtectionBackupCriteria
  BackupDatasourceParameters: BackupDataSourceSettings
  BackupInstance: DataProtectionBackupInstanceProperties
  BackupInstance.datasourceAuthCredentials: DataSourceAuthCredentials
  BackupInstanceResource: DataProtectionBackupInstance
  BackupParameters: DataProtectionBackupSettingsBase
  BackupPolicy: RuleBasedBackupPolicy
  BackupSchedule: DataProtectionBackupSchedule
  BackupVault: DataProtectionBackupVaultProperties
  BackupVault.replicatedRegions : -|azure-location
  BackupVaultResource: DataProtectionBackupVault
  BaseBackupPolicy: DataProtectionBackupPolicyPropertiesBase
  BaseBackupPolicy.datasourceTypes: DataSourceTypes
  BaseBackupPolicyResource: DataProtectionBackupPolicy
  BasePolicyRule: DataProtectionBasePolicyRule
  BlobBackupDatasourceParameters: BlobBackupDataSourceSettings
  CheckNameAvailabilityRequest: DataProtectionBackupNameAvailabilityContent
  CheckNameAvailabilityRequest.type: -|resource-type
  CheckNameAvailabilityResult: DataProtectionBackupNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  ClientDiscoveryForLogSpecification.blobDuration: -|duration
  CmkKekIdentity: BackupVaultCmkKekIdentity
  CopyOnExpiryOption: CopyOnExpirySetting
  CopyOption: DataProtectionBackupCopySetting
  CrossRegionRestoreDetails.sourceBackupInstanceId : -|arm-id
  CrossRegionRestoreDetails.sourceRegion  : -|azure-location
  CrossRegionRestoreJobRequest.jobId : -|uuid
  CrossRegionRestoreJobRequest.sourceBackupVaultId : -|arm-id
  CrossRegionRestoreJobRequest.sourceRegion  : -|azure-location
  CrossRegionRestoreJobsRequest.sourceBackupVaultId : -|arm-id
  CrossRegionRestoreJobsRequest.sourceRegion  : -|azure-location
  CrossSubscriptionRestoreState: DataProtectionBackupCrossSubscriptionRestoreState
  CustomCopyOption: CustomCopySetting
  CustomCopyOption.duration: -|duration
  Datasource: DataSourceInfo
  Datasource.datasourceType: DataSourceType
  Datasource.resourceID: -|arm-id
  Datasource.resourceLocation: -|azure-location
  Datasource.resourceType: -|resource-type
  Datasource.resourceUri: ResourceUriString
  DatasourceSet: DataSourceSetInfo
  DatasourceSet.datasourceType: DataSourceType
  DatasourceSet.resourceID: -|arm-id
  DatasourceSet.resourceLocation: -|azure-location
  DatasourceSet.resourceType: -|resource-type
  DatasourceSet.resourceUri: ResourceUriString
  DataStoreParameters: DataStoreSettings
  Day: DataProtectionBackupDay
  DayOfWeek: DataProtectionBackupDayOfWeek
  DeletedBackupInstance: DeletedDataProtectionBackupInstanceProperties
  DeletedBackupInstanceResource: DeletedDataProtectionBackupInstance
  DeleteOption: DataProtectionBackupDeleteSetting
  DeleteOption.duration: -|duration
  DeletionInfo: BackupInstanceDeletionInfo
  DeletionInfo.billingEndDate: BillingEndOn|date-time
  DeletionInfo.deletionTime: DeleteOn|date-time
  DeletionInfo.scheduledPurgeTime: ScheduledPurgeOn|date-time
  EncryptionSettings: BackupVaultEncryptionSettings
  EncryptionState: BackupVaultEncryptionState
  ExistingResourcePolicy: KubernetesClusterRestoreExistingResourcePolicy
  FeatureSettings: BackupVaultFeatureSettings
  FeatureType: BackupSupportedFeatureType
  FeatureValidationRequest: BackupFeatureValidationContent
  FeatureValidationRequestBase: BackupFeatureValidationContentBase
  FeatureValidationResponse: BackupFeatureValidationResult
  FeatureValidationResponseBase: BackupFeatureValidationResultBase
  FetchSecondaryRPsRequestParameters.sourceBackupInstanceId : -|arm-id
  FetchSecondaryRPsRequestParameters.sourceRegion  : -|azure-location
  IdentityDetails: DataProtectionIdentityDetails
  IdentityDetails.userAssignedIdentityArmUrl: UserAssignedIdentityId|arm-id
  IdentityType: BackupVaultCmkKekIdentityType
  ImmediateCopyOption: ImmediateCopySetting
  ImmutabilityState: BackupVaultImmutabilityState
  InfrastructureEncryptionState: BackupVaultInfrastructureEncryptionState
  JobExtendedInfo: BackupJobExtendedInfo
  JobSubTask: BackupJobSubTask
  KubernetesClusterBackupDatasourceParameters: KubernetesClusterBackupDataSourceSettings
  KubernetesClusterBackupDatasourceParameters.includeClusterScopeResources: IsClusterScopeResourcesIncluded
  KubernetesClusterBackupDatasourceParameters.snapshotVolumes: IsSnapshotVolumesEnabled
  KubernetesClusterRestoreCriteria.includeClusterScopeResources: IsClusterScopeResourcesIncluded
  Month: DataProtectionBackupMonth
  NamespacedNameResource: NamespacedName
  OperationExtendedInfo: DataProtectionOperationExtendedInfo
  OperationJobExtendedInfo: DataProtectionOperationJobExtendedInfo
  OperationJobExtendedInfo.jobId: JobIdentifier
  PatchBackupVaultInput: DataProtectionBackupVaultPatchProperties
  PolicyInfo: BackupInstancePolicyInfo
  PolicyInfo.policyId: -|arm-id
  PolicyParameters: BackupInstancePolicySettings
  PolicyParameters.backupDatasourceParametersList: BackupDataSourceParametersList
  ProtectionStatusDetails: BackupInstanceProtectionStatusDetails
  ProvisioningState: DataProtectionBackupProvisioningState
  RecoveryOption: RecoverySetting
  RecoveryPointCompletionState: DataProtectionBackupRecoveryPointCompletionState
  RecoveryPointDataStoreDetails: RecoveryPointDataStoreDetail
  RecoveryPointDataStoreDetails.expiryTime: ExpireOn
  RecoveryPointDataStoreDetails.id: RecoveryPointDataStoreId|uuid
  RecoveryPointDataStoreDetails.metaData: Metadata
  RecoveryPointDataStoreDetails.rehydrationExpiryTime: RehydrationExpireOn
  RecoveryPointDataStoreDetails.type: RecoveryPointDataStoreType
  RecoveryPointDataStoreDetails.visible: IsVisible
  RehydrationPriority: BackupRehydrationPriority
  RehydrationStatus: RecoveryPointDataStoreRehydrationStatus
  RehydrationStatus.CREATE_IN_PROGRESS: CreateInProgress
  RehydrationStatus.DELETE_IN_PROGRESS: DeleteInProgress
  ResourceGuard: ResourceGuardProperties
  ResourceGuard.allowAutoApprovals: IsAutoApprovalsAllowed
  ResourceGuardOperation: ResourceGuardOperationDetails
  ResourceGuardOperation.requestResourceType: -|resource-type
  ResourceGuardResource: ResourceGuard
  ResourceMoveDetails: BackupVaultResourceMoveDetails
  ResourceMoveDetails.completionTimeUtc: CompleteOn|date-time
  ResourceMoveDetails.startTimeUtc: StartOn|date-time
  ResourceMoveState: BackupVaultResourceMoveState
  ResourceMoveState.CommitTimedout: CommitTimedOut
  ResourceMoveState.PrepareTimedout: PrepareTimedOut
  RestorableTimeRange.endTime: EndOn|date-time
  RestorableTimeRange.startTime: StartOn|date-time
  RestoreJobRecoveryPointDetails.recoveryPointTime: RecoverOn
  RestoreTargetInfo.datasourceAuthCredentials: DataSourceAuthCredentials
  RestoreTargetInfo.datasourceInfo: DataSourceInfo
  RestoreTargetInfo.datasourceSetInfo: DataSourceSetInfo
  RestoreTargetInfoBase.recoveryOption: RecoverySetting
  RestoreTargetInfoBase.restoreLocation: -|azure-location
  RetentionTag: DataProtectionBackupRetentionTag
  ScheduleBasedBackupCriteria.daysOfTheWeek: DaysOfWeek
  ScheduleBasedBackupCriteria.weeksOfTheMonth: WeeksOfMonth
  ScheduleBasedTriggerContext: ScheduleBasedBackupTriggerContext
  ScheduleBasedTriggerContext.taggingCriteria: TaggingCriteriaList
  SecretStoreResource: SecretStoreResourceInfo
  SecureScoreLevel: BackupVaultSecureScoreLevel
  SecuritySettings: BackupVaultSecuritySettings
  SoftDeleteSettings: BackupVaultSoftDeleteSettings
  SoftDeleteState: BackupVaultSoftDeleteState
  Status: BackupInstanceProtectionStatus
  StorageSetting: DataProtectionBackupStorageSetting
  StorageSetting.datastoreType: DataStoreType
  SupportedFeature: BackupSupportedFeature
  SyncBackupInstanceRequest: BackupInstanceSyncContent
  SyncType: BackupInstanceSyncType
  TaggingCriteria: DataProtectionBackupTaggingCriteria
  TargetDetails: RestoreFilesTargetDetails
  TargetDetails.targetResourceArmId: -|arm-id
  TriggerBackupRequest: AdhocBackupTriggerContent
  TriggerBackupRequest.backupRuleOptions: BackupRules
  TriggerContext: DataProtectionBackupTriggerContext
  UnlockDeleteRequest: DataProtectionUnlockDeleteContent
  UnlockDeleteResponse: DataProtectionUnlockDeleteResult
  ValidateForBackupRequest: AdhocBackupValidateContent
  ValidateRestoreRequestObject: BackupValidateRestoreContent
  ValidationType: BackupValidationType
  WeekNumber: DataProtectionBackupWeekNumber

directive:
# Remove all the operation related methods
  - remove-operation: OperationResult_Get
  - remove-operation: OperationStatus_Get
  - remove-operation: OperationStatusBackupVaultContext_Get
  - remove-operation: OperationStatusResourceGroupContext_Get
  - remove-operation: BackupVaultOperationResults_Get
  - remove-operation: DataProtectionOperations_List
  - remove-operation: BackupInstances_GetBackupInstanceOperationResult
  - remove-operation: ExportJobsOperationResult_Get
# Enable the x-ms-skip-url-encoding extension for {resourceId} (Comment out as this parameter doesn't exist in this stable API version)
#  - from: dataprotection.json
#    where: $.parameters
#    transform: >
#      $.ResourceId['x-ms-skip-url-encoding'] = true;
# Work around the issue https://github.com/Azure/autorest.csharp/issues/2740
  - from: dataprotection.json
    where: $.definitions
    transform: >
      delete $.BackupVaultResourceList.allOf;
      $.BackupVaultResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.AzureBackupJobResourceList.allOf;
      $.AzureBackupJobResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.AzureBackupRecoveryPointResourceList.allOf;
      $.AzureBackupRecoveryPointResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.BackupInstanceResourceList.allOf;
      $.BackupInstanceResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.BaseBackupPolicyResourceList.allOf;
      $.BaseBackupPolicyResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
      delete $.ResourceGuardResourceList.allOf;
      $.ResourceGuardResourceList.properties.nextLink = {
          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
          "type": "string"
      };
#      delete $.ResourceGuardProxyBaseResourceList.allOf;
#      $.ResourceGuardProxyBaseResourceList.properties.nextLink = {
#          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
#          "type": "string"
#      };
#      delete $.DeletedBackupInstanceResourceList.allOf;
#      $.DeletedBackupInstanceResourceList.properties.nextLink = {
#          "description": "The uri to fetch the next page of resources. Call ListNext() fetches next page of resources.",
#          "type": "string"
#      };
# Ensure the data model inherits from ResourceData
  - from: dataprotection.json
    where: $.definitions
    transform: >
      $.DppBaseResource = {
        "x-ms-client-name": "ResourceGuardProtectedObjectData",
        "type": "object",
        "description": "Base resource under Microsoft.DataProtection provider namespace",
        "allOf": [
          {
            "$ref": "#/definitions/ResourceData"
          }
        ]
      };
      $.ResourceData = {
        "type": "object",
        "properties": {
          "id": {
            "description": "Resource Id represents the complete path to the resource.",
            "type": "string",
            "readOnly": true
          },
          "name": {
            "description": "Resource name associated with the resource.",
            "type": "string",
            "readOnly": true
          },
          "type": {
            "description": "Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...",
            "type": "string",
            "readOnly": true
          }
        }
      };
# rename the body parameter
  - from: dataprotection.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/providers/Microsoft.DataProtection/locations/{location}/checkFeatureSupport'].post.parameters[3]['x-ms-client-name'] = 'content';
# revert the format change of SubscriptionIdParameter in common type V4 to avoid breaking changes
  - from: types.json
    where: $.parameters
    transform: >
      delete $.SubscriptionIdParameter.format;
```
