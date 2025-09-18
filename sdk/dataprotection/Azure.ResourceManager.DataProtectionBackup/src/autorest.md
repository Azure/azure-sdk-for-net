# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataProtectionBackup
namespace: Azure.ResourceManager.DataProtectionBackup
require: https://github.com/Azure/azure-rest-api-specs/blob/b8fbdcc1e60dc013870988ef563014a07e9c7f47/specification/dataprotection/resource-manager/readme.md
#tag: package-2025-07
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
  AzureBackupJobResource: DataProtectionBackupJob
  AzureBackupJob: DataProtectionBackupJobProperties
  AzureBackupJob.duration: -|duration-constant
  AzureBackupJob.backupInstanceId: -|arm-id
  AzureBackupJob.dataSourceId: -|arm-id
  AzureBackupJob.dataSourceLocation: -|azure-location
  AzureBackupJob.policyId: -|arm-id
  AzureBackupJob.progressEnabled: IsProgressEnabled
  JobExtendedInfo: BackupJobExtendedInfo
  JobSubTask: BackupJobSubTask
  AzureBackupRecoveryPointResource: DataProtectionBackupRecoveryPoint
  AzureBackupRecoveryPoint: DataProtectionBackupRecoveryPointProperties
  AzureBackupDiscreteRecoveryPoint: DataProtectionBackupDiscreteRecoveryPointProperties
  AzureBackupDiscreteRecoveryPoint.recoveryPointTime: RecoverOn
  AzureBackupDiscreteRecoveryPoint.expiryTime: ExpireOn
  BackupInstanceResource: DataProtectionBackupInstance
  BackupInstance: DataProtectionBackupInstanceProperties
  BackupInstance.datasourceAuthCredentials: DataSourceAuthCredentials
  TriggerBackupRequest: AdhocBackupTriggerContent
  TriggerBackupRequest.backupRuleOptions: BackupRules
  OperationExtendedInfo: DataProtectionOperationExtendedInfo
  OperationJobExtendedInfo: DataProtectionOperationJobExtendedInfo
  OperationJobExtendedInfo.jobId: JobIdentifier
  AzureBackupFindRestorableTimeRangesRequest: BackupFindRestorableTimeRangeContent
  AzureBackupFindRestorableTimeRangesRequest.startTime: StartOn|date-time
  AzureBackupFindRestorableTimeRangesRequest.endTime: EndOn|date-time
  AzureBackupFindRestorableTimeRangesResponseResource: BackupFindRestorableTimeRangeResult
  AzureBackupFindRestorableTimeRangesResponse: BackupFindRestorableTimeRangeResultProperties
  RestorableTimeRange.startTime: StartOn|date-time
  RestorableTimeRange.endTime: EndOn|date-time
  SyncBackupInstanceRequest: BackupInstanceSyncContent
  AzureBackupRehydrationRequest: BackupRehydrationContent
  AzureBackupRestoreRequest: BackupRestoreContent
  AzureBackupRestoreRequest.sourceResourceId: -|arm-id
  AzureBackupRecoveryPointBasedRestoreRequest: BackupRecoveryPointBasedRestoreContent
  AzureBackupRestoreWithRehydrationRequest: BackupRestoreWithRehydrationContent
  AzureBackupRecoveryTimeBasedRestoreRequest: BackupRecoveryTimeBasedRestoreContent
  AzureBackupRecoveryTimeBasedRestoreRequest.recoveryPointTime: RecoverOn|date-time
  ValidateRestoreRequestObject: BackupValidateRestoreContent
  BackupVaultResource: DataProtectionBackupVault
  BackupVault: DataProtectionBackupVaultProperties
  ValidateForBackupRequest: AdhocBackupValidateContent
  BaseBackupPolicyResource: DataProtectionBackupPolicy
  BaseBackupPolicy: DataProtectionBackupPolicyPropertiesBase
  BaseBackupPolicy.datasourceTypes: DataSourceTypes
  BackupPolicy: RuleBasedBackupPolicy
  ResourceGuardResource: ResourceGuard
  ResourceGuard: ResourceGuardProperties
  ResourceGuard.allowAutoApprovals: IsAutoApprovalsAllowed
  FeatureValidationRequestBase: BackupFeatureValidationContentBase
  FeatureValidationRequest: BackupFeatureValidationContent
  FeatureValidationResponseBase: BackupFeatureValidationResultBase
  FeatureValidationResponse: BackupFeatureValidationResult
  CheckNameAvailabilityRequest: DataProtectionBackupNameAvailabilityContent
  CheckNameAvailabilityRequest.type: -|resource-type
  CheckNameAvailabilityResult: DataProtectionBackupNameAvailabilityResult
  CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
  AdHocBackupRuleOptions: AdhocBackupRules
  AdHocBackupRuleOptions.triggerOption: BackupTrigger
  AdhocBackupTriggerOption: AdhocBackupTriggerSetting
  DeleteOption: DataProtectionBackupDeleteSetting
  AbsoluteDeleteOption: DataProtectionBackupAbsoluteDeleteSetting
  AbsoluteMarker: BackupAbsoluteMarker
  AdhocBasedTaggingCriteria: AdhocBasedBackupTaggingCriteria
  RetentionTag: DataProtectionBackupRetentionTag
  TaggingCriteria: DataProtectionBackupTaggingCriteria
  TriggerContext: DataProtectionBackupTriggerContext
  AdhocBasedTriggerContext: AdhocBasedBackupTriggerContext
  AdhocBasedTriggerContext.taggingCriteria: AdhocBackupRetention
  ScheduleBasedTriggerContext: ScheduleBasedBackupTriggerContext
  ScheduleBasedTriggerContext.taggingCriteria: TaggingCriteriaList
  AlertsState: AzureMonitorAlertsState
  AuthCredentials: DataProtectionBackupAuthCredentials
  RecoveryPointDataStoreDetails: RecoveryPointDataStoreDetail
  RecoveryPointDataStoreDetails.expiryTime: ExpireOn
  RecoveryPointDataStoreDetails.rehydrationExpiryTime: RehydrationExpireOn
  RecoveryPointDataStoreDetails.metaData: Metadata
  RecoveryPointDataStoreDetails.id: RecoveryPointDataStoreId|uuid
  RecoveryPointDataStoreDetails.type: RecoveryPointDataStoreType
  RecoveryPointDataStoreDetails.visible: IsVisible
  BackupParameters: DataProtectionBackupSettingsBase
  AzureBackupParams: DataProtectionBackupSettings
  RehydrationPriority: BackupRehydrationPriority
  BasePolicyRule: DataProtectionBasePolicyRule
  AzureBackupRule: DataProtectionBackupRule
  AzureRetentionRule: DataProtectionRetentionRule
  DataStoreParameters: DataStoreSettings
  AzureOperationalStoreParameters: OperationalDataStoreSettings
  AzureOperationalStoreParameters.resourceGroupId: -|arm-id
  BackupCriteria: DataProtectionBackupCriteria
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
  PolicyInfo: BackupInstancePolicyInfo
  PolicyInfo.policyId: -|arm-id
  ValidationType: BackupValidationType
  BackupSchedule: DataProtectionBackupSchedule
  AzureMonitorAlertSettings.alertsForAllJobFailures: AlertSettingsForAllJobFailures
  ProvisioningState: DataProtectionBackupProvisioningState
  ResourceMoveDetails: BackupVaultResourceMoveDetails
  ResourceMoveDetails.startTimeUtc: StartOn|date-time
  ResourceMoveDetails.completionTimeUtc: CompleteOn|date-time
  ResourceMoveState: BackupVaultResourceMoveState
  ResourceMoveState.PrepareTimedout: PrepareTimedOut
  ResourceMoveState.CommitTimedout: CommitTimedOut
  StorageSetting: DataProtectionBackupStorageSetting
  StorageSetting.datastoreType: DataStoreType
  CopyOption: DataProtectionBackupCopySetting
  CopyOnExpiryOption: CopyOnExpirySetting
  CustomCopyOption: CustomCopySetting
  ImmediateCopyOption: ImmediateCopySetting
  Day: DataProtectionBackupDay
  DayOfWeek: DataProtectionBackupDayOfWeek
  Month: DataProtectionBackupMonth
  WeekNumber: DataProtectionBackupWeekNumber
  FeatureType: BackupSupportedFeatureType
  SupportedFeature: BackupSupportedFeature
  ProtectionStatusDetails: BackupInstanceProtectionStatusDetails
  Status: BackupInstanceProtectionStatus
  RecoveryOption: RecoverySetting
  RehydrationStatus: RecoveryPointDataStoreRehydrationStatus
  RehydrationStatus.CREATE_IN_PROGRESS: CreateInProgress
  RehydrationStatus.DELETE_IN_PROGRESS: DeleteInProgress
  ResourceGuardOperation: ResourceGuardOperationDetails
  ResourceGuardOperation.requestResourceType: -|resource-type
  TargetDetails: RestoreFilesTargetDetails
  TargetDetails.targetResourceArmId: -|arm-id
  RestoreJobRecoveryPointDetails.recoveryPointTime: RecoverOn
  RestoreTargetInfo.datasourceInfo: DataSourceInfo
  RestoreTargetInfo.datasourceSetInfo: DataSourceSetInfo
  RestoreTargetInfo.datasourceAuthCredentials: DataSourceAuthCredentials
  RestoreTargetInfoBase.restoreLocation: -|azure-location
  RestoreTargetInfoBase.recoveryOption: RecoverySetting
  SecretStoreResource: SecretStoreResourceInfo
  SyncType: BackupInstanceSyncType
  ScheduleBasedBackupCriteria.daysOfTheWeek: DaysOfWeek
  ScheduleBasedBackupCriteria.weeksOfTheMonth: WeeksOfMonth
  DeletedBackupInstanceResource: DeletedDataProtectionBackupInstance
  DeletedBackupInstance: DeletedDataProtectionBackupInstanceProperties
  BackupDatasourceParameters: BackupDataSourceSettings
  BlobBackupDatasourceParameters: BlobBackupDataSourceSettings
  AdlsBlobBackupDatasourceParameters: AdlsBlobBackupDataSourceSettings
  KubernetesClusterBackupDatasourceParameters: KubernetesClusterBackupDataSourceSettings
  KubernetesClusterBackupDatasourceParameters.snapshotVolumes: IsSnapshotVolumesEnabled
  KubernetesClusterBackupDatasourceParameters.includeClusterScopeResources: IsClusterScopeResourcesIncluded
  KubernetesClusterRestoreCriteria.includeClusterScopeResources: IsClusterScopeResourcesIncluded
  CrossSubscriptionRestoreState: DataProtectionBackupCrossSubscriptionRestoreState
  DeletionInfo: BackupInstanceDeletionInfo
  DeletionInfo.deletionTime: DeleteOn|date-time
  DeletionInfo.billingEndDate: BillingEndOn|date-time
  DeletionInfo.scheduledPurgeTime: ScheduledPurgeOn|date-time
  ExistingResourcePolicy: KubernetesClusterRestoreExistingResourcePolicy
  ImmutabilityState: BackupVaultImmutabilityState
  PatchBackupVaultInput: DataProtectionBackupVaultPatchProperties
  PolicyParameters: BackupInstancePolicySettings
  PolicyParameters.backupDatasourceParametersList: BackupDataSourceParametersList
  SecuritySettings: BackupVaultSecuritySettings
  SoftDeleteSettings: BackupVaultSoftDeleteSettings
  SoftDeleteState: BackupVaultSoftDeleteState
  UnlockDeleteRequest: DataProtectionUnlockDeleteContent
  UnlockDeleteResponse: DataProtectionUnlockDeleteResult
  SecureScoreLevel: BackupVaultSecureScoreLevel
  FeatureSettings: BackupVaultFeatureSettings
  IdentityDetails: DataProtectionIdentityDetails
  IdentityDetails.userAssignedIdentityArmUrl: UserAssignedIdentityId|arm-id
  NamespacedNameResource: NamespacedName
  CrossRegionRestoreDetails.sourceBackupInstanceId : -|arm-id
  CrossRegionRestoreDetails.sourceRegion  : -|azure-location
  CrossRegionRestoreJobRequest.jobId : -|uuid
  CrossRegionRestoreJobRequest.sourceBackupVaultId : -|arm-id
  CrossRegionRestoreJobRequest.sourceRegion  : -|azure-location
  CrossRegionRestoreJobsRequest.sourceBackupVaultId : -|arm-id
  CrossRegionRestoreJobsRequest.sourceRegion  : -|azure-location
  FetchSecondaryRPsRequestParameters.sourceBackupInstanceId : -|arm-id
  FetchSecondaryRPsRequestParameters.sourceRegion  : -|azure-location
  BackupVault.replicatedRegions : -|azure-location
  RecoveryPointCompletionState: DataProtectionBackupRecoveryPointCompletionState
  CmkKekIdentity: BackupVaultCmkKekIdentity
  EncryptionSettings: BackupVaultEncryptionSettings
  EncryptionState: BackupVaultEncryptionState
  IdentityType: BackupVaultCmkKekIdentityType
  InfrastructureEncryptionState: BackupVaultInfrastructureEncryptionState
  AKSVolumeTypes: BackupAksVolumeType

directive:
# Correct the type of properties
  - from: dataprotection.json
    where: $.definitions
    transform: >
      $.AzureBackupRehydrationRequest.properties.rehydrationRetentionDuration['format'] = 'duration';
      $.AzureBackupRestoreWithRehydrationRequest.properties.rehydrationRetentionDuration['format'] = 'duration';
      $.DeleteOption.properties.duration['format'] = 'duration';
      $.CustomCopyOption.properties.duration['format'] = 'duration';
      $.ClientDiscoveryForLogSpecification.properties.blobDuration['format'] = 'duration';
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
