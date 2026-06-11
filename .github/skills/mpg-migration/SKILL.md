---
name: mpg-migration
description: Handles Azure SDK for .NET management-plane migrations from AutoRest/Swagger to TypeSpec; use for MPG, mgmt migration, or Azure.ResourceManager.* migration requests.
---

# MPG Migration Workflow

Use for Azure SDK for .NET management-plane migrations from AutoRest/Swagger to TypeSpec for packages named `Azure.ResourceManager.*`.

## Inputs

- SDK package path: `sdk/<service>/Azure.ResourceManager.<Service>/`
- Local `azure-rest-api-specs` path if not at `../azure-rest-api-specs`
- Branches in both repos, normally `<service>-mpg-migration` from `main`

## Non-Negotiables

- Never hand-edit `src/Generated/` or `metadata.json`.
- Never add `ApiCompatBaseline.txt` entries or disable ApiCompat/package validation.
- Prefer `client.tsp` decorators with `"csharp"` scope before SDK custom code.
- Root-cause every ApiCompat/API diff before adding custom code.
- SDK custom code is only for backward compatibility or cases decorators cannot express.
- Do not overwrite dirty user work in either repo.

Ask the user only when the spec repo path is missing, a fix requires files beyond `client.tsp`, or a generator bug has no safe workaround.

## Setup

1. If resuming, read the draft SDK PR description first and continue from its phase/blockers.
2. Check `git status` in SDK and spec repos, then sync both to latest `main` without disturbing unrelated dirty files.
3. Fresh migration only: inventory and remove old SDK custom code (`src/Custom/`, `src/Customization/`, `src/Customized/`, hand-written partials, old shims) before first generation. Re-add only proven-needed compatibility shims later.
4. Remove AutoRest config: delete `<IncludeAutorestDependency>true</IncludeAutorestDependency>` and remove/replace `src/autorest.md`.
5. Set `tsp-location.yaml` to `emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`.
6. Generate with saved inputs. `-Services` must be the exact package folder name, not service directory:
   ```pwsh
   pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services "Azure.ResourceManager.<Service>" -LocalSpecRepoPath <path> -SaveInputs
   ```

## Resource Hierarchy Gate

Before the build-fix loop, compare the generated hierarchy with the previous GA SDK. Write JSON outputs to temp/package-local scratch and do not commit them.

```pwsh
$scripts = "eng/packages/http-client-csharp-mgmt/eng/scripts"
pwsh $scripts/Get-PreviousGaResourceHierarchy.ps1 -ProjectPath sdk/<svc>/Azure.ResourceManager.<Svc>/src -OutFile ga-hierarchy.json
pwsh $scripts/Get-ResourceHierarchyFromTspCodeModel.ps1 -TspCodeModelPath sdk/<svc>/Azure.ResourceManager.<Svc>/src -GeneratedDir sdk/<svc>/Azure.ResourceManager.<Svc>/src/Generated -OutFile new-hierarchy.json
pwsh $scripts/Compare-ResourceHierarchy.ps1 -GAJson ga-hierarchy.json -NewJson new-hierarchy.json
```

- Exit `0`: continue.
- Exit `1`: structural drift. Fix TypeSpec resource shape first (`@parentResource`, `@singleton`, scopes/templates). Do not enter ApiCompat mitigation yet.
- Exit `2`: class-name renames only. Continue, but record and handle during naming/API compatibility work.

For C# base-model/base-type compatibility, do **not** use `@@hierarchyBuilding`; use SDK custom code after the generated surface is stable.

## Build-Fix Loop

Repeat: build → classify → fix → regenerate if needed → rebuild.

Classify each issue before fixing:

| Category | Preferred action |
|---|---|
| Spec shape: names, types, paging, visibility, grouping | Fix in `client.tsp` with scoped decorators |
| SDK compatibility gap: missing/changed shipped API | Add minimal SDK shim only after root cause is known |
| Customization drift | Remove stale custom code; re-add only proven shims |
| Generated-code drift | Regenerate/export API; do not hand-edit generated files |
| Generator bug | Stop, minimize repro, file/link issue |

Common decorators: `@@clientName`, `@@alternateType`, `@@usage`, `@@markAsPageable`, `@@flattenProperty`, `@@clientLocation`.

SDK custom code goes in the package's existing customization folder (`src/Custom/`, `src/Customization/`, or `src/Customized/`). Use MCP tools for deterministic edits when available, then hand-write only remaining shim logic.

Every customization file or significant custom member needs a root-cause comment explaining what generated differently and why SDK-side customization is required. Avoid vague comments like "for backward compatibility".

Model factory compatibility overloads should delegate to generated public model-factory overloads. Do not construct generated models through internal constructors or private `Core` helpers just to preserve an old factory signature.

## Breaking Changes And New APIs

1. Export API: `pwsh eng/scripts/Export-API.ps1 <service>`.
2. Diff against the previous stable API surface from `ApiCompatVersion` / latest stable package tag. Use `origin/main` only if it matches that baseline.
3. Fix each break using the same classify-first loop. Never suppress with `ApiCompatBaseline.txt`.

For every new public API, classify it before keeping it:

| Category | Action |
|---|---|
| Real service/API-version addition | Keep and note source API version in PR status |
| Rename of existing shipped API | Prefer `@@clientName`; otherwise suppress/add minimal shim. Do not keep both names without approval |
| Generator convenience/drift | Investigate operation id, route, resource type, and prior API before keeping |

## Finalize

1. Review locally with `mpg-migration-pr-review` rules.
2. Ensure `CHANGELOG.md` has a short migration note and `ci.mgmt.yml` exists if needed.
3. Format TypeSpec before opening the spec PR.
4. Draft spec PR title: `Add csharp customizations for <Service> migration`.
5. Draft SDK PR title: `[Mgmt] <PackageName>: Migrate to TypeSpec`.
6. Keep the SDK PR description as the status tracker: current phase, blockers, remaining breaks.
7. Before final SDK review, point `tsp-location.yaml` to the final spec commit, regenerate once without `LocalSpecRepoPath`, run `pre-commit-checks`, and verify build.

## Done When

- Build is clean.
- ApiCompat is clean without baselines.
- New APIs are triaged.
- Required PR/status/review steps are complete.
- `tsp-location.yaml` points to the final spec commit.
