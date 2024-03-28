# Perform custom named entity recognition (NER)

This sample demonstrates how to perform custom named entity recognition (NER) on one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new(TestEnvironment.ApiKey);
AnalyzeTextClient client = new AnalyzeTextClient(endpoint, credential);;
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform custom NER on one or more text documents

To perform custom NER on one or more text documents, call `RecognizeCustomEntitiesAsync` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter. This returns a `RecognizeCustomEntitiesOperation`.

```C# Snippet:Sample8_AnalyzeTextSubmitJob_CustomEntitiesLROTask
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
MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
{
    Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
            new MultiLanguageInput("B", documentB, "en"),
        }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

// Perform the text analysis operation.
AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
{
    new CustomEntitiesLROTask()
    {
        Parameters = new CustomEntitiesTaskContent(projectName, deploymentName)
    }
});
Operation operation = await client.AnalyzeTextSubmitJobAsync(WaitUntil.Completed, analyzeTextJobsInput);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the custom NER, including any errors that might have occurred:

```C# Snippet:Sample8_AnalyzeTextSubmitJob_CustomEntitiesLROTask_ViewResults
AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
{
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.CustomEntityRecognitionLROResults)
    {
        CustomEntityRecognitionLROResult customClassificationResult = (CustomEntityRecognitionLROResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (EntitiesDocumentResult entitiesDocument in customClassificationResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{entitiesDocument.Id}\":");
            Console.WriteLine($"  Recognized {entitiesDocument.Entities.Count} Entities:");

            foreach (Entity entity in entitiesDocument.Entities)
            {
                Console.WriteLine($"  Entity: {entity.Text}");
                Console.WriteLine($"  Category: {entity.Category}");
                Console.WriteLine($"  Offset: {entity.Offset}");
                Console.WriteLine($"  Length: {entity.Length}");
                Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                Console.WriteLine($"  SubCategory: {entity.SubCategory}");
                Console.WriteLine();
            }
        }
        // View the errors in the document
        foreach (DocumentError error in customClassificationResult.Results.Errors)
        {
            Console.WriteLine($"  Error in document: {error.Id}!");
            Console.WriteLine($"  Document error: {error.Error}");
            continue;
        }
        Console.WriteLine();
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

<!-- LINKS -->
[train_model]: https://aka.ms/azsdk/textanalytics/customentityrecognition
[README]: https://github.com/quentinRobinson/azure-sdk-for-net/blob/qrobinson/analyze-text-sdk/sdk/cognitivelanguage/Azure.AI.Language.TextAnalytics/samples/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
