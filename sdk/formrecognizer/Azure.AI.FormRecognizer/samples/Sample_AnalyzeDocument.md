# Analyze a document

This sample demonstrates how to extract text, tables, styles, selection marks like radio buttons, entities, key-value pairs, and layout information from documents, without the need to train a model.

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
```

## Analyze a document from a URI

To analyze a given file at a URI, use the `StartAnalyzeDocumentFromUri` method and pass `prebuilt-document` as the model ID. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerAnalyzeDocumentFromUriAsync
```

## Analyze a document from a file stream

To analyze a given file at a file stream, use the `StartAnalyzeDocument` method and pass `prebuilt-document` as the model ID. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerAnalyzeDocumentFromFileAsync
```

To see the full example source files, see:

* [Analyze document from URI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeDocumentFromUriAsync.cs)
* [Analyze document from file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeDocumentFromFileAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
