# Analyze a document with a custom model

This sample demonstrates how to extract text and key information from your custom documents, using models you built with your own document types. For more information on how to do the training, see [build a model][build_a_model].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
```

## Use a custom model to analyze a document from a URI

To analyze a given file at a URI, use the `StartAnalyzeDocumentFromUri` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerAnalyzeWithCustomModelFromUriAsync
```

## Use a custom model to analyze a document from a file stream

To analyze a given file at a file stream, use the `StartAnalyzeDocument` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerAnalyzeWithCustomModelFromFileAsync
```

To see the full example source files, see:

* [Analyze with custom model from URI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeWithCustomModelFromUriAsync.cs)
* [Analyze with custom model from file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeWithCustomModelFromFileAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[build_a_model]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildModel.md
