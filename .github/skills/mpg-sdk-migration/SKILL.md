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
4. **Snapshot old API surface**: Read `api/<PACKAGE_NAME>.net*.cs` and extract all public type names. Store in a lookup table for later rename resolution (Phase 8).
5. **Extract autorest rename mappings**: If `src/autorest.md` exists, extract all `rename-mapping` and `prepend-rp-prefix` entries. Store for comparison after generation.
6. **Identify custom code folder convention**: Check which name the package uses: `Custom/`, `Customization/`, or `Customized/`. Match this convention for all new custom code files.
7. **Review naming conventions**: Consult the `azure-sdk-mgmt-pr-review` skill for naming review rules.

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
   - The mgmt emitter auto-handles these naming transforms (anything **not** in this list still needs `@@clientName`):
     - **Model/property suffixes**: `Url`→`Uri`, `Etag`→`ETag`
     - **DateTimeOffset property suffixes**: `Time`→`On`, `Date`→`On`, `DateTime`→`On`, `At`→`On` (e.g. `CreatedAt`→`CreatedOn`). Also transforms word stems: `Creation`→`Created`, `Deletion`→`Deleted`, `Expiration`→`Expire`, `Modification`→`Modified`. Excludes properties starting with `From`/`To` or ending with `PointInTime`.
     - **RP prefix prepending**: Automatically prepends the resource provider name to: `Sku`, `SkuName`, `SkuTier`, `SkuFamily`, `SkuInformation`, `Plan`, `Usage`, `Kind`, `PrivateEndpointConnection`, `PrivateLinkResource`, `PrivateLinkServiceConnectionState`, `PrivateEndpointServiceConnectionStatus`, `PrivateEndpointConnectionProvisioningState`, `PrivateLinkResourceProperties`, `PrivateLinkServiceConnectionStateProperty`, `PrivateEndpointConnectionListResult`, `PrivateLinkResourceListResult`.
     - **Resource update models**: Models using the `ResourceUpdateModel` base type are auto-renamed — `{Resource}Patch` if used only in PATCH, or `{Resource}CreateOrUpdateContent` if used in both CREATE and UPDATE.
   - Most other renames from `autorest.md` will still need `@@clientName` decorators.
   - Do NOT blindly add all renames — check what `@clientName("...", "csharp")` decorators already exist in the spec `.tsp` files (e.g., `back-compatible.tsp`). These are already applied and must not be duplicated.
   - After initial code generation, **compare old vs new public type names** to find which renames are missing. Only add `@@clientName` decorators for types that actually cause build errors.
3. Delete `src/autorest.md` — git history preserves the original content.
4. Do NOT create a `client.tsp` in the SDK repo. The TypeSpec source lives in the spec repo.
5. Map remaining AutoRest directives to TypeSpec customization approach:
   - Model/property renames → `@@clientName(SpecNamespace.SpecTypeName, "SdkName", "csharp")` in spec repo `client.tsp`
   - Accessibility overrides → `@@access(SpecNamespace.TypeName, Access.public, "csharp")` in spec repo `client.tsp` (for types generated as `internal` that need to be `public`)
   - Type mapping overrides → `@@alternateType(SpecNamespace.Model.property, "Azure.ResourceManager.CommonTypes.ResourceIdentifier", "csharp")` for properties that should use SDK types instead of raw strings (e.g., resource IDs)
   - Suppressions → `#suppress` decorators in spec `.tsp` files
   - Format overrides → TypeSpec `@format` / `@encode` decorators

### Spec ↔ SDK Iteration Cycle

The goal of iteration is to **get `dotnet build` to pass with zero errors** on the generated SDK code. During iteration, you may need to fix issues in the **spec**, the **generator**, or **SDK custom code**. Use local paths to regenerate without pushing to remote — this keeps the cycle fast.

**Loop until `dotnet build` succeeds with no errors:**

