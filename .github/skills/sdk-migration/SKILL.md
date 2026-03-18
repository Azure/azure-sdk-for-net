---
name: sdk-migration
description: Migration logic for Azure SDK for .NET libraries migrating from AutoRest/Swagger to TypeSpec-based generation.
---
# SDK Migration Workflow

Unified migration workflow for Azure SDK for .NET libraries. This file is the single source of truth for both data-plane (DPG) and management-plane (MPG) migrations. Sections marked **[MPG only]** or **[DPG only]** apply to one plane; everything else is shared.

## When Invoked

Trigger phrases: "migrate service X", "help with mgmt migration", "mpg migration", "mgmt sdk migration", "data-plane migration", "dpg migration", "migrate to TypeSpec", "swagger to TypeSpec migration", "upgrade generator", "generator migration help".

## Prerequisites

This skill requires two repositories side by side:

| Path | Purpose |
|------|---------|
| Current repository (`azure-sdk-for-net`) | Azure SDK for .NET mono-repo. SDK packages live under `sdk/<service>/Azure.ResourceManager.<Service>/`. |
| Sibling spec folder (`../azure-rest-api-specs`) | Full or sparse-checkout of the [Azure REST API Specs](https://github.com/Azure/azure-rest-api-specs) repo. TypeSpec specs live under `specification/<service>/resource-manager/Microsoft.<Provider>/<ServiceName>/`. |
| Sibling TypeSpec folder (`../typespec`) | (Optional) Clone of the [microsoft/typespec](https://github.com/microsoft/typespec) repo. Contains the base HTTP client generator under `packages/http-client-csharp/`. Only needed for diagnosing or fixing generator bugs. |

If the spec repo is not found at `../azure-rest-api-specs`, ask the user for the path.

## Inputs

Determine if the library is data-plane or management-plane - management-plane libraries will be named like Azure.ResourceManager.*. Data-plane libraries will have service-specific names without "ResourceManager".
For the purposes of diagnosing generator bugs, the management-plane emitter is located in this repo under `eng/packages/http-client-csharp-mgmt/`, while the data-plane emitter is in this repo under `eng/packages/http-client-csharp/`. The base emitter is in the microsoft/typespec repo under `packages/http-client-csharp/`.

| Variable | Example | Description |
|----------|---------|-------------|
| `LIBRARY_PATH` | `sdk/communication/Azure.Communication.Messages` | Relative path to the SDK package directory |
| `PACKAGE_NAME` | `Azure.Communication.Messages` | Full NuGet package / directory name |
| `SERVICE_NAME` | `communication` | The folder name immediately after `sdk/` |
| `EMITTER_PACKAGE_JSON_PATH` | see below | Path to the emitter package.json |

| Plane | `EMITTER_PACKAGE_JSON_PATH` | Target emitter in `tspconfig.yaml` |
|-------|----------------------------|------------------------------------|
| **DPG** | `eng/azure-typespec-http-client-csharp-emitter-package.json` | `azure-typespec/http-client-csharp` |
| **MPG** | `eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json` | `azure-typespec/http-client-csharp-mgmt` |

| Variable | Example | Description |
|----------|---------|-------------|
| `SPEC_DIR` | `specification/chaos/resource-manager/Microsoft.Chaos/Chaos` | TypeSpec directory in azure-rest-api-specs |
| `SPEC_COMMIT` | `37052dfa3f...` | Commit SHA from the spec repo |
| `API_VERSION` | `2025-01-01` | Target API version from the spec |

---

## Phase 0 — Sync Repositories

Before any migration work, merge the latest `main` branch into all 3 repos:

---

## Phase 1 — Discovery & Planning

Use **explore** agents in parallel:

1. **Find the spec**: Search `../azure-rest-api-specs/specification/<service>/` for `main.tsp` / `tspconfig.yaml`. Determine TypeSpec vs Swagger.
2. **Find the existing SDK**: Check for `tsp-location.yaml` (already migrated) or `src/autorest.md` (legacy Swagger).
3. **Inventory existing csharp customizations in spec**: Search `.tsp` files for `@clientName("...", "csharp")` and `@@clientName` decorators. Check for `back-compatible.tsp`.
4. **Snapshot old API surface**: Read `api/<PACKAGE_NAME>.net*.cs` — extract all public type names for later rename resolution.
5. **Extract autorest rename mappings**: From `src/autorest.md`, extract `rename-mapping` and `prepend-rp-prefix` entries.
6. **Identify custom code folder convention**: `Custom/`, `Customization/`, or `Customized/`.
7. **Review naming conventions**: Consult the `azure-sdk-mgmt-pr-review` skill.

Present a summary plan and **ask the user** to confirm.

---

## Phase 2 — Create/Update `tsp-location.yaml`

**Goal**: Point the library at the correct spec and emitter.

1. Check if `{LIBRARY_PATH}/tsp-location.yaml` exists.
   - **If it exists** (already TypeSpec-based): Read and parse `repo`, `directory`, and `commit` fields. Skip to step 3.
   - **If it does not exist** (migrating from swagger): Create `tsp-location.yaml` with the following fields:
     ```yaml
     directory: specification/<service>/resource-manager/Microsoft.<Provider>/<ServiceName>
     commit: <latest commit SHA from azure-rest-api-specs main>
     repo: Azure/azure-rest-api-specs
     cleanup: true
     ```
     Find the correct `directory` by searching `../azure-rest-api-specs/specification/<service>/` for a TypeSpec project (`main.tsp` + `tspconfig.yaml`) that targets the same service.
2. Set `emitterPackageJsonPath` to the plane-specific value (see Inputs table).
3. Resolve the correct commit SHA (see below).
4. Update the `commit` field with the resolved SHA.
5. If the `directory` path no longer exists, search for TypeSpec projects with similar service names.
6. Preserve all other existing fields.

### Commit SHA Resolution

```
1. Read current `commit` and `directory` from tsp-location.yaml.
2. Fetch tspconfig.yaml from spec repo at that commit.
3. IF tspconfig.yaml contains an `emit` or `options` entry for the target emitter
   → current commit is valid. Use it.
4. IF NOT → find the earliest commit on `main` that adds it.
5. IF directory no longer exists → search for relocated TypeSpec project, update `directory`, re-resolve.
6. IF nothing found → fall back to latest `main`. Warn user.
```

additional `tsp-location.yaml` fields:
- `directory` must point to the folder containing `main.tsp` and `tspconfig.yaml`.
- Optional: `additionalDirectories` array for shared TypeSpec libraries.

---

## Phase 3 — Handle Legacy Configuration

### Remove AutoRest dependency

1. Remove `<IncludeAutorestDependency>true</IncludeAutorestDependency>` from `.csproj` files.

### Handle `autorest.md` [MPG only]

If `src/autorest.md` exists:
1. Extract key config: `namespace`, `title`, `azure-arm: true`, `require` URL, `output-folder`, directives.
2. **Thoroughly analyze rename mappings** before deleting:
   - Extract ALL `rename-mapping` entries and `prepend-rp-prefix` entries from `autorest.md`.
   - The mgmt emitter auto-handles these naming transforms (anything **not** in this list still needs `@@clientName`):
     - **Model/property suffixes**: `Url`→`Uri`, `Etag`→`ETag`
     - **DateTimeOffset property suffixes**: `Time`→`On`, `Date`→`On`, `DateTime`→`On`, `At`→`On` (e.g. `CreatedAt`→`CreatedOn`). Also transforms word stems: `Creation`→`Created`, `Deletion`→`Deleted`, `Expiration`→`Expire`, `Modification`→`Modified`. Excludes properties starting with `From`/`To` or ending with `PointInTime`.
     - **RP prefix prepending**: Automatically prepends the resource provider name to: `Sku`, `SkuName`, `SkuTier`, `SkuFamily`, `SkuInformation`, `Plan`, `Usage`, `Kind`, `PrivateEndpointConnection`, `PrivateLinkResource`, `PrivateLinkServiceConnectionState`, `PrivateEndpointServiceConnectionStatus`, `PrivateEndpointConnectionProvisioningState`, `PrivateLinkResourceProperties`, `PrivateLinkServiceConnectionStateProperty`, `PrivateEndpointConnectionListResult`, `PrivateLinkResourceListResult`.
     - **Resource update models**: Models using the `ResourceUpdateModel` base type are auto-renamed — `{Resource}Patch` if used only in PATCH, or `{Resource}CreateOrUpdateContent` if used in both CREATE and UPDATE.
   - Most other renames from `autorest.md` will still need `@@clientName` decorators.
   - Do NOT blindly add all renames — check what `@clientName("...", "csharp")` decorators already exist in the spec `.tsp` files (e.g., `back-compatible.tsp`). These are already applied and must not be duplicated.
   - After initial code generation, **compare old vs new public type names** to find which renames are missing. Only add `@@clientName` decorators for types that actually cause build errors.
3. Delete `autorest.md` — git history preserves it.
4. Do NOT create a `client.tsp` in the SDK repo. The TypeSpec source lives in the spec repo.
5. Map remaining AutoRest directives to TypeSpec customization approach:
   - Model/property renames → `@@clientName(SpecNamespace.SpecTypeName, "SdkName", "csharp")` in spec repo `client.tsp`
   - Accessibility overrides → `@@access(SpecNamespace.TypeName, Access.public, "csharp")` in spec repo `client.tsp` (for types generated as `internal` that need to be `public`)
   - Type mapping overrides → `@@alternateType(SpecNamespace.Model.property, "Azure.ResourceManager.CommonTypes.ResourceIdentifier", "csharp")` for properties that should use SDK types instead of raw strings (e.g., resource IDs)
   - Suppressions → `#suppress` decorators in spec `.tsp` files
   - Format overrides → TypeSpec `@format` / `@encode` decorators

### SDK Package Structure [MPG only]

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

---

## Phase 4 — Update Custom Code

### CodeGen namespace and attributes

In all non-Generated `.cs` files under `{LIBRARY_PATH}/src/`:
1. Add `using Microsoft.TypeSpec.Generator.Customizations;` where `[CodeGen` attributes are used.
2. Replace `CodeGenClient` → `CodeGenType`
3. Replace `CodeGenModel` → `CodeGenType`

### DPG code transformations [DPG only]

Apply **before** code generation:
- `_pipeline` → `Pipeline` (field → property)
- Remove `using AutoRest.CSharp.Core;`
- `_serializedAdditionalRawData` → `_additionalBinaryDataProperties`
- `serializedAdditionalRawData` → `additionalBinaryDataProperties`
- `FromCancellationToken(cancellationToken)` → `cancellationToken.ToRequestContext()`

---

## Phase 5 — Code Generation

**Goal**: Regenerate code with the new TypeSpec emitter.

```shell
dotnet build <csproj_path> /t:GenerateCode
```

**IMPORTANT**: Always use `dotnet build /t:GenerateCode`. Do NOT use `tsp-client update`.

If generation fails, check if a customization file is causing it. Temporarily remove or fix it, then re-run. If it still fails with no customizations → generator bug.

local spec repo support:
```powershell
# During iteration — use local spec repo (no push needed)
dotnet build /t:GenerateCode /p:LocalSpecRepo=<path-to-azure-rest-api-specs>

# Final generation — uses commit from tsp-location.yaml
dotnet build /t:GenerateCode
```

After generation, additionally:
- Export the API surface: `pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>`.

### Post-Generation Checklist

1. Check `src/Generated/` for output files — verify file contents changed, not just file names.
2. Use `git diff --stat` to confirm the scope of changes. A typical migration touches hundreds of files with significant content changes.
3. Verify no compile errors: `dotnet build`. Then run `dotnet pack --no-restore` to check for ApiCompat errors (`CannotRemoveAttribute`, `MembersMustExist`, `TypesMustExist`) — these indicate **breaking changes** that must be investigated and fixed through spec-side fixes or custom code shims, **never** by creating `ApiCompatBaseline.txt` or disabling ApiCompat in the `.csproj`. See the ApiCompat Error → Fix Table in error-reference.md.
4. Run existing tests if available: `dotnet test`.
5.**Export the API surface** after all errors are fixed:
   ```powershell
   pwsh eng/scripts/Export-API.ps1 <SERVICE_NAME>
   ```
   Where `<SERVICE_NAME>` is the service folder name under `sdk/` (e.g., `guestconfiguration`). This updates the `api/*.cs` files. **CI will fail if the API surface files are not re-exported after migration.**

### Using `RegenSdkLocal.ps1` [MPG only]

When local generator changes exist under `eng/packages/http-client-csharp-mgmt/`:
```powershell
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME>
# With local spec repo:
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME> -LocalSpecRepoPath <path>
```

---

## Phase 6 — Build-Fix Cycle

**Goal**: Get the library to compile successfully through iterative error fixing.

### Command Macros

| Macro | Command |
|-------|---------|
| `[BUILD]` | `dotnet build /clp:ErrorsOnly 2>&1 \| Select-Object -First 50` |
| `[GENERATE]` | `dotnet build /t:GenerateCode` |
| `[TEST]` | `dotnet test --no-build --filter "TestCategory!=Live" 2>&1 \| Select-Object -Last 30` |

### Execution Protocol

```
LOOP:
  1. Run [BUILD] → collect ALL errors
  2. IF zero errors → EXIT LOOP
  3. Parse errors into structured list (error code, file, message)
  4. Group errors by root cause
  5. For each error group, check attempt_count:
     - IF attempt_count >= 5 → escalate to user
     - IF error count increased → escalate to user
  6. Apply fixes in batch
  7. Regenerate based on what changed:
     - Generator attributes changed → [GENERATE] then [BUILD]
     - Spec changes → [GENERATE] (with LocalSpecRepo) then [BUILD]
     - Generator code changes [MPG only] → RegenSdkLocal.ps1 then [BUILD]
     - Customization-only → just [BUILD]
  8. GOTO 1
```

Max 10 iterations. If still failing, escalate to user.

### Key Insight: Generator and Customization File Interaction

The generator reads existing customization files (`[CodeGenSuppress]`, `[CodeGenType]`, `[CodeGenMember]`, `[CodeGenSerialization]`) and produces **different output** based on them:

- Errors in `Generated/` are often **caused** by stale customization files, not generator bugs.
- Fix by editing the customization file, then re-running `[GENERATE]`.
- Only after eliminating customization interference can you identify true generator bugs.

### Error Classification

```
Given: error in file F with message M

1. IF F is under `src/Generated/`:
   a. Find the corresponding customization file
   b. Fix the customization to match new generated code
   c. Run [GENERATE] then [BUILD]
   d. If error persists after removing all customizations → generator bug

2. IF F is under custom code:
   a. Renamed/missing type → update custom code or add rename
   b. Internal type → use accessibility fix (@@access [MPG] or CodeGenType)

3. IF error is structural in Generated/ with correct spec → generator bug
```

### MPG Error Classification Detail [MPG only]

For each build error, classify it **without asking the user**:

```
Given: error in file F with message M

1. IF F is under `src/Generated/`:
   a. IF M mentions a type that exists in old API (`api/*.cs`) but with different name:
      → ROOT CAUSE: spec (missing @@clientName)
   b. IF M says type is "inaccessible due to protection level" (CS0051/CS0122):
      → ROOT CAUSE: spec (missing @@access) or customization ([CodeGenType])
   c. IF M is about wrong constructor args, type mismatch in return types:
      → ROOT CAUSE: spec (wrong template usage, or missing @@alternateType) or generator bug
      Check if old API used a different type (e.g., ResourceIdentifier vs string).
      If so, try @@alternateType in client.tsp first.
   d. IF M is AZC0030/AZC0032 (forbidden suffix):
      → ROOT CAUSE: spec (needs @@clientName rename)
   e. IF the generated code looks structurally wrong (missing serialization,
      wrong inheritance, wrong type mapping) and the spec is correct:
      → ROOT CAUSE: generator bug

2. IF F is under `src/Custom/` or `src/Customization/` or `src/Customized/`:
   a. IF M references a type that was renamed or no longer exists:
      → ROOT CAUSE: spec (add @@clientName to preserve old name) OR
                     customization (update custom code to use new name)
   b. IF M references a type that became internal:
      → ROOT CAUSE: spec (@@access) or customization ([CodeGenType])

3. IF error is from ApiCompat:
   a. IF rule is `TypesMustExist` AND the "missing" type matches a renamed type
      whose behavior/shape is otherwise unchanged:
      → ROOT CAUSE: spec (add @@clientName in client.tsp to restore previous public name)
   b. OTHERWISE (e.g., `MembersMustExist`, shape/behavior changes, or truly removed API):
      → ROOT CAUSE: customization (need backward-compat shim)
```

### DPG-Specific Error Patterns [DPG only]

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

### MPG-Specific Error Patterns [MPG only]

| Error | Root Cause | Fix |
|-------|-----------|-----|
| CS0234/CS0246 (type not found) | Type renamed by new generator | `@@clientName` in `client.tsp`, or update custom code |
| CS0051/CS0122 (inaccessible) | Type generated as `internal` | Try `@@access` first; fall back to `[CodeGenType]` |
| CS1729/CS0029/CS1503 (type mismatch) | Wrong type (e.g., `string` vs `ResourceIdentifier`) | `@@alternateType` in `client.tsp` |
| AZC0030 (forbidden suffix) | Naming analyzer rejects name | `@@clientName` to old name |
| AZC0032 (forbidden 'Data' suffix) | Doesn't inherit `ResourceData` | `@@clientName` to old name |
| ApiCompat MembersMustExist | Changed return type / missing member | `[CodeGenSuppress]` + custom shim (never use ApiCompatBaseline.txt) |
| ApiCompat CannotRemoveAttribute (WirePathAttribute) | Old SDK had `WirePathAttribute` but new generation doesn't | See `mitigate-breaking-changes` skill |
| ApiCompat TypesMustExist | Missing type | `@@clientName` to restore old name |

### MPG Fix Decision Tree [MPG only]

```
PREFER spec-side fix (@@clientName, @@access, @@alternateType) when:
  - Simple rename, accessibility change, or type mapping override
  - Multiple errors resolved by one decorator

PREFER SDK custom code when:
  - @@access doesn't work (nested/wrapper types)
  - Backward-compat methods/properties needed
  - One-off workaround for generator limitation

PREFER generator fix when:
  - Same bug affects ALL management SDKs
  - Generated code is structurally wrong despite correct spec
  - CAUTION: Run Generate.ps1 to verify no regressions
```

### Priority Order

1. Missing/renamed types (CS0234, CS0246)
2. Accessibility issues (CS0051, CS0122)
3. Signature mismatches (CS1729, CS0029, CS1503)
4. Duplicate definitions (CS0111)
5. Other errors — investigate individually

### Autonomous Rename Resolution Strategy [MPG only]

When migrating from autorest, many types get renamed. Resolve renames autonomously:

```
1. EXTRACT old names:
   a. Read api/<PACKAGE_NAME>.net*.cs for all public type names
   b. Read src/autorest.md rename-mapping entries (before deleting it)
   c. Store both in a lookup table

2. AFTER code generation, COMPARE:
   a. Get all new public type names from src/Generated/
   b. For each type referenced in custom code or old API surface:
      - IF type exists with same name → no action needed
      - IF type exists with different name → add @@clientName to preserve old name
      - IF type no longer exists → check if flattened/merged/removed

3. For ALL name mismatches that cause build errors, add @@clientName in client.tsp.
   PREFER @@clientName over updating custom code — it preserves backward compat
   and minimizes SDK-side changes.

4. For missing/moved operations (method not found, wrong resource type):
   a. Check the operation's HTTP path in the spec
   b. Compare with the old autorest-generated REST client
   c. IF the operation path changed in the spec → the spec was updated,
      add backward-compat wrapper in custom code if needed
   d. IF the operation path is the same but mapped to a different resource
      or extension scope → likely a generator bug in resource/scope assignment.
      Check the resource's resourceType and resourceIdPattern in generated code.
   e. IF the operation moved from one interface to another in the spec →
      check if it should be an extension resource operation (different scope)
```

### Batch Fix Strategy

When there are many errors (20+), fix them in batches to avoid unnecessary regeneration cycles:

```
1. Collect ALL errors from dotnet build
2. Group by root cause type
3. For spec fixes (@@clientName, @@access):
   a. Identify ALL needed decorators from the full error list
   b. Add them ALL to client.tsp in one batch
   c. Run `npx tsp format "**/*.tsp"` in the spec directory
   d. Regenerate ONCE with LocalSpecRepo
   e. Rebuild to see remaining errors
4. For custom code fixes:
   a. These don't need regeneration — fix as many as possible in one pass
   b. Rebuild after all custom code changes
5. For generator fixes:
   a. Fix one at a time — each may have cascading effects
   b. Regenerate and rebuild after each fix
```

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

### SQL Error Tracking

```sql
CREATE TABLE build_errors (
  id TEXT PRIMARY KEY,
  error_code TEXT, file TEXT, message TEXT,
  root_cause TEXT,       -- 'spec' | 'generator' | 'customization' | 'unknown'
  fix_type TEXT,         -- 'clientName' | 'access' | 'codeGenType' | 'codeGenSuppress' | 'custom_code' | 'generator_fix'
  fix_detail TEXT,
  attempt_count INTEGER DEFAULT 0,
  last_fix_attempted TEXT,
  status TEXT DEFAULT 'pending'  -- 'pending' | 'investigating' | 'fixed' | 'blocked' | 'cascaded'
);
```

---

## Phase 7 — CI & Changelog [MPG only]

**Do NOT hand-edit `metadata.json`** — it is auto-generated.

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
- Migrated from Swagger to TypeSpec-based generation
```

---

## Phase 8 — Test Project Build

1. If `tests/Generated/Samples/` exists, move contents to `tests/Samples/`. Do NOT run `[GENERATE]` in tests.
2. Run `[BUILD]` in the tests directory.
3. Fix errors (test files are not generated — edit directly).
4. Check `src/Generated/` for actual new type names before writing fixes.
5. Repeat (max 10 iterations). If still failing, skip to finalization.

---

## Phase 9 — Test Execution

1. Run `[TEST]` in the tests directory.
2. Fix failures, run `[BUILD]`, then `[TEST]` again.
3. Repeat (max 5 iterations). If still failing, continue to finalization.

---

## Phase 10 — Finalization

Run from the **repository root**:

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

### Step 3 — Create Generator PR (if applicable) [MPG only]

1. In the SDK repo, create a branch containing **only** the generator changes under `eng/packages/http-client-csharp-mgmt/`.
2. Push and create a PR against `Azure/azure-sdk-for-net`.
3. PR title: `[Mgmt Generator] Fix <description> for <Service> migration`
4. Include test project regeneration if the fix affects other SDKs (run `eng/packages/http-client-csharp-mgmt/eng/scripts/Generate.ps1`).

### Step 4 — Create SDK Migration PR

1. Update `tsp-location.yaml` with the final spec commit SHA from Step 2.
2. Regenerate one final time **without** `LocalSpecRepo` to verify CI-reproducible generation:
   ```powershell
   cd sdk\<service>\<PACKAGE_NAME>\src
   dotnet build /t:GenerateCode
   ```
3. Verify `dotnet build` still passes.
4. Run pre-commit checks (Export-API, Update-Snippets, dotnet format).
5. Commit all SDK changes and create a PR against `Azure/azure-sdk-for-net`.
6. PR title: `[Mgmt] <PACKAGE_NAME>: Migrate to TypeSpec (API version <API_VERSION>)` **[MPG only]**
7. PR title: `<PACKAGE_NAME>: Migrate to TypeSpec (API version <API_VERSION>)` **[DPG only]**
8. In the PR description, link to the spec PR and generator PR (if any) as dependencies.

### Step 5 — Report Summary

After all PRs are created, report:
1. **Spec PR**: Link and summary of decorators added.
2. **Generator PR**: Link and summary of fixes (if any).
3. **SDK PR**: Link and summary of migration changes.
4. **Manual follow-up**: Any remaining items that need human review (naming decisions, breaking changes, etc.).

---

## Phase 12 — Verify and Summarize

1. Report summary of all completed steps and warnings.
2. Note any `CodeGenType` attributes needing manual review.
3. Remind user to review with `git diff` before committing.
4. Suggest running the `pre-commit-checks` skill.

---

## Phase 13 — Retrospective [MPG only]

After migration, update skill files with:
1. New error patterns → [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/sdk-migration/error-reference.md)
2. New decorators/TypeSpec patterns → `mitigate-breaking-changes` skill
3. New workarounds/pitfalls → [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/sdk-migration/error-reference.md)

---

## Generator Bug Diagnosis

Before reporting a generator bug, ALWAYS:
1. Remove/fix any customization files that could influence the generator.
2. Re-run `[GENERATE]`.
3. If the error persists with no customization influence → generator bug.

Report: error messages, generated code snippet, repro steps. Do NOT manually fix Generated/ code.

### Generator Fix Workflow [MPG only]

```
1. CONFIRM it's a generator bug
2. IF fixing generator:
   - Edit under eng/packages/http-client-csharp-mgmt/
   - Regenerate with RegenSdkLocal.ps1
   - Clean up stale custom workarounds
   - Run Generate.ps1 to verify no regressions
3. IF workaround: [CodeGenSuppress] + custom implementation, document the issue
```

---

## Safety Rules

### Hard Rules (Never Violate)

1. **Never edit files under `Generated/`** — they are overwritten by codegen.
2. **Never hand-edit `metadata.json`** — it is auto-generated.
3. **Never use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
4. **Never create or add entries to `ApiCompatBaseline.txt`** — this file must never be used to bypass breaking changes. Always mitigate ApiCompat errors through spec-side fixes (`@@clientName`) or SDK custom code shims (see error-reference.md). If you encounter ApiCompat errors, follow the ApiCompat Error → Fix Table — do NOT suppress them via baseline files.
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
5. **Regenerating code** using `dotnet build /t:GenerateCode` or **[MPG only]** `RegenSdkLocal.ps1`.
6. **Updating CHANGELOG.md** and other metadata files.

### Actions Requiring User Confirmation

These actions **require explicit user approval** (use `ask_user`):

1. **Modifying spec `.tsp` files beyond `client.tsp`** — e.g., changing `main.tsp`, model definitions, or operation signatures. These affect all languages, not just C#.
2. **Generator code changes** that affect other SDKs — run `Generate.ps1` to verify scope first.
3. **Removing public API surface** with no backward-compat option (true breaking change).
4. **Deleting existing custom code files** — may lose manually-written logic.

### Escalation Criteria

Proceed **without asking the user** except when:
1. Ambiguous fix — multiple equally valid approaches.
2. Breaking API change with no backward-compat option.
3. Generator fix affects other SDKs.
4. 5 consecutive failed attempts for the same error.
5. Error count increases after a fix.

---

## Fleet Mode Execution Strategy

### Parallel Phase (explore agents)
- **Agent 1**: Find spec location and determine spec type
- **Agent 2**: Analyze existing SDK package structure
- **Agent 3**: Read naming guidelines from `azure-sdk-mgmt-pr-review` skill [MPG only]

### Sequential Phase (task/general-purpose agents)
1. Create/update `tsp-location.yaml`
2. Delete `autorest.md` if needed
3. Create `ci.mgmt.yml` if missing
4. Run code generation (initial_wait: 120+)
5. Apply customizations (general-purpose agent for naming rules)
6. Build error triage loop
7. Final build and validate

### Sub-Agent Strategy
1. **task agent** — Run `dotnet build`, collect errors, populate SQL table.
2. **Batch spec fixes**: explore → general-purpose → task (regenerate + rebuild).
3. **Batch custom code fixes**: explore → general-purpose → task (rebuild).
4. **Generator fixes** (one at a time): explore → general-purpose → task (RegenSdkLocal + rebuild) → general-purpose (clean up stale workarounds) → task (rebuild).

## Common Pitfalls

- **Do NOT use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
- **Do NOT hand-edit `metadata.json`**.
- **Match existing custom code folder convention**.
- Don't blindly copy all renames from `autorest.md` — only add `@@clientName` for names that actually cause build errors after generation. Check existing spec decorators to avoid duplicates.
- Batch spec fixes, then rebuild — one spec fix can resolve 5–20 errors.
- Try spec-side fix (`@@access`) before custom code (`[CodeGenType]`).
- Finalize `tsp-location.yaml` with pushed spec commit before creating PR.
- Run `CodeChecks.ps1` before pushing: `pwsh eng\scripts\CodeChecks.ps1 -ServiceDirectory <service>`
- Clean up stale custom workarounds after generator fixes.
