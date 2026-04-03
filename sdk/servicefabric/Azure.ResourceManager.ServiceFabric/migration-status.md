# Migration Status — Azure.ResourceManager.ServiceFabric

**Tracking Issue:** [#55604](https://github.com/Azure/azure-sdk-for-net/issues/55604)
**Last Updated:** 2026-04-03

## PRs

| PR | URL | Status |
|----|-----|--------|
| **Spec** | Not created (branch: `servicefabric-mpg-migration` on `live1206/azure-rest-api-specs`) | Draft |
| **SDK** | Not created (branch: `servicefabric-mpg-migration` on `live1206/azure-sdk-for-net`) | Draft |
| **Generator** | N/A | N/A |

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
