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
- Never add ApiCompat baselines or disable ApiCompat/package validation, except targeted `WirePathAttribute` removal entries in the centralized baseline file.
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
6. Generate with saved inputs so `tspCodeModel.json` is preserved for hierarchy checks. `-Services` must be the exact package folder name, not service directory:
   ```pwsh
   pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services "Azure.ResourceManager.<Service>" -LocalSpecRepoPath <path> -SaveInputs
   ```
   Alternative from the package `src/` directory: `dotnet build /t:GenerateCode /p:SaveInputs=true`.
7. Build after first generation. Errors are expected; classify them in the build-fix loop.

## Resource Hierarchy Gate

Before the build-fix loop, compare the generated hierarchy with the previous GA SDK. The previous GA DLL is restored automatically by ApiCompat from `<ApiCompatVersion>`. Write JSON outputs to temp/package-local scratch and do not commit them.

```pwsh
$scripts = "eng/packages/http-client-csharp-mgmt/eng/scripts"
pwsh $scripts/Get-PreviousGaResourceHierarchy.ps1 -ProjectPath sdk/<svc>/Azure.ResourceManager.<Svc>/src -OutFile ga-hierarchy.json
pwsh $scripts/Get-ResourceHierarchyFromTspCodeModel.ps1 -TspCodeModelPath sdk/<svc>/Azure.ResourceManager.<Svc>/src -GeneratedDir sdk/<svc>/Azure.ResourceManager.<Svc>/src/Generated -OutFile new-hierarchy.json
pwsh $scripts/Compare-ResourceHierarchy.ps1 -GAJson ga-hierarchy.json -NewJson new-hierarchy.json
```

- Exit `0`: every GA resource exists in the new SDK with the same `ResourceType`, parent set, scope, and singleton flag; continue.
- Exit `1`: structural drift. Fix TypeSpec resource shape first (`@parentResource`, `@singleton`, scopes/templates). Do not enter ApiCompat mitigation yet.
- Exit `2`: class-name renames only. Continue, but record and handle during naming/API compatibility work.

For C# base-model/base-type compatibility, do **not** use `@@hierarchyBuilding`; use SDK custom code after the generated surface is stable.

## Build-Fix Loop

Repeat: build → classify → fix → regenerate if needed → rebuild.

Always verify zero Swagger diff after spec changes. Keep a running status list grouped by issue category so real migration breaks, compatibility shims, and generator bugs stay distinct.

Classify each issue before fixing:

| Category | Preferred action |
|---|---|
| Spec shape: names, types, paging, visibility, grouping | Fix in `client.tsp` with scoped decorators |
| SDK compatibility gap: missing/changed shipped API | Add minimal SDK shim only after root cause is known |
| Customization drift | Remove stale custom code; re-add only proven shims |
| Generated-code drift | Regenerate/export API; do not hand-edit generated files |
| Generator bug | Stop, minimize repro, file/link issue |

Common decorator fixes:

| Problem | Decorator |
|---|---|
| Wrong property type | `@@alternateType(Model.prop, targetType, "csharp")` |
| Wrong operation parameter type | `@@alternateType(Interface.op::parameters.param, targetType, "csharp")` |
| Wrong name | `@@clientName(target, "NewName", "csharp")` |
| Model should be input and output | `@@usage(Model, Usage.input, "csharp")`; decorator appends, so specify only the missing flag |
| Needs pageable return type | `@@markAsPageable(Interface.op, "csharp")` |
| Flatten properties envelope | `@@flattenProperty(Model.properties, "csharp")` |
| Operation name collision | `@@clientLocation(Interface.op, "GroupName", "csharp")` |

SDK custom code goes in the package's existing customization folder (`src/Custom/`, `src/Customization/`, or `src/Customized/`). Use MCP tools for deterministic edits when available, then hand-write only remaining shim logic. Useful MCP edits include `add_using_directive`, `remove_using_directive`, `regex_replacement`, `nullable_annotation_fix`, `rename_codegen_type`, and `add_codegen_suppress`. Regenerate when `CodeGen*` attributes change.

Every customization file or significant custom member needs a root-cause comment explaining what generated differently and why SDK-side customization is required. Avoid vague comments like "for backward compatibility". Obsolete custom members do not need a separate justification comment when the `[Obsolete]` message already clearly explains the reason and replacement.

Model factory compatibility overloads should translate renamed parameters or enum/value types, then delegate to generated public model-factory overloads. Do not construct generated models through internal constructors, internal `Properties` bags, or private `Core` helpers just to preserve an old factory signature. First look for a public generated factory overload or public model surface that can receive the same values.

SDK-side fix patterns when decorators cannot help:

| Problem | Fix |
|---|---|
| Base model/base type changed | Add a custom partial model declaring the intended base model; use `[CodeGenType]` only when the custom type name differs from the generated/TypeSpec name, then regenerate. Do not use `@@hierarchyBuilding`. |
| Flattened properties lost on a polymorphic type | Shim properties delegating to the `Properties` bag |
| Protected constructor missing on a discriminated base | Add a `protected` constructor in the partial class |
| Property lost due to `@@alternateType` model swap | Add the property in a partial class |

## Breaking Changes And New APIs

1. Export API: `pwsh eng/scripts/Export-API.ps1 <service>`.
2. Diff against the previous stable API surface from `ApiCompatVersion` / latest stable package tag. Use `origin/main` only if it matches that baseline.
3. Fix each break using the same classify-first loop, then regenerate/export API/re-diff until clean. Never suppress with an ApiCompat baseline except for `WirePathAttribute` removal diffs.

For every new public API, classify it before keeping it:

| Category | Action |
|---|---|
| Real service/API-version addition | Keep and note source API version in PR status |
| Rename of existing shipped API | Prefer `@@clientName`; otherwise suppress/add minimal shim. Do not keep both names without approval |
| Generator convenience/drift | Investigate operation id, route, resource type, and prior API before keeping |

Compare each new member against the previous GA public API listing or restored ApiCompat assembly, operation id and request path in generated XML docs/source, resource type/parent hierarchy, and the TypeSpec or Swagger API version where the operation/model first appears. If a new API is actually a rename of an existing API, fix the rename instead of documenting it as additive.

## Generator Bugs

If generated code is structurally wrong after stale customizations are removed, stop and report a generator bug. Create a minimum TypeSpec repro, document any approved workaround in `client.tsp` or SDK custom code with an issue link, and pause migration if no safe workaround exists.

## Finalize

1. Review locally with `mpg-migration-pr-review` rules.
2. Ensure `CHANGELOG.md` has a short migration note and `ci.mgmt.yml` exists if needed.
3. Format TypeSpec before opening the spec PR.
4. Push spec changes to a fork and open draft spec PR titled `Add csharp customizations for <Service> migration`.
5. Update `tsp-location.yaml` to point to the fork spec commit, then push SDK changes to a fork and open draft SDK PR titled `[Mgmt] <PackageName>: Migrate to TypeSpec`.
6. Keep the SDK PR description as the status tracker: current phase, blockers, remaining breaks. If pausing before a draft PR exists, create one and use its description as the tracker.
7. Before final SDK review, point `tsp-location.yaml` to the final spec commit, regenerate once without `LocalSpecRepoPath`, run `pre-commit-checks`, and verify build.

## Done When

- Build is clean.
- ApiCompat is clean without baselines, except approved `WirePathAttribute` removal entries.
- New APIs are triaged.
- Required PR/status/review steps are complete.
- `tsp-location.yaml` points to the final spec commit.
