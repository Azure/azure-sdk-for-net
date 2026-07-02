# ARM provider schema comparison: Azure.ResourceManager.DevTestLabs

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

### Raw resource ID variable-name differences

Raw resource ID pattern mismatches reduced after normalizing path variable names. This means at least some raw differences are only parameter-name differences such as `{name}` vs `{labName}`.

| Raw legacy-only | Raw `resolveArmResources`-only | Normalized legacy-only | Normalized `resolveArmResources`-only |
| ---: | ---: | ---: | ---: |
| 15 | 15 | 0 | 0 |

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

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DevTestLab.GalleryImages.list` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/galleryimages` | Different. | Different. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.DevTestLab.Schedules.listApplicable` | `List` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/schedules/{name}/listApplicable` | Different. | Different. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 21 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 2 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}` | `DevTestLab` | `Lab` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/artifactsources/{}` | `DevTestLabArtifactSource` | `ArtifactSource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/artifactsources/{}/armtemplates/{}` | `DevTestLabArmTemplate` | `ArmTemplate` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/artifactsources/{}/artifacts/{}` | `DevTestLabArtifact` | `Artifact` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/costs/{}` | `DevTestLabCost` | `LabCost` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/customimages/{}` | `DevTestLabCustomImage` | `LabsCustomimages` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/formulas/{}` | `DevTestLabFormula` | `Formula` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/notificationchannels/{}` | `DevTestLabNotificationChannel` | `NotificationChannel` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/policysets/{}/policies/{}` | `DevTestLabPolicy` | `PolicysetsPolicies` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/schedules/{}` | `DevTestLabSchedule` | `LabsSchedules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/servicerunners/{}` | `DevTestLabServiceRunner` | `ServiceRunner` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/users/{}` | `DevTestLabUser` | `User` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/users/{}/disks/{}` | `DevTestLabDisk` | `Disk` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/users/{}/environments/{}` | `DevTestLabEnvironment` | `DtlEnvironment` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/users/{}/secrets/{}` | `DevTestLabSecret` | `Secret` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/users/{}/servicefabrics/{}` | `DevTestLabServiceFabric` | `ServiceFabric` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/users/{}/servicefabrics/{}/schedules/{}` | `DevTestLabServiceFabricSchedule` | `ServicefabricsSchedules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/virtualmachines/{}` | `DevTestLabVm` | `LabVirtualMachine` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/virtualmachines/{}/schedules/{}` | `DevTestLabVmSchedule` | `VirtualmachinesSchedules` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/labs/{}/virtualnetworks/{}` | `DevTestLabVirtualNetwork` | `VirtualNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.devtestlab/schedules/{}` | `DevTestLabGlobalSchedule` | `Schedules` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Azure.ResourceManager.ProviderOperations.list` | `/providers/Microsoft.DevTestLab/operations` | Missing. | Present. |
| `Microsoft.DevTestLab.Operations.get` | `/subscriptions/{subscriptionId}/providers/Microsoft.DevTestLab/locations/{locationName}/operations/{name}` | Missing. | Present. |

