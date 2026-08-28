---
name: search-documents-typespec-validation
description: 'TypeSpec validation skill for Azure.Search.Documents SDK. Performs a COMPLETE validation of ALL operations, ALL models, ALL enums, and ALL properties against the TypeSpec definition at any pinned commit. Works for any API version. Generates a full gap report: missing features, extra features, naming mismatches, and recommended fix location. WHEN: "validate Azure.Search.Documents SDK against TypeSpec", "detect Azure.Search.Documents typespec feature gaps", "what is missing from the Azure.Search.Documents SDK", "compare Azure.Search.Documents SDK to spec", "full spec coverage audit for Azure.Search.Documents". Do NOT use for version-to-version diff or regression detection — use search-documents-version-diff instead.'
---

# Azure.Search.Documents — TypeSpec Validation Skill

| Property | Value |
|---|---|
| Package | `Azure.Search.Documents` |
| Root | `sdk/search/Azure.Search.Documents/` |
| TypeSpec repo | `Azure/azure-rest-api-specs` |
| TypeSpec path | `specification/search/data-plane/Search` |
| Pin file | `tsp-location.yaml` (contains commit SHA) |

**Related skills:**
- [search-documents](../search-documents/SKILL.md) — E2E workflow skill for full release cycles, spec updates, code changes, and customizations
- [search-documents-version-diff](../search-documents-version-diff/SKILL.md) — diff public API surface between two versions to catch regressions

For TypeSpec decorator details and C# customization patterns referenced in this validation, see:
- [customization.md](../search-documents/references/customization.md) — `@@clientName`, `@@access`, `[CodeGenMember]`, compound property wiring
- [architecture.md](../search-documents/references/architecture.md) — source layout, SearchOptions architecture, service version management

---

## Purpose

Perform a **complete, exhaustive** comparison of the SDK's public API surface against the TypeSpec definition to produce a structured gap analysis report. The TypeSpec (main spec files + `client.tsp` overrides) is the **source of truth** for what the SDK should expose.

This skill validates:
- **Every operation** on every client
- **Every model** (class, struct, enum, union) and its properties
- **Every enum/union value** to detect missing or extra members
- **Every generated file** against the public API listing to ensure nothing is silently dropped or incorrectly internalized

The validation is **version-aware**: it reads the commit SHA from `tsp-location.yaml` and uses the TypeSpec `@added`/`@removed` versioning decorators to determine which features should exist for the SDK's current target API version(s).

---

## Inputs

| Input | Source | Required |
|---|---|---|
| TypeSpec commit SHA | `tsp-location.yaml` → `commit` field | Yes (auto-read) |
| TypeSpec directory | `tsp-location.yaml` → `directory` field | Yes (auto-read) |
| SDK public API listing | `api/Azure.Search.Documents.netstandard2.0.cs` (preferred; fallback: `net10.0.cs`) | Yes (local file) |
| Generated code | `src/Generated/` directory (all `.cs` files) | Yes (local) |
| Generated models | `src/Generated/Models/` directory (all `.cs` files) | Yes (local) |
| Custom code | `src/` (non-Generated files) | Yes (local) |
| client.tsp | Fetched from azure-rest-api-specs at pinned SHA | Yes (remote) |
| All TypeSpec model files | Fetched from azure-rest-api-specs routes/ and models/ dirs | Yes (remote) |

---

## Workflow

### Step 1 — Gather Sources

1. Read `tsp-location.yaml` to get the commit SHA and TypeSpec directory path.
2. Determine the SDK's target API version(s) by reading `SearchClientOptions.ServiceVersion` enum from the API listing. The **latest** version is the one being validated.
3. Fetch the TypeSpec files from GitHub at the pinned SHA:
   - Entry point: `https://raw.githubusercontent.com/Azure/azure-rest-api-specs/{SHA}/{directory}/main.tsp`
   - Client customizations: `https://raw.githubusercontent.com/Azure/azure-rest-api-specs/{SHA}/{directory}/client.tsp`
   - Config: `https://raw.githubusercontent.com/Azure/azure-rest-api-specs/{SHA}/{directory}/tspconfig.yaml`
   - **All route files**: Follow imports from `main.tsp` (e.g., `routes-service.tsp`, `routes-index.tsp`, `routes-knowledgebase.tsp`, etc.)
   - **All model files**: Fetch everything in the `models/` subdirectory if present, or follow imports
