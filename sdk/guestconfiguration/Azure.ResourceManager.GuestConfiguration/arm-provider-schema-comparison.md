# ARM provider schema comparison: Azure.ResourceManager.GuestConfiguration

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

4 legacy-only and 0 resolve-only normalized resource ID patterns.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 0 matching normalized patterns; 4 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** 4 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 0 | None. |
| Legacy only | 4 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` |
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

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 24 non-resource method difference(s) were found.

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignments.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignments.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignments.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignments.guestConfigurationAssignmentReportsGet` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}/reports/{reportId}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignments.guestConfigurationAssignmentReportsList` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}/reports` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignments.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.guestConfigurationAssignmentReportsVMSSGet` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}/reports/{id}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.guestConfigurationAssignmentReportsVMSSList` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{name}/reports` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationAssignmentsVMSS.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmssName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.guestConfigurationConnectedVMwarevSphereAssignmentsReportsGet` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}/reports/{reportId}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.guestConfigurationConnectedVMwarevSphereAssignmentsReportsList` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}/reports` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationConnectedVMwarevSphereAssignments.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ConnectedVMwarevSphere/virtualmachines/{vmName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.createOrUpdate` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.get` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.guestConfigurationHCRPAssignmentReportsGet` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}/reports/{reportId}` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.guestConfigurationHCRPAssignmentReportsList` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/{guestConfigurationAssignmentName}/reports` | Missing. | Present. |
| `Microsoft.GuestConfiguration.GuestConfigurationHCRPAssignments.list` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments` | Missing. | Present. |

