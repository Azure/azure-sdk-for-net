# Perform Custom Multiple Category Classification in Documents
This sample demonstrates how to run a Multi Category Classification action in one or more documents.  In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

To get started you will need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to perform a custom multi category classification on a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Performing Custom Multiple Category Classification in one or multiple documents

To perform Multiple Category Classification in one or multiple documents, set up a `MultiCategoryClassifyAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running Operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsMultiCategoryClassifyAsync
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

var multiCategoryClassifyAction = new MultiCategoryClassifyAction(projectName, deploymentName);

TextAnalyticsActions actions = new TextAnalyticsActions()
{
    MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>() { multiCategoryClassifyAction }
};

// Start analysis process.
AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:TextAnalyticsMultiCategoryClassifyOperationStatus
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

```C# Snippet:TextAnalyticsMultiCategoryClassifyAsyncViewResults
// View operation results.
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<MultiCategoryClassifyActionResult> multiClassificationActionResults = documentsInPage.MultiCategoryClassifyResults;

    foreach (MultiCategoryClassifyActionResult classificationActionResults in multiClassificationActionResults)
    {
        Console.WriteLine($" Action name: {classificationActionResults.ActionName}");
        foreach (MultiCategoryClassifyResult documentResults in classificationActionResults.DocumentsResults)
        {
            if (documentResults.Classifications.Count > 0)
            {
                Console.WriteLine($"  The following classes were predicted for this document:");

                foreach (ClassificationCategory classification in documentResults.Classifications)
                {
                    Console.WriteLine($"  Class category \"{classification.Category}\" predicted with a confidence score of {classification.ConfidenceScore}.");
                }

                Console.WriteLine();
            }
        }
    }
}
```

To see the full example source files, see:

* [Synchronously Multi Category Classify](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample11_MultiCategoryClassify.cs)
* [Asynchronously Multi Category Classify](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample11_MultiCategoryClassifyAsync.cs)
* [Synchronously Multi Category Classify Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample11_MultiCategoryClassifyConvenience.cs)
* [Asynchronously Multi Category Classify Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample11_MultiCategoryClassifyConvenienceAsync.cs)

[train_model]: https://aka.ms/azsdk/textanalytics/customfunctionalities
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
