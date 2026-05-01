---
name: search-documents
description: 'Domain knowledge for Azure.Search.Documents SDK. Covers tool invocation, code generation, build, API export, testing, changelog, customization, and release workflows. Use when regenerating, building, fixing errors, customizing types, exporting API, running tests, or releasing the search SDK. Do not use for Azure.ResourceManager.Search or Azure.Provisioning.Search.'
description: 'Domain knowledge for Azure.Search.Documents SDK. Covers tool invocation, code generation, build, API export, testing, changelog, customization, and release workflows. Use when regenerating, building, fixing errors, customizing types, exporting API, running tests, or releasing the search SDK. Do not use for Azure.ResourceManager.Search or Azure.Provisioning.Search.'
---

# Azure.Search.Documents — Package Skill

Procedural workflows and tool invocations for the Azure.Search.Documents SDK. For detailed reference:
- [references/architecture.md](./references/architecture.md) — source layout, public clients, service version management, backward compat rules, retained types list
- [references/customization.md](./references/customization.md) — CodeGen attributes, TypeSpec-vs-C# decision table, SearchModelFactory patterns, post-regen update guide
- [scripts/Classify-BuildErrors.ps1](./scripts/Classify-BuildErrors.ps1) — build error classification script for batch resolution

---

## Package Identity

| Property | Value |
|---|---|
| Package name | `Azure.Search.Documents` |
| Root path | `sdk/search/Azure.Search.Documents/` |
| TypeSpec pin | `tsp-location.yaml` |
| Service directory key | `search` |
| Service directory key | `search` |

`src/Generated/` is auto-generated — **never hand-edit**. All other `src/` files are custom code extending generated `partial` classes. See [architecture.md](./references/architecture.md) for full layout and client list.
`src/Generated/` is auto-generated — **never hand-edit**. All other `src/` files are custom code extending generated `partial` classes. See [architecture.md](./references/architecture.md) for full layout and client list.

---

## Tool Reference
ALWAYS attempt to use available MCP tools for each of the below steps. Do not manually invoke scripts unless a tool is unavailable or fails after repeated attempts.

### 1. `azsdk_package_generate_code` — Regenerate from TypeSpec

Takes 2+ minutes. Avoid calling repeatedly.

ALWAYS attempt to use available MCP tools for each of the below steps. Do not manually invoke scripts unless a tool is unavailable or fails after repeated attempts.

### 1. `azsdk_package_generate_code` — Regenerate from TypeSpec

Takes 2+ minutes. Avoid calling repeatedly.

```
azsdk_package_generate_code
  packagePath: sdk/search/Azure.Search.Documents
```

**Before invoking:** Update `tsp-location.yaml` `commit` field if the spec SHA changed.

**After invoking:**
1. Check for deleted files: `git diff --diff-filter=D --name-only HEAD -- src/Generated/`.
2. Decide whether to restore deleted types — see [backward compat rules in architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types).
3. Run `azsdk_package_build_code` immediately.
**Before invoking:** Update `tsp-location.yaml` `commit` field if the spec SHA changed.

**After invoking:**
1. Check for deleted files: `git diff --diff-filter=D --name-only HEAD -- src/Generated/`.
2. Decide whether to restore deleted types — see [backward compat rules in architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types).
3. Run `azsdk_package_build_code` immediately.

> **Rule:** Never edit files inside `src/Generated/`. Fix upstream in TypeSpec or add a C# customization (see [customization.md](./references/customization.md)).
> **Rule:** Never edit files inside `src/Generated/`. Fix upstream in TypeSpec or add a C# customization (see [customization.md](./references/customization.md)).

---

### 2. `azsdk_package_build_code` — Build / Compile

```
azsdk_package_build_code
  packagePath: sdk/search/Azure.Search.Documents
```

Run after any change to `src/` or `src/Generated/`.

#### Error Resolution Strategy

When the build fails with multiple errors, **do not fix errors one-by-one**. Use the classification script to batch them:

**Step 1 — Classify errors.** Read and execute [scripts/Classify-BuildErrors.ps1](./scripts/Classify-BuildErrors.ps1):

