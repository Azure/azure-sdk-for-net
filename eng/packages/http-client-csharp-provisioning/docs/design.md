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

### Overrides

The `ProvisioningTypeFactory` extends `ManagementTypeFactory` and overrides four extension points: model creation, enum creation, C# type resolution, and property creation.

- **Model creation** routes each input model type to the appropriate provisioning provider — resource models become `ProvisionableResource` subclasses, regular models become `ProvisionableConstruct` subclasses, and system/framework types are skipped (they come from the `Azure.Provisioning` base package).
- **Enum creation** produces simple C# `enum` types instead of the extensible `readonly struct` pattern used by mgmt libraries.
- **Type resolution** wraps scalar types in `BicepValue<T>`, arrays in `BicepList<T>`, and dictionaries in `BicepDictionary<T>`. Model types resolve to our providers without wrapping.
- **Property creation** delegates to base to run the mgmt visitor pipeline (e.g., standard name renames like `Etag` → `ETag`), then creates a provisioning-style property with a linked backing field and `BicepValue` getter/setter.

### Resource Detection

Resource models are identified from the ARM provider schema at the input level. The output library pre-creates all resources from the schema at construction time, populating a map from input model types to resource metadata used by the factory.

**Important:** We access the input-level resource schema and **never** the mgmt output library's resource providers, which would trigger model creation causing crashes since our factory returns provisioning types instead of the expected mgmt types.

### Type Resolution Flow

```
InputModelType → Model creation
  ├─ Known framework type? → null (use Azure.Provisioning base)
  ├─ Inheritable system type? → null (e.g., ManagedServiceIdentity, SystemData)
  ├─ ARM resource model? → ProvisioningResourceProvider
  ├─ Discriminator variant of resource? → ProvisioningResourceProvider (derived)
  └─ Regular model? → ProvisioningModelProvider

InputType → Type resolution
  ├─ Model type → provider's CSharpType (no wrapping)
  ├─ Array → BicepList<elementType>
  ├─ Dictionary → BicepDictionary<valueType>
  ├─ Enum (system) → BicepValue<frameworkEnumType>
  ├─ Enum (custom) → BicepValue<generatedEnumType>
  └─ Scalar → BicepValue<T> (string, int, DateTimeOffset, ResourceIdentifier, etc.)
```

Element types for `BicepList<T>` and `BicepDictionary<T>` are resolved without `BicepValue<T>` wrapping (avoids `BicepList<BicepValue<string>>`).

---

## 6. Output Types

### Resource Provider

Generates `ProvisionableResource` subclasses from input model types + resource metadata:
- **Property collection**: walks the model's inheritance chain and collects all properties, flattening only those with the `@flattenProperty` decorator
- **Field-property linking**: each property gets a nullable backing field. Properties and fields are co-created through the TypeFactory property creation pipeline, ensuring names go through the mgmt visitor pipeline. These linked pairs are lazily initialized on first access.
- **System properties**: `name`, `location` (required input), `id`, `systemData` (output-only), `tags` (input), `type` (skipped)
- **Parent resources**: child resources get a typed `Parent` property for parent-child relationship
- **Constructor**: `(string bicepIdentifier, string? resourceVersion)` with default API version
- **`FromExisting()`**: static factory method
- **`ResourceVersions`**: nested class with GA API version constants

### Model Provider

Generates `ProvisionableConstruct` subclasses:
- Same field-property co-creation pattern as resources — properties go through the TypeFactory pipeline for visitor-based name resolution
- Getter/setter patterns: models use `AssignOrReplace`, BicepValue types use `.Assign()`, read-only properties are getter-only
- `DefineProvisionableProperties()` maps each property to its bicep path

### Enum Provider

Generates simple C# `enum` types:
- Optional `[DataMember(Name = "...")]` attribute when the serialized value differs from the member name
- No serialization providers — provisioning enums are serialized via `DefineProperty` at the resource/model level

### Output Library

The output library bypasses the mgmt output pipeline (which would trigger mgmt-specific type initialization) and instead iterates input models and enums directly, routing each through our TypeFactory. Only resources are marked as "types to keep" — the post-processor automatically prunes unreferenced models and enums.

---

## 7. Naming & Namespace Strategy

- All types in flat namespace: `Azure.Provisioning.{ServiceName}` (no `.Models` sub-namespace)
- Achieved by setting `model-namespace=false` in the provisioning emitter, which prevents the base `NamespaceVisitor` from appending `.Models`
- Resource model names have the "Data" suffix stripped by `ResourceDataSuffixVisitor` — the mgmt `ResourceVisitor` appends "Data" (e.g., `ConfigurationStore` → `ConfigurationStoreData`), and our visitor reverts it since provisioning libraries don't use the Data suffix convention
- Property names are resolved through the `TypeFactory.CreatePropertyCore()` pipeline, which runs mgmt visitors (specifically `NameVisitor`) to apply standard renames: `Etag` → `ETag`, `CreationDate` → `CreatedOn`, `*Url` → `*Uri`, and other datetime suffix normalizations. This ensures provisioning libraries follow the same naming conventions as mgmt libraries without duplicating rename rules.

---

## 8. Migration Strategy

The new emitter-based generator coexists with the current reflection-based generator:

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
- Existing tests must pass without modification (except for API version updates in expected Bicep strings — which should be pinned).
