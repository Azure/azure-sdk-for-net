# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-12-16)

### Features Added
- Added methods `GetAnalyzeBatchResult`, `GetAnalyzeBatchResults`, `DeleteAnalyzeBatchResult`, and `DeleteAnalyzeResult` to `DocumentIntelligenceClient`.
- Added class `AnalyzeBatchOperationDetails` to be used as the output of the `GetAnalyzeBatchResult` and `GetAnalyzeBatchResults` APIs.
- Added overloads for the `AnalyzeDocument` API that take only required parameters.
- Added property `ModifiedOn` to `DocumentModelDetails` and to `DocumentClassifierDetails`.
- Added member `Skipped` to `DocumentIntelligenceOperationStatus` (former `OperationStatus`).
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes
- Replaced the following `Content` classes with new corresponding `Options` classes:
  - `AnalyzeBatchDocumentsContent` to `AnalyzeBatchDocumentsOptions`.
  - `AnalyzeDocumentContent` to `AnalyzeDocumentOptions`.
  - `AuthorizeClassifierCopyContent` to `AuthorizeClassifierCopyOptions`.
  - `AuthorizeCopyContent` to `AuthorizeModelCopyOptions`.
  - `BuildDocumentClassifierContent` to `BuildClassifierOptions`.
  - `BuildDocumentModelContent` to `BuildDocumentModelOptions`.
  - `ClassifyDocumentContent` to `ClassifyDocumentOptions`.
  - `ComposeDocumentModelContent` to `ComposeModelOptions`.
  - Parameters of the `AnalyzeBatchDocuments`, `AnalyzeDocument`, and `ClassifyDocument` methods have been moved into their corresponding `Options` class.
- Updated parameter `resultId` of methods `GetAnalyzeResultPdf` and `GetAnalyzeResultFigure` to take a `string` instead of a `Guid`.
- Renamed all occurrences of property `UrlSource` to `UriSource`.
- Renamed all occurrences of properties `DocType` and `DocTypes` to `DocumentType` and `DocumentTypes`, respectively.
- In `DocumentField`, renamed properties `Type` and `ValueLong` to `FieldType` and `ValueInt64`, respectively.
- Renamed property `Type` to `FieldType` in `DocumentFieldSchema`.
- Renamed class `AzureBlobContentSource` to `BlobContentSource`.
- Renamed class `AzureBlobFileListContentSource` to `BlobFileListContentSource`.
- Renamed all occurrences of properties `AzureBlobSource` and `AzureBlobFileListSource` to `BlobSource` and `BlobFileListSource`, respectively.
- Renamed all occurrences of property `ContainerUrl` to `ContainerUri`.
- Renamed property `ResultContainerUrl` to `ResultContainerUri` in `AnalyzeBatchDocumentsContent`.
- Renamed class `AnalyzeBatchOperationDetail` to `AnalyzeBatchResultDetails`.
- In `AnalyzeBatchResultDetails` (former `AnalyzeBatchOperationDetail`), renamed properties `SourceUrl` and `ResultUrl` to `SourceUri` and `ResultUri`, respectively.
- Removed member `Generative` from `DocumentBuildMode`.
- Renamed member `StyleFonts` to `FontStyling` in `DocumentAnalysisFeature`.
- In `ContentSourceKind`, renamed members `Url`, `Base64`, `AzureBlob`, and `AzureBlobFileList` to `Uri`, `Bytes`, `Blob`, and `BlobFileList`, respectively.
- Renamed all occurrences of property `ExpirationDateTime` to `ExpiresOn`.
- Renamed method `GetResourceInfo` to `GetResourceDetails` in `DocumentIntelligenceAdministrationClient`.
- Renamed class `ResourceDetails` to `DocumentIntelligenceResourceDetails`.
- Renamed type `ContentFormat` to `DocumentContentFormat`.
- Renamed class `OperationDetails` to `DocumentIntelligenceOperationDetails`.
- Renamed class `InnerError` to `DocumentIntelligenceInnerError`.
- Renamed class `CopyAuthorization` to `ModelCopyAuthorization`.
- Renamed type `OperationStatus` to `DocumentIntelligenceOperationStatus`.
- Renamed property `Innererror` to `InnerError` in `DocumentIntelligenceError`.
- Renamed property `InnerErrorObject` to `InnerError` in `DocumentIntelligenceInnerError` (former class `InnerError`).
- Removed member `Completed` from `DocumentIntelligenceOperationStatus` (former `OperationStatus`).
- Removed type `StringIndexType`.
- Removed property `StringIndexType` in `AnalyzeResult`.
- Updated property `Fields` in `AnalyzedDocument` to be a `DocumentFieldDictionary` instead of an `IReadOnly<string, DocumentField>`.
- Updated property `ValueDictionary` in `DocumentField` to be a `DocumentFieldDictionary` instead of an `IReadOnly<string, DocumentField>`.
- Made type `BoundingRegion` a `struct`.
- Made type `DocumentSpan` a `struct`.

