# Release History

## 4.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 4.1.0 (2023-08-10)

### Features Added
- In struct `DocumentAnalysisFeature`, added properties `Barcodes`, `KeyValuePairs`, and `Languages` as add-on capabilities.
- Added class `DocumentContentSource` as a base class to `AzureBlobContentSource` (renamed to `BlobContentSource` in this SDK version) and `AzureBlobFileListSource` (renamed to `BlobFileListContentSource` in this SDK version).
- In `DocumentModelAdministrationClient`, added a new overload to `BuildDocumentModel` that takes a `DocumentContentSource` object. It can be used to build a document model from alternative content sources.
- Added property `ServiceVersion` to classes `AnalyzeResult`, `DocumentModelDetails`, `DocumentModelSummary`, `OperationDetails`, and `OperationSummary`.

### Breaking Changes
- `DocumentAnalysisClient` and `DocumentModelAdministrationClient` now target service API version `2023-07-31` by default. Version `2023-02-28-preview` is not supported anymore.
- In struct `DocumentAnalysisFeature`, properties `OcrFormula` and `OcrFont` were renamed to `Formulas` and `FontStyling`, respectively.
- Removed query fields support. The properties `AnalyzeDocumentOptions.QueryFields` and `DocumentAnalysisFeature.QueryFieldsPremium` were removed.
- Removed image extraction support. The class `DocumentImage` and the property `DocumentPage.Images` were removed.
- Removed annotation extraction support. The types `DocumentAnnotation`, `DocumentAnnotationKind`, and the property `DocumentPage.Annotations` were removed.
- Removed struct `DocumentPageKind` and property `DocumentPage.Kind`.
- Removed property `DocumentKeyValuePair.CommonName`.
- In `DocumentBarcodeKind`, renamed members `QRCode`, `PDF417`, `EAN8`, `EAN13`, `ITF`, and `MicroQRCode` to `QrCode`, `Pdf417`, `Ean8`, `Ean13`, `Itf`, and `MicroQrCode`, respectively.
- Renamed class `AzureBlobContentSource` to `BlobContentSource`.
- Renamed class `AzureBlobFileListSource` to `BlobFileListContentSource`.
- In class `ClassifierDocumentTypeDetails`, properties `AzureBlobFileListSource` and `AzureBlobSource` have been replaced by a single polymorphic property `TrainingDataSource`.
- In class `ClassifierDocumentTypeDetails`, all constructors have been replaced by a single constructor that takes a polymorphic parameter `trainingDataSource`.
- In class `ResourceDetails`, renamed property `CustomNeuralDocumentModelBuilds` to `NeuralDocumentModelQuota`.
- In class `DocumentClassifierDetails`, renamed property `ApiVersion` to `ServiceVersion`.
- Renamed struct `FontStyle` to `DocumentFontStyle`.
- Renamed struct `FontWeight` to `DocumentFontWeight`.
- Renamed class `QuotaDetails` to `ResourceQuotaDetails`.

### Bugs Fixed
- Fixed a bug where calling the `GetResourceDetails` API while targeting service version `2022-08-31` would throw an `ArgumentNullException`.

## 4.1.0-beta.1 (2023-04-13)

### Features Added
- Added property `QueryFields` to `AnalyzeDocumentOptions` to support field extraction without the need for added training.
- Added property `Features` to `AnalyzeDocumentOptions` to support add-on capabilities.
- Added properties `SimilarFontFamily`, `FontStyle`, `FontWeight`, `Color`, and `BackgroundColor` to `DocumentStyle`. These properties can only be populated when `DocumentAnalysisFeature.OcrFont` is enabled.
- Added properties `Annotations`, `Barcodes`, `Formulas`, `Images`, and `Kind` to `DocumentPage`. `Formulas` can only be populated when `DocumentAnalysisFeature.OcrFormula` is enabled.
- Added member `FormulaBlock` to `ParagraphRole`.
- Added methods in `DocumentAnalysisClient` to support custom document classification: `ClassifyDocument` and `ClassifyDocumentFromUri`.
- Added methods in `DocumentModelAdministrationClient` to support custom document classification: `BuildDocumentClassifier`, `GetDocumentClassifier`, `GetDocumentClassifiers`, and `DeleteDocumentClassifier`.
- Added a new `DocumentClassifierBuildOperationDetails` class. Instances of this class can now be returned in calls to `DocumentModelAdministrationClient.GetOperation`.
- Added member `DocumentClassifierBuild` to `DocumentOperationKind`.
- Added member `Boolean` to `DocumentFieldType`.
- Added method `AsBoolean` to `DocumentFieldValue` to support extracting values of boolean fields.
- Added property `Code` to the `CurrencyValue` class.
- Added properties `Unit`, `CityDistrict`, `StateDistrict`, `Suburb`, `House`, and `Level` to the `AddressValue` class.
- Added property `CommonName` to the `DocumentKeyValuePair` class.
- Added property `ExpiresOn` to the `DocumentModelDetails` and `DocumentModelSummary` classes.
- Added property `CustomNeuralDocumentModelBuilds` to the `ResourceDetails` class.

