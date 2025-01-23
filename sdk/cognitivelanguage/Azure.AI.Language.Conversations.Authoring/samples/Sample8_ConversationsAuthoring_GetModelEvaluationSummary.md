# Retrieving Model Evaluation Summary in Azure AI Language

This sample demonstrates how to retrieve a model evaluation summary for a specific trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## Get Model Evaluation Summary

To retrieve a model evaluation summary, call GetModelEvaluationSummary on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample8_ConversationsAuthoring_GetModelEvaluationSummary
string projectName = "MyProject";
string trainedModelLabel = "YourTrainedModelLabel";

Response<EvaluationSummary> evaluationSummaryResponse = authoringClient.GetModelEvaluationSummary(
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

// Print entities evaluation summary
var entitiesEval = evaluationSummaryResponse.Value.EntitiesEvaluation;
Console.WriteLine($"Entities - Micro F1: {entitiesEval.MicroF1}, Micro Precision: {entitiesEval.MicroPrecision}, Micro Recall: {entitiesEval.MicroRecall}");
Console.WriteLine($"Entities - Macro F1: {entitiesEval.MacroF1}, Macro Precision: {entitiesEval.MacroPrecision}, Macro Recall: {entitiesEval.MacroRecall}");

// Print detailed metrics per entity
foreach (var entity in entitiesEval.Entities)
{
    Console.WriteLine($"Entity '{entity.Key}': F1 = {entity.Value.F1}, Precision = {entity.Value.Precision}, Recall = {entity.Value.Recall}");
    Console.WriteLine($"  True Positives: {entity.Value.TruePositiveCount}, True Negatives: {entity.Value.TrueNegativeCount}");
    Console.WriteLine($"  False Positives: {entity.Value.FalsePositiveCount}, False Negatives: {entity.Value.FalseNegativeCount}");
}

// Print intents evaluation summary
var intentsEval = evaluationSummaryResponse.Value.IntentsEvaluation;
Console.WriteLine($"Intents - Micro F1: {intentsEval.MicroF1}, Micro Precision: {intentsEval.MicroPrecision}, Micro Recall: {intentsEval.MicroRecall}");
Console.WriteLine($"Intents - Macro F1: {intentsEval.MacroF1}, Macro Precision: {intentsEval.MacroPrecision}, Macro Recall: {intentsEval.MacroRecall}");

// Print detailed metrics per intent
foreach (var intent in intentsEval.Intents)
{
    Console.WriteLine($"Intent '{intent.Key}': F1 = {intent.Value.F1}, Precision = {intent.Value.Precision}, Recall = {intent.Value.Recall}");
    Console.WriteLine($"  True Positives: {intent.Value.TruePositiveCount}, True Negatives: {intent.Value.TrueNegativeCount}");
    Console.WriteLine($"  False Positives: {intent.Value.FalsePositiveCount}, False Negatives: {intent.Value.FalseNegativeCount}");
}
```

To retrieve a model evaluation summary, call GetModelEvaluationSummary on the AnalyzeConversationAuthoring client, which returns a Response<EvaluationSummary> containing evaluation metrics for intents and entities.
