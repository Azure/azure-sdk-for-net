# Recognizing Entities from Documents
This sample demonstrates how to recognize entities in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample4CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing entities in a single document

To recognize entities in a document, use the `RecognizeEntities` method.  The returned type is the collection of `CategorizedEntity` that were recognized in the document.

```C# Snippet:RecognizeEntities
string document = "Microsoft was founded by Bill Gates and Paul Allen.";

CategorizedEntityCollection entities = client.RecognizeEntities(document);

Console.WriteLine($"Recognized {entities.Count} entities:");
foreach (CategorizedEntity entity in entities)
{
    Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
}
```

## Recognizing entities in multiple documents

To recognize entities in multiple documents, call `RecognizeEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizeEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample4RecognizeEntitiesConvenience
RecognizeEntitiesResultCollection results = client.RecognizeEntitiesBatch(documents);
```

To recognize entities in a collection of documents in different languages, call `RecognizeEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample4RecognizeEntitiesBatch
var documents = new List<TextDocumentInput>
{
    new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
    {
         Language = "en",
    },
    new TextDocumentInput("2", "Text Analytics is one of the Azure Cognitive Services.")
    {
         Language = "en",
    },
    new TextDocumentInput("3", "A key technology in Text Analytics is Named Entity Recognition (NER).")
    {
         Language = "en",
    }
};

RecognizeEntitiesResultCollection results = client.RecognizeEntitiesBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Synchronously RecognizeEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntities.cs)
* [Asynchronously RecognizeEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesAsync.cs)
* [Synchronously RecognizeEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatch.cs)
* [Asynchronously RecognizeEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatchAsync.cs)
* [Synchronously RecognizeEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatchConvenience.cs)
* [Asynchronously RecognizeEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample4_RecognizeEntitiesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md