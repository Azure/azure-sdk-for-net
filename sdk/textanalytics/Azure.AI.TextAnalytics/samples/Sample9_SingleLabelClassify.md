# Perform custom single-label classification

This sample demonstrates how to perform custom single-label classification on one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform custom single-label classification on one or more text documents

To perform custom single-label classification one or more text documents, call `SingleLabelClassifyAsync` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter. This returns a `ClassifyDocumentOperation`.

```C# Snippet:Sample9_SingleLabelClassifyConvenienceAsync
string document =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
List<string> batchedDocuments = new()
{
    document
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

// Perform the text analysis operation.
ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(WaitUntil.Completed, batchedDocuments, projectName, deploymentName);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the custom single-label classification, including any errors that might have occurred:

```C# Snippet:Sample9_SingleLabelClassifyConvenienceAsync_ViewResults
// View the operation results.
await foreach (ClassifyDocumentResultCollection documentsInPage in operation.Value)
{
    foreach (ClassifyDocumentResult documentResult in documentsInPage)
    {
        if (documentResult.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
            Console.WriteLine($"  Message: {documentResult.Error.Message}");
            continue;
        }

        Console.WriteLine($"  Predicted the following class:");
        Console.WriteLine();

        foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
        {
            Console.WriteLine($"  Category: {classification.Category}");
            Console.WriteLine($"  Confidence score: {classification.ConfidenceScore}");
            Console.WriteLine();
        }
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[train_model]: https://aka.ms/azsdk/textanalytics/customfunctionalities
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
