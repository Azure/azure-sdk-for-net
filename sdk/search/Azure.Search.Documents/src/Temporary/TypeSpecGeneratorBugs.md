# TypeSpec C# Generator Bugs

This document tracks bugs encountered during the Azure.Search.Documents TypeSpec migration.

---

## Bug 1: Missing Extension Methods for Extensible Enums in Collections

### Description
The TypeSpec C# generator produces serialization code that calls `ToSerialString()` and `To<EnumName>()` extension methods for extensible enum types (readonly structs with string backing), but these extension methods are never generated.

### Reproduction
When generating code for `CjkBigramTokenFilterScripts` (an extensible enum defined as a `readonly partial struct`), the generated serialization file `CjkBigramTokenFilter.Serialization.cs` contains:

```csharp
// Line 46 - serialization
writer.WriteStringValue(item.ToSerialString());

// Line 107 - deserialization  
array.Add(item.GetString().ToCjkBigramTokenFilterScripts());
```

However, the generated `CjkBigramTokenFilterScripts.cs` file only contains the struct definition with a `ToString()` method—**no `ToSerialString()` or `ToCjkBigramTokenFilterScripts()` extension methods are generated**.

### Expected Behavior
For extensible enums (readonly structs), the generator should either:
1. **Generate the extension methods** in a separate `*.Serialization.cs` file (like it does for fixed enums), OR
2. **Use `ToString()` and the constructor** directly in the serialization code:
   ```csharp
   writer.WriteStringValue(item.ToString());
   array.Add(new CjkBigramTokenFilterScripts(item.GetString()));
   ```

### Workaround
Manually create the missing extension methods:

```csharp
internal static class CjkBigramTokenFilterScriptsExtensions
{
    public static string ToSerialString(this CjkBigramTokenFilterScripts value) => value.ToString();
    public static CjkBigramTokenFilterScripts ToCjkBigramTokenFilterScripts(this string value) => new(value);
}
```

### Affected Types
This likely affects all extensible enums used in collection properties. Known affected types:
- `CjkBigramTokenFilterScripts`

---

## Bug 2: Inconsistent Variable Naming in Deserialization Methods

### Description
The TypeSpec C# generator produces inconsistent variable names in the `Deserialize*` methods. A local variable is declared with one name but referenced with a different name later in the method.

### Reproduction
In `IndexingParametersConfiguration.Serialization.cs`:

```csharp
// Line 176 - variable declared as 'additionalProperties'
IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();

// ... many lines later ...

// Line 301 - referenced as 'additionalBinaryDataProperties' (WRONG!)
additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
```

### Expected Behavior
The variable name should be consistent throughout the method. Either:
- Declare as `additionalBinaryDataProperties` and use `additionalBinaryDataProperties`, OR
- Declare as `additionalProperties` and use `additionalProperties`

### Root Cause
The generator uses different naming conventions in different parts of the serialization template:
- One part uses the pattern matching the field name (`_additionalBinaryDataProperties` ? `additionalBinaryDataProperties`)
- Another part uses a simpler name (`additionalProperties`)

### Affected Types
- `IndexingParametersConfiguration`
- Potentially any type with additional/unknown properties handling

---

## Bug 3: Duplicate Discriminator Property in Derived Types

### Description
The TypeSpec C# generator creates a duplicate `OdataType` property in derived classes when the base class already defines it as the discriminator. This causes CS0108 "hides inherited member" compiler warnings/errors.

### Reproduction
In `ContentUnderstandingSkill.cs` (derived from `SearchIndexerSkill`):

**Base class (`SearchIndexerSkill.cs`):**
```csharp
internal string OdataType { get; set; }
```

**Derived class (`ContentUnderstandingSkill.cs`) incorrectly re-declares:**
```csharp
internal string OdataType { get; set; } = "#Microsoft.Skills.Util.ContentUnderstandingSkill";
```

The internal constructor also has a redundant parameter:
```csharp
internal ContentUnderstandingSkill(
    string odataType,           // ? passed to base class
    ...,
    string odataType0)          // ? duplicate, assigned to local OdataType
    : base(odataType, ...)
{
    // ...
    OdataType = odataType0;     // ? This shouldn't exist
}
```

### Expected Behavior
Derived types should NOT re-declare the discriminator property. The value should be set via the base class constructor only, which is already being done correctly in the public constructor:

```csharp
public ContentUnderstandingSkill(...) 
    : base("#Microsoft.Skills.Util.ContentUnderstandingSkill", inputs, outputs)
```

### Compiler Error
```
CS0108: 'ContentUnderstandingSkill.OdataType' hides inherited member 'SearchIndexerSkill.OdataType'. 
Use the new keyword if hiding was intended.
```

### Root Cause
The TypeSpec definition likely has the `@odata.type` discriminator property appearing in both the base type and derived type definitions, or there's a conflict between the discriminator and a regular property with the same JSON name.

### Affected Types
- `ContentUnderstandingSkill`
- Potentially all derived skill types and any other polymorphic hierarchy with a discriminator property

---

## Summary

| Bug # | Issue | Severity | Workaround Available |
|-------|-------|----------|---------------------|
| 1 | Missing extension methods for extensible enums | High | Yes - manual extension class |
| 2 | Inconsistent variable naming in deserialization | High | No - requires regeneration |
| 3 | Duplicate discriminator property in derived types | High | Yes - use `new` keyword or suppress |

---

## Environment

- **Repository**: Azure/azure-sdk-for-net
- **Branch**: efrainretana/tsp-migration
- **SDK**: Azure.Search.Documents
- **Target Frameworks**: .NET 10, .NET 8, .NET Standard 2.0
