# Perform Custom Single Label Classification on Documents
This sample demonstrates how to run a single label classification action in one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to perform a single label classify on a document, you need a Cognitive Services or Language service endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Language service API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client. See [README][README] for links and instructions.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Performing Single Label Classify on one or multiple documents

To perform Custom Single Label Classification in one or multiple documents, set up a `SingleLabelClassifyAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running Operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsSingleLabelClassifyAsync
// Get input document.
string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

// Prepare analyze operation input. You can add multiple documents to this list and perform the same
// operation to all of them.
var batchInput = new List<string>
{
    document
};

// Set project and deployment names of the target model
// To train a model to classify your documents, see https://aka.ms/azsdk/textanalytics/customfunctionalities
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

var singleLabelClassifyAction = new SingleLabelClassifyAction(projectName, deploymentName);

TextAnalyticsActions actions = new TextAnalyticsActions()
{
    SingleLabelClassifyActions = new List<SingleLabelClassifyAction>() { singleLabelClassifyAction }
};

// Start analysis process.
AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:TextAnalyticsSingleLabelClassifyOperationStatus
// View operation status.
Console.WriteLine($"AnalyzeActions operation has completed");
Console.WriteLine();

Console.WriteLine($"Created On   : {operation.CreatedOn}");
Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
Console.WriteLine($"Id           : {operation.Id}");
Console.WriteLine($"Status       : {operation.Status}");
Console.WriteLine($"Last Modified: {operation.LastModified}");
Console.WriteLine();
```

To view the final results of the long-running operation:

```C# Snippet:TextAnalyticsSingleLabelClassifyAsyncViewResults
// View operation results.
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<SingleLabelClassifyActionResult> singleClassificationActionResults = documentsInPage.SingleLabelClassifyResults;

    foreach (SingleLabelClassifyActionResult classificationActionResults in singleClassificationActionResults)
    {
        Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
        foreach (ClassifyDocumentResult documentResults in classificationActionResults.DocumentsResults)
        {
            ClassificationCategory classification = documentResults.ClassificationCategories.First();

            Console.WriteLine($"  Class label \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
            Console.WriteLine();
        }
    }
}
```

[train_model]: https://aka.ms/azsdk/textanalytics/customfunctionalities
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