1. **Identify the error** — Run `dotnet build` and triage the error (spec issue, generator bug, or customization needed).
2. **Fix the source:**
   - **Spec fix**: Edit `client.tsp` (or other `.tsp` files) in the local spec repo (`../azure-rest-api-specs`). Run `npx tsp format "**/*.tsp"` in the spec directory.
   - **Generator fix**: Edit generator code under `eng/packages/http-client-csharp-mgmt/`.
   - **Customization fix**: Edit or add partial classes under `src/Customization/` in the SDK package.
3. **Regenerate** based on what changed:
   - **Spec-only change** — regenerate with local spec:
     ```powershell
     cd sdk\<service>\<PACKAGE_NAME>\src
     dotnet build /t:GenerateCode /p:LocalSpecRepo=<full-path-to-azure-rest-api-specs>
     ```
   - **Generator-only change** — regenerate with local generator:
     ```powershell
     pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME>
     ```
   - **Both spec and generator changed** — regenerate with both local:
     ```powershell
     pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME> -LocalSpecRepoPath <full-path-to-azure-rest-api-specs>
     ```
   - **Customization-only change** — no regeneration needed, just rebuild.
4. **Rebuild**: `dotnet build` to check if errors are resolved.
5. **Repeat** from step 1 until `dotnet build` passes with zero errors.

**After the loop completes (build succeeds):**
1. Proceed to **Phase 9 — Create Pull Requests** to push changes and create separate PRs.

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

Apply naming rules from the `azure-sdk-mgmt-pr-review` skill. For detailed customization techniques, invoke the `mitigate-breaking-changes` skill.

Key approaches:
- **SDK-side**: Partial classes under `Custom/` or `Customization/`:
  - Plain partial class — add new members or override behavior (no attributes needed)
  - `[CodeGenType("SpecName")]` — only needed when the custom class name differs from the spec/generated type name, to link them
  - `[CodeGenSuppress("MemberName", typeof(...))]` — only needed when replacing a specific generated member with a custom implementation
  - `[CodeGenMember("MemberName")]` — only needed when a custom property name differs from the generated property name
- **Spec-side**: `@@clientName`, `@@access`, `@@markAsPageable`, `@@alternateType` decorators in `client.tsp`
- **Extension resources**: Parameterized scopes, `ActionSync<>` for sub-resource ops (see the `mitigate-breaking-changes` skill)

## Phase 6 — Code Generation

**IMPORTANT**: Always use `dotnet build /t:GenerateCode` for SDK code generation. Do NOT use `tsp-client update` — it can produce different output and `@@clientName`/`@@access` decorators may not take effect with it.

Run generation from the SDK package `src/` directory:

```powershell
cd sdk\<service>\<PACKAGE_NAME>\src

# During iteration — use local spec repo for speed (no need to push spec changes first)
dotnet build /t:GenerateCode /p:LocalSpecRepo=<full-path-to-azure-rest-api-specs>

# For final generation — uses commit from tsp-location.yaml (fetches from remote)
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
# Generator-only change (fetches spec from remote)
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME>

# Both generator and spec changed (uses local spec repo — no push needed)
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME> -LocalSpecRepoPath <full-path-to-azure-rest-api-specs>
```
**Note**: Without `-LocalSpecRepoPath`, this fetches the spec commit from GitHub, so the commit in `tsp-location.yaml` must be pushed to remote.

### Handling ApiCompat Errors

ApiCompat errors surface via `dotnet pack` (not `dotnet build`). See [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md) for the full ApiCompat error pattern table and fix strategies.

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

## Phase 8 — Autonomous Build-Fix Loop

After code generation, build errors surface via `dotnet build`. This phase runs **autonomously** — Copilot triages and fixes errors without asking the user, following the decision trees below. The loop continues until `dotnet build` passes with zero errors.

### Autonomous Execution Protocol

