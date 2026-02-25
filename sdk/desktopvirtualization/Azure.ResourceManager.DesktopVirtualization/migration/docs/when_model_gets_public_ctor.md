# When Does a Model Get a Public Constructor?

## Context (BREAKING #9)

When migrating from Swagger to TypeSpec, several resource Data types lost their
public constructors. The `@@usage(X, Usage.input, "csharp")` decorator was added
for all affected types, which successfully restored public ctors for 2 out of 5
types but **not** for the remaining 3:

| Type (C#) | TSP Definition | Public ctor after @@usage? |
|---|---|---|
| `MsixPackageData` | `ProxyResource<MSIXPackageProperties, false>` | **NO** |
| `ScalingPlanPersonalScheduleData` | `ProxyResource<..., false>` | **NO** |
| `ScalingPlanPooledScheduleData` | `ProxyResource<..., false>` | **NO** |
| `DesktopVirtualizationPrivateEndpointConnectionDataData` | `ProxyResource<...>` (no 2nd param) | YES |
| `DesktopVirtualizationPrivateLinkResourceData` | `extends CommonTypes.Resource` | YES |

## The Rule: Constructor Generation Decision Tree

The C# code generator uses the following logic to determine whether a resource
Data type gets a public constructor:

```
Is the model a TrackedResource<T>?
  └─ YES → Public ctor with (AzureLocation location, ...required writable sub-properties)
  └─ NO  → Is it a ProxyResource<T> or similar?
              └─ Is properties.optional == true? (i.e. no 2nd param, or 2nd param = true)
              │     └─ YES → Public parameterless ctor: `public TypeData() { }`
              │     └─ NO  → Is properties.flatten == true?
              │                └─ YES → Are there any required writable sub-properties?
              │                │         └─ YES → Public ctor with those params
              │                │         └─ NO  → ❌ NO PUBLIC CTOR (dead zone)
              │                └─ NO  → Public ctor takes whole Properties object
              └─ Is it `extends CommonTypes.Resource`?
                    └─ Treated as normal model → Public ctor based on Usage.input
```

## Key Factors

### 1. `ProxyResource<T, PropertiesOptional>` — the second template parameter

In TypeSpec ARM templates, `ProxyResource<T>` has an optional second boolean
parameter that defaults to `true`:

```typespec
model MSIXPackage is ProxyResource<MSIXPackageProperties, false>;
//                                                         ^^^^^ properties is REQUIRED

model Desktop is ProxyResource<DesktopProperties>;
//            no 2nd param → defaults to true → properties is OPTIONAL
```

- **`true` (default)**: The `properties` bag is optional → the generator can
  create a public **parameterless** constructor.
- **`false`**: The `properties` bag is required → the generator cannot create a
  parameterless constructor (the object would be invalid without properties).

### 2. Property Flattening (`flatten = true`)

When the properties bag is flattened (the default for most ARM resources), the
generator lifts individual sub-properties into the constructor signature instead
of taking the whole `Properties` object. This means the constructor parameters
come from **required writable sub-properties** within the properties model.

### 3. Required Writable Sub-Properties

A sub-property contributes to the constructor when:
- `optional = false` (required)
- `readOnly = false` (writable / not server-populated)

If there are zero such properties, and the properties bag is required + flattened,
the generator has **no valid constructor signature** to emit.

## The "Dead Zone"

The 3 types that lost their public constructors fall into this exact combination:

| Condition | Value | Why it blocks ctor |
|---|---|---|
| Base model | `ProxyResource` | No `location` param (unlike TrackedResource) |
| `properties.optional` | `false` | Can't be parameterless |
| `properties.flatten` | `true` | Can't take raw Properties object |
| Required writable sub-props | **0** | Nothing to put in ctor signature |

**Result**: The generator cannot produce any valid public constructor.

## Comparison: All Resource Data Types

| Type | TSP Base | props optional? | flatten? | Required writable sub-props | Public ctor? |
|---|---|---|---|---|---|
| `HostPoolData` | TrackedResource | false | true | 3 (`hostPoolType`, `loadBalancerType`, `preferredAppGroupType`) | ✅ `(location, 3 params)` |
| `ScalingPlanData` | TrackedResource | false | true | 1 (`timeZone`) | ✅ `(location, timeZone)` |
| `VirtualApplicationGroupData` | TrackedResource | false | true | 2 (`hostPoolId`, `applicationGroupType`) | ✅ `(location, 2 params)` |
| `VirtualWorkspaceData` | TrackedResource | false | true | 0 | ✅ `(location)` — TrackedResource always has location |
| `AppAttachPackageData` | TrackedResource | false | false | — (takes Properties obj) | ✅ `(location, properties)` |
| `VirtualDesktopData` | ProxyResource | **true** | true | 0 | ✅ `()` parameterless |
| `PrivateEndpointConnectionDataData` | ProxyResource | **true** | true | 0 | ✅ `()` parameterless |
| `VirtualApplicationData` | ProxyResource | false | true | 1 (`commandLineSetting`) | ✅ `(commandLineSetting)` |
| `SessionHostConfigurationData` | ProxyResource | false | **false** | — (takes Properties obj) | ✅ `(properties)` |
| **`MsixPackageData`** | **ProxyResource** | **false** | **true** | **0** | ❌ |
| **`ScalingPlanPersonalScheduleData`** | **ProxyResource** | **false** | **true** | **0** | ❌ |
| **`ScalingPlanPooledScheduleData`** | **ProxyResource** | **false** | **true** | **0** | ❌ |
| `PrivateLinkResourceData` | extends Resource | n/a | n/a | n/a | ✅ `()` — treated as normal model |
| `PrivateEndpointConnection` | extends Resource | n/a | n/a | n/a | ✅ `()` — treated as normal model |

## Fix Options

### Option A: Change `ProxyResource<T, false>` to `ProxyResource<T>` (make properties optional)

```typespec
// Before:
model MSIXPackage is ProxyResource<MSIXPackageProperties, false>;

// After:
model MSIXPackage is ProxyResource<MSIXPackageProperties>;
```

**Pros**: Generator will emit a public parameterless ctor.
**Cons**: Changes the API contract — properties bag becomes optional in the
OpenAPI spec. May not be acceptable if the service requires properties on
create/update.

### Option B: Add a required sub-property

If a sub-property in the Properties model is made `required` + writable,
the generator will include it in the public ctor. However, this may not be
semantically correct for these types.

### Option C: SDK customization (recommended for backward compat)

Add public parameterless constructors manually in `src/Customize/` partial
classes:

```csharp
// src/Customize/MsixPackageData.cs
public partial class MsixPackageData
{
    /// <summary> Initializes a new instance of <see cref="MsixPackageData"/>. </summary>
    public MsixPackageData()
    {
    }
}
```

**Pros**: No TSP/spec changes needed, purely additive.
**Cons**: Manual maintenance; ctor may create objects that fail server
validation if properties bag is truly required.

### Option D: Disable flattening for these resources

```typespec
// In client.tsp:
@@flattenProperty(MSIXPackage.properties, false, "csharp");
```

If supported, this would make the generator take the whole `Properties`
object in the ctor. But this changes the entire property access pattern
(users would access `data.Properties.DisplayName` instead of
`data.DisplayName`), which is itself a breaking change.

## Conclusion

The **`@@usage` decorator is necessary but not sufficient** for ProxyResource
types with `properties.optional = false`, `flatten = true`, and zero required
writable sub-properties. These types fall into a "dead zone" where the
generator has no valid public constructor signature to produce. The
recommended fix is **Option C** (SDK customization with manual public ctors).
