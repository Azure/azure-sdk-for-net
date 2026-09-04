# Release History

## 1.2.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.3 (2026-08-11)

### Features Added

- Added support for service API version `2026-06-01-preview`, which is the default service API version for this beta package.
- Added inline analysis convenience APIs `AnalyzeInline` / `AnalyzeInlineAsync` and `AnalyzeBinaryInline` / `AnalyzeBinaryInlineAsync`, available only with service API version `2026-06-01-preview`. These return `AnalysisResult` in a single HTTP 200 response (no LRO polling) and throw `RequestFailedException` when the inline operation status is not Succeeded. `AnalyzeBinaryInline*` includes a `ContentRange?` convenience overload matching `AnalyzeBinary*`. See [Sample 18](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample18_AnalyzeInline.md) and [Sample 19](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample19_AnalyzeBinaryInline.md).
- Added `AnalyzeBinaryOptions` and corresponding `AnalyzeBinary*` / `AnalyzeBinaryInline*` overloads for binary analyze request settings (`ContentRange`, `ContentType`, `ProcessingLocation`, and future options). Required analyzer ID and binary input live on the options bag. See [Sample 01](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md) and [Sample 19](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample19_AnalyzeBinaryInline.md).
- Added `AnalyzeOptions` and corresponding `Analyze*` / `AnalyzeInline*` overloads for JSON analyze request settings (`ModelDeployments`, `ProcessingLocation`, and future options). Required analyzer ID and inputs live on the options bag.
- Added semantic chunking for custom analyzers in `2026-06-01-preview`: configure `ContentAnalyzerConfig.ChunkingStrategy` with `SemanticChunkingStrategy` (for example `MaxTokens`) when creating an analyzer, then read `DocumentContent.Chunks` (`DocumentChunk` spans into markdown) from the analysis result. See [Sample 17](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample17_AnalyzeChunking.md).
- Added analyzer workflow selection via `ContentAnalyzerConfig.Workflow` / `ContentAnalyzerWorkflow` for `2026-06-01-preview`. Omit `Workflow` for standard extraction, or set `ContentAnalyzerWorkflow.Agentic` when an answer must be built from evidence. See [Sample 16](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample16_CreateAnalyzerWorkflow.md).
- Added signature detection via `DocumentSignature` / `DocumentContent.Signatures` for `2026-06-01-preview` when layout extraction is enabled (`EnableLayout`, including `prebuilt-layout`). See [Detect signatures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample_Advanced_DetectSignatures.md) and [Sample 10](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample10_AnalyzeConfigs.md).
- Added in-page segmentation opt-in via `ContentAnalyzerConfig.AllowInPageSegments` for `2026-06-01-preview`. Used with `EnableSegment`, this allows classification segments to split within a page (for example supplemental statements appended after a K-1 tax form) instead of only at page boundaries. See [Classify in-page segments](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample_Advanced_ClassifyInPageSegments.md).
- Added embedded document metadata via `AnalysisContent.Metadata` for `2026-06-01-preview`. See [Extract document metadata](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample_Advanced_ExtractDocumentMetadata.md).
- Added analysis diagnostics via `AnalysisResult.Infos` for `2026-06-01-preview`. The collection exposes service information as `ResponseError` values for troubleshooting. See [Analysis diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample_Advanced_AnalysisDiagnostics.md).
- Updated `ToLlmInput` (preview) to emit analysis-result metadata (`AnalysisContent.Metadata`) under a `metadata:` front-matter block. See [ToLlmInput](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample_Advanced_ToLlmInput.md).
- Added `AnalyzeOperationExtensions.GetUsageDetails()` to return generated `UsageDetails` from a completed analyze LRO (`Operation<AnalysisResult>`) or inline analyze response (`Response<AnalysisResult>`). See [Sample 03](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md), [Sample 18](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample18_AnalyzeInline.md), and [Sample 19](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample19_AnalyzeBinaryInline.md). `GetUsage()` / `AnalyzeUsageDetails` are obsolete and retained for 1.1.0 compatibility.

### Other Changes

- `ToLlmInput` (preview): renamed the optional caller dictionary from `metadata` to `customMetadata` and emit it under a nested `customMetadata:` front-matter block (service metadata stays under `metadata:`). Changes the preview API from `1.2.0-beta.1`; not a stable-breaking change.

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
