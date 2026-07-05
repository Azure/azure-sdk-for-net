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

## Architecture

`Get-ResourceHierarchy.ps1` is a thin PowerShell shim around the .NET 10
console tool under `ResourceHierarchyTool/`. The shim builds the tool on
demand (only when sources are newer than the existing build output) and
forwards the request to a child `dotnet` process.

The reflection runs on .NET 10 specifically so that the latest
`Azure.ResourceManager` (and its `System.Text.Json` v10 transitive dep) can
be loaded; the PowerShell host's own .NET 9 runtime cannot satisfy those
references.

## Usage

```
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/Get-ResourceHierarchy.ps1 <path-to-dll> [-ProbeDir <dir>...] [-ProbeFile <file>...] > hierarchy.json
```

The DLL's directory is automatically added as a probe directory. If
sibling dependencies (`Azure.ResourceManager.dll`, etc.) are not colocated,
pass extra `-ProbeDir`/`-ProbeFile` arguments listing where to find them —
or use `Get-PreviousGaResourceHierarchy.ps1` which builds a probe-dir list
from the SDK project's NuGet restore for you.

### Obtaining a DLL with dependencies

Any method that produces the target DLL alongside its dependencies will work.
A few common approaches:

| Source | How |
|--------|-----|
| **Build output** (`dotnet publish`) | `dotnet publish sdk/<rp>/Azure.ResourceManager.<RP>/src -f net10.0 -o ./out` |
| **NuGet global-packages cache** | After building with `ApiCompatVersion`, the previous GA DLL is restored under `~/.nuget/packages/azure.resourcemanager.<rp>/<version>/lib/…` |
| **Downloaded NuGet package** | Download and extract the `.nupkg`; the DLL is under `lib/<tfm>/` |

> **Note**: When using a DLL from the NuGet cache or an extracted `.nupkg`,
> make sure `Azure.ResourceManager.dll` (and other transitive dependencies)
> are present in the same directory. `dotnet publish` handles this
> automatically.

### Example

```powershell
pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/Get-ResourceHierarchy.ps1 `
    path/to/Azure.ResourceManager.Compute.dll > compute.json
```

On a recent run this reports **49 resource types / 45 collection types /
52 data types**, including singletons like
`VirtualMachineScaleSetRollingUpgradeResource` (parented under
`VirtualMachineScaleSetResource`) and EBN-hidden resources like
`CommunityGallery*` / `SharedGallery*`.

## How it works (short version)

The work happens inside `ResourceHierarchyTool` (a small `net10.0` console
app). It:

- Loads the target assembly with `Assembly.LoadFrom`; sibling dependencies
  are resolved from the DLL's own directory plus any caller-supplied probe
  directories via an `AssemblyResolve` handler.
- Discovers types by walking the `BaseType` chain (avoids cross-ALC
  identity pitfalls that `IsAssignableFrom` would hit).
- Reads `[Obsolete]` and `[EditorBrowsable]` via
  `GetCustomAttributesData()` (no attribute instantiation required).
- Infers parents and scopes by inspecting `Get*` methods on other resources
  and on the RP's `Mockable*` extension types:
  - for collection-backed resources: methods returning `<Name>Collection`
  - for singletons: parameter-less methods returning the resource type
    directly
- Propagates extension scopes from each top-level resource down through its
  parent → child chain (so deeply nested children correctly inherit
  `ResourceGroup` / `Subscription` / `Tenant` / `ManagementGroup`).

## Caveats

- Running the reflection requires the .NET 10 SDK to be installed (the tool
  targets `net10.0`). The shim builds on first use; subsequent runs reuse
  the build output.
- Assemblies load into the default `AssemblyLoadContext`, so a single tool
  invocation cannot analyze two DLLs with conflicting dependency versions
  — run the shim once per target DLL.
