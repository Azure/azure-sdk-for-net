# Migration Status — Azure.Security.ConfidentialLedger

**Tracking Issue:** Not created
**Last Updated:** 2026-08-07

## PRs

| PR | URL | Status |
|----|-----|--------|
| **Spec** | Not created | Not created |
| **SDK** | Not created | Not created |
| **Generator** | N/A | N/A |

## Branches

| Repo | Branch | Fork Remote |
|------|--------|-------------|
| azure-sdk-for-net | `copilot/confidentialledger-new-emitter` | `origin` |
| azure-rest-api-specs | `copilot/confidentialledger-csharp-emitter` | `origin` |

## Phase Tracker

**Status legend:** ✅ Done | 🔄 In Progress | ❌ Blocked | ⏭️ Not Started

| Phase | Status | Notes |
|-------|--------|-------|
| Phase 0 — Sync & Resume | ✅ Done | Created isolated worktrees from upstream main. |
| Phase 1 — Discovery & Planning | ✅ Done | Existing TypeSpec package uses the legacy emitter; new emitter spec config needs namespace correction. |
| Phase 2 — Create/Update tsp-location.yaml | ✅ Done | Switched to the new emitter; final spec commit remains to be pinned. |
| Phase 3 — Handle Legacy Configuration | ✅ Done | Removed the legacy Microsoft.Azure.AutoRest.CSharp build dependency. |
| Phase 4 — Update Custom Code | ✅ Done | Migrated customization attributes and pipeline references to new-generator conventions. |
| Phase 5 — Code Generation | ✅ Done | Regenerated locally with Node 24.14.1 and emitter 1.0.0-alpha.20260805.3. |
| Phase 6 — Build-Fix Cycle | ❌ Blocked | Confirmed generator bug: ClientSettings emits invalid IConfiguration binding for X509Certificate2. |
| Phase 7 — Changelog | ⏭️ Not Started | |
| Phase 8 — Test Project Build | ⏭️ Not Started | |
| Phase 9 — Test Execution | ⏭️ Not Started | |
| Phase 10 — Finalization | ⏭️ Not Started | |
| Phase 11 — Create Pull Requests | ⏭️ Not Started | |
| Phase 12 — Verify and Summarize | ⏭️ Not Started | |

## ApiCompat Baseline Summary

| Error Type | Count | Action |
|-----------|-------|--------|
| Not evaluated | 0 | Build after regeneration. |

## Known Issues

- The upstream new-emitter configuration currently uses `Azure.ConfidentialLedger`; the existing package API requires `Azure.Security.ConfidentialLedger`.
- The new emitter generates `new X509Certificate2(IConfigurationSection)` in `ConfidentialLedgerClientSettings.BindCore`, which fails with CS1503 on netstandard2.0, net8.0, and net10.0. This was reproduced after a clean local regeneration with the migrated customization attributes.

## Next Steps

1. Decide whether to fix the generator, explicitly approve a workaround, or pause.
2. Complete the source build and API compatibility fixes.
3. Build and run non-live tests.
