# API Analysis: `2025-02-01-preview` → `2026-03-01-preview`

## Summary

- **Spec PR**: https://github.com/Azure/azure-rest-api-specs/pull/40408
- **Spec PR Latest Full Commit Hash**: 6152339643491464509b200249f64af1839e95e0
- **Tag**: `package-preview-2026-03-01`
- **Track**: preview
- **Baseline version**: `2025-02-01-preview`
- **Breaking Changes**: 6
- **New Features**: 5

---

## Breaking Changes

| Item | Kind | Before | After | Action |
|------|------|--------|-------|--------|
| `disabledDataExfiltrationOptions` | Property renamed | `IList<SearchDisabledDataExfiltrationOption>` | `dataExfiltrationProtections` (`IList<SearchDataExfiltrationProtection>`) | Add obsolete backward-compat property or update rename-mapping |
| `DisabledDataExfiltrationOption` / `SearchDisabledDataExfiltrationOption` | Enum type removed+renamed | `SearchDisabledDataExfiltrationOption` (enum: `All`) | `SearchDataExfiltrationProtection` (enum: `BlockAll`) | Existing rename-mapping already handles `SearchDataExfiltrationProtection`; may need obsolete stub for old enum |
| `serviceUpgradeDate` | Property renamed | `DateTimeOffset? ServiceUpgradeDate` | `serviceUpgradedAt` (`DateTimeOffset? ServiceUpgradedAt`) | Add rename-mapping or obsolete stub |
| `SemanticSearch` (definition) | Definition renamed | `SemanticSearch` | `SearchSemanticSearch` | No SDK impact — both map to `SearchSemanticSearch` enum; but `$ref` path changed |
| `NSP*` inline types (11 types) | Moved to common-types | Inline definitions (`NSPConfigAccessRule`, `NSPConfigPerimeter`, `NetworkSecurityPerimeterConfiguration`, etc.) | `common-types/resource-management/v6/networksecurityperimeter.json` | Existing rename-mappings for NSP types may need updating |
| `Operation`, `OperationProperties`, `OperationServiceSpecification`, etc. | Moved to common-types | Inline definitions | `common-types/resource-management/v6/types.json#/definitions/Operation` | Auto-generated; no SDK customization needed |
| `UserAssignedManagedIdentities` / `UserAssignedManagedIdentity` | Moved to common-types | Inline definitions | `common-types/resource-management/v6/managedidentity.json#/definitions/UserAssignedIdentity` | Auto-generated; no SDK customization needed |
| `OperationListResult` pagination | Changed from non-pageable to pageable | `nextLinkName: null` | `nextLinkName: nextLink` | Auto-generated; SDK will now paginate this operation |
| `SearchService.systemData` / `SearchServiceUpdate.systemData` | Property removed from inline | Inline `systemData` property | Inherited from `TrackedResource`/`Resource` via common-types | Auto-generated; systemData comes from base class |
| Top-level parameters | Moved to common-types | Inline `ApiVersionParameter`, `SubscriptionIdParameter`, etc. | `common-types/resource-management/v6/types.json#/parameters/*` | Auto-generated; no SDK customization needed |

---

## New Features

| Item | Description |
|------|-------------|
| `knowledgeRetrieval` | New property on `SearchServiceProperties`. Enum `KnowledgeRetrieval` with values: `free`, `standard`. Nullable. Controls knowledge retrieval availability. |
| `serviceLevelEncryptionKey` | New property on `EncryptionWithCmk`. Type `SearchResourceEncryptionKey` with sub-properties: `keyVaultKeyName`, `keyVaultKeyVersion`, `keyVaultUri`, `accessCredentials`, `identity`. |
| `SearchResourceEncryptionKey` | New model for service-level CMK encryption key configuration. |
| `DataIdentity` hierarchy | New discriminated type hierarchy: `DataIdentity` (base, discriminator: `@odata.type`), `DataNoneIdentity`, `DataUserAssignedIdentity`. Used by `SearchResourceEncryptionKey.identity`. |
| `AzureActiveDirectoryApplicationCredentials` | New model with `applicationId` and `applicationSecret` for Key Vault access. Used by `SearchResourceEncryptionKey.accessCredentials`. |
| `PrivateLinkResourcesResult.nextLink` | Pagination support added to private link resources list. |

---

## Recommended Customizations

### Renames — add to `autorest.md`

The following new definitions need `rename-mapping` entries to follow the `SearchService*` naming convention:

```yaml
rename-mapping:
  # New types needing Search prefix
  KnowledgeRetrieval: SearchServiceKnowledgeRetrieval
  SearchResourceEncryptionKey: SearchServiceEncryptionKey
  AzureActiveDirectoryApplicationCredentials: SearchAadApplicationCredentials
  DataIdentity: SearchDataIdentity
  DataNoneIdentity: SearchDataNoneIdentity
  DataUserAssignedIdentity: SearchDataUserAssignedIdentity
  # Renamed property mappings
  SearchService.properties.serviceUpgradedAt: ServiceUpgradeOn
  SearchServiceUpdate.properties.serviceUpgradedAt: ServiceUpgradeOn
  SearchService.properties.dataExfiltrationProtections: DataExfiltrationProtections
  SearchServiceUpdate.properties.dataExfiltrationProtections: DataExfiltrationProtections
  SearchDataExfiltrationProtection: SearchDataExfiltrationProtection
```

### Property renames — may need obsolete backward-compat stubs

1. `disabledDataExfiltrationOptions` → `dataExfiltrationProtections`: The spec renamed this property AND changed the item enum from `DisabledDataExfiltrationOption` (value: `All`) to `SearchDataExfiltrationProtection` (value: `BlockAll`). The existing SDK uses `SearchDataExfiltrationProtection` already — check if the enum value change from `All` to `BlockAll` is a breaking change.

2. `serviceUpgradeDate` → `serviceUpgradedAt`: Renamed in spec. The SDK currently maps this to `ServiceUpgradeOn` via autorest.md. Need to update the mapping to point to `serviceUpgradedAt`.

### NSP types — verify common-types compatibility

The 11 NSP-related types moved from inline definitions to `common-types/resource-management/v6/networksecurityperimeter.json`. The existing rename-mappings for `AccessRule`, `AccessRuleDirection`, `AccessRuleProperties`, `NetworkSecurityPerimeter`, `NetworkSecurityPerimeterConfiguration`, etc. may no longer apply if common-types uses different names. These rename-mappings should be reviewed and possibly removed if the common-types types are used directly.

---

## Notes for Spec Authors

- The `DisabledDataExfiltrationOption` enum value `All` was changed to `SearchDataExfiltrationProtection` with value `BlockAll`. This is a breaking change for existing SDK users who reference the old enum value.
- The `OperationListResult` was changed from non-pageable (`nextLinkName: null`) to pageable. This is a behavior change — existing SDK consumers won't expect pagination for this API.
- The spec restructuring (moving types to common-types, reordering properties, changing parameter refs) creates a very large diff that makes reviewing actual semantic changes difficult.
