# Recognizing Linked Entities in Text Inputs
This sample demonstrates how to recognize linked entities in one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize linked entities in an input text, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample6CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Recognizing linked entities in a single input

To recognize linked entities in a single text input, pass the input string to the client's `RecognizeLinkedEntities` method.  The returned `RecognizeLinkedEntitiesResult` contains a collection of `LinkedEntities` containing entities recognized in the text as well as links to those entities in a reference data source, such as Wikipedia.

```C# Snippet:RecognizeLinkedEntities
string input = "Microsoft was founded by Bill Gates and Paul Allen.";

RecognizeLinkedEntitiesResult result = client.RecognizeLinkedEntities(input);

Console.WriteLine($"Extracted {result.LinkedEntities.Count()} linked entit{(result.LinkedEntities.Count() > 1 ? "ies" : "y")}:");
foreach (LinkedEntity linkedEntity in result.LinkedEntities)
{
    Console.WriteLine($"Name: {linkedEntity.Name}, Id: {linkedEntity.Id}, Language: {linkedEntity.Language}, Data Source: {linkedEntity.DataSource}, Uri: {linkedEntity.Uri.ToString()}");
    foreach (LinkedEntityMatch match in linkedEntity.Matches)
    {
        Console.WriteLine($"    Match Text: {match.Text}, Score: {match.Score:0.00}, Offset: {match.Offset}, Length: {match.Length}.");
    }
}
```

## Recognizing linked entities in multiple inputs

To recognize linked entities in multiple text inputs as a batch, call `RecognizeLinkedEntities` on an `IEnumerable` of strings.  The results are returned as a `RecognizeLinkedEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntities(inputs);
```

To recognize linked entities in a collection of text inputs in different languages, call `RecognizeLinkedEntities` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesBatch
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
    new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
    {
         Language = "en",
    }
};

RecognizeLinkedEntitiesResultCollection results = client.RecognizeLinkedEntities(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample6_RecognizeLinkedEntities.cs](../tests/samples/Sample6_RecognizeLinkedEntities.cs)
* [Sample6_RecognizeLinkedEntitiesBatch.cs](../tests/samples/Sample6_RecognizeLinkedEntitiesBatch.cs)
* [Sample6_RecognizeLinkedEntitiesBatchConvenience.cs](../tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvenience.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md