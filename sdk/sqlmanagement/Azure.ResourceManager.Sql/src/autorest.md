# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
use: $(this-folder)/../../../../../autorest.csharp/artifacts/bin/AutoRest.CSharp/Debug/netcoreapp3.1/
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/47e46d4eab3ea98d7578d51c404b1ca4405fdb76/specification/sql/resource-manager/readme.md
namespace: Azure.ResourceManager.Sql
model-namespace: false
public-clients: false
head-as-boolean: false
clear-output-folder: true
modelerfour:
  lenient-model-deduplication: true
  seal-single-value-enum-by-default: true
skip-csproj: true
show-request-path: true
request-path-to-singleton-resource:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/automaticTuning/current: automaticTuning/current
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/maintenanceWindowOptions/current: maintenanceWindowOptions/current
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/maintenanceWindows/current: maintenanceWindows/current
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/sqlAgent/current: sqlAgent/current
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/automaticTuning/current: automaticTuning/current
list-exception: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName};/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/deletedServers/{deletedServerName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/instanceFailoverGroups/{failoverGroupName};/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionServers/{longTermRetentionServerName}/longTermRetentionDatabases/{longTermRetentionDatabaseName}/longTermRetentionBackups/{backupName};/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/longTermRetentionManagedInstances/{managedInstanceName}/longTermRetentionDatabases/{databaseName}/longTermRetentionManagedInstanceBackups/{backupName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/queries/{queryId};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/restoreDetails/{restoreDetailsName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/serverTrustGroups/{serverTrustGroupName};/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/usages/{usageName};/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationName}/timeZones/{timeZoneId};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataMaskingPolicies/{dataMaskingPolicyName};/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName};
no-property-type-replacement: ResourceMoveDefinition
directive:
    # - remove-operation: FirewallRules_Replace
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
        from: ManagedDatabaseQueries_ListByQuery
        to: ManagedDatabaseQueries_GetQueryStatistics
    - from: BlobAuditing.json
      where: $.parameters.BlobAuditingPolicyNameParameter
      transform: >
          $['x-ms-enum'] = {
              "name": "BlobAuditingPolicyName",
              "modelAsString": true
          }
```
