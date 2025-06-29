# Retrieving Model Evaluation Results in Azure AI Language

This sample demonstrates how to retrieve model evaluation results, including intents and entities, for a specific trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Get Model Evaluation Results

To retrieve model evaluation results, call GetModelEvaluationResults on the `ConversationAuthoringTrainedModel` client, which provides evaluation metrics for intents and entities for each utterance in the dataset.

```C# Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResults
string projectName = "SampleProject";
string trainedModelLabel = "SampleModel";

ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);
StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;
Pageable<UtteranceEvaluationResult> results = trainedModelClient.GetModelEvaluationResults(
    stringIndexType: stringIndexType
);

foreach (UtteranceEvaluationResult result in results)
{
    Console.WriteLine($"Text: {result.Text}");
    Console.WriteLine($"Language: {result.Language}");

    // Print intents result
    Console.WriteLine($"Expected Intent: {result.IntentsResult.ExpectedIntent}");
    Console.WriteLine($"Predicted Intent: {result.IntentsResult.PredictedIntent}");

    // Print entities result
    Console.WriteLine("Expected Entities:");
    foreach (UtteranceEntityEvaluationResult entity in result.EntitiesResult.ExpectedEntities)
    {
        Console.WriteLine($" - Category: {entity.Category}, Offset: {entity.Offset}, Length: {entity.Length}");
    }

    Console.WriteLine("Predicted Entities:");
    foreach (UtteranceEntityEvaluationResult entity in result.EntitiesResult.PredictedEntities)
    {
        Console.WriteLine($" - Category: {entity.Category}, Offset: {entity.Offset}, Length: {entity.Length}");
    }

    Console.WriteLine();
}
```
