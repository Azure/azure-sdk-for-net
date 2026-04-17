---
name: search-documents
description: '**UTILITY SKILL** — Domain knowledge for the Azure.Search.Documents SDK package. Covers all supported developer tools, how to use each one for Search, architecture, customization patterns, and common scenarios (e.g. new API version release). WHEN: regenerate search package; modify search client; fix search build error; add search feature; customize types; export API surface; run tests; release new version.'
---

# Azure.Search.Documents — Package Skill

This skill is organized around **tools and capabilities** — what you can do and exactly how to do it for this package. Common scenarios (like releasing a new API version) are covered at the end as tool-composition workflows.

For deep reference, see:
- [references/architecture.md](./references/architecture.md) — full source layout, clients, service version rules, buffererd indexing
- [references/customization.md](./references/customization.md) — `CodeGenType`/`CodeGenMember`/`CodeGenSuppress` patterns

---

## Package Identity

| Property | Value |
|---|---|
| Package name | `Azure.Search.Documents` |
| Root path | `sdk/search/Azure.Search.Documents/` |
| TypeSpec pin | `tsp-location.yaml` |
| Solution | `Azure.Search.Documents.sln` |
| Service directory key | `search` (used by eng scripts) |

---

## Architecture at a Glance

`src/Generated/` — **never hand-edit**. All other `src/` files are custom code extending the generated `partial` classes.

**Public clients:**

| Client | Namespace | Purpose |
|---|---|---|
| `SearchClient` | `Azure.Search.Documents` | Document query (search, suggest, autocomplete) and document index/delete |
| `SearchIndexClient` | `Azure.Search.Documents.Indexes` | Indexes, synonym maps, aliases, knowledge bases, knowledge sources |
| `SearchIndexerClient` | `Azure.Search.Documents.Indexes` | Indexers, data sources, skillsets |
| `KnowledgeBaseRetrievalClient` | `Azure.Search.Documents.KnowledgeBases` | RAG-style retrieval from a knowledge base |
| `SearchIndexingBufferedSender<T>` | `Azure.Search.Documents` | Batched, retry-aware document upload |

---

## Tool Reference

### 1. `azsdk_package_generate_code` — Regenerate SDK from TypeSpec

**What it does:** Pulls the TypeSpec spec at the commit pinned in `tsp-location.yaml` and regenerates all files under `src/Generated/`.

**When to use:**
- Updating to a new spec commit / API version
- Picking up spec bug fixes without a version bump

**How to invoke:**
```
azsdk_package_generate_code
  packagePath: sdk/search/Azure.Search.Documents
```

**Inputs that may need to change first:**

| File | Field | When to change |
|---|---|---|
| `tsp-location.yaml` | `commit` | New API version or spec update |
| `tsp-location.yaml` | `directory` | Spec path changed (rare) |

Current `tsp-location.yaml`:
```yaml
repo: Azure/azure-rest-api-specs
commit: <SHA>
directory: specification/search/data-plane/Search
emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-emitter-package.json
```

