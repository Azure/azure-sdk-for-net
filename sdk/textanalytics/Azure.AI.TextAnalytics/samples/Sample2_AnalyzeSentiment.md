# Analyzing the Sentiment of Text Inputs

This sample demonstrates how to analyze the sentiment in one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to detect the language a text input is written in, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample2CreateClient
```

## Analyzing the sentiment of a single text input

To analyze the sentiment of a single text input, pass the input string to the client's `AnalyzeSentiment` method.  The returned `AnalyzeSentimentResult` contains a `DocumentSentiment` describing the sentiment of the full input, as well as a collection of `SentenceSentiments` indicating the sentiment of each individual sentence.

```C# Snippet:AnalyzeSentiment
```

## Analyzing the sentiment of multipile text inputs

To analyze the sentiment of a collection of text inputs in the same language, call `AnalyzeSentiment` on an `IEnumerable` of strings.  The results are returned as a `AnalyzeSentimentResultCollection`.

``` C# Snippet:TextAnalyticsSample2AnalyzeSentimentConvenience
```

To analyze the sentiment of a collection of text inputs in different languages, call `AnalyzeSentiment` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

``` C# Snippet:TextAnalyticsSample2AnalyzeSentiment
```

* [Sample2_AnalyzeSentiment.cs](../tests/samples/Sample2_AnalyzeSentiment.cs)
* [Sample2_AnalyzeSentimentBatch.cs](../tests/samples/Sample2_AnalyzeSentimentBatch.cs)
* [Sample2_AnalyzeSentimentBatchConvienice.cs](../tests/samples/Sample2_AnalyzeSentimentBatchConvienice.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md