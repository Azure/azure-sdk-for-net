# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
