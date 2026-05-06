---
name: mpg-migration
description: Handles Azure SDK for .NET management-plane migrations from AutoRest/Swagger to TypeSpec; use for MPG, mgmt migration, or Azure.ResourceManager.* migration requests.
---

# MPG Migration Workflow

Migrate an Azure SDK for .NET management library from AutoRest/Swagger to TypeSpec.

## When to Use

Use this skill only for **management-plane** packages named like `Azure.ResourceManager.*`.

Typical triggers:
- "mpg migration"
- "mgmt migration"
- "migrate Azure.ResourceManager.<Service> to TypeSpec"

## Required Input

- SDK package path under `sdk/<service>/Azure.ResourceManager.<Service>/`
- Local `azure-rest-api-specs` repo path if it is not present at `../azure-rest-api-specs`

## Prerequisites

- **SDK repo**: Package at `sdk/<service>/Azure.ResourceManager.<Service>/`
- **Spec repo**: Sibling `../azure-rest-api-specs` with TypeSpec for this service. Ask user for path if not found.
- **Branches**: `<service>-mpg-migration` in both repos, branched off `main`

## Guardrails

1. **Never edit `src/Generated/` or `metadata.json` by hand.**
2. **Never add `ApiCompatBaseline.txt` entries or disable ApiCompat/package validation.**
3. **Prefer spec-side decorators first**: `@@clientName`, `@@access`, `@@alternateType`, `@@markAsPageable`.
4. **Use MCP tools first for deterministic custom-code edits**; hand-edit only the remaining shim logic.
5. **Use SDK customizations only** for backward-compat shims or when decorators cannot express the fix.

## Default Autonomy

Proceed autonomously through the normal generate/build/fix loop. Ask the user only when:
- the spec repo path is missing or ambiguous
- the fix requires changes beyond `client.tsp`
- the issue is a generator bug with no safe workaround

## Phase 1 — Setup & First Generation

1. If resuming and a draft PR already exists, **read the current PR description** first and continue from the recorded phase/blockers.
2. Sync both repos to latest `main`.
3. **Fresh migration only / before the very first generation**: remove existing SDK custom code that predates the migration (`src/Custom/`, `src/Customization/`, `src/Customized/`, hand-written partials, backward-compat shims) so stale customizations do not hide real migration problems. When resuming, preserve minimal compatibility shims that were intentionally reintroduced during earlier migration work.
4. Do **not** spend time porting old custom code during the initial build-fix loop. Only add back the pieces that are still required, and do that later during breaking-change mitigation.
5. Update `tsp-location.yaml`: set `emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`.
6. Generate with `SaveInputs=true` so `tspCodeModel.json` is preserved for the next step: `pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/RegenSdkLocal.ps1 -Services "<Service>" -LocalSpecRepoPath <path> -SaveInputs` (or `dotnet build /t:GenerateCode /p:SaveInputs=true` in `src/`).
7. **Verify resource-hierarchy parity with the previous GA SDK** before entering the build-fix loop. The previous GA DLL is restored automatically by ApiCompat from `<ApiCompatVersion>` in the .csproj.
   ```pwsh
   $scripts = "eng/packages/http-client-csharp-mgmt/eng/scripts"
   pwsh $scripts/Get-PreviousGaResourceHierarchy.ps1   -ProjectPath sdk/<svc>/Azure.ResourceManager.<Svc>/src -OutFile ga-hierarchy.json
   pwsh $scripts/Get-ResourceHierarchyFromTspCodeModel.ps1 -TspCodeModelPath sdk/<svc>/Azure.ResourceManager.<Svc>/src -GeneratedDir sdk/<svc>/Azure.ResourceManager.<Svc>/src/Generated -OutFile new-hierarchy.json
   pwsh $scripts/Compare-ResourceHierarchy.ps1 -GAJson ga-hierarchy.json -NewJson new-hierarchy.json
   ```
   Verification semantics — every GA resource must exist in the new SDK with the same `ResourceType`, parent set, scope, and singleton flag. Class-name renames are reported but not blocking.
   - Exit `0` → hierarchy matches; continue.
   - Exit `1` → **structural drift** (missing resource / parent / scope / singleton flip). Block and fix spec-side first (typespec-azure decorators such as `@parentResource`, `@singleton`, `@@hierarchyBuilding`, scope-defining templates) **before** entering the Phase 2 build-fix loop, otherwise downstream ApiCompat work will compound.
   - Exit `2` → **class-name renames only**, structural hierarchy is intact. Non-blocking; record the renames in the migration status and address them during Phase 2 alongside other surface-level fixes.
8. Build — expect errors, proceed to Phase 2.

## Phase 2 — Build-Fix Loop

Fix errors **spec-side** (decorators in `client.tsp` with `"csharp"` scope) or **SDK-side** (custom code in `src/Customization/`). Always verify zero swagger diff after spec changes.

After each fix: regenerate if spec changed → rebuild → check remaining errors → repeat until clean.
Apply this same classify-first loop to both **compile/build errors** and **breaking-change remediation** from ApiCompat/API diff review.

Before fixing an issue, **categorize it first** so the mitigation goes to the right layer and we do not paper over the real cause.

### Categorize build errors and breaking changes

