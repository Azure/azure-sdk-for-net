# Recognizing Linked Entities in Text Inputs
This sample demonstrates how to recognize linked entities in one or more text inputs using Azure Text Analytics.  To get started you'll need a Text Analytics endpoint and credentials.  See [README](../README.md) for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize linked entities in an input text, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics subscription key.  You can set `endpoint` and `subscriptionKey` based on an environment variable, a configuration setting, or any way that works for your application.

``` C# Snippet:TextAnalyticsSample6CreateClient
```

## Recognizing linked entities in a single input

To recognize linked entities in a single text input, pass the input string to the client's `RecognizeLinkedEntities` method.  The returned `RecognizeLinkedEntitiesResult` contains a collection of `LinkedEntities` containing entities recognized in the text as well as links to those entities in a reference data source, such as Wikipedia.

```C# Snippet:RecognizeLinkedEntities
```

## Recognizing linked entities in multiple inputs

To recognize linked entities in multiple text inputs as a batch, call `RecognizeLinkedEntities` on an `IEnumerable` of strings.  The results are returned as a `RecognizeLinkedEntitiesResultCollection`.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesConvenience
```

To recognize linked entities in a collection of text inputs in different languages, call `RecognizeLinkedEntities` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each input.

```C# Snippet:TextAnalyticsSample6RecognizeLinkedEntitiesBatch
```

* [Sample6_RecognizeLinkedEntities.cs](../tests/samples/Sample6_RecognizeLinkedEntities.cs)
* [Sample6_RecognizeLinkedEntitiesBatch.cs](../tests/samples/Sample6_RecognizeLinkedEntitiesBatch.cs)
* [Sample6_RecognizeLinkedEntitiesBatchConvienice.cs](../tests/samples/Sample6_RecognizeLinkedEntitiesBatchConvienice.cs)

[DefaultAzureCredential]: ../../../identity/Azure.Identity/README.md