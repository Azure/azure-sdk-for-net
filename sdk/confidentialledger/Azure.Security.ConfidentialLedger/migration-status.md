# Migration Status — Azure.Security.ConfidentialLedger

**Tracking Issue:** Not created
**Last Updated:** 2026-08-06

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
| Phase 2 — Create/Update tsp-location.yaml | 🔄 In Progress | |
| Phase 3 — Handle Legacy Configuration | ⏭️ Not Started | |
| Phase 4 — Update Custom Code | ⏭️ Not Started | |
| Phase 5 — Code Generation | ⏭️ Not Started | |
| Phase 6 — Build-Fix Cycle | ⏭️ Not Started | |
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

## Next Steps

1. Correct the C# emitter namespace and output directory in the spec.
2. Update `tsp-location.yaml` to the new emitter and spec commit.
3. Regenerate and resolve build/API compatibility issues.
