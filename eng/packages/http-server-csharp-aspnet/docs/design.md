# Server Code Generation Design

## The API-first vision

Today, ARM resource provider teams maintain hand-written ASP.NET controllers
alongside swagger that is authored separately. The two drift, and reconciling
the drift forces breaking swagger corrections that cascade into SDKs, CLI, and
PowerShell.

API-first inverts the relationship: the **TypeSpec specification is the single
source of truth** for the API contract, and a per-service emitter generates the
server-side scaffolding that implements it.

```
TypeSpec spec  ──►  emitter  ──►  abstract controllers + models
                                  └──►  team writes concrete controllers
                                        that derive from the generated bases
```

Concretely, for each TypeSpec interface the emitter produces an abstract
`<Name>ControllerBase : ControllerBase` decorated with `[ApiController]` and one
abstract `Task<ActionResult<T>> <Name>Async(...)` method per operation, with
`[Http*("route")]` on each method and `[FromRoute]`/`[FromQuery]`/`[FromHeader]`/
`[FromBody]` on each parameter. For each TypeSpec model, a POCO. The team
derives a concrete controller from the generated base and provides the
implementation.

### Benefits

| Benefit                       | How                                                                                                                                |
| ----------------------------- | ---------------------------------------------------------------------------------------------------------------------------------- |
| Single source of truth        | Spec, server scaffolding, and (eventually) client SDKs all derive from one TypeSpec definition. No swagger-vs-implementation drift. |
| Spec-level API review         | Reviewers read a declarative spec, not scattered controller code.                                                                   |
| Breaking-change detection     | Caught at spec-compile time via TypeSpec linters, before code is generated.                                                         |
| Reduced boilerplate           | Routing, models, and controller scaffolding are generated; teams focus on business logic.                                           |

## The incremental versioning pattern

ARM services version APIs by adding a new version directory containing **only
the operations whose request/response signature changed**. A version-aware
routing framework (e.g., `ApiVersionControllerSelector`) resolves each request
to the newest controller whose base version is `≤` the requested `api-version`.

```
ARM/
├── V20251101/Controllers/MyResource.cs   ← all operations (first version)
├── V20251201/Controllers/MyResource.cs   ← only operations that changed
└── V20260201/Controllers/MyResource.cs   ← only operations that changed
```

This pattern is what makes server code generation tractable for ARM:

1. **Versioning is the hardest part to get right manually.** Identifying which
   operations are impacted by a model change requires tracing type dependencies
   through the entire API surface — adding a property to a shared model might
   affect Create/Get/Update/List but not Delete. The emitter automates this
   analysis by diffing operation fingerprints across versions.
2. **The incremental pattern keeps generated output minimal.** Only changed
   operations need new controllers; unchanged operations fall through to an
   older version's controller via routing.
3. **Version history is explicit in TypeSpec.** `@added`, `@removed`, and
   `@typeChangedFrom` decorators make the timeline declarative and
   machine-readable, so the emitter can reason about cross-version differences
   without external metadata.
4. **Safe continuous regeneration.** Generated abstract bases and hand-written
   concrete implementations live in separate files. The emitter can regenerate
   at any time without touching business logic.

## Generated vs. hand-written separation

| File                                            | Owner             | Regeneration behaviour      |
| ----------------------------------------------- | ----------------- | --------------------------- |
| `Generated/Models/*.cs`                         | Emitter           | Overwritten on every build  |
| `Generated/Controllers/*ControllerBase.cs`      | Emitter           | Overwritten on every build  |
| `Controllers/*Controller.cs` (concrete classes) | Service team      | Never touched by the emitter |

When the spec changes incrementally, regenerated abstract bases gain new method
signatures and the C# compiler tells the developer exactly which abstract
methods need an implementation. When the spec changes in a breaking way (e.g.,
a property type changed, a parameter was removed), existing concrete overrides
fail to compile — surfacing the breakage as a build error before deploy.

## Implementation status in this package

This emitter currently implements the **non-versioned** subset of the design:

- ✅ POCO models per TypeSpec model
- ✅ Abstract `<Name>ControllerBase` per TypeSpec interface, with operation
  signatures, route templates, and parameter binding attributes
- ✅ Generated/hand-written separation via abstract base classes
- ⏳ Version registry, incremental per-version directories, and impact
  analysis driven by `@added`/`@removed`/`@typeChangedFrom`
- ⏳ Polymorphic discriminators, paging helpers, validation attributes

See [framework-choice.md](./framework-choice.md) for why this emitter is built
on Microsoft.TypeSpec.Generator rather than Alloy.
