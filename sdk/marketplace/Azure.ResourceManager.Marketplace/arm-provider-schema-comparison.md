# ARM provider schema comparison: Azure.ResourceManager.Marketplace

Compared files:

- `arm-provider-schema.legacy.json`
- `arm-provider-schema.resolve-arm-resources.json`

## Summary

3 list/action operation differences.

| Aspect | Result |
| --- | --- |
| Resource ID patterns | Same 5 resource ID patterns in both schemas. |
| Hierarchy for matching patterns | Same resource-level hierarchy for every matching resource ID pattern. |
| Resource model for matching patterns | Same resource model and resource type for every matching resource ID pattern. |
| CRUD operations for matching patterns | Same CRUD operation set for every matching resource ID pattern. |
| List/action operations for matching patterns | 3 differences. |

## 1. Resource ID pattern coverage

**Differences:** none. Both schemas include the same `resourceIdPattern` values.

| Category | Count | Details |
| --- | ---: | --- |
| In both schemas | 5 | Matching resource ID patterns are compared in the following sections. |
| Legacy only | 0 | None. |
| `resolveArmResources` only | 0 | None. |

## 2. Hierarchy comparison for matching resource ID patterns

**Differences:** none. For every matching `resourceIdPattern`, the resource-level `scope` object is identical in both schemas.

No hierarchy differences were found for matching resource ID patterns.

## 3. Resource model comparison for matching resource ID patterns

**Differences:** none for `resourceModelId` or `resourceType`. All matching `resourceIdPattern` values map to the same resource model and resource type in both schemas.

No resource model differences were found for matching resource ID patterns.

## 4. Operation comparison for matching resource ID patterns

### 4.1 CRUD operations

**Differences:** none. For every matching `resourceIdPattern`, the `Create`, `Read`, `Update`, and `Delete` operation sets are identical.

No CRUD operation differences were found for matching resource ID patterns.

### 4.2 List and action operations

**Differences:** 3 list/action operation differences.

#### List/action operation differences: `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Marketplace.PrivateStoreCollectionOperationGroup.post` | `Action` | `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}` | Missing. | Present. |

#### List/action operation differences: `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Marketplace.PrivateStoreCollectionOfferOperationGroup.post` | `Action` | `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/offers/{offerId}` | Missing. | Present. |
| `Microsoft.Marketplace.PrivateStoreCollectionOperationGroup.post` | `Action` | `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}` | Present. | Missing. |

#### List/action operation differences: `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/offers/{offerId}`

| Operation | Kind | Request path | Legacy | `resolveArmResources` |
| --- | --- | --- | --- | --- |
| `Microsoft.Marketplace.PrivateStoreCollectionOfferOperationGroup.post` | `Action` | `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/offers/{offerId}` | Present. | Missing. |

## Secondary observations

These differences are outside the requested comparison axes but may still be useful when evaluating `resolveArmResources` output.

- 4 matching resource ID pattern(s) have different `resourceName` values. The requested comparison uses `resourceModelId` and `resourceType`; these still match unless noted above.

### Resource name differences

| Resource ID pattern | Legacy `resourceName` | `resolveArmResources` `resourceName` |
| --- | --- | --- |
| `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/adminRequestApprovals/{adminRequestApprovalId}` | `MarketplaceAdminApprovalRequest` | `AdminRequestApprovalsResource` |
| `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}` | `PrivateStoreCollectionInfo` | `Collection` |
| `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/collections/{collectionId}/offers/{offerId}` | `PrivateStoreOffer` | `Offer` |
| `/providers/Microsoft.Marketplace/privateStores/{privateStoreId}/requestApprovals/{requestApprovalId}` | `MarketplaceApprovalRequest` | `RequestApprovalResource` |

