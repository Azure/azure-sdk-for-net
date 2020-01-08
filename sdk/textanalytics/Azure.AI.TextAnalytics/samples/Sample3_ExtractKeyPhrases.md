# Extracting Key Phrases from Text Inputs

This sample demonstrates how to extract key phrases from one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to extract key phrases from text input, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample3CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Extracting key phrases from a single input

To extract key phrases from a single text input, pass the input string to the client's `ExtractKeyPhrases` method.  The returned `ExtractKeyPhrasesResult` contains a collection of `KeyPhrases` that were extracted from the input text.

```C# Snippet:ExtractKeyPhrases
string input = "My cat might need to see a veterinarian.";

ExtractKeyPhrasesResult result = client.ExtractKeyPhrases(input);
IReadOnlyCollection<string> keyPhrases = result.KeyPhrases;

Console.WriteLine($"Extracted {keyPhrases.Count()} key phrases:");
foreach (string keyPhrase in keyPhrases)
{
    Console.WriteLine(keyPhrase);
}
```

## Extracting key phrases from multiple inputs

To extract key phrases from multiple text inputs as a batch, call `ExtractKeyPhrases` on an `IEnumerable` of strings.  The results are returned as a `ExtractKeyPhrasesResultCollection`.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesConvenience
ExtractKeyPhrasesResultCollection results = client.ExtractKeyPhrases(inputs);
```

To extract key phrases from a collection of text inputs in different languages, call `ExtractKeyPhrases` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesBatch
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
    new TextDocumentInput("3", "My cat might need to see a veterinarian.")
    {
         Language = "en",
    }
};

ExtractKeyPhrasesResultCollection results = client.ExtractKeyPhrases(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample3_ExtractKeyPhrases.cs](../tests/samples/Sample3_ExtractKeyPhrases.cs)
* [Sample3_ExtractKeyPhrasesBatch.cs](../tests/samples/Sample3_ExtractKeyPhrasesBatch.cs)
* [Sample3_ExtractKeyPhrasesBatchConvenience.cs](../tests/samples/Sample3_ExtractKeyPhrasesBatchConvenience.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md
