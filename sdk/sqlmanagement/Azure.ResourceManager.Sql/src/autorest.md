# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/55090ea4342b5dac48bc2e9706e3a59465ffa34c/specification/sql/resource-manager/readme.md
namespace: Azure.ResourceManager.Sql
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
model-namespace: false
public-clients: false
head-as-boolean: false

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
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
  'partnerLocation': 'azure-location'
  'defaultSecondaryLocation': 'azure-location'

keep-plural-enums:
  - DiffBackupIntervalInHours

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
prepend-rp-prefix:
  - DatabaseAutomaticTuning
  - DatabaseBlobAuditingPolicy
  - DatabaseSecurityAlertPolicy
  - TimeZone
  - Metric
  - Server
  - Database
  - ServerAutomaticTuning
  - ServerAzureADAdministrator
  - ServerAzureADOnlyAuthentication
  - ServerBlobAuditingPolicy
  - ServerCommunicationLink
  - ServerConnectionPolicy
  - ServerDnsAlias
  - ServerKey
  - ServerSecurityAlertPolicy
  - ServerTrustGroup
  - ServerVulnerabilityAssessment
rename-mapping:
  Job: SqlServerJob
  JobAgent: SqlServerJobAgent
  JobVersion: SqlServerJobVersion
  JobCredential: SqlServerJobCredential
  JobTargetGroup: SqlServerJobTargetGroup
  LedgerDigestUploads: LedgerDigestUpload
  ServerDevOpsAuditingSettings: SqlServerDevOpsAuditingSetting
  ManagedDatabaseRestoreDetailsResult: ManagedDatabaseRestoreDetail
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/restoreDetails/{restoreDetailsName}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}

no-property-type-replacement: ResourceMoveDefinition

override-operation-name:
  ServerTrustGroups_ListByInstance: GetServerTrustGroups
  ManagedInstances_ListByManagedInstance: GetTopQueries
  ManagedDatabases_ListInaccessibleByInstance: GetInaccessibleManagedDatabases
  ManagedDatabaseQueries_ListByQuery: GetQueryStatistics
  Metrics_ListDatabase: GetMetrics
  MetricDefinitions_ListDatabase: GetMetricDefinitions
  Metrics_ListElasticPool: GetMetrics
  MetricDefinitions_ListElasticPool: GetMetricDefinitions
  Capabilities_ListByLocation: GetCapabilitiesByLocation

request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/queries/{queryId}

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}/backupShortTermRetentionPolicies/{policyName}: ManagedRestorableDroppedDbBackupShortTermRetentionPolicy
  /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName}: SubscriptionLongTermRetentionManagedInstanceBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName}: ResourceGroupLongTermRetentionManagedInstanceBackup
  /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}: SubscriptionLongTermRetentionBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}: ResourceGroupLongTermRetentionBackup
<<<<<<< HEAD
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
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}: ManagedDatabaseTable
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}: ManagedDatabaseColumn
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}: ManagedDatabaseSensitivityLabel
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}: ManagedDatabaseVulnerabilityAssessment
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}: ManagedDatabaseVulnerabilityAssessmentRuleBaseline
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/scans/{scanId}: ManagedDatabaseVulnerabilityAssessmentScan
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}: SqlServerAdvisor
  
=======

rename-mapping:
  CopyLongTermRetentionBackupParameters: CopyLongTermRetentionBackupContent
  UpdateLongTermRetentionBackupParameters: UpdateLongTermRetentionBackupContent
  Name: InstancePoolUsageName
  Usage: InstancePoolUsage
  Usage.type: ResourceType
  UsageListResult: InstancePoolUsageListResult
  TimeZone: SqlTimeZone
  Metric: SqlMetric
  Server: SqlServer
  Database: SqlDatabase
  Job: SqlJob
  SyncGroupsType: SyncGroupLogType
  SampleName: SampleSchemaName
  DayOfWeek: SqlDayOfWeek
  ManagedInstancePrivateEndpointConnection.properties.privateLinkServiceConnectionState: ConnectionState
  RestorePoint.properties.restorePointCreationDate: restorePointCreatedOn

>>>>>>> f0d32c9e536b98383aa488bbc29730d50ba25734
directive:
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
<<<<<<< HEAD
    - rename-model:
        from: UnlinkParameters
        to: UnlinkOptions
    - rename-model:
        from: CopyLongTermRetentionBackupParameters
        to: CopyLongTermRetentionBackupOptions
    - rename-model:
        from: UpdateLongTermRetentionBackupParameters
        to: UpdateLongTermRetentionBackupOptions
    - rename-model:
        from: Name
        to: UsageName
    - rename-model:
        from: Usage
        to: InstancePoolUsage
    - rename-model:
        from: UsageListResult
        to: InstancePoolUsageListResult
    - from: BlobAuditing.json
      where: $.parameters.BlobAuditingPolicyNameParameter
      transform: >
          $['x-ms-enum'] = {
              "name": "BlobAuditingPolicyName",
              "modelAsString": true
          }
    - from: SyncGroups.json
      where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/syncGroups/{syncGroupName}/logs'].get.parameters[?(@.name === "type")]
      transform: >
          $['x-ms-enum'] = {
              "name": "SyncGroupLogType",
              "modelAsString": true
          }
    - from: Databases.json
      where: $.definitions.DatabaseProperties.properties.sampleName['x-ms-enum']
      transform: >
          $['name'] = "SampleSchemaName"
    - from: Databases.json
      where: $.definitions.DatabaseUpdateProperties.properties.sampleName['x-ms-enum']
=======
    # add format to Usage
    - from: Usages.json
      where: $.definitions.Usage.properties
>>>>>>> f0d32c9e536b98383aa488bbc29730d50ba25734
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
      where: $.definitions..creationDate
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'createdOn';
    - from: swagger-document
      where: $.definitions..creationTime
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'createdOn';
    - from: swagger-document
      where: $.definitions..deletionDate
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'deletedOn';
    - from: swagger-document
      where: $.definitions..deletionTime
      transform: >
          if ($.format === 'date-time')
              $['x-ms-client-name'] = 'deletedOn';
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
<<<<<<< HEAD
    - from: swagger-document
      where: $.definitions..emailAccountAdmins
      transform: >
          $['x-ms-client-name'] = 'SendToEmailAccountAdmins'
    - from: swagger-document
      where: $.definitions..lastChecked
      transform: >
          $['x-ms-client-name'] = 'LastCheckedOn'
=======
```
>>>>>>> f0d32c9e536b98383aa488bbc29730d50ba25734