```powershell
pwsh sdk/search/Azure.Search.Documents/.github/skills/search-documents/scripts/Classify-BuildErrors.ps1
```

This outputs a JSON report that:
- Deduplicates errors across target frameworks (e.g., 81 raw errors → ~27 unique)
- Groups by root cause `(errorCode, targetSymbol)` (e.g., 27 unique errors → ~9 groups)
- Identifies the generated file defining each changed symbol
- Separates fixable (custom code) from non-fixable (generated code) call sites
- Sorts groups by count descending (biggest impact first)

**Step 2 — Fix each root-cause group as a batch.** For each group in the report:

1. **Read the generated file** listed in `generatedFile` to understand the new signature and what each new parameter represents (1 read)
2. **Read all affected custom files** listed in `fixableSites` in parallel (1 read call)
3. **Determine the correct value for each new parameter at each call site** (see rules below)
4. **Apply all fixes for the group** via `multi_replace_string_in_file` (1 edit call)

This is ~3 tool calls per group instead of ~3 per error.

**Step 2a — Choosing the right value (not just `default`).** Do NOT blindly pass `null`/`default` for new parameters. Classify each call site by purpose:

| Call site type | How to handle new parameters |
|---|---|
| **SearchModelFactory method** | Always add the new parameter to the factory method signature so callers can set it. Forward to the generated constructor. |
| **Custom convenience constructor** | Accept the new parameter (with a default) and forward it to the generated constructor. |
| **Custom method building a request** | Source the value from the available context (e.g., options object, request properties, response fields). Use `null` only if the parameter is genuinely optional and no source exists. |
| **Custom method parsing a response** | Extract the value from the response/deserialized data and pass it through. |
| **Test helper / sample code** | May use `default` since it's constructing test data, but prefer realistic values when available. |

> **Principle:** Every new generated parameter represents a new feature. If custom code wraps that generated code, it should *expose* the feature to callers, not hide it behind `default`. A `null`/`default` is acceptable only when the calling context genuinely has no source for that data.

**Step 3 — Rebuild** to verify. If new errors appear, re-run the script.

#### Common error code patterns

| Error Code | Meaning | Typical Fix |
|---|---|---|
| CS7036 | Missing required parameter | Determine proper value per call site type (see Step 2a above) |
| CS1729 | Wrong constructor arg count | Same as CS7036 |
| CS1503 | Arg type mismatch (params shifted) | Same as CS7036 — classify call site and wire up properly |
| CS0246/CS0234 | Type/namespace not found | Restore deleted type (if backward compat) or remove reference |
| CS0117 | Member not found on type | Update custom partial or add `[CodeGenMember]` |
| Ambiguous reference | Duplicate member from generated + custom | Add `[CodeGenSuppress]` on the generated member |
| Switch not exhaustive | Missing enum case | Update all switch arms in `SearchClientOptions.cs` |

> **Rule:** Never fix errors by editing `src/Generated/`. Fix upstream in TypeSpec or add a C# customization (see [customization.md](./references/customization.md)).

---

### 3. `Export-API.ps1` — Export Public API Surface

```powershell
eng/scripts/Export-API.ps1 search
eng/scripts/Export-API.ps1 search
```

Run after any public API change. Produces `api/Azure.Search.Documents.{net10.0,net8.0,netstandard2.0}.cs`.
Run after any public API change. Produces `api/Azure.Search.Documents.{net10.0,net8.0,netstandard2.0}.cs`.

> **Rule:** Never update `ApiCompatBaseline.txt` or `ApiCompatVersion` without explicit directive.
> **Rule:** Never update `ApiCompatBaseline.txt` or `ApiCompatVersion` without explicit directive.

---

### 4. Code Quality

### 4. Code Quality

```powershell
dotnet format sdk/search/Azure.Search.Documents/src/Azure.Search.Documents.csproj
dotnet format sdk/search/Azure.Search.Documents/tests/Azure.Search.Documents.Tests.csproj
```

```
azsdk_package_run_check
  packagePath: sdk/search/Azure.Search.Documents
```

---

### 5. `Update-Snippets.ps1`

### 5. `Update-Snippets.ps1`

