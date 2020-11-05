# Recognizing Healthcare Entities from Documents
This sample demonstrates how to recognize healthcare entities in one or more documents and get them asynchronously. To get started you will need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize healthcare entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:TextAnalyticsSample4CreateClient
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing healthcare entities in a single document asynchronously

To recognize healthcare entities in a document, use the `StarthealthcareAsyc` method.  The returned type is a Long Running operation of type `HealthcareOperation` which polls for the results from the API.

```C# Snippet:RecognizeHealthcareEntities
string document = "Subject is taking 100mg of ibuprofen twice daily.";

HealthcareOperation healthOperation = await client.StartHealthcareAsync(document);

await healthOperation.WaitForCompletionAsync();

RecognizeHealthcareEntitiesResultCollection results = healthOperation.Value;

Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\" Model, version: \"{results.ModelVersion}\"");
Console.WriteLine("");

foreach (DocumentHealthcareResult result in results)
{
		Console.WriteLine($"    Recognized the following {result.Entities.Count} healthcare entities:");

		foreach (HealthcareEntity entity in result.Entities)
		{
				Console.WriteLine($"    Entity: {entity.Text}");
				Console.WriteLine($"    Subcategory: {entity.Subcategory}");
				Console.WriteLine($"    Offset: {entity.Offset}");
				Console.WriteLine($"    Length: {entity.Length}");
				Console.WriteLine($"    IsNegated: {entity.IsNegated}");
				Console.WriteLine($"    Links:");

				foreach (HealthcareEntityLink healthcareEntityLink in entity.Links)
				{
						Console.WriteLine($"        ID: {healthcareEntityLink.Id}");
						Console.WriteLine($"        DataSource: {healthcareEntityLink.DataSource}");
				}
		}
		Console.WriteLine("");
}
}
```

## Recognizing healthcare entities in multiple documents

To recognize healthcare entities in multiple documents, call `StartHealthcareBatchAsync` on an `IEnumerable` of strings.  The result is a Long Running operation of type `HealthcareOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsSampleRecognizeHealthcare
string document = "Subject is taking 100mg of ibuprofen twice daily.";

HealthcareOperation healthOperation = await client.StartHealthcareAsync(document);

await healthOperation.WaitForCompletionAsync();

RecognizeHealthcareEntitiesResultCollection results = healthOperation.Value;
```

To recognize healthcare entities in a collection of documents in different languages, call `RecognizeHealthcare EntitiesBatch` on an `IEnumerable` of `TextDocumentInput` objects, setting the `Language` on each document.

```C# Snippet:TextAnalyticsSampleRecognizeHealthcare
var documents = new List<TextDocumentInput>
{
    new TextDocumentInput("1", "Subject is taking 100mg of ibuprofen twice daily.")
    {
         Language = "en",
    },
    new TextDocumentInput("2", "Can cause rapid or irregular heartbeat.")
    {
         Language = "en",
    },
    new TextDocumentInput("3", "The patient is a 54-year-old gentleman with a history of progressive angina over the past several months")
    {
         Language = "en",
    }
};

HealthcareOperation healthOperation = await client.StartHealthcareAsync(document);

await healthOperation.WaitForCompletionAsync();

RecognizeHealthcareEntitiesResultCollection results = healthOperation.Value;
```

To see the full example source files, see:

* [Synchronously RecognizeHealthcare ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_Healthcare.cs)
* [Asynchronously RecognizeHealthcare ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync.cs)
* [Synchronously RecognizeHealthcareBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareBatch.cs)
* [Asynchronously RecognizeHealthcareBatch](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareBatchAsync.cs)
* [Synchronously RecognizeHealthcare Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_Healthcare_Cancellation.cs)
* [Asynchronously RecognizeHealthcare Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_HealthcareAsync_Cancellation.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md