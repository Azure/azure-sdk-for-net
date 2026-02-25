# ProxyResource<T, false> with flattened properties and no required writable sub-properties generates no public constructor

## Generator

`@azure-typespec/http-client-csharp-mgmt` version `1.0.0-alpha.20260210.5`

## Description

When a TypeSpec ARM resource is defined as `ProxyResource<T, false>` (properties bag is **required**), property flattening is enabled (default), and the properties model has **no required writable sub-properties**, the C# mgmt generator fails to emit any public constructor for the resulting `*Data` class — even when `@@usage(X, Usage.input, "csharp")` is applied.

This creates a breaking change for SDK migrations from Swagger to TypeSpec, because the old Swagger-generated code had public parameterless constructors for these types.

## Repro

### TypeSpec definition

```typespec
model MSIXPackage
  is Azure.ResourceManager.ProxyResource<MSIXPackageProperties, false> {
  ...ResourceNameParameter<Resource = MSIXPackage, KeyName = "msixPackageFullName", SegmentName = "msixPackages">;
}

// All sub-properties in MSIXPackageProperties are optional
model MSIXPackageProperties {
  imagePath?: string;
  packageName?: string;
  packageFamilyName?: string;
  displayName?: string;
  // ... (all optional)
}
```

```typespec
// In client.tsp — attempt to make it input-capable:
@@usage(MSIXPackage, Usage.input, "csharp");
```

### Generated C# (actual)

```csharp
public partial class MsixPackageData : ResourceData
{
    // Only internal ctor — no public constructor!
    internal MsixPackageData(ResourceIdentifier id, string name, ResourceType resourceType,
        SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties,
        MSIXPackageProperties properties) : base(id, name, resourceType, systemData) { ... }
}
```

### Expected C#

```csharp
public partial class MsixPackageData : ResourceData
{
    // Public parameterless ctor should be generated
    public MsixPackageData() { }

    internal MsixPackageData(ResourceIdentifier id, ...) : base(...) { ... }
}
```

## Root Cause Analysis

The generator's constructor generation logic for resource Data types works as follows:

| Resource type | properties optional? | flatten? | Required writable sub-props | Ctor generated |
|---|---|---|---|---|
| `TrackedResource<T>` | N/A | true | any | ✅ `(AzureLocation location, ...requiredProps)` |
| `ProxyResource<T>` (default, optional=true) | **true** | true | 0 | ✅ `()` parameterless |
| `ProxyResource<T, false>` | **false** | true | ≥1 | ✅ `(requiredProps...)` |
| **`ProxyResource<T, false>`** | **false** | **true** | **0** | **❌ No ctor** |
| `ProxyResource<T, false>` | false | **false** | any | ✅ `(Properties propertiesObj)` |

The problematic case is row 4: when properties is required (`false`), flattening lifts individual sub-properties into the constructor signature, but there are zero required writable sub-properties to lift. The generator ends up with no valid constructor signature:

- Can't be parameterless → the `properties` bag is required, an empty object would be invalid
- Can't take the `Properties` bag as a parameter → it's flattened away (internal)
- Can't take required sub-properties → there are none

This creates a **"dead zone"** where no public constructor can be produced.

## Evidence from the Same SDK

The following types from `Azure.ResourceManager.DesktopVirtualization` demonstrate the pattern:

### Types that **fail** (no public ctor)

| C# Type | TSP Definition | properties optional | flatten | Required writable sub-props |
|---|---|---|---|---|
| `MsixPackageData` | `ProxyResource<MSIXPackageProperties, false>` | false | true | 0 |
| `ScalingPlanPersonalScheduleData` | `ProxyResource<..., false>` | false | true | 0 |
| `ScalingPlanPooledScheduleData` | `ProxyResource<..., false>` | false | true | 0 |

All three have `@@usage(X, Usage.input, "csharp")` applied. The `tspCodeModel.json` shows `"usage": "Input,Output,Json"` for all of them — the usage decorator works, but the generator still does not emit a public ctor.

### Types that **succeed** (have public ctor) — same SDK

| C# Type | TSP Definition | Why ctor exists |
|---|---|---|
| `VirtualDesktopData` | `ProxyResource<DesktopProperties>` (no 2nd param → optional=true) | Parameterless ctor: properties bag is optional |
| `VirtualApplicationData` | `ProxyResource<ApplicationProperties, false>` | Ctor with `commandLineSetting`: there IS a required writable sub-property |
| `HostPoolData` | `TrackedResource<HostPoolProperties>` | TrackedResource always gets ctor with `location` |
| `DesktopVirtualizationPrivateEndpointConnectionDataData` | `ProxyResource<PrivateEndpointConnectionProperties>` (no 2nd param) | Parameterless ctor: properties bag is optional |

## Suggested Fix

When a `ProxyResource<T, false>` has:
- `properties.optional = false`
- `properties.flatten = true`
- Zero required writable sub-properties in the flattened properties model
- Usage includes `Input`

The generator should emit a **public parameterless constructor** that initializes the internal `Properties` object to a default instance:

```csharp
public MsixPackageData()
{
    Properties = new MSIXPackageProperties();
}
```

This is consistent with what Swagger/AutoRest generated and allows users to create instances and populate optional properties before passing to create/update operations.

## Current Workaround

Add public parameterless constructors manually via SDK customization (`src/Customize/` partial classes):

```csharp
// src/Customize/MsixPackageData.cs
namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class MsixPackageData
    {
        public MsixPackageData()
        {
        }
    }
}
```

## Affected Types (this SDK)

- `MsixPackageData`
- `ScalingPlanPersonalScheduleData`
- `ScalingPlanPooledScheduleData`

This pattern likely affects other Azure SDKs migrating from Swagger to TypeSpec that use `ProxyResource<T, false>` with all-optional properties.
