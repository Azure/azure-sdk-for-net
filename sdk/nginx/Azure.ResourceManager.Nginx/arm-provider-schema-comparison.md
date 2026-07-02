# ARM provider schema comparison: Azure.ResourceManager.Nginx

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 5 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 4 differences. |
| List/action operations for matching patterns | 1 difference. |

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

**Differences:** 4 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Nginx.NginxPlus.NginxDeployments.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/certificates/{certificateName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Nginx.NginxPlus.NginxCertificates.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/certificates/{certificateName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Nginx.NginxPlus.NginxConfigurationResponses.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName}` | Present. | Missing. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/wafPolicies/{wafPolicyName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Nginx.NginxPlus.NginxDeploymentWafPolicies.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/wafPolicies/{wafPolicyName}` | Present. | Missing. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Nginx.NginxPlus.NginxCertificates.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/certificates/{certificateName}` | Missing. | Present. |
| `Nginx.NginxPlus.NginxConfigurationResponses.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName}` | Missing. | Present. |
| `Nginx.NginxPlus.NginxDeploymentWafPolicies.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/wafPolicies/{wafPolicyName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 2 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/nginx.nginxplus/nginxdeployments/{}/apikeys/{}` | `NginxDeploymentApiKey` | `NginxDeploymentApiKeyResponse` |
| `/subscriptions/{}/resourcegroups/{}/providers/nginx.nginxplus/nginxdeployments/{}/configurations/{}` | `NginxConfiguration` | `NginxConfigurationResponse` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Nginx.NginxPlus.NginxDeployments.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}` | Missing. | Present. |

