# Retrieving Model Evaluation Summary in Azure AI Language

This sample demonstrates how to retrieve the evaluation summary of a trained model synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient

To create a `TextAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `TextAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Get Model Evaluation Summary Synchronously

To retrieve the evaluation summary of a trained model, call GetModelEvaluationSummary on the TextAnalysisAuthoring client.

```C# Snippet:Sample8_TextAuthoring_GetSingleLabelClassificationEvaluationSummary
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

// Get the evaluation summary for the trained model
Response<TextAuthoringEvalSummary> evaluationSummaryResponse = trainedModelClient.GetModelEvaluationSummary();

TextAuthoringEvalSummary evaluationSummary = evaluationSummaryResponse.Value;

// Cast to the specific evaluation summary type for custom single label classification
if (evaluationSummary is CustomSingleLabelClassificationEvalSummary singleLabelSummary)
{
    Console.WriteLine($"Project Kind: CustomSingleLabelClassification");
    Console.WriteLine($"Evaluation Options: ");
    Console.WriteLine($"    Kind: {singleLabelSummary.EvaluationOptions.Kind}");
    Console.WriteLine($"    Training Split Percentage: {singleLabelSummary.EvaluationOptions.TrainingSplitPercentage}");
    Console.WriteLine($"    Testing Split Percentage: {singleLabelSummary.EvaluationOptions.TestingSplitPercentage}");

    Console.WriteLine($"Micro F1: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroF1}");
    Console.WriteLine($"Micro Precision: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroPrecision}");
    Console.WriteLine($"Micro Recall: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroRecall}");
    Console.WriteLine($"Macro F1: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroF1}");
    Console.WriteLine($"Macro Precision: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroPrecision}");
    Console.WriteLine($"Macro Recall: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroRecall}");

    // Print confusion matrix
    Console.WriteLine("Confusion Matrix:");
    foreach (var row in singleLabelSummary.CustomSingleLabelClassificationEvaluation.ConfusionMatrix)
    {
        Console.WriteLine($"Row: {row.Key}");
        foreach (var col in row.Value.AdditionalProperties)
        {
            try
            {
                // Deserialize BinaryData properly
                var cell = col.Value.ToObject<TextAuthoringConfusionMatrixCell>(new JsonObjectSerializer());
                Console.WriteLine($"    Column: {col.Key}, Normalized Value: {cell.NormalizedValue}, Raw Value: {cell.RawValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"    Error deserializing column {col.Key}: {ex.Message}");
            }
        }
    }

    // Print class-specific metrics
    Console.WriteLine("Class-Specific Metrics:");
    foreach (var kvp in singleLabelSummary.CustomSingleLabelClassificationEvaluation.Classes)
    {
        Console.WriteLine($"Class: {kvp.Key}");
        Console.WriteLine($"    F1: {kvp.Value.F1}");
        Console.WriteLine($"    Precision: {kvp.Value.Precision}");
        Console.WriteLine($"    Recall: {kvp.Value.Recall}");
        Console.WriteLine($"    True Positives: {kvp.Value.TruePositiveCount}");
        Console.WriteLine($"    True Negatives: {kvp.Value.TrueNegativeCount}");
        Console.WriteLine($"    False Positives: {kvp.Value.FalsePositiveCount}");
        Console.WriteLine($"    False Negatives: {kvp.Value.FalseNegativeCount}");
    }
}
else
{
    Console.WriteLine("The returned evaluation summary is not for a single-label classification project.");
}
```

To retrieve a model evaluation summary, the GetModelEvaluationSummary method sends a request with the project name and the model label. It returns a specific EvaluationSummary object containing metrics such as F1 score, precision, recall, and class-specific metrics.

## Get Model Evaluation Summary Asynchronously

To retrieve the evaluation summary of a trained model, call GetModelEvaluationSummaryAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample8_TextAuthoring_GetSingleLabelClassificationEvaluationSummaryAsync
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

// Get the evaluation summary for the trained model
Response<TextAuthoringEvalSummary> evaluationSummaryResponse = await trainedModelClient.GetModelEvaluationSummaryAsync();

TextAuthoringEvalSummary evaluationSummary = evaluationSummaryResponse.Value;

// Cast to the specific evaluation summary type for custom single label classification
if (evaluationSummary is CustomSingleLabelClassificationEvalSummary singleLabelSummary)
{
    Console.WriteLine($"Project Kind: CustomSingleLabelClassification");
    Console.WriteLine($"Evaluation Options: ");
    Console.WriteLine($"    Kind: {singleLabelSummary.EvaluationOptions.Kind}");
    Console.WriteLine($"    Training Split Percentage: {singleLabelSummary.EvaluationOptions.TrainingSplitPercentage}");
    Console.WriteLine($"    Testing Split Percentage: {singleLabelSummary.EvaluationOptions.TestingSplitPercentage}");

    Console.WriteLine($"Micro F1: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroF1}");
    Console.WriteLine($"Micro Precision: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroPrecision}");
    Console.WriteLine($"Micro Recall: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MicroRecall}");
    Console.WriteLine($"Macro F1: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroF1}");
    Console.WriteLine($"Macro Precision: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroPrecision}");
    Console.WriteLine($"Macro Recall: {singleLabelSummary.CustomSingleLabelClassificationEvaluation.MacroRecall}");

    // Print confusion matrix
    Console.WriteLine("Confusion Matrix:");
    foreach (var row in singleLabelSummary.CustomSingleLabelClassificationEvaluation.ConfusionMatrix)
    {
        Console.WriteLine($"Row: {row.Key}");
        foreach (var col in row.Value.AdditionalProperties)
        {
            try
            {
                // Deserialize BinaryData properly
                var cell = col.Value.ToObject<TextAuthoringConfusionMatrixCell>(new JsonObjectSerializer());
                Console.WriteLine($"    Column: {col.Key}, Normalized Value: {cell.NormalizedValue}, Raw Value: {cell.RawValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"    Error deserializing column {col.Key}: {ex.Message}");
            }
        }
    }

    // Print class-specific metrics
    Console.WriteLine("Class-Specific Metrics:");
    foreach (var kvp in singleLabelSummary.CustomSingleLabelClassificationEvaluation.Classes)
    {
        Console.WriteLine($"Class: {kvp.Key}");
        Console.WriteLine($"    F1: {kvp.Value.F1}");
        Console.WriteLine($"    Precision: {kvp.Value.Precision}");
        Console.WriteLine($"    Recall: {kvp.Value.Recall}");
        Console.WriteLine($"    True Positives: {kvp.Value.TruePositiveCount}");
        Console.WriteLine($"    True Negatives: {kvp.Value.TrueNegativeCount}");
        Console.WriteLine($"    False Positives: {kvp.Value.FalsePositiveCount}");
        Console.WriteLine($"    False Negatives: {kvp.Value.FalseNegativeCount}");
    }
}
else
{
    Console.WriteLine("The returned evaluation summary is not for a single-label classification project.");
}
```

To retrieve a model evaluation summary, the GetModelEvaluationSummaryAsync method sends a request with the project name and the model label. It returns a specific EvaluationSummary object containing metrics such as F1 score, precision, recall, and class-specific metrics.
