# Retrieving Model Evaluation Results in Azure AI Language

This sample demonstrates how to retrieve model evaluation results, including intents and entities, for a specific trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Get Model Evaluation Results

To retrieve model evaluation results, call GetModelEvaluationResults on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResults
Pageable<UtteranceEvaluationResult> results = authoringClient.GetModelEvaluationResults(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel,
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

To retrieve model evaluation results, call GetModelEvaluationResults on the AnalyzeConversationAuthoring client, which provides evaluation metrics for intents and entities for each utterance in the dataset.