### Bugs Fixed
- Fixed a bug where calling `Operation.Id` would sometimes return an `InvalidOperationException` with message "The operation ID was not present in the service response.".
- Calling `Operation.Id` in an operation returned from the `AnalyzeBatchDocuments` and `ClassifyDocument` APIs won't throw a `NotSupportedException` anymore.

## 1.0.0-beta.3 (2024-08-14)

### Features Added
- Added support for the Analyze Batch Documents API:
  - Added method `AnalyzeBatchDocuments` to `DocumentIntelligenceClient`.
  - Added class `AnalyzeBatchDocumentsContent` to be used as the main input of the API.
  - Added class `AnalyzeBatchResult` to be used as the main output of the API.
  - Added class `AnalyzeBatchOperationDetail` to be used as part of the output of the API.
- Added support for different kinds of output in the Analyze Document API:
  - Added method `GetAnalyzeResultPdf` to `DocumentIntelligenceClient`.
  - Added method `GetAnalyzeResultFigures` to `DocumentIntelligenceClient`.
  - Added type `AnalyzeOutputOption` to specify other kinds of output: either `Pdf` and `Figures`.
  - Added parameter `output` to `AnalyzeDocument` overloads in `DocumentIntelligenceClient`.
  - Added property `Id` to `DocumentFigure`.
- Added support for the Copy Classifier API:
  - Added method `AuthorizeClassifierCopy` to `DocumentIntelligenceAdministrationClient`.
  - Added method `CopyClassifierTo` to `DocumentIntelligenceAdministrationClient`.
  - Added class `AuthorizeClassifierCopyContent` to be used as the input of the `AuthorizeClassifierCopy` API.
  - Added class `ClassifierCopyAuthorization` to be use das the output of the `AuthorizeClassifierCopy` API.
  - Added class `DocumentClassifierCopyToOperationDetails` to represent a Copy Classifier operation in calls to the `GetOperation` API.
- Miscellaneous:
  - Added new kind of `DocumentBuildMode`: `Generative`.
  - Added property `Warnings` to `AnalyzeResult`.
  - Added properties `ClassifierId`, `Split`, and `TrainingHours` to `DocumentModelDetails`.
  - Added properties `ConfidenceThreshold`, `Features`, `MaxDocumentsToAnalyze`, `ModelId`, and `QueryFields` to `DocumentTypeDetails`.
  - Added properties `AllowOverwrite` and `MaxTrainingHours` to `BuildDocumentModelContent`.
  - Exposed the constructor of `DocumentTypeDetails` and made its properties settable to support new changes to the Compose Document API.
  - Exposed the constructor of `DocumentFieldSchema` and made its properties settable to support new changes to the Compose Document API.
  - Added parameter `pages` to `ClassifyDocument` overloads in `DocumentIntelligenceClient`.
  - Added properties `ClassifierId`, `DocTypes`, and `Split` to `ComposeDocumentModelContent`.
  - Added property `AllowOverwrite` to `BuildDocumentClassifierContent`.

