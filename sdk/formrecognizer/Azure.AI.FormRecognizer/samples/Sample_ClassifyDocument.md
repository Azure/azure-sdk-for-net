# Classify a document

This sample demonstrates how to use document classifiers to accurately detect and identify documents you process within your application. Document classifiers are trained with your own data, so they're tailored to your documents. For more information on how to do the training, see [build a document classifier][build_classifier].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
```

## Classify a document from a URI

To classify a given file at a URI, use the `ClassifyDocumentFromUri` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerClassifyDocumentFromUriAsync
string classifierId = "<classifierId>";
Uri fileUri = new Uri("<fileUri>");

ClassifyDocumentOperation operation = await client.ClassifyDocumentFromUriAsync(WaitUntil.Completed, classifierId, fileUri);
AnalyzeResult result = operation.Value;

Console.WriteLine($"Document was classified by classifier with ID: {result.ModelId}");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Document of type: {document.DocumentType}");
}
```

## Classify a document from a file stream

To classify a given file at a file stream, use the `ClassifyDocument` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerClassifyDocumentFromFileAsync
string classifierId = "<classifierId>";
string filePath = "<filePath>";

using var stream = new FileStream(filePath, FileMode.Open);

ClassifyDocumentOperation operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, classifierId, stream);
AnalyzeResult result = operation.Value;

Console.WriteLine($"Document was classified by classifier with ID: {result.ModelId}");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Document of type: {document.DocumentType}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[build_classifier]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildDocumentClassifier.md
