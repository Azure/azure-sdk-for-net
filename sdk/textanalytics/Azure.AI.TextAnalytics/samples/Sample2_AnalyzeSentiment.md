# Analyzing the Sentiment of Text Inputs

This sample demonstrates how to analyze the sentiment in one or more text inputs. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to analyze the sentiment in a text input, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating a `TextAnalyticsApiKeyCredential` object, that if neded, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample2CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new TextAnalyticsApiKeyCredential(apiKey));
```

## Analyzing the sentiment of a single text input

To analyze the sentiment of a single text input, pass the input string to the client's `AnalyzeSentiment` method.  The returned `AnalyzeSentimentResult` contains a `DocumentSentiment` describing the sentiment of the full input, as well as a collection of `Sentences` indicating the sentiment of each individual sentence.

```C# Snippet:AnalyzeSentiment
string input = "That was the best day of my life!";

DocumentSentiment docSentiment = client.AnalyzeSentiment(input);

Console.WriteLine($"Sentiment was {docSentiment.Sentiment}, with scores: ");
Console.WriteLine($"    Positive score: {docSentiment.SentimentScores.Positive:0.00}.");
Console.WriteLine($"    Neutral score: {docSentiment.SentimentScores.Neutral:0.00}.");
Console.WriteLine($"    Negative score: {docSentiment.SentimentScores.Negative:0.00}.");
```

## Analyzing the sentiment of multipile text inputs

To analyze the sentiment of a collection of text inputs in the same language, call `AnalyzeSentimentBatch` on an `IEnumerable` of strings.  The results are returned as a `AnalyzeSentimentResultCollection`.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(inputs);
```

To analyze the sentiment of a collection of text inputs in different languages, call `AnalyzeSentimentBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentBatch
var inputs = new List<TextDocumentInput>
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

AnalyzeSentimentResultCollection results = client.AnalyzeSentimentBatch(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample2_AnalyzeSentiment.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentiment.cs)
* [Sample2_AnalyzeSentimentBatch.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatch.cs)
* [Sample2_AnalyzeSentimentBatchConvenience.cs](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample2_AnalyzeSentimentBatchConvenience.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
