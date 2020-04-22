# Release History

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
