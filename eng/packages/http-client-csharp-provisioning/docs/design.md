# Provisioning Generator V2 — Design Document

## 1. Background & Motivation

### What is Azure.Provisioning?

The `Azure.Provisioning.*` libraries provide a C# infrastructure-as-code experience for Azure resources. Each library wraps an Azure Resource Manager (ARM) resource type with `ProvisionableResource` subclasses that expose `BicepValue<T>` properties, enabling users to declare Azure resources in C# and compile them to Bicep templates.

### Current Generator

The current generator (`sdk/provisioning/Generator/src/`) is a standalone .NET console application that:

1. **Takes NuGet packages as input** — references `Azure.ResourceManager.*` packages in its `.csproj`, loading compiled assemblies at runtime.
2. **Uses .NET reflection** — introspects ARM SDK types (collections, resources, data classes) to discover resource shapes, properties, and parent-child relationships.
3. **Extracts API versions from XML doc comments** — parses `<summary>` tags on ARM methods to find version strings like `2023-01-01`.
4. **Requires a hand-written `Specification` class per service** — each service (Storage, KeyVault, etc.) needs a `*Specification.cs` file that registers the entry-point type, applies customizations (remove properties, rename models, add naming constraints, define RBAC roles), and is hard-coded in `Program.cs`.
5. **Outputs `src/Generated/*.cs` files** — writes `ProvisionableResource` subclasses, model classes, enums, role definitions, and Bicep schema files.

### Problems with the Current Approach

| Problem | Impact |
|---------|--------|
| **NuGet dependency lag** | The generator reads from _published_ NuGet packages, not source. When an mgmt package is updated, the provisioning generator cannot pick up changes until a new NuGet version is published and referenced. |
| **Hand-written Specification per service** | Every new provisioning library requires a developer to: (1) create a Specification class, (2) add the NuGet reference, (3) register in `Program.cs`. This does not scale. |
| **Reflection is fragile** | The generator relies on internal patterns of the ARM SDK (e.g., finding `CreateOrUpdate` methods on `ArmCollection` types). Changes to ARM SDK codegen patterns silently break provisioning generation. |
| **No TypeSpec integration** | As management plane SDKs migrate from Swagger/AutoRest to TypeSpec, the TypeSpec toolchain has richer semantic information (resource types, API versions, property metadata) that is lost when going through NuGet binaries. |
| **Version discovery is indirect** | API versions are extracted from XML doc comment strings using regex, which is brittle and sometimes incorrect (e.g., preview versions leaking through). |
| **No automation** | Generating a provisioning library is a fully manual process with no CI/CD integration. |

### Why Now?

Four provisioning libraries now have TypeSpec-based mgmt counterparts:

| Provisioning Package | Mgmt Package | TypeSpec Spec Path |
|---|---|---|
| `Azure.Provisioning.AppConfiguration` | `Azure.ResourceManager.AppConfiguration` | `specification/appconfiguration/resource-manager/...` |
| `Azure.Provisioning.KeyVault` | `Azure.ResourceManager.KeyVault` | `specification/keyvault/KeyVault.Management` |
| `Azure.Provisioning.Kubernetes` | `Azure.ResourceManager.Kubernetes` | `specification/hybridkubernetes/...` |
| `Azure.Provisioning.SignalR` | `Azure.ResourceManager.SignalR` | `specification/signalr/resource-manager/...` |

As more management SDKs migrate to TypeSpec, this number will grow rapidly. Now is the right time to build a generator that integrates into the TypeSpec toolchain.

---

## 2. Goals & Non-Goals

### Goals

1. **Automate provisioning library generation from TypeSpec** — given a TypeSpec definition for a management-plane service, produce a complete `Azure.Provisioning.*` library with minimal manual intervention.
2. **Eliminate hand-written Specification classes** — resource discovery, property extraction, parent-child relationships, and API versions should be derived automatically from the TypeSpec input model or the generated mgmt SDK.
3. **Integrate into the existing TypeSpec emitter ecosystem** — leverage the layered emitter architecture (`http-client-csharp` → `http-client-csharp-mgmt` → provisioning) so that provisioning generation can be triggered alongside mgmt SDK generation.
4. **Support customization without forking** — provide a declarative customization mechanism (e.g., a config file or decorators) for service-specific tweaks (naming overrides, property removal, RBAC roles, naming constraints).
5. **Maintain backward compatibility** — generated output must be API-compatible with existing `Azure.Provisioning.*` libraries. Existing users should not experience breaking changes.
6. **Support incremental adoption** — the new generator should coexist with the current one. Services can migrate individually from the old generator to the new one.

### Non-Goals