```
LOOP:
  1. Run `dotnet build` → collect ALL errors
  2. IF zero errors → EXIT LOOP (proceed to Phase 9)
  3. Parse errors into structured list (error code, file, message)
  4. Group errors by root cause using Classification Algorithm
  5. For each error group, check attempt_count:
     - IF attempt_count >= 5 for any error → escalate to user via ask_user
     - IF error count increased from previous iteration → escalate to user
  6. Apply fixes in batch using Priority Order and Decision Tree
  7. Increment attempt_count for each error that was targeted by a fix
  8. IF any fix required spec change → regenerate with LocalSpecRepo
  9. IF any fix required generator change → regenerate with RegenSdkLocal.ps1
  10. GOTO 1
```

**Priority order** (fix these first — they cascade into many other errors):
1. Missing/renamed types (CS0234, CS0246) — one `@@clientName` fixes 5–20 errors
2. Accessibility issues (CS0051, CS0122) — one `@@access` or `[CodeGenType]` fixes multiple
3. Naming rule violations (AZC0030, AZC0032) — one rename per type
4. Signature mismatches (CS1729, CS0029, CS1503) — often a spec template issue
5. Duplicate definitions (CS0111) — usually generator or spec dedup issue
6. Other errors — investigate individually

### Error Classification Algorithm

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

### Autonomous Fix Decision Tree

For each classified error, apply the fix **without asking the user**. Look up the specific error code in [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md) for the migration-specific root cause and fix.

#### Decision: Spec Fix vs SDK Custom Code vs Generator Fix

```
PREFER spec-side fix (@@clientName, @@access, @@alternateType in client.tsp) when:
  - The fix is a simple rename, accessibility change, or type mapping override
  - Multiple errors would be resolved by one decorator
  - The old name/accessibility is clearly documented in api/*.cs

PREFER SDK custom code when:
  - @@access doesn't work (nested/wrapper types — try spec first, fall back to [CodeGenType])
  - The fix requires adding backward-compat methods or properties
  - The change is specific to this SDK and shouldn't affect the spec
  - It's a one-off workaround for a generator limitation

PREFER generator fix when:
  - The same bug would affect ALL management SDKs (not just this one)
  - The generated code is structurally wrong despite a correct spec
  - CAUTION: Generator fixes require running Generate.ps1 to verify no regressions
```

#### Generator Fix Workflow

```
1. CONFIRM it's a generator bug (spec compiles, generated code is structurally wrong)
2. DECIDE: fix generator vs workaround (see error-reference.md Generator Bug Detection)
3. IF fixing generator:
   - Edit code under eng/packages/http-client-csharp-mgmt/
   - Regenerate with RegenSdkLocal.ps1:
     pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME>
     (add -LocalSpecRepoPath if spec was also changed)
   - CLEAN UP stale custom workarounds that are now redundant after the fix
     (e.g., [CodeGenSuppress] + manual implementations for the same issue)
   - Run Generate.ps1 to verify no regressions on other SDKs
   - Rebuild and confirm
4. IF workaround: [CodeGenSuppress] + custom implementation, document the issue
```

### Autonomous Rename Resolution Strategy

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

### SQL Error Tracking

Track errors and fixes for observability:

```sql
CREATE TABLE build_errors (
  id TEXT PRIMARY KEY,
  error_code TEXT,
  file TEXT,
  message TEXT,
  root_cause TEXT,       -- 'spec' | 'generator' | 'customization' | 'unknown'
  fix_type TEXT,         -- 'clientName' | 'access' | 'codeGenType' | 'codeGenSuppress' | 'custom_code' | 'generator_fix' | 'spec_template'
  fix_detail TEXT,       -- description of what was changed
  attempt_count INTEGER DEFAULT 0,  -- incremented each time a fix is attempted
  last_fix_attempted TEXT,          -- description of the last fix tried
  status TEXT DEFAULT 'pending'  -- 'pending' | 'investigating' | 'fixed' | 'blocked' | 'cascaded'
);
```

