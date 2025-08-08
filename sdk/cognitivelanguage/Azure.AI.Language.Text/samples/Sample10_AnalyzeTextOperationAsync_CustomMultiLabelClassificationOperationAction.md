# Perform custom multi-label classification

This sample demonstrates how to perform custom multi-label classification one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform custom multi-label classification on one or more text documents

To perform custom multi-label classification one or more text documents, call `AnalyzeTextOperationAsync` on the `TextAnalysisClient` by passing the documents as `MultiLanguageTextInput` parameter and a `AnalyzeTextOperationAction` with a `CustomMltiLabelClassificationOperationAction` action. This returns a `Response<AnalyzeTextOperationState>` which you can extract the `CustomMultiLabelClassificationOperationResult`.

```C# Snippet:Sample10_AnalyzeTextOperationAsync_CustomMultiLabelClassificationOperationAction
string textA =
    "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and"
    + " add it to my playlist.";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA)
        {
            Language = "en"
        },
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

CustomMultiLabelClassificationActionContent customMultiLabelClassificationActionContent = new CustomMultiLabelClassificationActionContent(projectName, deploymentName);

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new CustomMultiLabelClassificationOperationAction
    {
        Name = "CMCOperationActionSample",
        ActionContent = customMultiLabelClassificationActionContent,
    },
};

Response<AnalyzeTextOperationState> response = await client.AnalyzeTextOperationAsync(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is CustomMultiLabelClassificationOperationResult)
    {
        CustomMultiLabelClassificationOperationResult customClassificationResult = (CustomMultiLabelClassificationOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (ClassificationActionResult customClassificationDocument in customClassificationResult.Results.Documents)
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
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
