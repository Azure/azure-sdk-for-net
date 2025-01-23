# Extract the layout of a document as Markdown

This sample demonstrates how to extract text, paragraphs, styles, table structures, and selection marks, along with their bounding region coordinates from documents, presenting the output text in Markdown syntax.

To get started you'll need an Azure AI services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceClient`

To create a new `DocumentIntelligenceClient` you need the endpoint and credentials from your resource. In the sample below you'll make use of identity-based authentication by creating a `DefaultAzureCredential` object.

You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new DocumentIntelligenceClient(new Uri(endpoint), credential);
```

## Extract the layout of a document as Markdown

To extract the layout from a given file at a URI, use the `AnalyzeDocument` method and pass `prebuilt-layout` as the model ID. The output format can be selected with the option `OutputContentFormat`, which we will set to `Markdown` in the sample below. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceExtractLayoutAsMarkdownAsync
Uri uriSource = new Uri("<uriSource>");

var options = new AnalyzeDocumentOptions("prebuilt-layout", uriSource)
{
    OutputContentFormat = DocumentContentFormat.Markdown
};

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
AnalyzeResult result = operation.Value;

Console.WriteLine(result.Content);
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
