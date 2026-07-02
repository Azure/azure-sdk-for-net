# ARM provider schema comparison: Azure.ResourceManager.Hci.Vm

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 2 resolve-only normalized resource ID patterns; 2 CRUD operation differences; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 17 matching normalized patterns; 0 legacy-only; 2 resolve-only. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching normalized resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | 2 differences. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 2 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 17 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 2 | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/natGateways/{natGatewayName}/inboundRules/{inboundRuleName}`<br>`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/snapshots/{snapshotName}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching normalized `resourceIdPattern`, the resource-level `scope` object is identical after path-variable normalization.

No hierarchy differences were found for matching normalized resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 2 CRUD operation differences.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/networkInterfaces/{networkInterfaceName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureStackHCI.NetworkInterfaces.updateOld` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/networkInterfaces/{networkInterfaceName}` | Missing. | Present. |

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{virtualHardDiskName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureStackHCI.VirtualHardDisks.updateOld` | `Update` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHCI/virtualHardDisks/{virtualHardDiskName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/{resourceUri}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.AzureStackHCI.VirtualMachineInstances.powerOff` | `Action` | `/{resourceUri}/providers/Microsoft.AzureStackHCI/virtualMachineInstances/default/powerOff` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 17 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/galleryimages/{}` | `HciVmGalleryImage` | `GalleryImage` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/loadbalancers/{}` | `HciVmLoadBalancer` | `LoadBalancer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/logicalnetworks/{}` | `HciVmLogicalNetwork` | `LogicalNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/marketplacegalleryimages/{}` | `HciVmMarketplaceGalleryImage` | `MarketplaceGalleryImage` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/natgateways/{}` | `HciVmNatGateway` | `NatGateway` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/networkinterfaces/{}` | `HciVmNetworkInterface` | `NetworkInterface` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/networksecuritygroups/{}` | `HciVmNetworkSecurityGroup` | `NetworkSecurityGroup` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/networksecuritygroups/{}/securityrules/{}` | `HciVmSecurityRule` | `SecurityRule` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/publicipaddresses/{}` | `HciVmPublicIPAddress` | `PublicIPAddress` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/storagecontainers/{}` | `HciVmStorageContainer` | `StorageContainer` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/virtualharddisks/{}` | `HciVmVirtualHardDisk` | `VirtualHardDisk` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/virtualnetworks/{}` | `HciVmVirtualNetwork` | `VirtualNetwork` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.azurestackhci/virtualnetworks/{}/subnets/{}` | `HciVmVirtualNetworkSubnet` | `VirtualNetworkSubnet` |
| `/{}/providers/microsoft.azurestackhci/virtualmachineinstances/default` | `HciVmInstance` | `VirtualMachineInstance` |
| `/{}/providers/microsoft.azurestackhci/virtualmachineinstances/default/attestationstatus/default` | `HciVmAttestationStatus` | `AttestationStatus` |
| `/{}/providers/microsoft.azurestackhci/virtualmachineinstances/default/guestagents/default` | `HciVmGuestAgent` | `GuestAgent` |
| `/{}/providers/microsoft.azurestackhci/virtualmachineinstances/default/hybrididentitymetadata/default` | `HciVmHybridIdentityMetadata` | `HybridIdentityMetadata` |

