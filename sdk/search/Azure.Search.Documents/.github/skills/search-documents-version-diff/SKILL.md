---
name: search-documents-version-diff
description: Diff the current Azure.Search.Documents public API surface against a previous published version and detect preview-to-preview regressions where the SDK customization layer was not bubbled up after a TypeSpec change. Use whenever the user asks to compare Azure.Search.Documents betas, verify no Azure.Search.Documents preview features dropped, audit a regen for Azure.Search.Documents, sanity-check a release branch for Azure.Search.Documents, or investigate a missing Azure.Search.Documents preview feature — even if they don't say the word "diff". Specifically catches dropped wrappers (QueryAnswer/QueryCaption/QueryRewrites style), lost SearchOptions aggregator redirectors, `@@access("internal")` flips, deleted-instead-of-gated `#if AZURE_SEARCH_PREVIEW` blocks, dropped `ServiceVersion` enum values, and convenience-to-protocol downgrades.
---

# Azure.Search.Documents — Version Diff

| Property | Value |
|---|---|
| Package | `Azure.Search.Documents` |
| Root | `sdk/search/Azure.Search.Documents/` |
| Public API listing | `api/Azure.Search.Documents.netstandard2.0.cs` |
| TypeSpec pin | `tsp-location.yaml` (`commit:`) |

## When to use

The `Azure.Search.Documents` SDK ships a hand-customized layer over generated code. When a new TypeSpec or `client.tsp` lands, regen can silently drop a previously-shipped public API because the customization wasn't reapplied. A plain `git diff` will not surface this — you need to compare the *shipped public surface*, then classify each removal against what the current spec and generated code still contain.

Use this skill to produce that classified diff. Do **not** use it for:
- Generating a changelog — use the package's changelog tooling.
- Validating SDK ↔ spec parity at the current commit only — use [search-documents-typespec-validation](../search-documents-typespec-validation/SKILL.md).
- Updating `ApiCompatBaseline*.txt` — see pitfall #8 in [search-documents](../search-documents/SKILL.md).

## Inputs

| Input | Source |
|---|---|
| Previous version reference | Git tag (`Azure.Search.Documents_<version>`), branch, commit SHA, or local `.nupkg` |
| Current API listing | `api/Azure.Search.Documents.netstandard2.0.cs` (working tree) |
| Both TypeSpec commits | `tsp-location.yaml` on each side (auto-resolved by the script) |
| Both channel labels | `<Version>` in each `Azure.Search.Documents.csproj` — preview iff contains `beta` (auto) |

If the user does not specify a previous reference, list the most recent tags and ask. **Do not silently default to `origin/main`** — it leads to nonsense diffs when main already contains the current branch.

```pwsh
git tag --list 'Azure.Search.Documents_*' --sort=-creatordate | Select-Object -First 10
```

## Workflow

### 1. Resolve baselines and run the diff script

The deterministic work — git-fetching both sides, parsing types/members, computing added/removed/changed buckets — lives in [scripts/Compare-ApiSurface.ps1](scripts/Compare-ApiSurface.ps1). Run it first, then operate on the JSON it produces.

```pwsh
./scripts/Compare-ApiSurface.ps1 -PreviousRef Azure.Search.Documents_<version>
# default output: sdk/search/Azure.Search.Documents/artifacts/search-version-diff.json
```

The JSON includes: `previous`/`current` metadata (version, channel, tspCommit), `comparisonMode` (`preview->preview` etc.), and `addedTypes` / `removedTypes` / `changedTypes` / `addedMembers` / `removedMembers` arrays.

**Non-obvious**: if the previous side is a `.nupkg`, the script throws. Extract `lib/netstandard2.0/Azure.Search.Documents.dll`, decompile to a single `.cs` listing with `Microsoft.CodeAnalysis` or ildasm, commit it to a local throwaway branch, and pass that branch as `-PreviousRef`. Do not paper over a missing baseline by pointing at `origin/main`.

