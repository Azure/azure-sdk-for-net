# C# ARM Model Naming

Load with [C# member naming](csharp-naming.md) for confirmed C# management SDK targets in authoring or read-only review. Apply the [shared scope and compatibility safeguards](naming-conventions.md).

Sources: [.NET management naming conventions](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Mgmt-Naming-Conventions.md) and [.NET management PR review skill](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/azure-sdk-mgmt-pr-review/SKILL.md).

Additional context: [payload and options-bag naming rules](https://github.com/Azure/azure-sdk-for-net/blob/8ce543a7602e7e3c8402fe808b9b376c1c3ea833/.github/skills/code-review/references/repository-rules.md#naming--review-only)
from [Azure/azure-sdk-for-net#62615](https://github.com/Azure/azure-sdk-for-net/pull/62615).

## Body Role Before Suffix

Choose names from HTTP usage, not a global string replacement:

- Dedicated PATCH body model: `<Model>Patch`. A nested property model is not itself patched; when renaming a transport wrapper's suffix, use `Content`, not `Patch`.
- Dedicated PUT/POST transport wrapper: `<Model>Content`, or `<Model>Data` for actual resource data. An output-only transport wrapper uses `Result`.
- A reusable domain model does not acquire `Content` or `Result` merely because it appears in an input, output, or both. Preserve a descriptive domain noun such as `WidgetConnection`.
- Shared models used in incompatible roles need an explicit design decision. Do not pick a suffix from the first operation encountered or split a model without approval.
- Do not rename the literal TypeSpec body parameter to PascalCase just because the SDK body model needs a new name.

## Model Suffixes

| Existing suffix                      | Preferred name                           | Exception / context                                                                                                      |
| ------------------------------------ | ---------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ |
| `Parameter`, `Parameters`, `Request` | `Content`, or `Patch` for the PATCH body | Apply the HTTP-role rules above                                                                                          |
| `Response`                           | `Result`                                 | Confirm it represents a response                                                                                         |
| `Options`                            | `Config`                                 | Preserve `ClientOptions` types and genuine method options bags that aggregate parameters from multiple request locations |
| `Update`                             | `Patch` / `Content`                      | Contextual review guidance; use the actual body role                                                                     |
| `Definition`                         | Remove                                   | Keep if removal conflicts with another resource                                                                          |
| `Data`                               | Remove                                   | Keep for types deriving from `ResourceData` / `TrackedResourceData`                                                      |
| `Operation`                          | Remove or use a descriptive `Info` name  | Keep for `Operation` / `Operation<T>`; do not invent resource inheritance to justify `Data`                              |
| `Collection`                         | `Group` / `List` where meaningful        | Preserve domain terminology such as `MongoDBCollection` and emitter-generated `ArmCollection` resource collections       |

## Resources and Domain Context

- Remove a redundant service-model `Resource` suffix only if the remaining name is descriptive. Preserve established exceptions such as `GenericResource` and `PrivateLinkServiceResource`.
- For a resource-shaped model, use `Data` only when it is actually resource data; otherwise prefer a descriptive `Info` name. Inspect effective SDK inheritance rather than inferring it from the TypeSpec name.
- Do not include redundant `Resource` before `Data` or `Collection`: prefer `VirtualMachineData` and `VirtualMachineCollection`. Preserve `PrivateLinkResourceData` / `PrivateLinkResourceCollection`, where `PrivateLinkResource` is the ARM resource name.
- Distinguish a service model's suffix from the emitter's `ArmResource` wrapper and collection. Do not strip required generated wrapper suffixes or fabricate targets for synthesized types.
- Type names should be understandable without their namespace. Avoid generic/single-word names such as `Scope` or `EncryptionStatus`; use verified RP/resource context, e.g. `StorageAccountEncryptionStatus`. Do not apply this contextual-prefix rule to enum members.
- Avoid `Microsoft` / `Azure` prefixes and collisions with common ARM/.NET names. Reuse common ARM types where appropriate instead of redefining them. A genuinely service-specific wire variant needs domain context and an explanation.
- Check related resource/data/collection names together. If the domain prefix or replacement is uncertain, ask instead of inventing a name.
