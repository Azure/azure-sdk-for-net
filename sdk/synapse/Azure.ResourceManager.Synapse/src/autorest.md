# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Synapse
namespace: Azure.ResourceManager.Synapse
# The readme.md in swagger repo contains invalid setting for C# sdk
# require: https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/readme.md
tag: package-composite-v2
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - WorkspaceManagedSqlServerDedicatedSQLMinimalTlsSettings_Update
  - SqlPoolSensitivityLabels_CreateOrUpdate
  - SqlPoolSensitivityLabels_Delete
skip-csproj: true
use-core-datafactory-replacements: false
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true   # Mitigate the duplication schema 'ErrorResponse' issue
use-model-reader-writer: true

# mgmt-debug:
#   show-serialized-names: true

rename-mapping:
  AzureADOnlyAuthentication: SynapseAadOnlyAuthentication
  AzureADOnlyAuthenticationListResult: SynapseAadOnlyAuthenticationListResult
  AzureADOnlyAuthenticationName: SynapseAadOnlyAuthenticationName
  DedicatedSQLminimalTlsSettings: SynapseDedicatedSqlMinimalTlsSetting
  DedicatedSQLminimalTlsSettingsListResult: SynapseDedicatedSqlMinimalTlsSettingListResult
  DedicatedSQLMinimalTlsSettingsName: SynapseDedicatedSqlMinimalTlsSettingName
  BigDataPoolResourceInfo: SynapseBigDataPoolInfo
  BigDataPoolResourceInfoListResult: SynapseBigDataPoolInfoListResult
  IntegrationRuntimeResource: SynapseIntegrationRuntime
  LibraryResource: SynapseLibrary
  ManagedIdentitySqlControlSettingsModel: SynapseManagedIdentitySqlControlSetting
  ManagedIdentitySqlControlSettingsModelPropertiesGrantSqlControlToManagedIdentity: SynapseGrantSqlControlToManagedIdentity
  MetadataSyncConfig: SynapseMetadataSyncConfiguration
  SparkConfigurationResource: SynapseSparkConfiguration
  ConfigurationType: SynapseSparkConfigurationType
  ActualState: SynapseGrantSqlControlToManagedIdentityState
  AzureCapacity: SynapseDataSourceCapacity
  AzureScaleType: SynapseDataSourceScaleType
  AzureSku: SynapseDataSourceSku
  AzureResourceSku: SynapseDataSourceResourceSku
  AutoPauseProperties: BigDataPoolAutoPauseProperties
  AutoScaleProperties: BigDataPoolAutoScaleProperties
  CheckNameResult: KustoPoolNameAvailabilityResult
  Reason: KustoPoolNameUnavailableReason
  DataConnectionCheckNameRequest: KustoPoolDataConnectionNameAvailabilityContent
  DatabasePrincipalAssignmentCheckNameRequest: KustoPoolDatabasePrincipalAssignmentNameAvailabilityContent
  DatabaseCheckNameRequest: KustoPoolChildResourceNameAvailabilityContent
  ClusterPrincipalAssignmentCheckNameRequest: KustoPoolPrincipalAssignmentNameAvailabilityContent
  KustoPoolCheckNameRequest: KustoPoolNameAvailabilityContent
  ConnectionPolicyName: SqlPoolConnectionPolicyName
  CreateMode: SqlPoolCreateMode
  CreateSqlPoolRestorePointDefinition: SqlPoolCreateRestorePointContent
  CustomerManagedKeyDetails: WorkspaceCustomerManagedKeyDetails
  IntegrationRuntime: SynapseIntegrationRuntimeProperties
  Compression: KustoPoolCompressionType
  IntegrationRuntimeMonitoringData: SynapseIntegrationRuntimeMonitoringResult
  IntegrationRuntimeNodeMonitoringData: SynapseIntegrationRuntimeNodeMonitoringResult
  ColumnDataType: SqlPoolColumnDataType
  IntegrationRuntimeListResponse: SynapseIntegrationRuntimeListResult
  IntegrationRuntimeOutboundNetworkDependenciesEndpointsResponse: SynapseIntegrationRuntimeOutboundNetworkDependenciesCategoryEndpointListResult
  IntegrationRuntimeStatusResponse: SynapseIntegrationRuntimeStatusResult
  IntegrationRuntimeVNetProperties: SynapseIntegrationRuntimeVnetProperties
  LibraryInfo: BigDataPoolLibraryInfo
  LibraryListResponse: BigDataPoolLibraryListResult
  LibraryRequirements: BigDataPoolLibraryRequirements
  ListResourceSkusResult: SynapseDataSourceResourceSkuListResult
  ListSqlPoolSecurityAlertPolicies: SynapseSqlPoolSecurityAlertPolicyListResult
  NodeSize: BigDataPoolNodeSize
  NodeSizeFamily: BigDataPoolNodeSizeFamily
  PrivateEndpointConnectionForPrivateLinkHubResourceCollectionResponse: SynapsePrivateEndpointConnectionForPrivateLinkHubListResult
  PrivateEndpointConnectionList: SynapsePrivateEndpointConnectionListResult
  PrivateLinkHubInfoListResult: SynapsePrivateLinkHubListResult
  RecommendedSensitivityLabelUpdateList: SynapseRecommendedSensitivityLabelUpdateOperationListResult
  RecoverableSqlPoolListResult: SynapseRecoverableSqlPoolListResult
  ReplaceAllFirewallRulesOperationResponse: ReplaceAllFirewallRulesOperationResult
  ReplicationLinkListResult: SynapseReplicationLinkListResult
  ResourceType: KustoPoolDatabaseType
  RestorableDroppedSqlPoolListResult: SynapseRestorableDroppedSqlPoolListResult
  RestorePointListResult: SynapseRestorePointListResult
  SensitivityLabelListResult: SynapseSensitivityLabelListResult
  SensitivityLabelUpdateList: SynapseSensitivityLabelUpdateListResult
  ServerBlobAuditingPolicyListResult: SynapseServerBlobAuditingPolicyListResult
  ServerSecurityAlertPolicyListResult: SynapseServerSecurityAlertPolicyListResult
  ServerUsageListResult: SynapseServerUsageListResult
  ServerVulnerabilityAssessmentListResult: SynapseServerVulnerabilityAssessmentListResult
  SkuDescription: KustoPoolSkuDescription
  SkuDescriptionList: KustoPoolSkuDescriptionListResult
  SkuLocationInfoItem: KustoPoolSkuLocationInfoItem
  SkuSize: KustoPoolSkuSize
  SparkConfigProperties: BigDataPoolSparkConfigProperties
  SparkConfigurationListResponse: SynapseSparkConfigurationListResult
  SsisObjectMetadataStatusResponse: SynapseSsisObjectMetadataStatusResult
  State: KustoPoolState
  StateValue: AadAuthenticationState
  StorageAccountType: SqlPoolStorageAccountType
  SsisObjectMetadataListResponse: SynapseSsisObjectMetadataListResult
  WorkspaceInfoListResult: SynapseWorkspaceListResult
  MaintenanceWindowTimeRange.startTime: StartOn
  AutoPauseProperties.enabled: IsEnabled
  CheckNameResult.nameAvailable: IsNameAvailable
  IntegrationRuntimeNodeIpAddress.ipAddress: -|ip-address
  ColumnDataType.uniqueidentifier: UniqueIdentifier
  ColumnDataType.datetime2: DateTime2
  ColumnDataType.datetimeoffset: DateTimeOffset
  ColumnDataType.tinyint: TinyInt
  ColumnDataType.smallint: SmallInt
  ColumnDataType.smalldatetime: SmallDateTime
  ColumnDataType.datetime: DateTime
  ColumnDataType.smallmoney: SmallMoney
  ColumnDataType.bigint: BigInt
  IpFirewallRuleProperties.endIpAddress: -|ip-address
  IpFirewallRuleProperties.startIpAddress: -|ip-address
  LibraryInfo.uploadedTimestamp: UploadedOn
  ManagedVirtualNetworkSettings.linkedAccessCheckOnTargetResource: EnableLinkedAccessCheckOnTargetResource
  AutoScaleProperties.enabled: IsEnabled
  ReplicationState.CATCH_UP: CatchUp
  ResourceMoveDefinition.id: -|arm-id
  AzureADOnlyAuthentication.properties.azureADOnlyAuthentication: IsAadOnlyAuthenticationEnabled
  BigDataPoolResourceInfo.properties.sessionLevelPackagesEnabled: IsSessionLevelPackagesEnabled
  MetadataSyncConfig.properties.enabled: IsEnabled
  ServerSecurityAlertPolicy.properties.emailAccountAdmins: EnableEmailToAccountAdmins
  SqlPoolSecurityAlertPolicy.properties.emailAccountAdmins: EnableEmailToAccountAdmins
  Workspace.properties.azureADOnlyAuthentication: IsAadOnlyAuthenticationEnabled
  Workspace.properties.trustedServiceBypassEnabled: IsTrustedServiceBypassEnabled
  DynamicExecutorAllocation.enabled: IsEnabled
  EncryptionDetails.doubleEncryptionEnabled: IsDoubleEncryptionEnabled
  SsisParameter.required: IsRequired
  SsisParameter.sensitive: IsSensitive
  SsisVariable.sensitive: IsSensitive
  VulnerabilityAssessmentRecurringScansProperties.emailSubscriptionAdmins: EnableEmailToAccountAdmins
  DataLakeStorageAccountDetails.resourceId: -|arm-id
  LinkedIntegrationRuntimeRbacAuthorization.resourceId: -|arm-id
  LibraryRequirements.time: UpdatedOn
  SparkConfigProperties.time: UpdatedOn
  CspWorkspaceAdminProperties.initialWorkspaceAdminObjectId: -|uuid
  KekIdentityProperties.userAssignedIdentity: UserAssignedIdentityId|arm-id
  SkuDescription.locations: -|azure-location
  PurviewConfiguration.purviewResourceId: -|arm-id
  DataMaskingFunction.CCN: Ccn
  DataMaskingFunction.SSN: Ssn
  EventGridDataConnection.properties.storageAccountResourceId: -|arm-id
  EventGridDataConnection.properties.eventHubResourceId: -|arm-id
  EventHubDataConnection.properties.eventHubResourceId: -|arm-id
  EventHubDataConnection.properties.managedIdentityResourceId: -|arm-id
  FollowerDatabaseDefinition.clusterResourceId: -|arm-id
  IntegrationRuntimeComputeProperties.vNetProperties: VnetProperties
  IntegrationRuntimeConnectionInfo.identityCertThumbprint: -|any
  IntegrationRuntimeSsisCatalogInfo.catalogServerEndpoint: -|uri
  IntegrationRuntimeVNetProperties.vNetId: VnetId|uuid
  IntegrationRuntimeVNetProperties.subnetId: -|arm-id
  IotHubDataConnection.properties.iotHubResourceId: -|arm-id
  SelfHostedIntegrationRuntimeNode.lastConnectTime: LastConnectedOn
  SelfHostedIntegrationRuntimeNode.expiryTime: ExpireOn
  SelfHostedIntegrationRuntimeNode.lastStartTime: LastStartedOn
  AttachedDatabaseConfiguration.properties.clusterResourceId: -|arm-id
  BigDataPoolResourceInfo.properties.lastSucceededTimestamp: LastSucceededOn
  ClusterPrincipalAssignment.properties.aadObjectId: -|uuid
  DatabasePrincipalAssignment.properties.aadObjectId: -|uuid
  DataMaskingRule.properties.id: ruleId
  EncryptionProtector.properties.thumbprint: -|any
  Key.properties.isActiveCMK: IsActiveCmk
  KustoPool.properties.workspaceUID: WorkspaceUid|uuid
  LibraryResource.properties.uploadedTimestamp: UploadedOn
  ReplicationLink.properties.partnerLocation: -|azure-location
  SensitivityLabel.properties.labelId: -|uuid
  SensitivityLabel.properties.informationTypeId: -|uuid
  SparkConfigurationResource.properties.created: CreatedOn
  Workspace.properties.workspaceUID: WorkspaceUid|uuid
  Workspace.properties.adlaResourceId: -|arm-id
  KustoPoolUpdate.properties.workspaceUID: WorkspaceUid|uuid
  PrivateLinkResources: SynapseKustoPoolPrivateLinkList
  KustoPoolPrivateLinkResources: SynapseKustoPoolPrivateLinkData
  IntegrationRuntimeStatus.type: RuntimeType
  EntityReference.type: IntegrationRuntimeEntityReferenceType

