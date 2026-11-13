# @azure-typespec/http-client-csharp-provisioning

TypeSpec library for emitting Azure provisioning (infrastructure-as-code) libraries for C#.

## Overview

This package generates `Azure.Provisioning.*` libraries from TypeSpec ARM (Azure Resource Manager) definitions. It extends the management emitter (`@azure-typespec/http-client-csharp-mgmt`) to produce `ProvisionableResource` subclasses with `BicepValue<T>` properties, enabling C# infrastructure-as-code that compiles to Bicep templates.

## Resource construction and inline inputs

A GET-only resource model can also be a writable inline input to a deployable
parent. The generator intentionally preserves public construction and input
setters for those usages; constructor accessibility must not depend solely on
the resource's standalone deployability. `FromExisting()` is not a general
replacement for constructing an input object.

See the [deployability and model-settability invariants](docs/resource-detection-design.md#deployability-is-not-model-settability)
before changing constructor or setter generation.

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

## New library scaffolding

When the source project does not exist (or `new-project` is enabled), the
generator uses `NewProvisioningProjectScaffolding` to create a source project
referencing `Azure.Provisioning`, package build properties, and a solution. The
build properties use the same normalized template for SDK packages and local
generation fixtures: shared framework defaults, management-library classification,
analyzer suppressions, the experimental-attribute polyfill, and the conditional
`Azure.Core` project-reference bridge. They do not enable nullable or unused
experimental provisioning flags. Nullable is enabled only in the test project.
For packages under `sdk/`, the generator also creates a provisioning README,
changelog, and a test project wired to `ProvisioningTestShared` and the provisioning
deployment libraries. Existing SDK documentation, build properties, and test
projects are preserved. Local fixture build properties are regenerated along with
their projects. Service CI registration is not part of generator scaffolding.

## Development

Keep all three generator dependencies in `package.json` aligned with
`eng/centralpackagemanagement/Directory.Generation.Packages.props` and compatible
with each other. After updating the pins, run `npm install` in this directory,
then run `eng/scripts/Generate.ps1` to regenerate and build both local fixtures.