### Other Changes
- `DocumentAnalysisClient` and `DocumentModelAdministrationClient` now target service API version `2023-02-28-preview` by default. Version `2022-08-31` can still be targeted if specified in the `DocumentAnalysisClientOptions`.

## 4.0.0 (2022-09-08)

### Features Added
- Added `GetWords` method to `DocumentLine`. It can be used to split the line into separate `DocumentWord` instances.
- Added derived classes to `DocumentModelOperationDetails` for each kind of operation: `DocumentModelBuildOperationDetails`, `DocumentModelCopyToOperationDetails`, and `DocumentModelComposeOperationDetails`.
- Added `DocumentField.ExpectedFieldType` property.

### Breaking Changes
- The `DocumentAnalysisClient` and `DocumentModelAdministrationClient` now target the service version `2022-08-31`, so they don't support `2020-06-30-preview` anymore.
- Renamed `DocumentModelAdministrationClient` methods to use the term `DocumentModel` instead of `Model` only. For example, `BuildModel` and `GetModels` became `BuildDocumentModel` and `GetDocumentModels`.
  - Similarly, `Operation` types have been renamed to reflect this change. For example, `ComposeModelOperation` became `ComposeDocumentModelOperation`.
  - As a consequence, `BuildModelOptions` has been renamed to `BuildDocumentModelOptions`.
- Removed the `BoundingPolygon` type. All `BoundingPolygon` properties are now of type `IReadOnlyList<PointF>`.
- Moved all `DocumentField` conversion methods, such as `AsDate` and `AsString`, to the new `DocumentFieldValue` class. They can be accessed from the `DocumentField.Value` property.
- `DocumentField.ValueType` (now called `FieldType`) can now be `Unknown` when the field value couldn't be parsed by the service. In this case, `DocumentField.Content` can be used to get a textual representation of the field.
- Updated `DocumentField.AsDate` to return a `DateTimeOffset` instead of a `DateTime`.
- Renamed classes `DocumentModelOperationDetails` and `DocumentModelOperationSummary` to `OperationDetails` and `OperationSummary`, respectively.
- Moved property `Result` in `DocumentModelOperationDetails` (now called `OperationDetails`) to each of its new derived classes. The property can't be accessed from the base class anymore.
- Renamed class `DocTypeInfo` to `DocumentTypeDetails`.
- Renamed property `Offset` to `Index` in the `DocumentSpan` class.
- Renamed property `DocType` to `DocumentType` in the `AnalyzedDocument` class.
- Renamed property `DocTypes` to `DocumentTypes` in the `DocumentModelDetails` class.
- Renamed properties `DocumentModelCount` and `DocumentModelLimit` to `CustomDocumentModelCount` and `CustomDocumentModelLimit` in the `ResourceDetails` class.
- Removed property `BuildModelOptions.Prefix`. The prefix must now be set with the `prefix` parameter in the method `BuildModel`.
- Removed class `DocumentPageKind` and related properties.
- Made `BoundingRegion` a `struct` instead of a `class`.
- `BoundingRegion` now implements the `IEquatable<BoundingRegion>` interface.
- Overrode `BoundingRegion.ToString` to include information about its page number and its bounding polygon in its string representation.
- `DocumentSpan` now implements the `IEquatable<DocumentSpan>` interface.
- Overrode `DocumentSpan.ToString` to include information about its index and its length in its string representation.
- Renamed `LengthUnit` to `DocumentPageLengthUnit`. This change only affects the type defined in the `DocumentAnalysis` namespace.
- Renamed `SelectionMarkState` to `DocumentSelectionMarkState`. This change only affects the type defined in the `DocumentAnalysis` namespace.
- Renamed `CopyAuthorization` to `DocumentModelCopyAuthorization`. This change only affects the type defined in the `DocumentAnalysis` namespace.

