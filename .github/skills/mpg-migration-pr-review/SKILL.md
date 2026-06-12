---
name: mpg-migration-pr-review
description: Review Azure SDK management-plane migration PRs (Swagger/AutoRest -> TypeSpec). Checks customization quality, TypeSpec decorator usage, and migration-specific anti-patterns on top of the standard mgmt PR review.
---

# Azure .NET Mgmt SDK Migration PR Review

Review Azure SDK for .NET management-library migration PRs from Swagger/AutoRest to TypeSpec. This skill extends `azure-sdk-mgmt-pr-review`; run its Phases 1-3 first, then run these migration phases.

Use this skill for migration PRs indicated by titles like `Migrate to TypeSpec` / `MPG migration`, adding `tsp-location.yaml`, deleting `src/autorest.md`, adding TypeSpec `metadata.json`, or broadly regenerating `src/Generated/`. Do not use it for normal TypeSpec-based management feature PRs unless they change migration shape or mitigation code.

Phases:
1. Versioning Review - base skill.
2. API Review - base skill.
3. Breaking Change Detection - base skill.
4. Migration Customization Review.
5. TypeSpec Decorator Preference Review.
6. Migration New API Triage.

Migration notes for base phases:
- Phase 2: migration often introduces generic C# names such as `Scope`, `GroupScope`, `Sensitivity`, `ManagedRuleSetException`; flag contextual naming issues and prefer `@@clientName(..., "csharp")` when defined in TypeSpec.
- Phase 3: migration breaking changes are expected but still must be mitigated. `ApiCompatBaseline.txt` entries remain forbidden.

## Phase 4: Migration Customization Review

Review added/modified files under `src/Custom*/`, `src/Customization*/`, or `src/Customized*/`. Comment on source/customization/TypeSpec lines in the PR diff; never target `api/*.cs` inline. Treat issues as blocking when they risk incorrect API shape, broken compatibility, generated-code drift, or unmaintainable migration debt; minor cleanup can be a suggestion.

Rules:
- **4.1 Justification comments**: each customization file or significant block must explain why it exists: breaking-change mitigation, generator bug with issue link, naming fix, backward compatibility, etc.
- **4.2 `[CodeGenMember]` vs `[CodeGenSuppress]`**: use `[CodeGenMember("GeneratedName")]` for same-data renames so generator metadata, serialization, and samples remain linked. Use `[CodeGenSuppress("MemberName", ...)]` only when removing/suppressing a generated member or rewriting different behavior.
- **4.3 Redundant `[CodeGenType]`**: only use `[CodeGenType("SpecName")]` when the custom class name differs from the generated/spec type name.
- **4.4 `EditorBrowsable(Never)` misuse**: only hide backward-compat members that have replacements. Never hide the only public constructor, method, or property for its purpose.
- **4.5 Rename, don't hide-and-replace**: when generated names differ from shipped SDK names, rename the generated API back to the shipped name instead of exposing both old and new names. Use `@@clientName(..., "csharp")` when the target is defined in TypeSpec. If synthesized by C# generator and not directly defined in TypeSpec, use the smallest SDK customization, e.g. `[CodeGenType]` for type rename or `[CodeGenMember]` for member rename. A custom old-name method that only forwards to a new generated method usually means the generated method should be renamed back.
- **4.6 ModelFactory anti-patterns**: do not suppress generated ModelFactory methods without strong justification. Backward-compat overloads should delegate to generated public ModelFactory overloads and translate renamed parameters/types as needed; do not call internal constructors or private `Core` helpers. Add only overloads that existed in the previous stable API.
- **4.7 Constructor suppression**: if a generated constructor has the wrong signature, first fix root cause in `client.tsp`: missing flattened properties -> `@@flattenProperty`; wrong property type -> `@@alternateType`; missing `Properties` envelope members -> flatten the envelope. Review every constructor `[CodeGenSuppress]` for a possible decorator fix.
- **4.8 Using cleanup**: flag customization-file diffs that only add/remove unnecessary `using` statements.
- **4.9 Obsolete compatibility members**: determine why `[Obsolete]` exists. A backward-compat shim preserving shipped API should remain functional when it can safely delegate to the replacement; do not require `NotSupportedException` for safe shims. Require `NotSupportedException` only when old behavior cannot be implemented safely/accurately or is intentionally unsupported, and ensure obsolete/exception messages point to the replacement or explain why none exists.
- **4.10 No manual edits to generated files - blocking**: `src/Generated/` must be generator output only. A large regenerated diff is expected and not evidence of hand editing. Flag clear hand edits such as isolated generated-style mismatches, custom logic, ad hoc `#pragma` suppressions, type changes, or CI `Verify Generated Code`/code-check drift. Fix through custom partials (`[CodeGenSuppress]`), TypeSpec decorators (`@@clientName`, `@@alternateType`, `@@access`), or generator bug fixes. After adding custom files with generator attributes, regenerate so suppressions are honored.

