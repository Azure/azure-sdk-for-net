# ARM provider schema comparison: Azure.ResourceManager.HybridCompute

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

1 hierarchy difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 13 normalized resource ID patterns in both schemas. |
| Hierarchy for matching patterns | 1 difference. |
| Resource model for matching patterns | Same resource model and resource type for every matching normalized resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching normalized resource ID pattern. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** none after path-variable normalization. Both schemas include the same normalized `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 13 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 1 hierarchy difference.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/providers/microsoft.hybridcompute/locations/{}/publishers/{}/extensiontypes/{}/versions/{}` | Tenant, `scopeIdPattern: `, `scopeResourceType: Microsoft.Resources/tenants` | Subscription, `scopeIdPattern: `, `scopeResourceType: Microsoft.Resources/tenants` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching normalized `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching normalized resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching normalized `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical after path-variable normalization.

No CRUD operation differences were found for matching normalized resource ID patterns.

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/licenses/{licenseName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.HybridCompute.LicensesOperationGroup.validateLicense` | `Action` | `/subscriptions/{subscriptionId}/providers/Microsoft.HybridCompute/validateLicense` | Missing. | Present. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 10 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/microsoft.hybridcompute/locations/{}/publishers/{}/extensiontypes/{}/versions/{}` | `HybridComputeExtensionValueV2` | `LocationsPublishersExtensionTypesVersions` |
| `/subscriptions/{}/providers/microsoft.hybridcompute/locations/{}/publishers/{}/extensiontypes/{}/versions/{}` | `HybridComputeExtensionValue` | `ExtensionValue` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/gateways/{}` | `ArcGateway` | `Gateway` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/licenses/{}` | `HybridComputeLicense` | `License` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/machines/{}` | `HybridComputeMachine` | `Machine` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/machines/{}/extensions/{}` | `HybridComputeMachineExtension` | `MachineExtension` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/machines/{}/licenseprofiles/{}` | `HybridComputeLicenseProfile` | `MachinesLicenseProfiles` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/machines/{}/runcommands/{}` | `HybridComputeMachineRunCommand` | `MachineRunCommand` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/privatelinkscopes/{}/privateendpointconnections/{}` | `HybridComputePrivateEndpointConnection` | `PrivateEndpointConnection` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.hybridcompute/privatelinkscopes/{}/privatelinkresources/{}` | `HybridComputePrivateLinkResource` | `PrivateLinkResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Microsoft.HybridCompute.LicensesOperationGroup.validateLicense` | `/subscriptions/{subscriptionId}/providers/Microsoft.HybridCompute/validateLicense` | Present. | Missing. |

