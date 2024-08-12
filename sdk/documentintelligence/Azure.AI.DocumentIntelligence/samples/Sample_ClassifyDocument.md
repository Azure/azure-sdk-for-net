# Classify a document

This sample demonstrates how to use document classifiers to accurately detect and identify documents you process within your application. Document classifiers are trained with your own data, so they're tailored to your documents. For more information on how to do the training, see [build a document classifier][build_classifier].

To get started you'll need a Cognitive Services resource or a Form Recognizer resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceClient`

To create a new `DocumentIntelligenceClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Classify a document from a URI

To classify a given file at a URI, use the `ClassifyDocument` method. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceClassifyDocumentFromUriAsync
string classifierId = "<classifierId>";
Uri uriSource = new Uri("<uriSource>");

var content = new ClassifyDocumentContent()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, classifierId, content);
AnalyzeResult result = operation.Value;

Console.WriteLine($"Input was classified by the classifier with ID '{result.ModelId}'.");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Found a document of type: {document.DocType}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
[build_classifier]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_BuildDocumentClassifier.md
