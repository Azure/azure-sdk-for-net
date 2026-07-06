# ARM provider schema comparison: Azure.ResourceManager.Resources.DeploymentStacks

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 6 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 2 matching normalized patterns; 0 legacy-only; 6 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 6 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 2 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 6 | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{deploymentStacksWhatIfResultName}`<br>`/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}`<br>`/subscriptions/{subscriptionId}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{deploymentStacksWhatIfResultName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentStacksWhatIfResults/{deploymentStacksWhatIfResultName}` |

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

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Bicep reference validation

Resource type validity was checked against the public Bicep reference by opening `https://learn.microsoft.com/en-us/azure/templates/{resourceType}?pivots=deployment-language-bicep`. For resources that exist, the Bicep API versions were compared with this package's generated API versions.

| Metric | Count |
| --- | ---: |
| Checked rows | 6 |
| Found in Bicep reference | 6 |
| Found in package API version | 6 |
| Found only outside package API versions | 0 |
| Not found in Bicep reference | 0 |

**Result:** The six `resolveArmResources`-only rows are not new resource types. They are concrete scope-specific expansions of the same two resources that the legacy detector represents with generic `/{scope}` paths. Bicep confirms the resource types exist in `2025-07-01`.

Legacy C# intentionally scopes out the resource-group/subscription/management-group specific interfaces and exposes a generic `DeploymentStacksAtScope` / `DeploymentStacksWhatIfAtScope` shape for C#:

```typespec
@@scope(DeploymentStacksAtResourceGroup.get, "!csharp");
@@scope(DeploymentStacksAtSubscription.get, "!csharp");
@@scope(DeploymentStacksAtManagementGroup.get, "!csharp");
@@armResourceOperations(DeploymentStacksAtScope);
@@scope(DeploymentStacksAtScope.get, "csharp");
```

Therefore this is primarily a representation mismatch: `resolveArmResources` returns both generic `/{scope}` and concrete expanded paths, while the legacy detector only keeps the generic C# projection.

| Side | Resource type | Concrete path shape | Bicep API versions | Package resource API versions |
| --- | --- | --- | --- | --- |
| `resolveArmResources` only | [Microsoft.Resources/deploymentStacks](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/deploymentstacks?pivots=deployment-language-bicep) | Management group | `2025-07-01` | None |
| `resolveArmResources` only | [Microsoft.Resources/deploymentStacksWhatIfResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/deploymentstackswhatifresults?pivots=deployment-language-bicep) | Management group | `2025-07-01` | None |
| `resolveArmResources` only | [Microsoft.Resources/deploymentStacks](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/deploymentstacks?pivots=deployment-language-bicep) | Subscription | `2025-07-01` | None |
| `resolveArmResources` only | [Microsoft.Resources/deploymentStacksWhatIfResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/deploymentstackswhatifresults?pivots=deployment-language-bicep) | Subscription | `2025-07-01` | None |
| `resolveArmResources` only | [Microsoft.Resources/deploymentStacks](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/deploymentstacks?pivots=deployment-language-bicep) | Resource group | `2025-07-01` | None |
| `resolveArmResources` only | [Microsoft.Resources/deploymentStacksWhatIfResults](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/deploymentstackswhatifresults?pivots=deployment-language-bicep) | Resource group | `2025-07-01` | None |