| Category | Typical symptoms | Preferred fix |
|---------|-------------------|---------------|
| **Spec-shape issue** | Wrong names, types, visibility, paging shape, inheritance, or operation grouping | Fix in `client.tsp` using decorators first |
| **SDK compatibility gap** | ApiCompat failures such as missing types/members, signature changes, or lost convenience entry points | Add targeted compatibility shims in SDK custom code |
| **Customization drift** | Old handwritten code conflicts with the new generated surface or masks the real migration issue | Remove it first; only reintroduce a minimal shim if Phase 3 proves it is still needed |
| **Generated-code drift** | `Verify Generated Code` or local regen changes files after a clean build | Regenerate, export API, and commit the produced output |
| **Generator bug** | Emitted code is structurally wrong and cannot be safely corrected with decorators or normal customizations | Stop, minimize the repro, and file a generator issue |

During the loop, keep a running list of remaining issues grouped by category. This makes it clear which items are real migration breaks, which are compatibility shims, and which must be fixed in the generator.

For **SDK-side custom code**, prefer MCP tools for deterministic edits:
- `add_using_directive` / `remove_using_directive`
- `regex_replacement`
- `nullable_annotation_fix`
- `rename_codegen_type`
- `add_codegen_suppress`

Use them in a loop: **build/classify → batch MCP fixes → regenerate if `CodeGen*` attributes changed → hand-write only the remaining compatibility logic**. Use this same loop again in Phase 3 when mitigating breaking changes; do not treat ApiCompat work as a separate ad hoc cleanup step.

Treat deleted custom code as **suspect by default**. Re-add only the smallest compatibility layer required to preserve the shipped API or behavior after the generated surface has stabilized.

### Spec-side decorator table

| Problem | Decorator |
|---------|-----------|
| Wrong property type | `@@alternateType(Model.prop, targetType, "csharp")` |
| Wrong name | `@@clientName(target, "NewName", "csharp")` |
| Type should be public | `@@access(Model, Access.public, "csharp")` |
| Model should be input and output | `@@usage(Model, Usage.input \| Usage.output, "csharp")` |
| Needs pageable return type | `@@markAsPageable(Interface.op, "csharp")` |
| Flatten properties envelope | `@@flattenProperty(Model.properties, "csharp")` |
| Change base type | `@@hierarchyBuilding(Model, TargetBase, "csharp")` |
| Wrong operation parameter type | `@@alternateType(Interface.op::parameters.param, targetType, "csharp")` |
| Operation name collision | `@@clientLocation(Interface.op, "GroupName", "csharp")` |

### SDK-side customization (when decorators can't help)

Every file needs a justification comment.

| Problem | Fix |
|---------|-----|
| Flattened properties lost (polymorphic type) | Shim properties delegating to `Properties` bag |
| Protected constructor missing (discriminated base) | `protected` ctor in partial class |
| Property lost due to `@@alternateType` model swap | Add property in partial class |

## Phase 3 — Mitigate Breaking Changes

1. Export API: `pwsh eng/scripts/Export-API.ps1 <service>`
2. Diff with `origin/main` API file.
3. Categorize each break (shape issue vs compatibility gap vs generator bug), then fix it using the same **build/classify → fix → regenerate/export API → re-diff** loop from Phase 2 — **never** suppress with `ApiCompatBaseline.txt`.

## Phase 4 — Self-Review

Review changes against the `mpg-migration-pr-review` skill rules locally — check customization quality rules and decorator preference rules. Fix issues before proceeding.

Before opening the SDK PR:
- Ensure `CHANGELOG.md` has a short migration note.
- Ensure `ci.mgmt.yml` exists if the package does not already have one.

## Phase 5 — Create PRs

1. Run the `pre-commit-checks` skill on the SDK package.
2. Push spec to fork → draft PR against `Azure/azure-rest-api-specs`.
3. Update `tsp-location.yaml` to point to fork commit.
4. Push SDK to fork → draft PR against `Azure/azure-sdk-for-net`.
5. Keep the **SDK PR description** updated with the current migration phase, blockers, and remaining breaking-change items; use it as the migration status tracker instead of creating a separate status file.

Use concise PR titles:
- Spec PR: `Add csharp customizations for <Service> migration`
- SDK PR: `[Mgmt] <PackageName>: Migrate to TypeSpec`

## Generator Bugs

1. If the generated code is structurally wrong after removing stale customizations, stop and report it as a generator bug.
2. Create an issue with a minimum TypeSpec repro.
3. Document any approved workaround in `client.tsp` or SDK custom code and link the issue.
4. If no safe workaround exists, pause migration until the fix is merged.

## Pausing & Resuming

When pausing, update the **draft SDK PR description** with the current state. If no draft PR exists yet, create one at that point and use its description as the tracker going forward:

```markdown
## Phase 2 — Fix Build Errors
Blocked: [#58138](https://github.com/Azure/azure-sdk-for-net/issues/58138) — CollectionResultOfT name collision
Remaining breaks: ApplicationPatch base type change, model factory signatures
```

Keep it minimal — just current phase, blockers, and unfinished work. On resume, read the PR description first.

## Done When

- `dotnet build` is clean
- ApiCompat issues are mitigated without baselines
- required review/validation steps are complete
- `tsp-location.yaml` points to the final spec commit used by the PR
