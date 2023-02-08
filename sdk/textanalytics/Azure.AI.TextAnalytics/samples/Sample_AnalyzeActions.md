# Running multiple actions
This sample demonstrates how to run multiple actions in one or more documents. Actions include:

- Named Entities Recognition
- PII Entities Recognition
- Linked Entity Recognition
- Key Phrase Extraction
- Sentiment Analysis
- Extractive Summarization
- Custom Named Entity Recognition
- Custom Text Classification

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to run analyze operation for a document, you need a Cognitive Services or Language service endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Language service API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client. See [README][README] for links and instructions.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
TextAnalyticsClient client = new(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Running multiple actions in multiple documents

To run multiple actions in multiple documents, call `StartAnalyzeActionsAsync` on the documents.  The result is a Long Running operation of type `AnalyzeActionsOperation` which polls for the results from the API.

```C# Snippet:AnalyzeOperationConvenienceAsync
    string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                        worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                        We tried again today and it was amazing. Everyone in my family liked the trail although
                        it was too challenging for the less athletic among us.";

    string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                        our anniversary so they helped me organize a little surprise for my partner.
                        The room was clean and with the decoration I requested. It was perfect!";

    var batchDocuments = new List<string>
    {
        documentA,
        documentB
    };

    TextAnalyticsActions actions = new TextAnalyticsActions()
    {
        ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
        RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() },
        DisplayName = "AnalyzeOperationSample"
    };

    AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, actions);

    await operation.WaitForCompletionAsync();

    Console.WriteLine($"Status: {operation.Status}");
    Console.WriteLine($"Created On: {operation.CreatedOn}");
    Console.WriteLine($"Expires On: {operation.ExpiresOn}");
    Console.WriteLine($"Last modified: {operation.LastModified}");
    if (!string.IsNullOrEmpty(operation.DisplayName))
        Console.WriteLine($"Display name: {operation.DisplayName}");
    Console.WriteLine($"Total actions: {operation.ActionsTotal}");
    Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
    Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
    Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");

    await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
    {
        IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesResults = documentsInPage.ExtractKeyPhrasesResults;
        IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResults = documentsInPage.RecognizeEntitiesResults;

        Console.WriteLine("Recognized Entities");
        int docNumber = 1;
        foreach (RecognizeEntitiesActionResult entitiesActionResults in entitiesResults)
        {
            Console.WriteLine($" Action name: {entitiesActionResults.ActionName}");
            foreach (RecognizeEntitiesResult documentResults in entitiesActionResults.DocumentsResults)
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

        Console.WriteLine("Key Phrases");
        docNumber = 1;
        foreach (ExtractKeyPhrasesActionResult keyPhrasesActionResult in keyPhrasesResults)
        {
            foreach (ExtractKeyPhrasesResult documentResults in keyPhrasesActionResult.DocumentsResults)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {documentResults.KeyPhrases.Count} Keyphrases:");

                foreach (string keyphrase in documentResults.KeyPhrases)
                {
                    Console.WriteLine($"  {keyphrase}");
                }
                Console.WriteLine("");
            }
        }
    }
}
```

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
