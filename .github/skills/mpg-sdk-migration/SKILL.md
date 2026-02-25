---
name: mpg-sdk-migration
description: Migrate an Azure management-plane .NET SDK from Swagger/AutoRest to TypeSpec-based generation. Use when asked to migrate a service, do MPG migration, update spec, or bring SDK to latest TypeSpec.
---
# Skill: mpg-sdk-migration

Migrate an Azure management-plane .NET SDK from Swagger/AutoRest to TypeSpec-based generation.

## When Invoked

Trigger phrases: "migrate service X", "update spec", "bring SDK to latest", "help with mgmt migration", "mpg migration", "mgmt sdk migration".

## Prerequisites

This skill requires two repositories side by side:

| Path | Purpose |
|------|---------|
| Current repository (`azure-sdk-for-net`) | Azure SDK for .NET mono-repo. SDK packages live under `sdk/<service>/Azure.ResourceManager.<Service>/`. |
| Sibling spec folder (`../azure-rest-api-specs`) | Full or sparse-checkout of the [Azure REST API Specs](https://github.com/Azure/azure-rest-api-specs) repo. TypeSpec specs live under `specification/<service>/resource-manager/Microsoft.<Provider>/<ServiceName>/`. |

If the spec repo is not found at `../azure-rest-api-specs`, ask the user for the path.

## Primary Inputs

When the user says "migrate service X", resolve:

| Variable | Example | How to find |
|----------|---------|-------------|
| `SERVICE_NAME` | `chaos` | The lowercase service directory name under `sdk/` |
| `PACKAGE_NAME` | `Azure.ResourceManager.Chaos` | Full NuGet package / directory name |
| `SPEC_DIR` | `specification/chaos/resource-manager/Microsoft.Chaos/Chaos` | TypeSpec directory inside azure-rest-api-specs containing `main.tsp` and `tspconfig.yaml` |
| `SPEC_COMMIT` | `37052dfa3f...` | Latest commit hash from `azure-rest-api-specs` for the spec |
| `API_VERSION` | `2025-01-01` | Target API version from the spec |

## Phase 0 — Sync Repositories

Before any migration work, merge the latest `main` branch into both repos:

```powershell
# Sync spec repo
cd ..\azure-rest-api-specs
git fetch origin main
git merge origin/main

# Sync SDK repo
cd ..\azure-sdk-for-net
git fetch origin main
git merge origin/main
```

This ensures specs and SDK tooling are up-to-date. Resolve any merge conflicts before proceeding.

## Phase 1 — Discovery & Planning

Use **explore** agents in parallel to gather information:

1. **Find the spec**: Search `../azure-rest-api-specs/specification/<service>/` for `main.tsp` / `tspconfig.yaml` / OpenAPI JSON files. Determine whether the spec is already TypeSpec or still Swagger-only.
2. **Find the existing SDK**: Check `sdk/<service>/<PACKAGE_NAME>/` for:
   - `tsp-location.yaml` → already migrated (may just need version bump)
   - `src/autorest.md` → legacy Swagger-based, needs migration
3. **Inventory existing csharp customizations in spec**: Search all `.tsp` files in the spec directory for `@clientName("...", "csharp")` and `@@clientName` decorators. Also check for `back-compatible.tsp`. These are already applied and must not be duplicated when adding renames later.
4. **Review naming conventions**: Consult the `azure-sdk-pr-review` skill for naming review rules.

Present a summary plan and **ask the user** to confirm before proceeding.

## Phase 2 — Create/Update `tsp-location.yaml`

This is the core migration artifact. Create it at `sdk/<service>/<PACKAGE_NAME>/tsp-location.yaml`:

```yaml
directory: specification/<service>/resource-manager/Microsoft.<Provider>/<ServiceName>
commit: <SPEC_COMMIT>
repo: Azure/azure-rest-api-specs
emitterPackageJsonPath: "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json"
```

Key rules:
- `directory` must point to the folder containing `main.tsp` and `tspconfig.yaml` in the spec repo.
- `commit` must be a valid commit SHA from `Azure/azure-rest-api-specs`.
- `emitterPackageJsonPath` is always `eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json` for management SDKs.
- `repo` is always `Azure/azure-rest-api-specs`.
- Optional: `additionalDirectories` array for shared TypeSpec libraries.

## Phase 3 — Handle Legacy `autorest.md`

If `src/autorest.md` exists:
1. Extract key config: `namespace`, `title`, `azure-arm: true`, `require` URL, `output-folder`, directives.
2. **Thoroughly analyze rename mappings** before deleting:
   - Extract ALL `rename-mapping` entries and `prepend-rp-prefix` entries from `autorest.md`.
   - Many renames are handled **automatically** by the mgmt emitter: RP prefix prepending (`prepend-rp-prefix`), `Is*` boolean property naming, acronym casing (e.g., `Ip` → `IP`), and standard format rules. Do NOT blindly add all renames to `client.tsp`.
   - Check what `@clientName("...", "csharp")` decorators already exist in the individual `.tsp` files (e.g., `Volume.tsp`, `Account.tsp`, `back-compatible.tsp`) — these are already applied and must not be duplicated.
   - After initial code generation, **compare old vs new public type names** to find which renames are missing. Only add `@@clientName` decorators for types that actually differ.
3. Delete `src/autorest.md` — git history preserves the original content.
4. Do NOT create a `client.tsp` in the SDK repo. The TypeSpec source lives in the spec repo.
5. Map remaining AutoRest directives to TypeSpec customization approach:
   - Model/property renames → `@@clientName(SpecTypeName, "SdkName", "csharp")` in spec repo `client.tsp`
   - Accessibility overrides → `@@access(TypeName, Access.public, "csharp")` in spec repo `client.tsp` (for types generated as `internal` that need to be `public`)
   - Suppressions → `#suppress` decorators in spec `.tsp` files
   - Format overrides → TypeSpec `@format` / `@encode` decorators

### Spec ↔ SDK Iteration Cycle

When adding `@@clientName` or `@@access` decorators to `client.tsp` in the spec repo, follow this cycle:

1. Edit `client.tsp` in the spec repo.
2. Run `npx tsp format "**/*.tsp"` in the spec directory to fix formatting (CI enforces this).
3. Commit (or `git commit --amend`) and push to the spec branch.
3. Copy the new spec commit SHA.
4. Update `tsp-location.yaml` in the SDK repo with the new `commit` hash.
5. Regenerate: `dotnet build /t:GenerateCode` in the SDK package `src/` folder.
6. Rebuild: `dotnet build` to check errors.
7. Repeat until errors are resolved.

> **Tip**: Use `git commit --amend` + `git push --force` on the spec branch to keep a clean single commit during iteration. Squash later if needed.

## Phase 4 — SDK Package Structure

Ensure the package directory matches this layout:

```
sdk/<service>/<PACKAGE_NAME>/
├── tsp-location.yaml              # Created in Phase 2
├── src/
│   ├── <PACKAGE_NAME>.csproj      # Inherits from Directory.Build.props
│   ├── Properties/AssemblyInfo.cs
│   ├── Customization/             # Hand-written partial classes (if needed)
│   │   └── <ModelName>.cs         # Override generated behavior
│   └── Generated/                 # Auto-generated (do NOT edit)
├── tests/
├── api/                           # API surface snapshots
├── CHANGELOG.md
├── README.md
├── Directory.Build.props
├── assets.json                    # Test recording assets reference
├── ci.mgmt.yml                    # CI pipeline definition
└── <PACKAGE_NAME>.sln
```

## Phase 5 — Customization (Naming Review)

Apply naming rules from the `azure-sdk-pr-review` skill. Use **Custom/*.cs** or **Customization/*.cs** partial classes (follow the package's existing structure) for .NET-side fixes:

### Customization Patterns

#### Partial class (add members, suppress generated members)
```csharp
// src/Custom/MyModel.cs (or src/Customization/MyModel.cs — follow the package's existing convention)
namespace Azure.ResourceManager.<Service>.Models
{
    public partial class MyModel
    {
        // Add computed properties, rename via [CodeGenMember], etc.
    }
}
```

#### `[CodeGenType]` — Override accessibility or rename a generated type
When a generated type is `internal` and `@@access` in `client.tsp` doesn't work (common for nested/wrapper types), use `[CodeGenType]` in Custom code to make it public:

```csharp
// src/Custom/Models/MyPublicModel.cs
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.<Service>.Models
{
    [CodeGenType("OriginalTypeSpecModelName")]
    public partial class MyPublicModel
    {
    }
}
```

The `[CodeGenType("...")]` attribute takes the **original TypeSpec model name** (not the C# renamed name). This links the Custom partial class to the generated internal type and overrides its accessibility to `public`.

### TypeSpec Decorator Customizations (in spec repo)
```typespec
// Rename parameter
@@clientName(Operations.create::parameters.resource, "content");

// Rename path parameter
@@Azure.ResourceManager.Legacy.renamePathParameter(Resources.list, "fooName", "name");

// Mark a non-pageable list operation as pageable (returns Pageable<T> instead of Response<ListType>)
// Requires: using Azure.ClientGenerator.Core.Legacy;
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
@@markAsPageable(InterfaceName.operationName, "csharp");

// Suppress warning
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
```

#### When to use `@@markAsPageable`
When the old SDK returned `Pageable<T>` / `AsyncPageable<T>` for a list operation, but the TypeSpec spec defines the operation as non-pageable (returns a wrapper list type like `FooList`), use `@@markAsPageable` to make the generator produce pageable methods. This is **preferred over** writing custom `SinglePagePageable<T>` wrapper code because:
- It reduces custom code that must be maintained
- The generated pageable implementation handles diagnostics, cancellation, and error handling correctly
- It keeps the SDK surface consistent with other generated methods

**Do NOT use `@@markAsPageable` if the operation is already marked with `@list`** — the `@list` decorator already makes the operation pageable, and adding `@@markAsPageable` will cause a compile error. Check the spec's operation definition before adding the decorator.

**Requirements:**
1. Add `using Azure.ClientGenerator.Core.Legacy;` to the `client.tsp` imports
2. Add `#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"` before each `@@markAsPageable` call
3. After adding the decorator, regenerate and remove any custom `[CodeGenSuppress]` + `SinglePagePageable` wrapper code

## Phase 5b — Extension Resources

Extension resources (deployed onto parent resources from different providers) require special handling:

### Parameterized Scopes
When the same resource type can be deployed onto multiple parent types (e.g., VM, HCRP, VMSS), use `OverrideResourceName` with parameterized scopes. Each scope generates a separate SDK resource type. The generator may produce duplicate `GetXxxResource()` methods in `MockableArmClient` when multiple entries exist for the same resource — this is a known generator bug requiring deduplication.

### Sub-Resource Operations: Avoid `Read<>` / `Extension.Read<>` for Non-Lifecycle Ops
When a sub-resource operation (e.g., getting a report under an assignment) uses `Read<>` or `Extension.Read<>` templates, the ARM library treats it as a **lifecycle read** operation. This causes:
- The resource's `resourceType` and `resourceIdPattern` to be set to the sub-resource path
- Collections using the wrong REST client
- Compile errors: CS1729 (wrong constructor), CS0029 (type mismatch), CS1503 (wrong argument)

**Fix**: Change sub-resource Get operations from `Read<>` to `ActionSync<>` (or `Extension.ActionSync<>` for extension resources) with a `@get` decorator:
```typespec
// WRONG — ARM library treats this as lifecycle Read
reportGet is Ops.Read<Resource, Response = ArmResponse<Report>, ...>;

// CORRECT — ActionSync with @get avoids lifecycle misclassification
@get reportGet is Ops.ActionSync<Resource, void, Response = ArmResponse<Report>, ...>;
```

### `@@alternateType` Decorator
When the spec uses older common types that generate incorrect C# types (e.g., `string` instead of `ResourceIdentifier` for ID properties), use `@@alternateType`:
```typespec
@@alternateType(MyModel.resourceId, Azure.ResourceManager.CommonTypes.ArmResourceIdentifier, "csharp");
```

## Phase 6 — Code Generation

**IMPORTANT**: Always use `dotnet build /t:GenerateCode` for SDK code generation. Do NOT use `tsp-client update` — it can produce different output and `@@clientName`/`@@access` decorators may not take effect with it.

Run generation from the SDK package `src/` directory:

```powershell
cd sdk\<service>\<PACKAGE_NAME>\src
dotnet build /t:GenerateCode
```

After generation:
1. Check `src/Generated/` for output files — verify file contents changed, not just file names.
2. Use `git diff --stat` to confirm the scope of changes. A typical migration touches hundreds of files with significant content changes.
3. Verify no compile errors: `dotnet build`. ApiCompat errors (`MembersMustExist`, `TypesMustExist`) indicate **breaking changes** — these must be investigated and fixed, not skipped.
4. Run existing tests if available: `dotnet test`.
5. Check ApiCompat with `dotnet pack --no-restore` — ApiCompat errors only surface during pack, not during build.
6. **Export the API surface** after all errors are fixed:
   ```powershell
   pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>
   ```
   Where `<SERVICE_NAME>` is the service folder name under `sdk/` (e.g., `guestconfiguration`). This updates the `api/*.cs` files. **CI will fail if the API surface files are not re-exported after migration.**

### Using `RegenSdkLocal.ps1` for Generator Fixes

When you've made local changes to the generator under `eng/packages/http-client-csharp-mgmt/`, use:
```powershell
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 <PACKAGE_NAME>
```
**Important**: This still fetches the spec commit from GitHub, so the commit in `tsp-location.yaml` must be pushed to remote. Use `dotnet build /t:GenerateCode` for normal iteration (NPM-published emitter).

### Handling ApiCompat Errors

ApiCompat compares the new generated API against the existing API surface files (`api/*.cs`). Failures mean the migration introduced breaking changes. For each error:

1. **Missing member/type**: The old API had a public member that no longer exists. Determine why:
   - **Renamed**: Add `@@clientName` in `client.tsp` to restore the old name, or add a backward-compat wrapper in Custom code.
   - **Removed from spec**: If the member was removed in a newer API version, it may be acceptable. Document in CHANGELOG.
   - **Changed signature**: Add a Custom code overload with the old signature that delegates to the new one.
   - **Changed accessibility**: Use `@@access` or `[CodeGenType]` to restore public visibility.
2. After fixing all breaking changes, re-export the API surface:
   ```powershell
   pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>
   ```
   Where `<SERVICE_NAME>` is the service folder name under `sdk/` (e.g., `guestconfiguration`, NOT the full package name).
3. Verify the full build passes: `dotnet build`.

## Phase 7 — CI & Changelog

**Do NOT hand-author or manually edit `metadata.json`** — it is auto-generated by the `tsp-client update` tooling during code generation. Always include the auto-generated `metadata.json` in your PR when generation creates or updates it; manual changes can cause conflicts or incorrect values.

### ci.mgmt.yml
```yaml
trigger: none
extends:
  template: /eng/pipelines/templates/stages/archetype-sdk-client.yml
  parameters:
    ServiceDirectory: <service>
    LimitForPullRequest: true
    Artifacts:
    - name: <PACKAGE_NAME>
      safeName: <PackageNameNoDotsNoDashes>
```

### CHANGELOG.md
```markdown
## <VERSION> (Unreleased)

### Features Added
- Upgraded API version to `<API_VERSION>`
- Migrated from Swagger to TypeSpec-based generation
```

## Phase 8 — Build Error Triage & Fix Loop

After code generation, build errors (including breaking changes) surface via `dotnet build`. Each error must be triaged and fixed iteratively.

### Step 1 — Collect Build Errors

```powershell
cd sdk\<service>\<PACKAGE_NAME>\src
dotnet build 2>&1 | Select-String "error CS"
```

Parse the output into a structured list of errors (file, code, message). Use a SQL table to track them:

```sql
CREATE TABLE build_errors (
  id TEXT PRIMARY KEY,
  error_code TEXT,
  file TEXT,
  message TEXT,
  root_cause TEXT,       -- 'spec' | 'generator' | 'customization' | 'unknown'
  status TEXT DEFAULT 'pending'  -- 'pending' | 'investigating' | 'fixed' | 'blocked'
);
```

### Step 2 — Triage Each Error

For each build error, determine the root cause:

| Root Cause | Symptoms | Fix Location |
|-----------|----------|--------------|
| **TypeSpec issue** | Missing/wrong model, property, enum value, or operation in generated code that can be corrected by updating the `.tsp` spec | Spec repo |
| **Naming/accessibility mismatch** | CS0234 (type not found — renamed), CS0051 (internal type used in public Custom code) | `client.tsp` in spec repo (`@@clientName` / `@@access`) or `src/Customization/*.cs` in SDK |
| **Generator bug/gap** | Correct spec but wrong codegen output (e.g., missing serialization, wrong type mapping, incorrect inheritance) | `eng/packages/http-client-csharp-mgmt` in SDK repo |
| **Customization needed** | Breaking change from rename, removed property, or type change that needs a compatibility shim | `src/Customization/*.cs` in SDK package |

#### Common Error Patterns

| Error Code | Typical Cause | Fix |
|-----------|--------------|-----|
| **CS0234** | Type name changed due to missing `@@clientName` rename | Add `@@clientName(SpecType, "OldSdkName", "csharp")` in `client.tsp`, regenerate |
| **CS0051** | Type became `internal` but Custom code references it publicly | First try `@@access(SpecType, Access.public, "csharp")` in `client.tsp`. If that doesn't work (common for nested/wrapper types), use `[CodeGenType("OriginalSpecName")]` in Custom code to override accessibility |
| **CS0246** | Type removed or restructured | Check if type was flattened, merged, or renamed. May need Custom code update |
| **CS0111** | Duplicate method/type definitions | For extension resources with parameterized scopes, check for duplicate resource entries. May need generator dedup fix |
| **CS1729/CS0029/CS1503** | Wrong REST client or type mismatch in collections | Sub-resource ops using `Read<>` template cause lifecycle misclassification. Fix by changing to `ActionSync<>` in spec (see Phase 5b) |
| **AZC0030** | Model name has forbidden suffix (`Request`, `Response`, `Parameters`) | Add `@@clientName` rename. Check old autorest SDK API surface for the **original name** to maintain backward compatibility, rather than inventing a new name |
| **AZC0032** | Model name has forbidden suffix (`Data`) not inheriting `ResourceData` | Add `@@clientName` rename to remove or replace the suffix |

#### Common ApiCompat Error Patterns

ApiCompat errors surface via `dotnet pack` (not `dotnet build`). **Do NOT use `ApiCompatBaseline.txt` to bypass breaking changes** — mitigate them with custom code instead.

| ApiCompat Error | Cause | Fix |
|----------------|-------|-----|
| **MembersMustExist** (method with different return type) | Generated method has different return type than old API (e.g., `Response<ReportList>` vs `Pageable<Report>`) | Use `[CodeGenSuppress("MethodName", typeof(ParamType))]` on the partial class to suppress the generated method, then provide a custom implementation with the old return type |
| **MembersMustExist** (missing extension method) | Old API had `GetXxx(ArmClient, ResourceIdentifier scope, string name)` but new only has `GetXxxResource(ArmClient, ResourceIdentifier id)` | Add custom extension methods that delegate to collection Get |
| **TypesMustExist** | Old API had a type that no longer exists (e.g., base class removed) | Create the type in Custom code with matching properties and `IJsonModel<>`/`IPersistableModel<>` serialization |
| **MembersMustExist** (property setter missing) | Generated property is get-only but old API had setter | Use `[CodeGenSuppress("PropertyName")]` and re-declare with `{ get; set; }` in custom partial class |

### Step 3 — Fix Based on Root Cause

#### If TypeSpec issue (including naming/accessibility):
1. Update `client.tsp` (or other `.tsp` files) in the spec repo.
2. Commit the spec change (use `git commit --amend` during iteration to keep clean history).
3. Push to the spec branch and note the new commit SHA.
4. Update `tsp-location.yaml` with the new `commit` SHA.
5. Regenerate with `dotnet build /t:GenerateCode` and rebuild with `dotnet build`.

#### If generator bug/gap:
1. Fix the generator code under `eng/packages/http-client-csharp-mgmt/`.
2. Verify the fix locally using the regen script:
   ```powershell
   pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 <PACKAGE_NAME>
   ```
3. Rebuild and confirm the error is resolved.
4. Create a feature branch for the generator fix and open a **draft PR** for it.
5. Continue migration work on top of that branch.

#### If customization needed:
1. Add a partial class under `src/Customization/` to address the issue.
2. Rebuild and confirm.

### Step 4 — Iterate

After fixing one error, rebuild and update the error list. Repeat until all errors are resolved. Update the SQL tracking table as you go:

```sql
UPDATE build_errors SET status = 'fixed', root_cause = 'generator' WHERE id = 'err-1';
```

### Sub-Agent Strategy for Error Triage

This loop is best handled **sequentially** with a mix of agent types:

1. **task agent** — Run `dotnet build`, collect errors, populate the SQL table.
2. **For each error** (sequential — each fix may change subsequent errors):
   - **explore agent** — Investigate the error: read the generated file, compare with spec, determine root cause.
   - **general-purpose agent** — Apply the fix (spec change, generator fix, or customization). Include full context: error message, file path, root cause, and relevant spec/generated code.
   - **task agent** — Regenerate (if spec/generator fix) and rebuild to verify.
3. **task agent** — Final full build + test to confirm all errors resolved.

> **Why sequential?** Each fix can resolve multiple errors or introduce new ones. Parallel fixing would cause conflicts and wasted work.

## Phase 9 — Final Reporting

1. **Summary**: Report what changed, what was renamed, what needs manual follow-up.
2. **Generator PRs**: List any draft PRs created for generator fixes.
3. **Spec changes**: List any spec commits made during triage.
4. **PR structure**: One PR per service, titled `[Mgmt] <PACKAGE_NAME>: Migrate to TypeSpec (API version <API_VERSION>)`.

## Fleet Mode Execution Strategy

When operating in fleet/autopilot mode, use sub-agents for parallelism:

### Parallel Phase (explore agents)
Launch these simultaneously at the start:
- **Agent 1**: Find spec location and determine spec type (TypeSpec vs Swagger)
- **Agent 2**: Analyze existing SDK package structure and current state
- **Agent 3**: Read naming guidelines from the azure-sdk-pr-review skill

### Sequential Phase (task/general-purpose agents)
Execute these in order after planning:
1. **Create/update tsp-location.yaml** (task agent)
2. **Delete autorest.md if needed** (task agent)
3. **Create ci.mgmt.yml if missing** (task agent)
4. **Run code generation** (task agent — long-running, use initial_wait: 120+)
5. **Apply customizations** (general-purpose agent — needs reasoning for naming rules)
6. **Build error triage loop** (see Phase 8 sub-agent strategy — sequential per error)
7. **Final build and validate** (task agent)

### Rules for Fleet Agents
- Always pass complete context in the prompt — agents are stateless.
- Include the service name, paths, spec commit, and API version in every agent prompt.
- For customization agents, include the full naming rules from the azure-sdk-pr-review skill.
- After each agent completes, verify output before launching dependent agents.
- Use `ask_user` for any destructive changes or ambiguous naming decisions.

## Phase 10 — Retrospective: Update This Skill File

After completing (or making significant progress on) a migration, review what was learned and update this skill file:

1. **New error patterns**: Did you encounter build errors (CS*, AZC*) not listed in the Common Error Patterns table? Add them.
2. **New workarounds**: Did you discover a workaround for a generator limitation? Document it in the relevant phase.
3. **New decorators or TypeSpec patterns**: Did you use decorators not mentioned here? Add them to Phase 5 or Phase 5b.
4. **Generator bugs fixed**: If you filed or fixed generator bugs, add a note about the symptom and fix.
5. **Common pitfalls**: Did you waste time on something avoidable? Add it to the Common Pitfalls section.

> **Goal**: Each migration should leave this skill file slightly better than it was before.

## Common Pitfalls

1. **Do NOT use `tsp-client update` for code generation.** Use `dotnet build /t:GenerateCode`. The former can produce different output and `@@clientName`/`@@access` decorators may not take effect.

2. **Do NOT compare only file names after generation.** The generated file names may be identical between old and new, but **file contents** change significantly (thousands of lines). Always use `git diff --stat` to verify content changes.

3. **Do NOT blindly copy all `rename-mapping` entries from `autorest.md` to `client.tsp`.** The mgmt emitter automatically handles many renames (RP prefix, acronym casing, `Is*` booleans). Compare old vs new generated types to find only the missing renames.

4. **Do NOT hand-author or manually edit `metadata.json`.** It is auto-generated by the tooling during code generation. Always include the auto-generated file in your PR.

5. **`@@access` may not work for all types.** Some types nested inside other models (e.g., `VolumePropertiesExportPolicy`) may not respond to `@@access` decorators. In those cases, update the Custom code instead.

6. **Custom code (`src/Custom/`) often references old type names.** After migration, scan Custom code for references to renamed or removed types. Common fixes: update type references, or add `@@clientName` to preserve the old name.

7. **Build errors cascade.** A single missing rename can cause dozens of errors. Fix one error at a time, rebuild, and re-assess — many errors may resolve together.

8. **Do NOT use `ApiCompatBaseline.txt` to bypass breaking changes.** Always mitigate breaking changes with custom code (`[CodeGenSuppress]`, partial classes, wrapper methods). The baseline should only be used as a last resort for changes that are truly impossible to fix.

9. **Use `dotnet pack` (not just `dotnet build`) to check ApiCompat errors.** API compatibility checks only run during pack. Run `dotnet pack --no-restore` to catch breaking changes early.

10. **Check the custom code folder name.** Different SDKs use different conventions: `Custom/`, `Customized/`, or `Customization/`. Always match the existing convention in the package.

11. **Sub-resource operations must NOT use `Read<>` template.** When a TypeSpec spec defines sub-resource Get operations using `Read<>` or `Extension.Read<>`, the ARM library treats them as lifecycle read operations, causing wrong REST client selection. Use `ActionSync<>` with `@get` instead. See Phase 5b.

12. **Use `@@markAsPageable` instead of custom `SinglePagePageable` wrappers.** When the old SDK returned `Pageable<T>` for a non-pageable list operation, prefer adding `@@markAsPageable(Interface.operation, "csharp")` in `client.tsp` over writing custom `[CodeGenSuppress]` + `SinglePagePageable<T>` wrapper code. This reduces custom code and produces a cleaner generated implementation.

13. **File name casing mismatches between Windows and Linux CI.** The TypeSpec code generator may produce file names with different casing than what git tracks (e.g., `GuestConfigurationHcrpAssignmentsRestOperations.cs` in git vs `GuestConfigurationHCRPAssignmentsRestOperations.cs` on disk). On Windows (case-insensitive) this is invisible, but on Linux CI these are treated as **different files** — CI sees the old lowercase file as "deleted" and the new uppercase file as "untracked", causing the "Generated code is not up to date" error. **Fix**: After code generation, check for casing mismatches with:
    ```powershell
    git ls-files "sdk/<service>/<PACKAGE_NAME>/src/Generated/" | ForEach-Object {
        $filename = Split-Path $_ -Leaf
        $dir = Split-Path $_ -Parent
        $diskFile = Get-ChildItem -LiteralPath (Join-Path (Get-Location) $dir) -Filter $filename -ErrorAction SilentlyContinue
        if ($diskFile -and ($diskFile.Name -cne $filename)) {
            Write-Host "MISMATCH: git='$filename' disk='$($diskFile.Name)' in $dir"
        }
    }
    ```
    Fix each mismatch with `git rm --cached <old-cased-path>` then `git add <new-cased-path>`.

14. **`@@markAsPageable` is ineffective on operations already marked with `@list`.** If a TypeSpec operation is already decorated with `@list` (making it pageable), adding `@@markAsPageable` is redundant and will cause a compile error: `@markAsPageable decorator is ineffective since this operation is already marked as pageable with @list decorator`. Before adding `@@markAsPageable`, check whether the target operation already has `@list` in its spec definition. Only add `@@markAsPageable` for operations that are truly non-pageable in the spec.

15. **Always run `CodeChecks.ps1` locally before pushing.** The CI "Verify Generated Code" step runs `eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>`, which regenerates code, updates snippets, re-exports API, and does `git diff --exit-code`. Run this locally to catch issues before CI:
    ```powershell
    pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>
    ```
    This is the single most reliable way to verify your changes will pass the "Build Analyze PRBatch" CI check.

## Safety Rules

1. **Never modify spec files** without explicit user confirmation.
2. **Delete `autorest.md`** after extracting directives — git history preserves it.
3. **Never edit files under `Generated/`** — they are overwritten by codegen.
4. **Always ask** before making destructive changes (deleting files, removing code).
5. **Preserve git history** — prefer renames over delete+create.
