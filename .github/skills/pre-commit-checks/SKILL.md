---
name: pre-commit-checks
description: Pre-commit validation checks for azure-sdk-for-net. Use this before committing or pushing changes to SDK packages. Runs dotnet format, exports public API listings, updates snippets, and regenerates code as needed.
---

# Pre-Commit Validation Checks

Run these checks after making changes to SDK packages under `sdk/` and **before** staging, committing, or pushing. These steps may produce additional file changes that must be included in the commit.

> **General rule:** Steps 3–5 are conditional to save time, but if you are unsure whether a step is needed, **always run it**. It is better to run an unnecessary script than to miss a required regeneration.

## 1. Determine scope from changed files

- Derive the changed file list from `git status --porcelain` (or by combining `git diff --name-only HEAD` with `git ls-files -o --exclude-standard`) so that **untracked (new) files are included**.
- From the changed file list, extract **all unique ServiceDirectories** — the first path segment after `sdk/` (e.g., `sdk/storage/...` → `storage`, `sdk/ai/...` → `ai`).
- For each ServiceDirectory, identify **all affected packages** = distinct `sdk/{ServiceDirectory}/{PackageName}/` paths.
- For each affected package, identify:
  - **All csproj files** that had changes beneath them (src, tests, samples, perf, stress, or any other project type).
  - **The src csproj** specifically = `sdk/{service}/{package}/src/{Package}.csproj` — this is used for GenerateCode.
- The remaining steps must be run **for each affected project/ServiceDirectory**. If changes span multiple ServiceDirectories or packages, run for each one.

## 2. Run `dotnet format` (for every changed csproj)

For **every** csproj that had files change beneath it — src, tests, samples, perf, stress, or any other project type — run:

```shell
dotnet format <path-to-changed.csproj>
```

Identify affected csproj files by looking at the full changed file list: include any project where either (a) there is a changed `.cs` file with that `.csproj` as its nearest parent, or (b) the `.csproj` itself changed, or files such as `.props`, `.targets`, or `.md` changed under that project. This fixes style/formatting issues and may modify `.cs` files.

## 3. Conditionally run `dotnet build /t:GenerateCode` (per src csproj)

**Trigger condition — for each affected package's src csproj:** Run this if ANY of the following files are in the changed file list:

- Any file matching `sdk/{service}/{package}/src/Generated/**`
- `sdk/{service}/{package}/tsp-location.yaml`
- `sdk/{service}/{package}/src/autorest.md`
- Any `.cs` file under `sdk/{service}/{package}/src/` where a `CodeGen*` attribute was added, removed, or modified (e.g., `CodeGenType`, `CodeGenModel`, `CodeGenClient`, `CodeGenMember`, `CodeGenSuppress`, `CodeGenSerialization`, `CodeGenVisibility`). These attributes in custom (non-generated) code influence the generated output.

**Important:** Do not manually edit files under `src/Generated/`. Changes to generated code should only come from running the `GenerateCode` target.

**Command:**

```shell
dotnet build sdk/{service}/{package}/src/{Package}.csproj /t:GenerateCode
```

This regenerates code from TypeSpec/AutoRest specs. It may modify files under `src/Generated/`.

## 4. Conditionally run `Export-API.ps1` (per ServiceDirectory)

**Trigger condition — per ServiceDirectory:** Run this if ANY of the following are true for ANY affected package within this ServiceDirectory:

- Step 3 above ran for any package in this ServiceDirectory (generated code may affect public API).
- Changed `.cs` files under `sdk/{service}/{package}/src/` for any package in this ServiceDirectory contain public API surface changes. To determine this, inspect the diffs for:
  - New, removed, or renamed `public` or `protected` types (`class`, `interface`, `struct`, `enum`, `record`).
  - New, removed, or changed signatures of `public` or `protected` members (methods, properties, constructors, events, fields).
  - Visibility changes (e.g., `internal` → `public`).
  - Changes to base classes or implemented interfaces on public types.
  - New `.cs` files under `src/` that contain `public` types.

**Skip Export-API if** changes are limited to:

- Method body implementations (no signature changes).
- `internal` or `private` members only.
- XML doc comments or code comments.
- `.csproj` configuration changes.

**Command:**

```shell
eng\scripts\Export-API.ps1 {ServiceDirectory}
```

This regenerates API listing files under `sdk/{service}/{package}/api/*.cs`. Uses `dotnet build /t:ExportApi` internally.

Note: Export-API operates at the ServiceDirectory level (not per-csproj), so run it once per affected ServiceDirectory.

## 5. Conditionally run `Update-Snippets.ps1` (per ServiceDirectory)

**Trigger condition — for each affected ServiceDirectory:** Run this if ANY of the following are true:

- Changed `*.md` files under `sdk/{service}/` contain snippet references (`` ```C# Snippet: `` markers).
- Changed `.cs` files contain snippet regions (`#region Snippet:`).

**Command:**

```shell
eng\scripts\Update-Snippets.ps1 {ServiceDirectory}
```

Note: Update-Snippets operates at the ServiceDirectory level (not per-csproj), so run it once per affected ServiceDirectory.

This runs `snippet-generator` to sync code snippets into markdown files. May modify `*.md` and `*.cs` files.

## 6. Verify and include all changes

- After running all applicable steps for all affected projects and ServiceDirectories, check for new/modified files with `git status`.
- All changes produced by these steps must be included in the commit.
- Do NOT commit if any of the above steps failed.

## Execution order

Run the following steps in this order, respecting their scope (per package vs per ServiceDirectory):

1. **`dotnet format`** first — run on all changed csproj files (src, tests, etc.) for each affected package.
2. **`GenerateCode`** second — per src csproj, regenerates from specs (may override format changes in Generated/) for each affected package.
3. **`Export-API`** third — run once per affected ServiceDirectory, after all GenerateCode runs for packages in that ServiceDirectory are complete; captures the final public API surface after generation.
4. **`Update-Snippets`** fourth — run once per affected ServiceDirectory, after Export-API; captures any snippet changes from all prior steps.

When multiple packages/ServiceDirectories are affected, run steps 1–2 for each affected package, then steps 3–4 once per affected ServiceDirectory. Step 6 (verify) runs once at the end.
