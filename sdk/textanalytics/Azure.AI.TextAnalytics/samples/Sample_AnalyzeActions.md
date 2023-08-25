# Perform multiple text analysis actions

This sample demonstrates how to perform multiple text analysis actions on one or more documents. These actions can include:

- Named Entities Recognition
- PII Entities Recognition
- Linked Entity Recognition
- Key Phrase Extraction
- Sentiment Analysis
- Extractive Summarization
- Custom Named Entity Recognition
- Custom Text Classification

## Create a `TextAnalyticsClient`

To create a new `TextAnalyticsClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalyticsClient
Uri endpoint = new("<endpoint>");
AzureKeyCredential credential = new("<apiKey>");
TextAnalyticsClient client = new(endpoint, credential);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform multiple actions on one or more text documents

To perform multiple actions on one or more text documents, call `AnalyzeActionsAsync` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter. This returns an `AnalyzeActionsOperation`. Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the text analysis actions, including any errors that might have occurred.

```C# Snippet:AnalyzeOperationConvenienceAsync
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
    List<string> batchedDocuments = new()
    {
        documentA,
        documentB
    };

    TextAnalyticsActions actions = new()
    {
        ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() { ActionName = "ExtractKeyPhrasesSample" } },
        RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() { ActionName = "RecognizeEntitiesSample" } },
        DisplayName = "AnalyzeOperationSample"
    };

    // Perform the text analysis operation.
    AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchedDocuments, actions);

    // View the operation status.
    Console.WriteLine($"Created On   : {operation.CreatedOn}");
    Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
    Console.WriteLine($"Id           : {operation.Id}");
    Console.WriteLine($"Status       : {operation.Status}");
    Console.WriteLine($"Last Modified: {operation.LastModified}");
    Console.WriteLine();

    if (!string.IsNullOrEmpty(operation.DisplayName))
    {
        Console.WriteLine($"Display name: {operation.DisplayName}");
        Console.WriteLine();
    }

    Console.WriteLine($"Total actions: {operation.ActionsTotal}");
    Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
    Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
    Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");
    Console.WriteLine();

    await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
    {
        IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesResults = documentsInPage.ExtractKeyPhrasesResults;
        IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResults = documentsInPage.RecognizeEntitiesResults;

        Console.WriteLine("Recognized Entities");
        int docNumber = 1;
        foreach (RecognizeEntitiesActionResult entitiesActionResults in entitiesResults)
        {
            Console.WriteLine($" Action name: {entitiesActionResults.ActionName}");
            Console.WriteLine();
            foreach (RecognizeEntitiesResult documentResult in entitiesActionResults.DocumentsResults)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized {documentResult.Entities.Count} entities:");

                foreach (CategorizedEntity entity in documentResult.Entities)
                {
                    Console.WriteLine();
                    Console.WriteLine($"    Entity: {entity.Text}");
                    Console.WriteLine($"    Category: {entity.Category}");
                    Console.WriteLine($"    Offset: {entity.Offset}");
                    Console.WriteLine($"    Length: {entity.Length}");
                    Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                    Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                }
                Console.WriteLine();
            }
        }

        Console.WriteLine("Extracted Key Phrases");
        docNumber = 1;
        foreach (ExtractKeyPhrasesActionResult keyPhrasesActionResult in keyPhrasesResults)
        {
            Console.WriteLine($" Action name: {keyPhrasesActionResult.ActionName}");
            Console.WriteLine();
            foreach (ExtractKeyPhrasesResult documentResults in keyPhrasesActionResult.DocumentsResults)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {documentResults.KeyPhrases.Count} Keyphrases:");

                foreach (string keyphrase in documentResults.KeyPhrases)
                {
                    Console.WriteLine($"    {keyphrase}");
                }
                Console.WriteLine();
            }
        }
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
