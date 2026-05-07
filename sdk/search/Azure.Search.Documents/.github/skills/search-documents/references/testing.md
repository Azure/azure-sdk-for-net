# Azure.Search.Documents — Testing Reference

## Contents
- [Coverage tiers](#coverage-tiers)
- [Version matrix rules](#version-matrix-rules)
- [Preview isolation](#preview-isolation)
- [Test type selection](#test-type-selection)
- [Post-regen test workflow](#post-regen-test-workflow)
- [ModelSerializationMockTests scope](#modelserializationmocktests-scope)
- [Traps](#traps)

**Related:** [architecture.md](./architecture.md) — service version enum, SearchClientOptions switch arms

---

## Coverage Tiers

| Tier | File | Discovery | Purpose |
|---|---|---|---|
| 1 | `TypeCompleteness/ModelDiscoveryTests.cs` | Automatic (reflection) | Every `IJsonModel<T>` — builder exists, Read/Write don't crash |
| 2 | `TypeCompleteness/PolymorphicRoundtripTests.cs` | Automatic (reflection) | Every subtype of `SearchTestHelpers.PolymorphicBaseTypes` |
| 3 | `Models/ModelSerializationMockTests.cs` | Manual (curated) | Specific property values survive roundtrip for high-value types |

Tiers 1+2 self-heal on regen — no intervention needed. Tier 3 is intentionally selective.

**When `PolymorphicBaseTypes` needs updating:** If a new abstract base class is added to `src/Generated/Models/` that has concrete subtypes (e.g., a new `VectorSearchAlgorithm` hierarchy), add it to the list in `SearchTestHelpers.cs`. The `AllBaseTypesHaveSubtypes` test guards against stale entries.

---

## Version Matrix Rules

`SearchTestBase.cs` is the **single source of truth**. Constants `CurrentGAVersion` / `CurrentPreviewVersion` control what all tests run against.

| Rule | Rationale |
|---|---|
| Never add `[ClientTestFixture]` on derived classes | Inherited from `SearchTestBase` — overrides fragment the matrix |
| Use `[ServiceVersion(Min = ...)]` only when a test would **fail** against an older version | Not for documentation — costs nothing to run against all versions in playback |
| `#if AZURE_SEARCH_PREVIEW` is compile-time; `[ServiceVersion]` is runtime | Different mechanisms for different problems — don't mix them |
| `AZURE_SEARCH_PREVIEW` auto-defined when `<Version>` contains `-` | Set in both `src/*.csproj` and `tests/*.csproj` via `$(Version.Contains('-'))` |

**Updating the matrix:** Change `CurrentGAVersion` (and optionally `CurrentPreviewVersion`). All tests follow automatically.

---

## Preview Isolation

Preview tests live in `*.Preview.cs` partial class files, wrapped entirely in `#if AZURE_SEARCH_PREVIEW`:

```
SearchTests.Preview.cs
SearchIndexClientTests.Preview.cs
SearchIndexerClientTests.Preview.cs
```

**GA promotion:** Remove `#if`/`#endif` wrapper → update `[ServiceVersion(Min)]` to new GA version → optionally merge into main file.

---

## Test Type Selection

| Scenario | Base class | Key detail |
|---|---|---|
| Service interaction (CRUD, queries) | `SearchTestBase` | Uses `SearchResources.Create*Async(this)` + recordings |
| Request payload validation | `ClientTestBase` | `MockTransport` — no recordings, instant |
| Type/convention scanning | None (`[TestFixture]`) | Reflection-based, no framework |
| Preview feature | `SearchTestBase` in `*.Preview.cs` | Compile-gated, `[ServiceVersion(Min = CurrentPreviewVersion)]` |
| Timing-sensitive (auto-flush) | `SearchTestBase` + `[LiveOnly]` | Cannot be recorded |
| Geo-limited (semantic search) | `SearchTestBase` + `[PlaybackOnly]` | Cannot run live in all regions |

**Mock test helpers:** `SearchTestHelpers.CreateMockSearchClient(...)`, `SearchTestHelpers.CreateMockJsonResponse(statusCode, json)`.

---

## Post-Regen Test Workflow

1. Run TypeCompleteness tests — failures **are** the to-do list.
2. New `SearchOptions` property → add 1 line to `SearchOptionsMockTests.SearchOptionProperties()`.
3. New client operation → write recorded test + mock test.
4. New preview feature → add to `*.Preview.cs`.
5. Full suite: `dotnet test --filter "TestCategory!=Live"`.

TypeCompleteness tests detect new models automatically. No manual model tracking needed for Tiers 1+2.

---

## ModelSerializationMockTests Scope

**Add when:** top-level resource type, complex custom converter, or previously-broken serialization.

**Skip when:** simple DTO, already tested by recorded integration tests, or Tiers 1+2 coverage is sufficient.

This is a curated quality gate, not a completeness checklist.

---

## Traps

| Trap | Detail |
|---|---|
| `SearchMockTests` uses `SearchClientOptions.LatestVersion` | Must stay in sync — if LatestVersion changes, mock response shapes may need updating |
| `SearchResources` disposes live resources | Always use `await using` — leaked resources hit quota limits |
| Recordings replay regardless of version string | Version matrix in playback is "free" — no reason to minimize it |
| `ModelDiscoveryTests` exclusion set | `SearchDocument` is excluded (dynamic bag type, not standard IJsonModel) |
