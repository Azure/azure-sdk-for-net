# @azure-typespec/http-client-csharp-provisioning

TypeSpec library for emitting Azure provisioning (infrastructure-as-code) libraries for C#.

## Overview

This package generates `Azure.Provisioning.*` libraries from TypeSpec ARM (Azure Resource Manager) definitions. It extends the management emitter (`@azure-typespec/http-client-csharp-mgmt`) to produce `ProvisionableResource` subclasses with `BicepValue<T>` properties, enabling C# infrastructure-as-code that compiles to Bicep templates.

## Resource inventory

Use PowerShell 7+ to build a provisioning library and export its ARM resource hierarchy as JSON:

```powershell
.\eng\packages\http-client-csharp-provisioning\eng\scripts\Export-ResourceInventory.ps1 `
    -Path .\sdk\batch\Azure.Provisioning.Batch `
    -OutputPath .\batch-resources.json
```

`-Path` accepts a package directory with one project under `src`, a directory containing one project, a `.csproj`, or an existing `.dll`. Project inputs build with `dotnet` and copy their dependencies next to the output assembly. The default build target is `netstandard2.0` in `Debug`; use `-Framework` and `-Configuration` to override these.

For DLL inputs, no build is performed. Keep the DLL's dependencies alongside it and use a compatible PowerShell/.NET runtime. Only .NET framework assemblies may fall back to the host's default load context; a missing private dependency fails inspection even if PowerShell already loaded it:

```powershell
.\eng\packages\http-client-csharp-provisioning\eng\scripts\Export-ResourceInventory.ps1 `
    -Path .\artifacts\bin\Azure.Provisioning.Batch\Debug\netstandard2.0\Azure.Provisioning.Batch.dll `
    -OutputPath .\batch-resources.json
```

The output is a JSON array using a subset of the field names from the management emitter's [`Get-ResourceHierarchy.ps1`](../http-client-csharp-mgmt/eng/scripts/Get-ResourceHierarchy.md). Resource ID templates, data-wrapper and tracked-resource metadata, singleton status, and deprecation and visibility attributes are omitted. It includes each concrete `ProvisionableResource` type, including non-public types and constructors. Abstract and open generic types are excluded. Inspection errors fail the command rather than producing a partial report.

| Fields | Provisioning meaning |
| --- | --- |
| `Name`, `FullName`, `ResourceType` | CLR resource name, fully qualified name, and ARM resource type. |
| `ParentResources` | Array of parent CLR type names from the public `Parent` property, or an empty array for no parent property. Includes inherited properties. |
| `HasScope`, `ResourceVersion` | Provisioning-specific additions: whether a public `Scope` property exists and the default API version. |
| `CollectionType`, `ChildCollections`, `ChildResources`, `Scopes` | Explicitly `null`: these management concepts are not available from this provisioning reflection. |

In particular, `HasScope` does not identify the supported ARM deployment scope kinds. `Scopes` remains unknown (`null`), rather than inventing a scope set or propagating guesses from parents. The JSON shape is aligned with the management tool, but it is not sufficient for the strict `Compare-ResourceHierarchy.ps1` gate, which expects known singleton and deployment-scope metadata.

Only inspect trusted libraries: assembly loading and resource constructors execute code. The script supports resource constructors taking a Bicep identifier and an optional API version, or just a Bicep identifier. The declared API-version default is used when present; otherwise the two-string constructor receives `null`.

Generating the emitter's test projects also exports `resource-inventory.json` into each generated project directory:

```powershell
.\eng\packages\http-client-csharp-provisioning\eng\scripts\Generate.ps1
```

Commit these reports alongside the generated code under `generator\TestProjects\Local` so resource metadata changes can be reviewed. A filtered generation updates only the selected project's report.

## Architecture

```
@typespec/http-client-csharp                         (core)
       ↑
@azure-typespec/http-client-csharp                    (Azure base)
       ↑
@azure-typespec/http-client-csharp-mgmt               (ARM management)
       ↑
@azure-typespec/http-client-csharp-provisioning        (provisioning — this package)
```

## Install

```bash
npm install @azure-typespec/http-client-csharp-provisioning
```

## Usage

1. Via the command line

```bash
tsp compile . --emit=@azure-typespec/http-client-csharp-provisioning
```

2. Via the config

```yaml
emit:
  - '@azure-typespec/http-client-csharp-provisioning'
```
