# Release History

## 5.1.0-beta.8 (Unreleased)
### New features
- Added support for service version `3.0`. This can be specified in the `TextAnalyticsClientOptions` object under the `ServiceVersion` enum. By default the SDK targets latest supported service version.
- Added value `None` to enum `PiiEntityDomainType` to allow user to specify no domain.

### Breaking changes
- Renamed `StartAnalyzeBatchActions` to `StartAnalyzeActions`.
- Renamed `AnalyzeBatchActionsOperation` to `AnalyzeActionsOperation`.
- Renamed `AnalyzeBatchActionsResult` to `AnalyzeActionsResult`.
- Renamed `AnalyzeBatchActionsOptions` to `AnalyzeActionsOptions`.
- `TextAnalyticsActions` now takes `xxAction` types, instead of `xxOptions` types. Renames and types are as follow:
  - `ExtractKeyPhrasesOptions` changed to new type `ExtractKeyPhrasesActions`.
  - `RecognizeEntitiesOptions` changed to new type `RecognizeEntitiesActions`.
  - `RecognizePiiEntitiesOptions` changed to new type `RecognizePiiEntitiesActions`.
  - `RecognizeLinkedEntitiesOptions` changed to new type `RecognizeLinkedEntitiesActions`.
  - `AnalyzeSentimentOptions` changed to new type `AnalyzeSentimentActions`.
- Renamed type `TextAnalyticsActionDetails` to `TextAnalyticsActionResult`.
- Renamed type `PiiEntityDomainType` to `PiiEntityDomain`.
- Changed type `RecognizePiiEntitiesOptions.DomainFilter` from `PiiEntityDomainType?` to `PiiEntityDomainType`.
- Changed type `AnalyzeActionsOptions.IncludeStatistics` from `bool` to `bool?`.
- Removed property `Statistics` from `AnalyzeActionsResult` as it is not currently returned by the service even if the user passes `IncludeStatistics  = true`.
- Removed property `StringIndexType` from `TextAnalyticsRequestOptions`. This SDK will keep using `UTF-16` code unit as the default encoding.

## 5.1.0-beta.7 (2021-05-18)
### New features
- Added property `DisableServiceLogs` to `TextAnalyticsRequestOptions`.
- Added support for Sentiment Analysis as an action type for `StartAnalyzeBatchActions`.
- Changed type of `IncludeOpinionMining` to `bool?`.

### Breaking changes
- The client defaults to the latest supported service version, which currently is `3.1-preview.5`.
- Renamed type `TextElementsV8` to `TextElementV8` in model `StringIndexType`.

## 5.1.0-beta.6 (2021-04-06)
### New features
- Add overloads to `ExtractKeyPhrasesBatch` and `ExtractKeyPhrasesBatchAsync` to on `TextAnalyticsClient` to accept `ExtractKeyPhrasesOptions` and hid the previous methods (non-breaking change).
- Add overloads to `RecognizeEntitiesBatch` and `RecognizeEntitiesBatchAsync` to on `TextAnalyticsClient` to accept `RecognizeEntitiesOptions` and hid the previous methods (non-breaking change).
- Add overloads to `RecognizeLinkedEntitiesBatch` and `RecognizeLinkedEntitiesBatch` to on `TextAnalyticsClient` to accept `RecognizeLinkedEntitiesOptions` and hid the previous methods (non-breaking change).

### Breaking changes
- Renamed `TotalActions` to `ActionsTotal`.

