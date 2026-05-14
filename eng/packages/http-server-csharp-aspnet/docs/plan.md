# Roadmap

This document tracks the major features that are not yet implemented in
`@azure-typespec/http-server-csharp-aspnet`. Items are roughly ordered by
priority, but priorities will shift as we onboard pilot services.

## ✅ Implemented today

- POCO models per TypeSpec model (`src/Generated/Models/`)
- Abstract `<Name>ControllerBase` per TypeSpec interface, decorated with
  `[ApiController]`, inheriting `ControllerBase`
- One abstract `Task<ActionResult<T>> <Name>Async(...)` method per operation
  with the correct `[Http*("route")]` attribute
- Per-parameter binding attributes
  (`[FromRoute]` / `[FromQuery]` / `[FromHeader]` / `[FromBody]`) that mirror
  TypeSpec `@path` / `@query` / `@header` / `@body`
- Generated/hand-written separation: generated abstract bases live under
  `Generated/`, concrete controllers live in user-owned files

## 🔜 Planned

### 1. Versioning (largest gap)

Today every operation lands in a single non-versioned `ControllerBase`. Real
ARM services need:

- **Version registry generation.** Walk `@versioned` enums and emit a
  per-service `ApiVersion` enum (or equivalent registry) with category
  metadata (Preview / Stable).
- **Impact analysis.** For each version, compare each operation's
  request/response fingerprint (parameters + return type, projected through
  `@typespec/versioning` mutators) against the previous version. Flag an
  operation as "impacted" when it is `@added`, `@removed`, or its signature
  changed because a referenced model changed.
- **Incremental per-version directories.** Emit
  `Generated/V<YYYYMMDD>/Controllers/<Name>ControllerBase.cs` containing only
  the operations impacted in that version, plus
  `Generated/V<YYYYMMDD>/Models/*.cs` reflecting that version's model shapes.
- **Versioning attributes on generated controllers.** Default to `[ApiVersion]`
  / `[Route]`; allow downstream extensions to swap them for service-specific
  attributes (e.g., SQL's `[VersionedRoute]` + `[BaseApiVersion]`) without
  forking the core.
- **Routing helper.** Optional generated `ApiVersionControllerSelector` (or
  similar) that implements the "newest controller with baseVersion ≤ requested
  version, within the same category" fallback rule.

### 2. ARM type replacement

ARM resource models share a large set of common envelope types
(`SystemData`, `TrackedResource`, `ProxyResource`, `ResourceIdentifier`,
`ManagedServiceIdentity`, `ErrorResponse`, `Operation`, …). The emitter must:

- Detect TypeSpec models that come from `Azure.ResourceManager.*` and map
  them to the corresponding `Azure.ResourceManager` runtime types instead of
  emitting duplicate POCOs in `Generated/Models/`.
- Provide a registered map of `<TypeSpec name> → <runtime CLR type>` that a
  service-specific extension can extend or override.
- Emit `using Azure.ResourceManager;` (or equivalent) in generated files that
  reference these types.

### 3. Service-extensibility surface

The framework choice (Microsoft.TypeSpec.Generator) gives us subclassing,
plugins, and visitors for free, but we still need to **expose the right
extension points from this emitter** so a service-specific package (e.g.,
"SQL flavour") can layer on top without forking:

- Factory methods on `AspNetServerCodeModelGenerator` that return the
  controller / model / version-registry providers (overridable from a
  subclass).
- `LibraryVisitor`s that downstream packages can register to rewrite
  attributes (e.g., `[Route]` → `[VersionedRoute]`), swap base classes, or
  duplicate methods across categories (Preview + Stable).
- A documented `tspconfig.yaml` knob (`generator-name`) for selecting the
  service-specific generator subclass.

### 4. Long-running operations and paging

- Detect `@pollingOperation` / Azure LRO patterns and project them onto the
  ASP.NET Core controller signature (`Task<ActionResult<ArmOperationStatus>>`
  + a generated polling controller, or the convention the pilot service
  prefers).
- Detect `@pageable` operations and emit the standard "list" shape
  (`Task<ActionResult<PagedResponse<T>>>` or equivalent).

### 5. Validation attributes

Map TypeSpec constraints to ASP.NET Core data-annotation attributes on POCO
properties and controller parameters:

- `@minLength` / `@maxLength` → `[StringLength]` / `[MinLength]` /
  `[MaxLength]`
- `@minValue` / `@maxValue` → `[Range]`
- `@pattern` → `[RegularExpression]`
- `@format` → format-specific attributes where they exist
- Required vs. optional → presence/absence of `[Required]`

### 6. Polymorphic discriminators

TypeSpec `@discriminator` unions need to project to a sensible C# inheritance
hierarchy plus a custom `JsonConverter` (or `[JsonPolymorphic]` /
`[JsonDerivedType]` on .NET 7+) so requests and responses serialize to the
right concrete type.

### 7. End-developer customization

Bring over the `partial class` + `[CodeGenType("Original")]` /
`[CodeGenMember("Original")]` story from `Azure.Generator` so service teams
can rename, retype, internalize, or replace individual generated members
without changing the spec.

### 8. Documentation, samples, and onboarding

- Service-author guide: how to lay out a project, where to put concrete
  controllers, how to wire DI, how to register the generated routing helper.
- Sample service: a small ARM RP end-to-end using only generated scaffolding.
- Migration guide for existing hand-written ARM controllers.

## Out of scope (for now)

- Generating non-controller infrastructure: hosting, DI registration,
  `Program.cs`, configuration. Service authors continue to own these.
- Generating client SDKs from the same spec — that is the job of
  `@azure-typespec/http-client-csharp` and friends.
