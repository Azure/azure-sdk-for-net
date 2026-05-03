# Why Microsoft.TypeSpec.Generator?

## The two candidate frameworks

|                | Framework                                                                                                            | Language        |
| -------------- | -------------------------------------------------------------------------------------------------------------------- | --------------- |
| **Approach A** | [Alloy](https://alloy-framework.github.io/alloy/) on top of [`@typespec/emitter-framework`](https://typespec.io/docs/extending-typespec/emitter-framework) | TypeScript / JSX |
| **Approach B** | [Microsoft.TypeSpec.Generator (MTG)](https://github.com/microsoft/typespec/tree/main/packages/http-client-csharp)    | C# (TS shim)    |

Both can produce identical C#. The decisive factor is not output quality — it
is the **contract the framework defines for an extending team**.

## The driving requirement: service-specific extensions

A generic "ARM server code emitter" is not enough on its own. Each ARM service
has bespoke conventions:

- Azure SQL uses `[VersionedRoute]` / `[BaseApiVersion]`, an `ApiVersion` enum
  with Preview/Stable categories, shared `VCommon/BaseDatabase<T>` base classes,
  and a custom `ApiVersionControllerSelector`.
- Other services (Compute, Storage, …) have their own equivalents.

The framework must therefore let a downstream service:

1. **Replace or wrap individual outputs** — emit `[VersionedRoute]` instead of
   `[Route]`, swap the controller base class, etc.
2. **Inject new outputs** — add a generated `Constants/RouteConstants.cs` or a
   service-specific manifest.
3. **Hook into the type/operation pipeline** — remove or rewrite types, attach
   extra metadata.
4. **Ship as a separate package** — versioned independently from the generic
   core, no fork required.

## How each framework scores

| Capability                                  | Alloy                                                | MTG                                                                       |
| ------------------------------------------- | ---------------------------------------------------- | ------------------------------------------------------------------------- |
| Extension as an installable package         | No built-in contract; conventions must be invented   | First-class: `CodeModelGenerator` subclass + `GeneratorPlugin` DLLs       |
| Replace one piece of output                 | Component composition / context override (per convention) | Override one factory method or register one `LibraryVisitor`              |
| Add new outputs                             | Append a JSX child to the tree                       | Add a new `TypeProvider` in the generator subclass                        |
| Cross-cutting transforms                    | None standard — write a pre-/post-processor          | `LibraryVisitor` pipeline                                                 |
| End-developer customization (per spec)      | Not supported — spec-only or fork the component      | `partial class` + `[CodeGenType]` / `[CodeGenMember]` attributes          |
| Multi-language reuse of core                | Yes (Alloy supports C#/Java/TS)                      | No — .NET only                                                            |
| Production precedent for service extension  | None published                                       | `Azure.Generator` extending `ScmCodeModelGenerator` in `azure-sdk-for-net` |

## Why MTG wins for this charter

MTG ships a documented, versioned, three-layer extension model — subclass /
plugin / visitor — plus an end-developer customization vocabulary
(`partial class` + `CodeGen*` attributes). The Azure SDK's `Azure.Generator`
is concrete proof that a downstream team can layer significant behaviour on
top of an upstream generator without forking it.

Alloy is a code-rendering framework, not an emitter framework. It can be made
extensible, but every extension point would be a convention we invent and
maintain ourselves, with no framework-level guarantees and no precedent of
another team actually doing it. Hardening Alloy into a "core + per-service
extension" package pair would essentially mean re-inventing what MTG already
provides.

## Trade-offs we accept

- **Two-process architecture.** Debugging spans TypeScript (`tsp compile` shim)
  and C# (`dotnet exec` generator). MTG already supports `--debug` to attach to
  the .NET generator.
- **Indirect output.** Code is built by mutating `TypeProvider` objects, not by
  writing JSX that "looks like" the output. This is exactly what makes
  visitor-based extension safe.
- **.NET only.** MTG cannot generate Java/Python servers. For ARM services
  (which are .NET on the server side) this is a non-issue.

## When to reconsider

If a future requirement emerges to generate **server code in multiple
languages** from the same emitter (e.g., Go or Java services), Alloy's
multi-language story becomes a real advantage and would justify revisiting the
decision.