prepend-rp-prefix:
  - AttachedDatabaseConfiguration
  - AttachedDatabaseConfigurationListResult
  - ClusterPrincipalAssignment
  - ClusterPrincipalAssignmentListResult
  - ClusterPrincipalRole
  - Database
  - DatabaseListResult
  - DatabasePrincipalAssignment
  - DatabasePrincipalAssignmentListResult
  - DataConnection
  - DataMaskingPolicy
  - DataMaskingRule
  - DataMaskingRuleListResult
  - DataWarehouseUserActivities
  - EncryptionProtector
  - EncryptionProtectorListResult
  - ExtendedServerBlobAuditingPolicy
  - ExtendedServerBlobAuditingPolicyListResult
  - ExtendedSqlPoolBlobAuditingPolicy
  - ExtendedSqlPoolBlobAuditingPolicyListResult
  - GeoBackupPolicy
  - GeoBackupPolicyListResult
  - IpFirewallRuleInfo
  - Key
  - KustoPool
  - MaintenanceWindows
  - MaintenanceWindowOptions
  - PrivateEndpointConnectionForPrivateLinkHub
  - PrivateLinkHub
  - RecoverableSqlPool
  - ReplicationLink
  - RestorableDroppedSqlPool
  - RestorePoint
  - SensitivityLabel
  - ServerBlobAuditingPolicy
  - ServerSecurityAlertPolicy
  - ServerVulnerabilityAssessment
  - SqlPool
  - SqlPoolBlobAuditingPolicy
  - SqlPoolBlobAuditingPolicyListResult
  - SqlPoolColumn
  - SqlPoolConnectionPolicy
  - SqlPoolSchema
  - SqlPoolSecurityAlertPolicy
  - SqlPoolTable
  - SqlPoolVulnerabilityAssessment
  - SqlPoolVulnerabilityAssessmentRuleBaseline
  - TransparentDataEncryption
  - TransparentDataEncryptionListResult
  - TransparentDataEncryptionName
  - TransparentDataEncryptionStatus
  - VulnerabilityAssessmentScanRecord
  - VulnerabilityAssessmentScanRecordListResult
  - WorkloadClassifier
  - WorkloadClassifierListResult
  - WorkloadGroup
  - WorkloadGroupListResult
  - WorkspaceAadAdminInfo
  - Workspace
  - BlobAuditingPolicyName
  - BlobAuditingPolicyState
  - BlobStorageEventType
  - CmdkeySetup
  - CustomSetupBase
  - ComponentSetup
  - DatabasePrincipalAssignmentType
  - DatabasePrincipalRole
  - DataConnectionKind
  - DataConnectionListResult
  - DataConnectionType
  - DataConnectionValidation
  - DataConnectionValidationListResult
  - DataConnectionValidationResult
  - DataFlowComputeType
  - DataLakeStorageAccountDetails
  - DataMaskingFunction
  - DataMaskingRuleState
  - DataMaskingState
  - DataWarehouseUserActivityName
  - DayOfWeek
  - DefaultPrincipalsModificationKind
  - DesiredState
  - DynamicExecutorAllocation
  - EncryptionDetails
  - EncryptionProtectorName
  - EntityReference
  - EnvironmentVariableSetup
  - EventGridDataConnection
  - EventGridDataFormat
  - EventHubDataConnection
  - EventHubDataFormat
  - FollowerDatabaseDefinition
  - FollowerDatabaseListResult
  - GeoBackupPolicyName
  - GeoBackupPolicyState
  - GetSsisObjectMetadataRequest
  - IntegrationRuntimeAuthKeyName
  - IntegrationRuntimeAuthKeys
  - IntegrationRuntimeAutoUpdate
  - IntegrationRuntimeComputeProperties
  - IntegrationRuntimeConnectionInfo
  - IntegrationRuntimeCustomSetupScriptProperties
  - IntegrationRuntimeDataFlowProperties
  - IntegrationRuntimeDataProxyProperties
  - IntegrationRuntimeEdition
  - IntegrationRuntimeEntityReferenceType
  - IntegrationRuntimeInternalChannelEncryptionMode
  - IntegrationRuntimeLicenseType
  - IntegrationRuntimeNodeIpAddress
  - IntegrationRuntimeOutboundNetworkDependenciesCategoryEndpoint
  - IntegrationRuntimeOutboundNetworkDependenciesEndpoint
  - IntegrationRuntimeOutboundNetworkDependenciesEndpointDetails
  - IntegrationRuntimeRegenerateKeyContent
  - IntegrationRuntimeSsisCatalogInfo
  - IntegrationRuntimeSsisCatalogPricingTier
  - IntegrationRuntimeSsisProperties
  - IntegrationRuntimeState
  - IntegrationRuntimeStatus
  - IntegrationRuntimeUpdateResult
  - IotHubDataConnection
  - IotHubDataFormat
  - IpFirewallRuleInfoListResult
  - IpFirewallRuleProperties
  - LanguageExtension
  - LanguageExtensionName
  - LanguageExtensionsList
  - LinkedIntegrationRuntime
  - LinkedIntegrationRuntimeKeyAuthorization
  - LinkedIntegrationRuntimeRbacAuthorization
  - LinkedIntegrationRuntimeType
  - MaintenanceWindowTimeRange
  - ManagedIntegrationRuntime
  - ManagedIntegrationRuntimeError
  - ManagedIntegrationRuntimeNode
  - ManagedIntegrationRuntimeNodeStatus
  - ManagedIntegrationRuntimeOperationResult
  - ManagedIntegrationRuntimeStatus
  - ManagedVirtualNetworkSettings
  - ManagementOperationState
  - OptimizedAutoscale
  - PrincipalAssignmentType
  - PrincipalsModificationKind
  - PrincipalType
  - PrivateEndpointConnectionProperties
  - ProvisioningState
  - ReadOnlyFollowingDatabase
  - ReadWriteDatabase
  - RecommendedSensitivityLabelUpdate
  - RecommendedSensitivityLabelUpdateKind
  - ReplicationRole
  - ReplicationState
  - ResourceMoveDefinition
  - RestorePointType
  - SecretBase
  - SecureString
  - SecurityAlertPolicyState
  - SelfHostedIntegrationRuntime
  - SelfHostedIntegrationRuntimeNode
  - SelfHostedIntegrationRuntimeNodeStatus
  - SelfHostedIntegrationRuntimeStatus
  - SensitivityLabelRank
  - SensitivityLabelSource
  - SensitivityLabelUpdate
  - SensitivityLabelUpdateKind
  - ServerKeyType
  - ServerUsage
  - SsisEnvironment
  - SsisEnvironmentReference
  - SsisFolder
  - SsisObjectMetadata
  - SsisObjectMetadataType
  - SsisPackage
  - SsisParameter
  - SsisProject
  - SsisVariable
  - TableLevelSharingProperties
  - VulnerabilityAssessmentName
  - VulnerabilityAssessmentPolicyBaselineName
  - VulnerabilityAssessmentRecurringScansProperties
  - VulnerabilityAssessmentScanError
  - VulnerabilityAssessmentScanState
  - VulnerabilityAssessmentScanTriggerType
  - WorkspaceKeyDetails
  - WorkspaceRepositoryConfiguration

