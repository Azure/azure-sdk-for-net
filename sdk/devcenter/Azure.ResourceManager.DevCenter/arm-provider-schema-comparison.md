# ARM provider schema comparison: Azure.ResourceManager.DevCenter

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 resource model difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 29 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 29 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/networkconnections/{}/healthchecks/latest` | `Microsoft.DevCenter.HealthCheckStatusDetails` | `Microsoft.DevCenter.HealthCheckStatusDetails` | `Microsoft.DevCenter/networkConnections/healthChecks` | `Microsoft.DevCenter/networkConnections` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DevCenter.DevCenters.listByDevCenter` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/images` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 17 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/catalogs/{}/imagedefinitions/{}` | `DevCenterCatalogImageDefinition` | `CatalogsImageDefinitions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/catalogs/{}/imagedefinitions/{}/builds/{}` | `DevCenterCatalogImageDefinitionBuild` | `ImageDefinitionsBuilds` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/catalogs/{}/tasks/{}` | `DevCenterCatalogTask` | `CatalogsTasks` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/devboxdefinitions/{}` | `DevBoxDefinition` | `DevcentersDevboxdefinitions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/environmenttypes/{}` | `DevCenterEnvironmentType` | `EnvironmentType` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/galleries/{}` | `DevCenterGallery` | `Gallery` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/galleries/{}/images/{}/versions/{}` | `ImageVersion` | `ImagesVersions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/devcenters/{}/projectpolicies/{}` | `DevCenterProjectPolicy` | `ProjectPolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/networkconnections/{}` | `DevCenterNetworkConnection` | `NetworkConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/networkconnections/{}/healthchecks/latest` | `HealthCheckStatusDetail` | `HealthCheckStatusDetails` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}` | `DevCenterProject` | `Project` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}/catalogs/{}` | `ProjectCatalog` | `ProjectsCatalogs` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}/catalogs/{}/imagedefinitions/{}` | `ProjectCatalogImageDefinition` | `CatalogsImageDefinitions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}/catalogs/{}/imagedefinitions/{}/builds/{}` | `ProjectCatalogImageDefinitionBuild` | `ImageDefinitionsBuilds` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}/environmenttypes/{}` | `DevCenterProjectEnvironment` | `ProjectEnvironmentType` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}/pools/{}` | `DevCenterPool` | `Pool` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devcenter/projects/{}/pools/{}/schedules/{}` | `DevCenterSchedule` | `Schedule` |

