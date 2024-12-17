# Retrieving Model Evaluation Summary Synchronously in Azure AI Language

This sample demonstrates how to retrieve the evaluation summary of a trained model synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Get Model Evaluation Summary Synchronously

To retrieve the evaluation summary of a trained model, call GetModelEvaluationSummary on the TextAnalysisAuthoring client.

```C# Snippet:Sample7_TextAuthoring_GetSingleLabelClassificationEvaluationSummary
string projectName = "LoanAgreements";
string trainedModelLabel = "model2";

// Get the evaluation summary for the trained model
Response<EvaluationSummary> evaluationSummaryResponse = authoringClient.GetModelEvaluationSummary(projectName, trainedModelLabel);

EvaluationSummary evaluationSummary = evaluationSummaryResponse.Value;

// Cast to the specific evaluation summary type for custom single label classification
if (evaluationSummary is CustomSingleLabelClassificationEvaluationSummary singleLabelSummary)
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
    foreach (var row in singleLabelSummary.CustomSingleLabelClassificationEvaluation.ConfusionMatrix.AdditionalProperties)
    {
        Console.WriteLine($"Row: {row.Key}");
        var columnData = row.Value.ToObjectFromJson<Dictionary<string, BinaryData>>();
        foreach (var col in columnData)
        {
            var values = col.Value.ToObjectFromJson<Dictionary<string, float>>();
            Console.WriteLine($"    Column: {col.Key}, Normalized Value: {values["normalizedValue"]}, Raw Value: {values["rawValue"]}");
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