### Breaking Changes
- `DocumentIntelligenceClient` and `DocumentIntelligenceAdministrationClient` now target service API version `2024-07-31-preview`. Support for `2024-02-29-preview` has been removed.
- Removed support for extracting lists from analyzed documents:
  - Removed types `DocumentList` and `DocumentListItem`.
  - Removed property `Lists` from `AnalyzeResult`.
- Changes to the Compose Document API:
  - Removed class `ComponentDocumentModelDetails`, originally used as part of the input of the API.
  - Removed property `ComponentModels` from `ComposeDocumentModelContent`.
  - `ComposeDocumentModelContent` now needs a dictionary of `DocumentTypeDetails` instances and a classifier ID to be constructed.
- Removed type `QuotaDetails`.
- Removed property `CustomNeuralDocumentModelBuilds` from `ResourceDetails.`
- Updated class `DocumentIntelligenceModelFactory` to reflect model changes.

### Bugs Fixed
- Calling `Operation.Id` in an operation returned from the Analyze Document API won't throw a `NotSupportedException` anymore. Using the operation ID to retrieve operations started previously is still not supported.

## 1.0.0-beta.2 (2024-03-05)

### Features Added
- Added property `BaseClassifierId` to `BuildDocumentClassifierContent`.
- Added property `BaseClassifierId` to `DocumentClassifierDetails`.
- Added property `Warnings` to `DocumentModelDetails`.
- Added property `Warnings` to `DocumentClassifierDetails`.
- Added property `SelectionGroup` to `DocumentFieldType`.
- Added property `ValueSelectionGroup` to `DocumentField`.
- Added member `Completed` to `OperationDetails`.

### Breaking Changes
- `DocumentIntelligenceClient` and `DocumentIntelligenceAdministrationClient` now target service API version `2024-02-29-preview`. Support for `2023-10-31-preview` has been removed.
- Renamed class `AIDocumentIntelligenceModelFactory` to `DocumentIntelligenceModelFactory`.
- Renamed class `AzureAIDocumentIntelligenceClientOptions` to `DocumentIntelligenceClientOptions`.
- Renamed class `AIDocumentIntelligenceClientBuilderExtensions` to `DocumentIntelligenceClientBuilderExtensions`.
- In `DocumentField`:
  - Renamed property `ValueArray` to `ValueList`.
  - Renamed property `ValueInteger` to `ValueLong`.
  - Renamed property `ValueNumber` to `ValueDouble`.
  - Renamed property `ValueObject` to `ValueDictionary`.
- In `DocumentFieldType`:
  - Renamed property `Array` to `List`.
  - Renamed property `Integer` to `Long`.
  - Renamed property `Number` to `Double`.
  - Renamed property `Object` to `Dictionary`.
- Renamed class `FontStyle` to `DocumentFontStyle`.
- Renamed class `FontWeight` to `DocumentFontWeight`.
- In `DocumentClassifierDetails`, renamed properties `CreatedDateTime` and `ExpirationDateTime` to `CreatedOn` and `ExpiresOn`, respectively.
- In `DocumentModelDetails`, renamed properties `CreatedDateTime` and `ExpirationDateTime` to `CreatedOn` and `ExpiresOn`, respectively.
- In `OperationDetails`, renamed properties `CreatedDateTime` and `LastUpdatedDateTime` to `CreatedOn` and `LastUpdatedOn`, respectively.
- In `QuotaDetails`, renamed property `QuotaResetDateTime` to `QuotaResetsOn`.
- In `DocumentBarcodeKind`:
  - Renamed property `EAN13` to `Ean13`.
  - Renamed property `EAN8` to `Ean8`.
  - Renamed property `ITF` to `Itf`.
  - Renamed property `MicroQRCode` to `MicroQrCode`.
  - Renamed property `PDF417` to `Pdf417`.
  - Renamed property `QRCode` to `QrCode`.
  - Renamed property `UPCA` to `Upca`.
  - Renamed property `UPCE` to `Upce`.

