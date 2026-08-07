# Roadmap

This document tracks the major features that are not yet implemented in
`@azure-typespec/http-server-csharp-aspnet`. Items are roughly ordered by
priority, but priorities will shift as we onboard pilot services.

## ✅ Implemented today

- POCO models per TypeSpec model in the current API version folder
  (`src/Generated/V<YYYYMMDD>/Models/`)
- Abstract `<Name>ControllerBase` per TypeSpec interface, decorated with
  `[ApiController]` / `[ApiVersion]`, inheriting `ControllerBase`
- One abstract `Task<ActionResult<T>> <Name>Async(...)` method per operation
  with the correct `[Http*("route")]` attribute
- Per-parameter binding attributes
  (`[FromRoute]` / `[FromQuery]` / `[FromHeader]` / `[FromBody]`) that mirror
  TypeSpec `@path` / `@query` / `@header` / `@body`
- Generated/hand-written separation: generated abstract bases live under
  `Generated/`, concrete controllers live in user-owned files
- End-to-end test scenario that generates contracts into an existing ASP.NET
  Core project (`generator/TestProjects/Local/AzureSql/src`) while preserving
  user-owned concrete controllers outside `src/Generated/`
- ASP.NET Core integration tests for the AzureSql scenario using
  `WebApplicationFactory<Program>` and real HTTP requests against generated
  routes
- Current-version changed-set generation for TypeSpec `@versioned` services:
  the emitter compares the selected API version with the previous version using
  TypeSpec versioning projections, keeps only changed operations by TCGC
  cross-language definition ID, and emits the transitive model/enum/union closure
  required by those operations
- Incremental per-version output layout:
  `Generated/V<YYYYMMDD>/Controllers/<Name>ControllerBase.cs` contains only the
  operations impacted in the selected version, while
  `Generated/V<YYYYMMDD>/Models/*.cs` contains only the models related to those
  changed operations
- Generated ASP.NET Core version metadata: `[ApiVersion]` on controller bases
- AzureSql versioning integration tests that verify the latest changed-set
  controller shape and latest model shape

## 🔜 Planned

### 1. Versioning follow-ups

The current changed-set generation path is implemented. Remaining work for
production ARM services:

- **Operation-diff fidelity.** Extend TypeSpec snapshot fingerprints to cover
  more protocol metadata and versioning decorators if services need finer
  changed-set boundaries than the current request/response/model graph diff.
- **Versioning attributes on generated controllers.** Default to `[ApiVersion]`
  / `[Route]`; allow downstream extensions to swap them for service-specific
  attributes (e.g., SQL's `[VersionedRoute]` + `[BaseApiVersion]`) without
  forking the core.
- **Routing helper.** Optional generated `ApiVersionControllerSelector` (or
  similar) that lets service-owned controllers from previous generated
  changed-sets participate in fallback routing.

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

- Service-author guide: how to lay out an existing ASP.NET Core project, where
  to put concrete controllers, how to wire DI, how to register the generated
  routing helper.
- Sample service: a small ARM RP end-to-end using only generated scaffolding.
- Migration guide for existing hand-written ARM controllers.

## Out of scope (for now)

- Generating non-controller infrastructure: hosting, DI registration,
  `Program.cs`, configuration. Service authors continue to own these.
- Generating client SDKs from the same spec — that is the job of
  `@azure-typespec/http-client-csharp` and friends.