### 2. Pick the comparison mode

Read `comparisonMode` from the JSON. It controls how aggressively to flag removals:

| Mode | Removal interpretation |
|---|---|
| `preview->preview` | Primary focus. Removals are likely regressions unless the spec also removed the feature. |
| `GA->preview` | Removals usually intentional shedding before GA. Flag as **By design** unless the user disputes. |
| `preview->GA` | Removals expected (preview-only features did not promote). Flag as **By design**. |
| `GA->GA` | Any removal is a **Critical breaking change**. Stop and surface immediately. |

### 3. Classify each removed/changed symbol

For every entry in `removedMembers`, `removedTypes`, and `changedTypes`, pick a pattern from [references/heuristics.md](references/heuristics.md). That file defines seven named patterns (P1–P7) with signals and fix locations, plus a decision aid at the bottom.

**Non-obvious step**: classifying correctly requires looking at the **current TypeSpec at its pinned commit** — not the spec checked out locally, which may be on a different SHA than `tsp-location.yaml`. Fetch raw via:

```pwsh
$sha = ((Get-Content tsp-location.yaml | Select-String '^commit:').Line -replace '^commit:\s*','').Trim()
curl -s "https://raw.githubusercontent.com/Azure/azure-rest-api-specs/$sha/specification/search/Search.Service/client.tsp"
```

Also search `src/Generated/Models/` locally — many "removed" public symbols still exist there as `internal` (pattern P3) or as `*Raw` siblings (pattern P1). If the heuristic decision aid can't place an item, leave it as P7 — do not guess.

### 4. Write the report

Write a single Markdown file to `artifacts/search-version-diff.md`. Use exactly this structure so reviewers can navigate by header:

```markdown
# Azure.Search.Documents — Version Diff Report

| | Previous | Current |
|---|---|---|
| Version | <prev-version> | <current-version> |
| Channel | <preview|GA> | <preview|GA> |
| TypeSpec SHA | <prev-sha> | <current-sha> |
| Comparison mode | <preview->preview|...> | |

## Summary
- Removed: <N> types, <M> members
- Added: <N> types, <M> members
- Changed: <N> types
- **Regressions (action required): <N>**

## Regressions (action required)
| Symbol | Scope | Pattern | Evidence | Fix location |
|---|---|---|---|---|
| `SemanticSearchOptions.QueryRewrites` | Property | P1 — wrapper dropped | `QueryRewritesRaw` still in `src/Generated/Models/SemanticSearchOptions.cs` | `src/Models/SemanticSearchOptions.cs` partial, gated `#if AZURE_SEARCH_PREVIEW` |

## By-design drops
Items the spec intentionally removed (preview shedding into GA, or `@@access("internal")` confirmed intentional). No action.

## Renamed / Changed
Old → new, with the rename source (`@@clientName`, `[CodeGenMember]`, manual partial class).

## Added (informational)
Bullet list of new public symbols. No action.

## Open questions (P7)
Items the heuristics could not classify. Flag for human review.
```

In chat, echo **only** the Summary and Regressions sections. Everything else stays in the file.

### 5. Stop conditions

- If the previous baseline cannot be resolved → stop, ask the user. Do not fall back.
- If `comparisonMode == GA->GA` and any member is removed → stop and surface to the user immediately; this is release-blocking.
- If more than ~20 items land in P7 → the heuristics are stale for this regen. Surface a few examples to the user and ask whether to extend [references/heuristics.md](references/heuristics.md) before continuing.

## Output

- File: `sdk/search/Azure.Search.Documents/artifacts/search-version-diff.md`
- Chat: Summary table + Regressions table only.

## Related skills

- [search-documents](../search-documents/SKILL.md) — E2E workflow, customization patterns, pitfalls.
- [search-documents-typespec-validation](../search-documents-typespec-validation/SKILL.md) — single-commit SDK ↔ spec parity check (no version comparison).
