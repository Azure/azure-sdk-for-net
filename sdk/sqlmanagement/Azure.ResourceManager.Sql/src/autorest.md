# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
tag: package-preview-2024-11-01-preview
require: https://github.com/Azure/azure-rest-api-specs/blob/0d68729fe5000a0e7dcdccd2c5f5e6e712f901a9/specification/sql/resource-manager/readme.md
namespace: Azure.ResourceManager.Sql
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - ManagedDatabaseSensitivityLabels_CreateOrUpdate
  - ManagedDatabaseSensitivityLabels_Delete
  - SensitivityLabels_CreateOrUpdate
  - SensitivityLabels_Delete
  - ManagedDatabaseSecurityEvents_ListByDatabase
  - OutboundFirewallRules_CreateOrUpdate
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
model-namespace: false
public-clients: false
head-as-boolean: false
use-model-reader-writer: true
enable-bicep-serialization: true

# mgmt-debug:
#  show-serialized-names: true

# this is temporary, to be removed when we find the owner of this feature
operation-groups-to-omit:
- JobPrivateEndpoints

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  'locationName': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  'keyId': 'Uri'
  '*ResourceId': 'arm-id'
  '*SubnetId': 'arm-id'
  'subnetId': 'arm-id'
  'primaryUserAssignedIdentityId': 'arm-id'
  'elasticPoolId': 'arm-id'
  'recoverableDatabaseId': 'arm-id'
  'sourceDatabaseId': 'arm-id'
  'syncDatabaseId': 'arm-id'
  'maintenanceConfigurationId': 'arm-id'
  'originalId': 'arm-id'
  '*ManagedInstanceId': 'arm-id'
  'instancePoolId': 'arm-id'
  'recoveryServicesRecoveryPointId': 'arm-id'
  'syncAgentId': 'arm-id'
  'oldServerDnsAliasId': 'arm-id'
  'failoverGroupId': 'arm-id'
  'partnerLocation': 'azure-location'
  'defaultSecondaryLocation': 'azure-location'
  'privateLinkServiceId': 'arm-id'
  'resourceType': 'resource-type'
  'clientIP': 'ip-address'

keep-plural-enums:
- DiffBackupIntervalInHours

keep-plural-resource-data:
- MaintenanceWindows

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
  SQL: Sql
  DTU: Dtu
  GEO: Geo
  GRS: Grs
  LRS: Lrs
  ZRS: Zrs
  Hierarchyid: HierarchyId
  CP1CIAS: Cp1CiAs
  CatchUP: CatchUp
  CCN: Ccn
  SSN: Ssn
  DbCopying: DBCopying
  DbMoving: DBMoving

prepend-rp-prefix:
  - DatabaseAutomaticTuning
  - DatabaseBlobAuditingPolicy
  - DatabaseSecurityAlertPolicy
  - TimeZone
  - Server
  - ServerCreateMode
  - Database
  - DayOfWeek
  - MetricType
  - ServerAutomaticTuning
  - ServerAzureADAdministrator
  - ServerAzureADOnlyAuthentication
  - ServerBlobAuditingPolicy
  - ServerConnectionPolicy
  - ServerDnsAlias
  - ServerKey
  - ServerSecurityAlertPolicy
  - ServerTrustGroup
  - ServerVulnerabilityAssessment
  - ServicePrincipal
  - ServicePrincipalType
  - FirewallRule
  - AdministratorName
  - AdministratorType
  - CapabilityGroup
  - CapabilityStatus
  - LocationCapabilities
  - ColumnDataType
  - DatabaseState
  - DatabaseStatus
  - ResourceMoveDefinition
  - ServerUsage
  - AdvisorStatus
  - Advisor

list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/restoreDetails/{restoreDetailsName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}

# no-property-type-replacement: ResourceMoveDefinition

