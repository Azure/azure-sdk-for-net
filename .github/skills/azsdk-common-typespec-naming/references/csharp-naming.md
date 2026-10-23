# C# ARM Member Naming

Load only for confirmed C# management SDK targets via the [naming dispatcher](naming-conventions.md), in either authoring or read-only review. These rules describe generated C# names, not REST wire names.

Sources: [.NET management naming conventions](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Mgmt-Naming-Conventions.md), [.NET management PR review skill](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/azure-sdk-mgmt-pr-review/SKILL.md), and [tracked linter rules](https://github.com/Azure/typespec-azure/issues/4442). The convention document is the primary naming guide; the review skill supplies additional contextual checks and accepted exceptions. Where guidance differs, preserve shipped API and resolve uncertainty rather than enforcing a mechanical rewrite.

Additional context: [naming review rules](https://github.com/Azure/azure-sdk-for-net/blob/8ce543a7602e7e3c8402fe808b9b376c1c3ea833/.github/skills/code-review/references/repository-rules.md#naming--review-only)
from [Azure/azure-sdk-for-net#62615](https://github.com/Azure/azure-sdk-for-net/pull/62615).
Apply these checks to the effective public SDK surface, not private implementation names.

## Emitter Defaults Before Overrides

Read the [C# HTTP client emitter automatic naming conversions](https://github.com/microsoft/typespec/blob/9457ed0a9874c04b5a72058b838a71923e5eb2c3/packages/http-client-csharp/generator/docs/naming-conventions.md) before reasoning about generated C# names or proposing `@clientName` overrides. Use that reference for built-in conversions and exceptions rather than treating the style rules below as transformations the emitter always performs.

Check applicability to the project's emitter version and generator/plugins; the reference describes the built-in `ScmCodeModelGenerator`. Account for existing handwritten customizations and the released contract. If applicable defaults already produce the intended name, do not add a redundant override. Automatic conversions do not replace semantic ARM naming checks.

An ordinary `@clientName` supplies an SDK name but does not disable subsequent C# conversions. If an exact spelling is required, consult the reference's exact-name limits and confirm installed TCGC support before recommending `exact(...)`. Exact names do not control every synthesized name, collision suffix, or derived declaration. Without generated API evidence, keep the effective name unverified.

## Properties and Parameters

| Applies to                | Guidance                                                                                      | Guardrails                                                                                                                                                       |
| ------------------------- | --------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Boolean                   | Start with a verb, normally `Is`, `Can`, or `Has`: `enabled` -> `IsEnabled`                   | Preserve meaningful existing verbs. The review skill also accepts `Does`, `Should`, `Allow`, `Enable`, `Disable`, `Use`, `Support`; do not produce `IsIsEnabled` |
| Date/time                 | Prefer `On`: `StartsOn`, `EndsOn`, `CreatedOn`                                                | Use active/passive voice appropriately. The review skill also accepts `At` for `DateTimeOffset`; do not churn an accepted name such as `CreatedAt`               |
| URI                       | Use `Uri`, not `Url`, for a confirmed URI concept: `callbackUrl` -> `CallbackUri`             | A name alone does not establish URI semantics. SDK type conversions are separate from this naming-only workflow                                                  |
| Integer interval/duration | Include the verified unit: `MonitoringIntervalInSeconds`                                      | Never infer seconds from an integer type or name alone. Do not append integer-unit suffixes to a `duration` scalar or an encoded duration value                  |
| Numeric TTL               | Use `TimeToLiveIn<Unit>` when the unit is verified: `ttl` in minutes -> `TimeToLiveInMinutes` | Confirm the unit from the contract/documentation; keep units and serialized values unchanged                                                                     |

Name checks depend on semantic types, not substrings alone. A string containing a timestamp-like name is not automatically a date/time property. A duration already carrying units must not receive another unit suffix.
For new, unshipped members with verified semantics, apply the matching rule
instead of returning only emitter-normalized casing such as `Enabled`,
`RetryInterval`, or `Ttl`.

## Operations

- Scope availability checks by resource/RP: `CheckWidgetNameAvailability`, `WidgetNameAvailabilityContent`, `WidgetNameAvailabilityResult`, and `WidgetNameUnavailableReason`.
- Coordinate related operation/model/enum names; avoid collisions with other resource providers' public API.
- Use the [model naming rules](csharp-model-naming.md) for request/response and PATCH bodies. Do not change HTTP verbs, requiredness, or serialization merely to satisfy a naming rule.

## Acronyms, Enums, and Related Names

- Longer acronyms use `Http`, `Tcp`, `Aes`.
- Two-letter acronyms such as `IP`, `OS`, and `DB` are uppercase where they are acronym components; retain the `Id` and `Vm` exceptions. Do not uppercase every matching pair of letters inside ordinary words.
- Prefer singular enum type names; plural names are for flags.
- Expand unclear acronyms only with verified service/domain meaning, not a guessed expansion.
- When expanding a verified abbreviation, check the entire affected type/member/parameter family, not just one declaration. For example, if `auth` is confirmed to mean authentication, coordinate `WidgetAuthDetails`, its sibling types, and the public properties and parameters using them.
- Keep parameter names consistent for the same concept across related operations and constructors. Numeric-suffixed collision artifacts or public `internal*` names require resolving the modeling or domain ambiguity, not inventing another spelling.

The initial support covers naming decisions only. Type conversions, operation removal, compatibility shims, and other non-naming review checks are not automatic consequences of this profile.