```powershell
eng/scripts/Update-Snippets.ps1 search
eng/scripts/Update-Snippets.ps1 search
```

Run after adding/renaming public types that appear in samples. Ensure build passes first.
Run after adding/renaming public types that appear in samples. Ensure build passes first.

---

### 6. `azsdk_package_run_tests` - Execute tests

Takes several minutes. Avoid calling repeatedly.

Run the `azsdk_package_run_tests` tool.

Recordings are in a separate repo pointed to by `assets.json`.

---

### 7. `azsdk_package_update_changelog_content` — Changelog
### 7. `azsdk_package_update_changelog_content` — Changelog

```
azsdk_package_update_changelog_content
  packagePath: sdk/search/Azure.Search.Documents
```

May return `noop` — manually draft entries in comparison to the previous release tag.

**Changelog patching rules:**
- If the topmost version has **not shipped to NuGet**, patch that entry in-place. Do not create a new version section.
- If the topmost version has an `(Unreleased)` header, add entries directly to it.
- Only create a new section when the topmost version has already been released.

**Breaking change classification:**
- Only removals/renames of types from a **previously released** version are breaking changes.
- Types introduced in the current unreleased version and then removed are **not** breaking changes — update "Features Added" instead.
May return `noop` — manually draft entries in comparison to the previous release tag.

**Changelog patching rules:**
- If the topmost version has **not shipped to NuGet**, patch that entry in-place. Do not create a new version section.
- If the topmost version has an `(Unreleased)` header, add entries directly to it.
- Only create a new section when the topmost version has already been released.

**Breaking change classification:**
- Only removals/renames of types from a **previously released** version are breaking changes.
- Types introduced in the current unreleased version and then removed are **not** breaking changes — update "Features Added" instead.

