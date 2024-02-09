# Perform custom single-label classification

This sample demonstrates how to perform custom single-label classification on one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `AnalyzeTextClient`

To create a new `AnalyzeTextClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateAnalyzeTextClient
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new(TestEnvironment.ApiKey);
Language client = new AnalyzeTextClient(endpoint, credential).GetLanguageClient(apiVersion: "2023-04-01");
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform custom single-label classification on one or more text documents

To perform custom single-label classification one or more text documents, call `SingleLabelClassifyAsync` on the `TextAnalyticsClient` by passing the documents as either an `IEnumerable<string>` parameter or an `IEnumerable<TextDocumentInput>` parameter. This returns a `ClassifyDocumentOperation`.

```C# Snippet:Sample9_AnalyzeTextSubmitJob_CustomSingleLabelClassificationLROTask
string documentA =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageAnalysisInput multiLanguageAnalysisInput = new MultiLanguageAnalysisInput()
{
    Documents =
        {
            new MultiLanguageInput("A", documentA, "en"),
        }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

AnalyzeTextJobsInput analyzeTextJobsInput = new AnalyzeTextJobsInput(multiLanguageAnalysisInput, new AnalyzeTextLROTask[]
{
    new CustomSingleLabelClassificationLROTask()
    {
        Parameters = new CustomSingleLabelClassificationTaskParameters(projectName, deploymentName)
    }
});
Operation operation = client.AnalyzeTextSubmitJob(WaitUntil.Completed, analyzeTextJobsInput);
```

Using `WaitUntil.Completed` means that the long-running operation will be automatically polled until it has completed. You can then view the results of the custom single-label classification, including any errors that might have occurred:

```C# Snippet:Sample9_AnalyzeTextSubmitJob_CustomSingleLabelClassificationLROTask_ViewResults
// View the operation results.
AnalyzeTextJobState analyzeTextJobState = AnalyzeTextJobState.FromResponse(operation.GetRawResponse());

foreach (AnalyzeTextLROResult analyzeTextLROResult in analyzeTextJobState.Tasks.Items)
{
    if (analyzeTextLROResult.Kind == AnalyzeTextLROResultsKind.CustomSingleLabelClassificationLROResults)
    {
        CustomSingleLabelClassificationLROResult customClassificationResult = (CustomSingleLabelClassificationLROResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (ClassificationDocumentResult customClassificationDocument in customClassificationResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{customClassificationDocument.Id}\":");
            Console.WriteLine($"  Recognized {customClassificationDocument.Class.Count} classifications:");

            foreach (ClassificationResult classification in customClassificationDocument.Class)
            {
                Console.WriteLine($"  Classification: {classification.Category}");
                Console.WriteLine($"  ConfidenceScore: {classification.ConfidenceScore}");
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
    }
}
```

See the [README] of the Text Analytics client library for more information, including useful links and instructions.

[train_model]: https://aka.ms/azsdk/textanalytics/customfunctionalities
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/textanalytics/Azure.AI.TextAnalytics/README.md
