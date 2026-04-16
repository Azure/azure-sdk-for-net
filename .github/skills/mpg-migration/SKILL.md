---
name: mpg-migration
description: Migrate Azure SDK for .NET management-plane libraries from AutoRest/Swagger to TypeSpec. Use when asked to do an MPG migration or move from Swagger to TypeSpec.
---

# MPG Migration Workflow

Migrate an Azure SDK for .NET management library from AutoRest/Swagger to TypeSpec.

## When to Use

Use this skill only for **management-plane** packages named like `Azure.ResourceManager.*`.

Typical triggers:
- "mpg migration"
- "mgmt migration"
- "migrate Azure.ResourceManager.<Service> to TypeSpec"

## Prerequisites

- **SDK repo**: Package at `sdk/<service>/Azure.ResourceManager.<Service>/`
- **Spec repo**: Sibling `../azure-rest-api-specs` with TypeSpec for this service. Ask user for path if not found.
- **Branches**: `<service>-mpg-migration` in both repos, branched off `main`

## Guardrails

1. **Never edit `src/Generated/` or `metadata.json` by hand.**
2. **Never add `ApiCompatBaseline.txt` entries or disable ApiCompat/package validation.**
3. **Prefer spec-side decorators first**: `@@clientName`, `@@access`, `@@alternateType`, `@@markAsPageable`.
4. **Use SDK customizations only** for backward-compat shims or when decorators cannot express the fix.

## Phase 1 — Setup & First Generation

1. **Check for `migration-status.md`** in the package directory. If it exists, read it and resume from the recorded phase — skip completed work.
2. Sync both repos to latest `main`.
3. Update `tsp-location.yaml`: set `emitterPackageJsonPath: eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json`.
4. Generate: `dotnet build /t:GenerateCode` in `src/`, or `RegenSdkLocal.ps1 -Services "<Service>" -LocalSpecRepoPath <path>`.
5. Build — expect errors, proceed to Phase 2.

## Phase 2 — Build-Fix Loop

Fix errors **spec-side** (decorators in `client.tsp` with `"csharp"` scope) or **SDK-side** (custom code in `src/Customization/`). Always verify zero swagger diff after spec changes.

After each fix: regenerate if spec changed → rebuild → check remaining errors → repeat until clean.

### Spec-side decorator table

| Problem | Decorator |
|---------|-----------|
| Wrong property type | `@@alternateType(Model.prop, targetType, "csharp")` |
| Wrong name | `@@clientName(target, "NewName", "csharp")` |
| Type should be public | `@@access(Model, Access.public, "csharp")` |
| Constructor should be protected | `@@usage(Model, Usage.input \| Usage.output, "csharp")` |
| Needs pageable return type | `@@markAsPageable(Interface.op, "csharp")` |
| Flatten properties envelope | `@@flattenProperty(Model.properties, "csharp")` |
| Change base type | `@@hierarchyBuilding(Model, TargetBase, "csharp")` |
| Unwanted ARM resource type from operation | Convert `LegacyOperations.Read` to plain inline operation |
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
3. Fix each break using the tables from Phase 2 — **never** suppress with `ApiCompatBaseline.txt`.

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
