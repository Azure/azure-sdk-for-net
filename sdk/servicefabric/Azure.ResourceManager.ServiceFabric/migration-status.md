# Migration Status — Azure.ResourceManager.ServiceFabric

**Tracking Issue:** [#55604](https://github.com/Azure/azure-sdk-for-net/issues/55604)
**Last Updated:** 2026-04-03

## Known Generator Bug — Resource Type Renames Blocked

`@@clientName` on resource models extending custom `@customAzureResource ProxyResource` causes the
mgmt generator to produce empty stub Resource classes (missing `ResourceType`, `Data`, constructors,
and all operations). This affects ALL resource types in this package because the spec defines a custom
`ProxyResource` model with `string id/name/type` fields.

**Impact:** Cannot rename resource types from `ClusterResource` → `ServiceFabricClusterResource`, etc.
This is a **breaking change** from the old API which used the `ServiceFabric` prefix on all resource types.

**Workaround applied:** Resource type `@@clientName` decorators are commented out in `client.tsp`.
The property-level renames and model-level renames work correctly.

**To revisit:** When the mgmt generator is fixed to handle `@@clientName` on resources with custom
`@customAzureResource` base types, uncomment the resource renames in `client.tsp` and regenerate.

## Current ApiCompat Status (267 errors remaining)

| Category | Count (×3 TFMs) | Root Cause | Fix |
|----------|----------------|------------|-----|
| TypesMustExist | 54 | Resource type renames skipped (generator bug) | Generator fix needed |
| MembersMustExist | 204 | Flattened properties, changed types, missing constructors | Custom code shims |
| CannotSealType | 6 | Types that became sealed | Custom code |
| CannotRemoveBaseTypeOrInterface | 3 | Data classes inherit custom ProxyResource instead of TrackedResourceData | Generator bug |

## Spec Changes Applied (client.tsp)

- `@@clientName` for `ProxyResource` → `ServiceFabricProxyResource` (csharp)
- `@@clientName` for `ArmProxyResource` (common types, csharp)
- 12 model type renames (e.g., `AzureActiveDirectory` → `ClusterAadSetting`)
- 14 enum/union renames (e.g., `AddOnFeatures` → `ClusterAddOnFeature`)
- 8 property renames (e.g., `sfZonalUpgradeMode` → `ServiceFabricZonalUpgradeMode`)
- 5 `@@access(public)` decorators
- 5 `@@alternateType` for URI properties
- Removed `model-namespace: false` from tspconfig.yaml

## SDK Workarounds (Customization/)

- `MockableServiceFabricArmClient.cs` — duplicate `GetClusterVersionResource` removed
- `ServiceFabricExtensions.cs` — duplicate `GetClusterVersionResource` removed
- `ServiceFabricExtensionsHelper.cs` — missing `GetMockableServiceFabricArmClient` helper
- `ClusterVersionCollection.cs` — `ClusterVersionsEnvironment` → `string`, `IEnumerable` fix
- `ApplicationResource.cs` etc — `data.Id` string → `new ResourceIdentifier(data.Id)`
- `ClusterData.cs` — `string id` → `new ResourceIdentifier(id)`
- `VMSizeResourceData.cs` — `string id` → `new ResourceIdentifier(id)`
- `MockableServiceFabricSubscriptionResource.cs` — missing constructor arg

## Branches

| Repo | Branch | Fork Remote |
|------|--------|-------------|
| azure-sdk-for-net | `servicefabric-mpg-migration` | `fork` |
| azure-rest-api-specs | `servicefabric-mpg-migration` | `fork` |

## Phase Tracker

**Status legend:** ✅ Done | 🔄 In Progress | ❌ Blocked | ⏭️ Not Started

| Phase | Status | Notes |
|-------|--------|-------|
| Phase 0 — Sync & Resume | ✅ | Repos synced to latest main |
| Phase 1 — Discovery | ✅ | No custom code, 49 rename-mappings, 6 prepend-rp-prefix |
| Phase 2 — tsp-location.yaml | ✅ | Created with mgmt emitter path |
| Phase 3 — Legacy config removed | ✅ | autorest.md deleted, IncludeAutorestDependency removed |
| Phase 4 — Custom code updated | ✅ | No custom code existed |
| Phase 5 — Code generation | ✅ | Generation succeeds |
| Phase 6 — Build-Fix Cycle | 🔄 | Compilation passes, 543 ApiCompat errors remaining |
| Phase 7 — CI & Changelog | ⏭️ | |
| Phase 8 — Test project build | ⏭️ | |
| Phase 9 — Test execution | ⏭️ | |
| Phase 10 — Finalization | ⏭️ | |
| Phase 11 — Create PRs | ⏭️ | |
| Phase 12 — Verify | ⏭️ | |

## Known Generator Bugs

1. **string id in Data constructors** - ClusterData, VMSizeResourceData use `string id` in constructors where base expects `ResourceIdentifier`. Root cause: Custom `ProxyResource` model with `string id` in spec namespace.
2. **string id cascade to Resource classes** - ApplicationResource, ApplicationTypeResource, ApplicationTypeVersionResource, ServiceResource call `data.Id` which returns `string` from custom ProxyResource base.
3. **Duplicate methods** - MockableServiceFabricArmClient and ServiceFabricExtensions generate duplicate `GetClusterVersionResource` methods.
4. **ClusterVersionCollection wrong types** - Multiple type mismatches (ClusterVersionsEnvironment→string, ClusterCodeVersionsListResult→ClusterData, missing GetEnumerator).
5. **MockableServiceFabricSubscriptionResource** - Missing constructor argument for ClusterVersionCollection.

## Spec Changes Made

- Uncommented C# mgmt emitter in tspconfig.yaml (removed `clear-output-folder` and `flavor` invalid options)
- Added "csharp" to @@clientName for CommonTypes.ProxyResource → "ArmProxyResource"
- Added @@clientName for custom ProxyResource → "ServiceFabricProxyResource" (csharp)

## SDK Changes Made

- Created tsp-location.yaml with emitterPackageJsonPath
- Removed autorest.md and IncludeAutorestDependency
- Added `<Compile Remove>` in csproj for duplicate method files
- Created corrected copies in Customization/ for MockableServiceFabricArmClient.cs and ServiceFabricExtensions.cs

## Next Steps

1. Fix remaining generator bugs via Compile Remove + corrected copies
2. Or investigate generator-level fix for string id issue
