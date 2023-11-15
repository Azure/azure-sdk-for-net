# Analyze with the prebuilt general document model

This sample demonstrates how to analyze key-value pairs, tables, and selection marks from documents using the prebuilt general document model.

To get started you'll need a Cognitive Services resource or a Document Intelligence resource. See [README][README] for prerequisites and instructions.

## Creating a `DocumentIntelligenceClient`

To create a new `DocumentIntelligenceClient` you need the endpoint and credentials from your resource. In the sample below you'll use a Document Intelligence API key credential by creating an `AzureKeyCredential` object that, if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentAnalysisClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Use the prebuilt general document model to analyze a document from a URI

To analyze a given file at a URI, use the `AnalyzeDocument` method and pass `prebuilt-document` as the model ID. The returned value is an `AnalyzeResult` object containing data about the submitted document.

```C# Snippet:DocumentIntelligenceAnalyzePrebuiltDocumentFromUriAsync
Uri uriSource = new Uri("<uriSource>");

var request = new AnalyzeDocumentRequest()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-document", request);
AnalyzeResult result = operation.Value;

Console.WriteLine("Detected key-value pairs:");
foreach (DocumentKeyValuePair kvp in result.KeyValuePairs)
{
    if (kvp.Value == null)
    {
        Console.WriteLine($"  Found key '{kvp.Key.Content}' with no value");
    }
    else
    {
        Console.WriteLine($"  Found key '{kvp.Key.Content}' with value '{kvp.Value.Content}'");
    }
}

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s)," +
        $" and {page.SelectionMarks.Count} selection mark(s).");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        DocumentLine line = page.Lines[i];
        Console.WriteLine($"  Line {i}:");
        Console.WriteLine($"    Content: '{line.Content}'");

        Console.Write("    Bounding polygon, with points ordered clockwise:");
        for (int j = 0; j < line.Polygon.Count; j += 2)
        {
            Console.Write($" ({line.Polygon[j]}, {line.Polygon[j + 1]})");
        }

        Console.WriteLine();
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        DocumentSelectionMark selectionMark = page.SelectionMarks[i];

        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine($"    State: {selectionMark.State}");

        Console.Write("    Bounding polygon, with points ordered clockwise:");
        for (int j = 0; j < selectionMark.Polygon.Count; j++)
        {
            Console.Write($" ({selectionMark.Polygon[j]}, {selectionMark.Polygon[j + 1]})");
        }

        Console.WriteLine();
    }
}

Console.WriteLine("Detected tables:");
for (int i = 0; i < result.Tables.Count; i++)
{
    DocumentTable table = result.Tables[i];

    Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

    foreach (DocumentTableCell cell in table.Cells)
    {
        Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) is a '{cell.Kind}' with content: '{cell.Content}'");
    }
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence#getting-started
