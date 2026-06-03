# Preview-to-preview regression patterns

Each removal from the diff falls into one of these patterns. The skill cites the pattern ID in the report so the reader can act without re-investigating.

## P1 — Wrapper dropped over compound-string raw value

The previous version exposed a typed wrapper (e.g. `QueryAnswer`, `QueryCaption`, `QueryRewrites`) around a generated `*Raw` property that carries a compound wire format like `extractive|count-5,threshold-0.9`. The new generation regenerated the raw property but the wrapper partial class wasn't reapplied, so the user can only set the raw string.

**Signal**: removed type or property has a sibling `*Raw` string property still present in the current API listing OR in `src/Generated/Models/*.cs`.

**Fix**: re-add the wrapper partial class in `src/Models/` following the `QueryRewrites` reference implementation in [search-documents references/customization.md](../../search-documents/references/customization.md#compound--magic-string-properties). Gate with `#if AZURE_SEARCH_PREVIEW` if the wrapper is preview-only.

## P2 — Aggregator redirector dropped on `SearchOptions`

The previous version surfaced a generated property through `SearchOptions.SemanticSearch` or `SearchOptions.VectorSearch` via a private `[CodeGenMember(...)]` redirector. The new regen produced a flat property on `SearchOptions`, but the redirector to the aggregator was lost, so the public API has the wrong shape (flat instead of nested through the aggregator).

**Signal**: a property is missing from `SemanticSearchOptions` or `VectorSearchOptions` in the current listing, but a same-named property appears directly on `SearchOptions`.

**Fix**: re-add the private `[CodeGenMember("Xxx")] private T Xxx { get => ...; set => ...; }` redirector in `src/Options/SearchOptions.cs`. See [search-documents references/architecture.md](../../search-documents/references/architecture.md#searchoptions-architecture) for the layer rules.

## P3 — Preview type made internal via `@@access`

A `client.tsp` change moved a previously public type to `@@access("internal")`. The type is still generated but no longer visible.

**Signal**: removed type still appears in `src/Generated/Models/` but with `internal partial class` instead of `public`.

**Fix**: confirm intent. If accidental, revert the `@@access` in the spec. If intentional, document in the changelog.

## P4 — `#if AZURE_SEARCH_PREVIEW` block deleted instead of gated

A previously preview-gated property was removed from custom code during a refactor instead of being wrapped in `#if AZURE_SEARCH_PREVIEW`. Easy to miss because the property is gone from the listing even though the spec still defines it.

**Signal**: removed property still has a generated counterpart in `src/Generated/Models/`, and `git log` on the previous version shows the property was inside a custom partial class.

**Fix**: re-add the property wrapped in `#if AZURE_SEARCH_PREVIEW`/`#endif`. Do not delete preview features when promoting an API version — gate them.

## P5 — `ServiceVersion` enum value dropped

A previously published preview `SearchClientOptions.ServiceVersion.VYYYY_MM_DD_Preview` value disappeared from the enum without being replaced. Callers that pinned to that version now fail to compile.

**Signal**: missing member is on `Azure.Search.Documents.SearchClientOptions+ServiceVersion`.

**Fix**: restore the enum value (keep stale preview enum values until the next preview ships, or until the value's API version is GA'd and removed from `Versions` in the spec). Update all six sync locations: enum member, `LatestVersion`, `TryGetServiceVersion`, `Validate`, `ToVersionString`, `ToServiceVersion` (see [search-documents](../../search-documents/SKILL.md) pitfall #4).

## P6 — Convenience method downgraded to protocol-only

`@@convenientAPI(op, false)` was added in `client.tsp`. The convenience overload (typed parameters, typed return) is gone; only the protocol method (`RequestContent` + `Response`) remains.

**Signal**: removed method has a matching method on the same client with `RequestContent` / `Response` signature still present.

**Fix**: confirm intent with the service team. If the convenience method should remain, remove the `@@convenientAPI(op, false)` from `client.tsp` and regenerate.

## P7 — Unknown

The removed symbol cannot be located in the current TypeSpec, the current generated code, or any current customization. Default to **REGRESSION — investigate** and flag for human review. Do not silently skip.

---

## Decision aid — picking the pattern

Given a removed symbol, ask in order:

1. Does a `*Raw` sibling exist in the current listing or `src/Generated/Models/`? → **P1**.
2. Does the same name appear flat on `SearchOptions` (when it used to be on `SemanticSearchOptions` / `VectorSearchOptions`)? → **P2**.
3. Does the type still exist in `src/Generated/Models/` as `internal`? → **P3**.
4. Was the previous symbol inside an `#if AZURE_SEARCH_PREVIEW` block in the previous code? → **P4** (likely a delete-instead-of-gate).
5. Is the symbol a `ServiceVersion` enum value? → **P5**.
6. Does the removed method have a sibling protocol method (taking `RequestContent`)? → **P6**.
7. None match? → **P7**.