Update as you work:
```sql
-- After fixing a batch of renames
UPDATE build_errors SET status = 'fixed', root_cause = 'spec', fix_type = 'clientName',
  fix_detail = 'Added @@clientName(NewName, "OldName", "csharp") in client.tsp'
WHERE error_code = 'CS0234' AND message LIKE '%OldTypeName%';

-- Errors resolved by cascade (fixed by another fix)
UPDATE build_errors SET status = 'cascaded' WHERE status = 'pending' AND id IN (...);
```

### Escalation Criteria

The autonomous loop proceeds **without asking the user** except when:

1. **Ambiguous rename** — Two equally valid old names exist and the correct choice is unclear
2. **Breaking API change with no backward-compat option** — A public type/method must be removed
3. **Generator fix affects other SDKs** — The fix would change behavior for all management SDKs
4. **Spec correctness concern** — The spec itself appears to have a bug (missing model, wrong type) beyond naming
5. **5 consecutive failed attempts** for the same error — something unexpected is happening
6. **Error count increases after a fix** — The fix made things worse

For all other cases, **proceed autonomously** using the decision trees above.

### Sub-Agent Strategy

This loop is best handled with batched sequential execution:

1. **task agent** — Run `dotnet build`, collect errors, populate the SQL table.
2. **Batch spec fixes** (most impactful first):
   - **explore agent** — Analyze ALL CS0234/CS0246/CS0051/CS1729/CS1503/AZC0030/AZC0032 errors. Compare old API surface (`api/*.cs`) vs new generated names. Identify ALL needed `@@clientName`, `@@access`, and `@@alternateType` decorators.
   - **general-purpose agent** — Apply ALL spec fixes to `client.tsp` in one batch. Include full context: all error messages, old API names, new generated names.
   - **task agent** — Regenerate with `LocalSpecRepo` and rebuild.
3. **Batch custom code fixes**:
   - **explore agent** — Analyze remaining errors in custom code, determine fixes needed.
   - **general-purpose agent** — Apply custom code fixes (partial classes, `[CodeGenSuppress]`, `[CodeGenType]`, etc.).
   - **task agent** — Rebuild (no regeneration needed).
4. **Generator fixes** (if any — one at a time):
   - **explore agent** — Confirm generator bug, determine fix vs workaround approach.
   - **general-purpose agent** — Apply generator fix or custom code workaround.
   - **task agent** — Regenerate with `RegenSdkLocal.ps1` and rebuild.
   - **general-purpose agent** — After generator fix, check for stale custom code workarounds that were added for the same issue earlier. Remove any `[CodeGenSuppress]` + manual implementations that are now redundant because the generator produces correct output.
   - **task agent** — Rebuild again after cleanup to confirm no regressions.
5. **task agent** — Final full build to confirm all errors resolved.

> **Why batched-sequential?** Spec fixes should be batched (one regeneration for many renames). Custom code fixes can be batched (no regeneration). Generator fixes are one-at-a-time (cascading effects). This minimizes regeneration cycles while avoiding conflicts.

## Phase 9 — Create Pull Requests

Once `dotnet build` passes with zero errors, create **separate PRs** for each category of change. This keeps reviews focused and allows independent merge timelines.

### Step 1 — Classify Changes

During the iteration loop, changes fall into three categories. Identify which ones apply:

| Category | Repository | What changed | PR needed? |
|----------|-----------|-------------|------------|
| **Spec changes** | `azure-rest-api-specs` | `client.tsp` decorators (`@@clientName`, `@@access`, `@@markAsPageable`, etc.) | Yes, if any spec files were modified |
| **Generator changes** | `azure-sdk-for-net` | Files under `eng/packages/http-client-csharp-mgmt/` | Yes, if generator code was fixed |
| **SDK migration** | `azure-sdk-for-net` | `tsp-location.yaml`, `Generated/`, `Customization/`, `api/`, `CHANGELOG.md`, etc. | Always yes |

### Step 2 — Create Spec PR (if applicable)

1. In the local spec repo (`../azure-rest-api-specs`), create a branch and commit all spec changes.
2. Push the branch and create a PR against `Azure/azure-rest-api-specs`.
3. Note the **final commit SHA** from the pushed branch.
4. PR title: `Add csharp client customizations for <Service> migration`

