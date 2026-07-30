# Custom code attributes

The management generator emits a small set of C# attributes into `src/Generated/Internal` for SDK customizations that cannot be expressed in TypeSpec. Apply these attributes in custom partial classes under the SDK package `src` folder. The generator reads them during code generation, so regenerate the SDK after adding, removing, or changing one of these attributes.

Use these attributes only for .NET management SDK compatibility or C#-specific behavior. Prefer TypeSpec customizations such as `@@clientName`, `@@alternateType`, and `@@access` when the change describes the service API shape.

## `CodeGenResourceDataAttribute`

Use `[CodeGenResourceData(typeof(TData))]` on a resource partial class when the generated resource must use a specific resource data type instead of the data type selected from the TypeSpec resource model.

```csharp
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sample
{
    [CodeGenResourceData(typeof(SampleResourceData))]
    public partial class SampleResource
    {
    }
}
```

The constructor accepts the resource data type. The generator uses the annotated class name to find the resource and then uses the supplied type for the resource data surface.

## `CodeGenTagPatchHookAttribute`

Use `[CodeGenTagPatchHook(nameof(MethodName))]` on a resource partial class when generated tag fallback methods need to copy or normalize resource data before sending the PATCH request. This is intended for resources where the service requires fields in tag PATCH requests that are not tag values.

The hook method must be an instance method on the same resource partial class. It receives the patch object and the current resource data:

```csharp
using Azure.ResourceManager.Sample.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sample
{
    [CodeGenTagPatchHook(nameof(PrepareTagPatch))]
    public partial class SampleResource
    {
        private void PrepareTagPatch(SamplePatch patch, SampleResourceData current)
        {
            patch.RequiredProperty = current.RequiredProperty;
        }
    }
}
```

The generator calls the hook in the PATCH fallback path for `AddTag`, `SetTags`, and `RemoveTag` after creating the patch and after copying existing tags when required, but before applying the requested tag mutation. This preserves the same ordering as AutoRest `update-required-copy` customizations: copy the current resource state into the patch, then apply the requested tag change.
