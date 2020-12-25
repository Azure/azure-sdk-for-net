# Recognizing Personally Identifiable Information in Documents
This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents. To get started you'll need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize Personally Identifiable Information in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if neded, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample5CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing Personally Identifiable Information in a single document

To recognize Personally Identifiable Information in a document, use the `RecognizePiiEntities` method.  The returned value is the collection of `PiiEntity` containing Personally Identifiable Information that were recognized in the document.

```C# Snippet:RecognizePiiEntities
string document = "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.";

PiiEntityCollection entities = client.RecognizePiiEntities(document).Value;

Console.WriteLine($"Redacted Text: {entities.RedactedText}");
if (entities.Count > 0)
{
    Console.WriteLine($"Recognized {entities.Count} PII entit{(entities.Count > 1 ? "ies" : "y")}:");
    foreach (PiiEntity entity in entities)
    {
        Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
    }
}
else
{
    Console.WriteLine("No entities were found.");
}
```

## Recognizing Personally Identifiable Information in multiple documents

To recognize Personally Identifiable Information in multiple documents, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizePiiEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesConvenience
RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(documents);
```

To recognize Personally Identifiable Information in a collection of documents in different languages, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesBatch
var documents = new List<TextDocumentInput>
{
    new TextDocumentInput("1", "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.")
    {
         Language = "en",
    },
    new TextDocumentInput("2", "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
    {
         Language = "en",
    }
};

RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(documents, new RecognizePiiEntitiesOptions { IncludeStatistics = true });
```

To see the full example source files, see:
* [Synchronous RecognizePiiEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntities.cs)
* [Asynchronous RecognizePiiEntities](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesAsync.cs)
* [Synchronous RecognizePiiEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatch.cs)
* [Asynchronous RecognizePiiEntitiesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchAsync.cs)
* [Synchronous RecognizePiiEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchConvenience.cs)
* [Asynchronous RecognizePiiEntitiesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md