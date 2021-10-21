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
> Note: Starting with version `2021-09-30-preview`, a new set of clients were introduced to leverage the newest features of the Form Recognizer service. Please see the [Migration Guide][migration_guide] for detailed instructions on how to update application code from client library version `3.1.X` or lower to the latest version. Additionally, see the [Changelog][changelog] for more detailed information.

Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to analyze text and structured data from your documents. It includes the following main features:

- Layout - Extract text, selection marks, and table structures, along with their bounding region coordinates, from documents.
- Document - Analyze key-value pairs and entities in addition to general layout from documents.
- Prebuilt - Analyze data from certain types of common documents (such as receipts, invoices, business cards, or identity documents) using prebuilt models.
- Custom - Build custom models to analyze text, field values, selection marks, and tabular data from documents. Custom models are trained with your own data, so they're tailored to your documents.

## Common scenarios samples for client library version 4.0.0-beta.x
- [Extract the layout of a document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ExtractLayout.md)
- [Analyze with the prebuilt document model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuiltDocument.md)
- [Analyze a document with a custom model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithCustomModel.md)
- [Analyze a document with a prebuilt model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithPrebuiltModel.md)
- [Build a custom model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildCustomModel.md)
- [Manage models](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ManageModels.md)

## Advanced samples for client library version 4.0.0-beta.x
- [Create a composed model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ModelCompose.md)
- [Get and List document model operations](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_GetAndListOperations.md)
- [Copy a custom model between Form Recognizer resources](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_CopyCustomModel.md)

## Samples for client library versions 3.1.x and below
Please see the samples [here][v31samples].

[changelog]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/CHANGELOG.md
[v31samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/README.md
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/MigrationGuide.md
