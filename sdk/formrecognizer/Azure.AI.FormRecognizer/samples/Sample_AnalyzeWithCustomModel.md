# Analyze a document with a custom model

This sample demonstrates how to analyze text, field values, selection marks, and table data from custom documents. Custom models are trained with your own data, so they're tailored to your documents. For more information on how to do the training, see [build a model][build_a_model].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource.  See [README][README] for prerequisites and instructions.

## Creating a `DocumentAnalysisClient`

To create a new `DocumentAnalysisClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Form Recognizer API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentAnalysisClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
```

## Use a custom model to analyze a document from a URI

To analyze a given file at a URI, use the `StartAnalyzeDocumentFromUri` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerAnalyzeWithCustomModelFromUriAsync
string modelId = "<modelId>";
string fileUri = "<fileUri>";

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync(modelId, fileUri);

await operation.WaitForCompletionAsync();

AnalyzeResult result = operation.Value;

Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Document of type: {document.DocType}");

    foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
    {
        string fieldName = fieldKvp.Key;
        DocumentField field = fieldKvp.Value;

        Console.WriteLine($"Field '{fieldName}': ");

        Console.WriteLine($"  Content: '{field.Content}'");
        Console.WriteLine($"  Confidence: '{field.Confidence}'");
    }
}
```

## Use a custom model to analyze a document from a file stream

To analyze a given file at a file stream, use the `StartAnalyzeDocument` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:FormRecognizerAnalyzeWithCustomModelFromFileAsync
string modelId = "<modelId>";
string filePath = "<filePath>";

using var stream = new FileStream(filePath, FileMode.Open);

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentAsync(modelId, stream);

await operation.WaitForCompletionAsync();

AnalyzeResult result = operation.Value;

Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Document of type: {document.DocType}");

    foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
    {
        string fieldName = fieldKvp.Key;
        DocumentField field = fieldKvp.Value;

        Console.WriteLine($"Field '{fieldName}': ");

        Console.WriteLine($"  Content: '{field.Content}'");
        Console.WriteLine($"  Confidence: '{field.Confidence}'");
    }
}
```

To see the full example source files, see:

* [Analyze with custom model from URI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeWithCustomModelFromUriAsync.cs)
* [Analyze with custom model from file](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/samples/Sample_AnalyzeWithCustomModelFromFileAsync.cs)

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer#getting-started
[build_a_model]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildCustomModel.md