override-operation-name:
  ServerTrustGroups_ListByInstance: GetSqlServerTrustGroups
  ManagedInstances_ListByManagedInstance: GetTopQueries
  ManagedDatabases_ListInaccessibleByInstance: GetInaccessibleManagedDatabases
  ManagedInstances_ListOutboundNetworkDependenciesByManagedInstance: GetOutboundNetworkDependencies
  ManagedDatabaseQueries_ListByQuery: GetQueryStatistics
  Capabilities_ListByLocation: GetCapabilitiesByLocation
  Servers_CheckNameAvailability: CheckSqlServerNameAvailability
  LongTermRetentionBackups_ListByResourceGroupLocation: GetLongTermRetentionBackupsWithLocation
  LongTermRetentionBackups_ListByResourceGroupServer: GetLongTermRetentionBackupsWithServer
  LongTermRetentionManagedInstanceBackups_ListByResourceGroupInstance: GetLongTermRetentionManagedInstanceBackupsWithInstance
  LongTermRetentionManagedInstanceBackups_ListByResourceGroupLocation: GetLongTermRetentionManagedInstanceBackupsWithLocation
  LongTermRetentionBackups_ListByLocation: GetLongTermRetentionBackupsWithLocation
  LongTermRetentionBackups_ListByServer: GetLongTermRetentionBackupsWithServer
  LongTermRetentionManagedInstanceBackups_ListByInstance: GetLongTermRetentionManagedInstanceBackupsWithInstance
  LongTermRetentionManagedInstanceBackups_ListByLocation: GetLongTermRetentionManagedInstanceBackupsWithLocation
  DatabaseSqlVulnerabilityAssessmentExecuteScan_Execute: ExecuteScan
  SqlVulnerabilityAssessmentExecuteScan_Execute: ExecuteScan

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/queries/{queryId}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}/backupShortTermRetentionPolicies/{policyName}: ManagedRestorableDroppedDbBackupShortTermRetentionPolicy
  /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName}: SubscriptionLongTermRetentionManagedInstanceBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName}: ResourceGroupLongTermRetentionManagedInstanceBackup
  /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}: SubscriptionLongTermRetentionBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}: ResourceGroupLongTermRetentionBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}: SqlServerJobExecution
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}: SqlServerJobExecutionStep
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/steps/{stepName}/targets/{targetId}: SqlServerJobExecutionStepTarget
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/steps/{stepName}: SqlServerJobStep
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/versions/{jobVersion}/steps/{stepName}: SqlServerJobVersionStep
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/advisors/{advisorName}: SqlDatabaseAdvisor
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}: SqlDatabaseSchema
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}: SqlDatabaseTable
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}: SqlDatabaseColumn
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}: SqlDatabaseSensitivityLabel
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}: SqlDatabaseVulnerabilityAssessment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}: SqlDatabaseVulnerabilityAssessmentRuleBaseline
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}: SqlDatabaseVulnerabilityAssessmentScan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/serverTrustCertificates/{certificateName}: ManagedInstanceServerTrustCertificate
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}: ManagedBackupShortTermRetentionPolicy
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}: ManagedDatabaseSchema
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}: ManagedDatabaseTable
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}: ManagedDatabaseColumn
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}: ManagedDatabaseSensitivityLabel
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}: ManagedDatabaseVulnerabilityAssessment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}: ManagedDatabaseVulnerabilityAssessmentRuleBaseline
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}: ManagedDatabaseVulnerabilityAssessmentScan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}: SqlServerAdvisor
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/virtualNetworkRules/{virtualNetworkRuleName}: SqlServerVirtualNetworkRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/replicationLinks/{linkId}: SqlServerDatabaseReplicationLink
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/restorePoints/{restorePointName}: SqlServerDatabaseRestorePoint
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}: SqlServerSqlVulnerabilityAssessment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}: SqlServerSqlVulnerabilityAssessmentScan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}/scanResults/{scanResultId}: SqlServerSqlVulnerabilityAssessmentScanResult
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/baselines/{baselineName}: SqlServerSqlVulnerabilityAssessmentBaseline
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/baselines/{baselineName}/rules/{ruleId}: SqlServerSqlVulnerabilityAssessmentBaselineRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}: SqlDatabaseSqlVulnerabilityAssessment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}: SqlDatabaseSqlVulnerabilityAssessmentScan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}/scanResults/{scanResultId}: SqlDatabaseSqlVulnerabilityAssessmentScanResult
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/baselines/{baselineName}: SqlDatabaseSqlVulnerabilityAssessmentBaseline
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/baselines/{baselineName}/rules/{ruleId}: SqlDatabaseSqlVulnerabilityAssessmentBaselineRule
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}: SqlDistributedAvailabilityGroup

