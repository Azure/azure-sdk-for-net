# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2026-02-11)

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

