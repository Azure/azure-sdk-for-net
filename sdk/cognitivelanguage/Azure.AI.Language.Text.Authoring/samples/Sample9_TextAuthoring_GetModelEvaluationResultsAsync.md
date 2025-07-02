# Retrieving Model Evaluation Results Asynchronously in Azure AI Language

This sample demonstrates how to retrieve model evaluation results asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Retrieve Model Evaluation Results Asynchronously

To retrieve model evaluation results, call `GetModelEvaluationResultsAsync` on the `TextAuthoringTrainedModel` client. The method returns an `AsyncPageable<TextAuthoringDocumentEvalResult>` that allows you to enumerate the evaluation results for each document asynchronously.

```C# Snippet:Sample9_TextAuthoring_GetModelEvaluationResultsAsync
string projectName = "MyEvaluationProjectAsync";
string trainedModelLabel = "model1";
StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

AsyncPageable<TextAuthoringDocumentEvalResult> results = trainedModelClient.GetModelEvaluationResultsAsync(
    stringIndexType: stringIndexType
);

await foreach (TextAuthoringDocumentEvalResult result in results)
{
    Console.WriteLine($"Document Location: {result.Location}");
    Console.WriteLine($"Language: {result.Language}");

    // Example: handle single-label classification results
    if (result is CustomSingleLabelClassificationDocumentEvalResult singleLabelResult)
    {
        var classification = singleLabelResult.CustomSingleLabelClassificationResult;
        Console.WriteLine($"Expected Class: {classification.ExpectedClass}");
        Console.WriteLine($"Predicted Class: {classification.PredictedClass}");
    }
    // Add handling for other result types as needed
}
```