## 4.0.0-beta.5 (2022-08-09)

### Features Added
- Added `Length` property to `BoundingPolygon`.
- Added a public constructor to `CopyAuthorization`.
- Added properties `AccessToken` and `TargetResourceId` to `CopyAuthorization`.

### Breaking Changes
- Updated all long-running operation client methods to a new pattern. This affects `StartAnalyzeDocument`, `StartAnalyzeDocumentFromUri`, `StartBuildModel`, `StartCopyModelTo`, and `StartCreateComposedModel` methods. Changes are:
  - Removed the "Start" prefix. For example, `StartAnalyzeDocument` was renamed to `AnalyzeDocument`.
  - Added a new required parameter: `waitUntil`. It specifies whether the operation should run to completion before returning or not, removing the need to call `WaitForCompletion` in most scenarios.
- Updated `DocumentModelInfo` and `DocumentModel`:
  - Renamed them to `DocumentModelSummary` and `DocumentModelDetails`, respectively.
  - Removed the inheritance between them.
- Updated `ModelOperationInfo` and `ModelOperation`:
  - Renamed them to `DocumentModelOperationSummary` and `DocumentModelOperationDetails`, respectively.
  - Removed the inheritance between them.
  - Updated `ResourceLocation` to be a `Uri` in both.
- Renamed `AccountProperties` to `ResourceDetails`.
- Renamed method `GetAccountProperties` to `GetResourceDetails`.
- Renamed method `StartCreateComposedModel` to `ComposeModel`.
- Renamed `BuildModelOptions.ModelDescription` to `Description`.
- Renamed `modelDescription` parameters to `description` in methods `GetCopyAuthorization` and `StartCreateComposedModel` (now called `ComposeModel`).
- Renamed `CopyAuthorization.ExpirationDateTime` to `ExpiresOn`.
- Removed `DocumentCaption` and `DocumentFootnote` features.
- Updated the return type of `StartCreateComposedModel` (now called `ComposeModel`) to a `ComposeModelOperation`.
- Renamed class `CopyModelOperation` to `CopyModelToOperation`.
- Renamed parameter `analyzeDocumentOptions` to `options` in the `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` methods (now called `AnalyzeDocument` and `AnalyzeDocumentFromUri`).
- Renamed parameter `buildModelOptions` to `options` in the `StartBuildModel` method (now called `BuildModel`).
- `FormRecognizerClientOptions.Audience` and `DocumentAnalysisClientOptions.Audience` now default to `null`.
- In the `DocumentAnalysis` namespace, `CopyModelOperation.PercentCompleted` and `BuildModelOperation.PercentCompleted` now throw an `InvalidOperationException` if called before a call to `UpdateStatus`.
- Updated `CopyAuthorization.TargetModelLocation` to be a `Uri` instead of `string`.
- Removed method `DocumentAnalysisModelFactory.CopyAuthorization`.

## 4.0.0-beta.4 (2022-06-08)

