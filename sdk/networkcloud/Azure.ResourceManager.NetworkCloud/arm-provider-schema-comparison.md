# ARM provider schema comparison: Azure.ResourceManager.NetworkCloud

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 21 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 3 differences. |
| List/action operations for matching patterns | 1 difference. |

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

**Differences:** 3 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetworkCloud.BareMetalMachines.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}` | Missing. | Present. |
| `Microsoft.NetworkCloud.BareMetalMachines.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/racks/{rackName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetworkCloud.Racks.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/racks/{rackName}` | Missing. | Present. |
| `Microsoft.NetworkCloud.Racks.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/racks/{rackName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetworkCloud.StorageAppliances.createOrUpdate` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}` | Missing. | Present. |
| `Microsoft.NetworkCloud.StorageAppliances.delete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/storageAppliances/{storageApplianceName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.NetworkCloud.BareMetalMachines.reimageOld` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/bareMetalMachines/{bareMetalMachineName}/reimageOld` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 21 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.networkcloud/rackskus/{}` | `NetworkCloudRackSku` | `RackSku` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/accessbridges/{}` | `NetworkCloudAccessBridge` | `AccessBridge` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/baremetalmachines/{}` | `NetworkCloudBareMetalMachine` | `BareMetalMachine` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/cloudservicesnetworks/{}` | `NetworkCloudCloudServicesNetwork` | `CloudServicesNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/clustermanagers/{}` | `NetworkCloudClusterManager` | `ClusterManager` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/clusters/{}` | `NetworkCloudCluster` | `Cluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/clusters/{}/baremetalmachinekeysets/{}` | `NetworkCloudBareMetalMachineKeySet` | `BareMetalMachineKeySet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/clusters/{}/bmckeysets/{}` | `NetworkCloudBmcKeySet` | `BmcKeySet` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/clusters/{}/metricsconfigurations/{}` | `NetworkCloudClusterMetricsConfiguration` | `ClusterMetricsConfiguration` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/kubernetesclusters/{}` | `NetworkCloudKubernetesCluster` | `KubernetesCluster` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/kubernetesclusters/{}/agentpools/{}` | `NetworkCloudAgentPool` | `AgentPool` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/kubernetesclusters/{}/features/{}` | `NetworkCloudKubernetesClusterFeature` | `KubernetesClusterFeature` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/kubernetesversions/{}` | `NetworkCloudKubernetesVersion` | `KubernetesVersion` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/l2networks/{}` | `NetworkCloudL2Network` | `L2Network` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/l3networks/{}` | `NetworkCloudL3Network` | `L3Network` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/racks/{}` | `NetworkCloudRack` | `Rack` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/storageappliances/{}` | `NetworkCloudStorageAppliance` | `StorageAppliance` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/trunkednetworks/{}` | `NetworkCloudTrunkedNetwork` | `TrunkedNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/virtualmachines/{}` | `NetworkCloudVirtualMachine` | `VirtualMachine` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/virtualmachines/{}/consoles/{}` | `NetworkCloudVirtualMachineConsole` | `Console` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.networkcloud/volumes/{}` | `NetworkCloudVolume` | `Volume` |

