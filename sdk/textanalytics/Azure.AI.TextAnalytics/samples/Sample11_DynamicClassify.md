# Performing dynamic classification of documents
This sample demonstrates how to perform dynamic classification of one or more documents.

## Create a `TextAnalyticsClient`
To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform dynamic classification of a single document
To perform dynamic classification of a document, call `DynamicClassify` on the `TextAnalyticsClient` by passing the document as a string parameter, in addition to the categories that it can be classified with as an `IEnumerable<string>` parameter. This returns a `ClassificationCategoryCollection`.

```C# Snippet:Sample11DynamicClassify
// Get the document.
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
    Response<ClassificationCategoryCollection> response = client.DynamicClassify(document, categories);
    ClassificationCategoryCollection classifications = response.Value;

    Console.WriteLine($"The document was classified as follows:");
    Console.WriteLine();

    foreach (ClassificationCategory classification in classifications)
    {
        Console.WriteLine($"  Category: {classification.Category}");
        Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}.");
        Console.WriteLine();
    }
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Perform dynamic classification of multiple document
To perform dynamic classification of multiple documents, call `DynamicClassifyBatch` on the `TextAnalyticsClient` by passing the documents as an `IEnumerable<string>` parameter, in addition to the categories that they can be classified with as another `IEnumerable<string>` parameter. This returns a `DynamicClassifyDocumentResultCollection`.

```C# Snippet:Sample11DynamicClassifyBatchConvenience
// Get the documents.
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

// Specify the categories that the documents can be classified with.
List<string> categories = new()
{
    "Health",
    "Politics",
    "Music",
    "Sports",
    "Technology"
};

List<string> documents = new()
{
    documentA,
    documentB,
    documentC
};

Response<DynamicClassifyDocumentResultCollection> response = client.DynamicClassifyBatch(documents, categories);
DynamicClassifyDocumentResultCollection batchResults = response.Value;

int i = 0;
Console.WriteLine($"Results of \"Dynamic Classification\" Model, version: \"{batchResults.ModelVersion}\"");
Console.WriteLine();

foreach (ClassifyDocumentResult documentResult in batchResults)
{
    Console.WriteLine($"On document with Text: \"{documents[i++]}\"");
    Console.WriteLine();

    if (documentResult.HasError)
    {
        Console.WriteLine("  Error!");
        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}.");
        Console.WriteLine($"  Message: {documentResult.Error.Message}");
        Console.WriteLine();
        continue;
    }

    foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
    {
        Console.WriteLine($"  Category: {classification.Category}");
        Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}.");
        Console.WriteLine();
    }
}
```

See the [README][README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
