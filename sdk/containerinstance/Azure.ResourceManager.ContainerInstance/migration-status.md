# Migration Status — Azure.ResourceManager.ContainerInstance

**Last Updated:** 2026-03-31

## PRs

| PR | URL | Status |
|----|-----|--------|
| **Spec** | Not created | N/A |
| **SDK** | Not created | N/A |
| **Generator** | N/A | N/A |

## Branches

| Repo | Branch | Fork Remote |
|------|--------|-------------|
| azure-sdk-for-net | `migration/containerinstance-typespec` | origin |
| azure-rest-api-specs | N/A (local only) | N/A |

## Phase Tracker

**Status legend:** ✅ Done | 🔄 In Progress | ❌ Blocked | ⏭️ Not Started

| Phase | Status | Notes |
|-------|--------|-------|
| Phase 0 — Sync & Resume | ✅ | |
| Phase 1 — Discovery | ✅ | TypeSpec spec found, API version 2025-09-01 |
| Phase 2 — tsp-location.yaml | ✅ | Created, commit 5b041764f26fcff04fbc00cacef378730f1d2bda |
| Phase 3 — Legacy config removed | ✅ | autorest.md backed up, IncludeAutorestDependency removed |
| Phase 4 — Custom code updated | ✅ | 7 original custom files updated for new types |
| Phase 5 — Code generation | ✅ | 263 files generated via manual npx tsp compile |
| Phase 6 — Build-Fix Cycle | 🔄 | Compilation passes; ApiCompat errors remain (316 unique) |
| Phase 7 — CI & Changelog | ⏭️ | |
| Phase 8 — Test project build | ⏭️ | |
| Phase 9 — Test execution | ⏭️ | |
| Phase 10 — Finalization | ⏭️ | |
| Phase 11 — Create PRs | ⏭️ | |
| Phase 12 — Verify | ⏭️ | |

## ApiCompat Error Summary

| Error Type | Count (per TFM) | Action |
|-----------|-------|--------|
| MembersMustExist | ~238 | Fix with custom code shims |
| TypesMustExist | ~40 | Fix with backward-compat type aliases |
| CannotRemoveBaseTypeOrInterface | ~23 | Fix with custom code |
| CannotSealType | ~16 | Fix with custom code |

### Missing Types (TypesMustExist) — 33 unique types

Key renamed types needing backward-compat aliases:
- ContainerGroupProfileCollection/Resource/RevisionCollection/RevisionResource (resources renamed to CGProfile*)
- ContainerCapabilities → Capabilities
- ContainerEnvironmentVariable → EnvironmentVariable
- ContainerEvent → Event
- ContainerGroupPort → Port
- ContainerInstanceAzureFileVolume → AzureFileVolume
- ContainerInstanceGitRepoVolume → GitRepoVolume
- ContainerVolumeMount → VolumeMount
- ContainerResourceLimits → ResourceLimits
- ContainerResourceRequestsContent → ResourceRequests
- ContainerResourceRequirements → ResourceRequirements
- ContainerInstanceView → ContainerPropertiesInstanceView
- And more...

## Known Generator Bugs

1. **Inconsistent model factory naming**: Factory uses old autorest-style names; models use short TypeSpec names
2. **Missing model types**: ContainerHttpHeader, NGroupContainerGroupProperty* not generated
3. **CS0542**: Properties named same as enclosing type (Capabilities.Capabilities, Port.Port)
4. **Duplicate methods**: GetCGProfileResource generated twice
5. **CodeGenSuppress/CodeGenMember ignored**: These attributes have no effect on generation output
6. **Nested output directory**: Emitter creates src/src/Generated/ instead of src/Generated/

## Workarounds Applied

- `<Compile Remove>` in csproj to exclude 7 buggy generated files
- Corrected copies in Customized/ directories
- 15 backward-compat wrapper types (internal classes inheriting from generated types)
- 3 fully custom model implementations for missing types

## Next Steps

1. Fix ApiCompat errors (316 unique per TFM)
   - Create backward-compat type aliases for 33 missing types
   - Add shim properties/methods for MembersMustExist errors
   - Fix inheritance issues for CannotRemoveBaseTypeOrInterface
2. Build tests
3. Run tests
4. Pre-commit checks (Export-API, Update-Snippets, dotnet format)
5. Create PRs