### Step 3 — Create Generator PR (if applicable)

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
6. PR title: `[Mgmt] <PACKAGE_NAME>: Migrate to TypeSpec (API version <API_VERSION>)`
7. In the PR description, link to the spec PR and generator PR (if any) as dependencies.

### Step 5 — Report Summary

After all PRs are created, report:
1. **Spec PR**: Link and summary of decorators added.
2. **Generator PR**: Link and summary of fixes (if any).
3. **SDK PR**: Link and summary of migration changes.
4. **Manual follow-up**: Any remaining items that need human review (naming decisions, breaking changes, etc.).

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

## Phase 10 — Retrospective: Update Skill Files

After completing (or making significant progress on) a migration, review what was learned and update the skill files:

1. **New error patterns**: Add to [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md).
2. **New decorators or TypeSpec patterns**: Add to the `mitigate-breaking-changes` skill.
3. **New workarounds or pitfalls**: Add to [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md) Common Pitfalls section.
4. **Migration flow changes**: Update this file (SKILL.md).

> **Goal**: Each migration should leave these skill files slightly better than they were before.

## Common Pitfalls

See [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md) for the full list of common pitfalls and autonomous fix recipes. Key ones to remember during the migration flow:

- **Do NOT use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
- **Do NOT blindly copy all renames from `autorest.md`** — after generation, only add `@@clientName` for names that actually cause build errors. Check existing spec decorators to avoid duplicates.
- **Batch spec fixes, then rebuild** — collect ALL needed `@@clientName`/`@@access` decorators before regenerating, to minimize regeneration cycles.
- **Build errors cascade** — one spec fix can resolve 5–20 errors. Always rebuild after each batch.
- **Try spec-side fix (`@@access`) before custom code (`[CodeGenType]`)** — spec-side is cleaner but doesn't work for all types.
- **Finalize `tsp-location.yaml` before creating the PR** — easy to forget when using `LocalSpecRepo`.
- **Match the existing custom code folder convention** — check if the package uses `Custom/`, `Customization/`, or `Customized/`.

## Safety Rules

### Autonomous Mode (Default)

During the build-fix loop (Phase 8), Copilot operates autonomously. These actions are **permitted without user confirmation**:

1. **Spec changes**: Adding `@@clientName`, `@@access`, `@@markAsPageable`, `@@alternateType`, and other decorators to `client.tsp` — these are safe, reversible, and csharp-scoped.
2. **Custom code**: Adding partial classes in the SDK custom code folder. Use `[CodeGenType]`/`[CodeGenSuppress]`/`[CodeGenMember]` only when needed (see Phase 5).
3. **Deleting `autorest.md`** after extracting directives — git history preserves it.
4. **Updating custom code** to reference new generated type names.
5. **Regenerating code** using `dotnet build /t:GenerateCode` or `RegenSdkLocal.ps1`.
6. **Updating CHANGELOG.md** and other metadata files.

### Actions Requiring User Confirmation

These actions **require explicit user approval** (use `ask_user`):

1. **Modifying spec `.tsp` files beyond `client.tsp`** — e.g., changing `main.tsp`, model definitions, or operation signatures. These affect all languages, not just C#.
2. **Generator code changes** that affect other SDKs — run `Generate.ps1` to verify scope first.
3. **Removing public API surface** with no backward-compat option (true breaking change).
4. **Adding `ApiCompatBaseline.txt` entries** — this should almost never be done.
5. **Deleting existing custom code files** — may lose manually-written logic.

### Hard Rules (Never Violate)

1. **Never edit files under `Generated/`** — they are overwritten by codegen.
2. **Never hand-edit `metadata.json`** — it is auto-generated.
3. **Never use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
4. **Never add entries to `ApiCompatBaseline.txt`** without explicit user approval.
5. **Never bump the major version** of a management SDK package.
6. **Preserve git history** — prefer renames over delete+create.