### Features Added
- Added `Kind` property to the `DocumentPage` class.
- Added the `Paragraphs` property to the `AnalyzeResult` class. This property holds information about the paragraphs extracted from the input documents.
- Added `DocumentAnalysisClient` integration for ASP.NET Core ([#27123](https://github.com/azure/azure-sdk-for-net/issues/27123)).

### Breaking Changes
- In the `DocumentAnalysis` namespace, renamed `BoundingBox` model and properties to `BoundingPolygon`. It will eventually be able to include more points to better fit the borders of a document element.
- Removed the support for analyzing entities. The `DocumentEntity` class and related properties have been removed from the SDK.
- Renamed `DocumentModelAdministrationClient.StartCopyModel` methods to `StartCopyModelTo`.
- Made `DocumentSpan` a `struct` instead of a `class`.
- In `AccountProperties`, renamed `Count` and `Limit` to `DocumentModelCount` and `DocumentModelLimit`.
- In `DocumentPage`, properties `Angle`, `Height`, `Unit`, and `Width` were made nullable.
- In `DocumentTableCell`, properties `Kind`, `RowSpan`, and `ColumnSpan` are not nullable anymore.
- In `DocumentLanguage`, renamed property `LanguageCode` to `Locale`.
- In the method `DocumentModelAdministrationClient.StartCreateComposedModel`, renamed parameter `modelIds` to `componentModelIds`.
- The `DocumentAnalysisClient` and `DocumentModelAdministrationClient` now target the service version `2022-06-30-preview`, so they don't support `2020-01-30-preview` anymore.
- `DocumentAnalysisModelFactory.DocumentPage` has a new `kind` parameter.

## 4.0.0-beta.3 (2022-02-10)

### Features Added
- Added the `DocumentField.AsCurrency` method and the `DocumentFieldType.Currency` enum value to support analyzed currency fields.
- Added the `Languages` property to the `AnalyzeResult` class. This property is populated when using the `prebuilt-read` model and holds information about the languages in which the document is written.
- Added the `Tags` property to the `BuildModelOptions` class. This property can be used to specify custom key-value attributes associated with the model to be built.
- Added the `Tags` property to the `DocumentModelInfo` and to the `ModelOperationInfo` classes.
- Added the `BuildMode` property to `DocTypeInfo` to indicate the technique used when building the correspoding model.
- Added the `DocumentAnalysisModelFactory` static class to the `Azure.AI.FormRecognizer.DocumentAnalysis` namespace. It contains methods for instantiating `DocumentAnalysis` models for mocking.

### Breaking Changes
- Added the required parameter `buildMode` to `StartBuildModel` methods. Users must now choose the technique (`Template` or `Neural`) used to build models. For more information about the available build modes and their differences, see [here](https://aka.ms/azsdk/formrecognizer/buildmode).
- Added the `tags` parameter to the `GetCopyAuthorization` methods.
- Added the `tags` parameter to the `StartCreateComposedModel` methods.
- The `DocumentAnalysisClient` and `DocumentModelAdministrationClient` now target the service version `2022-01-30-preview`, so they don't support `2021-09-30-preview` anymore.

### Bugs Fixed
- FormRecognizerAudience and DocumentAnalysisAudience have been added to allow the user to select the Azure cloud where the resource is located. Issue [17192](https://github.com/azure/azure-sdk-for-net/issues/17192).

## 4.0.0-beta.2 (2021-11-09)

### Bugs Fixed
- `BuildModelOperation` and `CopyModelOperation` correctly populate the `PercentCompleted` property, instead of always having a value of `0`.

## 4.0.0-beta.1 (2021-10-07)
> Note: Starting with version `2021-09-30-preview`, a new set of clients were introduced to leverage the newest features of the Form Recognizer service. Please see the [Migration Guide](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/MigrationGuide.md) for detailed instructions on how to update application code from client library version `3.1.X` or lower to the latest version.

### Features Added
- This version of the SDK defaults to the latest supported Service API version, which currently is `2021_09_30_preview`.
- Added class `DocumentAnalysisClient` to the new `Azure.AI.FormRecognizer.DocumentAnalysis` namespace. This will be the main client to use when analyzing documents for service versions `2021_09_30_preview` and higher. For lower versions, please use the `FormRecognizerClient`.
- Added methods `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` to `DocumentAnalysisClient`. These methods substitute all existing `StartRecognize<...>` methods, such as `StartRecognizeContent` and `StartRecognizeReceiptsFromUri`.
- Added class `DocumentModelAdministrationClient` to the new `Azure.AI.FormRecognizer.DocumentAnalysis` namespace. This will be the main client to use for model management for service versions `2021_09_30_preview` and higher. For lower versions, please use the `FormTrainingClient`.
- Added methods `StartBuildModel`, `StartCopyModel`, `StartCreateComposedModel`, `GetCopyAuthorization`, `GetModel`, `GetModels`, `GetAccountProperties`, `DeleteModel`, `GetOperation`, `GetOperations`, and the equivalent async methods to `DocumentModelAdministrationClient`.

## 3.1.1 (2021-06-08)

### Key Bug Fixes
- Handles invoices and other recognition operations that return a `FormField` with `Text` and no `BoundingBox` or `Page` information.

## 3.1.0 (2021-05-26)

### New Features
- This General Availability (GA) release marks the stability of the changes introduced in package versions `3.1.0-beta.1` through `3.1.0-beta.4`.
- Updated the `FormRecognizerModelFactory` class to support missing model types for mocking.
- Added support for service version `2.0`. This can be specified in the `FormRecognizerClientOptions` object under the `ServiceVersion` enum.
By default the SDK targets latest supported service version.

### Breaking changes
- The client defaults to the latest supported service version, which currently is `2.1`.
- Renamed `Id` for `Identity` in all the `StartRecognizeIdDocuments` functionalities. For example, the name of the method is now `StartRecognizeIdentityDocuments`.
- Renamed the model `ReadingOrder` to `FormReadingOrder`.
- The model `TextAppearance` now includes the properties `StyleName` and `StyleConfidence` that were part of the `TextStyle` object.
- Removed the model `TextStyle`.
- Renamed the method `AsCountryCode` to `AsCountryRegion`.
- Removed type `FieldValueGender`.
- Removed value `Gender` from the model `FieldValuetype`.

## 3.0.1 (2021-04-09)

### Key Bug Fixes
- Updated dependency versions.

## 3.1.0-beta.4 (2021-04-06)

### New Features
- Added support for pre-built passports and US driver licenses recognition with the `StartRecognizeIdDocuments` API.
- Expanded the set of document languages that can be provided to the `StartRecognizeContent` API.
- Added property `Pages` to `RecognizeBusinessCardsOptions`, `RecognizeCustomFormsOptions`, `RecognizeInvoicesOptions`, and `RecognizeReceiptsOptions` to specify the page numbers to recognize.
- Added property `ReadingOrder` to `RecognizeContentOptions` to specify the order in which recognized text lines are returned.

### Breaking changes
- The client defaults to the latest supported service version, which currently is `2.1-preview.3`.
- `StartRecognizeCustomForms` now throws a `RequestFailedException` when an invalid file is passed.

## 3.1.0-beta.3 (2021-03-09)

### New Features
- Added protected constructors for mocking to `Operation` types, such as `TrainingOperation` and `RecognizeContentOperation`.

## 3.1.0-beta.2 (2021-02-09)
### Breaking changes
- Renamed the model `Appearance` to `TextAppearance`.
- Renamed the model `Style` to `TextStyle`.
- Renamed the extensible enum `TextStyle` to `TextStyleName`.
- Changed object type for property `Pages` under `RecognizeContentOptions` from `IEnumerable` to `IList`.
- Changed model type of `Locale` from `string` to `FormRecognizerLocale` in `RecognizeBusinessCardsOptions`, `RecognizeInvoicesOptions`, and `RecognizeReceiptsOptions`.
- Changed model type of `Language` from `string` to `FormRecognizerLanguage` in `RecognizeContentOptions`.

## 3.1.0-beta.1 (2020-11-23)

### Breaking changes
- It defaults to the latest supported service version, which currently is `2.1-preview.2`.

### New Features
- Added integration for ASP.NET Core.
- Added support for pre-built business card recognition.
- Added support for pre-built invoices recognition.
- Added support for providing locale information when recognizing receipts and business cards. Supported locales include EN-US, EN-AU, EN-CA, EN-GB, EN-IN.
- Added support for providing the document language in `StartRecognizeContent` when recognizing a form.
- Added support to train and recognize custom forms with selection marks such as check boxes and radio buttons. This functionality is only available in train with labels scenarios.
- Added support to `StartRecognizeContent` to recognize selection marks such as check boxes and radio buttons.
- Added ability to create a composed model from the `FormTrainingClient` by calling method `StartCreateComposedModel`.
- Added ability to pass parameter `ModelName` to `StartTraining` methods.
- Added the properties `ModelName` and `Properties` to types `CustomFormModel` and `CustomFormModelInfo`.
- Added type `CustomFormModelProperties` that includes information like if a model is a composed model.
- Added property `ModelId` to `CustomFormSubmodel` and `TrainingDocumentInfo`.
- Added properties `ModelId` and `FormTypeConfidence` to `RecognizedForm`.
- Added property `Appearance` to `FormLine` to indicate the style of the extracted text. For example, "handwriting" or "other".
- Added property `BoundingBox` to `FormTable`.
- Added support for `ContentType` `image/bmp` in recognize content and prebuilt models.
- Added property `Pages` to `RecognizeContentOptions` to specify the page numbers to analyze.

## 3.0.0 (2020-08-20)

- First stable release of the Azure.AI.FormRecognizer package.

### Breaking changes

- Renamed the model `BoundingBox` to `FieldBoundingBox`.

### New Features

- Added `FormRecognizerModelFactory` static class to support mocking model types.

## 3.0.0-preview.2 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 3.0.0-preview.1 (2020-08-11)

### Breaking changes

- The library now targets the service's v2.0 API, instead of the v2.0-preview.1 API.
- Updated version number from `1.0.0-preview.5` to `3.0.0-preview.1`.
- Added models `RecognizeCustomFormsOptions`, `RecognizeReceiptsOptions`, and `RecognizeContentOptions` instead of a generic `RecognizeOptions` to support passing configurable options to recognize APIs.
- Added model `TrainingOptions` to support passing configurable options to training APIs. This type now includes `TrainingFileFilter`.
- Renamed the `FieldValue` property `Type` to `ValueType`.
- Renamed the `TrainingDocumentInfo` property `DocumentName` to `Name`.
- Renamed the `TrainingFileFilter` property `IncludeSubFolders` to `IncludeSubfolders`.
- Renamed the `FormRecognizerClient.StartRecognizeCustomForms` parameter `formFileStream` to `form`.
- Renamed the `FormRecognizerClient.StartRecognizeCustomFormsFromUri` parameter `formFileUri` to `formUri`.
- Renamed `CustomFormModelStatus.Training` to `CustomFormModelStatus.Creating`.
- Renamed `FormValueType.Integer` to `FormValueType.Int64`.
- `FormField` property `ValueData` is now set to null if there is no text, bounding box or page number associated with it.

### Fixes

- Made the `TrainingFileFilter` constructor public.
- Fixed a bug in which `FormTrainingClient.GetCustomModel` threw an exception if the model was still being created ([#13813](https://github.com/Azure/azure-sdk-for-net/issues/13813)).
- Fixed a bug in which the `BoundingBox` indexer and `ToString` method threw a `NullReferenceException` if it had no points ([#13971](https://github.com/Azure/azure-sdk-for-net/issues/13971)).
- Fixed a bug in which a default `FieldValue` threw a `NullReferenceException` if `AsString` was called. The method now returns `null`.

### New Features

- Added diagnostics functionality to the `FormRecognizerClient`, to the `FormTrainingClient` and to long-running operation types.

## 1.0.0-preview.4 (2020-07-07)

### Renames

- Property `RequestedOn` renamed to `TrainingStartedOn` on `CustomFormModel` and `CustomFormModelInfo`.
- Property `CompletedOn` renamed to `TrainingCompletedOn` on `CustomFormModel` and `CustomFormModelInfo`.
- Property `LabelText` renamed to `LabelData` on `FormField`.
- Property `ValueText` renamed to `ValueData` on `FormField`.
- Property `TextContent` renamed to `FieldElements` on `FieldData` and `FormTableCell`.
- Parameter `formUrl` in `StartRecognizeContent` has been renamed to `formUri`.
- Parameter `receiptUrl` in `StartRecognizeReceipts` has been renamed to `receiptUri`.
- Parameter `accessToken` in `CopyAuthorization.FromJson` has been renamed to `copyAuthorization`.
- Parameter `IncludeTextContent` in `RecognizeOptions` has been renamed to `IncludeFieldElements`.
- Model `FieldText` renamed to `FieldData`.
- Model `FormContent` renamed to `FormElement`.

### Other breaking changes

- Property `CopyAuthorization.ExpiresOn` type is now `DateTimeOffset`.
- `RecognizedReceipt` and `RecognizedReceiptsCollection` classes removed. Receipt field values must now be obtained from a `RecognizedForm`.

### Fixes

- Fixed a bug in which the `FormPage.TextAngle` property sometimes fell out of the (-180, 180] range ([#13082](https://github.com/Azure/azure-sdk-for-net/issues/13082)).

## 1.0.0-preview.3 (06-10-2020)

### Renames

- `FormRecognizerError.Code` renamed to `FormRecognizerError.ErrorCode`.
- `FormTrainingClient.GetModelInfos` renamed to `FormTrainingClient.GetCustomModels`.
- Property `CreatedOn` in types `CustomFormModel` and `CustomFormModelInfo` renamed to `RequestedOn`.
- Property `LastModified` in types `CustomFormModel` and `CustomFormModelInfo` renamed to `CompletedOn`.
- Property `Models` in `CustomFormModel` renamed to `Submodels`.
- Type `CustomFormSubModel` renamed to `CustomFormSubmodel`.
- `ContentType` renamed to `FormContentType`.
- Parameter `useLabels` in `FormTrainingClient.StartTraining` renamed to `useTrainingLabels`.
- Parameter `trainingFiles` in `FormTrainingClient.StartTraining` renamed to `trainingFilesUri`.
- Parameter `filter` in `FormTrainingClient.StartTraining` renamed to `trainingFileFilter`.
- Removed `Type` suffix from all `FieldValueType` values.
- Parameters `formFileStream` and `formFileUri` in `StartRecognizeContent` have been renamed to `form` and `formUrl` respectively.
- Parameters `receiptFileStream` and `receiptFileUri` in `StartRecognizeReceipts` have been renamed to `receipt` and `receiptUrl` respectively.

### Other breaking changes

- `FormPageRange` is now a `struct`.
- `RecognizeContentOperation` now returns a `FormPageCollection`.
- `RecognizeReceiptsOperation` now returns a `RecognizedReceiptCollection`.
- `RecognizeCustomFormsOperation` now returns a `RecognizedFormCollection`.
- In preparation for service-side changes, `FieldValue.AsInt32` has been replaced by `FieldValue.AsInt64`, which returns a `long`.
- Parameter `useTrainingLabels` is now required for `FormTrainingClient.StartTraining`.
- Protected constructors have been removed from `Operation` types, such as `TrainingOperation` or `RecognizeContentOperation`.
- `USReceipt`, `USReceiptItem`, `USReceiptType` and `FormField{T}` types removed. Information about a `RecognizedReceipt` must now be extracted from its `RecognizedForm`.
- `ReceiptLocale` removed from `RecognizedReceipt`.
- An `InvalidOperationException` is now raised if trying to access the `Value` property of a `TrainingOperation` when a trained model is invalid.
- A `RequestFailedException` is now raised if a model with `status=="invalid"` is returned from the `StartTraining` and `StartTrainingAsync` methods.
- A `RequestFailedException` is now raised if an operation like `StartRecognizeReceipts` or `StartRecognizeContent` fails.
- An `InvalidOperationException` is now raised if trying to access the `Value` property of a `xxOperation` object when the executed operation failed.
- Method `GetFormTrainingClient` has been removed from `FormRecognizerClient` and `GetFormRecognizerClient` has been added to `FormTrainingClient`.

### New Features

- `FormRecognizerClient` and `FormTrainingClient` support authentication with Azure Active Directory.
- Support to copy a custom model from one Form Recognizer resource to another.
- Headers and query parameters that were marked as `REDACTED` in error messages and logs are now exposed by default.

### Fixes

- Custom form recognition without labels can now handle multipaged forms ([#11881](https://github.com/Azure/azure-sdk-for-net/issues/11881)).
- `RecognizedForm.Pages` now only contains pages whose numbers are within `RecognizedForm.PageRange`.
- `FieldText.TextContent` cannot be `null` anymore, and it will be empty when no element is returned from the service.
- Custom form recognition with labels can now parse results from forms that do not contain all of the expected labels ([#11821](https://github.com/Azure/azure-sdk-for-net/issues/11821)).
- `FormRecognizerClient.StartRecognizeCustomFormsFromUri` now works with URIs that contain blank spaces, encoded or not ([#11564](https://github.com/Azure/azure-sdk-for-net/issues/11564)).
- Receipt recognition can now parse results from forms that contain blank pages.

## 1.0.0-preview.2 (05-06-2020)

### Fixes

- All of `FormRecognizerClient`'s `FormRecognizerClientOptions` are now passed to the client returned by
    `FormRecognizerClient.GetFormTrainingClient`.

## 1.0.0-preview.1 (04-23-2020)
This is the first preview Azure Form Recognizer client library that follows the [.NET Azure SDK Design Guidelines][guidelines].
This library replaces the package [`Microsoft.Azure.CognitiveServices.FormRecognizer`][cognitiveServices_fr_nuget].

This package's [documentation][readme] and [samples][samples] demonstrate the new API.

### Major changes from `Microsoft.Azure.CognitiveServices.FormRecognizer`
- This library supports only the Form Recognizer Service v2.0-preview API
- The namespace/package name for Azure Form Recognizer client library has changed from 
    `Microsoft.Azure.CognitiveServices.FormRecognizer` to `Azure.AI.FormRecognizer`
- Two client design:
  - `FormRecognizerClient` to recognize and extract fields/values on custom forms, receipts, and form content/layout.
  - `FormTrainingClient` to train custom models, and manage the custom models on your resource account.
- Different recognize methods based on input type: file stream or URI.
- File stream methods will automatically detect content-type of the input file.

[guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html
[cognitiveServices_fr_nuget]: https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.FormRecognizer/0.8.0-preview
[readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
