# Getting Model Evaluation Results Asynchronously in Azure AI Language

This sample demonstrates how to retrieve and display model evaluation results asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Retrieve Model Evaluation Results Asynchronously

To retrieve model evaluation results for a project asynchronously, call GetModelEvaluationResultsAsync on the `ConversationAuthoringTrainedModel` client. This returns an AsyncPageable<UtteranceEvaluationResult> that allows you to iterate through and analyze the results.

```C# Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResultsAsync
string projectName = "SampleProject";
string trainedModelLabel = "SampleModel";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);
StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

AsyncPageable<UtteranceEvaluationResult> results = trainedModelClient.GetModelEvaluationResultsAsync(
    stringIndexType: stringIndexType
);

await foreach (UtteranceEvaluationResult result in results)
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
