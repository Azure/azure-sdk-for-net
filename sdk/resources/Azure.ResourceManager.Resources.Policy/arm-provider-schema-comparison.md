# ARM provider schema comparison: Azure.ResourceManager.Resources.Policy

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 11 resolve-only resource ID patterns; 2 hierarchy differences; 2 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 9 matching patterns; 0 legacy-only; 11 resolve-only. |
| Hierarchy for matching patterns | 2 differences. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only pattern(s), 11 resolve-only pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 9 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 11 | `/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}`<br>`/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/versions/{policyDefinitionVersion}`<br>`/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}`<br>`/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/versions/{policyDefinitionVersion}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/variables/{variableName}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Authorization/variables/{variableName}/values/{variableValueName}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/versions/{policyDefinitionVersion}`<br>`/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/versions/{policyDefinitionVersion}`<br>`/{scope}/providers/Microsoft.Authorization/policyEnrollments/{policyEnrollmentName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 2 hierarchy differences.

| Resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/versions/{policyDefinitionVersion}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Tenant, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |
| `/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/versions/{policyDefinitionVersion}` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` | Tenant, `scopeIdPattern: /subscriptions/{subscriptionId}`, `scopeResourceType: Microsoft.Resources/subscriptions` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List/action operation differences: `/{scope}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Authorization.PolicyAssignments.listForResource` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyAssignments` | Missing. | Present. |

#### List/action operation differences: `/{scope}/providers/Microsoft.Authorization/policyExemptions/{policyExemptionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Authorization.PolicyExemptions.listForResource` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}/providers/Microsoft.Authorization/policyExemptions` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 1 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/Microsoft.Authorization/dataPolicyManifests/{policyMode}` | `DataPolicyManifest` | `DataPolicyManifests` |

