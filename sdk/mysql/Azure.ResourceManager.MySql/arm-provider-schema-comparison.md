# ARM provider schema comparison: Azure.ResourceManager.MySql

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns; 1 CRUD operation difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 11 matching normalized patterns; 0 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 1 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 11 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/privateLinkResources/{groupName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/backupsV2/{backupName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DBforMySQL.LongRunningBackup.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/backupsV2/{backupName}` | Present. | Missing. |
| `Microsoft.DBforMySQL.LongRunningBackup.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/backupsV2/{backupName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DBforMySQL.LongRunningBackup.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/backupsV2/{backupName}` | Missing. | Present. |
| `Microsoft.DBforMySQL.Replicas.listByServer` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}/replicas` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 10 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 3 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.dbformysql/locations/{}/capabilitysets/{}` | `MySqlFlexibleServersCapability` | `LocationsCapabilitySets` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}` | `MySqlFlexibleServer` | `Server` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/administrators/{}` | `MySqlFlexibleServerAadAdministrator` | `AzureADAdministrator` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/backups/{}` | `MySqlFlexibleServerBackup` | `ServerBackup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/backupsv2/{}` | `MySqlFlexibleServerBackupV2` | `ServerBackupV2` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/configurations/{}` | `MySqlFlexibleServerConfiguration` | `Configuration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/databases/{}` | `MySqlFlexibleServerDatabase` | `Database` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/firewallrules/{}` | `MySqlFlexibleServerFirewallRule` | `FirewallRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/maintenances/{}` | `MySqlFlexibleServerMaintenance` | `Maintenance` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.dbformysql/flexibleservers/{}/privateendpointconnections/{}` | `MySqlFlexibleServersPrivateEndpointConnection` | `ServerPrivateEndpointConnection` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.DBforMySQL.OperationProgress.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/operationProgress/{operationId}` | Missing. | Present. |
| `Microsoft.DBforMySQL.OperationResults.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/operationResults/{operationId}` | Missing. | Present. |
| `Microsoft.DBforMySQL.Operations.list` | `/providers/Microsoft.DBforMySQL/operations` | Missing. | Present. |

