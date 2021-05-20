# Running multiple actions
This sample demonstrates how to run multiple actions in one or more documents. Actions include entity recognition, linked entity recognition, key phrase extraction, Personally Identifiable Information (PII) Recognition, and sentiment analysis. To get started you will need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to run analyze operation for a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
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
        RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() },
        RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { new RecognizeLinkedEntitiesAction() },
        AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() },
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
        IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = documentsInPage.ExtractKeyPhrasesActionsResults;
        IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = documentsInPage.RecognizeEntitiesActionsResults;
        IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = documentsInPage.RecognizePiiEntitiesActionsResults;
        IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = documentsInPage.RecognizeLinkedEntitiesActionsResults;
        IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = documentsInPage.AnalyzeSentimentActionsResults;

        Console.WriteLine("Recognized Entities");
        int docNumber = 1;
        foreach (RecognizeEntitiesActionResult entitiesActionResults in entitiesActionsResults)
        {
            foreach (RecognizeEntitiesResult result in entitiesActionResults.Result)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {result.Entities.Count} entities:");

                foreach (CategorizedEntity entity in result.Entities)
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

        Console.WriteLine("Recognized PII Entities");
        docNumber = 1;
        foreach (RecognizePiiEntitiesActionResult piiActionResults in piiActionsResults)
        {
            foreach (RecognizePiiEntitiesResult result in piiActionResults.Result)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {result.Entities.Count} PII entities:");

                foreach (PiiEntity entity in result.Entities)
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
        foreach (ExtractKeyPhrasesActionResult keyPhrasesActionResult in keyPhrasesActionsResults)
        {
            foreach (ExtractKeyPhrasesResult result in keyPhrasesActionResult.Result)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {result.KeyPhrases.Count} Keyphrases:");

                foreach (string keyphrase in result.KeyPhrases)
                {
                    Console.WriteLine($"  {keyphrase}");
                }
                Console.WriteLine("");
            }
        }

        Console.WriteLine("Recognized Linked Entities");
        docNumber = 1;
        foreach (RecognizeLinkedEntitiesActionResult linkedEntitiesActionResults in entityLinkingActionsResults)
        {
            foreach (RecognizeLinkedEntitiesResult result in linkedEntitiesActionResults.Result)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Recognized the following {result.Entities.Count} linked entities:");

                foreach (LinkedEntity entity in result.Entities)
                {
                    Console.WriteLine($"  Entity: {entity.Name}");
                    Console.WriteLine($"  DataSource: {entity.DataSource}");
                    Console.WriteLine($"  DataSource EntityId: {entity.DataSourceEntityId}");
                    Console.WriteLine($"  Language: {entity.Language}");
                    Console.WriteLine($"  DataSource Url: {entity.Url}");

                    Console.WriteLine($"  Total Matches: {entity.Matches.Count()}");
                    foreach (LinkedEntityMatch match in entity.Matches)
                    {
                        Console.WriteLine($"    Match Text: {match.Text}");
                        Console.WriteLine($"    ConfidenceScore: {match.ConfidenceScore}");
                        Console.WriteLine($"    Offset: {match.Offset}");
                        Console.WriteLine($"    Length: {match.Length}");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
        }

        Console.WriteLine("Analyze Sentiment");
        docNumber = 1;
        foreach (AnalyzeSentimentActionResult analyzeSentimentActionsResult in analyzeSentimentActionsResults)
        {
            foreach (AnalyzeSentimentResult result in analyzeSentimentActionsResult.Result)
            {
                Console.WriteLine($" Document #{docNumber++}");
                Console.WriteLine($"  Sentiment is {result.DocumentSentiment.Sentiment}, with confidence scores: ");
                Console.WriteLine($"    Positive confidence score: {result.DocumentSentiment.ConfidenceScores.Positive}.");
                Console.WriteLine($"    Neutral confidence score: {result.DocumentSentiment.ConfidenceScores.Neutral}.");
                Console.WriteLine($"    Negative confidence score: {result.DocumentSentiment.ConfidenceScores.Negative}.");
                Console.WriteLine("");
            }
        }
    }
}
```

To see the full example source files, see:

* [Synchronously StartAnalyzeActions ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperation.cs)
* [Asynchronously StartAnalyzeActions ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync.cs)
* [Synchronously StartAnalyzeActions Convenience ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationConvenience.cs)
* [Asynchronously StartAnalyzeActions Convenience](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md