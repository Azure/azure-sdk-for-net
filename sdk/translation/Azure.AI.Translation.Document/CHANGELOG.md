# Release History

## 2.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.0.0 (2024-11-15)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.


### Other Changes
- Renamed SingleDocumentTranslationClient's API from `document_translate` to `translate`

## 2.0.0-beta.2 (2024-07-05)

### Features Added
- Single document translation client can be created using endpoint alone, mainly for SDK to work against containers.

### Bugs Fixed
- SourceInput options which is a part of TranslationInput is now public. This allows users to enter source language, source storage, and document filter prefix and suffix.

## 2.0.0-beta.1 (2024-05-07)

### Features Added
- `documenttranslate` is the method added to submit a single/synchronous document translation request to the Document Translation service.
- `DocumentTranslateContent` has been added to specify the `documenttranslate` request content.
- Added `getSupportedFormats` that returns a list of supported documents and glossaries by the Document Translation service.

### Breaking Changes
- Version `v1.0` is not supported
- Renamed property `FormatType` to `FileFormatType`

## 1.0.0 (2022-06-07)

### Features Added
- Added optional parameter `categoryId` to the `DocumentTranslationInput.AddTarget`.
- Added property `Ascending` to type `DocumentFilterOrder` and `TranslationFilterOrder`.
- `DocumentTranslationAudience` has been added to allow the user to select the Azure cloud where the resource is located.

### Breaking Changes
- Renamed type `StorageInputType` to `StorageInputUriKind`.
- Renamed property `StorageType` to `StorageUriKind` in `DocumentTranslationInput`.
- Renamed parameter `asc` to `ascending` in `TranslationFilterOrder` constructor.
- The following properties inside of the `DocumentTranslationOperation` class will throw an `InvalidOperationException` if they are accessed and the LRO hasn't made a request to the service:
  - `CreatedOn`
  - `DocumentsCanceled`
  - `DocumentsFailed`
  - `DocumentsInProgress`
  - `DocumentsNotStarted`
  - `DocumentsSucceeded`
  - `DocumentsTotal`
  - `LastModified`
  - `Status`

### Bugs Fixed
- In `DocumentTranslationOperation`, `Cancel` calls won't overwrite the response from `GetRawResponse` anymore.

## 1.0.0-beta.6 (2021-11-09)

### Breaking Changes
- Removed types `DocumentTranslationError` and `DocumentTranslationErrorCode`. These affected the classes `DocumentStatusResult` and `TranslationStatusResult`. Errors in both classes are now exposed as `ResponseError`.
- Renamed method `DocumentStatus` to `DocumentStatusResult` in `DocumentTranslationModelFactory`, which now takes a `BinaryData` type instead of `DocumentTranslationError`.
- Renamed method `TranslationStatus` to `TranslationStatusResult` in `DocumentTranslationModelFactory`, which now takes a `BinaryData` type instead of `DocumentTranslationError`.

## 1.0.0-beta.5 (2021-09-08)

### Breaking Changes
- `DocumentFilter.CreatedAfter` and `DocumentFilter.CreatedBefore` are now nullable properties.
- Renamed method `GetAllTranslationStatuses` to `GetTranslationStatuses`.
- Renamed method `GetAllDocumentStatuses` to `GetDocumentStatuses`.
- Renamed type `TranslationFilter` to `GetTranslationStatusesOptions`.
- Renamed type `DocumentFilter` to `GetDocumentStatusesOptions`.
- Renamed type `DocumentStatus` to `DocumentStatusResult`.
- Renamed type `TranslationStatus` to `TranslationStatusResult`.
- Renamed type `FileFormat` to `DocumentTranslationFileFormat`.
- Renamed property `TranslatedTo` to `TranslatedToLanguageCode` in `DocumentStatusResult`.
- Renamed parameter `asc` to `ascending` in `DocumentStatusResult` constructor.
- Changed spelling of `cancelled`/`cancelling` to `canceled`/`cancelling`. The following changes have been made:
  - property `DocumentsCancelled` to `DocumentsCanceled` in `DocumentTranslationOperation`
  - property `DocumentsCancelled` to `DocumentsCanceled` in `TranslationStatusResult`
  - value `Cancelled` to `Canceled` in `DocumentTranslationOperation`
  - value `Cancelling` to `Canceling` in `DocumentTranslationOperation`
  - parameter `Cancelled` to `Canceled` in function `DocumentTranslationModelFactory.TranslationStatus` 

### Bugs Fixed
- `GetDocumentStasus` and `GetDocumentStatusesAsync` no longer set CreatedAfter and CreatedBefore if the user doesn't set it.
- In `GetTranslationStatuses`, `GetDocumentStatuses` and their async counterparts; URL parameters for `Ids`, `Statuses`, and `OrderBy` are no longer included in the request URL if the user does not set them.

## 1.0.0-beta.4 (2021-08-10)

### Features Added
- Added filtering options to methods `GetAllTranslationStatuses`, `GetAllDocumentStatuses` and their async equivalent.
- Added `DocumentTranslationModelFactory` static class to support mocking model types. 

### Breaking Changes
- Properties `Suffix` and `Prefix` are now available under `TranslationSource` instead of in type `DocumentFilter`.
- Type `DocumentTranslationError` is now a struct.
- Type `StorageInputType` is now a regular enum instead of an extensible enum.

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
