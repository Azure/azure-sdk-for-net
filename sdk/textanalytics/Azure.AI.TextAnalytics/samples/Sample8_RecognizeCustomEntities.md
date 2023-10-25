# Perform custom named entity recognition (NER)

This sample demonstrates how to perform custom named entity recognition (NER) on one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform custom NER on one or more text documents

To perform custom NER on one or more text documents, call `RecognizeCustomEntitiesAsync` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter. This returns a `RecognizeCustomEntitiesOperation`.

```C# Snippet:Sample8_RecognizeCustomEntitiesAsync
string documentA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us.";

string documentB =
    "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
    + " so they helped me organize a little surprise for my partner. The room was clean and with the"
    + " decoration I requested. It was perfect!";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<TextDocumentInput> batchedDocuments = new()
{
    new TextDocumentInput("1", documentA)
    {
         Language = "en",
    },
    new TextDocumentInput("2", documentB)
    {
         Language = "en",
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

// Perform the text analysis operation.
RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the custom NER, including any errors that might have occurred:

```C# Snippet:Sample8_RecognizeCustomEntitiesAsync_ViewResults
await foreach (RecognizeCustomEntitiesResultCollection documentsInPage in operation.Value)
{
    foreach (RecognizeEntitiesResult documentResult in documentsInPage)
    {
        Console.WriteLine($"Result for document with Id = \"{documentResult.Id}\":");

        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            Console.WriteLine();
            continue;
        }

        Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

        foreach (CategorizedEntity entity in documentResult.Entities)
        {
            Console.WriteLine($"  Entity: {entity.Text}");
            Console.WriteLine($"  Category: {entity.Category}");
            Console.WriteLine($"  Offset: {entity.Offset}");
            Console.WriteLine($"  Length: {entity.Length}");
            Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
            Console.WriteLine($"  SubCategory: {entity.SubCategory}");
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

<!-- LINKS -->
[train_model]: https://aka.ms/azsdk/textanalytics/customentityrecognition
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
