# @azure-typespec/http-client-csharp-provisioning

TypeSpec library for emitting Azure provisioning (infrastructure-as-code) libraries for C#.

## Overview

This package generates `Azure.Provisioning.*` libraries from TypeSpec ARM (Azure Resource Manager) definitions. It extends the management emitter (`@azure-typespec/http-client-csharp-mgmt`) to produce `ProvisionableResource` subclasses with `BicepValue<T>` properties, enabling C# infrastructure-as-code that compiles to Bicep templates.

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

## Local development

The management emitter is temporarily referenced through
`file:../http-client-csharp-mgmt` to consume the ARM resolver changes from this
checkout. Installing this package also restores the management emitter's
dependencies. `npm run build:emitter` builds the management emitter first and
reinstalls the local package to refresh its compiled output.
If installing with `--ignore-scripts`, restore the management emitter's
dependencies separately with `npm --prefix ../http-client-csharp-mgmt ci --ignore-scripts`.
The base emitter versions are aligned with the management emitter.
`install-links=true` installs the local dependency as a regular package rather
than a symlink, sharing this package's TypeSpec compiler and typekit registrations.
Replace the local reference with a published management emitter version before
publishing this package.

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

Provisioning uses `resolveArmResources` by default, including API-version
projection and client-name customization. To opt back into legacy resource
detection, set `use-legacy-resource-detection: true` in the provisioning emitter
options. The management emitter's default is unchanged.
