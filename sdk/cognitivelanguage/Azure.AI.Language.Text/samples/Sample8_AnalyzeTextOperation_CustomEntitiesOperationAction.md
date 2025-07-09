# Perform custom named entity recognition (NER)

This sample demonstrates how to perform custom named entity recognition (NER) on one or more documents. In order to use this feature, you need to train a model with your own data. For more information on how to do the training, see [train model][train_model].

## Create a `TextAnalysisClient`

To create a new `TextAnalysisClient`, you will need the service endpoint and credentials of your Language resource. To authenticate, you can use the [`DefaultAzureCredential`][DefaultAzureCredential], which combines credentials commonly used to authenticate when deployed on Azure, with credentials used to authenticate in a development environment. In this sample, however, you will use an `AzureKeyCredential`, which you can create with an API key.

```C# Snippet:CreateTextAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisClientOptions options = new TextAnalysisClientOptions(TextAnalysisClientOptions.ServiceVersion.V2023_04_01);
var client = new TextAnalysisClient(endpoint, credential, options);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Perform custom NER on one or more text documents

To perform custom NER on one or more text documents, call `AnalyzeTextOperation` on the `TextAnalysisClient` by passing the documents as `MultiLanguageTextInput` parameter and a `AnalyzeTextOperationAction` with a `CustomEntitiesOperationAction` action. This returns a `Response<AnalyzeTextOperationState>` which you can extract the `CustomEntityRecognitionOperationResult`.

```C# Snippet:Sample8_AnalyzeTextOperation_CustomEntitiesOperationAction
string textA =
    "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
    + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
    + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
    + " athletic among us.";

string textB =
    "Last week we stayed at Hotel Foo to celebrate our anniversary. The staff knew about our anniversary"
    + " so they helped me organize a little surprise for my partner. The room was clean and with the"
    + " decoration I requested. It was perfect!";

// Prepare the input of the text analysis operation. You can add multiple documents to this list and
// perform the same operation on all of them simultaneously.
MultiLanguageTextInput multiLanguageTextInput = new MultiLanguageTextInput()
{
    MultiLanguageInputs =
    {
        new MultiLanguageInput("A", textA) { Language = "en" },
        new MultiLanguageInput("B", textB) { Language = "en" },
    }
};

// Specify the project and deployment names of the desired custom model. To train your own custom model to
// recognize custom entities, see https://aka.ms/azsdk/textanalytics/customentityrecognition.
string projectName = "<projectName>";
string deploymentName = "<deploymentName>";

CustomEntitiesActionContent customEntitiesActionContent = new CustomEntitiesActionContent(projectName, deploymentName);

var analyzeTextOperationActions = new AnalyzeTextOperationAction[]
{
    new CustomEntitiesOperationAction
    {
        Name = "CustomEntitiesOperationActionSample", // Optional string for humans to identify action by name.
        ActionContent = customEntitiesActionContent
    },
};

Response<AnalyzeTextOperationState> response = client.AnalyzeTextOperation(multiLanguageTextInput, analyzeTextOperationActions);

AnalyzeTextOperationState analyzeTextJobState = response.Value;

foreach (AnalyzeTextOperationResult analyzeTextLROResult in analyzeTextJobState.Actions.Items)
{
    if (analyzeTextLROResult is CustomEntityRecognitionOperationResult)
    {
        CustomEntityRecognitionOperationResult customClassificationResult = (CustomEntityRecognitionOperationResult)analyzeTextLROResult;

        // View the classifications recognized in the input documents.
        foreach (CustomEntityActionResult entitiesDocument in customClassificationResult.Results.Documents)
        {
            Console.WriteLine($"Result for document with Id = \"{entitiesDocument.Id}\":");
            Console.WriteLine($"  Recognized {entitiesDocument.Entities.Count} Entities:");

            foreach (NamedEntity entity in entitiesDocument.Entities)
            {
                Console.WriteLine($"  NamedEntity: {entity.Text}");
                Console.WriteLine($"  Category: {entity.Category}");
                Console.WriteLine($"  Offset: {entity.Offset}");
                Console.WriteLine($"  Length: {entity.Length}");
                Console.WriteLine($"  ConfidenceScore: {entity.ConfidenceScore}");
                Console.WriteLine($"  Subcategory: {entity.Subcategory}");
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
[README]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text/samples/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
