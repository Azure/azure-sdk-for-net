# Recognizing Personally Identifiable Information in Documents
This sample demonstrates how to recognize Personally Identifiable Information (PII) in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize Personally Identifiable Information in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating a `TextAnalyticsApiKeyCredential` object, that if neded, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample5CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));
```

## Recognizing Personally Identifiable Information in a single document

To recognize Personally Identifiable Information in a document, use the `RecognizePiiEntities` method.  The returned value is the collection of `CategorizedEntity` containing Personally Identifiable Information that were recognized in the document.

```C# Snippet:RecognizePiiEntities
string input = "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.";

IReadOnlyCollection<PiiEntity> entities = client.RecognizePiiEntities(input).Value;

Console.WriteLine($"Recognized {entities.Count()} PII entit{(entities.Count() > 1 ? "ies" : "y")}:");
foreach (PiiEntity entity in entities)
{
    Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
}
```

## Recognizing Personally Identifiable Information in multiple documents

To recognize Personally Identifiable Information in multiple documents, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of strings.  The results are returned as a `RecognizePiiEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesConvenience
RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(inputs);
```

To recognize Personally Identifiable Information in a collection of documents in different languages, call `RecognizePiiEntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesBatch
var inputs = new List<TextDocumentInput>
{
    new TextDocumentInput("1", "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.")
    {
         Language = "en",
    },
    new TextDocumentInput("2","Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
    {
         Language = "en",
    }
};

RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntitiesBatch(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample5_RecognizePiiEntities.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntities.cs)
* [Sample5_RecognizePiiEntitiesBatch.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatch.cs)
* [Sample5_RecognizePiiEntitiesBatchConvenience.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample5_RecognizePiiEntitiesBatchConvenience.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md