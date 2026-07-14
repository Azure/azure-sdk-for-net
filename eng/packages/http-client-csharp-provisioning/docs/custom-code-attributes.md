# Custom code attributes

The provisioning generator emits a small set of C# attributes into `src/Generated/Internal` for SDK customizations that cannot be expressed in TypeSpec. Apply these attributes in custom partial classes or assembly-level custom code under the SDK package `src` folder. The generator reads them during code generation, so regenerate the SDK after adding, removing, or changing one of these attributes.

Use these attributes only for .NET provisioning SDK compatibility or C#-specific behavior. Prefer TypeSpec customizations such as `@@clientName`, `@@alternateType`, and `@@access` when the change describes the service API shape.

## `CodeGenTypeAttribute`

Use `[CodeGenType("OriginalGeneratedTypeName")]` on a custom partial type when the generated type needs to be renamed or replaced for .NET compatibility.

```csharp
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sample
{
    [CodeGenType("SampleResource")]
    public partial class LegacySampleResource
    {
    }
}
```

## `CodeGenMemberAttribute`

Use `[CodeGenMember("OriginalGeneratedMemberName")]` on a custom member when the generated member needs to be renamed or replaced for .NET compatibility.

Provisioning properties must include backing fields and `Define*Property` wiring. If the custom member suppresses generated output, implement the replacement property fully in custom code.

```csharp
using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sample
{
    public partial class SampleProperties
    {
        private BicepValue<string> _newName;

        [CodeGenMember("OldName")]
        public BicepValue<string> NewName
        {
            get
            {
                Initialize();
                return _newName;
            }
        }

        partial void DefineAdditionalProperties()
        {
            _newName = DefineProperty<string>(nameof(NewName), new[] { "oldName" });
        }
    }
}
```

## `CodeGenSuppressAttribute`

Use `[CodeGenSuppress("GeneratedMemberName")]` to suppress generated members that should not appear in the provisioning SDK surface.

## `CodeGenEnumValueAttribute`

Use assembly-level `[CodeGenEnumValue(enumName, memberName, value)]` attributes when a generated enum needs to preserve previously shipped members or underlying integer values.

```csharp
using Microsoft.TypeSpec.Generator.Customizations;

[assembly: CodeGenEnumValue("SampleKind", "InsertedKind", 3)]
[assembly: CodeGenEnumValue("SampleKind", "LegacyKind", 4, WireName = "legacy-kind")]
```

The generator emits explicit integer values for every member. Members without custom values receive the smallest unused ordinal, so reserving `InsertedKind = 3` does not shift later generated members.

If `memberName` does not match any generated enum member, the generator appends a compatibility enum member. Set `WireName` when the appended member should serialize with a different wire value through `[DataMember(Name = "...")]`.
