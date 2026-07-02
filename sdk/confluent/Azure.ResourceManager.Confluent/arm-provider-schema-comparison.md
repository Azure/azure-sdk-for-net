# ARM provider schema comparison: Azure.ResourceManager.Confluent

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

5 CRUD operation differences; 3 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 5 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 5 differences. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 5 | Matching normalized resource ID patterns are compared in the following sections. |
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

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.OrganizationResourceAPIKeyActions.deleteClusterAPIKey` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/apiKeys/{apiKeyId}` | Missing. | Present. |
| `Microsoft.Confluent.OrganizationResourceRoleBindingIdActions.deleteRoleBinding` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/access/default/deleteRoleBinding/{roleBindingId}` | Missing. | Present. |
| `Microsoft.Confluent.OrganizationResources.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}` | Present. | Missing. |
| `Microsoft.Confluent.OrganizationResources.update` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.SCEnvironmentRecords.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.SCClusterRecords.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}/connectors/{connectorName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.ConnectorResources.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}/connectors/{connectorName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}/topics/{topicName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.TopicRecords.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}/topics/{topicName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 3 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.OrganizationResourceAPIKeyActions.deleteClusterAPIKey` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/apiKeys/{apiKeyId}` | Present. | Missing. |
| `Microsoft.Confluent.OrganizationResourceRoleBindingIdActions.deleteRoleBinding` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/access/default/deleteRoleBinding/{roleBindingId}` | Present. | Missing. |
| `Microsoft.Confluent.SCEnvironmentRecords.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.SCClusterRecords.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Confluent.ConnectorResources.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}/connectors/{connectorName}` | Missing. | Present. |
| `Microsoft.Confluent.TopicRecords.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}/environments/{environmentId}/clusters/{clusterId}/topics/{topicName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 2 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 3 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.confluent/organizations/{}` | `ConfluentOrganization` | `OrganizationResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.confluent/organizations/{}/environments/{}/clusters/{}/connectors/{}` | `ConfluentConnector` | `ConnectorResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.Confluent.Operations.list` | `/providers/Microsoft.Confluent/operations` | Missing. | Present. |
| `Microsoft.Confluent.OrganizationResources.create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}` | Missing. | Present. |
| `Microsoft.Confluent.OrganizationResources.update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Confluent/organizations/{organizationName}` | Missing. | Present. |

