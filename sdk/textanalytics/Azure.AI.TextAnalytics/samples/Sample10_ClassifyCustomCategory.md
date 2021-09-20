# Perform Custom Category Classification in Documents
This sample demonstrates how to run a Classify Custom Category action in one or more documents. To get started you will need a Text Analytics endpoint and credentials. See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to performa a custom category classification on a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Performing Custom Category Classification in one or multiple documents

To perform Custom Category Classification in one or multiple documents, set up an `ClassifyCustomCategoryAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:TextAnalyticsClassifyCustomCategoryAsync
// Get input document.
string document = @"I am so hungry! I can hear my stomach growling; I need this order to get here as soon as possible!";

// Prepare analyze operation input. You can add multiple documents to this list and perform the same
// operation to all of them.
var batchInput = new List<string>
{
    document
};

var classifyCustomCategoryAction = new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName);

TextAnalyticsActions actions = new TextAnalyticsActions()
{
    ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>() { classifyCustomCategoryAction }
};

// Start analysis process.
AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);

await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:TextAnalyticsClassifyCustomCategoryOperationStatus
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

```C# Snippet:TextAnalyticsClassifyCustomCategoryAsyncViewResults
// View operation results.
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<ClassifyCustomCategoryActionResult> classificationResultsCollection = documentsInPage.ClassifyCustomCategoryResults;

    foreach (ClassifyCustomCategoryActionResult classificationActionResults in classificationResultsCollection)
    {
        if (classificationActionResults.HasError)
        {
            Console.WriteLine($"  Error!");
            Console.WriteLine($"  Action error code: {classificationActionResults.Error.ErrorCode}.");
            Console.WriteLine($"  Message: {classificationActionResults.Error.Message}");
            continue;
        }

        foreach (ClassifyCustomCategoryResult documentResults in classificationActionResults.DocumentsResults)
        {
            if (documentResults.HasError)
            {
                Console.WriteLine($"  Error!");
                Console.WriteLine($"  Document error code: {documentResults.Error.ErrorCode}.");
                Console.WriteLine($"  Message: {documentResults.Error.Message}");
                continue;
            }

            Console.WriteLine($"  Class category \"{documentResults.DocumentClassification.Category}\" predicted with a confidence score of {documentResults.DocumentClassification.ConfidenceScore}.");
            Console.WriteLine();
        }
    }
}
```

To see the full example source files, see:

* [Synchronously ExtractSummary](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummary.cs)
* [Asynchronously ExtractSummary](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryAsync.cs)
* [Synchronously ExtractSummary Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryConvenience.cs)
* [Asynchronously ExtractSummary Convenience](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample8_ExtractSummaryConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md