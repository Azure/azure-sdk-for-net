# Release History

## 5.0.0 (2020-07-27)
- Re-release of version `1.0.1` with updated version `5.0.0`.

## 1.0.1 (2020-06-23)

### Fixes
- The document confidence scores for analyze sentiment now contains the values the Text Analytics service returns ([12889](https://github.com/Azure/azure-sdk-for-net/issues/12889)).
- `TextAnalyticsErrorCode` casing is now pascal case instead of camel case ([12888](https://github.com/Azure/azure-sdk-for-net/issues/12888)).

## 1.0.0 (2020-06-09)
- First stable release of Azure.AI.TextAnalytics package.

## 1.0.0-preview.5 (2020-05-27)
### Breaking changes
- Now targets the service's v3.0 API, instead of the v3.0-preview.1 API
- Removed `GraphemeLength` and `GraphemeOffset` from `CategorizedEntity`, `SentenceSentiment`, and `LinkedEntityMatch`.
- `GraphemeCount` in `TextDocumentStatistics` has been renamed to `CharacterCount`.
- `DetectedLanguage` property `SentimentScores` has been renamed to `ConfidenceScores`.
- `TextAnalyticsError` property `Code` has been renamed to `ErrorCode` and it is an `TextAnalyticsErrorCode` instead of a string.
- Single operation method `RecognizeEntitiesAsync` and `RecognizeEntities` now returns a `CategorizedEntityCollection`.
- Single operation method `ExtractKeyPhrasesAsync` and `ExtractKeyPhrases` now returns a `KeyPhraseCollection`.
- Single operation method `RecognizeLinkedEntitiesAsync` and `RecognizeLinkedEntities` now returns a `LinkedEntityCollection`.

### Added
- Added `Text` property to `SentenceSentiment`.
- `Warnings` property added to each document-level response object returned from the endpoints. It is a list of `TextAnalyticsWarnings`.

## 1.0.0-preview.4 (2020-04-07)
### Breaking changes
- Replaced `TextAnalyticsApiKeyCredential` with `AzureKeyCredential`.
- Renamed all input parameters `inputText` to `document`, and `inputs` to `documents`.
- Removed the `RecognizePiiEntities` endpoint and all related models (`RecognizePiiEntitiesResult` and `PiiEntity`) from this library.

### Added
- Refactor common properties from `DetectLanguageInput` and `TextDocumentInput` into it's own type `TextAnalyticsInput`.
- Mock support for the Text Analytics client with respective samples.
- Integration for ASP.NET Core.

## 1.0.0-preview.3 (2020-03-10)
### Breaking changes
- In both `DocumentSentiment` and `SentenceSentiment` property `SentimentScores` has been renamed to `ConfidenceScores`.
- In `LinkedEntity`, property `Id` has been renamed to `DataSourceEntityId`.
- Change wording in all documentation from `text inputs` to `documents`.
- Properties `Length` and `Offset` have been renamed to `GraphemeLength` and `GraphemeOffset` for the `SentenceSentiment`,
`CategorizedEntity`, `PiiEntity`, and `LinkedEntityMatch` objects, to make it clear that the offsets and lengths are in units of Unicode graphemes.
- `CharacterCount` in `TextDocumentStatistics` has been renamed to `GraphemeCount`.
- Unified `DocumentSentimentLabel` and `SentenceSentimentLabel` into `TextSentiment`.
- `SentimentConfidenceScorePerLabel` renamed to `SentimentConfidenceScores`.
- Extensible ENUM `SubCategory` has been deleted and managed as a string trhought the code.
- `Score` has been renamed to `ConfidenceScore` for types `CategorizedEntity`, `LinkedEntityMatch`, and `PiiEntity`.

### New Features
 - Added `DetectLanguageInput.None` for user convenience when overriding the default behavior of `CountryHint`.
 - Added `PersonType`, `Skill`, `Product`, `IP Address`, and `Event` to the `EntityCategory` ENUM.

## 1.0.0-preview.2 (2020-02-11)
### Breaking changes
- The `TextAnalyticsError` model has been simplified to an object with properties `Code`, `Message`, and `Target`.
- To use an API key as the credential for authenticating the client, a new credential class `TextAnalyticsApiKeyCredential("<api_key>")` must be passed in for the credential parameter.
Passing the API key as a string is no longer supported.
- Reference to `subcription key` changed to `API key`.
- `DetectLanguages` has been renamed to `DetectLanguage`. Same applies for `DetectLanguagesAsync` to `DetectLanguageAsync`.
- All batch overload methods have been renamed by adding the suffix `Batch` or `BatchAsync` accordingly. For example, instead of `AnalyzeSentimentAsync` now we have `AnalyzeSentimentBatchAsync`.
- Added a new parameter `TextAnalyticsRequestOptions` options to batch method overloads accepting a list of documents for allowing the users to opt for batch operation statistics.
- All single text operation methods now return an atomic type of the operation result. For example `DetectLanguage(String text)` returns a `DetectedLanguage` rather than a `DetectLanguageResult`.
- `NamedEntity.Type` and `NamedEntity.SubType` have been renamed to `NamedEntity.Category` and `NamedEntity.SubCategory`.
- `NamedEntity` has been renamed to `CategorizedEntity`.
- `RecognizeEntitiesResult` property `NamedEntities` has been renamed to `Entities`.
- `RecognizePiiEntitiesResult` now contains a list of `PiiEntity` instead of `NamedEntity`.
- `RecognizePiiEntitiesResult` property `NamedEntities` has been renamed to `Entities`.
- `RecognizeLinkedEntitiesResult` property `LinkedEntities` has been renamed to `Entities`.
- `DetectLanguageResult` no longer has a property `DetectedLanguages`. Use `PrimaryLanguage` to access the detected language in text.
- Created class `DocumentSentiment` that includes a list of `SentenceSentiment`.
- Sentiment label and sentiment scores are now part of `DocumentSentiment` and `SentenceSentiment`.
- Renamed `TextSentiment` to `SentenceSentiment`.
- Renamed `SentimentClass` to `SentimentLabel`.
- Extandable ENUMs created for `Category`, and `SubCategory`.

### New Features
Credential class `TextAnalyticsApiKeyCredential` provides an `UpdateCredential()` method which allows you to update the API key for long-lived clients.

### Fixes and improvements
A new `HasError` property has added to `<document>Collection` types to allow you to check if an operation on a particular document succeeded or failed.
If you try to access a result attribute where the operation was unsuccesful, an `InvalidOperationException` is raised with a custom error message that provides information about the error.

## 1.0.0-preview.1 (2020-01-09)
This is the first preview of the `Azure.AI.TextAnalytics` client library. It is not a direct replacement for `Microsoft.Azure.CognitiveServices.Language.TextAnalytics`, as applications currently using that library would require code changes to use `Azure.AI.TextAnalytics`.

This package's [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md) and [samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/textanalytics/Azure.AI.TextAnalytics/samples) demonstrate the new API.


### Major changes from `Microsoft.Azure.CognitiveServices.Language.TextAnalytics`
- This library supports only the Text Analytics Service v3.0-preview.1 API, whereas the previous library supports only earlier versions.
- The namespace/package name for Azure Text Analytics client library has changed from 
    `Microsoft.Azure.CognitiveServices.Language.TextAnalytics` to `Azure.AI.TextAnalytics`
- Added support for:
  - Subscription key and AAD authentication for both synchronous and asynchronous clients.
  - Detect Language.
  - Separation of Entity Recognition and Entity Linking.
  - Identification of Personally Identifiable Information.
  - Analyze Sentiment APIs including analysis for mixed sentiment.
