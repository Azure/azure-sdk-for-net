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
Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to recognize form fields, text, and tables in form documents. It includes the following capabilities:

- Layout - Extract text, table structures, and selection marks, along with their bounding region coordinates, from documents.
- Document - Analyze entities, key-value pairs, tables, and selection marks from documents using the general prebuilt document model.
- Prebuilt - Analyze data from certain types of common documents (such as receipts, invoices, business cards, or identity documents) using pre-trained models.
- Custom - Build custom models to analyze text, field values, selection marks, and table data from documents. Custom models are trained with your own data, so they're tailored to your documents.

## Common scenarios samples for SDK
- [Extract the layout of a document](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ExtractLayout.md)
- [Analyze with the prebuilt document model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuiltDocument.md)
- [Analyze a document with a custom model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeCustom.md)
- [Analyze a document with a prebuilt model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuilt.md)
- [Build a model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildModel.md)
- [Manage models](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ManageModels.md)

## Advanced samples for SDK
- [Create a composed model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ModelCompose.md)
- [Copy a custom model between Form Recognizer resources](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_CopyCustomModel.md)
- [Get and List document model operations](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_GetAndListOperations.md)
