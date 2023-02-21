# Perform Custom Multiple Label Classification in Documents

This sample demonstrates how to run a Multi Label Classification action in one or more documents.  In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create simply with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Performing Custom Multiple Label Classification in one or multiple documents

To perform Multiple Label Classification in one or multiple documents, set up a `MultiLabelClassifyAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running Operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:Sample10_MultiLabelClassifyConvenienceAsync
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
MultiLabelClassifyAction multiLabelClassifyAction = new(projectName, deploymentName);

TextAnalyticsActions actions = new()
{
    MultiLabelClassifyActions = new List<MultiLabelClassifyAction>() { multiLabelClassifyAction }
};

// Perform the text analysis operation.
AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchedDocuments, actions);
await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:Sample10_MultiLabelClassifyConvenienceAsync_ViewOperationStatus
// View the operation status.
Console.WriteLine($"Created On   : {operation.CreatedOn}");
Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
Console.WriteLine($"Id           : {operation.Id}");
Console.WriteLine($"Status       : {operation.Status}");
Console.WriteLine($"Last Modified: {operation.LastModified}");
Console.WriteLine();
```

To view the final results of the long-running operation:

```C# Snippet:Sample10_MultiLabelClassifyConvenienceAsync_ViewResults
// View the operation results.
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<MultiLabelClassifyActionResult> multiClassificationActionResults = documentsInPage.MultiLabelClassifyResults;

    foreach (MultiLabelClassifyActionResult classificationActionResults in multiClassificationActionResults)
    {
        Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
        foreach (ClassifyDocumentResult documentResult in classificationActionResults.DocumentsResults)
        {
            if (documentResult.ClassificationCategories.Count > 0)
            {
                Console.WriteLine($"  The following classes were predicted for this document:");

                foreach (ClassificationCategory classification in documentResult.ClassificationCategories)
                {
                    Console.WriteLine($"  Class label \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                }

                Console.WriteLine();
            }
        }
    }
}
```

[train_model]: https://aka.ms/azsdk/textanalytics/customfunctionalities
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
