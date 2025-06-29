# Retrieving Model Evaluation Results Synchronously in Azure AI Language

This sample demonstrates how to retrieve model evaluation results synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Retrieve Model Evaluation Results Synchronously

To retrieve model evaluation results, call `GetModelEvaluationResults` on the `TextAuthoringTrainedModel` client. The method returns a `Pageable<TextAuthoringDocumentEvalResult>` that allows you to enumerate the evaluation results for each document.

```C# Snippet:Sample9_TextAuthoring_GetModelEvaluationResults
string projectName = "MyEvaluationProject";
string trainedModelLabel = "model1";
StringIndexType stringIndexType = StringIndexType.Utf16CodeUnit;

TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Pageable<TextAuthoringDocumentEvalResult> results = trainedModelClient.GetModelEvaluationResults(
    stringIndexType: stringIndexType
);

foreach (TextAuthoringDocumentEvalResult result in results)
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
