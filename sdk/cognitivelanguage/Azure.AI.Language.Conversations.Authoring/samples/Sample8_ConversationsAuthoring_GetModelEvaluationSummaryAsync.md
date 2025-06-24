# Retrieving Model Evaluation Summary Asynchronously in Azure AI Language

This sample demonstrates how to asynchronously retrieve a model evaluation summary for a specific trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Get Model Evaluation Summary Asynchronously

To asynchronously retrieve a model evaluation summary, call GetModelEvaluationSummaryAsync on the `ConversationAuthoringTrainedModel` client, which returns a Response<EvaluationSummary> containing evaluation metrics for intents and entities.

```C# Snippet:Sample8_ConversationsAuthoring_GetModelEvaluationSummaryAsync
string projectName = "MyProject";
string trainedModelLabel = "YourTrainedModelLabel";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Response<ConversationAuthoringEvalSummary> evaluationSummaryResponse = await trainedModelClient.GetModelEvaluationSummaryAsync();

// Print entities evaluation summary
EntitiesEvaluationSummary entitiesEval = evaluationSummaryResponse.Value.EntitiesEvaluation;
Console.WriteLine($"Entities - Micro F1: {entitiesEval.MicroF1}, Micro Precision: {entitiesEval.MicroPrecision}, Micro Recall: {entitiesEval.MicroRecall}");
Console.WriteLine($"Entities - Macro F1: {entitiesEval.MacroF1}, Macro Precision: {entitiesEval.MacroPrecision}, Macro Recall: {entitiesEval.MacroRecall}");

// Print detailed metrics per entity
foreach (KeyValuePair<string, ConversationAuthoringEntityEvalSummary> entity in entitiesEval.Entities)
{
    Console.WriteLine($"Entity '{entity.Key}': F1 = {entity.Value.F1}, Precision = {entity.Value.Precision}, Recall = {entity.Value.Recall}");
    Console.WriteLine($"  True Positives: {entity.Value.TruePositiveCount}, True Negatives: {entity.Value.TrueNegativeCount}");
    Console.WriteLine($"  False Positives: {entity.Value.FalsePositiveCount}, False Negatives: {entity.Value.FalseNegativeCount}");
}

// Print intents evaluation summary
IntentsEvaluationSummary intentsEval = evaluationSummaryResponse.Value.IntentsEvaluation;
Console.WriteLine($"Intents - Micro F1: {intentsEval.MicroF1}, Micro Precision: {intentsEval.MicroPrecision}, Micro Recall: {intentsEval.MicroRecall}");
Console.WriteLine($"Intents - Macro F1: {intentsEval.MacroF1}, Macro Precision: {intentsEval.MacroPrecision}, Macro Recall: {intentsEval.MacroRecall}");

// Print detailed metrics per intent
foreach (KeyValuePair<string, IntentEvaluationSummary> intent in intentsEval.Intents)
{
    Console.WriteLine($"Intent '{intent.Key}': F1 = {intent.Value.F1}, Precision = {intent.Value.Precision}, Recall = {intent.Value.Recall}");
    Console.WriteLine($"  True Positives: {intent.Value.TruePositiveCount}, True Negatives: {intent.Value.TrueNegativeCount}");
    Console.WriteLine($"  False Positives: {intent.Value.FalsePositiveCount}, False Negatives: {intent.Value.FalseNegativeCount}");
}
```
