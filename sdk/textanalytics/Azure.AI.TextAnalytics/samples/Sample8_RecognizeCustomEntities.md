# Recognizing Custom Named Entities from Documents
This sample demonstrates how to recognize custom entities in one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to recognize custom entities in a document, you need a Cognitive Services or Language service endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Language service API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client. See [README][README] for links and instructions.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Recognizing custom entities in a single or multiple documents

To recognize custom entities in documents, set up a `RecognizeCustomEntitiesAction` and call `StartAnalyzeActionsAsync` on the documents. The result is a Long Running operation of type `AnalyzeActionsOperation` which polls for the results from the API. You can use [Azure language studio][azure_language_studio] to train custom models.

```C# Snippet:RecognizeCustomEntitiesActionAsync
// Create input documents.
string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                    worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                    We tried again today and it was amazing. Everyone in my family liked the trail although
                    it was too challenging for the less athletic among us.";

string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                    our anniversary so they helped me organize a little surprise for my partner.
                    The room was clean and with the decoration I requested. It was perfect!";

var batchDocuments = new List<TextDocumentInput>
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

// prepare actions.
// To train a model to recognize your custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";
var actions = new TextAnalyticsActions()
{
    RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
    {
        new RecognizeCustomEntitiesAction(projectName, deploymentName)
    }
};

AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, actions);

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
await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
{
    IReadOnlyCollection<RecognizeCustomEntitiesActionResult> customEntitiesActionResults = documentsInPage.RecognizeCustomEntitiesResults;
    foreach (RecognizeCustomEntitiesActionResult customEntitiesActionResult in customEntitiesActionResults)
    {
        Console.WriteLine($" Action name: {customEntitiesActionResult.ActionName}");
        int docNumber = 1;
        foreach (RecognizeEntitiesResult documentResults in customEntitiesActionResult.DocumentsResults)
        {
            Console.WriteLine($" Document #{docNumber++}");
            Console.WriteLine($"  Recognized the following {documentResults.Entities.Count} entities:");

            foreach (CategorizedEntity entity in documentResults.Entities)
            {
                Console.WriteLine($"  Entity: {entity.Text}");
                Console.WriteLine($"  Category: {entity.Category}");
                Console.WriteLine($"  Offset: {entity.Offset}");
                Console.WriteLine($"  Length: {entity.Length}");
                Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                Console.WriteLine($"  SubCategory: {entity.SubCategory}");
            }
            Console.WriteLine("");
        }
    }
}
```

<!-- LINKS -->
[train_model]: https://aka.ms/azsdk/textanalytics/customentityrecognition
[azure_language_studio]: https://language.azure.com/
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
