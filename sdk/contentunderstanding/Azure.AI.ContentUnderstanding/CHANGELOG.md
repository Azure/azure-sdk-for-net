# Release History

## 1.2.0-beta.3 (Unreleased)

### Features Added

- Added GitHub Copilot skills under `.github/skills/` to help users
  iteratively author custom analyzers in VS Code with Copilot:
  - **`cu-sdk-author-analyzer`** — author and refine a custom analyzer
    for a single document type (layout extraction → schema drafting →
    validation → batch test → agent review → refine cycle). Document
    modality only today; audio/video/image are planned.
  - **`cu-sdk-author-analyzer-classify-route`** — author and refine a
    classify-and-route pipeline for mixed-document packets (e.g.
    invoice + bank statement + loan application in one PDF), with
    per-category agent review.

  Both skills delegate to a small `cu-skill` .NET tool under
  `.github/skills/_shared/` that exposes three subcommands —
  `extract-layout`, `create-and-test`, and `create-and-test-router` —
  and a pure-C# `SchemaValidator` that catches structural mistakes
  (unknown `baseAnalyzerId`, missing `fieldSchema`, malformed
  `contentCategories` routes) before a service round-trip.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.2 (2026-06-11)

### Bugs Fixed

- Filtered service-emitted `LLMStats:` telemetry entries from the rendered `rai_warnings` front matter in `ToLlmInput`.

### Other Changes

- Updated `ToLlmInput` page markers from `<!-- page N -->` to `<!-- InputPageNumber: N -->` and avoided duplicate marker injection when the service markdown already includes `InputPageNumber` markers.

## 1.2.0-beta.1 (2026-04-30)

### Features Added

- Added `ToLlmInput` extension method that converts `AnalysisResult` into LLM-friendly text with YAML front matter and markdown content. Supports documents, audio/video, and classification hierarchies.

## 1.1.0 (2026-04-21)

### Features Added

- Added `ContentUnderstandingClientSettings` to support creating a `ContentUnderstandingClient` from `IConfiguration`, including configuration-based credential resolution and dependency injection registration.
- Added `AnalyzeUsageDetails` class and `AnalyzeOperationExtensions.GetUsage()` extension method to surface billing and token consumption details (`AnalyzeUsageDetails`) returned by the REST API.

## 1.0.2 (2026-03-11)

### Bugs Fixed

- Fixed `GetRehydrationToken()` returning `null` on operations started with `WaitUntil.Started`, preventing cross-process operation handoff ([#56840](https://github.com/Azure/azure-sdk-for-net/issues/56840))

## 1.0.1 (2026-03-06)

### Other Changes

- Set the default initial polling interval to 3 seconds for `Analyze`, `AnalyzeAsync`, `AnalyzeBinary`, and `AnalyzeBinaryAsync` to optimize polling efficiency.

## 1.0.0 (2026-02-27)

### Features Added

- GA release of Azure AI Content Understanding client library for .NET
- Each `ContentField` subclass now exposes a strongly-typed `Value` property (e.g., `ContentStringField.Value` returns `string?`, `ContentNumberField.Value` returns `double?`)
- Added `ContentSource` hierarchy (`DocumentSource`, `AudioVisualSource`) for strongly-typed parsing of grounding source strings on `ContentField`
- Added `ContentRange` value type with static factory methods (`Page`, `Pages`, `TimeRange`, etc.) for specifying content ranges on `AnalysisInput`
- Added convenience methods and indexers on `ContentArrayField` and `ContentObjectField`
- Added support for `clientRequestId` parameter in `Analyze` and `AnalyzeBinary` operations
- Updated to service API version `2025-11-01`

### Other Changes

The following API changes were made from the preview SDK (`1.0.0-beta.1`) to the GA SDK to align with [Azure SDK for .NET design guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html):

- **Type renames:** `AnalyzeInput` → `AnalysisInput`, `AnalyzeResult` → `AnalysisResult`, `MediaContent` → `AnalysisContent`, `DateField` → `ContentDateTimeOffsetField`, and all field subtypes prefixed with `Content` (e.g., `StringField` → `ContentStringField`)
- **Property renames:** `AnalysisInput.Url` → `Uri`, `ContentAnalyzer.DynamicFieldSchema` → `HasDynamicFieldSchema`, `ContentAnalyzerConfig.ReturnDetails` → `ShouldReturnDetails`, `ContentAnalyzerConfig.OmitContent` → `ShouldOmitContent`
- **Field value properties:** All `ContentField` subclasses use a unified `Value` property instead of type-specific properties (`ValueString`, `ValueNumber`, etc.)
- **Method signatures:** `Analyze`/`AnalyzeAsync` `inputs` parameter is now required; `AnalyzeBinary`/`AnalyzeBinaryAsync` parameter order changed


## 1.0.0-beta.1 (2026-01-08)

### Features Added
- Initial release of Azure AI Content Understanding client library for .NET
- Added `ContentUnderstandingClient` for analyzing documents, audio, and video content
- Analyze operations return `Operation<AnalysisResult>` with the operation ID accessible via the `Id` property

