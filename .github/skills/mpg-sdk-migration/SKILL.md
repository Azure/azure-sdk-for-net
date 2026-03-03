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
     pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 <PACKAGE_NAME>
     ```
   - **Both spec and generator changed** — regenerate with both local:
     ```powershell
     pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 <PACKAGE_NAME> -LocalSpecRepoPath <full-path-to-azure-rest-api-specs>
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

Apply naming rules from the `azure-sdk-pr-review` skill. For detailed customization techniques, invoke the `mitigate-breaking-changes` skill.

Key approaches:
- **SDK-side**: Partial classes under `Custom/` or `Customization/` with `[CodeGenType]`, `[CodeGenSuppress]`, `[CodeGenMember]`
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

For each build error, determine the root cause and look up the fix in [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md). The error reference contains:
- **Root cause triage table** — how to classify errors as spec, generator, or customization issues
- **Common build error patterns** — CS0234, CS0051, CS0246, AZC0030, etc. with specific fixes
- **ApiCompat error patterns** — MembersMustExist, TypesMustExist, etc.

### Step 3 — Fix Based on Root Cause

For each error, apply the fix locally and regenerate. **The iteration loop continues until `dotnet build` passes with zero errors.** All three fix types (spec, generator, customization) can be combined in a single iteration — use `LocalSpecRepo` and `RegenSdkLocal.ps1` to avoid pushing to remote during the loop.

#### If TypeSpec issue (including naming/accessibility):
1. Update `client.tsp` (or other `.tsp` files) in the local spec repo.
2. Regenerate using the local spec repo:
   ```powershell
   dotnet build /t:GenerateCode /p:LocalSpecRepo=<full-path-to-azure-rest-api-specs>
   ```
3. Rebuild with `dotnet build` and verify the error is resolved.

#### If generator bug/gap:
1. Fix the generator code under `eng/packages/http-client-csharp-mgmt/`.
2. Regenerate with the local generator (and optionally local spec):
   ```powershell
   # Generator-only fix
   pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME>
   # Generator + spec fixes together
   pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services <PACKAGE_NAME> -LocalSpecRepoPath <full-path-to-azure-rest-api-specs>
   ```
3. Rebuild and confirm the error is resolved.
4. Create a feature branch for the generator fix and open a **draft PR** for it.
5. Continue migration work on top of that branch.

#### If customization needed:
1. Add a partial class under `src/Customization/` to address the issue.
2. Rebuild and confirm (no regeneration needed).

### Step 4 — Iterate Until Build Succeeds

**Exit condition: `dotnet build` passes with zero errors.**

After fixing one error, rebuild and update the error list. Each fix may resolve multiple cascading errors or reveal new ones. Repeat until the build is clean. Update the SQL tracking table as you go:

```sql
UPDATE build_errors SET status = 'fixed', root_cause = 'generator' WHERE id = 'err-1';
```

**After the loop completes (build succeeds):**
Proceed to **Phase 9 — Create Pull Requests** to push changes and create separate PRs.

### Sub-Agent Strategy for Error Triage

This loop is best handled **sequentially** with a mix of agent types:

1. **task agent** — Run `dotnet build`, collect errors, populate the SQL table.
2. **For each error** (sequential — each fix may change subsequent errors):
   - **explore agent** — Investigate the error: read the generated file, compare with spec, determine root cause.
   - **general-purpose agent** — Apply the fix (spec change, generator fix, or customization). Include full context: error message, file path, root cause, and relevant spec/generated code.
   - **task agent** — Regenerate (if spec/generator fix) and rebuild to verify.
3. **task agent** — Final full build + test to confirm all errors resolved.

> **Why sequential?** Each fix can resolve multiple errors or introduce new ones. Parallel fixing would cause conflicts and wasted work.

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

## Phase 10 — Retrospective: Update Skill Files

After completing (or making significant progress on) a migration, review what was learned and update the skill files:

1. **New error patterns**: Add to [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md).
2. **New decorators or TypeSpec patterns**: Add to the `mitigate-breaking-changes` skill.
3. **New workarounds or pitfalls**: Add to [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md) Common Pitfalls section.
4. **Migration flow changes**: Update this file (SKILL.md).

> **Goal**: Each migration should leave these skill files slightly better than they were before.

## Common Pitfalls

See [error-reference.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/mpg-sdk-migration/error-reference.md) for the full list of common pitfalls. Key ones to remember during the migration flow:

- **Do NOT use `tsp-client update`** — use `dotnet build /t:GenerateCode`.
- **Do NOT blindly copy all renames from `autorest.md`** — the mgmt emitter handles many automatically.
- **Build errors cascade** — fix one at a time, rebuild, and re-assess.
- **Finalize `tsp-location.yaml` before creating the PR** — easy to forget when using `LocalSpecRepo`.

## Safety Rules

1. **Never modify spec files** without explicit user confirmation.
2. **Delete `autorest.md`** after extracting directives — git history preserves it.
3. **Never edit files under `Generated/`** — they are overwritten by codegen.
4. **Always ask** before making destructive changes (deleting files, removing code).
5. **Preserve git history** — prefer renames over delete+create.
