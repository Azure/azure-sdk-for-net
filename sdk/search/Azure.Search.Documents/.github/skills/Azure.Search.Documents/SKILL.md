---
name: Azure.Search.Documents
description: "**WORKFLOW SKILL** — Orchestrate the full release cycle for Azure.Search.Documents SDK including TypeSpec generation, customization fixes, API export, testing, and versioning. WHEN: \"search SDK release\", \"regenerate search SDK\", \"update search API version\", \"fix search customization errors\", \"search pre-release validation\". INVOKES: azsdk_package_generate_code, azsdk_package_build_code, azsdk_package_run_check, azsdk_package_update_changelog_content, azsdk_package_update_metadata MCP tools. FOR SINGLE OPERATIONS: Use azsdk MCP tools directly for one-off builds or generation."
---

# Azure.Search.Documents — Package Skill

## When to Use This Skill

Activate when user wants to:
- Prepare a new GA or preview release of Azure.Search.Documents
- Update to a new API spec version (new commit SHA)
- Regenerate SDK from TypeSpec and fix customization errors
- Run pre-release validation (build, test, API export, snippets)
- Understand the SDK architecture or customization patterns

## Prerequisites

- Read [references/architecture.md](references/architecture.md) — source layout, generated vs. custom split, namespace map, service version rules
- Read [references/customization.md](references/customization.md) — `CodeGenType`/`CodeGenMember`/`CodeGenSuppress` patterns, backward-compat retention

## MCP Tools Used

| Phase | MCP Tool | Purpose |
|-------|----------|---------|
| 2 | `azsdk_package_generate_code` | Generate SDK from TypeSpec |
| 3 | `azsdk_package_build_code` | Build and detect compilation errors |
| 7 | `azsdk_package_run_check` | Spelling, README, link integrity |
| 8 | `azsdk_package_update_changelog_content` | Draft changelog entries |
| 9 | `azsdk_package_update_metadata` | Update metadata.json |

## Steps

### Phase 0 — Determine Scope

Ask the user:
1. New API version or re-generation of current spec?
2. GA release or beta/preview release?
3. Target release date (for changelog)?

If new API version: get the new spec **commit SHA** and **API version string** (e.g., `2026-04-01`).

> **STOP** if the user cannot provide the commit SHA — do not guess or use HEAD.

### Phase 1 — Update `tsp-location.yaml`

*(Skip if commit SHA is not changing)*

Set `commit` to the new SHA in `sdk/search/Azure.Search.Documents/tsp-location.yaml`. Leave other fields unchanged.

### Phase 2 — Generate SDK from TypeSpec

Invoke `azsdk_package_generate_code` MCP tool with `tsp-location.yaml` path and workspace root.

### Phase 3 — Build and Fix Customizations

1. Invoke `azsdk_package_build_code` MCP tool
2. Check [references/architecture.md](references/architecture.md) and [references/customization.md](references/customization.md) for error patterns and fix guidance.
3. Prefer model renames, property renames, model visibility changes, and type changes directly updated in typespec `client.tsp` rather than in SDK code. Inform user of any such patterns detected in code and recommend typespec update for better long-term maintenance.

**Gate:** Clean build — zero errors.

### Phase 3.5 — Update `SearchClientOptions`

`src/SearchClientOptions.cs` is hand-written. Five locations must stay in sync — see "Service Version Management" in [references/architecture.md](references/architecture.md):

1. `ServiceVersion` enum — add new member
2. `LatestVersion` constant — point to new member
3. `Validate()` switch — add case
4. `ToVersionString()` switch — map enum → version string
5. `ToServiceVersion()` switch — map version string → enum

Placement rule: GA replacing a preview → replace at same integer; otherwise append.

**Gate:** All five locations in sync, and only the latest preview version is allowed to be included if preview release, and no preview versions allowed if GA release.

### Phase 4 — Export Public API

Run `eng\scripts\Export-API.ps1 search`. For GA: run `dotnet pack` to check ApiCompat.

**Gate:** No ApiCompat errors (GA only). If ApiCompat errors are detected, repeat phase 3.
> **NOTE**: NEVER update ApiCompat baseline or version without explicit directive. Prefer fixing code to match existing API shape unless intentional breaking change is being made. 

### Phase 5 — Run `dotnet format`

Format `src/`, `tests/`, and any changed `samples/` or `perf/` csproj files.

### Phase 6 — Update Samples and Snippets

Run `eng\scripts\Update-Snippets.ps1 search`. Add/update samples for new API features, then re-run if samples changed.

### Phase 7 — Run Tests

1. `dotnet test` with `--filter "TestCategory!=Live"`
2. Invoke `azsdk_package_run_check` MCP tool
3. Live tests only if provisioned service is available.

**Gate:** All non-live tests pass.

### Phase 8 — Update Changelog

Fill "Features Added", "Breaking Changes", "Bugs Fixed", "Other Changes" from generated code and API diffs. Write from the user's perspective. Use `azsdk_package_update_changelog_content` MCP tool if available.
Never include Breaking changes 

### Phase 9 — Update Version and Metadata

Run `eng\common\scripts\Prepare-Release.ps1 Azure.Search.Documents search <ReleaseDate>` (GA: `X.Y.Z`, Beta: `X.Y.Z-beta.N`). Invoke `azsdk_package_update_metadata` MCP tool.

### Phase 10 — Final Validation

Re-run any step whose outputs changed:

- [ ] Re-export API if `src/` changed since Phase 4
- [ ] Re-run snippets if `src/` or `*.md` changed since Phase 6
- [ ] `dotnet format` on changed csproj files
- [ ] `dotnet build` → `dotnet test` (non-live) → `dotnet pack` (GA only)



**Gate:** Clean build, all non-live tests pass, `git status` clean. 

## Execution Order Summary

| Phase | Action | Gate |
|-------|--------|------|
| 0 | Determine scope and release type | User provides commit SHA |
| 1 | Update `tsp-location.yaml` | — |
| 2 | Generate SDK | — |
| 3 | Build and fix errors | Zero errors |
| 3.5 | Update `SearchClientOptions` | All 5 locations in sync |
| 3.7 | Update test version references | No stale refs |
| 4 | Export public API | No ApiCompat errors (GA) |
| 5 | `dotnet format` | — |
| 6 | Update snippets and samples | — |
| 7 | Run tests | All non-live tests pass |
| 8 | Update changelog | All changes documented |
| 9 | Bump version and metadata | — |
| 10 | Final validation | Clean build + tests + `git status` |

## Reference Files

| File | Contents |
|------|----------|
| [references/architecture.md](references/architecture.md) | Source layout, generated vs. custom split, namespace map, service version rules |
| [references/customization.md](references/customization.md) | Customization attributes, patterns, backward-compat retention, serialization hooks |


