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

1. **Check for `migration-status.md`** in the package directory. If it exists, read it and resume from the recorded phase — skip completed work.
2. Sync both repos to latest `main`.
3. Update `tsp-location.yaml`: set `emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`.
4. Generate: `dotnet build /t:GenerateCode` in `src/`, or `RegenSdkLocal.ps1 -Services "<Service>" -LocalSpecRepoPath <path>`.
5. Build — expect errors, proceed to Phase 2.

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
| **Customization drift** | Existing custom code no longer compiles after regeneration because generated symbols moved or changed shape | Update or re-home the customization, then rebuild |
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

Use concise PR titles:
- Spec PR: `Add csharp customizations for <Service> migration`
- SDK PR: `[Mgmt] <PackageName>: Migrate to TypeSpec`

## Generator Bugs

1. If the generated code is structurally wrong after removing stale customizations, stop and report it as a generator bug.
2. Create an issue with a minimum TypeSpec repro.
3. Document any approved workaround in `client.tsp` or SDK custom code and link the issue.
4. If no safe workaround exists, pause migration until the fix is merged.

## Pausing & Resuming

When pausing, save `sdk/<service>/Azure.ResourceManager.<Service>/migration-status.md`:

```markdown
## Phase 2 — Fix Build Errors
Blocked: [#58138](https://github.com/Azure/azure-sdk-for-net/issues/58138) — CollectionResultOfT name collision
Remaining breaks: ApplicationPatch base type change, model factory signatures
```

Keep it minimal — just current phase, blockers, and unfinished work. On resume, read this file first. Delete when migration merges.

## Done When

- `dotnet build` is clean
- ApiCompat issues are mitigated without baselines
- required review/validation steps are complete
- `tsp-location.yaml` points to the final spec commit used by the PR
