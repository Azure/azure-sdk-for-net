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
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "RBAC roles for provisioning"
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

## `resource-name`

Customizes the **resource name** (the SDK class name root used for the generated `<Name>Resource` / `<Name>Collection` C# types) of an ARM resource.

This is useful in two cases:

1. **Plain rename.** The auto-derived class name (from the resource model name) is not what you want in the SDK. Anchoring on the Read operation rather than the model lets you target a single resource path even when the same model backs multiple paths.
2. **Expandable `{parentType}` resources.** When a single resource definition uses a `{parentType}` segment whose value comes from an enum, the emitter materializes one resource per enum value. The default name is `Capitalize(singular(enumValue)) + <ModelName>`, which is often verbose or awkward. The map form lets you set a custom name per expanded resource.

**Target:** The ARM resource's Read operation (e.g. `MyResources.get`). The Read operation is the natural identity anchor for a resource — it disambiguates multi-path same-model resources and, for expandable resources, is the single operation that fans out into multiple resources.

**Value:**

| Form                              | When to use                                                                                             |
| --------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `string`                          | Plain rename (one Read op → one resource). Also covers multi-path same-model resources, since each path has its own distinct Read op. |
| `Record<enumValue, string>`       | Expandable `{parentType}` resource (one Read op → N resources). Keys are the union/enum values that get substituted for the `{parentType}` segment; values are the desired class-name roots. |

**Example — plain rename:**

```typespec
#suppress "@azure-tools/typespec-client-generator-core/client-option" "Rename SDK class"
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "Rename SDK class"
@@clientOption(RecordSets.get, "resource-name", "DnsRecordSet", "csharp");
```

**Example — expandable resource:**

```typespec
union PrivateEndpointConnectionParentType {
  string,
  topics: "topics",
  domains: "domains",
}

@armResourceOperations(#{ allowStaticRoutes: true })
interface PrivateEndpointConnections {
  @get
  @route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{name}")
  get is /* ... */;
}

#suppress "@azure-tools/typespec-client-generator-core/client-option" "Customize expanded resource names"
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "Customize expanded resource names"
@@clientOption(PrivateEndpointConnections.get,
  "resource-name",
  #{
    topics: "EventGridTopicPrivateEndpointConnection",
    domains: "EventGridDomainPrivateEndpointConnection",
  },
  "csharp"
);
```

**Effect:** The override is applied as a final, name-only transformation after expansion, parent inference, and post-processing. It only changes the `resourceName` field of the resource metadata, so it affects the generated SDK class names (`<Name>Resource`, `<Name>Collection`, mockable extensions, etc.) without renaming the underlying model or changing the schema in any other way.

**Diagnostics:** The emitter reports warnings for:

- a plain `string` value on a Read operation that produces multiple resources (use the map form instead);
- map entries whose keys do not match any enum value produced by expanding this Read operation (catches typos and stale entries);
- resource-name collisions introduced by the override.

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

The C# generator only honors decorators scoped to `"csharp"` (or with no scope, which TCGC treats as "all languages"); decorators explicitly scoped to another language (e.g. `"java"`, `"python"`) are ignored.

## Notes

- All `@@clientOption` decorators require `#suppress` directives for the `client-option` and `client-option-requires-scope` diagnostics until the TCGC issue [Azure/typespec-azure#4104](https://github.com/Azure/typespec-azure/issues/4104) is resolved.
- The `resource-rbac-roles` and `resource-name-constraint` keys are read during resource detection in the emitter and serialized into the `armProviderSchema` decorator on the code model. The C# generator then deserializes them to drive code generation.
- The `disable-safe-flatten` key is propagated by TCGC onto the input model's `Decorators` collection. The C# generator reads it directly when deciding whether to apply safe-flatten.
