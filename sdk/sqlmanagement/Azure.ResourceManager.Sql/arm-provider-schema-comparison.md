# ARM provider schema comparison: Azure.ResourceManager.Sql

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 3 resolve-only normalized resource ID patterns; 5 hierarchy differences; 5 resource model differences; 2 CRUD operation differences; 12 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 125 matching normalized patterns; 2 legacy-only; 3 resolve-only. |
| Hierarchy for matching patterns | 5 differences. |
| Resource model for matching patterns | 5 differences. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 12 differences. |

## 1. Resource ID pattern coverage

**Differences:** 2 legacy-only normalized pattern(s), 3 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 125 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}` |
| `resolveArmResources` only | 3 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/locations/{locationName}/managedDatabaseMoveOperationResults/{operationId}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extensions/{extensionName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/privateEndpoints/{privateEndpointName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 5 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.sql/locations/{}/deletedservers/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/microsoft.sql/locations/{}/timezones/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/providers/microsoft.sql/locations/{}/usages/{}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/locations/{}/longtermretentionmanagedinstances/{}/longtermretentiondatabases/{}/longtermretentionmanagedinstancebackups/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/locations/{}/longtermretentionservers/{}/longtermretentiondatabases/{}/longtermretentionbackups/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 5 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/sqlagent/current` | `Microsoft.Sql.SqlAgentConfiguration` | `Microsoft.Sql.SqlAgentConfiguration` | `Microsoft.Sql/managedInstances/sqlAgent` | `Microsoft.Sql/managedInstances` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/automatictuning/current` | `Microsoft.Sql.ServerAutomaticTuning` | `Microsoft.Sql.ServerAutomaticTuning` | `Microsoft.Sql/servers/automaticTuning` | `Microsoft.Sql/servers` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/automatictuning/current` | `Microsoft.Sql.DatabaseAutomaticTuning` | `Microsoft.Sql.DatabaseAutomaticTuning` | `Microsoft.Sql/servers/databases/automaticTuning` | `Microsoft.Sql/servers/databases` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/maintenancewindowoptions/current` | `Microsoft.Sql.MaintenanceWindowOptions` | `Microsoft.Sql.MaintenanceWindowOptions` | `Microsoft.Sql/servers/databases/maintenanceWindowOptions` | `Microsoft.Sql/servers/databases` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/maintenancewindows/current` | `Microsoft.Sql.MaintenanceWindows` | `Microsoft.Sql.MaintenanceWindows` | `Microsoft.Sql/servers/databases/maintenanceWindows` | `Microsoft.Sql/servers/databases` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.SensitivityLabels.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}` | Missing. | Present. |
| `Microsoft.Sql.SensitivityLabels.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.SensitivityLabelOperationGroup.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}` | Missing. | Present. |
| `Microsoft.Sql.SensitivityLabelOperationGroup.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 12 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.InstancePools.listByInstancePool` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/instancePools/{instancePoolName}/managedInstances` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.ManagedInstances.listByInstance` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/serverTrustGroups` | Different. | Different. |
| `Microsoft.Sql.ManagedInstances.listInaccessibleByInstance` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/inaccessibleManagedDatabases` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.ManagedDatabases.listByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/columns` | Different. | Different. |
| `Microsoft.Sql.ManagedDatabases.listCurrentByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/currentSensitivityLabels` | Different. | Different. |
| `Microsoft.Sql.ManagedDatabases.listRecommendedByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/recommendedSensitivityLabels` | Different. | Different. |
| `Microsoft.Sql.ManagedDatabases.managedDatabaseSensitivityLabelsListByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/sensitivityLabels` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.SensitivityLabels.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/current` | Present. | Missing. |
| `Microsoft.Sql.SensitivityLabels.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/current` | Present. | Missing. |
| `Microsoft.Sql.SensitivityLabels.disableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/recommended/disable` | Present. | Missing. |
| `Microsoft.Sql.SensitivityLabels.enableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/recommended/enable` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.SensitivityLabels.disableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}/disable` | Missing. | Present. |
| `Microsoft.Sql.SensitivityLabels.enableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}/enable` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.FirewallRules.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}` | Missing. | Present. |
| `Microsoft.Sql.FirewallRules.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}` | Missing. | Present. |
| `Microsoft.Sql.FirewallRules.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules/{firewallRuleName}` | Missing. | Present. |
| `Microsoft.Sql.FirewallRules.listByServer` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules` | Missing. | Present. |
| `Microsoft.Sql.IPv6FirewallRules.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}` | Missing. | Present. |
| `Microsoft.Sql.IPv6FirewallRules.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}` | Missing. | Present. |
| `Microsoft.Sql.IPv6FirewallRules.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules/{firewallRuleName}` | Missing. | Present. |
| `Microsoft.Sql.IPv6FirewallRules.listByServer` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/ipv6FirewallRules` | Missing. | Present. |
| `Microsoft.Sql.Servers.listByServer` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/replicationLinks` | Different. | Different. |
| `Microsoft.Sql.Servers.listInaccessibleByServer` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/inaccessibleDatabases` | Different. | Different. |
| `Microsoft.Sql.Servers.replace` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/firewallRules` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.Databases.listByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/columns` | Different. | Different. |
| `Microsoft.Sql.Databases.listCurrentByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/currentSensitivityLabels` | Different. | Different. |
| `Microsoft.Sql.Databases.listRecommendedByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/recommendedSensitivityLabels` | Different. | Different. |
| `Microsoft.Sql.Databases.sensitivityLabelsListByDatabase` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/sensitivityLabels` | Different. | Different. |
| `Microsoft.Sql.ImportExportExtensionsOperationResults.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extensions/{extensionName}` | Present. | Missing. |
| `Microsoft.Sql.ImportExportExtensionsOperationResults.listByDatabase` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extensions` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.SensitivityLabelOperationGroup.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/current` | Present. | Missing. |
| `Microsoft.Sql.SensitivityLabelOperationGroup.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/current` | Present. | Missing. |
| `Microsoft.Sql.SensitivityLabelOperationGroup.disableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/recommended/disable` | Present. | Missing. |
| `Microsoft.Sql.SensitivityLabelOperationGroup.enableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/recommended/enable` | Present. | Missing. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.SensitivityLabelOperationGroup.disableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}/disable` | Missing. | Present. |
| `Microsoft.Sql.SensitivityLabelOperationGroup.enableRecommendation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}/enable` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.ElasticPools.listByElasticPool` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/elasticPools/{elasticPoolName}/databases` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.JobAgents.listByAgent` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/executions` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Sql.JobTargetExecutions.listByJobExecution` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/jobAgents/{jobAgentName}/jobs/{jobName}/executions/{jobExecutionId}/targets` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 41 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.sql/locations/{}/deletedservers/{}` | `DeletedServer` | `LocationsDeletedServers` |
| `/subscriptions/{}/providers/microsoft.sql/locations/{}/timezones/{}` | `SqlTimeZone` | `LocationsTimeZones` |
| `/subscriptions/{}/providers/microsoft.sql/locations/{}/usages/{}` | `SubscriptionUsage` | `LocationsUsages` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/instancepools/{}/operations/{}` | `SqlInstancePoolOperation` | `InstancePoolOperation` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/locations/{}/instancefailovergroups/{}` | `InstanceFailoverGroup` | `LocationsInstanceFailoverGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/locations/{}/servertrustgroups/{}` | `SqlServerTrustGroup` | `LocationsServerTrustGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/databases/{}/ledgerdigestuploads/{}` | `ManagedLedgerDigestUpload` | `ManagedLedgerDigestUploads` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/databases/{}/restoredetails/{}` | `ManagedDatabaseRestoreDetail` | `ManagedDatabaseRestoreDetailsResult` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/distributedavailabilitygroups/{}` | `SqlDistributedAvailabilityGroup` | `DistributedAvailabilityGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/serverconfigurationoptions/{}` | `ManagedInstanceServerConfigurationOption` | `ServerConfigurationOption` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/startstopschedules/{}` | `ManagedInstanceStartStopSchedule` | `StartStopManagedInstanceSchedule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}` | `SqlServer` | `Server` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/administrators/{}` | `SqlServerAzureADAdministrator` | `ServerAzureADAdministrator` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/automatictuning/current` | `SqlServerAutomaticTuning` | `ServerAutomaticTuning` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/azureadonlyauthentications/{}` | `SqlServerAzureADOnlyAuthentication` | `ServerAzureADOnlyAuthentication` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/connectionpolicies/{}` | `SqlServerConnectionPolicy` | `ServerConnectionPolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}` | `SqlDatabase` | `Database` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/auditingsettings/{}` | `SqlDatabaseBlobAuditingPolicy` | `DatabasesAuditingSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/automatictuning/current` | `SqlDatabaseAutomaticTuning` | `DatabaseAutomaticTuning` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/datawarehouseuseractivities/{}` | `DataWarehouseUserActivity` | `DataWarehouseUserActivities` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/extendedauditingsettings/{}` | `ExtendedDatabaseBlobAuditingPolicy` | `DatabasesExtendedAuditingSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/ledgerdigestuploads/{}` | `LedgerDigestUpload` | `LedgerDigestUploads` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/maintenancewindowoptions/current` | `MaintenanceWindowOption` | `MaintenanceWindowOptions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/replicationlinks/{}` | `SqlServerDatabaseReplicationLink` | `ReplicationLink` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/restorepoints/{}` | `SqlServerDatabaseRestorePoint` | `RestorePoint` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/databases/{}/securityalertpolicies/{}` | `SqlDatabaseSecurityAlertPolicy` | `DatabaseSecurityAlertPolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/devopsauditingsettings/{}` | `SqlServerDevOpsAuditingSetting` | `ServerDevOpsAuditingSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/dnsaliases/{}` | `SqlServerDnsAlias` | `ServerDnsAlias` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/extendedauditingsettings/{}` | `ExtendedServerBlobAuditingPolicy` | `ServersExtendedAuditingSettings` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/jobagents/{}` | `SqlServerJobAgent` | `JobAgent` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/jobagents/{}/credentials/{}` | `SqlServerJobCredential` | `JobCredential` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/jobagents/{}/jobs/{}` | `SqlServerJob` | `Job` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/jobagents/{}/jobs/{}/versions/{}` | `SqlServerJobVersion` | `JobsVersions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/jobagents/{}/targetgroups/{}` | `SqlServerJobTargetGroup` | `JobTargetGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/keys/{}` | `SqlServerKey` | `ServerKey` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/networksecurityperimeterconfigurations/{}` | `SqlNetworkSecurityPerimeterConfiguration` | `NetworkSecurityPerimeterConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/privateendpointconnections/{}` | `SqlPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/privatelinkresources/{}` | `SqlPrivateLinkResource` | `PrivateLinkResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/securityalertpolicies/{}` | `SqlServerSecurityAlertPolicy` | `ServerSecurityAlertPolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/virtualnetworkrules/{}` | `SqlServerVirtualNetworkRule` | `VirtualNetworkRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/vulnerabilityassessments/{}` | `SqlServerVulnerabilityAssessment` | `ServerVulnerabilityAssessment` |

