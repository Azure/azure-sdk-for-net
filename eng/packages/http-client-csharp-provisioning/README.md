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

## Resource name customization

When one TypeSpec model backs multiple ARM resource types, use the
`provisioning-resource-name` client option to assign a name to each generated
resource projection:

```typespec
#suppress "@azure-tools/typespec-client-generator-core/client-option" "Provisioning resource names"
#suppress "@azure-tools/typespec-client-generator-core/client-option-requires-scope" "Provisioning resource names"
@@clientOption(MyResource, "provisioning-resource-name", #{
  "Microsoft.Example/widgets": "Widget",
  "Microsoft.Example/widgets/children": "WidgetChild",
}, "csharp");
```

Keys are matched case-insensitively against the complete ARM resource type.
