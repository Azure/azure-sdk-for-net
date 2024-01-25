---
page_type: sample
languages:
- csharp
products:
- azure
- azure-cognitive-services
- azure-form-recognizer
name: Azure Form Recognizer samples for .NET
description: Samples for the Azure.AI.FormRecognizer client library
---

# Azure Form Recognizer client SDK Samples

> Note: on July 2023, the Azure Cognitive Services Form Recognizer service was renamed to Azure AI Document Intelligence. Any mentions to Form Recognizer or Document Intelligence in documentation refer to the same Azure service.

> Note: starting with version `4.0.0`, a new set of clients were introduced to leverage the newest features of the Document Intelligence service. Please see the [Migration Guide][migration_guide] for detailed instructions on how to update application code from client library version `3.1.1` or lower to the latest version. Additionally, see the [Changelog][changelog] for more detailed information.

Azure AI Document Intelligence is a cloud service that uses machine learning to analyze text and structured data from your documents. It includes the following main features:

- Layout - Extract text, selection marks, table structures, styles, and paragraphs, along with their bounding region coordinates from documents.
- General document - Analyze key-value pairs in addition to general layout from documents.
- Read - Read information about textual elements, such as page words and lines in addition to text language information.
- Prebuilt - Analyze data from certain types of common documents using prebuilt models. Supported documents include receipts, invoices, business cards, identity documents, vaccination cards, US W2 tax forms, and US health insurance cards.
- Custom analysis - Build custom document models to analyze text, field values, selection marks, table structures, styles, and paragraphs from documents. Custom models are built with your own data, so they're tailored to your documents.
- Custom classification - Build custom classifier models that combine layout and language features to accurately detect and identify documents you process within your application.

## Common scenarios samples for client library version 4.0.0 and higher
- [Extract the layout of a document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ExtractLayout.md)
- [Analyze with the prebuilt general document model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuiltDocument.md)
- [Analyze with the prebuilt read model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuiltRead.md)
- [Analyze a document with a custom model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithCustomModel.md)
- [Analyze a document with a prebuilt model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithPrebuiltModel.md)
- [Build a custom model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildCustomModel.md)
- [Manage models](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ManageModels.md)
- [Classify a document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ClassifyDocument.md)
- [Build a document classifier](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildDocumentClassifier.md)

## Advanced samples for client library version 4.0.0 and higher
- [Compose a model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ModelCompose.md)
- [Get and List document model operations](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_GetAndListOperations.md)
- [Copy a custom model between Form Recognizer resources](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_CopyCustomModel.md)
- [Mock a client for testing using the Moq library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_MockClient.md)

## Samples for client library versions 3.1.1 and lower
Please see the samples [here][v31samples].

[changelog]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/CHANGELOG.md
[v31samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/README.md
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/MigrationGuide.md
