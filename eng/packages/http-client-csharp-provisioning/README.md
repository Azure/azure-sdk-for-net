# @azure-typespec/http-client-csharp-provisioning

TypeSpec library for emitting Azure provisioning (infrastructure-as-code) libraries for C#.

## Overview

This package generates `Azure.Provisioning.*` libraries from TypeSpec ARM (Azure Resource Manager) definitions. It extends the management emitter (`@azure-typespec/http-client-csharp-mgmt`) to produce `ProvisionableResource` subclasses with `BicepValue<T>` properties, enabling C# infrastructure-as-code that compiles to Bicep templates.

## Resource inventory

Use PowerShell 7+ to build a provisioning library and export its ARM resource metadata as Markdown:

```powershell
.\eng\packages\http-client-csharp-provisioning\eng\scripts\Export-ResourceInventory.ps1 `
    -Path .\sdk\batch\Azure.Provisioning.Batch `
    -OutputPath .\batch-resources.md
```

`-Path` accepts a package directory with one project under `src`, a directory containing one project, a `.csproj`, or an existing `.dll`. Project inputs build with `dotnet` and copy their dependencies next to the output assembly. The default build target is `netstandard2.0` in `Debug`; use `-Framework` and `-Configuration` to override these.

For DLL inputs, no build is performed. Keep the DLL's dependencies alongside it and use a compatible PowerShell/.NET runtime:

```powershell
.\eng\packages\http-client-csharp-provisioning\eng\scripts\Export-ResourceInventory.ps1 `
    -Path .\artifacts\bin\Azure.Provisioning.Batch\Debug\netstandard2.0\Azure.Provisioning.Batch.dll `
    -OutputPath .\batch-resources.md
```

The report lists each concrete `ProvisionableResource` type, its ARM resource type, parent property type, presence of a public `Scope` property, and default API version. Inherited properties and resources with non-public constructors are included. Abstract and open generic types are excluded. Parent and scope columns describe the library's public properties, not assigned parent instances or supported ARM deployment scope kinds. Inspection errors fail the command rather than producing a partial report.

Only inspect trusted libraries: assembly loading and resource constructors execute code. The script supports resource constructors taking a Bicep identifier and an optional API version, or just a Bicep identifier.

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
