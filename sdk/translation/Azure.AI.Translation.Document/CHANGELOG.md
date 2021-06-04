# Release History

## 1.0.0-beta.2 (Unreleased)

### New Features

- Added support for authentication with Azure Active Directory.

### Breaking changes

- This version of the SDK defaults to the latest supported service version, which currently is `v1.0`.
- Renamed method `GetTranslations` to `GetAllTranslationStatuses` and same for the async equivalent method.
- Renamed property `TranslateTo` to `TranslatedTo` in type `DocumentStatusResult`.

## 1.0.0-beta.1 (2021-04-06)

This is the first beta package of the Azure.AI.Translation.Document client library that targets the service version `1.0-preview.1`.
This package's documentation and samples demonstrate the new API.
