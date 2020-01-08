# Extracting Key Phrases from Text Inputs

This sample demonstrates how to extract key phrases from one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to extract key phrases from a text input, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

``` C# Snippet:TextAnalyticsSample3CreateClient
```

## Extracting key phrases from a single input

To extract key phrases from a single text input, pass the input string to the client's `ExtractKeyPhrases` method.  The returned `ExtractKeyPhrasesResult` contains a collection of `KeyPhrases` that were extracted from the input text.

```C# Snippet:ExtractKeyPhrases
```

## Extracting key phrases from multiple inputs

To extract key phrases from multiple text inputs as a batch, call `ExtractKeyPhrases` on an `IEnumerable` of strings.  The results are returned as a `ExtractKeyPhrasesResultCollection`.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesConvenience
```

To extract key phrases from a collection of text inputs in different languages, call `ExtractKeyPhrases` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesBatch
```

* [Sample3_ExtractKeyPhrases.cs](../tests/samples/Sample3_ExtractKeyPhrases.cs)
* [Sample3_ExtractKeyPhrasesBatch.cs](../tests/samples/Sample3_ExtractKeyPhrasesBatch.cs)
* [Sample3_ExtractKeyPhrasesBatchConvienice.cs](../tests/samples/Sample3_ExtractKeyPhrasesBatchConvienice.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md