Compact examples:
- Bad rename: `[CodeGenSuppress("Tls1_0")]` plus custom `Tls10` member.
- Good rename: `[CodeGenMember("Tls1_0")] public static RedisTlsVersion Tls10 { get; } = ...;`.
- Bad ModelFactory compatibility: private helper calling internal generated constructors.
- Good ModelFactory compatibility: compatibility overload delegates to `ArmRedisModelFactory.RedisData(...)`.
- Bad generated edit: changing `src/Generated/Models/SomeModel.cs` by hand.
- Good generated fix: suppress in `src/Custom/SomeModel.cs`, provide custom member, then regenerate.

## Phase 5: TypeSpec Decorator Preference Review

Prefer TypeSpec decorators over SDK custom code when they can express the fix. Decorators are easier to maintain, keep migration behavior centralized in TypeSpec/customization inputs, and reduce custom code.

Always include the `"csharp"` scope parameter for decorators in `azure-rest-api-specs`; unscoped decorators affect other language emitters.

Common replacements:
- Manual wrapper properties for an unflattened `Properties` envelope -> `@@flattenProperty(Model.properties, "csharp")`.
- Manual property type conversion (`string` -> `ResourceIdentifier`, `AzureLocation`, etc.) plus custom serialization -> `@@alternateType(Model.prop, TargetType, "csharp")`.
- Custom pageable wrappers for old `Pageable<T>` / `AsyncPageable<T>` shape -> `@@markAsPageable(Interface.operation, "csharp")`, with `#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"` when needed.
- Public accessibility for an internal generated type -> try `@@access(Type, Access.public, "csharp")` before `[CodeGenType]`; fall back only when `@@access` is ineffective, such as nested/wrapper generated types.

When suggesting a decorator, include a scoped example and target the relevant `client.tsp`/TypeSpec line when in the diff.

## Phase 6: Migration New API Triage

Migration PRs can show many additive public APIs after regeneration. Classify each meaningful new type/member from the API diff before accepting it.

1. Compare PR API against previous GA API from `ApiCompatVersion` when available.
2. For each meaningful new public API, classify it:

| Category | Identify by | Review action |
|----------|-------------|---------------|
| Real service/API-version addition | Exists only in newer TypeSpec input/API version; no equivalent in previous GA swagger/API surface | Keep; mention significant additions in summary. |
| Rename of existing API | Same operation id, route, resource type, model semantics, or member semantics as previous GA API | Request changes: restore shipped name/shape with `@@clientName`, other decorators, or minimal SDK shim. |
| Generator convenience/drift | New overload/grouping/resource method/pageable/collection method appears because MPG grouped or named the same REST operation differently | Investigate; if duplicate semantics, request rename/compatibility fix. |

Use operation IDs, generated XML docs, request paths, resource type/parent hierarchy, and previous GA API listings to distinguish real additions from renamed existing APIs. Do not keep both old and new names unless there is an approved deliberate reason.

## Output Format

Follow base skill output rules: one PR review, safe-output tools in GitHub Agentic Workflow mode, no direct GitHub writes from agentic workflows, no execution of untrusted PR code, and no inline comments on `api/*.cs`.

Each migration inline comment should start with a rule ID such as `**[4.1]**`, `**[4.10]**`, or `**[5.2]**`, explain the violation, and suggest the fix. Put unattachable findings in `Non-inline findings`.

Review body must include:
- Phase 1-3 results from the base skill.
- Phase 4 customization result, grouped by 4.1-4.10.
- Phase 5 decorator-preference result.
- Phase 6 new API triage result, including accepted real additions and flagged rename/drift counts.
- Final counts for critical issues, should-fix issues, and suggestions.
