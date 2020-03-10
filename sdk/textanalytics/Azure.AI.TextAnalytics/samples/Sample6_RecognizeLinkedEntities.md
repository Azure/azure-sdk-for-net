# Recognizing Linked Entities in Documents
This sample demonstrates how to recognize linked entities in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize linked entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development. In the sample below, however, you'll use a Text Analytics API key credential by creating a `TextAnalyticsApiKeyCredential` object, that if neded, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample6CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));
```

## Recognizing linked entities in a single document

To recognize linked entities in a document, use the `RecognizeLinkedEntities` method.  The returned value is the collection of `LinkedEntities` containing entities recognized in the document as well as links to those entities in a reference data source, such as Wikipedia.

```C# Snippet:RecognizeLinkedEntities
string input = "Microsoft was founded by Bill Gates and Paul Allen.";

IReadOnlyCollection<LinkedEntity> linkedEntities = client.RecognizeLinkedEntities(input).Value;

Console.WriteLine($"Extracted {linkedEntities.Count} linked entit{(linkedEntities.Count > 1 ? "ies" : "y")}:");
foreach (LinkedEntity linkedEntity in linkedEntities)
{
    Console.WriteLine($"Name: {linkedEntity.Name}, Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Url: {linkedEntity.Url.ToString()}, Entity Id in Data Source: {linkedEntity.DataSourceEntityId}");
    foreach (LinkedEntityMatch match in linkedEntity.Matches)
    {
        Console.WriteLine($"    Match Text: {match.Text}, Confidence score: {match.ConfidenceScore}");
    }
}
```

## Recognizing linked entities in multiple documents

To recognize linked entities in multiple documents, call `RecognizeLinkedEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizeLinkedEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntitiesBatch(inputs);
```

To recognize linked entities in a collection of documents in different languages, call `RecognizeLinkedEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesBatch
var inputs = new List<TextDocumentInput>
{
    new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
    {
         Language = "en",
    },
    new TextDocumentInput("2", "Text Analytics is one of the Azure Cognitive Services.")
    {
         Language = "en",
    },
    new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
    {
         Language = "en",
    }
};

RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntitiesBatch(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample6_RecognizeLinkedEntities.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntities.cs)
* [Sample6_RecognizeLinkedEntitiesBatch.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesBatch.cs)
* [Sample6_RecognizeLinkedEntitiesBatchConvenience.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvenience.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md