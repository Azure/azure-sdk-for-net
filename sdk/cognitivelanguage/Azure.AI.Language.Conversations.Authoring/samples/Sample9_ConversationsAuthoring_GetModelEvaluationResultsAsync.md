# Getting Model Evaluation Results Asynchronously in Azure AI Language

This sample demonstrates how to retrieve and display model evaluation results asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

## Retrieve Model Evaluation Results Asynchronously

To retrieve model evaluation results for a project asynchronously, call GetModelEvaluationResultsAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResultsAsync
AsyncPageable<UtteranceEvaluationResult> results = authoringClient.GetModelEvaluationResultsAsync(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel,
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
    foreach (var entity in result.EntitiesResult.ExpectedEntities)
    {
        Console.WriteLine($" - Category: {entity.Category}, Offset: {entity.Offset}, Length: {entity.Length}");
    }

    Console.WriteLine("Predicted Entities:");
    foreach (var entity in result.EntitiesResult.PredictedEntities)
    {
        Console.WriteLine($" - Category: {entity.Category}, Offset: {entity.Offset}, Length: {entity.Length}");
    }

    Console.WriteLine();
}
```

To retrieve model evaluation results, call GetModelEvaluationResultsAsync on the AnalyzeConversationAuthoring client. This returns an AsyncPageable<UtteranceEvaluationResult> that allows you to iterate through and analyze the results.
