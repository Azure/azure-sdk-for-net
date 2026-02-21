# Release History

## 1.0.0 (2026-02-11)

### Features Added

- GA release of Azure AI Content Understanding client library for .NET
- Each `ContentField` subclass now exposes a strongly-typed `Value` property (e.g., `StringField.Value` returns `string?`, `NumberField.Value` returns `double?`), replacing the verbose `ValueString`, `ValueNumber`, etc. properties
- Added support for `clientRequestId` parameter in `Analyze` and `AnalyzeBinary` operations
- Updated to latest service API version `2025-11-01`

### Breaking Changes

The following renames were made to align with [Azure SDK for .NET design guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html).

#### Type renames

| 1.0.0-beta.1 | 1.0.0 |
|---|---|
| `AnalyzeInput` | `AnalysisInput` |
| `AnalyzeResult` | `AnalysisResult` |
| `DateField` | `DateTimeOffsetField` |

#### Property renames

| Type | 1.0.0-beta.1 | 1.0.0 |
|---|---|---|
| `AnalysisInput` (was `AnalyzeInput`) | `Url` | `Uri` |
| `ContentAnalyzer` | `DynamicFieldSchema` | `HasDynamicFieldSchema` |
| `ContentAnalyzerConfig` | `ReturnDetails` | `ShouldReturnDetails` |
| `ContentAnalyzerConfig` | `OmitContent` | `ShouldOmitContent` |

#### Field value properties unified to `Value`

All `ContentField` subclasses replace the verbose `Value{Type}` property with a unified `Value` property:

| Type | 1.0.0-beta.1 | 1.0.0 |
|---|---|---|
| `StringField` | `ValueString` (`string`) | `Value` (`string?`) |
| `NumberField` | `ValueNumber` (`double?`) | `Value` (`double?`) |
| `IntegerField` | `ValueInteger` (`long?`) | `Value` (`long?`) |
| `BooleanField` | `ValueBoolean` (`bool?`) | `Value` (`bool?`) |
| `DateTimeOffsetField` (was `DateField`) | `ValueDate` (`DateTimeOffset?`) | `Value` (`DateTimeOffset?`) |
| `TimeField` | `ValueTime` (`TimeSpan?`) | `Value` (`TimeSpan?`) |
| `ArrayField` | `ValueArray` (`IList<ContentField>`) | `Value` (`IList<ContentField>?`) |
| `ObjectField` | `ValueObject` (`IDictionary<string, ContentField>`) | `Value` (`IDictionary<string, ContentField>?`) |
| `JsonField` | `ValueJson` (`BinaryData`) | `Value` (`BinaryData?`) |

#### Method signature changes

- `Analyze` and `AnalyzeAsync`: The `inputs` parameter changed from `IEnumerable<AnalyzeInput>?` (optional) to `IEnumerable<AnalysisInput>` (required)
- `AnalyzeBinary` and `AnalyzeBinaryAsync`: Parameter order changed — `inputRange` moved before `contentType`


## 1.0.0-beta.1 (2026-01-08)

### Features Added
- Initial release of Azure AI Content Understanding client library for .NET
- Added `ContentUnderstandingClient` for analyzing documents, audio, and video content
- Analyze operations return `Operation<AnalysisResult>` with the operation ID accessible via the `Id` property

