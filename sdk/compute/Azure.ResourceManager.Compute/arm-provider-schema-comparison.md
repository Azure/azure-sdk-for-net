# ARM provider schema comparison: Azure.ResourceManager.Compute

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

2 legacy-only and 0 resolve-only normalized resource ID patterns; 2 resource model differences; 2 list/action operation differences.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 35 matching normalized patterns; 2 legacy-only; 0 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | 2 differences. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 2 differences. |

## 1. Resource ID pattern coverage

**Differences:** 2 legacy-only normalized pattern(s), 0 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 35 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}` |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 2 resource model differences.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.compute/locations/{}/publishers/{}/artifacttypes/vmextension/types/{}/versions/{}` | `Compute.VirtualMachineExtensionImage` | `Compute.VirtualMachineExtensionImage` | `Microsoft.Compute/locations/publishers/artifacttypes/types/versions` | `Microsoft.Compute/locations/publishers/types/versions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachinescalesets/{}/rollingupgrades/latest` | `Compute.RollingUpgradeStatusInfo` | `Compute.RollingUpgradeStatusInfo` | `Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades` | `Microsoft.Compute/virtualMachineScaleSets` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 2 list/action operation differences.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Compute.VirtualMachineScaleSetExtensions.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetExtensions.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetExtensions.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetExtensions.list` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetExtensions.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/extensions/{vmssExtensionName}` | Missing. | Present. |

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Compute.VirtualMachineScaleSetVMExtensions.createOrUpdate` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetVMExtensions.delete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetVMExtensions.get` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetVMExtensions.list` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions` | Missing. | Present. |
| `Compute.VirtualMachineScaleSetVMExtensions.update` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmScaleSetName}/virtualMachines/{instanceId}/extensions/{vmExtensionName}` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 14 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.compute/locations/{}/publishers/{}/artifacttypes/vmextension/types/{}/versions/{}` | `VirtualMachineExtensionImage` | `TypesVersions` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/diskaccesses/{}/privateendpointconnections/{}` | `ComputePrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/disks/{}` | `ManagedDisk` | `Disk` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/galleries/{}/invmaccesscontrolprofiles/{}` | `GalleryInVmAccessControlProfile` | `GalleryInVMAccessControlProfile` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/galleries/{}/invmaccesscontrolprofiles/{}/versions/{}` | `GalleryInVmAccessControlProfileVersion` | `GalleryInVMAccessControlProfileVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/images/{}` | `DiskImage` | `Image` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/restorepointcollections/{}` | `RestorePointGroup` | `RestorePointCollection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/restorepointcollections/{}/restorepoints/{}/diskrestorepoints/{}` | `DiskRestorePoint` | `RestorePointsDiskRestorePoints` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/sshpublickeys/{}` | `SshPublicKey` | `SshPublicKeyResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachines/{}/runcommands/{}` | `VirtualMachineRunCommand` | `VirtualMachinesRunCommands` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachinescalesets/{}/lifecyclehookevents/{}` | `VirtualMachineScaleSetLifecycleHookEvent` | `VMScaleSetLifecycleHookEvent` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachinescalesets/{}/rollingupgrades/latest` | `VirtualMachineScaleSetRollingUpgrade` | `RollingUpgradeStatusInfo` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachinescalesets/{}/virtualmachines/{}` | `VirtualMachineScaleSetVm` | `VirtualMachineScaleSetVM` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.compute/virtualmachinescalesets/{}/virtualmachines/{}/runcommands/{}` | `VirtualMachineScaleSetVmRunCommand` | `VirtualMachinesRunCommands` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Compute.Operations.list` | `/providers/Microsoft.Compute/operations` | Missing. | Present. |

