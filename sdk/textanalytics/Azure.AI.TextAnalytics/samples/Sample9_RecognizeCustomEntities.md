# Recognizing Custom Entities from Documents
This sample demonstrates how to recognize entities in one or more documents. To get started you'll need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize entities in a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing custom entities in a single or multiple documents

To recognize custom entities in a single or multiple documents, set up an `RecognizeCustomEntitiesAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:RecognizeCustomEntitiesActionAsync
 // Get input document.
var documents = new List<string>() { @"There are so many ways of arranging a deck of cards that, after shuffling it, 
                                                   it's almost guaranteed that the resulting sequence of cards has never appeared in the history of humanity." };

//prepare actions
var actions = new TextAnalyticsActions()
{
    RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
    {
        new RecognizeCustomEntitiesAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
    }
};

AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions);
await operation.WaitForCompletionAsync();
```

The returned `AnalyzeActionsOperation` contains general information about the status of the operation. It can be requested while the operation is running or when it has completed. For example:

```C# Snippet:RecognizeCustomEntitiesActionOperationStatus
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

```C# Snippet:RecognizeCustomEntitiesActionAsyncViewResults
// View operation results.
await foreach (var result in operation.Value)
{
    var results = result.RecognizeCustomEntitiesActionResult;
    foreach (var document in results)
    {
        var entitiesInDocument = document.DocumentsResults[0].Entities;
        Console.WriteLine($"Recognized {entitiesInDocument.Count} entities:");
        foreach (CategorizedEntity entity in entitiesInDocument)
        {
            Console.WriteLine($"    Text: {entity.Text}");
            Console.WriteLine($"    Offset: {entity.Offset}");
            Console.WriteLine($"  Length: {entity.Length}");
            Console.WriteLine($"    Category: {entity.Category}");
            if (!string.IsNullOrEmpty(entity.SubCategory))
                Console.WriteLine($"    SubCategory: {entity.SubCategory}");
            Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
            Console.WriteLine("");
        }
    }
}
```