override-operation-name:
  IntegrationRuntimeStatus_Get: GetIntegrationRuntimeStatus
  KustoPoolDataConnections_CheckNameAvailability: CheckKustoPoolDataConnectionNameAvailability
  KustoPoolDatabasePrincipalAssignments_CheckNameAvailability: CheckKustoPoolDatabasePrincipalAssignmentNameAvailability
  KustoPoolChildResource_CheckNameAvailability: CheckKustoPoolChildResourceNameAvailability
  KustoPoolPrincipalAssignments_CheckNameAvailability: CheckKustoPoolPrincipalAssignmentNameAvailability
  KustoPools_CheckNameAvailability: CheckKustoPoolNameAvailability
  KustoPoolDataConnections_DataConnectionValidation: ValidateDataConnection
  IntegrationRuntimeNodeIpAddress_Get: GetIntegrationRuntimeNodeIPAddress
  KustoPoolPrivateLinkResources_List: GetAllKustoPoolPrivateLinkData

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/privateLinkHubs/{privateLinkHubName}/privateLinkResources/{privateLinkResourceName}: SynapsePrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/privateLinkResources/{privateLinkResourceName}: SynapseWorkspacePrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/administrators/activeDirectory: SynapseWorkspaceAdministratorResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlAdministrators/activeDirectory: SynapseWorkspaceSqlAdministratorResource

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
  Multijson: MultiJson
  CSV: Csv
  TSV: Tsv
  PSV: Psv
  TXT: Txt
  RAW: Raw
  Singlejson: SingleJson
  ORC: Orc
  Apacheavro: ApacheAvro
  W3Clogfile: W3CLogfile
  GRS: Grs
  LRS: Lrs
  GPU: Gpu
  ETA: Eta

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/connectionPolicies/{connectionPolicyName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}