## 5.1.0-beta.5 (2021-03-09)
### New features
- Added ability to filter the categories returned in a Personally Identifiable Information recognition with the optional parameter `CategoriesFilter` in `RecognizePiiEntitiesOptions`.
- Added the ability to recognize linked entities under `StartAnalyzeBatchActions`.
- Added `RecognizeLinkedEntitiesOptions` to `TextAnalyticsActions`.
- Added `RecognizeLinkedEntitiesActionsResults` to `AnalyzeBatchActionsResult`.
- `AnalyzeHealthcareEntitiesResult`, now exposes the property `EntityRelations`of type `HealthcareEntityRelation`.
- Introduced `HealthcareEntityRelation` class which will determine all the different relations between the entities as `Roles`.
- Added `HealthcareEntityRelationRole`, which exposes `Name` and `Entity` of type `string` and `HealthcareEntity` respectively.
- `HealthcareEntityAssertion` is added to `HealthcareEntity` which further exposes `EntityAssociation`, `EntityCertainity` and `EntityConditionality`.
- Added new types under `HealthcareRelationType` class.

### Breaking changes
- Renamed `AspectSentiment` to `TargetSentiment`.
- Renamed `MinedOpinion` to `SentenceOpinion`.
- Renamed `OpinionSentiment` to `AssessmentSentiment`.
- For `PiiEntity.Category` the type of the property is now `PiiEntityCategory` instead of `EntityCategory`.
- Removed `RelatedEntities`.
- `RecognizePiiEntitiesOptions.Domain` is now a nullable type.
- In `StartAnalyzeBatchActions` when all actions return status `failed` the SDK will no longer throw an exception. The request will succeed and the errors will be located at the specific action level. 

