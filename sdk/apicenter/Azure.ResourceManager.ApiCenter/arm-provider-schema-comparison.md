# ARM provider schema comparison: Azure.ResourceManager.ApiCenter

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 10 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 4 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 10 | Matching normalized resource ID patterns are compared in the following sections. |
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

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 4 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiCenter.MetadataSchemas.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/metadataSchemas/{metadataSchemaName}` | Missing. | Present. |
| `Microsoft.ApiCenter.Workspaces.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiCenter.ApiSources.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apiSources/{apiSourceName}` | Missing. | Present. |
| `Microsoft.ApiCenter.Apis.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}` | Missing. | Present. |
| `Microsoft.ApiCenter.Environments.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/environments/{environmentName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiCenter.ApiVersions.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}` | Missing. | Present. |
| `Microsoft.ApiCenter.Deployments.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/deployments/{deploymentName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.ApiCenter.ApiDefinitions.head` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}/definitions/{definitionName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 9 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/deletedservices/{}` | `ApiCenterDeletedService` | `DeletedService` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}` | `ApiCenterService` | `Service` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/metadataschemas/{}` | `ApiCenterMetadataSchema` | `MetadataSchema` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/workspaces/{}` | `ApiCenterWorkspace` | `Workspace` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/workspaces/{}/apis/{}` | `ApiCenterApi` | `Api` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/workspaces/{}/apis/{}/deployments/{}` | `ApiCenterDeployment` | `Deployment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/workspaces/{}/apis/{}/versions/{}` | `ApiCenterApiVersion` | `ApiVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/workspaces/{}/apis/{}/versions/{}/definitions/{}` | `ApiCenterApiDefinition` | `ApiDefinition` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.apicenter/services/{}/workspaces/{}/environments/{}` | `ApiCenterEnvironment` | `Environment` |

