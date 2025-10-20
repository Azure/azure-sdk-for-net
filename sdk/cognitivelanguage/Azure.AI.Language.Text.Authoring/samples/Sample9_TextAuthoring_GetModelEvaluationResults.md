# Retrieving Model Evaluation Results in Azure AI Language

This sample demonstrates how to retrieve model evaluation results synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Retrieve Model Evaluation Results Synchronously

To retrieve model evaluation results, call `GetModelEvaluationResults` on the `TextAuthoringTrainedModel` client. The method returns a `Pageable<TextAuthoringDocumentEvalResult>` that allows you to enumerate the evaluation results for each document.

```C# Snippet:Sample9_TextAuthoring_GetModelEvaluationResults
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
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

## Retrieve Model Evaluation Results Asynchronously

To retrieve model evaluation results, call `GetModelEvaluationResultsAsync` on the `TextAuthoringTrainedModel` client. The method returns an `AsyncPageable<TextAuthoringDocumentEvalResult>` that allows you to enumerate the evaluation results for each document asynchronously.

```C# Snippet:Sample9_TextAuthoring_GetModelEvaluationResultsAsync
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
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
