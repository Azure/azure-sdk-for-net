# Analyzing the Sentiment of Documents

This sample demonstrates how to analyze the sentiment in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to analyze the sentiment in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample2CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Analyzing the sentiment of a single document

To analyze the sentiment of a document, use the `AnalyzeSentiment` method.  The returned `DocumentSentiment` describes the sentiment of the document, as well as a collection of `Sentences` indicating the sentiment of each individual sentence.

```C# Snippet:AnalyzeSentiment
string document = "That was the best day of my life!";

DocumentSentiment docSentiment = client.AnalyzeSentiment(document);

Console.WriteLine($"Sentiment was {docSentiment.Sentiment}, with confidence scores: ");
Console.WriteLine($"    Positive confidence score: {docSentiment.ConfidenceScores.Positive}.");
Console.WriteLine($"    Neutral confidence score: {docSentiment.ConfidenceScores.Neutral}.");
Console.WriteLine($"    Negative confidence score: {docSentiment.ConfidenceScores.Negative}.");
```

## Analyzing the sentiment of multipile documents

To analyze the sentiment of a collection of documents in the same language, call `AnalyzeSentimentBatch` on an `IEnumerable` of strings.  The results are returned as a `AnalyzeSentimentResultCollection`.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(documents);
```

To analyze the sentiment of a collection of documents in different languages, call `AnalyzeSentimentBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentBatch
var documents = new List<TextDocumentInput>
{
    new TextDocumentInput("1", "That was the best day of my life!")
    {
         Language = "en",
    },
    new TextDocumentInput("2", "This food is very bad. Everyone who ate with us got sick.")
    {
         Language = "en",
    },
    new TextDocumentInput("3", "I'm not sure how I feel about this product.")
    {
         Language = "en",
    },
    new TextDocumentInput("4", "Pike Place Market is my favorite Seattle attraction.  We had so much fun there.")
    {
         Language = "en",
    }
};

AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Synchronous AnalyzeSentiment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentiment.cs)
* [Asynchronous AnalyzeSentiment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentAsync.cs)
* [Synchronous AnalyzeSentimentBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatch.cs)
* [Asynchronous AnalyzeSentimentBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchAsync.cs)
* [Synchronous AnalyzeSentimentBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchConvenience.cs)
* [Asynchronous AnalyzeSentimentBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
