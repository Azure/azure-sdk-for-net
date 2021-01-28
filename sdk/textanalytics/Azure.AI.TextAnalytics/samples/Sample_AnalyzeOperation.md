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

```C# Snippet:AnalyzeOperationBatchConvenience
    string document = @"We went to Contoso Steakhouse located at midtown NYC last week for a dinner party, 
                        and we adore the spot! They provide marvelous food and they have a great menu. The
                        chief cook happens to be the owner (I think his name is John Doe) and he is super 
                        nice, coming out of the kitchen and greeted us all. We enjoyed very much dining in 
                        the place! The Sirloin steak I ordered was tender and juicy, and the place was impeccably
                        clean. You can even pre-order from their online menu at www.contososteakhouse.com, 
                        call 312-555-0176 or send email to order@contososteakhouse.com! The only complaint 
                        I have is the food didn't come fast enough. Overall I highly recommend it!";

    var batchDocuments = new List<string> { document };

    AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
    {
        KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
        EntitiesTaskParameters = new EntitiesTaskParameters(),
        PiiTaskParameters = new PiiTaskParameters(),
        DisplayName = "AnalyzeOperationSample"
    };

    AnalyzeOperation operation = client.StartAnalyzeOperationBatch(batchDocuments, operationOptions);

    await operation.WaitForCompletionAsync();

    AnalyzeOperationResult resultCollection = operation.Value;

    RecognizeEntitiesResultCollection entitiesResult = resultCollection.Tasks.EntityRecognitionTasks[0].Results;

    ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

    RecognizePiiEntitiesResultCollection piiResult = resultCollection.Tasks.EntityRecognitionPiiTasks[0].Results;

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
```

To see the full example source files, see:

* [Synchronously AnalyzeOperationBatch ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperation.cs)
* [Asynchronously AnalyzeOperationBatch ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync.cs)
* [Automatic Polling AnalyzeOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync_AutomaticPolling.cs)
* [Manual Polling AnalyzeOperation ](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/tests/samples/Sample_AnalyzeOperationAsync_ManualPolling.cs)

[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/textanalytics/Azure.AI.TextAnalytics/README.md