> **Rule:** Verify every entry against `api/*.cs`. Use git tags to check what was in the previous release — see [architecture.md](./references/architecture.md#checking-previous-releases-via-git-tags).

---

### 8. Version and Metadata

> **Rule:** Verify every entry against `api/*.cs`. Use git tags to check what was in the previous release — see [architecture.md](./references/architecture.md#checking-previous-releases-via-git-tags).

---

### 8. Version and Metadata

```powershell
eng/common/scripts/Prepare-Release.ps1 Azure.Search.Documents search <ReleaseDate>
eng/common/scripts/Prepare-Release.ps1 Azure.Search.Documents search <ReleaseDate>
```

```
azsdk_package_update_metadata
  packagePath: sdk/search/Azure.Search.Documents
```

---

## Scenarios

### A: Release a New API Version (GA or Preview)

> **Prerequisite:** Have the spec **commit SHA** and **API version string** before starting.

1. Update `tsp-location.yaml` `commit` to the new SHA.
2. Run `azsdk_package_generate_code`.
3. Update `SearchClientOptions.cs` — add new `ServiceVersion` enum member, update all six locations. See [architecture.md](./references/architecture.md#service-version-management).
   - **GA**: Remove any preview versions from the enum and all six locations.
   - **Preview**: Add the preview version to the enum and all six locations. Keep the latest GA version as `LatestVersion` for non-preview builds.
4. Update preview tests. See [architecture.md](./references/architecture.md#preview-tests-azure_search_preview).
   - **GA**: Promote preview test files — remove `#if AZURE_SEARCH_PREVIEW` guards, merge into main test classes or update `[ClientTestFixture]` to the new GA version.
   - **Preview**: Create `*.Preview.cs` test files wrapped in `#if AZURE_SEARCH_PREVIEW` for preview-specific features.
5. Run `azsdk_package_build_code`. Fix errors per [Error Resolution Strategy](#error-resolution-strategy) and [customization.md](./references/customization.md#identifying-what-needs-updating-after-regeneration).
6. Check for new properties on `SearchOptions`, `FacetResult`, `SearchResults`, and other types with custom deserialization. Wire them per [architecture.md](./references/architecture.md#searchoptions-property-wiring).
7. Check for deleted types and apply backward compat rules per [architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types).
7. Check for deleted types and apply backward compat rules per [architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types).
8. Run `Export-API.ps1 search`. Run `dotnet pack src/` to verify ApiCompat.
9. Run `dotnet format` on src and tests projects.
10. Update `SearchTestBase`'s `[ClientTestFixture]` to include the new API version (latest GA + latest preview). Do NOT add `[ClientTestFixture]` to derived classes — they inherit from `SearchTestBase`. See [architecture.md](./references/architecture.md#service-version-test-matrix).
11. Run `Update-Snippets.ps1 search`.
12. Run `azsdk_package_run_tests` and `azsdk_package_run_check`.
13. Update `CHANGELOG.md` per [Tool 7](#7-azsdk_package_update_changelog_content--changelog).
14. Update `src/Azure.Search.Documents.csproj` `<Version>` (use `-beta.N` suffix for preview). Run `Prepare-Release.ps1` and `azsdk_package_update_metadata`.
15. Final gate: re-run Export-API if `src/` changed after step 8; re-run snippets if `*.md` changed after step 11; confirm `git status` is clean.

---

### B: Spec Patch (Same API Version, Not Yet Released)
### B: Spec Patch (Same API Version, Not Yet Released)

1. Update `tsp-location.yaml` `commit`.
2. Run `azsdk_package_generate_code`.
3. Run `azsdk_package_build_code` and fix errors.
4. Check deleted types — only restore those in a previous GA release (see [architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types)).
5. Update handwritten files as needed.
6. Run `Export-API.ps1 search`.
7. Run `dotnet format` on src and tests.
8. Run `Update-Snippets.ps1 search`.
9. Run `azsdk_package_run_tests`.
10. Patch the existing `CHANGELOG.md` entry in-place per [Tool 7](#7-azsdk_package_update_changelog_content--changelog).

---

### C: Add a C# Customization

1. Identify the generated type in `src/Generated/` (do not edit it).
2. Create or update the custom partial file in `src/`. See [customization.md](./references/customization.md) for attribute patterns and the file mapping in [architecture.md](./references/architecture.md#generated-vs-custom-partial-classes).
3. Run `azsdk_package_build_code` to verify.
4. If public API changed: run `Export-API.ps1 search`.

> Prefer TypeSpec `client.tsp` for cross-language concerns (`@@clientName`, `@@access`). Use C# customization only for language-specific behavior.

---

## Common Pitfalls

- **Editing `src/Generated/`** — wiped on next regen. Use custom partials.
- **Missing a `ToVersionString` case** — silent runtime `ArgumentOutOfRangeException`.
- **Referencing preview `ServiceVersion` in tests without `#if AZURE_SEARCH_PREVIEW`** — GA builds fail to compile.
- **Forgetting `Export-API.ps1`** — CI ApiCompat fails.
- **Changelog entry for a non-existent type** — cross-check against `api/*.cs`.
- **Listing as "Breaking Change" a type never released** — not a breaking change; update "Features Added" instead.
- **New generated `SearchOptions` property not wired** — property exists in generated code but is silently ignored at runtime. See [architecture.md](./references/architecture.md#searchoptions-property-wiring) for the bridge property pattern and verification checklist.
- **Custom `Deserialize*` method ignoring new properties** — `FacetResult`, `SearchResults<T>`, and other types with custom deserialization drop new fields unless explicitly updated. See [architecture.md](./references/architecture.md#facetresult-and-searchresults-deserialization).
- **Restoring a preview-only deleted type** — only restore types from previous GA releases.
- **Creating a new changelog section for unreleased version** — patch in-place.

---

## Keeping References in Sync

After completing any task, check if these changed and update the relevant reference:

| Change | Update |
|---|---|
| Client types, namespaces, source layout | [architecture.md](./references/architecture.md) |
| `ServiceVersion` enum | [architecture.md](./references/architecture.md#service-version-management) |
| Restored a deleted type | [architecture.md](./references/architecture.md#known-retained-types) |
| `CodeGenType`/`CodeGenMember`/`CodeGenSuppress` usage | [customization.md](./references/customization.md) |
| `SearchModelFactory` custom partial | [customization.md](./references/customization.md#searchmodelfactory-customizations) |
