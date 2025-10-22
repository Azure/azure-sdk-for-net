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

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Get Model Evaluation Results

To retrieve model evaluation results, call GetModelEvaluationResults on the `ConversationAuthoringTrainedModel` client, which provides evaluation metrics for intents and entities for each utterance in the dataset.

```C# Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResults
string projectName = "{projectName}";
string trainedModelLabel = "{trainedModelLabel}";

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

## Retrieve Model Evaluation Results Async

To retrieve model evaluation results for a project asynchronously, call GetModelEvaluationResultsAsync on the `ConversationAuthoringTrainedModel` client. This returns an AsyncPageable<UtteranceEvaluationResult> that allows you to iterate through and analyze the results.

```C# Snippet:Sample9_ConversationsAuthoring_GetModelEvaluationResultsAsync
string projectName = "{projectName}";
string trainedModelLabel = "{trainedModelLabel}";
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
