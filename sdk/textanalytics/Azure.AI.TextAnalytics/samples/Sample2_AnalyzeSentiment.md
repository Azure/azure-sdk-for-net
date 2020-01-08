# Analyzing the Sentiment of Text Inputs

This sample demonstrates how to analyze the sentiment in one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to analyze the sentiment in a text input, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample2CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Analyzing the sentiment of a single text input

To analyze the sentiment of a single text input, pass the input string to the client's `AnalyzeSentiment` method.  The returned `AnalyzeSentimentResult` contains a `DocumentSentiment` describing the sentiment of the full input, as well as a collection of `SentenceSentiments` indicating the sentiment of each individual sentence.

```C# Snippet:AnalyzeSentiment
string input = "That was the best day of my life!";

AnalyzeSentimentResult result = client.AnalyzeSentiment(input);
TextSentiment sentiment = result.DocumentSentiment;

Console.WriteLine($"Sentiment was {sentiment.SentimentClass.ToString()}, with scores: ");
Console.WriteLine($"    Positive score: {sentiment.PositiveScore:0.00}.");
Console.WriteLine($"    Neutral score: {sentiment.NeutralScore:0.00}.");
Console.WriteLine($"    Negative score: {sentiment.NeutralScore:0.00}.");
```

## Analyzing the sentiment of multipile text inputs

To analyze the sentiment of a collection of text inputs in the same language, call `AnalyzeSentiment` on an `IEnumerable` of strings.  The results are returned as a `AnalyzeSentimentResultCollection`.

```C# Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
AnalyzeSentimentResultCollection results = client.AnalyzeSentiment(inputs);
```

To analyze the sentiment of a collection of text inputs in different languages, call `AnalyzeSentiment` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

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

AnalyzeSentimentResultCollection results = client.AnalyzeSentiment(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample2_AnalyzeSentiment.cs](../tests/samples/Sample2_AnalyzeSentiment.cs)
* [Sample2_AnalyzeSentimentBatch.cs](../tests/samples/Sample2_AnalyzeSentimentBatch.cs)
* [Sample2_AnalyzeSentimentBatchConvenience.cs](../tests/samples/Sample2_AnalyzeSentimentBatchConvenience.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md