- **Replace the current generator immediately** — the 25 Swagger-based services will continue using the current generator until their mgmt packages migrate to TypeSpec.
- **Generate provisioning libraries for data-plane services** — provisioning is management-plane only.
- **Multi-language support** — the provisioning libraries are .NET-only.
- **Generate test code** — tests remain hand-written.

---

## 3. Architecture

The provisioning generator is built as a new TypeSpec emitter package that extends the management emitter — a new layer in the existing emitter stack:

```
@typespec/http-client-csharp                         (core)
       ↑
@azure-typespec/http-client-csharp                    (Azure base)
       ↑
@azure-typespec/http-client-csharp-mgmt               (ARM management)
       ↑
@azure-typespec/http-client-csharp-provisioning        (NEW — provisioning)
```

**How it works:**
- Hooks into `$onEmit()` like the mgmt emitter.
- Receives the full TypeSpec code model (resources, models, enums, operations, API versions).
- Transforms the code model into provisioning-specific output (ProvisionableResource classes, BicepValue properties, etc.).
- Runs a C# generator (`ProvisioningGenerator`, extending `ManagementClientGenerator`) that produces the provisioning `.cs` files.

**Why this approach:**
- First-class TypeSpec integration — accesses the richest semantic information.
- API versions, resource types, and property metadata are directly available.
- Can be triggered via `tsp compile` alongside mgmt SDK generation.
- Follows the established emitter pattern used by the rest of the Azure SDK.

**Challenges to address:**
- The provisioning output is fundamentally different from a client SDK — it generates `ProvisionableResource` subclasses, not `ArmClient`/`ArmResource` types. This requires significant divergence in the C# generator's `TypeFactory` and `OutputLibrary`.
- Tight coupling to the emitter release cadence.

---

## 4. Detailed Design

### High-Level Architecture

```
@typespec/http-client-csharp                         (core emitter)
       ↑
@azure-typespec/http-client-csharp                    (Azure base emitter)
       ↑
@azure-typespec/http-client-csharp-mgmt               (ARM management emitter)
       ↑
@azure-typespec/http-client-csharp-provisioning        (provisioning emitter)
```

**Emitter side (TypeScript):**
- Hooks into `$onEmit()`, setting `generator-name` to `ProvisioningGenerator`.
- Delegates to the mgmt emitter, which passes the full code model to the C# generator.
- Can apply provisioning-specific TypeSpec decorators or code model mutations if needed.

