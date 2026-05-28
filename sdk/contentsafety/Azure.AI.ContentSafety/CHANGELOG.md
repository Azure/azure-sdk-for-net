# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2023-12-15)

### Features Added

- Support Microsoft Entra ID Authentication
- Support 8 severity level for AnalyzeText

### Breaking Changes

Contract change for AnalyzeText, AnalyzeImage, Blocklist management related methods

#### AnalyzeText

- AnalyzeTextOptions
  - Renamed BreakByBlocklists to HaltOnBlocklistHit
  - Added AnalyzeTextOutputType
- AnalyzeTextResult
  - Renamed BlocklistsMatchResults to BlocklistsMatch
  - Replaced TextAnalyzeSeverityResult by TextCategoriesAnalysis

#### AnalyzeImage

- AnalyzeImageOptions
  - Replaced ImageData by ContentSafetyImageData
  - Added AnalyzeImageOutputType
- AnalyzeImageResult
  - Replaced ImageAnalyzeSeverityResult by ImageCategoriesAnalysis

#### Blocklist management

- Added BlocklistAsyncClient
- Renamed AddBlockItemsOptions to AddOrUpdateTextBlocklistItemsOptions
- Renamed AddBlockItemsResult to AddOrUpdateTextBlocklistItemsResult
- Renamed RemoveBlockItemsOptions to RemoveTextBlocklistItemsOptions
- Renamed TextBlockItemInfo to TextBlocklistItem

## 1.0.0-beta.1 (2023-06-06)

- Initial version
