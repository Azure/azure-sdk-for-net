# C# ARM Member Naming

Load only for confirmed C# management SDK targets via the [naming dispatcher](naming-conventions.md), in either authoring or read-only review. These rules describe generated C# names, not REST wire names.

Sources: [.NET management naming conventions](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Mgmt-Naming-Conventions.md), [.NET management PR review skill](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/azure-sdk-mgmt-pr-review/SKILL.md), and [tracked linter rules](https://github.com/Azure/typespec-azure/issues/4442). The convention document is the primary naming guide; the review skill supplies additional contextual checks and accepted exceptions. Where guidance differs, preserve shipped API and resolve uncertainty rather than enforcing a mechanical rewrite.

## Properties and Parameters

| Applies to                | Guidance                                                                    | Guardrails                                                                                                                                                       |
| ------------------------- | --------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Boolean                   | Start with a verb, normally `Is`, `Can`, or `Has`: `enabled` -> `IsEnabled` | Preserve meaningful existing verbs. The review skill also accepts `Does`, `Should`, `Allow`, `Enable`, `Disable`, `Use`, `Support`; do not produce `IsIsEnabled` |
| Date/time                 | Prefer `On`: `StartOn`, `EndOn`, `CreatedOn`                                | Use active/passive voice appropriately. The review skill also accepts `At` for `DateTimeOffset`; do not churn an accepted name such as `CreatedAt`               |
| Integer interval/duration | Include the verified unit: `MonitoringIntervalInSeconds`                    | Never infer seconds from an integer type or name alone. Do not append integer-unit suffixes to a `duration` scalar or an encoded duration value                  |
| Numeric TTL               | Prefer `TimeToLiveIn<Unit>`, e.g. `TimeToLiveInMinutes`                     | Confirm the unit from the contract/documentation; keep units and serialized values unchanged                                                                     |

Name checks depend on semantic types, not substrings alone. A string containing a timestamp-like name is not automatically a date/time property. A duration already carrying units must not receive another unit suffix.

## Operations

- Scope availability checks by resource/RP: `CheckWidgetNameAvailability`, `WidgetNameAvailabilityContent`, `WidgetNameAvailabilityResult`, and `WidgetNameUnavailableReason`.
- Coordinate related operation/model/enum names; avoid collisions with other resource providers' public API.
- Use the [model naming rules](csharp-model-naming.md) for request/response and PATCH bodies. Do not change HTTP verbs, requiredness, or serialization merely to satisfy a naming rule.

## Casing and Enums

- Use PascalCase for C# public types/properties/methods and normal C# parameter casing. Longer acronyms use `Http`, `Tcp`, `Aes`.
- Two-letter acronyms such as `IP`, `OS`, and `DB` are uppercase where they are acronym components; retain the `Id` and `Vm` exceptions. Do not uppercase every matching pair of letters inside ordinary words.
- Prefer singular enum type names; plural names are for flags.
- Numeric version enum members use underscores, e.g. `Tls1_0`. Preserve the wire value. Check the installed TCGC/emitter's exact-name support when ordinary `clientName` normalization cannot preserve the requested spelling; do not assume a new helper exists in an older project.
- When both support [TCGC `exact`](https://github.com/Azure/typespec-azure/blob/main/packages/typespec-client-generator-core/lib/functions.tsp), propose a scoped override such as `@@clientName(WidgetTlsVersion.tls10, exact("Tls1_0"), "csharp");`. If support is absent or unconfirmed, block the override and report the missing capability/evidence; do not substitute a normalized name, change the wire value, or upgrade dependencies.
- Expand unclear acronyms only with verified service/domain meaning, not a guessed expansion.

The initial support covers naming decisions only. Type conversions, operation removal, compatibility shims, and other non-naming review checks are not automatic consequences of this profile.