rename-mapping:
  CopyLongTermRetentionBackupParameters: CopyLongTermRetentionBackupContent
  UpdateLongTermRetentionBackupParameters: UpdateLongTermRetentionBackupContent
  Name: InstancePoolUsageName
  Usage: InstancePoolUsage
  Usage.type: ResourceType
  UsageListResult: InstancePoolUsageListResult
  SyncGroupsType: SyncGroupLogType
  SampleName: SampleSchemaName
  ManagedInstancePrivateEndpointConnection.properties.privateLinkServiceConnectionState: ConnectionState
  RestorePoint.properties.restorePointCreationDate: restorePointCreatedOn
  Job: SqlServerJob
  JobAgent: SqlServerJobAgent
  JobVersion: SqlServerJobVersion
  JobCredential: SqlServerJobCredential
  JobTargetGroup: SqlServerJobTargetGroup
  JobSchedule: SqlServerJobSchedule
  JobScheduleType: SqlServerJobScheduleType
  JobExecution: SqlServerJobExecution
  JobStep: SqlServerJobStep
  LedgerDigestUploads: LedgerDigestUpload
  ServerDevOpsAuditingSettings: SqlServerDevOpsAuditingSetting
  ManagedDatabaseRestoreDetailsResult: ManagedDatabaseRestoreDetail
  ManagedDatabaseRestoreDetailsResult.properties.currentRestoredSizeMB: CurrentRestoredSizeInMB
  ManagedDatabaseRestoreDetailsResult.properties.currentRestorePlanSizeMB: CurrentRestorePlanSizeInMB
  ManagedDatabaseRestoreDetailsResult.properties.type: RestoreType
  ManagedDatabaseRestoreDetailsBackupSetProperties: ManagedDatabaseRestoreDetailBackupSetProperties
  ManagedDatabaseRestoreDetailsBackupSetProperties.backupSizeMB: BackupSizeInMB
  ManagedDatabaseRestoreDetailsBackupSetProperties.restoreStartedTimestampUtc: RestoreStartedOn
  ManagedDatabaseRestoreDetailsBackupSetProperties.restoreFinishedTimestampUtc: RestoreFinishedOn
  ManagedDatabaseRestoreDetailsUnrestorableFileProperties: ManagedDatabaseRestoreDetailUnrestorableFileProperties
  CheckNameAvailabilityReason: SqlNameUnavailableReason
  CheckNameAvailabilityResourceType: SqlNameAvailabilityResourceType
  CheckNameAvailabilityRequest: SqlNameAvailabilityContent
  CreateMode: SqlDatabaseCreateMode
  OperationMode: DatabaseExtensionOperationMode
  ProvisioningState: JobExecutionProvisioningState
  ManagedDatabaseUpdate.properties.autoCompleteRestore: AllowAutoCompleteRestore
  ManagedDatabase.properties.autoCompleteRestore: AllowAutoCompleteRestore
  ManagedInstanceAzureADOnlyAuthentication.properties.azureADOnlyAuthentication: IsAzureADOnlyAuthenticationEnabled
  ServerAzureADAdministrator.properties.azureADOnlyAuthentication: IsAzureADOnlyAuthenticationEnabled
  ServerAzureADOnlyAuthentication.properties.azureADOnlyAuthentication: IsAzureADOnlyAuthenticationEnabled
  ManagedInstanceExternalAdministrator.azureADOnlyAuthentication: IsAzureADOnlyAuthenticationEnabled
  ServerExternalAdministrator.azureADOnlyAuthentication: IsAzureADOnlyAuthenticationEnabled
  SyncGroup.properties.enableConflictLogging: IsConflictLoggingEnabled
  PrincipalType: SqlServerPrincipalType
  IsRetryable: ActionRetryableState
  ExportDatabaseDefinition: DatabaseExportDefinition
  ImportNewDatabaseDefinition: DatabaseImportDefinition
  PartnerInfo: PartnerServerInfo
  ReplicationState: ReplicationLinkState
  ServerInfo: ServerTrustGroupServerInfo
  DatabaseExtensions: SqlDatabaseExtension
  DatabaseOperation: DatabaseOperationData
  ServerOperation: ServerOperationData
  ElasticPoolOperation: ElasticPoolOperationData
  UpdateVirtualClusterDnsServersOperation: ManagedInstanceUpdateDnsServersOperationData
  VirtualNetworkRule: SqlServerVirtualNetworkRule
  VirtualNetworkRuleState: SqlServerVirtualNetworkRuleState
  PrivateEndpointConnectionProperties: ServerPrivateEndpointConnectionProperties
  PrivateEndpointProvisioningState: SqlPrivateEndpointProvisioningState
  PrivateLinkServiceConnectionStateActionsRequire: SqlPrivateLinkServiceConnectionActionsRequired
  PrivateLinkServiceConnectionStateStatus: SqlPrivateLinkServiceConnectionStatus
  SecurityAlertPolicyName: SqlSecurityAlertPolicyName
  ServerKeyType: SqlServerKeyType
  ServerPrivateEndpointConnection: SqlServerPrivateEndpointConnection
  ReplicationLink: SqlServerDatabaseReplicationLink
  ReplicationRole: SqlServerDatabaseReplicationRole
  ServerVersionCapability: SqlServerVersionCapability
  RestorePoint: SqlServerDatabaseRestorePoint
  BackupStorageRedundancy: SqlBackupStorageRedundancy
  DNSRefreshOperationStatus: DnsRefreshConfigurationPropertiesStatus
  DatabaseSqlVulnerabilityAssessmentBaselineSet: SqlVulnerabilityAssessmentBaseline
  BaselineName: SqlVulnerabilityAssessmentBaselineName
  DatabaseSqlVulnerabilityAssessmentRuleBaselineListInput: SqlVulnerabilityAssessmentBaselineCreateOrUpdateContent
  DatabaseSqlVulnerabilityAssessmentRuleBaselineListInput.properties.latestScan: IsLatestScan
  DatabaseSqlVulnerabilityAssessmentRuleBaseline: SqlVulnerabilityAssessmentBaselineRule
  DatabaseSqlVulnerabilityAssessmentRuleBaselineInput: SqlVulnerabilityAssessmentBaselineRuleCreateOrUpdateContent
  DatabaseSqlVulnerabilityAssessmentRuleBaselineInput.properties.latestScan: IsLatestScan
  SqlVulnerabilityAssessmentScanRecord: SqlVulnerabilityAssessmentScan
  AlwaysEncryptedEnclaveType: SqlAlwaysEncryptedEnclaveType
  AlwaysEncryptedEnclaveType.VBS: Vbs
  SynapseLinkWorkspace: SqlSynapseLinkWorkspace
  BaselineAdjustedResult: SqlVulnerabilityAssessmentBaselineAdjustedResult
  Remediation: SqlVulnerabilityAssessmentRemediation
  Remediation.automated: IsAutomated
  VaRule: SqlVulnerabilityAssessmentRuleMetadata
  RuleStatus: SqlVulnerabilityAssessmentRuleStatus
  Baseline: SqlVulnerabilityAssessmentBaselineDetails
  BenchmarkReference: SqlVulnerabilityAssessmentBenchmarkReference
  ManagedDatabaseMoveDefinition.destinationManagedDatabaseId: -|arm-id
  ManagedDatabaseStartMoveDefinition.destinationManagedDatabaseId: -|arm-id
  MoveOperationMode: ManagedDatabaseMoveOperationMode
  ManagedInstanceDtcSecuritySettings.xaTransactionsDefaultTimeout: XATransactionsDefaultTimeoutInSeconds
  ManagedInstanceDtcSecuritySettings.xaTransactionsMaximumTimeout: XATransactionsMaximumTimeoutInSeconds
  ManagedInstanceDtcSecuritySettings.xaTransactionsEnabled: IsXATransactionsEnabled
  QueryCheck: SqlVulnerabilityAssessmentQueryCheck
  RuleSeverity: SqlVulnerabilityAssessmentRuleSeverity
  RuleType: SqlVulnerabilityAssessmentRuleType
  SynapseLinkWorkspaceInfoProperties: SqlSynapseLinkWorkspaceInfo
  SynapseLinkWorkspaceInfoProperties.workspaceId: -|arm-id
  ServerPublicNetworkAccessFlag: ServerNetworkAccessFlag
  SecondaryInstanceType: GeoSecondaryInstanceType
  StartStopManagedInstanceSchedule: ManagedInstanceStartStopSchedule
  StartStopScheduleName: ManagedInstanceStartStopScheduleName
  DatabaseKey: SqlDatabaseKey
  DatabaseKeyType: SqlDatabaseKeyType
  AvailabilityZoneType: SqlAvailabilityZoneType
  EndpointDependency: ManagedInstanceEndpointDependency
  EndpointDetail: ManagedInstanceEndpointDetail
  ScheduleItem: SqlScheduleItem
  ServerConfigurationOptionName: ManagedInstanceServerConfigurationOptionName
  ServerConfigurationOption: ManagedInstanceServerConfigurationOption
  OutboundEnvironmentEndpoint: SqlOutboundEnvironmentEndpoint
  OutboundEnvironmentEndpointCollection: SqlOutboundEnvironmentEndpointCollection
  FailoverGroup.properties.databases: FailoverDatabases
  ManagedInstance.properties.dnsZonePartner: ManagedDnsZonePartner
  ManagedInstanceUpdate.properties.dnsZonePartner: ManagedDnsZonePartner
  FailoverGroupUpdate.properties.databases: FailoverDatabases
  Server.properties.minimalTlsVersion: minTlsVersion
  ServerUpdate.properties.minimalTlsVersion: minTlsVersion
  MinimalTlsVersion: SqlMinimalTlsVersion
  BackupStorageAccessTier: SqlBackupStorageAccessTier
  Phase: DatabaseOperationPhase
  PhaseDetails: DatabaseOperationPhaseDetails
  ManagementOperationStepState: UpsertManagedServerOperationStepStatus
  UpsertManagedServerOperationStepWithEstimatesAndDuration: UpsertManagedServerOperationStep
  GeoBackupPolicy.properties.state: GeoBackupPolicyState
  DistributedAvailabilityGroup: SqlDistributedAvailabilityGroup
  RecommendedAction.properties.details: ActionDetails
  ManagedDatabase.properties.crossSubscriptionSourceDatabaseId: -|arm-id
  ManagedDatabase.properties.crossSubscriptionRestorableDroppedDatabaseId: -|arm-id
  ManagedDatabaseUpdate.properties.crossSubscriptionSourceDatabaseId: -|arm-id
  ManagedDatabaseUpdate.properties.crossSubscriptionRestorableDroppedDatabaseId: -|arm-id
  ManagedInstanceUpdate.properties.virtualClusterId: -|arm-id
  NetworkSecurityPerimeterConfiguration: SqlNetworkSecurityPerimeterConfiguration
  NetworkSecurityPerimeterConfigurationListResult: SqlNetworkSecurityPerimeterConfigurationListResult
  AuthMetadataLookupModes.AzureAD: Aad
  CertificateInfo: SqlServerCertificateInfo
  ClientClassificationSource.MIP: Mip
  DataMaskingRule.properties.id: RuleId
  FailoverModeType: SqlServerFailoverModeType
  FailoverType: SqlServerFailoverType
  InstanceRole: DistributedAvailabilityGroupManagedInstanceRole
  LinkRole: SqlServerSideLinkRole
  NSPConfigAccessRule: SqlNetworkSecurityPerimeterConfigAccessRule
  NSPConfigAccessRuleProperties: SqlNetworkSecurityPerimeterConfigAccessRuleProperties
  NSPConfigAssociation: SqlNetworkSecurityPerimeterConfigAssociation
  NSPConfigNetworkSecurityPerimeterRule: SqlNetworkSecurityPerimeterConfigRule
  NSPConfigPerimeter: SqlNetworkSecurityPerimeterConfigPerimeter
  NSPConfigProfile: SqlNetworkSecurityPerimeterConfigProfile
  NSPProvisioningIssue: SqlNetworkSecurityPerimeterProvisioningIssue
  NSPProvisioningIssueProperties: SqlNetworkSecurityPerimeterProvisioningIssueProperties
  PricingModel: SqlManagedInstancePricingModel
  RefreshExternalGovernanceStatusOperationResultMI: SqlManagedInstanceRefreshExternalGovernanceStatusOperationResult
  ReplicaConnectedState: SqlReplicaConnectedState
  ReplicaSynchronizationHealth.NOT_HEALTHY: NotHealthy
  ReplicaSynchronizationHealth: SqlReplicaSynchronizationHealth
  ReplicationModeType: SqlReplicationModeType
  RoleChangeType: DistributedAvailabilityGroupRoleChangeType
  InstancePoolOperation: SqlInstancePoolOperation
  ManagedInstance.properties.totalMemoryMB: TotalMemoryInMB
  ManagedInstanceUpdate.properties.totalMemoryMB: TotalMemoryInMB
  ErrorType: SqlInstancePoolOperationErrorType
  InaccessibilityReason: ManagedDatabaseInaccessibilityReason 

