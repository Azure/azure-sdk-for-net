# ARM provider schema comparison: Azure.ResourceManager.WorkloadOrchestration

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 21 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 21 | Matching normalized resource ID patterns are compared in the following sections. |
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

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/solutionTemplates/{solutionTemplateName}/versions/{solutionTemplateVersionName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Edge.SolutionTemplateVersions.bulkReviewSolution` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/solutionTemplates/{solutionTemplateName}/versions/{solutionTemplateVersionName}/bulkReviewSolution` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/targets/{targetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Edge.Targets.unstageSolutionVersion` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Edge/targets/{targetName}/unstageSolutionVersion` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 21 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/configtemplates/{}` | `EdgeConfigTemplate` | `ConfigTemplate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/configtemplates/{}/versions/{}` | `EdgeConfigTemplateVersion` | `ConfigTemplateVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/contexts/{}` | `EdgeContext` | `Context` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/contexts/{}/sitereferences/{}` | `EdgeSiteReference` | `SiteReference` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/contexts/{}/workflows/{}` | `EdgeWorkflow` | `Workflow` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/contexts/{}/workflows/{}/versions/{}` | `EdgeWorkflowVersion` | `WorkflowVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/contexts/{}/workflows/{}/versions/{}/executions/{}` | `EdgeExecution` | `Execution` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/diagnostics/{}` | `EdgeDiagnostic` | `Diagnostic` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/schemas/{}` | `EdgeSchema` | `Schema` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/schemas/{}/dynamicschemas/{}` | `EdgeDynamicSchema` | `DynamicSchema` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/schemas/{}/dynamicschemas/{}/versions/{}` | `EdgeDynamicSchemaVersion` | `DynamicSchemaVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/schemas/{}/versions/{}` | `EdgeSchemaVersion` | `SchemaVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/solutiontemplates/{}` | `EdgeSolutionTemplate` | `SolutionTemplate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/solutiontemplates/{}/versions/{}` | `EdgeSolutionTemplateVersion` | `SolutionTemplateVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/targets/{}` | `EdgeTarget` | `Target` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/targets/{}/solutions/{}` | `EdgeSolution` | `Solution` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/targets/{}/solutions/{}/instances/{}` | `EdgeDeploymentInstance` | `Instance` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/targets/{}/solutions/{}/instances/{}/histories/{}` | `EdgeDeploymentInstanceHistory` | `InstanceHistory` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.edge/targets/{}/solutions/{}/versions/{}` | `EdgeSolutionVersion` | `SolutionVersion` |
| `/{}/providers/microsoft.edge/jobs/{}` | `EdgeJob` | `Job` |
| `/{}/providers/microsoft.edge/schemareferences/{}` | `EdgeSchemaReference` | `SchemaReference` |