4. Read the local SDK API listing: prefer `api/Azure.Search.Documents.netstandard2.0.cs` (most inclusive); fall back to `api/Azure.Search.Documents.net10.0.cs`
5. List ALL files in `src/Generated/Models/` — this is the authoritative set of generated types
6. Read custom partial classes: scan `src/` for non-Generated `.cs` files

**IMPORTANT**: Do NOT skip any TypeSpec files. The validation must cover the ENTIRE spec surface.

### Step 2 — Extract TypeSpec Surface

From the TypeSpec files, extract **ALL** of the following (no sampling, no shortcuts):

1. **API Versions** — all `enum Versions { ... }` members. Identify which version is being added by this commit (compare to SDK's `ServiceVersion` enum to find the new one).
2. **Operations** — all `op` declarations grouped by interface/namespace (these become client methods). Note `@added(Versions.vXXX)` decorators.
3. **Models** — ALL `model` declarations across ALL TypeSpec files (these become C# classes/structs). For EACH model, record:
   - Name
   - Base type (if `extends` or `is`)
   - All properties with types and optionality
   - `@discriminator` if present
   - `@added`/`@removed` version annotations
4. **Enums** — ALL `enum` declarations with all member values
5. **Unions** — ALL `union` declarations (these become extensible structs in C#) with all member values
6. **Discriminator hierarchies** — `@discriminator` decorators that create polymorphic type trees
7. **Versioning** — `@added(Versions.vXXX)` and `@removed(Versions.vXXX)` decorators on types, properties, and operations. A feature is expected in the SDK if it was `@added` in any version ≤ the SDK's latest version and not `@removed`.
8. **Routes** - ALL route declarations (e.g., `@route("/indexes")`) to verify correct client method placement and exposure. Ensure that new routes are exposed in the client.tsp and SDK as neeeded.

From `client.tsp`, extract **ALL** overrides:

1. **Renames** — every `@@clientName` augment (TypeSpec name → SDK name mapping)
2. **Access changes** — every `@@access("internal")` (types/methods hidden from public API)
3. **Suppressed methods** — `@@convenientAPI(op, false)` or `@@protocolAPI(op, false)`
4. **Usage overrides** — `@@usage` forcing input/output direction
5. **Client restructuring** — `@client`, `@operationGroup`, `@@clientLocation`
6. **Alternate types** — `@@alternateType` changing property types in the SDK
7. **Client namespace** — `@@clientNamespace` moving types to different namespaces

### Step 3 — Extract SDK Surface

From the API listing file (`api/*.cs`), extract:

1. **Public types** — all `public partial class`, `public partial struct`, `public enum`, `public static class`, `public abstract partial class`
2. **Public methods** — on ALL client types (search for classes ending in `Client`)
3. **Public properties** — on ALL model types
4. **Enum/struct members** — all `public static` properties on extensible structs (union-derived types)
5. **Factory methods** — on `SearchModelFactory`

From the generated models directory (`src/Generated/Models/`), extract:

6. **All generated files** — list every `.cs` file (excluding `.Serialization.cs`)
7. **Access modifier of each generated type** — check if each is `public` or `internal`
8. **Cross-reference**: every generated public type MUST appear in the API listing. If it doesn't, flag it.
9. **Cross-reference**: every generated internal type must be explainable by a `client.tsp` `@@access("internal")` override or by being a discriminator kind type.

From custom code, note:

10. **`[CodeGenSuppress]`** attributes — members actively hidden
11. **`[CodeGenType]`** attributes — type name remappings
12. **`[CodeGenMember]`** attributes — property name remappings
13. **Hand-written types** — classes that exist only in custom code (e.g., `FieldBuilder`, `SearchFilter`, `SearchDocument`)

### Step 3b — Exhaustive Generated Model Verification

This sub-step ensures NO model was silently dropped or incorrectly marked:

1. For **every** file in `src/Generated/Models/*.cs` (excluding `*.Serialization.cs`):
   - Read the type declaration line to get the type name and access modifier (`public` vs `internal`)
   - If `public`: verify it appears in the API listing file
   - If `internal`: verify there is a corresponding `@@access("internal")` or `@@clientName` rename to `Internal*` in `client.tsp`, OR it is a discriminator kind type (naming pattern: `*Kind`, `*Type` used internally for polymorphism)
2. Count totals: `{N} public, {M} internal, {0} unexplained`
3. Any type that is public in generated code but missing from the API listing is a **CRITICAL** gap.
4. Any type that is internal in generated code but has no explanation from `client.tsp` is a **WARNING** (may be intentional but needs verification).

### Step 4 — Compare and Classify

**This step MUST be exhaustive.** Do not sample or skip types. Every TypeSpec element must be accounted for.

#### 4a — Version Filtering

First, determine which API version is the SDK's **latest** (the default in `SearchClientOptions.ServiceVersion`). Then for each TypeSpec element:
- If it has `@added(Versions.vX)` where `vX` ≤ latest SDK version → **expected in SDK**
- If it has `@removed(Versions.vX)` where `vX` ≤ latest SDK version → **should NOT be in SDK**
- If it has no version annotation → **expected in all versions**

#### 4b — Operation Validation

For each TypeSpec operation, determine its expected SDK representation:

| TypeSpec element | Expected in SDK as |
|---|---|
| `op doSomething(...)` on interface X | Method `DoSomething`/`DoSomethingAsync` on client X |
| `op` with `@@access("internal")` in client.tsp | Should NOT appear in public API |
| `op` with `@@convenientAPI(op, false)` | No convenience method (only protocol method if `@@protocolAPI` not also false) |

Verify ALL operations on ALL clients.

#### 4c — Model Validation (EXHAUSTIVE)

For **every** model in the TypeSpec:

1. Determine its expected C# name (apply `@@clientName` if present)
2. Determine its expected access (apply `@@access` if present)
3. If expected public: verify it exists in the API listing with the correct name
4. If expected internal: verify it does NOT appear in the public API listing
5. For EACH property on the model:
   - Determine expected C# name (PascalCase, or `@@clientName` override)
   - Determine expected type (apply `@@alternateType` if present)
   - Verify it exists on the SDK type with correct name and compatible type
   - Check optionality: `?` in TypeSpec → nullable in SDK

#### 4d — Enum/Union Validation (EXHAUSTIVE)

For **every** enum and union:

1. Determine expected C# type:
   - `enum` → C# `enum` or extensible struct (depends on usage)
   - `union` with string base → extensible struct with `public static` members
2. Verify all members/values are present in the SDK
3. Flag any SDK values that don't exist in TypeSpec (could be backward-compat additions)

#### 4e — Discriminator Hierarchy Validation

For each `@discriminator` in TypeSpec:

1. Verify the base type exists as an abstract class in SDK
2. Verify ALL derived types exist
3. Verify the SDK has `Unknown*` fallback types for forward compatibility
4. Cross-reference with `client.tsp` renames

#### 4f — New Version Feature Validation

For the **specific API version being added** (the one in the TypeSpec commit that doesn't exist in the previous SDK release):

1. Identify ALL types, properties, operations, and enum values annotated with `@added(Versions.vNEW)` where `vNEW` is the new version
2. Verify EVERY one of these exists in the SDK
3. This is the highest-priority check — these are the new features this commit introduces

Apply `client.tsp` transformations:
- If `@@clientName(Foo, "Bar")` → expect `Bar` in SDK, not `Foo`
- If `@@access(op, "internal")` → should NOT appear in public API
- If `@@convenientAPI(op, false)` → no convenience method expected

### Step 5 — Generate Report

Produce a structured report with these sections:

#### 5.1 — Missing Features (in TypeSpec, not in SDK)

For each missing element:
```
| TypeSpec Element | Expected SDK Name | Category | Recommended Fix |
|---|---|---|---|
| model FooBar | FooBar | Model | Regenerate or check [CodeGenSuppress] |
| op getFoo | GetFoo/GetFooAsync | Operation | Check client.tsp @@access or regenerate |
| FooBar.bazProp | BazProp | Property | Check custom partial class |
```

**Recommended Fix** classification:
- **Regenerate** — TypeSpec has it, generation should produce it, likely stale codegen
- **Remove [CodeGenSuppress]** — SDK is actively suppressing it
- **Add to client.tsp** — needs `@@usage` or `@@convenientAPI(op, true)` to generate
- **SDK customization** — needs hand-written code (complex mapping, not 1:1)

#### 5.2 — Extra Features (in SDK, not in TypeSpec)

For each extra element:
```
| SDK Element | Category | Source | Action Needed |
|---|---|---|---|
| SearchFilter | Utility class | Hand-written | None (SDK-only helper) |
| FieldBuilder | Utility class | Hand-written | None (SDK-only helper) |
| OldModel | Backward compat | Retained from prev GA | Verify still needed |
```

**Source** classification:
- **Hand-written helper** — intentional SDK-only utility (no action)
- **Backward compat retained type** — kept from a previous GA release for ApiCompat
- **Stale customization** — was in old spec, removed from TypeSpec, should be evaluated
- **client.tsp override** — exists due to `@@clientName` or restructuring

#### 5.3 — Naming Mismatches

```
| TypeSpec Name | SDK Name | Source of Rename | Correct? |
|---|---|---|---|
| searchText | SearchText | Convention (PascalCase) | Yes |
| fooBar | BazQux | client.tsp @@clientName | Verify intent |
```

#### 5.4 — Structural Differences

- Operations on different clients than expected
- Models in different namespaces
- Properties with different types (e.g., `string` in TypeSpec vs `Uri` in SDK via customization)
- Properties with different optionality (required in TypeSpec, optional in SDK or vice versa)

#### 5.5 — Recommendations Summary

Prioritized list of actions:
1. **Critical** — public API gaps that affect functionality
2. **Important** — naming/structure issues that affect discoverability
3. **Low** — cosmetic or documentation-only differences
4. **No action** — intentional SDK-only additions or backward-compat retentions

For each recommendation, specify:
- **Where to fix**: `client.tsp` | `src/` customization | TypeSpec main spec (file a spec issue)
- **How to fix**: specific decorator/attribute/pattern to use
- **Risk**: breaking change? | backward compat impact?

---

## Fetching TypeSpec Files

The TypeSpec for this package lives in the external `Azure/azure-rest-api-specs` repo. To fetch:

1. Read commit SHA from `tsp-location.yaml`
2. Fetch `main.tsp` first — parse its `import` statements to discover all other files
3. Fetch `client.tsp` — this contains ALL SDK-specific overrides
4. Fetch `tspconfig.yaml` — this contains emitter options
5. Recursively fetch ALL imported `.tsp` files (routes, models, etc.)
6. Use raw GitHub URLs: `https://raw.githubusercontent.com/Azure/azure-rest-api-specs/{SHA}/{directory}/{file}`
7. The TypeSpec may import from `@azure-tools/typespec-azure-core` and other packages — focus on the **local model and operation definitions**, not library imports.

### Discovering TypeSpec Files

Parse `main.tsp` for lines like:
```
import "./routes-service.tsp";
import "./routes-index.tsp";
import "./models/common.tsp";
```

Each imported file may itself import more files. Follow ALL local imports (starting with `./`). Skip package imports (starting with `@`).

### Typical TypeSpec structure for this package:
```
specification/search/data-plane/Search/
├── main.tsp              # Entry point — defines service, API versions, imports routes
├── client.tsp            # SDK customizations (clientName, access, usage, etc.)
├── tspconfig.yaml        # Emitter configuration
├── routes-*.tsp          # Operation definitions by resource area
└── models (inline or in separate files imported by routes)
```

**Note**: The file structure may change between commits. Always discover files dynamically from `main.tsp` imports rather than assuming fixed paths.

---

## Handling Large TypeSpec Definitions

The Search service TypeSpec is large (400+ models, 50+ operations, 100+ enums/unions). The validation MUST still be exhaustive. Use these strategies:

1. **Automate the cross-reference** — use terminal commands to programmatically compare generated files against the API listing (see "Automated Verification Commands" below)
2. **Fetch all TypeSpec files** — follow ALL imports from `main.tsp` recursively; fetch every `.tsp` file in the spec directory
3. **Batch processing** — process files in batches but DO NOT skip any. Report progress: "Checked 150/400 models..."
4. **Focus on the new version first** — validate `@added(Versions.vNEW)` features with highest priority, then validate the full surface
5. **Use subagents for parallel work** — delegate model validation to an Explore subagent if needed

**NEVER skip types, NEVER sample, NEVER say "and similar types follow the same pattern."** Every type must be individually verified.

### Automated Verification Commands

Use the `Validate-GeneratedModels.ps1` script to perform exhaustive cross-reference checks:

```powershell
# Full validation — cross-references all generated models against API listing
./.github/skills/search-documents-typespec-validation/scripts/Validate-GeneratedModels.ps1 -Format summary

# Batch-check specific TypeSpec model names (after @@clientName renames) against the SDK
./.github/skills/search-documents-typespec-validation/scripts/Validate-GeneratedModels.ps1 -TypeNames @("SearchIndex","SearchField","SearchIndexer")

# JSON output for agent consumption
./.github/skills/search-documents-typespec-validation/scripts/Validate-GeneratedModels.ps1
```

The script lives at [scripts/Validate-GeneratedModels.ps1](scripts/Validate-GeneratedModels.ps1). It resolves paths relative to the package root automatically.

---

## Known Intentional Differences

These differences are **expected** and should NOT be flagged as gaps:

| SDK Element | Reason |
|---|---|
| `SearchDocument` (dynamic document) | SDK-only: enables `dynamic` and `Dictionary<string,object>` patterns |
| `FieldBuilder` | SDK-only: reflection-based field generation from C# model types |
| `SearchFilter.Create()` | SDK-only: OData filter expression builder |
| `SearchIndexingBufferedSender<T>` | SDK-only: client-side batching with retry |
| `SuggestOptions` / `AutocompleteOptions` | May differ from raw TypeSpec due to property grouping |
| `SemanticSearchOptions` / `VectorSearchOptions` | SDK-only sub-objects that group `SearchOptions` properties |
| Backward-compat retained types | Types from previous GA releases kept for ApiCompat |
| `SearchModelFactory` extra methods | May have legacy overloads for backward compat |
| Discriminator kind structs (e.g., `*Kind`, `*Type`) | Internal by design — used for polymorphic deserialization |
| `Unknown*` types | Internal forward-compat fallback types for polymorphic hierarchies |
| Types with `@@access("internal")` in client.tsp | Intentionally hidden — verify they're internal, not missing |

---

## Output Format

Present the report as a markdown table-based summary. Always include:

1. **Scope summary**: "Validated against TypeSpec commit `{SHA}`, API version `{version}`, {N} total TypeSpec models, {M} operations, {K} enums/unions"
2. **Automated cross-reference results**: "Generated models: {X} public (all in API), {Y} internal (all explained), {Z} unexplained"
3. **Gap counts**: X missing, Y extra, Z mismatches
4. **Critical items first** (blocking or high-impact gaps)
5. **Full type listing for new version features** — every `@added(Versions.vNEW)` type/operation explicitly confirmed or flagged
6. **Actionable recommendations** with specific file paths and patterns

Use collapsible sections (`<details>`) for large sub-lists (>20 items), but ALWAYS report the full data — never truncate or summarize.

---

## Constraints

- **DO NOT** modify any files during validation — this is a read-only analysis
- **DO NOT** flag backward-compat retained types as "extra" without checking git tags
- **DO NOT** flag hand-written helpers (FieldBuilder, SearchFilter, etc.) as issues
- **DO NOT** skip any types, operations, or enums — the analysis MUST be exhaustive
- **DO NOT** sample or summarize — report exact counts and exact names
- **DO NOT** hardcode API version names — read them dynamically from `main.tsp` and the SDK's `ServiceVersion` enum
- **DO** account for client.tsp transformations before flagging mismatches
- **DO** note when a gap might be intentional (e.g., `@@access("internal")`)
- **DO** distinguish between "missing from public API" and "present but internal"
- **DO** run the automated verification commands (Step 3b) to catch every generated model
- **DO** verify enum/union member counts match between TypeSpec and SDK
- **DO** explicitly confirm the new API version's `ServiceVersion` enum value exists and is set as default

## Completeness Checklist

Before reporting results, confirm ALL of the following:

- [ ] All TypeSpec files fetched (main.tsp + all imports + client.tsp)
- [ ] Every generated model file cross-referenced against API listing
- [ ] Every operation on every client verified
- [ ] Every `@@clientName` rename verified in SDK
- [ ] Every `@@access("internal")` verified as internal in SDK
- [ ] New API version's `ServiceVersion` value present and set as default
- [ ] All new-version `@added` features individually verified
- [ ] Enum/union member counts validated
- [ ] Discriminator hierarchies validated (base + all derived + Unknown* fallback)
- [ ] Summary counts reported: types checked, operations checked, gaps found