## 1.0.0-beta.1 (2023-11-16)

### Features Added
- This is the first preview of the `Azure.AI.DocumentIntelligence` package, targeting version 2023-10-31-preview of the Document Intelligence service.

**Note: Document Intelligence is a rebranding of Form Recognizer. While this package and `Azure.AI.FormRecognizer` target the same Azure service, `Azure.AI.DocumentIntelligence` is not backward compatible and should be seen as a new library. See the [Migration Guide][migration_guide] for detailed instructions on how to update application code from `Azure.AI.FormRecognizer` version `4.X.X`. The following list of changes uses version 4.1.0 for comparison to assist during migration.**

- In `DocumentAnalysisFeature`, added member `QueryFields`.
- In `AnalyzeResult`, added properties `ContentFormat`, `Figures`, `Lists`, and `Sections`.
- Added types `ContentFormat`, `DocumentFigure`, `DocumentList`, and `DocumentSection` to support new service features.
- In `DocumentTable`, added property `Caption` of type `DocumentCaption`.
- In `DocumentTable`, added property `Footnotes`, a list of `DocumentFootnote`.
- In `DocumentTableCell`, added property `Elements`.
- In `DocumentModelDetails`, added properties `AzureBlobSource`, `AzureBlobFileListSource`, and `BuildMode`.
- This library now supports [protocol methods][protocol_methods].

### Breaking Changes
- Moved all types from namespace `Azure.AI.FormRecognizer.DocumentAnalysis` to `Azure.AI.DocumentIntelligence`.
- Replaced client `DocumentAnalysisClient` with `DocumentIntelligenceClient`.
- Replaced client `DocumentModelAdministrationClient` with `DocumentIntelligenceAdministrationClient`.
- Renamed type `DocumentAnalysisClientOptions` to `AzureAIDocumentIntelligenceClientOptions`.
- Renamed type `DocumentAnalysisModelFactory` to `AIDocumentIntelligenceModelFactory`.

- Removed the original method `AnalyzeDocument` taking a `Stream` as the input document. It will eventually be supported again in a future SDK version.
- Renamed method `AnalyzeDocumentFromUri` to `AnalyzeDocument`:
  - Removed the `documentUri` parameter. The method now takes an `analyzeRequest` parameter of type `AnalyzeDocumentContent` to select the input type (URI or Base64 binary data).
  - Removed the `options` parameter and the `AnalyzeDocumentOptions` type. `pages`, `locale`, and `features` can now be set directly as method parameters.
  - Added parameter `queryFields`.
  - Added parameter `outputContentFormat` of type `ContentFormat`, supporting both `Text` and `Markdown`.
  - Changed the return type from `AnalyzeDocumentOperation` to `Operation<AnalyzeResult>`. The type `AnalyzeDocumentOperation` has been removed.
- In `DocumentAnalysisFeature`, renamed member `FontStyling` to `StyleFont`.

- Removed the original method `ClassifyDocument` taking a `Stream` as the input document. It will eventually be supported again in a future SDK version.
- Renamed method `ClassifyDocumentFromUri` to `ClassifyDocument`:
  - Removed parameter `documentUri`. The method now takes an `classifyRequest` parameter of type `ClassifyDocumentContent` to select the input type (URI or Base64 binary data).
  - Added parameter `split` of type `SplitMode`, supporting `Auto`, `None`, and `PerPage` modes.
  - Changed the return type from `ClassifyDocumentOperation` to `Operation<AnalyzeResult>`. The type `ClassifyDocumentOperation` has been removed.

- In method `BuildDocumentModel`:
  - Removed parameters `trainingDataSource`, `buildMode`, `modelId`, and `options` along with the type `BuildDocumentModelOptions`.
  - The method now takes a `buildRequest` parameter of type `BuildDocumentModelContent` containing all the options.
  - After creating a `BuildDocumentModelContent` instance, either property `AzureBlobSource` or `AzureBlobFileListSource` must be set before sending the request.
  - Changed the return type from `BuildDocumentModelOperation` to `Operation<DocumentModelDetails>`. The type `BuildDocumentModelOperation` has been removed.