### Fixes
- `RecognizePiiEntities` and `TextAnalyticsActions.RecognizePiiEntitiesOptions` were always passing `PiiEntityDomainType.PHI`. Now, it is only passed when requested by the user [19086](https://github.com/Azure/azure-sdk-for-net/issues/19086).

## 5.1.0-beta.4 (2021-02-10)
### New features
- Added property `Length` to `CategorizedEntity`, `SentenceSentiment`, `LinkedEntityMatch`, `AspectSentiment`, `OpinionSentiment`, and `PiiEntity`.
- `StringIndexType` has been added to all endpoints that expose the new properties `Offset` and `Length` to determine the encoding which service should use. It is added into the `TextAnalyticsRequestOptions` class and default for this SDK is `UTF-16` code unit.
- `AnalyzeHealthcareEntitiesOperation` now exposes the properties `CreatedOn`, `ExpiresOn`, `LastModified`, and `Status`.
- `AnalyzeBatchActionsOperation ` now exposes the properties `CreatedOn`, `ExpiresOn`, `LastModified`, `Status`, `ActionsFailed`, `ActionsInProgress`,  `ActionsSucceeded`,  `DisplayName`, and `TotalActions`.

### Breaking changes
- Renamed `JobStatus` to `TextAnalyticsOperationStatus`.

#### Analyze Healthcare Entities
- Pagination support was added for all `StartAnalyzeHealthcareEntities` methods.
- Moved `Cancel` and `CancelAsync` for Healthcare from `TextAnalyticsClient` to `AnalyzeHealthcareEntitiesOperation`.
- The healthcare entities returned by `StartAnalyzeHealthcareEntities` are now organized as a directed graph where the edges represent a certain type of healthcare relationship between the source and target entities. Edges are stored in the `RelatedEntities` property.
- Renamed `StartHealthcareBatch` and `StartHealthcareBatchAsync` to `StartAnalyzeHealthcareEntities` and `StartAnalyzeHealthcareEntitiesAsync` respectively.
- Renamed `RecognizeHealthcareEntitiesResultCollection` to `AnalyzeHealthcareEntitiesResultCollection`.
- Renamed `DocumentHealthcareResult` to `AnalyzeHealthcareEntitiesResult`.
- Renamed `HealthcareOperation` to `AnalyzeHealthcareEntitiesOperation`.
- Renamed `HealthcareOptions` to `AnalyzeHealthcareEntitiesOptions`, and removed types `Skip` and `Top` from it. Pagination is now done automatically by the SDK.
- Renamed `HealthcareEntityLink` to `EntityDataSource` with `DataSource` to `EntityDataSource` and `Id` to `Name`.
- Renamed `HealthcareRelation` to `HealthcareRelationType`.
- Removed method `GetHealthcareEntities` as pagination is now done with the main `StartAnalyzeHealthcareEntities` methods.
- Removed `HealthcareTaskResult`.
- Removed `StartHealthcare` and `StartHealthcareAsync` methods.
- Removed `IsNegated` property from `HealthcareEntity`.

#### Analyze batch actions
- The word `action` is now used consistently in our names and documentation instead of `task`.
- Pagination support was added for all `StartAnalyzeBatchActions` methods.
- Renamed methods `StartAnalyzeOperationBatch` and `StartAnalyzeOperationBatchAsync` to `StartAnalyzeBatchActions` and `StartAnalyzeBatchActionsAsync` respectively.
- Type `TextAnalyticsActions` added to `StartAnalyzeBatchActions` methods to specify the actions to execute in the batch of documents instead of in `AnalyzeOperationOptions`.
- The way to configure the options for each action is now exposed in the respective `ExtractKeyPhrasesOptions`, `RecognizeEntitiesOptions`, or `RecognizePiiEntitiesOptions` object.
- Results for the `StartAnalyzeBatchActions` method are now returned in a `AnalyzeHealthcareEntitiesResultCollection` object that contains information per type of action.
- Renamed `AnalyzeOperation` to `AnalyzeBatchActionsOperation`.
- Reuse `PiiEntityDomainType` instead of `PiiTaskParametersDomain`.
- Removed `AnalyzeTasks`, `EntitiesTask`, `EntitiesTaskParameters`, `EntityRecognitionTasksItem`, `JobManifestTasks`, `KeyPhraseExtractionTasksItem`, `KeyPhrasesTask`, `KeyPhrasesTaskParameters`, `PiiTask`, `PiiTaskParameters`.

## 5.1.0-beta.3 (2020-11-19)
### New Features
- Added `HealthcareOperation` long running operation for new asynchronous `Text Analytics for health` hosted API with support for batch processing. Note this is a currently in a gated preview where AAD is not supported. More information [here](https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview).
- Added `AnalyzeOperation` long running operation for new asynchronous `Analyze API` to support batch processing of Named entity recognition, Personally Identifiable Information and Key phrase extraction.
- Both new features listed above are available in `West US2`, `East US2`, `Central US`, `North Europe` and `West Europe` regions and in Standard tier.

### Breaking changes
- Modified the way to turn on Opinion Mining feature in `AnalyzeSentiment` to a bool property called `IncludeOpinionMining`.

## 5.1.0-beta.2 (2020-10-06)
### Breaking changes
- Removed property `Length` from `CategorizedEntity`, `SentenceSentiment`, `LinkedEntityMatch`, `AspectSentiment`, `OpinionSentiment`, and `PiiEntity`.

## 5.1.0-beta.1 (2020-09-17)

### New Features
- It defaults to the latest supported API version, which currently is `3.1-preview.2`.
- `ErrorCode` value returned from the service is now surfaced in `RequestFailedException`.
- Added the `RecognizePiiEntities` endpoint which returns entities containing Personally Identifiable Information. This feature is available in the Text Analytics service v3.1-preview.1 and above.
- Support added for Opinion Mining. This feature is available in the Text Analytics service v3.1-preview.1 and above.
- Added `Offset` and `Length` properties for `CategorizedEntity`, `SentenceSentiment`, and `LinkedEntityMatch`. The default encoding is UTF-16 code units. For additional information see https://aka.ms/text-analytics-offsets
- `TextAnalyticsError` and `TextAnalyticsWarning` now are marked as immutable.
- Added property `BingEntitySearchApiId` to the `LinkedEntity` class. This property is only available for v3.1-preview.2 and up, and it is to be used in conjunction with the Bing Entity Search API to fetch additional relevant information about the returned entity.

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