**Post-generation checklist** (always verify after running):
- [ ] `src/Generated/` has changed files — normal
- [ ] New model files appear in `src/Generated/Models/` — normal, may need `@@access`/`@@usage` in TypeSpec `client.tsp`
- [ ] Deleted model files — check if backward-compat retention is required (see [Backward Compat](#backward-compat-for-deleted-types))
- [ ] `SearchClientOptions.cs` updated if the generated `ServiceVersion` mapping changed
- [ ] Build passes — run `azsdk_package_build_code` immediately after

> **Rule:** Never manually edit any file inside `src/Generated/`. Fix the TypeSpec spec or add a C# customization.

---

### 2. `azsdk_package_build_code` — Build / Compile

**What it does:** Runs `dotnet build` on the package and returns compilation errors.

**When to use:** After any change to `src/` or `src/Generated/`. Always run after generation.

**How to invoke:**
```
azsdk_package_build_code
  packagePath: sdk/search/Azure.Search.Documents
```

**Common build errors and fixes:**

| Error pattern | Cause | Fix |
|---|---|---|
| `'Foo' does not contain a definition for 'Bar'` | Generated property renamed or removed | Update custom partial to use new name, or add `[CodeGenMember]` alias |
| `The type or namespace 'Foo' does not exist` | Generated type deleted | Restore file (backward compat) or update reference |
| `Ambiguous reference` | Custom and generated both declare same member | Use `[CodeGenSuppress]` to remove generated one |
| `CS0115` override/implement mismatch | Method signature changed in generated layer | Align custom override signature |
| Switch expression not exhaustive | New `ServiceVersion` enum member added | Update all three switch arms in `SearchClientOptions.cs` |

When generated code introduces a type not previously public, you may need to add `@@access` or `@@usage` decorators in the TypeSpec `client.tsp` rather than duplicating visibility control in C#. Prefer TypeSpec for cross-language concerns.

---

### 3. `Export-API.ps1` — Export Public API Surface

**What it does:** Generates `api/Azure.Search.Documents.*.cs` snapshots of the public API surface. Required after any public API change so CI ApiCompat works correctly.

**When to use:**
- After any public member is added, removed, or renamed
- After regeneration (if public types changed)
- Before any release

**How to invoke:**
```powershell
eng\scripts\Export-API.ps1 search
```

**Output files** (committed to the repo):
```
api/Azure.Search.Documents.net10.0.cs
api/Azure.Search.Documents.net8.0.cs
api/Azure.Search.Documents.netstandard2.0.cs
```

**Gate for GA releases:** Also run `dotnet pack` which triggers ApiCompat automatically and verifies no breaking changes from `ApiCompatVersion`. 

> **Rule:** Never update `ApiCompatBaseline.txt` or `ApiCompatVersion` without explicit directive. Prefer fixing code to match existing API shape. Breaking changes require a major version bump.

---

### 4. `dotnet format` / `azsdk_package_run_check` — Code Quality Checks

**`dotnet format` — code style:**
```powershell
dotnet format sdk/search/Azure.Search.Documents/src/Azure.Search.Documents.csproj
dotnet format sdk/search/Azure.Search.Documents/tests/Azure.Search.Documents.Tests.csproj
```
Run on any `*.cs` file you modify. Required before committing.

**`azsdk_package_run_check` — repo-level lint (spelling, README links, metadata):**
```
azsdk_package_run_check
  packagePath: sdk/search/Azure.Search.Documents
```
Catches: cspell violations in new identifiers/comments, broken README links, malformed `metadata.json`, missing `CHANGELOG.md` entry.

---

### 5. `Update-Snippets.ps1` — Sync Samples and Snippets

**What it does:** Scans `samples/` and `README.md` for code snippet markers and regenerates the inline code blocks from the actual compilable sample files.

**When to use:**
- After adding or changing a public API that has a sample
- After renaming a type that appears in samples
- Before any release

**How to invoke:**
```powershell
eng\scripts\Update-Snippets.ps1 search
```

If samples reference a new type added in this release, ensure the type is compilable first (i.e., build passes) before running snippets.

---

### 6. `dotnet test` — Run Tests

**Unit/recorded tests (always run):**
```powershell
dotnet test sdk/search/Azure.Search.Documents/tests/ --filter "TestCategory!=Live"
```

**Live tests (requires provisioned service):**
```powershell
dotnet test sdk/search/Azure.Search.Documents/tests/ --filter "TestCategory=Live"
```

**Test layout:**
```
tests/
├── Batching/               # SearchIndexingBufferedSender tests
├── DocumentOperations/     # Search, get, suggest, autocomplete
├── Models/                 # Model serialization, factory
├── Samples/                # Runnable doc examples
├── Serialization/          # SearchDocument converter
└── SearchClientTests.cs / SearchIndexClientTests.cs / ...
```

**Recording playback:** Test recordings are stored in a separate repo, pointed to by `assets.json`. Recorded tests run in CI without a live service.

---

### 7. `azsdk_package_update_changelog_content` — Draft Changelog

**What it does:** Drafts changelog entries in `CHANGELOG.md` based on API diffs and commits.

**When to use:** After completing a release cycle, before cutting the release.

**How to invoke:**
```
azsdk_package_update_changelog_content
  packagePath: sdk/search/Azure.Search.Documents
```

**Sections to fill:**
- `## Features Added` — new public types, operations, overloads
- `## Breaking Changes` — removed/renamed public members (GA only)
- `## Bugs Fixed` — behavior corrections
- `## Other Changes` — dependency bumps, perf, internal refactors

> **Rule:** Verify every entry against `api/*.cs`. Do not list types that do not exist in the codebase. Compare against the previous GA version's API surface.

---

### 8. `Prepare-Release.ps1` / `azsdk_package_update_metadata` — Version and Metadata

**Bump version and changelog header:**
```powershell
eng\common\scripts\Prepare-Release.ps1 Azure.Search.Documents search <ReleaseDate>
# GA:      X.Y.Z           e.g. 12.0.0
# Preview: X.Y.Z-beta.N    e.g. 12.0.0-beta.1
```

**Update metadata.json:**
```
azsdk_package_update_metadata
  packagePath: sdk/search/Azure.Search.Documents
```

---

## Key Hand-Authored Files

These files are **never overwritten by regeneration**. They must be manually kept in sync.

### `src/SearchClientOptions.cs` — Service Version Registry

The single source of truth for all API versions the SDK supports. Five locations must always be in sync:

```csharp
// 1. Enum member
public enum ServiceVersion
{
    V2020_06_30 = 1,
    V2023_11_01 = 2,
    V2024_07_01 = 3,
    V2025_09_01 = 4,
    V2026_04_01 = 5,  // ← add new member here
}

// 2. LatestVersion constant
internal const ServiceVersion LatestVersion = ServiceVersion.V2026_04_01;

// 3. Validate() — add case for the new member (throws on invalid)
// 4. ToVersionString() — map enum → "2026-04-01"
// 5. ToServiceVersion() — map "2026-04-01" → enum  (used by test recordings)
```

> **Rule:** All five must be in sync. Missing a `ToVersionString` case causes a runtime `ArgumentOutOfRangeException`.  
> For preview releases: only the latest preview version is allowed. For GA: no preview versions allowed.

### `src/Indexes/FieldBuilder.cs`
Reflects `.NET` model types to produce `SearchField` definitions. Self-contained; rarely needs changes.

### `src/SearchFilter.cs`
Safe OData filter string builder. Add new overloads here for new filter capabilities.

### `Models/SearchModelFactory.cs`
Custom partial of the generated factory for backward-compat overloads. Update when generated factory method signatures change.

---

## Customization Patterns

> Full reference: [references/customization.md](./references/customization.md)

### When to customize in TypeSpec vs. C#

| Change | Where |
|---|---|
| Rename type/property for all languages | TypeSpec `client.tsp` → `@@clientName` |
| Change access (public→internal) for all languages | TypeSpec `client.tsp` → `@@access` |
| Language-specific convenience constructor | C# customization |
| Wrap `string` as `Uri`, `ETag`, `IList<string>` | C# customization |
| Suppress a generated constructor to replace it | C# `[CodeGenSuppress]` |
| Add semantic helpers (`FieldBuilder`, `SearchFilter`) | C# only |
| Multi-version backward compat for removed type | C# (restore deleted file) |

### Quick attribute reference

```csharp
[CodeGenType("OriginalGeneratedName")]    // renames a class/enum in the custom partial
[CodeGenMember("OriginalPropertyName")]  // renames a property/field in the custom partial
[CodeGenSuppress("MethodName", typeof(Arg1))]  // removes a generated constructor/method
```

### Backward Compat for Deleted Types

When regeneration deletes a model that existed in a prior GA version:
1. `git status` / `git diff --name-only` — identify deleted `src/Generated/Models/Foo.cs`
2. `git checkout HEAD -- src/Generated/Models/Foo.cs` — restore
3. The file stays in `Generated/` but is no longer overwritten by future regen
4. Add to the known retained types list in this skill under [Known Retained Types](#known-retained-types)

**Known retained types** (restored after deletion due to API version changes):
- `HybridSearch.cs`, `HybridCountAndFacetMode.cs`
- `IndexerRuntime.cs`
- `QueryLanguage.cs`, `QuerySpellerType.cs`, `QueryRewritesType.cs`
- `SemanticQueryRewritesResultType.cs`, `KnowledgeRetrievalOutputMode.cs`
- `QueryRewritesDebugInfo.cs`, `QueryRewritesValuesDebugInfo.cs`

---

## Common Scenarios

### Scenario A: Release a New GA API Version

This is the full workflow composing all tools above.

> **Prerequisite:** Have the new spec **commit SHA** and **API version string** (e.g., `2026-04-01`) before starting. Do not guess or use HEAD.

**Step 1 — Update `tsp-location.yaml`** 
Set `commit` to the new SHA. Leave all other fields unchanged.

**Step 2 — Regenerate**
```
azsdk_package_generate_code  packagePath: sdk/search/Azure.Search.Documents
```

**Step 3 — Update `SearchClientOptions.cs`**  
Add the new `ServiceVersion` enum member and update all five locations (see [Key Hand-Authored Files](#key-hand-authored-files)). No preview versions in a GA release.

**Step 4 — Fix build errors**
```
azsdk_package_build_code  packagePath: sdk/search/Azure.Search.Documents
```
Resolve any errors using the patterns in [Tool 2](#2-azsdk_package_build_code----build--compile).

**Step 5 — Update test version references**  
Search tests for stale version strings (`"2025-09-01"`, `ServiceVersion.V2025_09_01`, etc.) and update to the new version.

**Step 6 — Export public API**
```powershell
eng\scripts\Export-API.ps1 search
dotnet pack sdk/search/Azure.Search.Documents/src  # triggers ApiCompat
```
Zero ApiCompat errors required. Never update baseline without explicit approval.

**Step 7 — Format**
```powershell
dotnet format sdk/search/Azure.Search.Documents/src/Azure.Search.Documents.csproj
dotnet format sdk/search/Azure.Search.Documents/tests/Azure.Search.Documents.Tests.csproj
```

**Step 8 — Snippets**
```powershell
eng\scripts\Update-Snippets.ps1 search
```

**Step 9 — Tests**
```powershell
dotnet test sdk/search/Azure.Search.Documents/tests/ --filter "TestCategory!=Live"
azsdk_package_run_check  packagePath: sdk/search/Azure.Search.Documents
```

**Step 10 — Changelog**
```
azsdk_package_update_changelog_content  packagePath: sdk/search/Azure.Search.Documents
```
Verify every entry against `api/*.cs`.

**Step 11 — Version and metadata**
```powershell
eng\common\scripts\Prepare-Release.ps1 Azure.Search.Documents search <ReleaseDate>
```
```
azsdk_package_update_metadata  packagePath: sdk/search/Azure.Search.Documents
```

**Step 12 — Final gate**
Re-run any step whose outputs changed since it last ran:
- [ ] `src/` changed after Step 6 → re-run Export-API
- [ ] `src/` or `*.md` changed after Step 8 → re-run snippets
- [ ] `dotnet build` → `dotnet test` (non-live) → `dotnet pack` (ApiCompat)
- [ ] `git status` clean (no unintentionally modified files)

---

### Scenario B: Regenerate Without Changing API Version

Use this when picking up a spec bug fix on the same API version.

1. Update `commit` in `tsp-location.yaml` to the new SHA
2. Run `azsdk_package_generate_code`
3. Run `azsdk_package_build_code` and fix any errors
4. Run `Export-API.ps1 search` and check for unintended API surface changes
5. Run `dotnet test --filter "TestCategory!=Live"`

---

### Scenario C: Add a C# Customization to a Generated Type

1. Identify the generated type in `src/Generated/` (do not edit it)
2. Create or update the corresponding custom partial file in `src/` (see [architecture.md](./references/architecture.md) for the file mapping)
3. Apply the appropriate attribute (`[CodeGenType]`, `[CodeGenMember]`, `[CodeGenSuppress]`)
4. Run `azsdk_package_build_code` to verify
5. If a public API changed: run `Export-API.ps1 search`

**Prefer TypeSpec first:** If the rename or visibility change should apply to all language SDKs, update `client.tsp` in `azure-rest-api-specs` and regenerate instead of adding a C# customization.

---

### Scenario D: Fix a Build Error After Regeneration

1. Read the error message carefully — identify the file, type, and member
2. Check if the generated type/member was renamed: look in `src/Generated/` for the new name
3. Choose the fix:
   - Rename in custom partial → use `[CodeGenMember("OldName")]`
   - Type no longer exists → restore deleted file (see [Backward Compat](#backward-compat-for-deleted-types)) or remove reference
   - Ambiguous declaration → add `[CodeGenSuppress]` on the generated version
   - Switch exhaustiveness → add the new `ServiceVersion` case to all three switches
4. Run `azsdk_package_build_code` again to confirm clean build

---

## Keeping Reference Docs in Sync

The reference files in `.github/skills/search-documents/references/` are the long-term memory for this package. They must stay accurate or future agents will make decisions based on stale information.

**After completing any task, check whether the following changed and update the relevant reference file if so:**

| If you changed… | Update in `references/` |
|---|---|
| Added/removed/renamed a client type or namespace | `architecture.md` → Public Client Types table, Namespaces table |
| Added/removed a `src/` directory or significant file | `architecture.md` → Source Layout section |
| Added/removed a custom partial class or key hand-authored file | `architecture.md` → Generated vs. Custom table, Key Supporting Files table |
| Changed `ServiceVersion` enum (new version, removed version) | `architecture.md` → Service Version Management section |
| Added/modified a `[CodeGenType]`, `[CodeGenMember]`, or `[CodeGenSuppress]` usage | `customization.md` → relevant pattern section and usage table |
| Restored a deleted generated type for backward compat | `architecture.md` → Backwards Compatibility section; this skill → Known Retained Types list |
| Added a new test directory or changed test framework conventions | `architecture.md` → Tests section |
| Changed how the `SearchModelFactory` custom partial works | `customization.md` → SearchModelFactory Customizations section |

**Rule:** If you're unsure whether a change is significant enough to document, document it. Stale reference docs are harder to fix than over-documented ones.

---

## Common Pitfalls

- **Editing `src/Generated/`** — changes are wiped on next regeneration. Use custom partial classes.
- **Missing a `ToVersionString` / `ToServiceVersion` case** — causes silent `ArgumentOutOfRangeException` at runtime, not a compile error.
- **Forgetting to re-export API after public changes** — CI ApiCompat fails on the PR.
- **Writing changelog entries for types that don't exist** — always cross-check against `api/*.cs`.
- **Not running `dotnet format`** — CI style check fails.
- **Adding a preview `ServiceVersion` to a GA release** — remove all preview-only version arms before tagging GA.
- **Restoring a deleted type to the wrong directory** — restored types go back to `src/Generated/Models/`, not `src/Models/`.
