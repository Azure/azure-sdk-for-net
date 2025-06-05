# Release History

## 1.0.0 (2025-01-14)

### Features Added

- Introduced `DeidentificationCustomizationOptions` and `DeidentificationJobCustomizationOptions` models
  - Created `SurrogateLocale` field in these models
  - Moved `RedactionFormat` field into these models
- Introduced `Overwrite` flag in `TargetStorageLocation` model

### Breaking Changes

- Changed `outputPrefix` behavior from including `jobName` to prefix replacement method
- Changed `Path` field to `Location` in `SourceStorageLocation` and `TargetStorageLocation`
- Deprecated `DocumentDataType`
- Deprecated `Path` and `Location` from `TaggerResult` model

## 1.0.0-beta.1 (2024-08-15)

- Azure Health Deidentification client library

### Features Added

- Azure Health Deidentification client library