prompted-enum-values:
  - Default

directive:
    - remove-operation: ManagedDatabaseMoveOperations_ListByLocation
    - remove-operation: ManagedDatabaseMoveOperations_Get
    - remove-operation: DatabaseExtensions_Get # This operation is not supported
    - remove-operation: FirewallRules_Replace # This operation sends a list of rules but got a single rule in response, which is abnormal. Besides, using FirewallRules_CreateOrUpdate/FirewallRules_Delete multiple times could achieve the same goal.
    - rename-operation:
        from: ManagedDatabaseRecommendedSensitivityLabels_Update
        to: ManagedDatabaseSensitivityLabels_UpdateRecommended
    - rename-operation:
        from: RecommendedSensitivityLabels_Update
        to: SensitivityLabels_UpdateRecommended
    - rename-operation:
        from: ManagedDatabaseSensitivityLabels_ListCurrentByDatabase
        to: ManagedDatabaseSensitivityLabels_ListCurrent
    - rename-operation:
        from: ManagedDatabaseSensitivityLabels_ListRecommendedByDatabase
        to: ManagedDatabaseSensitivityLabels_ListRecommended
    - rename-operation:
        from: DataMaskingRules_ListByDatabase
        to: DataMaskingRules_List
    - rename-operation:
        from: Databases_ListMetrics
        to: Metrics_ListDatabase
    - rename-operation:
        from: Databases_ListMetricDefinitions
        to: MetricDefinitions_ListDatabase
    - rename-operation:
        from: ElasticPools_ListMetrics
        to: Metrics_ListElasticPool
    - rename-operation:
        from: ElasticPools_ListMetricDefinitions
        to: MetricDefinitions_ListElasticPool
    # add format to Usage
    - from: Usages.json
      where: $.definitions.Usage.properties
      transform: >
        $.id["x-ms-format"] = "arm-id";
        $.type["x-ms-format"] = "resource-type";
    # why we have this change? If the modelAsString is false, this resource will become a singleton
    - from: BlobAuditing.json
      where: $.parameters.BlobAuditingPolicyNameParameter['x-ms-enum'].modelAsString
      transform: return true;
    - from: swagger-document #DatabaseRecommendedActions.json, DatabaseAdvisors.json, ServerAdvisors.json
      where: $.definitions.RecommendedActionProperties.properties
      transform: >
          $.executeActionDuration.format = "duration";
          $.revertActionDuration.format = "duration";
    - from: swagger-document #MaintenanceWindows.json, MaintenanceWindowOptions.json
      where: $.definitions.MaintenanceWindowTimeRange.properties.duration
      transform: >
          $.format = "duration";
    - from: swagger-document
      where: $.definitions..backupExpirationTime
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'backupExpireOn';
    - from: swagger-document
      where: $.definitions..expiryTime
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'ExpireOn';
    - from: swagger-document
      where: $.definitions..databaseDeletionTime
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'databaseDeletedOn';
    - from: swagger-document
      where: $.definitions..sourceDatabaseDeletionDate
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'sourceDatabaseDeletedOn';
    - from: swagger-document
      where: $.definitions..estimatedCompletionTime
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'estimatedCompleteOn';
    - from: SyncAgents.json
      where: $.definitions.SyncAgentProperties
      transform: >
          delete $.properties.name;
    - from: dataMasking.json
      where: $.definitions.DataMaskingRuleProperties
      transform: >
          delete $.properties.id;
    - from: JobAgents.json
      where: $.definitions.JobAgentProperties
      transform: >
          $.properties.databaseId['x-ms-format'] = 'arm-id';
    - from: ServerTrustGroups.json
      where: $.definitions.ServerInfo
      transform: >
          $.properties.serverId['x-ms-format'] = 'arm-id';
    - from: ManagedInstances.json
      where: $.definitions
      transform: >
          $.ServicePrincipal.properties.principalId['format'] = 'uuid';
          $.ServicePrincipal.properties.clientId['format'] = 'uuid';
    - from: swagger-document
      where: $.definitions..restorableDroppedDatabaseId
      transform: >
          $['x-ms-format'] = 'arm-id'
      reason: Only update the format of properties named 'restorableDroppedDatabaseId'. There is also a path parameter with the same name and should remain a string.
    - from: swagger-document
      where: $.definitions..emailAccountAdmins
      transform: >
          $['x-ms-client-name'] = 'SendToEmailAccountAdmins'
    - from: swagger-document
      where: $.definitions..lastChecked
      transform: >
          $['x-ms-client-name'] = 'LastCheckedOn'
    - from: swagger-document
      where: $.definitions..memoryOptimized
      transform: >
          $['x-ms-client-name'] = 'IsMemoryOptimized'
    - from: swagger-document
      where: $.definitions..zoneRedundant
      transform: >
          $['x-ms-client-name'] = 'IsZoneRedundant'
    - from: swagger-document
      where: $.definitions..autoRotationEnabled
      transform: >
          $['x-ms-client-name'] = 'IsAutoRotationEnabled'
    - from: swagger-document
      where: $.definitions..publicDataEndpointEnabled
      transform: >
          $['x-ms-client-name'] = 'IsPublicDataEndpointEnabled'
    - from: LocationCapabilities.json
      where: $.definitions.ManagedInstanceVcoresCapability.properties
      transform: >
          $.instancePoolSupported['x-ms-client-name'] = 'IsInstancePoolSupported';
          $.standaloneSupported['x-ms-client-name'] = 'IsStandaloneSupported';
    - from: swagger-document
      where: $.definitions..enabled
      transform: >
          if ($['type'] === 'boolean')
              $['x-ms-client-name'] = 'IsEnabled'
    - from: swagger-document
      where: $.definitions.ResourceWithWritableName
      transform: >
              $.properties.id['x-ms-format'] = 'arm-id';
    - from: Servers.json
      where: $.definitions.CheckNameAvailabilityResponse
      transform: >
          $['x-ms-client-name'] = 'SqlNameAvailabilityResponse';
          $.properties.available['x-ms-client-name'] = 'IsAvailable';
    - from: ManagedInstances.json
      where: $.definitions.ManagedInstancePecProperty
      transform: >
          $.properties.id['x-ms-format'] = 'arm-id';
    - from: Databases.json
      where: $.definitions.ResourceMoveDefinition
      transform: >
          $.properties.id['x-ms-format'] = 'arm-id';
    - from: FailoverGroups.json
      where: $.definitions.PartnerInfo
      transform: >
          $.properties.id['x-ms-format'] = 'arm-id';
    - from: Servers.json
      where: $.definitions.ServerPrivateEndpointConnection
      transform: >
          $.properties.id['x-ms-format'] = 'arm-id';
    - from: SyncAgents.json
      where: $.definitions.SyncAgentLinkedDatabaseProperties
      transform: >
          $.properties.databaseId['format'] = 'uuid';
    - from: Jobs.json
      where: $.definitions
      transform: >
          $.JobSchedule.properties.interval['format'] = 'duration';
    - from: ServerDevOpsAudit.json
      where: $.paths..parameters[?(@.name === 'devOpsAuditingSettingsName')]
      transform: >
        delete $.enum;
        delete $['x-ms-enum'];
        $.description = 'The name of the devops audit settings. This should always be Default.';
      reason: address breaking changes when upgrading ServerDevOpsAudit API version from 2020-11-01-preview to 2022-02-01-preview
    - from: ManagedDatabaseRestoreDetails.json
      where: $.definitions
      transform: >
        $.ManagedDatabaseRestoreDetailsProperties.properties.percentCompleted['x-ms-client-name'] = 'CompletedPercent';
        $.ManagedDatabaseRestoreDetailsProperties.properties.numberOfFilesDetected['x-ms-client-name'] = 'NumberOfFilesFound';
        $.ManagedDatabaseRestoreDetailsProperties.properties.unrestorableFiles['x-ms-client-name'] = 'UnrestorableFileList';
      reason: address breaking changes when upgrading ManagedDatabaseRestoreDetail API version from 2020-11-01-preview to 2022-02-01-preview
    - from: DatabaseSqlVulnerabilityAssessmentsSettings.json
      where: $.paths
      transform: >
        $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}'].get.parameters[3]['x-ms-enum']['name'] = 'VulnerabilityAssessmentName';
      reason: unify the name to ensure the right hierarchy
    - from: DatabaseSqlVulnerabilityAssessmentScanResult.json
      where: $.paths
      transform: >
        $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}/scanResults'].get.parameters[3]['x-ms-enum']['name'] = 'VulnerabilityAssessmentName';
        $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}/scanResults/{scanResultId}'].get.parameters[3]['x-ms-enum']['name'] = 'VulnerabilityAssessmentName';
      reason: unify the name to ensure the right hierarchy
    - from: SqlVulnerabilityAssessmentsSettings.json
      where: $.paths
      transform: >
        $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}'].get.parameters[2]['x-ms-enum']['name'] = 'VulnerabilityAssessmentName';
      reason: unify the name to ensure the right hierarchy
    - from: SqlVulnerabilityAssessmentScanResult.json
      where: $.paths
      transform: >
        $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}/scanResults'].get.parameters[2]['x-ms-enum']['name'] = 'VulnerabilityAssessmentName';
        $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/sqlVulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}/scanResults/{scanResultId}'].get.parameters[2]['x-ms-enum']['name'] = 'VulnerabilityAssessmentName';
      reason: unify the name to ensure the right hierarchy
    - from: Servers.json
      where: $.definitions.ServerProperties.properties.restrictOutboundNetworkAccess.enum
      transform: >
          $.push('SecuredByPerimeter');
      reason: Align the enum choices to avoid breaking changes of one enum split into two.
    - from: DataMaskingRules.json
      where: $.definitions.DataMaskingRuleProperties.properties.ruleState
      transform: >
          $['enum'] = [
              'Disabled',
              'Enabled'
            ];
    - from: DataMaskingPolicies.json
      where: $.definitions.DataMaskingPolicyProperties.properties.dataMaskingState
      transform: >
          $['enum'] = [
              'Disabled',
              'Enabled'
            ];
    - from: GeoBackupPolicies.json
      where: $.definitions.GeoBackupPolicyProperties.properties.state
      transform: >
          $['enum'] = [
              'Disabled',
              'Enabled'
            ];
    - from: DatabaseAdvisors.json
      where: $.definitions.RecommendedAction
      transform: >
          delete $.allOf;
          $.properties.id = {
            description: "Resource ID.",
            type: "string",
            readOnly: true
          };
          $.properties.name = {
            description: "Resource name.",
            type: "string",
            readOnly: true
          };
          $.properties.type = {
            description: "Resource type.",
            type: "string",
            readOnly: true
          };
    - from: DatabaseRecommendedActions.json
      where: $.definitions.RecommendedAction
      transform: >
          delete $.allOf;
          $.properties.id = {
            description: "Resource ID.",
            type: "string",
            readOnly: true
          };
          $.properties.name = {
            description: "Resource name.",
            type: "string",
            readOnly: true
          };
          $.properties.type = {
            description: "Resource type.",
            type: "string",
            readOnly: true
          };
    - from: ManagedInstances.json
      where: $.definitions.ManagedInstanceProperties.properties.provisioningState
      transform: >
          $['enum'] = [
              'Created',
              'InProgress',
              'Succeeded',
              'Failed',
              'Canceled',
              'Creating',
              'Deleting',
              'Updating',
              'Unknown',
              'Accepted',
              'Deleted',
              'Unrecognized',
              'Running',
              'NotSpecified',
              'Registering',
              'TimedOut'
          ];
          $['x-ms-enum']['name'] = 'ManagedInstancePropertiesProvisioningState';
    - from: ManagedInstanceOperations.json
      where: $.definitions.UpsertManagedServerOperationStepWithEstimatesAndDuration.properties.status
      transform: >
          $['enum'] = [
              'NotStarted',
              'InProgress',
              'SlowedDown',
              'Completed',
              'Failed',
              'Canceled'
          ];
          $['readOnly'] = true;
          $['x-ms-enum'] = {
            "name": "ManagementOperationStepState",
            "modelAsString": true
          };
    - from: DatabaseSecurityAlertPolicies.json
      where: $.paths
      transform: >
          $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}'].get.parameters[3]['enum'] = ['Default'];
          $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}'].put.parameters[3]['enum'] = ['Default'];
    - from: ManagedDatabaseSecurityAlertPolicies.json
      where: $.paths
      transform: >
          $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}'].get.parameters[3]['enum'] = ['Default'];
          $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}'].put.parameters[3]['enum'] = ['Default'];
    - from: ServerUsages.json
      where: $.definitions.ServerUsageProperties.properties
      transform: >
          $['resourceName'] = {
              "readOnly": true,
              "type": "string",
              "description": "The name of the resource."
            };
          $['nextResetTime'] = {
              "readOnly": true,
              "type": "string",
              "format": "date-time",
              "description": "The next reset time for the metric (ISO8601 format)."
            };
