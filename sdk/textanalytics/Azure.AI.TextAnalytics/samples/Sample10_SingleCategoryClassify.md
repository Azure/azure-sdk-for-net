# Perform Custom Single Category Classification on Documents
This sample demonstrates how to run a single category classification action in one or more documents. To get started you will need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to perform a single category classify on a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Performing Single Category Classify on one or multiple documents

To perform Custom Single Category Classification in one or multiple documents, set up a `SingleCategoryClassifyAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running Operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsSingleCategoryClassifyAsync
// Get input document.
string document = @"I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist.";

// Prepare analyze operation input. You can add multiple documents to this list and perform the same
// operation to all of them.
var batchInput = new List<string>
{
    document
};

// Set project and deployment names of the target model
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

var singleCategoryClassifyAction = new SingleCategoryClassifyAction(projectName, deploymentName);

TextAnalyticsActions actions = new TextAnalyticsActions()
{
    SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>() { singleCategoryClassifyAction }
};

// Start analysis process.
AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:TextAnalyticsSingleCategoryClassifyOperationStatus
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

```C# Snippet:TextAnalyticsSingleCategoryClassifyAsyncViewResults
// View operation results.
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<SingleCategoryClassifyActionResult> singleClassificationActionResults = documentsInPage.SingleCategoryClassifyResults;

    foreach (SingleCategoryClassifyActionResult classificationActionResults in singleClassificationActionResults)
    {
        foreach (SingleCategoryClassifyResult documentResults in classificationActionResults.DocumentsResults)
        {
            Console.WriteLine($"  Class category \"{documentResults.ClassificationCategory.Category}\" predicted with a confidence score of {documentResults.ClassificationCategory.ConfidenceScore}.");
            Console.WriteLine();
        }
    }
}
```

To see the full example source files, see:

* [Synchronously SingleCategoryClassify](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample10_SingleCategoryClassify.cs)
* [Asynchronously SingleCategoryClassify](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample10_SingleCategoryClassifyAsync.cs)
* [Synchronously SingleCategoryClassify Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample10_SingleCategoryClassifyConvenience.cs)
* [Asynchronously SingleCategoryClassify Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample10_SingleCategoryClassifyConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
