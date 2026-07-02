# ARM provider schema comparison: Azure.ResourceManager.DesktopVirtualization

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 17 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 17 | Matching normalized resource ID patterns are compared in the following sections. |
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

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DesktopVirtualization.ActiveSessionHostConfigurations.listByHostPool` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/activeSessionHostConfigurations` | Missing. | Present. |
| `Microsoft.DesktopVirtualization.AppAttachPackageInfo.import` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/importAppAttachPackageInfo` | Different. | Different. |
| `Microsoft.DesktopVirtualization.ScalingPlans.listByHostPool` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/scalingPlans` | Different. | Different. |
| `Microsoft.DesktopVirtualization.UserSessions.listByHostPool` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/userSessions` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/activeSessionHostConfigurations/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DesktopVirtualization.ActiveSessionHostConfigurations.listByHostPool` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/hostPools/{hostPoolName}/activeSessionHostConfigurations` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 5 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.desktopvirtualization/applicationgroups/{}` | `VirtualApplicationGroup` | `ApplicationGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.desktopvirtualization/applicationgroups/{}/applications/{}` | `VirtualApplication` | `Application` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.desktopvirtualization/applicationgroups/{}/desktops/{}` | `VirtualDesktop` | `Desktop` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.desktopvirtualization/hostpools/{}/msixpackages/{}` | `MsixPackage` | `MSIXPackage` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.desktopvirtualization/workspaces/{}` | `VirtualWorkspace` | `Workspace` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.DesktopVirtualization.Operations.list` | `/providers/Microsoft.DesktopVirtualization/operations` | Missing. | Present. |

