# Get-ResourceHierarchy.ps1

Reflection-based analyzer that extracts the resource hierarchy from a compiled
Azure SDK management-plane library (`Azure.ResourceManager.<RP>.dll`) and
emits the result as JSON.

Useful for understanding and validating resource hierarchies during
management-plane SDK migrations (e.g. Swagger → TypeSpec) and during
design review.

## What it produces

For every public non-abstract subclass of `ArmResource` in the target assembly,
the script records:

| Field | Description |
|---|---|
| `Name`, `FullName` | Resource type name |
| `ResourceType` | Value of the static `ResourceType` field (e.g. `Microsoft.Compute/virtualMachines`) |
| `ResourceId` | Template produced by `CreateResourceIdentifier(...)` with placeholder arguments |
| `DataType` | Type name of the `Data` property |
| `IsTrackedResource` | `true` if `Data` derives from `TrackedResourceData` |
| `IsSingleton` | `true` when no matching `<Name>Collection` type exists |
| `IsObsolete`, `ObsoleteMessage` | Set when the type is marked `[Obsolete(...)]` |
| `IsEditorBrowsableNever` | Set when the type is marked `[EditorBrowsable(EditorBrowsableState.Never)]` |
| `CollectionType` | Matching `<Name>Collection` type (null for singletons) |
| `ChildCollections` | `Get*()` methods on the resource returning an `ArmCollection` subtype |
| `ChildResources` | `Get*()` methods returning another `ArmResource` subtype directly (child singletons) |
| `ParentResources` | Other resource / `Mockable*` extension types that expose this resource's collection or singleton getter |
| `Scopes` | Extension scopes inferred from `Mockable*` types (e.g. `ResourceGroup`, `Subscription`, `Tenant`, `ArmClient`) |

The JSON array is written to **stdout**. Short diagnostic messages (assembly
version, type counts) go to **stderr**.

## Usage

The script needs the target DLL plus its runtime dependencies (notably
`Azure.ResourceManager.dll`) side-by-side in one folder. `dotnet publish`
gives you exactly that:

```powershell
# 1. Publish the mgmt library so dependencies are copied next to the DLL
dotnet publish sdk/<rp>/Azure.ResourceManager.<RP>/src -f net10.0 -o ./publish

# 2. Run the analyzer, capture JSON to a file
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/Get-ResourceHierarchy.ps1 `
    ./publish/Azure.ResourceManager.<RP>.dll > hierarchy.json
```

### Example: Azure.ResourceManager.Compute

```powershell
dotnet publish sdk/compute/Azure.ResourceManager.Compute/src -f net10.0 -o ./publish
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/Get-ResourceHierarchy.ps1 `
    ./publish/Azure.ResourceManager.Compute.dll > compute.json
```

On a recent build this reports **49 resource types / 45 collection types /
52 data types**, including singletons like
`VirtualMachineScaleSetRollingUpgradeResource` (parented under
`VirtualMachineScaleSetResource`) and EBN-hidden resources like
`CommunityGallery*` / `SharedGallery*`.

## How it works (short version)

- Loads the target assembly with `Assembly.LoadFrom`; sibling dependencies are
  resolved from the same directory via an `AssemblyResolve` handler.
- Discovers types by walking the `BaseType` chain (avoids cross-ALC identity
  pitfalls that `IsAssignableFrom` would hit).
- Reads `[Obsolete]` and `[EditorBrowsable]` via `GetCustomAttributesData()`
  (no attribute instantiation required).
- Infers parents and scopes by inspecting `Get*` methods on other resources
  and on the RP's `Mockable*` extension types:
  - for collection-backed resources: methods returning `<Name>Collection`
  - for singletons: parameter-less methods returning the resource type directly

## Caveats

- Input DLLs must target a framework compatible with the host pwsh runtime
  (`net10.0` works with pwsh on .NET 10). Netstandard2.0-only outputs will not
  load.
- Assemblies load into the default `AssemblyLoadContext`, so the pwsh process
  cannot analyze two DLLs with conflicting dependency versions in a single
  session — run the script once per target DLL.
