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

## 3. Architecture Options

### Option A: TypeSpec Emitter (New Layer in the Emitter Stack)

Build the provisioning generator as a new TypeSpec emitter package that extends the management emitter:

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
- Runs a C# generator (similar to `ManagementClientGenerator`) that produces the provisioning `.cs` files.

**Pros:**
- First-class TypeSpec integration — accesses the richest semantic information.
- API versions, resource types, and property metadata are directly available.
- Can be triggered via `tsp compile` alongside mgmt SDK generation.
- Follows the established emitter pattern used by the rest of the Azure SDK.

**Cons:**
- Requires understanding and extending the TypeSpec emitter infrastructure (TypeScript + C# generator).
- The provisioning output is fundamentally different from a client SDK — it generates `ProvisionableResource` subclasses, not `ArmClient`/`ArmResource` types. This may require significant divergence from the base emitter's C# generator.
- Tight coupling to the emitter release cadence.

### Option B: Post-Processing Generator (Read Generated Mgmt C# Code)

Build a generator that reads the _generated management SDK C# source files_ (rather than compiled NuGet packages) and transforms them into provisioning code:

```
TypeSpec → mgmt emitter → Azure.ResourceManager.* (C# source)
                                      ↓
                          Provisioning Generator (reads C# source)
                                      ↓
                          Azure.Provisioning.* (C# source)
```

**How it works:**
- Uses Roslyn to parse the generated mgmt C# files.
- Extracts resource types, properties, enums, and API versions from the parsed syntax/semantic model.
- Applies customizations from a config file.
- Generates provisioning `.cs` files.

**Pros:**
- Decoupled from the TypeSpec emitter infrastructure — pure C# tooling.
- Works with both TypeSpec-generated and Swagger-generated mgmt SDKs (since the C# output is identical).
- Roslyn provides accurate type information without needing compiled assemblies.
- Easier for .NET developers to contribute to.

**Cons:**
- Roslyn parsing adds complexity (need to resolve types, handle partial classes, etc.).
- Loses some TypeSpec-level semantic information (e.g., TypeSpec decorators, doc comments from the spec).
- Requires the mgmt SDK to be generated first (two-step process).
- Still needs some convention-based discovery (finding `CreateOrUpdate` methods, etc.).

### Option C: Enhanced Reflection-Based Generator (Evolve the Current Approach)

Keep the reflection-based approach but add automation:

- Auto-discover Specification classes from the NuGet packages (no hand-written Specification files).
- Read customizations from a config file instead of C# code.
- Add CI/CD integration to automatically regenerate when NuGet packages are updated.

**Pros:**
- Minimal architecture change — builds on proven infrastructure.
- Works today for all 29 services.

**Cons:**
- Still depends on published NuGet packages (version lag).
- Still fragile reflection-based discovery.
- Does not leverage TypeSpec semantic information.
- Band-aid solution that doesn't address fundamental problems.

### Option D: Hybrid — TypeSpec Metadata + Source Code Generator

Use TypeSpec to extract metadata (resource definitions, API versions, property schemas) into an intermediate representation (e.g., JSON), then use a C# generator to produce provisioning code from that metadata:

```
TypeSpec → metadata extractor (TypeSpec plugin) → resource-metadata.json
                                                         ↓
                                              C# Provisioning Generator
                                                         ↓
                                              Azure.Provisioning.* (C# source)
```

**How it works:**
- A lightweight TypeSpec plugin extracts resource metadata (resource types, properties, enums, API versions, parent-child relationships) into a JSON intermediate representation.
- A standalone C# tool reads the JSON and generates provisioning code.
- Customizations are defined in a YAML/JSON config file per service.

**Pros:**
- Clean separation of concerns — TypeSpec plugin is simple, C# generator is self-contained.
- The JSON IR can be versioned and inspected.
- C# generator is easy for .NET developers to work on.
- Decoupled from emitter release cadence.
- Can still fall back to reading mgmt assemblies for Swagger-based services.

**Cons:**
- Two tools to maintain (TypeSpec plugin + C# generator).
- Need to define and evolve the intermediate JSON schema.
- Extra build step in the pipeline.

---

## 4. Recommended Approach: Option D (Hybrid)

### Rationale

Option D provides the best balance of TypeSpec integration, developer accessibility, and incremental adoption:

1. **TypeSpec integration without emitter complexity** — a metadata extraction plugin is far simpler than a full emitter. It only needs to extract resource definitions, not generate C# code.
2. **C# generator stays in C#** — the existing generator team works in C#. Keeping the core generation logic in C# (rather than TypeScript) maximizes contributor productivity.
3. **Clean intermediate representation** — the JSON IR creates a clear contract between the TypeSpec world and the C# generator. It can be tested, validated, and versioned independently.
4. **Backward compatibility** — the C# generator can support both JSON IR input (for TypeSpec services) and reflection input (for legacy Swagger services), enabling gradual migration.
5. **Customization via config** — YAML/JSON config files replace hand-written Specification classes, making it easier to add new services.

### High-Level Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                    TypeSpec Definitions                      │
│           (azure-rest-api-specs repository)                  │
└─────────────────────┬───────────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────────┐
│          TypeSpec Metadata Extractor Plugin                  │
│  (TypeScript — lightweight TypeSpec library/plugin)          │
│                                                             │
│  Extracts:                                                  │
│  - ARM resource types & hierarchy                           │
│  - Properties (name, type, required, readonly, path)        │
│  - Models and enums                                         │
│  - API versions (GA only, ordered)                          │
│  - Resource type string (e.g., Microsoft.Storage/...)       │
│  - Default API version                                      │
│  - Naming constraints (from @pattern, @minLength, etc.)     │
│                                                             │
│  Output: resource-metadata.json                             │
└─────────────────────┬───────────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────────┐
│            Service Customization Config                      │
│  (YAML — per provisioning library)                          │
│                                                             │
│  Defines:                                                   │
│  - Property overrides (remove, rename, mark secure)         │
│  - Model overrides (rename types)                           │
│  - RBAC role definitions                                    │
│  - Resource-level config (role assignment generation)        │
│  - Name requirements (override if not in TypeSpec)          │
│  - Excluded resource types                                  │
└─────────────────────┬───────────────────────────────────────┘
                      │
                      ▼
┌─────────────────────────────────────────────────────────────┐
│              C# Provisioning Code Generator                 │
│  (.NET console app — evolved from current Generator)        │
│                                                             │
│  Pipeline:                                                  │
│  1. Load resource-metadata.json                             │
│  2. Load customization config                               │
│  3. Build internal model (Resource, Property, Model, Enum)  │
│  4. Apply customizations                                    │
│  5. Generate C# files:                                      │
│     - ProvisionableResource subclasses                      │
│     - BicepValue<T> property wrappers                       │
│     - Model classes (ProvisionableConstruct subclasses)     │
│     - Enum types                                            │
│     - ResourceVersions nested classes                       │
│     - Built-in role enums                                   │
│     - Bicep schema files                                    │
│                                                             │
│  Output: Azure.Provisioning.*/src/Generated/*.cs            │
└─────────────────────────────────────────────────────────────┘
```

---

## 5. Intermediate Representation (IR) Schema

The JSON IR is the contract between the TypeSpec plugin and the C# generator. Here is a sketch of the schema:

```jsonc
{
  // Service-level metadata
  "serviceName": "Storage",
  "provisioningNamespace": "Azure.Provisioning.Storage",
  "mgmtNamespace": "Azure.ResourceManager.Storage",

  // API versions (GA only, newest first)
  "apiVersions": ["2025-06-01", "2024-01-01", "2023-05-01", "2023-01-01"],

  // ARM resources
  "resources": [
    {
      "name": "StorageAccount",
      "resourceType": "Microsoft.Storage/storageAccounts",
      "defaultApiVersion": "2025-06-01",
      "apiVersions": ["2025-06-01", "2024-01-01", "2023-05-01", "2023-01-01"],
      "parentResourceType": null,
      "nameConstraints": {
        "minLength": 3,
        "maxLength": 24,
        "pattern": "^[a-z0-9]+$"
      },
      "properties": [
        {
          "name": "Name",
          "type": "string",
          "isRequired": true,
          "isReadOnly": false,
          "path": ["name"],
          "description": "The name of the storage account."
        },
        {
          "name": "Kind",
          "type": { "$ref": "#/enums/StorageKind" },
          "isRequired": true,
          "isReadOnly": false,
          "path": ["kind"],
          "description": "Indicates the kind of account."
        },
        {
          "name": "Sku",
          "type": { "$ref": "#/models/StorageSku" },
          "isRequired": true,
          "isReadOnly": false,
          "path": ["sku"],
          "description": "The SKU of the storage account."
        },
        {
          "name": "CreatedOn",
          "type": "dateTime",
          "isRequired": false,
          "isReadOnly": true,
          "path": ["properties", "creationTime"],
          "description": "The creation date and time of the storage account."
        }
      ]
    },
    {
      "name": "BlobService",
      "resourceType": "Microsoft.Storage/storageAccounts/blobServices",
      "defaultApiVersion": "2025-06-01",
      "apiVersions": ["2025-06-01", "2024-01-01"],
      "parentResourceType": "Microsoft.Storage/storageAccounts",
      "properties": []
    }
  ],

  // Model types (nested objects)
  "models": [
    {
      "name": "StorageSku",
      "properties": [
        {
          "name": "Name",
          "type": { "$ref": "#/enums/StorageSkuName" },
          "isRequired": true,
          "isReadOnly": false,
          "path": ["name"]
        },
        {
          "name": "Tier",
          "type": { "$ref": "#/enums/StorageSkuTier" },
          "isRequired": false,
          "isReadOnly": true,
          "path": ["tier"]
        }
      ]
    }
  ],

  // Enum types
  "enums": [
    {
      "name": "StorageKind",
      "values": [
        { "name": "Storage", "value": "Storage" },
        { "name": "StorageV2", "value": "StorageV2" },
        { "name": "BlobStorage", "value": "BlobStorage" },
        { "name": "BlockBlobStorage", "value": "BlockBlobStorage" },
        { "name": "FileStorage", "value": "FileStorage" }
      ]
    }
  ]
}
```

---

## 6. Customization Config Schema

Each provisioning library will have a `provisioning-config.yaml` alongside its source:

```yaml
# sdk/provisioning/Azure.Provisioning.Storage/provisioning-config.yaml

# Property overrides
properties:
  - resource: FileShareResource
    remove: [Expand]
  - resource: ImmutabilityPolicyResource
    remove: [IfMatch]
  - resource: StorageTaskAssignmentResource
    property: ProvisioningState
    hide: true
  - model: StorageAccountKey
    property: Value
    secure: true
  - model: LocalUserKeys
    property: SharedKey
    secure: true

# Model overrides
models:
  - armName: TableResource
    rename: StorageTable

# Resource overrides
resources:
  - name: StorageAccount
    generateRoleAssignment: true
  - name: BlobService
    defaultName: "default"
    hideName: true

# Naming requirements (override TypeSpec-derived constraints)
nameRequirements:
  - resource: StorageAccount
    min: 3
    max: 24
    allowed: [lowercase, digits]
  - resource: BlobContainer
    min: 3
    max: 63
    allowed: [lowercase, digits, hyphen]

# RBAC roles
roles:
  - name: StorageAccountContributor
    id: "17d1049b-9a84-46fb-8f53-869881c3d3ab"
    description: "Permits management of storage accounts."
  - name: StorageBlobDataContributor
    id: "ba92f5b4-2d11-453d-a403-e96b0029c9fe"
    description: "Read, write, and delete Azure Storage containers and blobs."
  # ... more roles
```

---

## 7. Implementation Plan

### Phase 1: IR-based C# Generator

**Goal:** Refactor the existing C# generator to accept JSON IR as input, while keeping the reflection path as fallback.

1. Define the IR JSON schema (TypeScript types + JSON Schema for validation).
2. Refactor the internal model (`Resource`, `Property`, `TypeModel`, `EnumModel`) to be populated from either:
   - JSON IR (new path), or
   - Reflection (existing path, for backward compatibility).
3. Implement YAML config loading to replace hand-written `Customize()` methods.
4. Write IR files manually for the 4 TypeSpec services to validate the generator.
5. Verify generated output matches existing libraries (diff test).

### Phase 2: TypeSpec Metadata Extractor

**Goal:** Build a TypeSpec plugin that extracts resource metadata into the IR JSON format.

1. Create a TypeSpec library/plugin project under `eng/packages/`.
2. Implement resource discovery from the TypeSpec ARM model (walk `@armResource` decorators).
3. Extract properties, models, enums, API versions, naming constraints.
4. Output `resource-metadata.json` that conforms to the IR schema.
5. Validate against the manually-written IR files from Phase 1.

### Phase 3: End-to-End Pipeline

**Goal:** Wire the TypeSpec plugin and C# generator into an automated pipeline.

1. Add a `tsp-location.yaml`-like config to provisioning libraries pointing to the TypeSpec spec.
2. Create a generation script: `tsp compile` (extract IR) → `dotnet run Generator` (generate C#).
3. Integrate with CI to detect when mgmt TypeSpec specs change and regenerate.
4. Migrate the 4 TypeSpec-based services to the new pipeline.

### Phase 4: Scale & Polish

**Goal:** Make the generator production-ready and migrate remaining services.

1. Add validation and error reporting (missing properties, schema violations).
2. Generate CHANGELOG entries for API version additions.
3. Support automatic `ResourceVersions` class generation from IR (no more reading existing files).
4. As mgmt SDKs migrate from Swagger to TypeSpec, migrate their provisioning libraries to the new generator.
5. Eventually deprecate the reflection-based path when all services are on TypeSpec.

---

## 8. Migration Strategy

The new generator will coexist with the current one:

```
sdk/provisioning/Generator/          ← Current generator (reflection-based)
sdk/provisioning/Generator.V2/       ← New generator (IR-based)
```

**Per-service migration:**
1. Service migrates mgmt SDK to TypeSpec (e.g., `Azure.ResourceManager.Storage` gets `tsp-location.yaml`).
2. Run TypeSpec metadata extractor to produce IR.
3. Create `provisioning-config.yaml` from the existing Specification class.
4. Run new generator, diff output against current generated code.
5. Resolve differences, update config.
6. Remove the old Specification class.
7. Update CI to use the new generator for this service.

**Backward compatibility guarantee:**
- Generated C# output must be API-compatible with existing libraries.
- Existing `partial class` customizations in non-generated code must continue to compile.
- Existing tests must pass without modification (except for API version updates in expected Bicep strings — which should be pinned, as we recently established).

---

## 9. Open Questions

1. **Where should RBAC roles come from?** Currently hard-coded in Specification classes. Options: (a) stay in config, (b) extract from Azure RBAC TypeSpec definitions, (c) fetch from Azure API at generation time.
2. **Should the TypeSpec extractor be a standalone plugin or an emitter extension?** A plugin is simpler but requires a separate invocation. An emitter extension runs alongside mgmt generation but adds coupling.
3. **How to handle services with both TypeSpec and hand-crafted code?** Some mgmt SDKs (e.g., DNS) are heavily hand-crafted. The generator needs to gracefully handle missing or incomplete metadata.
4. **Schema generation** — the current generator produces Bicep schema files. Should the new generator continue this, and if so, should schemas come from TypeSpec directly?
5. **How to handle the base specs (Arm, Resources, Authorization, ManagedServiceIdentities)?** These are always regenerated alongside any service. Should they use the new generator too, or remain on the reflection path?
