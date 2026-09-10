---
name: dpg-migration
description: Migration logic for Azure SDK for .NET data-plane libraries migrating from AutoRest/Swagger to TypeSpec-based generation. Uses MCP tools from the generator-agent server for automated deterministic fixes.
---
# DPG Migration Workflow

Data-plane migration workflow for Azure SDK for .NET libraries.

The workflow uses **MCP tools** from the `generator-agent` server to automate all deterministic, rule-based fixes (field renames, missing usings, type pattern replacements, nullable annotations, etc.) so the LLM only reasons about non-deterministic errors.

## When Invoked

Trigger phrases: "migrate service X", "data-plane migration", "dpg migration", "migrate to TypeSpec", "swagger to TypeSpec migration", "upgrade generator", "generator migration help", "migrate with MCP tools", "use generator-agent tools", "tool-assisted migration", "MCP migration", "automated build fix".

## Prerequisites

This skill requires the SDK repository and the spec repo:

| Path | Purpose | Required? |
|------|---------|----------|
| Current repository (`azure-sdk-for-net`) | Azure SDK for .NET mono-repo. Data-plane SDK packages typically live under `sdk/<service>/<package>/`. | Always |
| Sibling spec folder (`../azure-rest-api-specs`) | Full or sparse-checkout of the [Azure REST API Specs](https://github.com/Azure/azure-rest-api-specs) repo. Used for spec-side changes (`client.tsp`, `tspconfig.yaml` edits) and as the local spec path for code generation after any spec modification. | Always |
| Sibling TypeSpec folder (`../typespec`) | Clone of the [microsoft/typespec](https://github.com/microsoft/typespec) repo. | Only for diagnosing generator bugs |

The local spec repo path (`localSpecsPath`) is **always required** — ask the user for it at the start if not found at `../azure-rest-api-specs`. Code generation starts in **remote mode** (using the commit pinned in `tsp-location.yaml`) and switches to **local mode** (`/p:LocalSpecRepo=<path>`) only after `client.tsp` or `tspconfig.yaml` has been modified locally. Once in local mode, all subsequent generation calls use the local spec path — see [Generation Mode](#generation-mode) for details.

### MCP Server (Generator Agent)

The MCP server provides deterministic fix tools for the build-fix cycle. Configure in `.vscode/mcp.json`:
```json
{
  "servers": {
    "generator-agent": {
      "command": "dotnet",
      "args": ["run", "--project", "sdk/tools/Azure.GeneratorAgent/src/Azure.GeneratorAgent.csproj", "--framework", "net10.0"]
    }
  }
}
```

**Available MCP Tools:**

| Tool | When to Use | What It Does |
|------|-------------|--------------|
| `discover_project` | First step of any migration — call before all other tools | Returns comprehensive project context: detected plane, package name, service name, emitter config, tsp-location.yaml fields, custom code folder, API surface files, and `specsRepoPath` (auto-detected at `../azure-rest-api-specs` sibling of SDK repo root, `null` if not found — ask the user for the path when `null`). |
| `build_and_classify` | First step of every build-fix iteration | Runs `dotnet build`, parses output, classifies each error as deterministic or requires-reasoning |
| `batch_fix` | After `build_and_classify` returns deterministic errors | Applies multiple deterministic fixes in one call |
| `regex_replacement` | Field renames, type pattern replacements | Regex find/replace in a file |
| `add_using_directive` | CS0246/CS0103 for a known type (47 type→namespace mappings) | Adds a missing `using` directive |
| `remove_using_directive` | CS0246 for `*.Rest.*` or `Autorest.*` namespaces | Removes `using` directives matching a pattern |
| `nullable_annotation_fix` | CS8625 or CS8600 errors | Adds `?` nullable annotation on the error line |
| `rename_codegen_type` | CS0246 for mismatched `*ModelFactory` or `*ClientBuilderExtensions` | Updates `[CodeGenType]` attribute to match generated type |
| `fetch_to_fromlro` | CS0103/CS1061 for `Fetch` method calls in custom LRO code | Replaces `Fetch(response)` with `Model.FromLroResponse(response)` |
| `add_codegen_suppress` | CS0111 (duplicate member definition from custom + generated clash) | Adds `[CodeGenSuppress]` attribute to custom partial class, scanning Generated/ for member signature |
| `classify_errors` | Re-classify errors after partial fixes | Classifies errors against the deterministic fix registry |
| `validate_tsp_config` | Before code generation (if not already validated by `commit_iteration`) | Validates `tspconfig.yaml` emitter section: checks `@azure-typespec/http-client-csharp` key exists, required fields present (`emitter-output-dir`, `namespace`, `model-namespace`), and no invalid properties. Works on file path or string content. |
| `commit_iteration` | At migration start and whenever code generation fails with a spec-level error. | Finds a valid spec commit remotely. Supports strict (`commitOverride`), auto-resolve (iterates forward), and fallback (fixes `tspconfig.yaml` locally when `localSpecsPath` is provided — no git commit needed). Returns `useLocalSpecs=true` when tspconfig was fixed locally. See Phase 2 for details. |
| `pregen_cleanup` | Before first code generation | Removes `IncludeAutorestDependency` from `.csproj` |
| `snapshot_generated` | After code generation, before build-fix cycle | Takes SHA-256 snapshot of all Generated/ files. Enables auto-verification in `build_and_classify`. |
| `verify_generated_unchanged` | After build-fix cycle completes | Compares Generated/ files against snapshot. Reports violations (modified/deleted/added). Set `autoRevert=true` to auto-restore via git checkout. |
| `migrate_test_samples` | After src builds, before test build | Moves `Generated/Samples/` to `Samples/` |
| `finalize_migration` | After ALL builds succeed | Runs `Export-API.ps1` and `Update-Snippets.ps1` |
| `run_tests` | After build succeeds, to verify tests pass | Runs `dotnet test --no-build` with configurable filter (defaults to excluding live tests) |

## Inputs

The `discover_project` tool auto-resolves most variables below — it is called in Phase 0 as the first step of any migration. This skill applies only when `Plane = dpg`.

For the purposes of diagnosing generator bugs, the data-plane emitter is located in this repo under `eng/packages/http-client-csharp/`. The base emitter is in the microsoft/typespec repo under `packages/http-client-csharp/`.

| Variable | Example | `discover_project` field | Description |
|----------|---------|--------------------------|-------------|
| `LIBRARY_PATH` | `sdk/communication/Azure.Communication.Messages` | `LibraryPath` | Relative path to the SDK package directory |
| `PACKAGE_NAME` | `Azure.Communication.Messages` | `PackageName` | Full NuGet package / directory name |
| `SERVICE_NAME` | `communication` | `ServiceName` | The folder name immediately after `sdk/` |
| `EMITTER_PACKAGE_JSON_PATH` | see below | `EmitterPackageJsonPath` | Path to the emitter package.json |
| Plane | `dpg` | `Plane` | Should resolve to `dpg` for this skill |
| `SPECS_REPO_PATH` | `../azure-rest-api-specs` | `SpecsRepoPath` | Absolute path to local spec clone (null if not found — ask user) |

| Plane | `EMITTER_PACKAGE_JSON_PATH` | Target emitter in `tspconfig.yaml` |
|-------|----------------------------|------------------------------------|
| **DPG** | `eng/azure-typespec-http-client-csharp-emitter-package.json` | `azure-typespec/http-client-csharp` |

The following variables come from `tsp-location.yaml` (returned in `discover_project`'s `TspLocationFields` when the file exists):

| Variable | Example | `TspLocationFields` key | Description |
|----------|---------|------------------------|-------------|
| `SPEC_DIR` | `specification/<service>/<data-plane-spec-dir>` | `directory` | TypeSpec directory in azure-rest-api-specs |
| `SPEC_COMMIT` | `37052dfa3f...` | `commit` | Commit SHA from the spec repo |

The following variable is **not** auto-resolved by `discover_project` — determine it from the spec:

| Variable | Example | Description |
|----------|---------|-------------|
| `API_VERSION` | `2025-01-01` | Target API version from the spec |

---

## Migration Status File

Migrations often span multiple sessions and machines. To enable seamless pickup, a **`migration-status.md`** file is stored in the SDK package directory and committed to the migration branch.

### Location

```
{LIBRARY_PATH}/migration-status.md
```

Example: `sdk/communication/Azure.Communication.Messages/migration-status.md`

### Template

````markdown
# Migration Status — {PACKAGE_NAME}

**Tracking Issue:** [#{ISSUE_NUMBER}](https://github.com/Azure/azure-sdk-for-net/issues/{ISSUE_NUMBER})
**Last Updated:** {DATE}

## PRs

| PR | URL | Status |
|----|-----|--------|
| **Spec** | {URL or "Not created"} | {Draft/Open/Merged} |
| **SDK** | {URL or "Not created"} | {Draft/Open/Merged} |
| **Generator** | {URL or "N/A"} | {Draft/Open/Merged/N/A} |

## Branches

| Repo | Branch | Fork Remote |
|------|--------|-------------|
| azure-sdk-for-net | `{branch}` | `{remote}` |
| azure-rest-api-specs | `{branch}` | `{remote}` |

## Phase Tracker

**Status legend:** ✅ Done | 🔄 In Progress | ❌ Blocked | ⏭️ Not Started

| Phase | Status | Notes |
|-------|--------|-------|
| Phase 0 — Sync & Resume | {status} | |
| Phase 1 — Discovery & Planning | {status} | |
| Phase 2 — Create/Update tsp-location.yaml | {status} | |
| Phase 3 — Handle Legacy Configuration | {status} | |
| Phase 4 — Update Custom Code | {status} | |
| Phase 5 — Code Generation | {status} | |
| Phase 6 — Build-Fix Cycle | {status} | |
| Phase 7 — Changelog | {status} | |
| Phase 8 — Test Project Build | {status} | |
| Phase 9 — Test Execution | {status} | |
| Phase 10 — Finalization | {status} | |
| Phase 11 — Create Pull Requests | {status} | |
| Phase 12 — Verify and Summarize | {status} | |

## ApiCompat Baseline Summary

| Error Type | Count | Action |
|-----------|-------|--------|
| MembersMustExist | {N} | Fix with custom code |
| TypesMustExist | {N} | Fix with @@clientName |
| CannotChangeAttribute | {N} | Acceptable to baseline |
| ... | | |

## Known Issues

- {issue description and link}

## Next Steps

1. {next action}
````

### When to Save

Commit and push `migration-status.md` to the migration branch at these points:
1. **After Phase 0** — create the initial `migration-status.md` (or update if resuming)
2. **After any phase completes** — update phase status
3. **Before ending a session** — always save current progress
4. **After creating PRs** — update PR links

### Save Command

```bash
git add {LIBRARY_PATH}/migration-status.md
git commit -m "Update migration status for {PACKAGE_NAME}"
git push
```

### When to Delete

Remove `migration-status.md` from the branch when the migration is complete (Phase 12). It should **not** be included in the final PR merge to `main`.

---

## Phase 0 — Sync & Resume

Before any migration work:

### Discover Project
Call `discover_project` with the absolute path to the SDK package directory. This returns the detected plane, package name, service name, emitter config, tsp-location.yaml fields, custom code folder, API surface files, and `SpecsRepoPath` — all in one call. If `SpecsRepoPath` is null, ask the user for the path to their local `azure-rest-api-specs` clone.

### Resume Check
1. Check if `{LIBRARY_PATH}/migration-status.md` exists on the current branch.
   - **If it exists**: Read and parse the status file. Report the current phase to the user and resume from the first incomplete phase.
   - **If it does not exist**: This is a fresh migration — proceed with sync and Phase 1.

### Sync Repositories
Merge the latest `main` branch into all repos.

### Save Status
Create `migration-status.md` with all phases marked ⏭️ (or update existing with Phase 0 marked ✅). Commit and push to the migration branch.

---

## Phase 1 — Discovery & Planning

Use **explore** agents in parallel:

1. **Find the spec**: Search `../azure-rest-api-specs/specification/<service>/` for `main.tsp` / `tspconfig.yaml`. Determine TypeSpec vs Swagger.
2. **Find the existing SDK**: Check for `tsp-location.yaml` (already migrated, returned in `discover_project`'s `HasTspLocation`) or `src/autorest.md` (legacy Swagger, returned in `HasAutorestMd`).
3. **Inventory existing csharp customizations in spec**: Search `.tsp` files for `@clientName("...", "csharp")` and `@@clientName` decorators. Check for `back-compatible.tsp`.
4. **Snapshot old API surface**: Read `api/<PACKAGE_NAME>.net*.cs` (listed in `discover_project`'s `ApiSurfaceFiles`) — extract all public type names for later rename resolution.
5. **Extract autorest rename mappings**: From `src/autorest.md`, extract `rename-mapping` and `prepend-rp-prefix` entries.
6. **Identify custom code folder convention**: `Custom/`, `Customization/`, or `Customized/` (returned in `discover_project`'s `CustomCodeFolder`).

**If `tsp-location.yaml` exists with a `commit` and `directory`**: Proceed directly to Phase 2 — the `commit_iteration` tool will validate the spec remotely. Do NOT check the local spec repo or read local `tspconfig.yaml`.

**If no `tsp-location.yaml` exists** (fresh migration): Search `../azure-rest-api-specs/specification/<service>/` for `main.tsp` / `tspconfig.yaml` to determine the spec directory. Also inventory existing csharp customizations in spec (search `.tsp` files for `@clientName("...", "csharp")` and `@@clientName` decorators, check for `back-compatible.tsp`).

Present a summary plan and **ask the user** to confirm.

After confirmation, update `migration-status.md` to mark Phase 1 as ✅ and save.

---

## Phase 2 — Create/Update `tsp-location.yaml`

**Goal**: Point the library at the correct spec and emitter.

1. Check if `{LIBRARY_PATH}/tsp-location.yaml` exists.
   - **If it exists** (already TypeSpec-based): Read and parse `repo`, `directory`, and `commit` fields. Skip to step 3.
   - **If it does not exist** (migrating from swagger): Create `tsp-location.yaml` with the following fields:
     ```yaml
     directory: specification/<service>/<data-plane-spec-dir>
     commit: <latest commit SHA from azure-rest-api-specs main>
     repo: Azure/azure-rest-api-specs
     cleanup: true
     emitterPackageJsonPath: <value from discover_project's EmitterPackageJsonPath>
     ```
     Find the correct `directory` by searching `../azure-rest-api-specs/specification/<service>/` for a TypeSpec project (`main.tsp` + `tspconfig.yaml`) that targets the same service.
2. **Always** verify `emitterPackageJsonPath` is set to the correct plane-specific value (from `discover_project`'s `EmitterPackageJsonPath`). Update it if missing or incorrect — this field is required for code generation to use the right emitter.
3. Resolve the correct commit SHA (see below).
4. Update the `commit` field with the resolved SHA.
5. If the `directory` path no longer exists, search for TypeSpec projects with similar service names.
6. Preserve all other existing fields.

### Commit SHA Resolution

Call `commit_iteration` to resolve the correct spec commit. The tool handles all validation and iteration internally.

- **User provides a commit SHA**: Pass `commitOverride`. The tool validates strictly — if invalid, tell the user why. Do NOT iterate or fall back.
- **No commit provided**: Pass `sdkProjectPath`, `tspLocationPath`, `specsRelativeDirectory`, and `localSpecsPath`. The tool auto-resolves by validating the current commit and iterating forward if needed.
- **All remote candidates invalid**: The tool fixes `tspconfig.yaml` locally and returns `useLocalSpecs=true`. Set `gen_mode` to `local` in session state — Phase 5 uses this to decide how to run code generation.

Additional `tsp-location.yaml` fields:
- `directory` must point to the folder containing `main.tsp` and `tspconfig.yaml`.
- Optional: `additionalDirectories` array for shared TypeSpec libraries.

---

## Phase 3 — Handle Legacy Configuration

### Remove AutoRest dependency

1. Call `pregen_cleanup` with the project path — removes `<IncludeAutorestDependency>true</IncludeAutorestDependency>` from `.csproj` files.

### Handle legacy AutoRest configuration

If `src/autorest.md` exists:
1. Extract any still-relevant config for reference: `namespace`, `title`, `require` URL, `output-folder`, and rename directives.
2. Preserve only the information that still matters to the TypeSpec-based package shape.
3. Delete `autorest.md` after the TypeSpec generation path is working — git history preserves it.
4. Do NOT create a `client.tsp` in the SDK repo. The TypeSpec source lives in the spec repo.

---

## Phase 4 — Update Custom Code

### CodeGen namespace and attributes

In all non-Generated `.cs` files under `{LIBRARY_PATH}/src/`:
1. `add_using_directive` — Add `using Microsoft.TypeSpec.Generator.Customizations;` where `[CodeGen` attributes are used.
2. `regex_replacement` — Replace `CodeGenClient` → `CodeGenType`
3. `regex_replacement` — Replace `CodeGenModel` → `CodeGenType`

### Data-plane code transformations

These are also handled by MCP tools during build-fix, but can be applied before code generation:
- `regex_replacement` — `_pipeline` → `Pipeline` (field → property)
- `remove_using_directive` — Remove `using AutoRest.CSharp.Core;`
- `regex_replacement` — `_serializedAdditionalRawData` → `_additionalBinaryDataProperties`
- `regex_replacement` — `serializedAdditionalRawData` → `additionalBinaryDataProperties`
- `regex_replacement` — `FromCancellationToken(cancellationToken)` → `cancellationToken.ToRequestContext()`

---

## Phase 5 — Code Generation

**Goal**: Regenerate code with the new TypeSpec emitter.

### Generation Mode

Code generation operates in one of two modes:

```sql
SELECT value FROM session_state WHERE key = 'gen_mode';
```

| Mode | When | Command |
|------|------|---------|
| **Remote** (default) | Commit from `tsp-location.yaml` resolved successfully, no local spec edits made | `dotnet build /t:GenerateCode` |
| **Local** | After ANY local modification to `client.tsp` or `tspconfig.yaml`, or when `commit_iteration` returned `useLocalSpecs=true` | `dotnet build /t:GenerateCode /p:LocalSpecRepo=<localSpecsPath>` |

**Transition rules:**
- **Remote → Local**: Triggered by the first local edit to `client.tsp` or `tspconfig.yaml`, or when `commit_iteration` returns `useLocalSpecs=true`. This is a **one-way transition**.
- **Local → Remote**: Only in Phase 11, for the final CI-reproducibility verification after spec changes are pushed and a real commit SHA is obtained.

```sql
-- Set at migration start (Phase 0):
INSERT OR REPLACE INTO session_state (key, value) VALUES ('gen_mode', 'remote');
-- After first spec edit or useLocalSpecs=true:
UPDATE session_state SET value = 'local' WHERE key = 'gen_mode';
```

### Running Code Generation

Pass `localSpecsPath` **only** when in local mode:

- **Remote mode**: `dotnet build /t:GenerateCode`
- **Local mode**: `dotnet build /t:GenerateCode /p:LocalSpecRepo=<localSpecsPath>`

**Always use `dotnet build /t:GenerateCode`. Do NOT use `tsp-client update`.**

### Code Generation Failure

If generation fails, diagnose the cause:

1. **Customization file issue**: Check if a customization file is causing the failure. Temporarily remove or fix it, then re-run. If it still fails with no customizations → generator bug.

2. **Spec-level error** (e.g., `invalid-schema`, `duplicate-example-file`, or any TypeSpec compiler error that is **not** a C# build error):
   - Re-call `commit_iteration` (no `commitOverride`, always pass `localSpecsPath`) — it finds the next valid commit.
   - If found → retry code generation.
   - If every commit fails → `commit_iteration` fixes `tspconfig.yaml` locally and returns `useLocalSpecs=true`. Switch to local mode and use `/p:LocalSpecRepo=<localSpecsPath>` for all subsequent generation.

After generation:

### Post-Generation Checklist

1. Check `src/Generated/` for output files — verify file contents changed, not just file names.
2. Use `git diff --stat` to confirm the scope of changes. A typical migration touches hundreds of files with significant content changes.
3. **MANDATORY**: Call `snapshot_generated` with the project path to lock down the Generated/ directory. This enables auto-verification in every subsequent `build_and_classify` call — any accidental modification to Generated/ files will be detected and reverted automatically.

Build errors, ApiCompat, tests, and API export are handled in their dedicated phases (Phase 6, 8, 9, 10).

## Phase 6 — Build-Fix Cycle

**Goal**: Get the library to compile successfully through iterative error fixing.

**You (the LLM) are the orchestrator** — call MCP tools for deterministic fixes, reason about non-deterministic errors using the classification trees below.

### Command Macros

| Macro | Command |
|-------|---------|
| `[GENERATE]` | `dotnet build /t:GenerateCode` (remote mode) or `dotnet build /t:GenerateCode /p:LocalSpecRepo=<localSpecsPath>` (local mode — see Phase 5 Generation Mode) |
| `[TEST]` | Call `run_tests` MCP tool (or `dotnet test --no-build --filter "TestCategory!=Live" 2>&1 \| Select-Object -Last 30`) |

### Execution Protocol

```
LOOP:
  1. Call `build_and_classify` → builds and classifies ALL errors
  2. IF zero errors → EXIT LOOP
  3. IF error count is not decreasing after 3 iterations → escalate to user
  4. Separate errors into deterministic and requires-reasoning buckets
  5. Apply ALL deterministic fixes via `batch_fix`
  6. For requires-reasoning errors, classify and apply fixes in batch
  7. Regenerate based on what changed:
     - Spec changes (client.tsp edits) → [GENERATE]
     - Generator attribute changes → [GENERATE]
     - Generator code changes → rebuild the data-plane emitter, then [GENERATE]
     - Customization-only changes → no regeneration needed
     - Stale custom file (e.g., custom `FooResource.cs` exists but
       `Generated/FooResource.cs` was renamed to `BarResource.cs` or removed) →
       rename custom file to match the new generated name, or remove it if
       the generated type no longer exists. Then [GENERATE].
     - Error in Generated/ file with custom class present →
       remove custom file, then [GENERATE] to isolate cause.
       If error gone → custom file was the cause. Re-introduce incrementally.
       If error persists with zero custom files → generator bug, STOP and report.
  8. GOTO 1
```

Max 10 iterations. If still failing, escalate to user.

> **Generated/ Auto-Guard**: When a snapshot exists (taken in Phase 5), every `build_and_classify` call automatically verifies that no Generated/ files were modified. If violations are detected, they are auto-reverted via `git checkout` and reported in the build result under `generatedGuard`. Additionally, `regex_replacement`, `add_using_directive`, `remove_using_directive`, and `nullable_annotation_fix` will refuse to modify files inside Generated/ directories.

**Key decision points for regeneration:**
- After editing `[CodeGenType]`, `[CodeGenSuppress]`, `[CodeGenMember]`, or `[CodeGenSerialization]` attributes → [GENERATE] before rebuilding
- After editing `client.tsp` → **switch to local mode** (if not already), then [GENERATE] before rebuilding
- After **removing or renaming a custom file** that contained generator attributes → [GENERATE] before rebuilding (the generator will produce different output without those attributes)
- After editing only custom `.cs` code (no generator attributes) → no regeneration needed
- If build returns 0 errors but previous build had errors → verify no regressions by rebuilding once more
- **When in doubt, regenerate.** Skipping regeneration after customization changes is a common source of confusing errors.

### ApiCompat Error Handling

**⛔ NEVER create or modify `ApiCompatBaseline.txt` to suppress ApiCompat errors. This is a hard rule — no exceptions.**
**⛔ NEVER remove or modify `ApiCompatVersion` from the .csproj to suppress these errors.** The version must stay to enforce compatibility.

ApiCompat errors surface when `dotnet build` detects breaking changes vs the previously shipped API. Run `dotnet pack --no-restore` to get the full list. For each error, create a backward-compat shim in `Custom/BackwardCompat/`:

| ApiCompat Rule | What It Means | Fix |
|---|---|---|
| `MembersMustExist` (constructor) | Protected constructor removed from abstract type | Add `protected TypeName(params) : base(params) { }` in `Custom/BackwardCompat/<TypeName>.cs`. Never edit Generated/ files. |
| `MembersMustExist` (method/property) | Method signature changed (e.g., `IReadOnlyDictionary` → `IDictionary`) | Create forwarding overloads in `Custom/BackwardCompat/<ClientName>.cs` with the old `IReadOnlyDictionary` parameter type that convert and delegate to the new `IDictionary` method. Add `#pragma warning disable AZC0002` if overloads lack CancellationToken. For async forwarding methods, always use `ConfigureAwait(false)` on the awaited call. Never edit Generated/ files. |
| `MembersMustExist` (ModelFactory) | ModelFactory overload signature changed (usually a parameter's enum type was removed) | Add forwarding overload with old signature in `Custom/BackwardCompat/<ModelFactoryName>.cs`. Accept the removed enum param and discard it, delegating to the new method. Mark `[EditorBrowsable(Never)]`. If the removed param's type no longer exists, create a stub struct in `MissingEnumTypes.cs`. |
| `MembersMustExist` (`SerializedAdditionalRawData`) | Protected field renamed to `_additionalBinaryDataProperties` | Re-declare the old field in `Custom/BackwardCompat/<TypeName>.cs`: `protected internal IDictionary<string, BinaryData> SerializedAdditionalRawData;` with `#pragma warning disable SA1307` and `SA1401`. |
| `MembersMustExist` (missing setter) | Property lost its setter | `[CodeGenSuppress("Property")]` + re-declare with `{ get; set; }` |
| `MembersMustExist` (missing enum value) | Enum value removed/renamed | Add `[EditorBrowsable(EditorBrowsableState.Never)]` deprecated value in custom partial |
| `MembersMustExist` (property type changed) | Property type changed (e.g., custom enum → `string`) | Use `[CodeGenSuppress("Property")]` to suppress the generated property, then re-declare it in a custom partial class returning the old type. Create a stub type (e.g., a `readonly struct` with `implicit operator` from `string`) in `MissingEnumTypes.cs`, marked `[EditorBrowsable(Never)]`. Never edit Generated/ files. |
| `TypesMustExist` | Type renamed/removed | `@@clientName` to restore old name, OR create stub type in custom code |
| `TypesMustExist` (extension class renamed) | DI extension class renamed (e.g., `AIFooClientBuilderExtensions` → `FooClientBuilderExtensions`) | Create a stub `public static class` with the old name containing extension methods that delegate to the new class. Use `global::` namespace qualifiers if the stub is inside `Microsoft.Extensions.Azure` (bare `Azure.X` resolves wrong). Copy any `[RequiresUnreferencedCode]`/`[RequiresDynamicCode]` attributes from the target method. |
| `CannotMakeMemberNonVirtual` | `virtual` → non-virtual (abstract type) | Add protected constructor shim to keep type inheritable (check for serialization constructor conflicts first — see constructor row above) |
| `CannotSealType` | Type effectively sealed (private ctor) | Same as above — add protected constructor to keep type inheritable |

**File organization**: Place backward-compat shims in `Custom/BackwardCompat/`, with each file named after the type it extends:
- `<TypeName>.cs` — e.g., `PersistentAgentsModelFactory.cs` for ModelFactory shims, `SomeClient.cs` for client method shims, `MessageDeltaTextAnnotation.cs` for field renames
- `MissingEnumTypes.cs` — stub types for removed enums (these don't map to a single generated type)

**Mark all backward-compat shims with:**
- `[EditorBrowsable(EditorBrowsableState.Never)]` — hide from IntelliSense
- `#pragma warning disable AZC0002` if needed for missing CancellationToken
- For async forwarding methods, always `await ... .ConfigureAwait(false)` (library best practice)
- Code comment explaining why the shim exists

#### Detailed Examples

**PersistentAgentsModelFactory.cs** — When a ModelFactory method's old signature had an enum parameter that no longer exists (e.g., `MessageDeltaChunkObject`), create a forwarding overload that accepts the old enum and discards it:

```csharp
// Custom/BackwardCompat/PersistentAgentsModelFactory.cs
#nullable disable
using System.ComponentModel;
namespace Azure.AI.Agents.Persistent
{
    public static partial class PersistentAgentsModelFactory
    {
        // backward-compat: old overload had MessageDeltaChunkObject param that no longer exists
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MessageDeltaChunk MessageDeltaChunk(
            string id,
            MessageDeltaChunkObject @object, // old enum param — accepted but discarded
            MessageDelta delta)
        {
            return MessageDeltaChunk(id: id, delta: delta);
        }
    }
}
```

**MessageDeltaTextAnnotation.cs** — When the protected field `SerializedAdditionalRawData` was renamed to `_additionalBinaryDataProperties`:

```csharp
// Custom/BackwardCompat/MessageDeltaTextAnnotation.cs
using System;
using System.Collections.Generic;
namespace Azure.AI.Agents.Persistent
{
    public abstract partial class MessageDeltaTextAnnotation
    {
#pragma warning disable SA1307 // Accessible fields should begin with upper-case letter
#pragma warning disable SA1401 // Fields should be private
        protected internal IDictionary<string, BinaryData> SerializedAdditionalRawData;
#pragma warning restore SA1401
#pragma warning restore SA1307
    }
}
```

**SomeClient.cs async pattern** — Always use `ConfigureAwait(false)` in async forwarding overloads:

```csharp
#pragma warning disable AZC0002
public partial class SomeClient
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<Response<Model>> CreateAsync(
        IReadOnlyDictionary<string, string> metadata,
        CancellationToken cancellationToken)
    {
        return await CreateAsync(
            (IDictionary<string, string>)(metadata?.ToDictionary(k => k.Key, k => k.Value)),
            cancellationToken).ConfigureAwait(false);
    }
}
#pragma warning restore AZC0002
```

#### Common Pitfalls

1. **`[CodeGenType]` attribute mismatch**: When a custom partial class uses `[CodeGenType("X")]`, the value `X` must exactly match the generated class name. If the generated name changed during migration, the partial classes silently fail to merge — methods from both sides become invisible, producing dozens of spurious `MembersMustExist` errors. Always verify the generated class name before assuming individual methods are missing.

2. **XML `cref` references break after signature changes**: After changing method parameter types (e.g., `IDictionary` → `IReadOnlyDictionary`), XML doc comments in custom files that reference the old signatures via `cref` attributes produce CS1574 errors. Scan custom `*.cs` files for `cref` attributes containing the old type and update them.

3. **ModelFactory class name mismatch**: The generated ModelFactory class name may differ from what the custom partial class expects. If most ModelFactory methods show as `MembersMustExist` errors, check whether the generated and custom ModelFactory classes have matching names/`[CodeGenType]` attributes before creating individual shims.

### Key Insight: Generator and Customization File Interaction

The generator reads existing customization files (`[CodeGenSuppress]`, `[CodeGenType]`, `[CodeGenMember]`, `[CodeGenSerialization]`) and produces **different output** based on them:

- Errors in `Generated/` are often **caused** by stale customization files, not generator bugs.
- Fix by editing the customization file, then re-running `[GENERATE]`.
- **If a generated file has errors that trace back to a problematic custom file, remove (or rename/comment-out) the custom file and regenerate.** The generator will produce clean output without the stale customization influence. You can then re-introduce only the parts of the custom file that are still needed, one piece at a time, regenerating after each change.
- **After ANY change to a custom file that contains generator attributes** (`[CodeGenType]`, `[CodeGenSuppress]`, `[CodeGenMember]`, `[CodeGenSerialization]`), you **MUST** regenerate with `[GENERATE]` before rebuilding. The generator reads these attributes at generation time — building without regenerating will use stale generated code that doesn't reflect your customization changes.
- Only after eliminating customization interference can you identify true generator bugs.

### Error Classification

```
Given: error in file F with message M

1. IF F is under `src/Generated/`:
   a. Find the corresponding customization file
   b. Fix the customization to match new generated code
   c. Run [GENERATE] then [BUILD]
   d. If error persists after removing all customizations → generator bug
      → STOP: Do NOT suppress. Report to user with full details (see Generator Bug Reporting).

2. IF F is under custom code:
   a. Renamed/missing type → update custom code or add rename
   b. Internal type → use an accessibility fix in the spec or CodeGenType

3. IF error is structural in Generated/ with correct spec → generator bug
      → STOP: Do NOT suppress. Report to user with full details (see Generator Bug Reporting).
```

### Data-plane error patterns

These patterns are specific to data-plane migrations. Apply them during the shared skill's "Build-Fix Cycle" phase, in addition to the common customization patterns.

#### `GeneratorPageableHelpers` → `CollectionResult` pattern
- If code uses `GeneratorPageableHelpers.CreatePageable` or similar, replace it with the corresponding generated `CollectionResult` type from the `Generated/` folder.
- If no `CollectionResult` type exists in `Generated/`:
    1. Look for a `[CodeGenSuppress]` attribute that suppresses the internal method which would create the `CollectionResult`.
    2. Comment out or remove that `[CodeGenSuppress]` attribute.
    3. Re-run code generation to produce the `CollectionResult` type.
    4. After regeneration, use the generated type.
- Do NOT create `CollectionResult` types manually — they must be generated.

#### `ToRequestContent()` removal
- Input models now have an implicit cast to `RequestContent`.
- Replace `foo.ToRequestContent()` with just `foo`.
- Example: `using RequestContent content = details.ToRequestContent();` → `using RequestContent content = details;`
- **Keep** the `using` statement; only remove the `.ToRequestContent()` call.

#### `FromCancellationToken` replacement
- Replace `RequestContext context = FromCancellationToken(cancellationToken);`
- With `RequestContext context = cancellationToken.ToRequestContext();`

#### Mismatched `ModelFactory` type names
- If a custom type ending in `ModelFactory` has a different name than the generated type ending in `ModelFactory`, update the `CodeGenType` attribute in the custom type to match the generated type name.

### Mismatched `ClientBuilderExtensions` type names
- If a custom type ending in `ClientBuilderExtensions` has a different name than the generated type ending in `ClientBuilderExtensions`, update the `CodeGenType` attribute in the custom type to match the generated type name.

#### Fetch methods in custom LRO methods
- The old `Fetch` methods are replaced by static `FromLroResponse` methods on the response models.
- Update custom LRO methods to use `ResponseModel.FromLroResponse(response)` instead of calling `Fetch` methods.
- Do NOT create `Fetch` methods manually — call the generated `FromLroResponse` method.

#### `FromResponse` method removal
- `FromResponse` methods have been removed from models.
- Use explicit cast from `Response` to the model type instead.
- Example: `var model = ModelType.FromResponse(response);` → `var model = (ModelType)response;`

### Priority Order

1. Missing/renamed types (CS0234, CS0246)
2. Accessibility issues (CS0051, CS0122)
3. Signature mismatches (CS1729, CS0029, CS1503)
4. Duplicate definitions (CS0111)
5. Other errors — investigate individually

### Customization Patterns

- **Partial classes** — Extend generated types without editing `Generated/`.
- **`[CodeGenType("SpecName")]`** — Link custom class to generated counterpart.
- **`[CodeGenSuppress("MemberName", typeof(...))]`** — Suppress a generated member.
- **`[CodeGenMember("MemberName")]`** — Link custom property to generated counterpart.
- **Match existing custom code folder convention** — `Custom/`, `Customization/`, or `Customized/`.
- **Add justification comments** — Every custom code file must include a code comment (`//`) explaining **why** the customization exists (e.g., backward-compat shim for removed enum value, property rename from flattening change). This helps future maintainers understand the intent and decide whether the shim can be removed.
- **No XML `<summary>` on partial type declarations in custom code** — Partial types in customization files do not need an XML doc summary on the type itself; the generated partial already carries the summary and it will be merged by the compiler. Adding a summary here risks leaking internal justification into the released NuGet package's XML documentation. Only add XML docs on **new members** (properties, methods) introduced in custom code.
- **Mark backward-compat shims with `[EditorBrowsable(EditorBrowsableState.Never)]`** — Deprecated shim members (e.g., restored enum values, renamed properties) should be hidden from IntelliSense to guide users toward the new API surface.

> **Further reading**: [C# Customization Guide](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/.tspd/docs/customization.md), [TypeSpec client customization](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/knowledge/customizing-client-tsp.md).

---

## Phase 7 — Changelog

**Do NOT hand-edit `metadata.json`** — it is auto-generated.

### CHANGELOG.md
```markdown
## <VERSION> (Unreleased)

### Features Added
- Migrated from Swagger to TypeSpec-based generation
```

---

## Phase 8 — Test Project Build

1. Call `migrate_test_samples` with the project path — moves `tests/Generated/Samples/` to `tests/Samples/`. Do NOT run `[GENERATE]` in tests.
2. Call `build_and_classify` on the test project path — same build-fix loop as Phase 6, but for test code.
   - Test files are NOT generated — edit them directly.
   - Check `src/Generated/` for actual new type names before writing fixes.
   - Use `batch_fix` for deterministic errors, reason about the rest.
3. Max 10 iterations. If still failing, skip to finalization.

---

## Phase 9 — Test Execution

1. Call `run_tests` with the project path — runs `dotnet test --no-build --filter "TestCategory!=Live"` and returns structured pass/fail results.
2. Fix failures, call `build_and_classify`, then `run_tests` again.
3. Repeat (max 5 iterations). If still failing, continue to finalization.

---

## Phase 10 — Finalization

Call `finalize_migration` with the project path — runs Export-API.ps1 and Update-Snippets.ps1 automatically.

Or run manually from the **repository root**:

```powershell
.\eng\scripts\Export-API.ps1 -ServiceDirectory SERVICE_NAME
.\eng\scripts\Update-Snippets.ps1 -ServiceDirectory SERVICE_NAME
```

---

## Phase 11 — Create Pull Requests

Once `dotnet build` passes, create **separate PRs** for each category:

| Category | Repository | PR needed? |
|----------|-----------|------------|
| **Spec changes** | `azure-rest-api-specs` | If any spec files were modified |
| **Generator changes** | `azure-sdk-for-net` | If generator code was fixed |
| **SDK migration** | `azure-sdk-for-net` | Always |

### Step 1 — Classify Changes

During the iteration loop, changes fall into three categories. Identify which ones apply by reviewing the modified files across both repositories.

### Step 2 — Create Spec PR (if applicable)

1. In the local spec repo (`../azure-rest-api-specs`), create a branch and commit all spec changes.
2. Run `tsp format "*.tsp"` in the TypeSpec project directory to ensure formatting passes CI validation.
3. Push the branch and create a PR against `Azure/azure-rest-api-specs`.
4. Note the **final commit SHA** from the pushed branch.
5. PR title: `Add csharp client customizations for <Service> migration`

### Step 3 — Create Generator PR (if applicable)

1. In the SDK repo, create a branch containing **only** the generator changes under `eng/packages/http-client-csharp/`.
2. Push and create a PR against `Azure/azure-sdk-for-net`.
3. PR title: `[Generator] Fix <description> for <Service> migration`
4. Include test project regeneration if the fix affects other SDKs (run `eng/packages/http-client-csharp/eng/scripts/Generate.ps1`).

### Step 4 — Create SDK Migration PR

1. Update `tsp-location.yaml` with the final spec commit SHA from Step 2.
2. **Switch back to remote mode** — regenerate one final time **without** `LocalSpecRepo` to verify CI-reproducible generation:
   ```powershell
   cd sdk\<service>\<PACKAGE_NAME>\src
   dotnet build /t:GenerateCode
   ```
   This is the only time the generation mode transitions from local back to remote.
3. Verify `dotnet build` still passes.
4. Run pre-commit checks (Export-API, Update-Snippets, dotnet format).
5. Commit all SDK changes and create a PR against `Azure/azure-sdk-for-net`.
6. PR title: `<PACKAGE_NAME>: Migrate to TypeSpec (API version <API_VERSION>)`
7. In the PR description, link to the spec PR and generator PR (if any) as dependencies.

### Step 5 — Report Summary

After all PRs are created, report:
1. **Spec PR**: Link and summary of decorators added.
2. **Generator PR**: Link and summary of fixes (if any).
3. **SDK PR**: Link and summary of migration changes.
4. **Manual follow-up**: Any remaining items that need human review (naming decisions, breaking changes, etc.).
5. **Update `migration-status.md`** with all PR links and mark Phase 11 as done. Commit and push.

---

## Phase 12 — Verify and Summarize

1. Report summary of all completed steps and warnings.
2. Note any `CodeGenType` attributes needing manual review.
3. Remind user to review with `git diff` before committing.
4. Suggest running the `pre-commit-checks` skill.
5. **Remove `migration-status.md`** from the branch — it should not be included in the final merge to `main`:
   ```bash
   git rm {LIBRARY_PATH}/migration-status.md
   git commit -m "Remove migration status file — migration complete"
   git push
   ```

---

## Generator Bug Diagnosis

Before reporting a generator bug, ALWAYS:
1. Remove/fix any customization files that could influence the generator.
2. Re-run `[GENERATE]`.
3. If the error persists with no customization influence → confirmed generator bug.

Do NOT manually fix Generated/ code. Do NOT silently suppress generator bugs with `[CodeGenSuppress]` or other workarounds.

### Generator Bug Reporting

When a generator bug is confirmed, you **MUST stop and report the bug to the user in detail**. Do NOT silently work around it with `[CodeGenSuppress]` + custom implementation. The user needs to understand what is broken so they can decide how to proceed (fix the generator, file an issue, or explicitly choose a workaround).

**Required information to present to the user:**
1. **Summary** — One-sentence description of the bug.
2. **Affected operations** — Which TypeSpec operations / generated methods are broken, with their signatures.
3. **What the generated code looks like** — Show the broken generated code snippet and explain what's wrong.
4. **What correct code would look like** — Describe or show the expected behavior.
5. **Error messages** — Full CS error codes and messages.
6. **Repro steps** — Exact commands to reproduce (spec repo, commit, emitter version, tsp-location.yaml content).
7. **Confirmation it's not caused by customizations** — State that you verified with zero custom files.
8. **Root cause hypothesis** — Your best assessment of why the generator produces incorrect code.

After presenting the bug details, **ask the user how they want to proceed**:
- **Option A**: Fix the data-plane generator (emitter path: `eng/packages/http-client-csharp/`)
- **Option B**: File an issue and apply a `[CodeGenSuppress]` workaround **only with the user's explicit approval**
- **Option C**: Pause the migration and wait for a generator fix

### Generator Fix Workflow

```
1. CONFIRM it's a generator bug (zero custom files, clean regeneration, same errors)
2. REPORT the bug to the user with full details (see Generator Bug Reporting above)
3. WAIT for user decision before proceeding
4. IF user chooses to fix generator:
   - Edit under eng/packages/http-client-csharp/
   - Rebuild the emitter (`npm run build`)
   - Regenerate the affected SDK with `dotnet build /t:GenerateCode`
   - Clean up stale custom workarounds
   - Run Generate.ps1 to verify no regressions
5. IF user explicitly approves workaround:
   - [CodeGenSuppress] + custom implementation
   - Add a code comment documenting the generator bug and linking to any filed issue
```

---

## Safety Rules

### Hard Rules (Never Violate)

1. **Never edit files under `Generated/`** — they are overwritten by codegen. This rule is enforced deterministically at three levels:
   - **MCP tool guards**: `regex_replacement`, `add_using_directive`, `remove_using_directive`, and `nullable_annotation_fix` refuse to write to Generated/ paths.
   - **Snapshot verification**: `build_and_classify` auto-verifies Generated/ file integrity every build when a snapshot exists (taken via `snapshot_generated` in Phase 5).
   - **Post-cycle check**: Call `verify_generated_unchanged` with `autoRevert=true` after the build-fix cycle to catch any modifications made outside MCP tools (e.g., via `edit`, `create`, or `powershell`).
2. **Never hand-edit `metadata.json`** — it is auto-generated.
3. **Never use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
4. **Never create or add entries to `ApiCompatBaseline.txt`** — this file must never be used to bypass breaking changes. Always mitigate ApiCompat errors through spec-side fixes (`@@clientName`) or SDK custom code shims in `Custom/BackwardCompat/` (see ApiCompat Error Handling in Phase 6 and error-reference.md). Do NOT suppress them via baseline files.
5. **Never disable ApiCompat or package validation in `.csproj`** — do NOT set `<EnablePackageValidation>false</EnablePackageValidation>`, `<RunApiCompat>false</RunApiCompat>`, or any other property that disables API compatibility checks. These checks exist to catch breaking changes and must always remain enabled. Fix the underlying breaking changes instead.
6. **Never bump the major version** of an Azure SDK package.
7. **Preserve git history** — prefer renames over delete+create.
8. **Never manually edit files under `src/Generated/`** — this is strictly forbidden. All generated code must come from the generator. If generated code has a bug (e.g., references a non-existent method, wrong type), fix it through:
   - **TypeSpec decorators** (`@@clientName`, `@@alternateType`, `@@access`) in `client.tsp`
   - **Custom partial classes** with `[CodeGenSuppress]` in `src/Custom/` to suppress the broken member and provide a corrected replacement
   - **Generator bug fix** if no decorator or customization can resolve it
   
   Note: `[CodeGenSuppress]` only takes effect when the custom files exist **before** code generation. After adding custom files, regenerate with `dotnet build /t:GenerateCode` so the generator reads them and honors the suppression.

### Autonomous Mode (Default)

During the build-fix loop, Copilot operates autonomously. These actions are **permitted without user confirmation**:

1. **Spec changes**: Adding `@@clientName`, `@@access`, `@@markAsPageable`, `@@alternateType`, and other decorators to `client.tsp` — these are safe, reversible, and csharp-scoped.
2. **Custom code**: Adding partial classes in the SDK custom code folder. Use `[CodeGenType]`/`[CodeGenSuppress]`/`[CodeGenMember]` only when needed.
3. **Deleting `autorest.md`** after extracting directives — git history preserves it.
4. **Updating custom code** to reference new generated type names.
5. **Removing or commenting out a problematic custom file** that is causing errors in generated code — regenerate immediately after. Git history preserves the old version, and needed customizations can be re-introduced incrementally.
6. **Regenerating code** using `dotnet build /t:GenerateCode`. **Always regenerate after modifying custom files that contain generator attributes.**
7. **Updating CHANGELOG.md** and other metadata files.

### Actions Requiring User Confirmation

These actions **require explicit user approval** (use `ask_user`):

1. **Modifying spec `.tsp` files beyond `client.tsp`** — e.g., changing `main.tsp`, model definitions, or operation signatures. These affect all languages, not just C#.
2. **Generator code changes** that affect other SDKs — run `Generate.ps1` to verify scope first.
3. **Removing public API surface** with no backward-compat option (true breaking change).
4. **Adding `ApiCompatBaseline.txt` entries** — this should almost never be done.
5. **Deleting existing custom code files** — may lose manually-written logic.

### Escalation Criteria

Proceed **without asking the user** except when:
1. Ambiguous fix — multiple equally valid approaches.
2. Breaking API change with no backward-compat option.
3. Generator fix affects other SDKs.
4. 5 consecutive failed attempts for the same error.
5. Error count increases after a fix.

### Session End Rule

**Always update and push `migration-status.md` before ending a session**, even if the migration is incomplete. This ensures the next session (possibly on a different machine) can resume from the exact point where work stopped.

---

## Fleet Mode Execution Strategy

### Parallel Phase (explore agents)
- **Agent 1**: Find spec location and determine spec type
- **Agent 2**: Analyze existing SDK package structure

### Sequential Phase (task/general-purpose agents)
1. Create/update `tsp-location.yaml`
2. Delete `autorest.md` if needed
3. Run code generation (initial_wait: 120+)
4. Apply customizations
5. Build error triage loop
6. Final build and validate

### Sub-Agent Strategy
1. **task agent** — Run `dotnet build`, collect errors, populate SQL table.
2. **Batch spec fixes**: explore → general-purpose → task (regenerate + rebuild).
3. **Batch custom code fixes**: explore → general-purpose → task (rebuild).
4. **Generator fixes** (one at a time): explore → general-purpose → task (rebuild emitter + regenerate + rebuild) → general-purpose (clean up stale workarounds) → task (rebuild).

## Quick Reference — Do's and Don'ts

- **Do NOT use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
- **Do NOT hand-edit `metadata.json`**.
- **Match existing custom code folder convention**.
- Don't blindly copy all renames from `autorest.md` — only add `@@clientName` for names that actually cause build errors after generation. Check existing spec decorators to avoid duplicates.
- Batch spec fixes, then rebuild — one spec fix can resolve 5–20 errors.
- Try spec-side fix (`@@access`) before custom code (`[CodeGenType]`).
- Finalize `tsp-location.yaml` with pushed spec commit before creating PR.
- Run `CodeChecks.ps1` before pushing: `pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>`
- Clean up stale custom workarounds after generator fixes.
- **Always require `localSpecsPath`** — ask at migration start, not mid-flow.
- **Respect generation mode** — remote by default, local after any `client.tsp`/`tspconfig.yaml` edit. Never mix modes within a migration.
