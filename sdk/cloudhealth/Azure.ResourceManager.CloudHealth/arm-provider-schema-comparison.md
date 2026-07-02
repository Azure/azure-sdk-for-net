# ARM provider schema comparison: Azure.ResourceManager.CloudHealth

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

5 CRUD operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 6 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 5 differences. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 6 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 5 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/authenticationsettings/{authenticationSettingName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.CloudHealth.AuthenticationSettings.createOrUpdateV1` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/authenticationsettings/{authenticationSettingName}` | Missing. | Present. |
| `Microsoft.CloudHealth.AuthenticationSettings.deleteV1` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/authenticationsettings/{authenticationSettingName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/discoveryrules/{discoveryRuleName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.CloudHealth.DiscoveryRules.createOrUpdateV1` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/discoveryrules/{discoveryRuleName}` | Missing. | Present. |
| `Microsoft.CloudHealth.DiscoveryRules.deleteV1` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/discoveryrules/{discoveryRuleName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/entities/{entityName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.CloudHealth.Entities.createOrUpdateV1` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/entities/{entityName}` | Missing. | Present. |
| `Microsoft.CloudHealth.Entities.deleteV1` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/entities/{entityName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/relationships/{relationshipName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.CloudHealth.Relationships.createOrUpdateV1` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/relationships/{relationshipName}` | Missing. | Present. |
| `Microsoft.CloudHealth.Relationships.deleteV1` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/relationships/{relationshipName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/signaldefinitions/{signalDefinitionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.CloudHealth.SignalDefinitions.createOrUpdateV1` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/signaldefinitions/{signalDefinitionName}` | Missing. | Present. |
| `Microsoft.CloudHealth.SignalDefinitions.deleteV1` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CloudHealth/healthmodels/{healthModelName}/signaldefinitions/{signalDefinitionName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 5 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cloudhealth/healthmodels/{}/authenticationsettings/{}` | `HealthModelAuthenticationSetting` | `AuthenticationSetting` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cloudhealth/healthmodels/{}/discoveryrules/{}` | `HealthModelDiscoveryRule` | `DiscoveryRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cloudhealth/healthmodels/{}/entities/{}` | `HealthModelEntity` | `Entity` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cloudhealth/healthmodels/{}/relationships/{}` | `HealthModelRelationship` | `Relationship` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.cloudhealth/healthmodels/{}/signaldefinitions/{}` | `HealthModelSignalDefinition` | `SignalDefinition` |

