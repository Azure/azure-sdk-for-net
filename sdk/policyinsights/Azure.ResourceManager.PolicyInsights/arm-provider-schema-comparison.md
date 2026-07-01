# ARM provider schema comparison: Azure.ResourceManager.PolicyInsights

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 2 resolve-only resource ID patterns; 1 list/action operation difference.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 1 matching patterns; 2 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 2 legacy-only pattern(s), 2 resolve-only pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 1 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 2 | `/{resourceId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}`<br>`/{resourceId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}` |
| `resolveArmResources` only | 2 | `/providers/{managementGroupsNamespace}/managementGroups/{managementGroupId}/providers/Microsoft.PolicyInsights/remediations/{remediationName}`<br>`/subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/attestations/{attestationName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List/action operation differences: `/providers/Microsoft.PolicyInsights/policyMetadata/{resourceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `PolicyInsightsApi.PolicyMetadataNonResourceOperationGroup.list` | `List` | `/providers/Microsoft.PolicyInsights/policyMetadata` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 2 non-resource method difference(s) were found.

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `PolicyInsightsApi.Operations.list` | `/providers/Microsoft.PolicyInsights/operations` | Missing. | Present. |
| `PolicyInsightsApi.PolicyMetadataNonResourceOperationGroup.list` | `/providers/Microsoft.PolicyInsights/policyMetadata` | Present. | Missing. |

