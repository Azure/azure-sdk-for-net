---
title: 'Supported @@clientOption keys'
---

# Supported `@@clientOption` Keys

The Azure management-plane C# emitter recognizes several `@@clientOption` keys that allow spec authors to provide additional metadata for resource code generation. These options use the TCGC [`@@clientOption`](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/reference/decorators/#@clientOption) decorator and are scoped to `"csharp"`.

## `resource-rbac-roles`

Defines RBAC (Role-Based Access Control) role definitions for a resource. Used by the provisioning generator to emit `BuiltInRole` structs and `CreateRoleAssignment` methods.

**Target:** ARM resource model (e.g., `Vault`, `ManagedCluster`)

**Value:** A record mapping role names (PascalCase) to role GUIDs.

**Example:**

```typespec
#suppress "@azure-tools/typespec-client-generator-core/client-option" "RBAC roles for provisioning"
@@clientOption(Vault,
  "resource-rbac-roles",
  #{
    KeyVaultAdministrator: "00482a5a-887f-4fb3-b363-3b7fe8e74483",
    KeyVaultContributor: "f25e0fa2-a7c8-4377-a976-54943a77a395",
    KeyVaultReader: "21090545-7ca7-4776-b22c-e363652d74d2",
  },
  "csharp"
);
```

**Effect:** The provisioning generator produces:

- A `{Service}BuiltInRole` struct with static properties for each role.
- `CreateRoleAssignment` methods on the resource class.

## `resource-name-constraint`

Overrides or supplements the resource name constraints (min length, max length, and valid character pattern) for a resource. This is useful when the spec's `name` property does not carry `@pattern`, `@minLength`, or `@maxLength` decorators — for example, when adding those decorators to the spec would cause breaking changes in the generated swagger.

The emitter first reads constraints from the resource model's `name` property decorators, then applies any overrides from this `@@clientOption`. Individual fields can be omitted to keep the original value.

**Target:** ARM resource model (e.g., `Vault`, `ManagedHsm`, `Secret`)

**Value:** A record with optional fields:

| Field       | Type     | Description                                              |
| ----------- | -------- | -------------------------------------------------------- |
| `minLength` | `int32`  | Minimum number of characters allowed in the resource name |
| `maxLength` | `int32`  | Maximum number of characters allowed in the resource name |
| `pattern`   | `string` | A regex pattern describing valid resource name characters |

**Example:**

```typespec
#suppress "@azure-tools/typespec-client-generator-core/client-option" "Name constraints for provisioning"
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "Name constraints for provisioning"
@@clientOption(Vault,
  "resource-name-constraint",
  #{
    minLength: 3,
    maxLength: 24,
    pattern: "^[a-zA-Z][a-zA-Z0-9-]+[a-zA-Z0-9]$",
  },
  "csharp"
);
```

**Effect:** The provisioning generator produces a `GetResourceNameRequirements()` override on the resource class:

```csharp
public override ResourceNameRequirements GetResourceNameRequirements()
    => new ResourceNameRequirements(3, 24,
        ResourceNameCharacters.LowercaseLetters
        | ResourceNameCharacters.UppercaseLetters
        | ResourceNameCharacters.Numbers
        | ResourceNameCharacters.Hyphen);
```

The `pattern` string is parsed to determine which `ResourceNameCharacters` flags to include. Character classes (`[a-z]`, `[A-Z]`, `[0-9]`, `-`, `_`, `.`, `()`) are extracted from the regex and tested against representative characters.

## `disable-safe-flatten`

Opts a model out of the C# generator's *safe-flatten* transform. By default, when a parent model has a property whose type is another model that contains exactly one public, non-discriminator, non-obsolete property, the generator lifts that single inner property up onto the parent and removes the inner type. Setting `disable-safe-flatten` to `true` on the inner model preserves it as a public type and keeps the parent's property pointing at it.

Use this when the inner model is part of the public API surface that consumers already depend on (for example, when migrating from AutoRest where `safe-flatten: false` was used in `readme.md` directives), or when future spec changes are likely to add more properties to the inner model and you do not want the public surface to change.

**Target:** Any input model that would otherwise be safe-flattened (e.g. `AllInstancesDown`, `UserInitiatedRedeploy`).

**Value:** Boolean `true`. Any other value — including the string `"true"`, `1`, `false`, or omission — is ignored and the model will still be safe-flattened.

**Example:**

```typespec
#suppress "@azure-tools/typespec-client-generator-core/client-option" "Preserve type for public API surface"
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "Preserve type for public API surface"
@@clientOption(AllInstancesDown, "disable-safe-flatten", true, "csharp");
```

**Effect:** The C# generator skips the safe-flatten step for the targeted model wherever it appears as a single-property inner type. The model is emitted as a regular public type, and the parent property continues to expose it directly (i.e. `parent.AllInstancesDown.AutomaticallyApprove` rather than `parent.AutomaticallyApprove`).

**Scope:** Inner-model. One decorator covers every parent that uses the model. There is no per-call-site granularity.

## Notes

- All `@@clientOption` decorators require `#suppress` directives for the `client-option` and `client-option-requires-scope` diagnostics until the TCGC issue [Azure/typespec-azure#4104](https://github.com/Azure/typespec-azure/issues/4104) is resolved.
- The `resource-rbac-roles` and `resource-name-constraint` keys are read during resource detection in the emitter and serialized into the `armProviderSchema` decorator on the code model. The C# generator then deserializes them to drive code generation.
- The `disable-safe-flatten` key is propagated by TCGC onto the input model's `Decorators` collection. The C# generator reads it directly when deciding whether to apply safe-flatten.
