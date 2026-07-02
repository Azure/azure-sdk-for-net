# ARM provider schema comparison: Azure.ResourceManager.RecoveryServices

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

0 legacy-only and 1 resolve-only normalized resource ID patterns; 1 hierarchy difference; 1 resource model difference; 1 CRUD operation difference; 1 list/action operation difference.

Resource ID comparisons normalize path variable names, so `{name}` and `{labName}` are treated as the same resource identity.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | 4 matching normalized patterns; 0 legacy-only; 1 resolve-only. |
| Hierarchy for matching patterns | 1 difference. |
| Resource model for matching patterns | 1 difference. |
| CRUD operations for matching patterns | 1 difference. |
| List/action operations for matching patterns | 1 difference. |

## 1. Resource ID pattern coverage

**Differences:** 0 legacy-only normalized pattern(s), 1 resolve-only normalized pattern(s).

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 4 | Matching normalized resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 1 | `/subscriptions/{subscriptionId}/providers/Microsoft.RecoveryServices/locations/{location}/deletedVaults/{deletedVaultName}/operations/{operationId}` |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** 1 hierarchy difference.

| Normalized resource ID pattern | Legacy hierarchy | `resolveArmResources` hierarchy |
| --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/privatelinkresources/{}` | ResourceGroup, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` | Subscription, `scopeIdPattern: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`, `scopeResourceType: Microsoft.Resources/resourceGroups` |

## 3. Resource model comparison for matching resource ID patterns

**Differences:** 1 resource model difference.

| Normalized resource ID pattern | Legacy resource model | `resolveArmResources` resource model | Legacy resource type | `resolveArmResources` resource type |
| --- | --- | --- | --- | --- |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/extendedinformation/vaultextendedinfo` | `Microsoft.RecoveryServices.VaultExtendedInfoResource` | `Microsoft.RecoveryServices.VaultExtendedInfoResource` | `Microsoft.RecoveryServices/vaults/extendedInformation` | `Microsoft.RecoveryServices/vaults` |

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** 1 CRUD operation difference.

#### CRUD operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.Vaults.create` | `Create` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/certificates/{certificateName}` | Missing. | Present. |
| `Microsoft.RecoveryServices.Vaults.registeredIdentitiesDelete` | `Delete` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/registeredIdentities/{identityName}` | Missing. | Present. |

### 4.2 List and action operations

**Differences:** 1 list/action operation difference.

#### List and action operations differences: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.RecoveryServices.Vaults.create` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/certificates/{certificateName}` | Present. | Missing. |
| `Microsoft.RecoveryServices.Vaults.registeredIdentitiesDelete` | `Action` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/registeredIdentities/{identityName}` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 4 matching normalized resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.
- 1 non-resource method difference(s) were found.

### Resource name differences

| Normalized resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/subscriptions/{}/providers/microsoft.recoveryservices/locations/{}/deletedvaults/{}` | `RecoveryServicesDeletedVault` | `LocationsDeletedVaults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}` | `RecoveryServicesVault` | `Vaults` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/extendedinformation/vaultextendedinfo` | `RecoveryServicesVaultExtendedInfo` | `VaultExtendedInfoResource` |
| `/subscriptions/{}/resourcegroups/{}/providers/microsoft.recoveryservices/vaults/{}/privatelinkresources/{}` | `RecoveryServicesPrivateLinkResource` | `PrivateLinkResource` |

### Non-resource method differences

| Operation | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- |
| `Azure.ResourceManager.Legacy.Operations.list` | `/providers/Microsoft.RecoveryServices/operations` | Missing. | Present. |

