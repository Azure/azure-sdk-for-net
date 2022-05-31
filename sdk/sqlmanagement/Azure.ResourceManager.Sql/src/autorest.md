# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/55090ea4342b5dac48bc2e9706e3a59465ffa34c/specification/sql/resource-manager/readme.md
namespace: Azure.ResourceManager.Sql
output-folder: $(this-folder)/Generated
model-namespace: false
public-clients: false
head-as-boolean: false
clear-output-folder: true
skip-csproj: true

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
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
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri

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
request-path-is-non-resource:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/queries/{queryId}
request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}/backupShortTermRetentionPolicies/{policyName}: ManagedRestorableDroppedDbBackupShortTermRetentionPolicy
  /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName}: SubscriptionLongTermRetentionManagedInstanceBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName}: ResourceGroupLongTermRetentionManagedInstanceBackup
  /subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}: SubscriptionLongTermRetentionBackup
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName}: ResourceGroupLongTermRetentionBackup

directive:
    - remove-operation: DatabaseExtensions_Get
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
    - rename-model:
        from: TimeZone
        to: SqlTimeZone
    - rename-model:
        from: Metric
        to: SqlMetric
    - rename-model:
        from: Server
        to: SqlServer
    - rename-model:
        from: Database
        to: SqlDatabase
    - rename-model:
        from: Job
        to: SqlJob
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
      transform: >
          $['name'] = "SampleSchemaName"
    - from: MaintenanceWindows.json
      where: $.definitions.MaintenanceWindowTimeRange.properties.dayOfWeek['x-ms-enum']
      transform: >
          $['name'] = "SqlDayOfWeek"
    - from: MaintenanceWindowOptions.json
      where: $.definitions.MaintenanceWindowTimeRange.properties.dayOfWeek['x-ms-enum']
      transform: >
          $['name'] = "SqlDayOfWeek"
    - from: swagger-document #DatabaseRecommendedActions.json, DatabaseAdvisors.json, ServerAdvisors.json
      where: $.definitions.RecommendedActionProperties.properties
      transform: >
          $.executeActionDuration.format = "duration";
          $.revertActionDuration.format = "duration";
    - from: swagger-document #MaintenanceWindows.json, MaintenanceWindowOptions.json
      where: $.definitions.MaintenanceWindowTimeRange.properties.duration
      transform: >
          $.format = "duration";
# shorten "privateLinkServiceConnectionState" property name
    - from: ManagedInstances.json
      where: $.definitions.ManagedInstancePrivateEndpointConnectionProperties
      transform: >
          $.properties.privateLinkServiceConnectionState["x-ms-client-name"] = "connectionState";
    - from: ManagedInstancePrivateEndpointConnections.json
      where: $.definitions.ManagedInstancePrivateEndpointConnectionProperties
      transform: >
          $.properties.privateLinkServiceConnectionState["x-ms-client-name"] = "connectionState";
```