**Generator side (C#):**
- `ProvisioningGenerator` extends `ManagementClientGenerator`.
- Overrides `TypeFactory` to produce provisioning-specific output types (`ProvisionableResource`, `BicepValue<T>` properties, etc.).
- Overrides `OutputLibrary` to control which files are generated (provisioning classes instead of ARM client classes).
- Reads the same code model (resources, models, enums, API versions) that the mgmt generator uses, but transforms it into provisioning output.

```
┌─────────────────────────────────────────────────────────────┐
│                    TypeSpec Definitions                      │
│           (azure-rest-api-specs repository)                  │
└─────────────────────┬───────────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────────┐
│        TypeSpec Emitter Chain                                │
│                                                             │
│  @typespec/http-client-csharp                               │
│    → @azure-typespec/http-client-csharp                     │
│      → @azure-typespec/http-client-csharp-mgmt              │
│        → @azure-typespec/http-client-csharp-provisioning    │
│                                                             │
│  Output: Code model (tspCodeModel.json)                     │
└─────────────────────┬───────────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────────┐
│              ProvisioningGenerator (C#)                      │
│  (extends ManagementClientGenerator)                        │
│                                                             │
│  Pipeline:                                                  │
│  1. Load code model from emitter                            │
│  2. Override TypeFactory for provisioning types              │
│  3. Override OutputLibrary for provisioning output           │
│  4. Generate C# files:                                      │
│     - ProvisionableResource subclasses                      │
│     - BicepValue<T> property wrappers                       │
│     - Model classes (ProvisionableConstruct subclasses)     │
│     - Enum types                                            │
│     - ResourceVersions nested classes                       │
│     - Built-in role enums                                   │
│                                                             │
│  Output: Azure.Provisioning.*/src/Generated/*.cs            │
└─────────────────────────────────────────────────────────────┘
```

---

## 5. TypeFactory & Type Resolution

The provisioning generator uses **TypeFactory extension points** to intercept type creation at the framework level. This is the core architectural decision — instead of post-processing mgmt output, we replace type creation itself.

### TypeFactory Overrides

`ProvisioningTypeFactory` extends `ManagementTypeFactory` and overrides three methods:

| Override | Behavior |
|---|---|
| `CreateModelCore(InputModelType)` | If system type → `null` (use framework). If ARM resource → `ProvisioningResourceProvider`. Otherwise → `ProvisioningModelProvider`. |
| `CreateEnumCore(InputEnumType)` | If system type → `null`. Otherwise → `ProvisioningEnumProvider`. |
| `CreateCSharpTypeCore(InputType)` | Wraps scalar types in `BicepValue<T>`, arrays in `BicepList<T>`, dictionaries in `BicepDictionary<T>`. Model types resolve to our providers without wrapping. |

### Resource Detection

Resource models are identified via `ManagementInputLibrary.IsResourceModel()` and their metadata (`ResourceMetadata`) is obtained from `ArmProviderSchema.Resources`. A `ResourceModelMap` dictionary maps `InputModelType` → `ResourceMetadata` at factory construction time.

**Important:** We access `ArmProviderSchema.Resources` (input-level) and **never** `ManagementOutputLibrary.ResourceProviders` (output-level), which would trigger `TypeFactory.CreateModel()` causing crashes since our factory returns provisioning types instead of the expected `ModelProvider`.

### Type Resolution Flow

```
InputModelType → CreateModelCore()
  ├─ KnownManagementTypes.TryGetSystemType? → null (framework type)
  ├─ KnownManagementTypes.TryGetInheritableSystemType? → null (base types from Azure.Provisioning)
  ├─ IsResourceModel? → ProvisioningResourceProvider(model, metadata)
  └─ Regular model? → ProvisioningModelProvider(model)

InputType → CreateCSharpTypeCore()
  ├─ InputModelType → base resolves to our provider's CSharpType (no wrapping)
  ├─ InputArrayType → BicepList<elementType>
  ├─ InputDictionaryType → BicepDictionary<valueType>
  ├─ InputEnumType (system) → BicepValue<frameworkEnumType>
  ├─ InputEnumType (custom) → BicepValue<ProvisioningEnumProvider.Type>
  └─ Scalar types → BicepValue<T> (string, int, DateTimeOffset, ResourceIdentifier, etc.)
```

Element types for `BicepList<T>` and `BicepDictionary<T>` use `GetUnwrappedCSharpType()` to resolve without `BicepValue<T>` wrapping (avoids `BicepList<BicepValue<string>>`).

### BicepTypeHelpers

CSharpType classification helpers are centralized in `BicepTypeHelpers`:
- `IsModelType(type)` — true if the type uses `DefineModelProperty` + `AssignOrReplace` (custom types, or framework types inheriting `ProvisionableConstruct`)
- `IsBicepValueType/IsBicepListType/IsBicepDictionaryType` — generic type checks
- `GetGenericArgument(type)` — extracts `T` from `BicepValue<T>`, etc.

---

## 6. Output Types

### ProvisioningModelProvider

Generates `ProvisionableConstruct` subclasses from `InputModelType`:
- Properties from `InputModelType.Properties`, with types resolved via `TypeFactory.CreateCSharpType()`
- Getter/setter patterns: models use `AssignOrReplace`, BicepValue types use `.Assign()`, read-only properties are getter-only
- `DefineProvisionableProperties()` override with `DefineProperty`/`DefineModelProperty`/`DefineListProperty`/`DefineDictionaryProperty` calls
- Property names PascalCased via `ToIdentifierName()`, field names via `ToVariableName()`

### ProvisioningResourceProvider

Generates `ProvisionableResource` subclasses from `InputModelType` + `ResourceMetadata`:
- **Property collection**: walks the model's inheritance chain (`BaseModel`) and collects all properties
- **Property flattening**: only flattens properties with the `@flattenProperty` decorator — not hardcoded for the `properties` bag
- **System properties**: `name`, `location` (required input), `id`, `systemData` (output-only), `tags` (input), `type` (skipped)
- **Constructor**: `(string bicepIdentifier, string? resourceVersion)` calling `base(bicepIdentifier, armResourceType, resourceVersion ?? defaultApiVersion)`
- **`FromExisting()`**: static factory method that creates an instance with `IsExistingResource = true`
- **`ResourceVersions`**: nested class with `public static readonly string` fields for each API version

### ProvisioningEnumProvider

Generates simple C# `enum` types from `InputEnumType`:
- Members named via `ToIdentifierName()` (PascalCase)
- Optional `[DataMember(Name = "...")]` attribute when the serialized value differs from the member name
- Extends `EnumProvider` with custom `BuildEnumValues()` override to satisfy framework enum value tracking
- No serialization providers — provisioning enums are serialized via `DefineProperty` at the resource/model level

### ProvisioningOutputLibrary

The output library bypasses the mgmt `BuildTypeProviders()` (which would trigger `ResourceClientProvider` initialization) and instead:
1. Iterates `InputNamespace.Models` and `InputNamespace.Enums` directly
2. Calls `TypeFactory.CreateModel()`/`TypeFactory.CreateEnum()` to get our providers
3. Adds all non-null providers to the output
4. Only adds resources to `AddTypeToKeep` — the post-processor automatically prunes unreferenced models/enums

---

## 7. Naming & Namespace Strategy (TODO)

- All types in flat namespace: `Azure.Provisioning.{ServiceName}` (no `.Models` sub-namespace for resources)
- Resources: derive name from ARM resource type (currently uses raw input name + mgmt "Data" suffix from `ResourceVisitor`)
- Models/Enums: service-prefix naming (e.g., `AppConfigurationKeyVaultProperties`)

---

## 8. Implementation Plan

### Phase 1: Generator Scaffolding & TypeFactory

**Goal:** Build the `ProvisioningGenerator` C# class with a custom `TypeFactory` that can transform mgmt code model types into provisioning output types.

1. Define the `ProvisioningTypeFactory` extending `ManagementTypeFactory`.
2. Implement type mappings: ARM resource → `ProvisionableResource` subclass, ARM data model → `ProvisionableConstruct` subclass, properties → `BicepValue<T>` wrappers.
3. Implement `ProvisioningOutputLibrary` to control which C# files are generated.
4. Add `ResourceVersions` nested class generation (GA versions only).
5. Validate by generating a single provisioning library (e.g., AppConfiguration) and comparing with the existing generated code.

### Phase 2: Emitter Integration & Config

**Goal:** Wire the emitter chain so `tsp compile` with the provisioning emitter produces provisioning C# code.

1. Set up the emitter build pipeline (`npm install`, `npm run build`) in `eng/packages/http-client-csharp-provisioning/`.
2. Add code model transformations in the emitter if needed (e.g., filtering non-resource types, annotating provisioning-specific metadata).
3. Implement `provisioning-config.yaml` loading in the C# generator for service-specific overrides (property removal, renames, RBAC roles, naming constraints).
4. Create `tspconfig.yaml` entries for provisioning libraries.
5. Validate end-to-end: `tsp compile` → provisioning C# code for all 4 TypeSpec-based services.

### Phase 3: End-to-End Pipeline

**Goal:** Automate provisioning library generation alongside mgmt SDK generation.

1. Add `tsp-location.yaml` to provisioning libraries pointing to the TypeSpec specs.
2. Create generation scripts that invoke the provisioning emitter.
3. Integrate with CI to detect when mgmt TypeSpec specs change and regenerate.
4. Migrate the 4 TypeSpec-based services (AppConfiguration, KeyVault, Kubernetes, SignalR) to the new generator.

### Phase 4: Scale & Polish

**Goal:** Make the generator production-ready and migrate remaining services as they move to TypeSpec.

1. Add validation and error reporting (missing properties, schema violations).
2. Generate CHANGELOG entries for API version additions.
3. Support automatic `ResourceVersions` class generation (no more reading existing files).
4. As mgmt SDKs migrate from Swagger to TypeSpec, migrate their provisioning libraries to the new generator.
5. Eventually deprecate the reflection-based generator when all services are on TypeSpec.

---

## 8. Migration Strategy

The new emitter-based generator will coexist with the current reflection-based generator:

```
sdk/provisioning/Generator/                              ← Current generator (reflection-based, for Swagger services)
eng/packages/http-client-csharp-provisioning/             ← New generator (emitter-based, for TypeSpec services)
```

**Per-service migration:**
1. Service migrates mgmt SDK to TypeSpec (e.g., `Azure.ResourceManager.Storage` gets `tsp-location.yaml`).
2. Add provisioning emitter to the service's `tspconfig.yaml`.
3. Add `tsp-location.yaml` to the provisioning library pointing at the same TypeSpec project with the provisioning emitter.
4. Run `dotnet build /t:GenerateCode` to generate provisioning code.
5. Diff output against current generated code, resolve differences.
6. Remove the old Specification class from `sdk/provisioning/Generator/`.
7. Update CI to use the new emitter for this service.

**Backward compatibility guarantee:**
- This migration should not introduce any breaking change comparing with the library's latest stable release.
- Existing `partial class` customizations in non-generated code must continue to compile.
- Existing tests must pass without modification (except for API version updates in expected Bicep strings — which should be pinned, as we recently established).

---

## 9. Open Questions

1. **Where should RBAC roles come from?** Currently hard-coded in Specification classes. Options: (a) stay in config, (b) extract from Azure RBAC TypeSpec definitions, (c) fetch from Azure API at generation time.
2. **Schema generation** — the current generator produces Bicep schema files. Should the new generator continue this, and if so, should schemas come from TypeSpec directly?
3. **How to handle the base specs (Arm, Resources, Authorization, ManagedServiceIdentities)?** These are always regenerated alongside any service. Should they use the new generator too, or remain on the reflection path?
