# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2021-07-07)
### Breaking changes

- Renamed property `DocumentId` to `Id`in `DocumentStatusResult`.
- Renamed property `TranslationId` to `Id`in `TranslationStatusResult`
- Renamed type `TranslationStatusResult` to `TranslationStatus`.
- Renamed type `DocumentStatusResult` to `DocumentStatus`.
- Renamed enum `TranslationStatus` to `DocumentTranslationStatus`.
- Renamed method `GetDocumentFormats` to `GetSupportedDocumentFormats`.
- Renamed method `GetGlossaryFormats` to `GetSupportedGlossaryFormats`.
- Removed property `HasCompleted` from types `DocumentStatusResult` and `TranslationStatusResult`.

## 1.0.0-beta.2 (2021-06-08)

### New Features

- Added support for authentication with Azure Active Directory.

### Breaking changes

- This version of the SDK defaults to the latest supported service version, which currently is `v1.0`.
- Renamed method `GetTranslations` to `GetAllTranslationStatuses` and same for the async equivalent method.
- Renamed property `TranslateTo` to `TranslatedTo` in type `DocumentStatusResult`.

## 1.0.0-beta.1 (2021-04-06)

This is the first beta package of the Azure.AI.Translation.Document client library that targets the service version `1.0-preview.1`.
This package's documentation and samples demonstrate the new API.
