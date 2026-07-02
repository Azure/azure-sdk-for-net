# ARM provider schema comparison: Azure.ResourceManager.DataMigration

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 hierarchy differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 12 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 4 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 12 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 4 hierarchy differences.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}/projects/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}/projects/{}/files/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}/projects/{}/tasks/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}/servicetasks/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{groupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 8 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}` | `DataMigrationService` | `Services` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}/projects/{}` | `DataMigrationProject` | `ServicesProjects` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.datamigration/services/{}/projects/{}/files/{}` | `DataMigrationProjectFile` | `ProjectsFiles` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/databaseaccounts/{}/providers/microsoft.datamigration/databasemigrations/{}` | `DatabaseMigrationsMongoToCosmosDbRUMongo` | `DatabaseAccountsDatabaseMigrations` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.documentdb/mongoclusters/{}/providers/microsoft.datamigration/databasemigrations/{}` | `DatabaseMigrationsMongoToCosmosDbvCoreMongo` | `MongoClustersDatabaseMigrations` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/managedinstances/{}/providers/microsoft.datamigration/databasemigrations/{}` | `DatabaseMigrationSqlMI` | `ManagedInstancesDatabaseMigrations` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sql/servers/{}/providers/microsoft.datamigration/databasemigrations/{}` | `DatabaseMigrationSqlDB` | `ServersDatabaseMigrations` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.sqlvirtualmachine/sqlvirtualmachines/{}/providers/microsoft.datamigration/databasemigrations/{}` | `DatabaseMigrationSqlVm` | `SqlVirtualMachinesDatabaseMigrations` |

