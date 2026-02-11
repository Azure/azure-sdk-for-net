---
name: mpg-sdk-migration
description: Migrate an Azure management-plane .NET SDK from Swagger/AutoRest to TypeSpec-based generation. Use when asked to migrate a service, do MPG migration, update spec, or bring SDK to latest TypeSpec.
---
# Skill: mgmt-sdk-migration

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
4. **Review naming conventions**: Consult the [azure-sdk-mgmt-pr-review](.github/skills/azure-sdk-mgmt-pr-review/SKILL.md) skill for naming review rules.

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
2. Commit (or `git commit --amend`) and push to the spec branch.
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

Apply naming rules from the [azure-sdk-mgmt-pr-review](.github/skills/azure-sdk-mgmt-pr-review/SKILL.md) skill. Use **Customization/*.cs** partial classes for .NET-side fixes:

### Customization Patterns

#### Partial class (add members, suppress generated members)
```csharp
// src/Customization/MyModel.cs
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

// Suppress warning
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
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

### Handling ApiCompat Errors

ApiCompat compares the new generated API against the existing API surface files (`api/*.cs`). Failures mean the migration introduced breaking changes. For each error:

1. **Missing member/type**: The old API had a public member that no longer exists. Determine why:
   - **Renamed**: Add `@@clientName` in `client.tsp` to restore the old name, or add a backward-compat wrapper in Custom code.
   - **Removed from spec**: If the member was removed in a newer API version, it may be acceptable. Document in CHANGELOG.
   - **Changed signature**: Add a Custom code overload with the old signature that delegates to the new one.
   - **Changed accessibility**: Use `@@access` or `[CodeGenType]` to restore public visibility.
2. After fixing all breaking changes, re-export the API surface:
   ```powershell
   dotnet build /t:ExportApi
   ```
3. Verify the full build passes: `dotnet build`.

## Phase 7 — CI & Changelog

**Do NOT create `metadata.json`** — it is auto-generated by the `tsp-client update` tooling during code generation. Creating it manually can cause conflicts or incorrect values.

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
| **AZC0030** | Model name has forbidden suffix (`Request`, `Response`, `Parameters`) | Add `@@clientName` rename. Check old autorest SDK API surface for the **original name** to maintain backward compatibility, rather than inventing a new name |
| **AZC0032** | Model name has forbidden suffix (`Data`) not inheriting `ResourceData` | Add `@@clientName` rename to remove or replace the suffix |

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
- **Agent 3**: Read naming guidelines from the azure-sdk-mgmt-pr-review skill

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
- For customization agents, include the full naming rules from the azure-sdk-mgmt-pr-review skill.
- After each agent completes, verify output before launching dependent agents.
- Use `ask_user` for any destructive changes or ambiguous naming decisions.

## Common Pitfalls

1. **Do NOT use `tsp-client update` for code generation.** Use `dotnet build /t:GenerateCode`. The former can produce different output and `@@clientName`/`@@access` decorators may not take effect.

2. **Do NOT compare only file names after generation.** The generated file names may be identical between old and new, but **file contents** change significantly (thousands of lines). Always use `git diff --stat` to verify content changes.

3. **Do NOT blindly copy all `rename-mapping` entries from `autorest.md` to `client.tsp`.** The mgmt emitter automatically handles many renames (RP prefix, acronym casing, `Is*` booleans). Compare old vs new generated types to find only the missing renames.

4. **Do NOT create `metadata.json` manually.** It is auto-generated by the tooling during code generation.

5. **`@@access` may not work for all types.** Some types nested inside other models (e.g., `VolumePropertiesExportPolicy`) may not respond to `@@access` decorators. In those cases, update the Custom code instead.

6. **Custom code (`src/Custom/`) often references old type names.** After migration, scan Custom code for references to renamed or removed types. Common fixes: update type references, or add `@@clientName` to preserve the old name.

7. **Build errors cascade.** A single missing rename can cause dozens of errors. Fix one error at a time, rebuild, and re-assess — many errors may resolve together.

## Safety Rules

1. **Never modify spec files** without explicit user confirmation.
2. **Delete `autorest.md`** after extracting directives — git history preserves it.
3. **Never edit files under `Generated/`** — they are overwritten by codegen.
4. **Always ask** before making destructive changes (deleting files, removing code).
5. **Preserve git history** — prefer renames over delete+create.
