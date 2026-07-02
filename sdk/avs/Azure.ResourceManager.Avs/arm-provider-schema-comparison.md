# ARM provider schema comparison: Azure.ResourceManager.Avs

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

No requested-axis differences after path-variable normalization.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 29 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | Same list/action operation set for every matching normalized resource ID pattern. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 29 | Matching normalized resource ID patterns are compared in the following sections. |
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

**Differences:** none. For every matching normalized `resourceIdPattern`, the `List` and `Action` operation sets are identical after path-variable normalization.

No list/action operation differences were found for matching normalized resource ID patterns.

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 13 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}` | `AvsPrivateCloud` | `PrivateCloud` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/addons/{}` | `AvsPrivateCloudAddon` | `Addon` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/cloudlinks/{}` | `AvsCloudLink` | `CloudLink` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/clusters/{}` | `AvsPrivateCloudCluster` | `Cluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/clusters/{}/datastores/{}` | `AvsPrivateCloudDatastore` | `Datastore` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/clusters/{}/hosts/{}` | `AvsHost` | `Host` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/clusters/{}/virtualmachines/{}` | `AvsPrivateCloudClusterVirtualMachine` | `VirtualMachine` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/licenses/{}` | `AvsLicense` | `License` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/maintenances/{}` | `AvsMaintenance` | `Maintenance` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/provisionednetworks/{}` | `AvsProvisionedNetwork` | `ProvisionedNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/purestoragepolicies/{}` | `AvsPureStoragePolicy` | `PureStoragePolicy` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/workloadnetworks/default/portmirroringprofiles/{}` | `WorkloadNetworkPortMirroringProfile` | `WorkloadNetworkPortMirroring` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.avs/privateclouds/{}/workloadnetworks/default/vmgroups/{}` | `WorkloadNetworkVmGroup` | `WorkloadNetworkVMGroup` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.AVS.ServiceComponents.checkAvailability` | `/subscriptions/{subscriptionId}/providers/Microsoft.AVS/locations/{location}/serviceComponents/{serviceComponentName}/checkAvailability` | Missing. | Present. |

