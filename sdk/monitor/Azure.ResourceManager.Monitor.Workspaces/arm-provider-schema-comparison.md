# ARM provider schema comparison: Azure.ResourceManager.Monitor.Workspaces

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 6 resolve-only normalized resource ID patterns; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 3 matching normalized patterns; 0 legacy-only; 6 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 6 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 3 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 6 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/authenticationsettings/{authenticationSettingName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/discoveryrules/{discoveryRuleName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/entities/{entityName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/relationships/{relationshipName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/healthmodels/{healthModelName}/signaldefinitions/{signalDefinitionName}` |

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

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/issues/{issueName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Monitor.Issue.startInvestigation` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Monitor/accounts/{azureMonitorWorkspaceName}/issues/{issueName}/startInvestigation` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 3 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.monitor/accounts/{}` | `MonitorWorkspace` | `AzureMonitorWorkspaceResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.monitor/accounts/{}/issues/{}` | `MonitorIssue` | `IssueResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.monitor/accounts/{}/metricscontainers/{}` | `MonitorMetricsContainer` | `MetricsContainerResource` |

## Bicep reference validation

Resource type validity was checked against the public Bicep reference by opening `https://learn.microsoft.com/en-us/azure/templates/{resourceType}?pivots=deployment-language-bicep`. For resources that exist, the Bicep API versions were compared with this package's generated API versions.

| Metric | Count |
| --- | ---: |
| Checked rows | 6 |
| Found in Bicep reference | 6 |
| Found in package API version | 6 |
| Found only outside package API versions | 0 |
| Not found in Bicep reference | 0 |

**Result:** All six `resolveArmResources`-only `healthmodels/*` resource types are real ARM resources in the same package API version (`2025-05-03-preview`). This points to a legacy/TCGC projection issue rather than a false `resolveArmResources` resource.

The saved C# `tspCodeModel.json` contains no HealthModel/AuthenticationSetting/DiscoveryRule/Entity/Relationship/SignalDefinition clients or methods. The TypeSpec marks those interfaces with `@removed(Versions.v2025_10_03)`, while the package includes API versions `2025-05-03-preview`, `2025-10-03-preview`, and `2025-10-03`. This suggests the C# SDK projection drops the health model resources entirely because they are removed in the latest selected versions, while `resolveArmResources` still sees them from the full TypeSpec program.

### Found in the same package API version

These are possible misses in the legacy/TCGC-based detector unless intentionally excluded from the SDK surface.

| Side | Resource type | Overlapping API versions | Resource schema API versions |
| --- | --- | --- | --- |
| `resolveArmResources` only | [Microsoft.Monitor/accounts/healthmodels](https://learn.microsoft.com/en-us/azure/templates/microsoft.monitor/accounts/healthmodels?pivots=deployment-language-bicep) | `2025-05-03-preview` | None |
| `resolveArmResources` only | [Microsoft.Monitor/accounts/healthmodels/authenticationsettings](https://learn.microsoft.com/en-us/azure/templates/microsoft.monitor/accounts/healthmodels/authenticationsettings?pivots=deployment-language-bicep) | `2025-05-03-preview` | None |
| `resolveArmResources` only | [Microsoft.Monitor/accounts/healthmodels/discoveryrules](https://learn.microsoft.com/en-us/azure/templates/microsoft.monitor/accounts/healthmodels/discoveryrules?pivots=deployment-language-bicep) | `2025-05-03-preview` | None |
| `resolveArmResources` only | [Microsoft.Monitor/accounts/healthmodels/entities](https://learn.microsoft.com/en-us/azure/templates/microsoft.monitor/accounts/healthmodels/entities?pivots=deployment-language-bicep) | `2025-05-03-preview` | None |
| `resolveArmResources` only | [Microsoft.Monitor/accounts/healthmodels/relationships](https://learn.microsoft.com/en-us/azure/templates/microsoft.monitor/accounts/healthmodels/relationships?pivots=deployment-language-bicep) | `2025-05-03-preview` | None |
| `resolveArmResources` only | [Microsoft.Monitor/accounts/healthmodels/signaldefinitions](https://learn.microsoft.com/en-us/azure/templates/microsoft.monitor/accounts/healthmodels/signaldefinitions?pivots=deployment-language-bicep) | `2025-05-03-preview` | None |
