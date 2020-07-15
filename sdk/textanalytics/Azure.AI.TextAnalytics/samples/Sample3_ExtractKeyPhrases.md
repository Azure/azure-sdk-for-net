# Extracting Key Phrases from Documents

This sample demonstrates how to extract key phrases from one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to extract key phrases from a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample3CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Extracting key phrases from a single document

To extract key phrases from a document, use the `ExtractKeyPhrases` method.  The returned value the collection of `KeyPhrases` that were extracted from the document.

```C# Snippet:ExtractKeyPhrases
string document = "My cat might need to see a veterinarian.";

KeyPhraseCollection keyPhrases = client.ExtractKeyPhrases(document);

Console.WriteLine($"Extracted {keyPhrases.Count} key phrases:");
foreach (string keyPhrase in keyPhrases)
{
    Console.WriteLine(keyPhrase);
}
```

## Extracting key phrases from multiple documents

To extract key phrases from multiple documents, call `ExtractKeyPhrasesBatch` on an `IEnumerable` of strings.  The results are returned as a `ExtractKeyPhrasesResultCollection`.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesConvenience
ExtractKeyPhrasesResultCollection results = client.ExtractKeyPhrasesBatch(documents);
```

To extract key phrases from a collection of documents in different languages, call `ExtractKeyPhrasesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSample3ExtractKeyPhrasesBatch
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
    new TextDocumentInput("3", "My cat might need to see a veterinarian.")
    {
         Language = "en",
    }
};

ExtractKeyPhrasesResultCollection results = client.ExtractKeyPhrasesBatch(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Synchronous ExtractKeyPhrases](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrases.cs)
* [Asynchronous ExtractKeyPhrases](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesAsync.cs)
* [ExtractKeyPhrases with warnings](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesWithWarnings.cs)
* [Synchronous ExtractKeyPhrasesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatch.cs)
* [Asynchronous ExtractKeyPhrasesBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatchAsync.cs)
* [Synchronous ExtractKeyPhrasesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatchConvenience.cs)
* [Asynchronous ExtractKeyPhrasesBatchConvenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample3_ExtractKeyPhrasesBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
