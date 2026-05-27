---
name: mitigate-breaking-changes
description: Patterns and techniques for mitigating breaking changes during Azure management-plane SDK migration from Swagger/AutoRest to TypeSpec. Covers SDK-side customizations (partial classes, CodeGenType, CodeGenSuppress) and TypeSpec decorator customizations (clientName, access, markAsPageable, alternateType, hierarchyBuilding).
---
# Skill: mitigate-breaking-changes

Patterns and techniques for mitigating breaking changes when migrating or regenerating Azure management-plane .NET SDKs. Use these to preserve backward compatibility in the generated SDK surface.

## When Invoked

Trigger phrases: "mitigate breaking changes", "fix breaking change", "customization patterns", "how to keep backward compat", "CodeGenType", "CodeGenSuppress", "markAsPageable", "hierarchyBuilding", "base type change".

## SDK-Side Customizations (in SDK repo)

Use **Custom/*.cs** or **Customization/*.cs** partial classes (follow the package's existing structure) for .NET-side fixes.

### Partial class (add members, suppress generated members)
```csharp
// src/Custom/MyModel.cs (or src/Customization/MyModel.cs — follow the package's existing convention)
namespace Azure.ResourceManager.<Service>.Models
{
    public partial class MyModel
    {
        // Add computed properties, rename via [CodeGenMember], etc.
    }
}
```

### `[CodeGenType]` — Override accessibility or rename a generated type
When a generated type is `internal` and `@@access` in `client.tsp` doesn't work (common for nested/wrapper types), use `[CodeGenType]` in Custom code to make it public:

```csharp
// src/Custom/Models/MyPublicModel.cs
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.<Service>.Models
{
    [CodeGenType("OriginalTypeSpecModelName")]
    public partial class MyPublicModel
    {
    }
}
```

The `[CodeGenType("...")]` attribute takes the **original TypeSpec model name** (not the C# renamed name). This links the Custom partial class to the generated internal type and overrides its accessibility to `public`.

## TypeSpec Decorator Customizations (in spec repo)

These decorators are added to `client.tsp` in the spec repo.

```typespec
// Rename parameter
@@clientName(Operations.create::parameters.resource, "content");

// Rename path parameter
@@Azure.ResourceManager.Legacy.renamePathParameter(Resources.list, "fooName", "name");

// Mark a non-pageable list operation as pageable (returns Pageable<T> instead of Response<ListType>)
// Requires: using Azure.ClientGenerator.Core.Legacy;
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
@@markAsPageable(InterfaceName.operationName, "csharp");

// Suppress warning
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"
```

### When to use `@@markAsPageable`
When the old SDK returned `Pageable<T>` / `AsyncPageable<T>` for a list operation, but the TypeSpec spec defines the operation as non-pageable (returns a wrapper list type like `FooList`), use `@@markAsPageable` to make the generator produce pageable methods. This is **preferred over** writing custom `SinglePagePageable<T>` wrapper code because:
- It reduces custom code that must be maintained
- The generated pageable implementation handles diagnostics, cancellation, and error handling correctly
- It keeps the SDK surface consistent with other generated methods

**Do NOT use `@@markAsPageable` if the operation is already marked with `@list`** — the `@list` decorator already makes the operation pageable, and adding `@@markAsPageable` will cause a compile error. Check the spec's operation definition before adding the decorator.

**Requirements:**
1. Add `using Azure.ClientGenerator.Core.Legacy;` to the `client.tsp` imports
2. Add `#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "migration"` before each `@@markAsPageable` call
3. After adding the decorator, regenerate and remove any custom `[CodeGenSuppress]` + `SinglePagePageable` wrapper code

### `@@alternateType` Decorator
When the spec uses older common types that generate incorrect C# types (e.g., `string` instead of `ResourceIdentifier` for ID properties), use `@@alternateType`:
```typespec
@@alternateType(MyModel.resourceId, Azure.ResourceManager.CommonTypes.ArmResourceIdentifier, "csharp");
```

### `@@hierarchyBuilding` Decorator — Change a resource model's base type
When a TypeSpec resource model generates with the wrong base class (e.g., a plain `Resource` model instead of `TrackedResource` or `ProxyResource`), use `@@hierarchyBuilding` to override the base type. This is common when the spec defines a resource using a non-standard base type that doesn't map to the correct ARM SDK base class (`ResourceData`, `TrackedResourceData`, etc.).

**Syntax:**
```typespec
// Requires: using Azure.ClientGenerator.Core.Legacy;
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Change the base type back to <TargetBase> for backward compatibility"
@@Azure.ClientGenerator.Core.Legacy.hierarchyBuilding(MyResource,
  Azure.ResourceManager.Foundations.TrackedResource,
  "csharp"
);
```

**Common target base types:**
- `Azure.ResourceManager.Foundations.TrackedResource` — generates `TrackedResourceData` (for resources with location and tags)
- `Azure.ResourceManager.Foundations.ProxyResource` — generates `ResourceData` (for proxy/child resources)
- `Azure.ResourceManager.Foundations.Resource` — generates `ResourceData` (ARM resource base)

**When to use:**
- When the old SDK had `MyData : ResourceData` or `MyData : TrackedResourceData`, but the new TypeSpec-generated SDK produces `MyData : SomeOtherType` (e.g., a service-local `Resource` model)
- The `CannotRemoveBaseTypeOrInterface` API compatibility violation indicates this issue (e.g., _"Type 'X' does not inherit from base type 'Azure.ResourceManager.Models.ResourceData'"_)

**Requirements:**
1. Add `using Azure.ClientGenerator.Core.Legacy;` to the `client.tsp` imports
2. Add `#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "..."` before each `@@hierarchyBuilding` call
3. After adding the decorator, regenerate the SDK code

**Example** (from KeyVault migration):
```typespec
import "@azure-tools/typespec-client-generator-core";
using Azure.ClientGenerator.Core.Legacy;

// Fix Vault resource to generate VaultData : TrackedResourceData
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Change the base type back to TrackedResource for backward compatibility"
@@Azure.ClientGenerator.Core.Legacy.hierarchyBuilding(Vault,
  Azure.ResourceManager.Foundations.TrackedResource,
  "csharp"
);
```

## WirePathAttribute Breaking Changes [MPG only]

When the previous SDK version included `WirePathAttribute` on model properties (used by Azure.Provisioning libraries), migrating to TypeSpec may produce ApiCompat `CannotRemoveAttribute` errors for the missing attribute — because the emitter defaults to **not** generating it.

### How to detect

- ApiCompat `CannotRemoveAttribute` errors referencing `WirePathAttribute` on model properties
- These errors appear during `dotnet pack --no-restore` when the previous SDK release had `WirePathAttribute` on properties but the new generation does not

### Fix

Add `enable-wire-path-attribute: true` to the **mgmt emitter options** in `tspconfig.yaml` (in the spec repo):

```yaml
options:
  "@azure-typespec/http-client-csharp-mgmt":
    emitter-output-dir: "{output-dir}/{service-dir}/{namespace}"
    namespace: "Azure.ResourceManager.<Service>"
    enable-wire-path-attribute: true
```

Then regenerate the SDK.

**Avoid** attempting to fix this by creating `ApiCompatBaseline.txt` or disabling ApiCompat. The emitter option is the correct solution.

## Extension Resources

Extension resources (deployed onto parent resources from different providers) require special handling.

### Parameterized Scopes
When the same resource type can be deployed onto multiple parent types (e.g., VM, HCRP, VMSS), use `OverrideResourceName` with parameterized scopes. Each scope generates a separate SDK resource type. The generator may produce duplicate `GetXxxResource()` methods in `MockableArmClient` when multiple entries exist for the same resource — this is a known generator bug requiring deduplication.

### Sub-Resource Operations: Avoid `Read<>` / `Extension.Read<>` for Non-Lifecycle Ops
When a sub-resource operation (e.g., getting a report under an assignment) uses `Read<>` or `Extension.Read<>` templates, the ARM library treats it as a **lifecycle read** operation. This causes:
- The resource's `resourceType` and `resourceIdPattern` to be set to the sub-resource path
- Collections using the wrong REST client
- Compile errors: CS1729 (wrong constructor), CS0029 (type mismatch), CS1503 (wrong argument)

**Fix**: Change sub-resource Get operations from `Read<>` to `ActionSync<>` (or `Extension.ActionSync<>` for extension resources) with a `@get` decorator:
```typespec
// WRONG — ARM library treats this as lifecycle Read
reportGet is Ops.Read<Resource, Response = ArmResponse<Report>, ...>;

// CORRECT — ActionSync with @get avoids lifecycle misclassification
@get reportGet is Ops.ActionSync<Resource, void, Response = ArmResponse<Report>, ...>;
```
