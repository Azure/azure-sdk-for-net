---
name: search-documents
description: 'Domain knowledge for Azure.Search.Documents SDK. Covers tool invocation, code generation, build, API export, testing, changelog, customization, and release workflows. Use when regenerating, building, fixing errors, customizing types, exporting API, running tests, or releasing the search SDK. Do not use for Azure.ResourceManager.Search or Azure.Provisioning.Search.'
---

# Azure.Search.Documents — Package Skill

Procedural workflows and tool invocations for the Azure.Search.Documents SDK. For detailed reference:
- [references/architecture.md](./references/architecture.md) — source layout, public clients, service version management, backward compat rules, retained types list
- [references/customization.md](./references/customization.md) — CodeGen attributes, TypeSpec-vs-C# decision table, SearchModelFactory patterns, post-regen update guide

---

## Package Identity

| Property | Value |
|---|---|
| Package name | `Azure.Search.Documents` |
| Root path | `sdk/search/Azure.Search.Documents/` |
| TypeSpec pin | `tsp-location.yaml` |
| Service directory key | `search` |

`src/Generated/` is auto-generated — **never hand-edit**. All other `src/` files are custom code extending generated `partial` classes. See [architecture.md](./references/architecture.md) for full layout and client list.

---

## Tool Reference
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

> **Rule:** Never edit files inside `src/Generated/`. Fix upstream in TypeSpec or add a C# customization (see [customization.md](./references/customization.md)).

---

### 2. `azsdk_package_build_code` — Build / Compile

```
azsdk_package_build_code
  packagePath: sdk/search/Azure.Search.Documents
```

Run after any change to `src/` or `src/Generated/`. Common error fixes:

| Error pattern | Fix |
|---|---|
| `does not contain a definition for 'Bar'` | Update custom partial or add `[CodeGenMember]` — see [customization.md](./references/customization.md) |
| `type or namespace 'Foo' does not exist` | Restore deleted type (if backward compat) or remove reference |
| `Ambiguous reference` | Add `[CodeGenSuppress]` on the generated member |
| Switch expression not exhaustive | Update all switch arms in `SearchClientOptions.cs` — see [architecture.md](./references/architecture.md#service-version-management) |

---

### 3. `Export-API.ps1` — Export Public API Surface

```powershell
eng/scripts/Export-API.ps1 search
```

Run after any public API change. Produces `api/Azure.Search.Documents.{net10.0,net8.0,netstandard2.0}.cs`.

> **Rule:** Never update `ApiCompatBaseline.txt` or `ApiCompatVersion` without explicit directive.

---

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

```powershell
eng/scripts/Update-Snippets.ps1 search
```

Run after adding/renaming public types that appear in samples. Ensure build passes first.

---

### 6. `azsdk_package_run_tests`

Takes several minutes. Avoid calling repeatedly.

```powershell
dotnet test sdk/search/Azure.Search.Documents/tests/ --filter "TestCategory!=Live"
```

Recordings are in a separate repo pointed to by `assets.json`.

---

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

> **Rule:** Verify every entry against `api/*.cs`. Use git tags to check what was in the previous release — see [architecture.md](./references/architecture.md#checking-previous-releases-via-git-tags).

---

### 8. Version and Metadata

```powershell
eng/common/scripts/Prepare-Release.ps1 Azure.Search.Documents search <ReleaseDate>
```

```
azsdk_package_update_metadata
  packagePath: sdk/search/Azure.Search.Documents
```

---

## Scenarios

### A: Release a New GA API Version

> **Prerequisite:** Have the spec **commit SHA** and **API version string** before starting.

1. Update `tsp-location.yaml` `commit` to the new SHA.
2. Run `azsdk_package_generate_code`.
3. Update `SearchClientOptions.cs` — add new `ServiceVersion` enum member, update all five locations. See [architecture.md](./references/architecture.md#service-version-management). No preview versions in GA.
4. Run `azsdk_package_build_code`. Fix errors per [Tool 2](#2-azsdk_package_build_code----build--compile) and [customization.md](./references/customization.md#identifying-what-needs-updating-after-regeneration).
5. Check for deleted types and apply backward compat rules per [architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types).
6. Run `Export-API.ps1 search`. Run `dotnet pack src/` to verify ApiCompat.
7. Run `dotnet format` on src and tests projects.
8. Run `Update-Snippets.ps1 search`.
9. Run `azsdk_package_run_tests` and `azsdk_package_run_check`.
10. Update `CHANGELOG.md` per [Tool 7](#7-azsdk_package_update_changelog_content--changelog).
11. Run `Prepare-Release.ps1` and `azsdk_package_update_metadata`.
12. Final gate: re-run Export-API if `src/` changed after step 6; re-run snippets if `*.md` changed after step 8; confirm `git status` is clean.

---

### B: Spec Patch (Same API Version, Not Yet Released)

1. Update `tsp-location.yaml` `commit`.
2. Run `azsdk_package_generate_code`.
3. Run `azsdk_package_build_code` and fix errors.
4. Check deleted types — only restore those in a previous GA release (see [architecture.md](./references/architecture.md#backwards-compatibility-for-removed-api-version-types)).
5. Update handwritten files as needed.
6. Run `Export-API.ps1 search`.
7. Run `dotnet format` on src and tests.
8. Run `Update-Snippets.ps1 search`.
9. Run `dotnet test --filter "TestCategory!=Live"`.
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
- **Forgetting `Export-API.ps1`** — CI ApiCompat fails.
- **Changelog entry for a non-existent type** — cross-check against `api/*.cs`.
- **Listing as "Breaking Change" a type never released** — not a breaking change; update "Features Added" instead.
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
