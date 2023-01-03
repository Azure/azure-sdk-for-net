# Classify documents with dynamic classification

This sample demonstrates how to perform dynamic classification. Also known as zero-shot classification, this is a feature of the Azure Cognitive Service for Language used to classify text documents without the need to train a model.

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential apiKey = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Classify a single document

To classify a text document using dynamic classification, call `DynamicClassify` on the `TextAnalyticsClient` by passing the document as a string parameter in addition to passing the categories that it can be classified with as an `IEnumerable<string>` parameter. This returns a `ClassificationCategoryCollection`.

```C# Snippet:Sample11_DynamicClassifyAsync
string document =
    "“The Microsoft Adaptive Accessories are intended to remove the barriers that traditional mice and"
    + " keyboards may present to people with limited mobility,” says Gabi Michel, director of Accessible"
    + " Accessories at Microsoft. “No two people are alike, and empowering people to configure their own"
    + " system that works for them was definitely the goal.”";

// Specify the categories that the document can be classified with.
List<string> categories = new()
{
    "Health",
    "Politics",
    "Music",
    "Sports",
    "Technology"
};

try
{
    Response<ClassificationCategoryCollection> response = await client.DynamicClassifyAsync(document, categories);
    ClassificationCategoryCollection classifications = response.Value;

    Console.WriteLine($"The document was classified as:");
    foreach (ClassificationCategory classification in classifications)
    {
        Console.WriteLine($"  Category: {classification.Category}");
        Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"  Error!");
    Console.WriteLine($"  ErrorCode: {exception.ErrorCode}");
    Console.WriteLine($"  Message: {exception.Message}");
}
```

## Classify multiple documents

To classify multiple text documents at a time using dynamic classification, call `DynamicClassifyBatch` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter in addition to passing the categories that they can be classified with as another `IEnumerable<string>` parameter. This returns a `DynamicClassifyDocumentResultCollection`.

```C# Snippet:Sample11_DynamicClassifyBatchConvenienceAsync
string documentA =
    "“The Microsoft Adaptive Accessories are intended to remove the barriers that traditional mice and"
    + " keyboards may present to people with limited mobility,” says Gabi Michel, director of Accessible"
    + " Accessories at Microsoft. “No two people are alike, and empowering people to configure their own"
    + " system that works for them was definitely the goal.”";

string documentB =
    "The Seattle Seahawks are a professional American football team based in Seattle. The Seahawks compete"
    + " in the National Football League (NFL) as a member club of the league's National Football"
    + " Conference (NFC) West, which they rejoined in 2002 as part of conference realignment.";

string documentC = string.Empty;

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    documentA,
    documentB,
    documentC
};

// Specify the categories that the documents can be classified with.
List<string> categories = new()
{
    "Health",
    "Politics",
    "Music",
    "Sports",
    "Technology"
};

Response<DynamicClassifyDocumentResultCollection> response = await client.DynamicClassifyBatchAsync(batchedDocuments, categories);
DynamicClassifyDocumentResultCollection results = response.Value;

int i = 0;
Console.WriteLine($"Dynamic Classify, model version: \"{results.ModelVersion}\"");
Console.WriteLine();

foreach (ClassifyDocumentResult documentResult in results)
{
    Console.WriteLine($"Result for document with Text = \"{batchedDocuments[i++]}\"");

    if (documentResult.HasError)
    {
        Console.WriteLine($"  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
    {
        Console.WriteLine($"  Category: {classification.Category}");
        Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
        Console.WriteLine();
    }
}
```

See the [README][README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