suppress-abstract-base-class:
- SynapseDatabaseData
- SynapseDataConnectionData
- SynapseIntegrationRuntimeProperties
- SynapseIntegrationRuntimeStatus

directive:
  - remove-operation: Get_IntegrationRuntimeStart
  - remove-operation: Get_IntegrationRuntimeStop
  - remove-operation: Get_IntegrationRuntimeEnableInteractivequery
  - remove-operation: Operations_List
  - remove-operation: Operations_GetLocationHeaderResult
  - remove-operation: Operations_GetAzureAsyncHeaderResult
  - remove-operation: KustoOperations_List
  - remove-operation: SqlPoolOperations_List
  - remove-operation: SqlPoolOperationResults_GetLocationHeaderResult
  - from: operations.json
    where: $.definitions
    transform: >
      $.OperationMetaLogSpecification.properties.blobDuration['format'] = 'duration';
  - from: sqlPool.json
    where: $.definitions
    transform: >
      $.MaintenanceWindowTimeRange.properties.duration['format'] = 'duration';
      $.MaintenanceWindowTimeRange.properties.startTime['format'] = 'time';
  - from: kustoPool.json
    where: $.definitions
    transform: >
      $.DatabaseCheckNameRequest.properties.type['x-ms-client-name'] = 'resourceType';
      $.DatabaseCheckNameRequest.properties.type['x-ms-enum']['name'] = 'ResourceType';
  # Fix the dubplicate schema 'PrivateEndpointConnectionForPrivateLinkHubBasic'
  - from: privatelinkhub.json
    where: $.definitions
    transform: >
      $.PrivateLinkHubProperties.properties.privateEndpointConnections.items['$ref'] = '../../../../common/v1/privateEndpointConnection.json#/definitions/PrivateEndpointConnectionForPrivateLinkHubBasic';
      delete $.PrivateEndpointConnectionForPrivateLinkHubBasic;
  # Fix the duplicating schema 'SecurityAlertPolicyName'
  - from: sqlPool.json
    where: $.paths..parameters[?(@.name === 'securityAlertPolicyName')]
    transform: >
      $['x-ms-enum']['name'] = 'SqlPoolSecurityAlertPolicyName';
  - from: sqlServer.json
    where: $.paths..parameters[?(@.name === 'securityAlertPolicyName')]
    transform: >
      $['x-ms-enum']['name'] = 'SqlServerSecurityAlertPolicyName';
  # Fix the breaking changes relative to version 1.0.0
  - from: bigDataPool.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/bigDataPools/{bigDataPoolName}'].delete
    transform: >
      $.description += ' You can call ToObjectFromJson<SynapseBigDataPoolInfoData>() against the Value property of the result to get specified type.';
      $.responses['200'].schema = {
          "type": "object"
      };
      $.responses['202'].schema = {
          "type": "object"
      };
  - from: firewallRule.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/firewallRules/{ruleName}'].delete
    transform: >
      $.description += '. You can call ToObjectFromJson<SynapseIPFirewallRuleInfoData>() against the Value property of the result to get specified type.';
      $.responses['200'].schema = {
          "type": "object"
      };
  - from: sqlPool.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}'].delete
    transform: >
      $.description += '. You can call ToObjectFromJson<SynapseSqlPoolData>() against the Value property of the result to get specified type.';
      $.responses['200'].schema = {
          "type": "object"
      };
      $.responses['202'].schema = {
          "type": "object"
      };
  - from: sqlPool.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/pause'].post
    transform: >
      $.description += '. You can call ToObjectFromJson<SynapseSqlPoolData>() against the Value property of the result to get specified type.';
      $.responses['200'].schema = {
          "type": "object"
      };
      $.responses['202'].schema = {
          "type": "object"
      };
  - from: sqlPool.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/resume'].post
    transform: >
      $.description += '. You can call ToObjectFromJson<SynapseSqlPoolData>() against the Value property of the result to get specified type.';
      $.responses['200'].schema = {
          "type": "object"
      };
      $.responses['202'].schema = {
          "type": "object"
      };
  - from: integrationRuntime.json
    where: $.definitions
    transform: >
      $.IntegrationRuntimeResource.properties.properties['x-ms-client-flatten'] = false;
      $.IntegrationRuntimeStatusResponse.properties.properties['x-ms-client-flatten'] = false;

```

### Tag: package-composite-v2

These settings apply only when --tag=package-composite-v2 is specified on the command line.

```yaml $(tag) == 'package-composite-v2'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/azureADOnlyAuthentication.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/checkNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/firewallRule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/keys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privateEndpointConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privatelinkhub.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/sqlPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/sqlServer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/workspace.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/bigDataPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/library.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/integrationRuntime.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/sparkConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/340d577969b7bff5ad0488d79543314bc17daa50/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/kustoPool.json
```
