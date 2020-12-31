# Release History

## 3.1.0-beta.2 (Unreleased)


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
[readme]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
