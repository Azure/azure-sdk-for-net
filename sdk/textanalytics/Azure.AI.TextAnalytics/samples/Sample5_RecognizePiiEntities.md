# Recognizing Personally Identifiable Information in Text Inputs
This sample demonstrates how to recognize personally identifiable information (PII) in one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize personally identifiable information in an input text, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample5CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), subscriptionKey);
```

## Recognizing personally identifiable information in a single input

To recognize personally identifiable information in a single text input, pass the input string to the client's `RecognizePiiEntities` method.  The returned `RecognizePiiEntitiesResult` contains a collection of `NamedEntities` containing personally identifiable information that were recognized in the input text.

```C# Snippet:RecognizePiiEntities
string input = "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.";

RecognizePiiEntitiesResult result = client.RecognizePiiEntities(input);
IReadOnlyCollection<NamedEntity> entities = result.NamedEntities;

Console.WriteLine($"Recognized {entities.Count()} PII entit{(entities.Count() > 1 ? "ies" : "y")}:");
foreach (NamedEntity entity in entities)
{
    Console.WriteLine($"Text: {entity.Text}, Type: {entity.Type}, SubType: {entity.SubType ?? "N/A"}, Score: {entity.Score}, Offset: {entity.Offset}, Length: {entity.Length}");
}
```

## Recognizing personally identifiable information in multiple inputs

To recognize personally identifiable information in multiple text inputs as a batch, call `RecognizePiiEntities` on an `IEnumerable` of strings.  The results are returned as a `RecognizePiiEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample5RecognizePiiEntitiesConvenience
RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntities(inputs);
```

To recognize personally identifiable information in a collection of text inputs in different languages, call `RecognizePiiEntities` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

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

RecognizePiiEntitiesResultCollection results = client.RecognizePiiEntities(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });
```

To see the full example source files, see:

* [Sample5_RecognizePiiEntities.cs](../tests/samples/Sample5_RecognizePiiEntities.cs)
* [Sample5_RecognizePiiEntitiesBatch.cs](../tests/samples/Sample5_RecognizePiiEntitiesBatch.cs)
* [Sample5_RecognizePiiEntitiesBatchConvenience.cs](../tests/samples/Sample5_RecognizePiiEntitiesBatchConvenience.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md