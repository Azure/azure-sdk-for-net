# Analyze a document with a prebuilt model

This sample demonstrates how to extract text and key information from documents with one of the service's prebuilt models, using an invoice as an example. For a list of the types of documents supported by the Form Recognize service's prebuilt models, please check the [Choosing the prebuilt model ID][choosing-the-prebuilt-model-id] section.

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
```

## Choosing the prebuilt model ID

The model to use for the analyze operation depends on the type of document to be analyzed. These are the IDs of the prebuilt models currently supported by the Form Recognizer service:

- prebuilt-businessCard: extracts text and key information from English business cards. [Supported fields][businessCard_fields].
- prebuilt-idDocument: extracts text and key information from US driver licenses and international passports. [Supported fields][idDocument_fields].
- prebuilt-invoice: extracts text, selection marks, tables, key-value pairs, and key information from English invoices. [Supported fields][invoice_fields].
- prebuilt-receipt: extracts text and key information from English receipts. [Supported fields][receipt_fields].

## Use a prebuilt model to analyze a document from a URI

To analyze a given file at a URI, use the `StartAnalyzeDocumentFromUri` method. The returned value is an `AnalyzeResult` object containing data about the submitted document. Since we're analyzing an English invoice, we'll pass the model ID `prebuilt-invoice` to the method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult the [Choosing the prebuilt model ID][choosing-the-prebuilt-model-id] section.

```C# Snippet:FormRecognizerAnalyzeWithPrebuiltModelFromUriAsync
```

## Use a prebuilt model to analyze a document from a file stream

To analyze a given file at a file stream, use the `StartAnalyzeDocument` method. The returned value is an `AnalyzeResult` object containing data about the submitted document. Since we're analyzing an English invoice, we'll pass the model ID `prebuilt-invoice` to the method.

For simplicity, we are not showing all the fields that the service returns. To see the list of all the supported fields returned by service and its corresponding types, consult the [Choosing the prebuilt model ID][choosing-the-prebuilt-model-id] section.

```C# Snippet:FormRecognizerAnalyzeWithPrebuiltModelFromFileAsync
```

To see the full example source files, see:

* [Analyze document from URI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeDocumentFromUriAsync.cs)
* [Analyze document from document](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeDocumentFromFileAsync.cs)

[businessCard_fields]: https://aka.ms/formrecognizer/businesscardfields
[idDocument_fields]: https://aka.ms/formrecognizer/iddocumentfields
[invoice_fieds]: https://aka.ms/formrecognizer/invoicefields
[receipt_fields]: https://aka.ms/formrecognizer/receiptfields

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
