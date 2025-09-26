# Release History

## 1.1.0-beta.1 (2025-09-30)

### Features Added
- Added `DeidentificationOperationType.SurrogateOnly`, which returns output text where user-defined PHI entities are replaced with realistic replacement values. When using this operation, include `DeidentificationContent.TaggedEntities`, which allows user input of PHI entities detected in the input text. The service will skip tagging and apply surrogation directly to the user-defined entities.
- Added `DeidentificationCustomizationOptions.InputLocale` to allow specifying the locale of the input text for TAG and REDACT operations.

## 1.0.0 (2025-04-23)

### Features Added

- Introduced `DeidentificationCustomizationOptions` and `DeidentificationJobCustomizationOptions` models
  - Created `SurrogateLocale` field in these models
  - Moved `RedactionFormat` field into these models
- Introduced `Overwrite` flag in `TargetStorageLocation` model

### Breaking Changes

- Changed method names in `DeidentificationClient` to match functionality:
    - Changed the `Deidentify*` method names to `DeidentifyText*`.
    - Changed the `CreateJob*` method names to `DeidentifyDocuments*`.
- Renamed the property `DeidentificationContent.Operation` to `OperationType`.
- Deprecated `DocumentDataType`.
- Changed the model `DeidentificationDocumentDetails`:
    - Renamed `Input` to `InputLocation`.
    - Renamed `Output` to `OutputLocation`.
- Changed the model `DeidentificationJob`
    - Renamed `Name` to `JobName`.
    - Renamed `Operation` to `OperationType`.
- Renamed the model `OperationState` to `OperationStatus`.
- Changed `Path` field to `Location` in `SourceStorageLocation` and `TargetStorageLocation`.
- Changed handling of `TargetStorageLocation.Prefix` to only include the provided value. Previously, the generated document locations would include the `DeidentificationJob.JobName` by default.
- Deprecated `Path` and `Location` from `TaggerResult` model.

## 1.0.0-beta.1 (2024-08-15)

- Azure Health Deidentification client library

### Features Added

- Azure Health Deidentification client library
