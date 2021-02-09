# Running Analyze Operation Asynchronously
This sample demonstrates how to run analyze operation in one or more documents and get them asynchronously for multiple tasks including entity recognition, key phrase extraction, and Personally Identifiable Information (PII) Recognition. To get started you will need a Text Analytics endpoint and credentials.  See [README][README] for links and instructions.

## Creating a `TextAnalyticsClient`

To create a new `TextAnalyticsClient` to run analyze operation for a document, you need a Text Analytics endpoint and credentials.  You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.  In the sample below, however, you'll use a Text Analytics API key credential by creating an `AzureKeyCredential` object, that if needed, will allow you to update the API key without creating a new client.

You can set `endpoint` and `apiKey` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreateTextAnalyticsClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Running Analyze Operation Asynchronously in multiple documents

To run analyze operation in multiple documents, call `StartAnalyzeOperationBatchAsync` on an `IEnumerable` of strings.  The result is a Long Running operation of type `AnalyzeOperation` which polls for the results from the API.

```C# Snippet:AnalyzeOperationBatchConvenienceAsync
    string documentA = @"We love this trail and make the trip every year. The views are breathtaking and well
                        worth the hike! Yesterday was foggy though, so we missed the spectacular views.
                        We tried again today and it was amazing. Everyone in my family liked the trail although
                        it was too challenging for the less athletic among us.
                        Not necessarily recommended for small children.
                        A hotel close to the trail offers services for childcare in case you want that.";

    string documentB = @"Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about
                        our anniversary so they helped me organize a little surprise for my partner.
                        The room was clean and with the decoration I requested. It was perfect!";

    string documentC = @"That was the best day of my life! We went on a 4 day trip where we stayed at Hotel Foo.
                        They had great amenities that included an indoor pool, a spa, and a bar.
                        The spa offered couples massages which were really good. 
                        The spa was clean and felt very peaceful. Overall the whole experience was great.
                        We will definitely come back.";

    var batchDocuments = new List<string>
    {
        documentA,
        documentB,
        documentC
    };

    TextAnalyticsActions batchActions = new TextAnalyticsActions()
    {
        ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
        RecognizeEntitiesOptions = new List<RecognizeEntitiesOptions>() { new RecognizeEntitiesOptions() },
        RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>() { new RecognizePiiEntitiesOptions() },
        DisplayName = "AnalyzeOperationSample"
    };

    AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions);

    await operation.WaitForCompletionAsync();

    await foreach (AnalyzeBatchActionsResult documentsInPage in operation.Value)
    {
        RecognizeEntitiesResultCollection entitiesResult = documentsInPage.RecognizeEntitiesActionsResults.FirstOrDefault().Result;

        ExtractKeyPhrasesResultCollection keyPhrasesResult = documentsInPage.ExtractKeyPhrasesActionsResults.FirstOrDefault().Result;

        RecognizePiiEntitiesResultCollection piiResult = documentsInPage.RecognizePiiEntitiesActionsResults.FirstOrDefault().Result;

        Console.WriteLine("Recognized Entities");

        foreach (RecognizeEntitiesResult result in entitiesResult)
        {
            Console.WriteLine($"    Recognized the following {result.Entities.Count} entities:");

            foreach (CategorizedEntity entity in result.Entities)
            {
                Console.WriteLine($"    Entity: {entity.Text}");
                Console.WriteLine($"    Category: {entity.Category}");
                Console.WriteLine($"    Offset: {entity.Offset}");
                Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                Console.WriteLine($"    SubCategory: {entity.SubCategory}");
            }
            Console.WriteLine("");
        }

        Console.WriteLine("Recognized PII Entities");

        foreach (RecognizePiiEntitiesResult result in piiResult)
        {
            Console.WriteLine($"    Recognized the following {result.Entities.Count} PII entities:");

            foreach (PiiEntity entity in result.Entities)
            {
                Console.WriteLine($"    Entity: {entity.Text}");
                Console.WriteLine($"    Category: {entity.Category}");
                Console.WriteLine($"    Offset: {entity.Offset}");
                Console.WriteLine($"    ConfidenceScore: {entity.ConfidenceScore}");
                Console.WriteLine($"    SubCategory: {entity.SubCategory}");
            }
            Console.WriteLine("");
        }

        Console.WriteLine("Key Phrases");

        foreach (ExtractKeyPhrasesResult result in keyPhrasesResult)
        {
            Console.WriteLine($"    Recognized the following {result.KeyPhrases.Count} Keyphrases:");

            foreach (string keyphrase in result.KeyPhrases)
            {
                Console.WriteLine($"    {keyphrase}");
            }
            Console.WriteLine("");
        }
    }
}
```

To see the full example source files, see:

* [Synchronously AnalyzeOperationBatch ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperation.cs)
* [Asynchronously AnalyzeOperationBatch ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync.cs)
* [Synchronously AnalyzeBathActionsConvenience ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationBatchConvenience.cs)
* [Asynchronously AnalyzeBathActionsConvenience ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationBatchConvenienceAsync.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md