# Training a Project in Azure AI Language

This sample demonstrates how to train a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Train a Project Synchronously

To train a project, call Train on the TextAnalysisAuthoring client.

```C# Snippet:Sample6_TextAuthoring_Train
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var trainingJobDetails = new TextAuthoringTrainingJobDetails(
    modelLabel: "{modelLabel}",
    trainingConfigVersion: "latest"
)
{
    EvaluationOptions = new TextAuthoringEvaluationDetails
    {
        Kind = TextAuthoringEvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    }
};

Operation<TextAuthoringTrainingJobResult> operation = projectClient.Train(
    waitUntil: WaitUntil.Completed,
    details: trainingJobDetails
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

To train a project, the Train method sends a request with the necessary training job configuration. The method returns an Operation<TrainingJobResult> object indicating the training status.

## Train a Project Asynchronously

To train a project, call TrainAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample6_TextAuthoring_TrainAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var trainingJobConfig = new TextAuthoringTrainingJobDetails(
    modelLabel: "{modelLabel}",
    trainingConfigVersion: "latest"
)
{
    EvaluationOptions = new TextAuthoringEvaluationDetails
    {
        Kind = TextAuthoringEvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    }
};

Operation<TextAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
    waitUntil: WaitUntil.Completed,
    details: trainingJobConfig
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

To train a project, the TrainAsync method sends a request with the necessary training job configuration. The method returns an Operation<TrainingJobResult> object indicating the training status.