- Renamed method `ComposeDocumentModel` to `ComposeModel`:
  - Removed parameters `componentModelIds`, `modelId`, `description`, and `tags`.
  - The method now takes a `composeRequest` parameter of type `ComposeDocumentModelContent` containing all the options.
  - Changed the return type from `ComposeDocumentModelOperation` to `Operation<DocumentModelDetails>`. The type `ComposeDocumentModelOperation` has been removed.
- Renamed method `GetCopyAuthorization` to `AuthorizeModelCopy`:
  - Removed parameters `modelId`, `description`, and `tags`.
  - The method now takes an `authorizeCopyRequest` parameter of type `AuthorizeCopyContent` containing all the options.
- Renamed method `CopyDocumentModelTo` to `CopyModelTo`:
  - Renamed parameter `target` to `copyToRequest`.
  - Changed the return type from `CopyDocumentModelToOperation` to `Operation<DocumentModelDetails>`. The type `CopyDocumentModelToOperation` has been removed.
- Renamed method `GetDocumentModel` to `GetModel`.
- Renamed method `GetDocumentModels` to `GetModels`.
- In method `GetModels` (former `GetDocumentModels`), changed the return type from `DocumentModelSummary` to `DocumentModelDetails`.
- Renamed method `DeleteDocumentModel` to `DeleteModel`.

- Renamed method `BuildDocumentClassifier` to `BuildClassifier`:
  - Removed parameters `documentTypes`, `classifierId`, and `description`.
  - The method now takes a `buildRequest` parameter of type `BuildDocumentClassifierContent` containing all the options.
  - Changed the return type from `BuildDocumentClassifierOperation` to `Operation<DocumentClassifierDetails>`. The type `BuildDocumentClassifierOperation` has been removed.
- Renamed method `GetDocumentClassifier` to `GetClassifier`.
- Renamed method `GetDocumentClassifiers` to `GetClassifiers`.
- Renamed method `DeleteDocumentClassifiers` to `DeleteClassifiers`.

- In method `GetOperations`, changed the return type from `OperationSummary` to `OperationDetails`.
- Renamed method `GetResourceDetails` to `GetResourceInfo`.

- In `DocumentField`:
  - Renamed property `ExpectedFieldType` to `Type`.
  - Removed property `FieldType`.
  - Removed property `Value` along with the `DocumentFieldValue` type.
  - The value of the field can now be extracted from one of the its new value properties, depending on the type of the field (`ValueAddress` for type `Address`, `ValueBoolean` for type `Boolean`, and so on).
- In `DocumentFieldType`:
  - Updated it to be a struct instead of an enum.
  - Removed member `Unknown`.
  - Renamed member `List` to `Array`.
  - Renamed member `Int64` to `Integer`.
  - Renamed member `Double` to `Number`.
  - Renamed member `Dictionary` to `Object`.
- In `CurrencyValue`:
  - Updated it to be a class instead of a struct.
  - Renamed `Code` to `CurrencyCode`.
  - Renamed `Symbol` to `CurrencySymbol`.

- In `AnalyzeResult`, renamed property `ServiceVersion` to `ApiVersion`.
- In `AnalyzedDocument`, renamed property `DocumentType` to `DocType`.
- Updated `DocumentSpan` to be a class instead of a struct.
- In `DocumentSpan`, renamed property `Index` to `Offset`.
- All properties `BoundingPolygon` across the library were renamed to `Polygon`. They are now a list of `float` instead of `PointF`.
- In `DocumentLine`, removed method `GetWords`.
- In `DocumentTableCell`, made properties `ColumnSpan`, `RowSpan`, and `Kind` nullable.
- Updated `DocumentSelectionMarkState` to be a struct instead of an enum.
- Renamed type `DocumentFontStyle` to `FontStyle`.
- Renamed type `DocumentFontWeight` to `FontWeight`.
- Renamed type `DocumentPageLengthUnit` to `LengthUnit`.
- In `DocumentBarcodeKind`:
  - Renamed member `Ean13` to `EAN13`.
  - Renamed member `Ean8` to `EAN8`.
  - Renamed member `Itf` to `ITF`.
  - Renamed member `MicroQrCode` to `MicroQRCode`.
  - Renamed member `Pdf417` to `PDF417`.
  - Renamed member `QrCode` to `QRCode`.
  - Renamed member `Upca` to `UPCA`.
  - Renamed member `Upce` to `UPCE`.

