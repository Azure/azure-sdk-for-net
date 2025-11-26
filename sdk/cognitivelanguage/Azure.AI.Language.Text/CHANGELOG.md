# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2025-11-20)

This version of the client library defaults to the service API version `2025-11-15-preview`.

### Features Added

- Added support for **multiple redaction policies** in a single request.
- Added **synthetic replacement redaction**, enabling selected PII types (e.g., Person, Email) to be replaced with realistic synthetic values rather than masked.
- Added **confidence score thresholding**, allowing customers to define minimum confidence levels�globally or per-entity�so that only entities meeting the required confidence are returned.
- Added **entity validation control** with the `disableEntityValidation` parameter, allowing users to bypass entity validation when needed.

## 1.0.0-beta.3 (2025-06-23)

### Features Added

- Added Value Exclusion, synonyms, and new entity types to the detection of Personally Identifiable Information (PII).
- Added support for analyze-text API Versions
  - 2025-05-15-preview

## 1.0.0-beta.2 (2024-12-15)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.
- Added support for analyze-text API Versions
  - 2024-11-01
  - 2024-11-15-preview

### Breaking Changes

- Removed support for analyze-text API Versions
  - 2023-11-15-preview

## 1.0.0-beta.1 (2024-08-06)

- Initial release

### Features Added

- Added support for analyze-text API Versions
  - 2022-05-01
  - 2023-04-01
  - 2023-11-15-preview
