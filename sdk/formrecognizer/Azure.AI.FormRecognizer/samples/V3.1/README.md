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

# Azure Form Recognizer client SDK V3.1 Samples
Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to recognize form fields, text, and tables in form documents. It includes the following capabilities:

- Recognize form content - Recognize and extract tables, lines, words, and selection marks like radio buttons and check boxes in forms documents, without the need to train a model.
- Recognize custom forms - Recognize and extract form fields and other content from your custom forms, using models you trained with your own form types.
- Recognize Prebuilt models - Recognize data using the following prebuilt models:
  - Receipts - Recognize and extract common fields from receipts, using a pre-trained receipt model.
  - Business Cards - Recognize and extract common fields from business cards, using a pre-trained business cards model.
  - Invoices - Recognize and extract common fields from invoices, using a pre-trained invoice model.
  - Identity Documents - Recognize and extract common fields from identity documents like passports or driver's licenses, using a pre-trained identity documents model.

## Common scenarios samples for SDK v3.1
- [Recognize form content](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample1_RecognizeFormContent.md)
- [Recognize custom forms](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample2_RecognizeCustomForms.md)
- [Recognize receipts](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample3_RecognizeReceipts.md)
- [Recognize business cards](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample9_RecognizeBusinessCards.md)
- [Recognize invoices](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample10_RecognizeInvoices.md)
- [Recognize identity documents](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample11_RecognizeIdentityDocuments.md)
- [Train a model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample5_TrainModel.md)
- [Manage custom models](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample6_ManageCustomModels.md)

## Advanced samples for SDK v3.1
- [Strongly-typing a recognized form](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample4_StronglyTypingARecognizedForm.md)
- [Create a composed model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample8_ModelCompose.md)
- [Differentiate output models trained with and without labels](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/V3.1/Sample10_DifferentiateOutputModelsTrainedWithAndWithoutLabels.cs)
- [Differentiate output labeled tables](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/V3.1/Sample15_DifferentiateOutputLabeledTables.cs)
- [Copy a custom model between Form Recognizer resources](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample7_CopyCustomModel.md)
- [Field Bounding Box](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/V3.1/Sample9_FieldBoundingBox.cs)
- [Mock a client for testing using the Moq library](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/Sample_MockClient.md)