- Removed type `DocumentContentSource`.
- Renamed type `BlobContentSource` to `AzureBlobContentSource`.
- In `AzureBlobContentSource` (former `BlobContentSource`), renamed property `ContainerUri` to `ContainerUrl`.
- Renamed type `BlobFileListContentSource` to `AzureBlobFileListContentSource`.
- In `AzureBlobFileListContentSource` (former `BlobFileListContentSource`), renamed property `ContainerUri` to `ContainerUrl`.

- In `ClassifierDocumentTypeDetails`:
  - Removed property `SourceKind`.
  - Removed property `TrainingDataSource`. It was replaced by properties `AzureBlobSource` and `AzureBlobFileListSource`.
  - Either `AzureBlobSource` or `AzureBlobFileListSource` must be set before sending a Build Classifier request.

- Removed type `DocumentModelSummary`.
- In `DocumentModelDetails`, renamed property `DocumentTypes` to `DocTypes`.
- In `DocumentModelDetails`, renamed property `ServiceVersion` to `ApiVersion`.
- In `DocumentModelDetails`, renamed property `CreatedOn` to `CreatedDateTime`.
- In `DocumentModelDetails`, renamed property `ExpiresOn` to `ExpirationDateTime`.

- Removed type `OperationSummary`.
- In `OperationDetails`, removed property `Kind` along with the type `DocumentOperationKind`. The `OperationDetails` instance can be type-checked for this purpose.
- In `OperationDetails`, renamed property `ServiceVersion` to `ApiVersion`.
- In `OperationDetails`, renamed property `CreatedOn` to `CreatedDateTime`.
- In `OperationDetails`, renamed property `LastUpdatedOn` to `LastUpdatedDateTime`.
- In `OperationDetails`, changed the type of the property `Error` from `ResponseError` to `DocumentIntelligenceError`.

- In `DocumentClassifierDetails`, renamed property `DocumentTypes` to `DocTypes`.
- In `DocumentClassifierDetails`, renamed property `ServiceVersion` to `ApiVersion`.
- In `DocumentClassifierDetails`, renamed property `CreatedOn` to `CreatedDateTime`.
- In `DocumentClassifierDetails`, renamed property `ExpiresOn` to `ExpirationDateTime`.

- Renamed type `DocumentOperationStatus` to `OperationStatus`.
- Updated `OperationStatus` (former `DocumentOperationStatus`) to be a struct instead of an enum.
- In `ResourceDetails`, moved properties `CustomDocumentModelCount` and `CustomDocumentModelLimit` to the new property `CustomDocumentModels` of type `CustomDocumentModelsDetails`.
- In `ResourceDetails`, renamed property `NeuralDocumentModelQuota` to `CustomNeuralDocumentModelBuilds`.
- Renamed type `ResourceQuotaDetails` to `QuotaDetails`.
- In `QuotaDetails` (former `ResourceQuotaDetails`), renamed property `QuotaResetsOn` to `QuotaResetStartTime`.
- Renamed type `DocumentModelCopyAuthorization` to `CopyAuthorization`.
- In `CopyAuthorization` (former `DocumentModelCopyAuthorization`), renamed property `ExpiresOn` to `ExpirationDateTime`.

[migration_guide]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/MigrationGuide.md
[protocol_methods]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md
