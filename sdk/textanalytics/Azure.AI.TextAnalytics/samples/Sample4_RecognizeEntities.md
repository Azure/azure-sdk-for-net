# Recognizing Entities from Text Inputs
This sample demonstrates how to recognize entities in one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize entities in an input text, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample4CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Recognizing entities in a single input

To recognize entities in a single text input, pass the input string to the client's `RecognizeEntities` method.  The returned `RecognizeEntitiesResult` contains a collection of `NamedEntities` that were recognized in the input text.

```C# Snippet:RecognizeEntities
string input = "Microsoft was founded by Bill Gates and Paul Allen.";

RecognizeEntitiesResult result = client.RecognizeEntities(input);
IReadOnlyCollection<NamedEntity> entities = result.NamedEntities;

Console.WriteLine($"Recognized {entities.Count()} entities:");
foreach (NamedEntity entity in entities)
{
    Console.WriteLine($"Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score}, Offset: {entity.Offset}, Length: {entity.Length}");
}
```

## Recognizing entities in multiple inputs

To recognize entities in multiple text inputs as a batch, call `RecognizeEntities` on an `IEnumerable` of strings.  The results are returned as a `RecognizeEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample4RecognizeEntitiesConvenience
RecognizeEntitiesResultCollection results = client.RecognizeEntities(inputs);
```

To recognize entities in a collection of text inputs in different languages, call `RecognizeEntities` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample4RecognizeEntitiesBatch
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
    new TextDocumentInput("3", "A key technology in Text Analytics is Named Entity Recognition (NER).")
    {
         Language = "en",
    }
};

RecognizeEntitiesResultCollection results = client.RecognizeEntities(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Synchronously Sample4_RecognizeEntities.cs](../tests/samples/Sample4_RecognizeEntities.cs)
* [Asynchronously Sample4_RecognizeEntitiesAsync.cs](../tests/samples/Sample4_RecognizeEntitiesAsync.cs)
* [Synchronously Sample4_RecognizeEntitiesBatch.cs](../tests/samples/Sample4_RecognizeEntitiesBatch.cs)
* [Synchronously Sample4_RecognizeEntitiesBatchConvenience.cs](../tests/samples/Sample4_RecognizeEntitiesBatchConvenience.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md