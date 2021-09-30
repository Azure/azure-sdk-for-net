# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Added support for API version 2021-07-15-preview.
- Added `QuestionAnsweringClientOptions.DefaultLanguage` to specify a client default, and the `language` parameters of `QueryTextOptions` optional.

### Breaking Changes

- Made `projectName` and `deploymentName` parameters required for `QuestionAnsweringClient` methods.
- Moved `QueryKnowledgeBaseOptions`, `QueryTextOptions`, and `TextRecord` to `Azure.AI.Language.QuestionAnswering` namespace.
- Removed `QueryTextOptions.StringIndexType` property and will always pass `StringIndexType.Utf16CodeUnit` for .NET.
- Renamed "CompoundOperation" to "LogicalOperation" in properties and type names.

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2021-07-27)

- Initial release which supports querying of knowledge bases and text records.
