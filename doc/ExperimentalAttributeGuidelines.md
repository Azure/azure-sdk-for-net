# Guidelines: Using `ExperimentalAttribute` in Azure SDK for .NET

## Status

Draft. These guidelines describe how and when to apply
`System.Diagnostics.CodeAnalysis.ExperimentalAttribute` in Azure SDK for .NET
libraries.

Rules use the same imperative style as the Azure SDK design guidelines:
**DO**, **DO NOT**, **YOU SHOULD**, **YOU SHOULD NOT**, and **YOU MAY**.

## Background

`[Experimental]` (introduced in .NET 8 / C# 12) marks an API as not-yet-stable.
The compiler reports a **diagnostic at every call site** that consumes the API,
identified by a per-feature **diagnostic ID**. Consumers opt in by suppressing
that specific ID (recommended: via the project's `<NoWarn>` property). Because
each feature has its own ID, consenting to one experimental feature does **not**
consent to any other.

Authoritative references (baseline for these guidelines):

- [ExperimentalAttribute class](https://learn.microsoft.com/dotnet/api/system.diagnostics.codeanalysis.experimentalattribute)
- [Preview APIs — .NET](https://learn.microsoft.com/dotnet/fundamentals/runtime-libraries/preview-apis)
- [`Experimental` attributes — C# reference](https://learn.microsoft.com/dotnet/csharp/language-reference/attributes/general#experimental-attributes)
- [Choosing diagnostic IDs](https://learn.microsoft.com/dotnet/csharp/roslyn-sdk/choosing-diagnostic-ids)
- [CA2252: Opt in to preview features](https://learn.microsoft.com/dotnet/fundamentals/code-analysis/quality-rules/ca2252)

Key facts from the official docs:

- `[Experimental]` requires **no** runtime or language preview features; it only
  signals that an API is not stable yet. This is different from
  `[RequiresPreviewFeatures]`, which is reserved for APIs that depend on runtime
  or language preview behaviors. The resulting [CA2252](https://learn.microsoft.com/dotnet/fundamentals/code-analysis/quality-rules/ca2252)
  diagnostic can be satisfied either by annotating the calling member or type
  with `[RequiresPreviewFeatures]` itself (propagating the requirement to just
  that surface), or by opting in for the whole assembly with
  `<EnablePreviewFeatures>true</EnablePreviewFeatures>`.
- Valid targets: assembly, module, class, struct, interface, enum, delegate,
  constructor, method, property, event, field. `Inherited = false`.

## When to use `[Experimental]`

- ✅ **DO** use `[Experimental]` to ship a **not-yet-stable API inside an
  otherwise stable (GA) package**. This is its primary purpose: getting feedback
  on an API you may still change or remove, without blocking the stable release.
- ✅ **DO** mark an API `[Experimental]` when you are **not yet willing to commit
  to its shape** under the Azure SDK's backward-compatibility guarantees.
- ✅ **DO** treat `[Experimental]` APIs as changeable: they **MAY** change or be
  removed in any subsequent release, including a stable one, without the normal
  deprecation cycle.

## When NOT to use `[Experimental]`

- ❌ **DO NOT** add `[Experimental]` to an API that has **already GA'd**. Applying
  the attribute to a shipped stable type or member is itself a breaking change,
  since it introduces a new build diagnostic at every existing call site.
- ❌ **DO NOT** add `[Experimental]` to APIs that ship **only** in a **prerelease
  (beta) package**. A prerelease version suffix already communicates preview
  quality for the whole package; marking individual APIs is redundant noise.
- ❌ **DO NOT** use `[Experimental]` as a substitute for `[Obsolete]`. Use
  `[Obsolete]` to deprecate an existing stable API; use `[Experimental]` for a
  new API that has not yet stabilized.
- ❌ **DO NOT** use `[Experimental]` for APIs that require runtime or language
  preview features. Use `[RequiresPreviewFeatures]` for those entry points
  instead.
- ❌ **DO NOT** ship an API that is `[Experimental]` **forever**. It is a
  temporary state; every experimental API is expected to have a path to either
  stabilization or removal.

## Diagnostic IDs

- ✅ **DO** use a library-owned ID prefix, not a `SYSLIB*` / framework ID.
  Existing Azure libraries use short package-specific prefixes plus a number,
  e.g. `AAIP001` (Azure.AI.Projects), `SCME0002` (System.ClientModel
  extensions). Follow the established prefix for your package if one exists.
- ✅ **YOU SHOULD** use a **distinct ID per independent feature**, so a consumer
  opting into one experimental feature is not forced to silence unrelated ones.
  Reuse the **same** ID across all types/members that make up a **single**
  feature.
- ✅ **DO** keep IDs stable once published. Changing a published ID is a breaking
  change for anyone who has suppressed the old one. The only exception is
  aggregation (below).
- ✅ **DO** aggregate IDs when a member accrues a second, independent experimental
  surface. A member can carry only one `[Experimental]` attribute, so this is
  required whenever two IDs would otherwise need to apply at the same location
  — including when one of the two is a dependency's forwarded ID (see
  *Forwarding from dependencies*). Example: a member is experimental under code
  `A`; you then add a parameter whose type is experimental under code `B`. That
  member now surfaces both. Introduce a new aggregate code `C` representing
  `A + B` and change the member from `A` to `C`. Only remove `C` once **both**
  `A` and `B` have GA'd — never switch back to just `A` even if `B` GAs first
  (and vice versa), regardless of which party (you or a dependency) controls
  the GA timing of either individual ID.
- ✅ **DO** document every ID in an `experimentalfeatures.md` file in your library
  folder, describing the feature each ID covers and its current status, so
  consumers know what they are opting into.

## Granularity — where to put the attribute

- ✅ **YOU SHOULD** apply `[Experimental]` at the **narrowest scope** that covers
  the unstable surface — the specific type or member — rather than the whole
  assembly, so stable APIs in the same package are unaffected.
- ❌ **DO NOT** apply `[Experimental]` at **assembly or module** scope in a GA
  package; that would flag every API in the package as experimental.
- ✅ **YOU SHOULD** apply the attribute to the **type** when the entire type is
  experimental, rather than repeating it on every member.
- Because `Inherited = false`, ✅ **DO** re-apply the attribute on derived types
  or overrides if they are also intended to be experimental.

## Forwarding from dependencies

- ✅ **DO** forward the **dependency's own diagnostic ID**, unchanged, on any
  public API of yours that exposes, wraps, or requires an experimental API from
  a dependency — as long as that dependency is the **only** reason the
  member/type is experimental. The dependency controls when that feature GAs,
  so surface their ID directly rather than inventing your own, so your
  consumers track the upstream stability.
- ✅ **DO** aggregate instead of forwarding unchanged when the member **already**
  carries your own library-owned experimental ID. You cannot apply a second
  `[Experimental]` attribute to the same member, so follow the aggregation rule
  above: introduce a combined code (e.g. `C` for your ID `A` plus the
  dependency's forwarded ID `B`) and apply it in place of `A`. The dependency
  still only owns the GA timing of its own ID (`B`) — you **MUST NOT** retire
  the aggregate until `A` **and** `B` have both GA'd, even though `A` is
  entirely within your own control.
- ❌ **DO NOT** silently suppress a dependency's experimental diagnostic on a
  **public** API you ship as stable. Either forward it (with the dependency's ID,
  aggregating if needed) as experimental, or wait for the dependency's API to
  stabilize before building stable surface on it.
- ✅ **YOU MAY** suppress a dependency's experimental diagnostic **inline** (never
  via `<NoWarn>`) when the code that touches the experimental API is only
  reachable after the consumer has already interacted with a public surface that
  itself carries the warning. Example: serialization code that reads an
  experimental member is a no-op unless the consumer set that member — and
  setting it required opting into the experimental diagnostic — so accessing it
  during serialization is safe to suppress inline.

## Graduating (stabilizing) or removing an experimental API

- ✅ **DO** remove the `[Experimental]` attribute when the API stabilizes and is
  covered by the normal backward-compatibility guarantees. Removing the
  attribute is **not** a breaking change (it only stops emitting the diagnostic).
- ✅ **YOU SHOULD** stabilize or remove experimental APIs in a timely fashion
  rather than leaving them experimental indefinitely.
- ✅ **YOU SHOULD** retire a diagnostic ID once its feature graduates, rather than
  recycling it for an unrelated feature.
- ✅ **YOU MAY** keep a single global, library-wide ID to cover APIs or areas that
  have **never** GA'd, reusing it to keep the total number of active IDs to a
  minimum.

## Changelog and communication

- ✅ **YOU SHOULD** call out newly-added, changed, and removed experimental APIs in the
  package changelog, including the diagnostic ID needed to opt in.
- ✅ **YOU SHOULD** make clear in docs/samples that consuming an experimental API
  requires suppressing its diagnostic ID and accepting future breaking changes.
