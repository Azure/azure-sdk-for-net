# Custom code attributes

The provisioning generator inherits the base C# generator custom code attributes, such as `CodeGenTypeAttribute`, `CodeGenMemberAttribute`, and `CodeGenSuppressAttribute`. Refer to the base C# generator custom-code attribute documentation for those shared attributes.

This document only covers provisioning-specific attributes.

## `CodeGenEnumValueAttribute`

Use assembly-level `[CodeGenEnumValue(enumName, memberName, value)]` attributes when a provisioning enum needs to preserve a previously shipped public API surface.

This is useful during TypeSpec migrations when generated enum output changes in ways that would otherwise break ApiCompat:

- a new generated enum member is inserted before existing members, shifting C# implicit integer values;
- a previously shipped enum member no longer exists in the generated TypeSpec output, but must remain in the SDK for compatibility;
- a compatibility enum member needs a serialized wire name that differs from its C# member name.

### Preserve enum ordinals when new values are inserted

The provisioning generator emits explicit integer values for every enum member. Members without custom values receive the smallest unused ordinal. This means reserving an ordinal for a newly inserted member does not shift later generated members.

For example, suppose the previous SDK shipped:

```csharp
public enum SampleKind
{
    A = 0,
    B = 1,
    C = 2
}
```

If newer TypeSpec generates:

```csharp
public enum SampleKind
{
    A,
    Z,
    B,
    C
}
```

Add one customization for the inserted member:

```csharp
using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("SampleKind", "Z", 3)]
```

The generator emits:

```csharp
public enum SampleKind
{
    A = 0,
    Z = 3,
    B = 1,
    C = 2
}
```

### Append a compatibility member

If `memberName` does not match any generated enum member, the generator appends that member to the enum.

```csharp
using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("SampleKind", "LegacyKind", 4)]
```

The generator emits:

```csharp
public enum SampleKind
{
    A = 0,
    B = 1,
    C = 2,
    LegacyKind = 4
}
```

### Set a wire name for an appended member

Use the optional `WireName` property when the appended compatibility member should serialize with a different wire value.

```csharp
using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("SampleKind", "LegacyKind", 4, WireName = "legacy-kind")]
```

The generator emits:

```csharp
public enum SampleKind
{
    A = 0,
    B = 1,
    C = 2,

    [DataMember(Name = "legacy-kind")]
    LegacyKind = 4
}
```

### Parameters

| Parameter | Description |
| --- | --- |
| `enumName` | Generated C# enum type name. |
| `memberName` | Generated or compatibility C# enum member name. |
| `value` | Explicit integer value to emit for the enum member. |
| `WireName` | Optional settable property. When provided and different from `memberName`, emits `[DataMember(Name = "...")]`. |

The generator fails fast if two `CodeGenEnumValue` attributes target the same enum member or assign the same explicit ordinal within the same enum.
