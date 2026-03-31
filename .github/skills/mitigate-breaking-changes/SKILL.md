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

## Emitter Configuration Options (in spec repo `tspconfig.yaml`)

### `enable-wire-path-attribute: true` — Preserve WirePathAttribute for ApiCompat

When migrating from AutoRest to TypeSpec, the old generated code had `[WirePath("...")]` attributes on model properties. By default, the TypeSpec C# mgmt emitter does **not** emit these attributes, causing hundreds of ApiCompat `CannotRemoveAttribute` errors:

```
CannotRemoveAttribute : Attribute 'Azure.ResourceManager.Hci.WirePathAttribute' exists on '...' in the contract but not the implementation.
```

**Fix**: Add `enable-wire-path-attribute: true` to the C# mgmt emitter options in `tspconfig.yaml`:

```yaml
"@azure-typespec/http-client-csharp-mgmt":
  namespace: "Azure.ResourceManager.<Service>"
  emitter-output-dir: "{output-dir}/sdk/<service>/{namespace}"
  enable-wire-path-attribute: true
```

This tells the emitter to generate `[WirePath("...")]` attributes on properties, matching the old AutoRest output and eliminating the `CannotRemoveAttribute` ApiCompat errors.

**When to use**: Always use this during migration from AutoRest to TypeSpec when the existing SDK has `ApiCompatVersion` set (i.e., there is a prior GA or beta release with WirePath attributes). Check the old `api/*.cs` files for `[WirePath(...)]` attributes — if present, this option is needed.

## Property Type Changes (Same Name, Different Type)

When a property's **type** changes between AutoRest and TypeSpec generations (e.g., `BinaryData` → `ArcConnectivityProperties`, `ResourceIdentifier` → `string`), C# does not allow two properties with the same name but different types. This causes `MembersMustExist` API compat errors that cannot be fixed by simply adding a property in Custom code.

### Solution: Rename + Custom Property Pattern

Use a **two-step approach**:

1. **In TypeSpec `client.tsp`**: Rename the new property to a different name using `@@clientName`
2. **In SDK Custom code**: Add the original property name with the old type, delegating to the renamed property

#### Step 1: TypeSpec Customization (spec repo)

```typespec
// client.tsp
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

// Rename the property to free up the original name for backward-compat
@@clientName(ArcSettingProperties.connectivityProperties, "ArcConnectivityProperties", "csharp");
@@clientName(RemoteSupportNodeSettings.arcResourceId, "ArcResourceIdString", "csharp");
```

#### Step 2: SDK Customization (SDK repo)

```csharp
// src/Custom/ArcSettingData.cs
using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci
{
    public partial class ArcSettingData
    {
        /// <summary> Connectivity properties for Arc agents. </summary>
        [Obsolete("This property is deprecated. Use ArcConnectivityProperties instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData ConnectivityProperties
        {
            get => ArcConnectivityProperties?.ToSerializedData();
            set
            {
                // Parse BinaryData to typed object if needed
                if (value != null)
                {
                    ArcConnectivityProperties = value.ToObjectFromJson<ArcConnectivityProperties>();
                }
            }
        }
    }
}
```

```csharp
// src/Custom/RemoteSupportNodeSettings.cs
using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class RemoteSupportNodeSettings
    {
        /// <summary> The Arc resource ID. </summary>
        [Obsolete("This property is deprecated. Use ArcResourceIdString instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ArcResourceId
        {
            get => string.IsNullOrEmpty(ArcResourceIdString) ? null : new ResourceIdentifier(ArcResourceIdString);
        }
    }
}
```

### Common Type Conversions

| Old Type | New Type | Conversion Pattern |
|----------|----------|-------------------|
| `BinaryData` | Typed model | `value.ToObjectFromJson<T>()` / `BinaryData.FromObjectAsJson(obj)` |
| `ResourceIdentifier` | `string` | `new ResourceIdentifier(str)` / `resourceId.ToString()` |
| `IList<ResourceIdentifier>` | `IList<string>` | LINQ `.Select()` with conversion |
| `ExtensionInstanceViewStatus` | `ArcExtensionInstanceViewStatus` | Create new instance copying properties |

### When Properties Are Removed

If a property was **removed entirely** (not just renamed/retyped), you cannot add it back with custom code because there's no underlying data. In this case:
1. Check if the property moved to a nested object — if so, delegate to the nested path
2. If truly removed from the API, this is a **service-level breaking change** that must be documented in CHANGELOG

### Regeneration Required

After adding `@@clientName` decorators in `client.tsp`:
1. Regenerate the SDK: `dotnet build /t:GenerateCode`
2. Verify the property was renamed in generated code
3. Add the backward-compat property in Custom code
4. Build and run `dotnet pack` to verify API compat passes
