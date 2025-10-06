# Training a Model in Azure AI Language

This sample demonstrates how to train a model using the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## Train a Model

To train a model, call Train on the `ConversationAuthoringProject` client. The method returns an Operation<TrainingJobResult> object containing the status of the training job, and the operation-location header can be used to track the training process.

```C# Snippet:Sample6_ConversationsAuthoring_Train
string projectName = "{projectName}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);
ConversationAuthoringTrainingJobDetails trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
    modelLabel: "{modelLabel}",
    trainingMode: ConversationAuthoringTrainingMode.Standard
)
{
    TrainingConfigVersion = "1.0",
    EvaluationOptions = new ConversationAuthoringEvaluationDetails
    {
        Kind = ConversationAuthoringEvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    }
};

Operation<ConversationAuthoringTrainingJobResult> operation = projectClient.Train(
    waitUntil: WaitUntil.Completed,
    details: trainingJobDetails
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

## Train a Model with Data Generation Settings

To train a model with data generation, include `DataGenerationSettings` when calling `Train` on the `ConversationAuthoringProject` client. This enables the service to generate additional training data using a connected Azure OpenAI resource. The method returns an `Operation<TrainingJobResult>` object, and the `operation-location` header can be used to track the training process.

```C# Snippet:Sample6_ConversationsAuthoring_Train_WithDataGeneration
string projectName = "{projectName}";

// Create connection info for data generation
var connectionInfo = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
    kind: AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
    deploymentName: "gpt-4o")
{
    ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
};

// Prepare training job details with evaluation and data generation settings
var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
    modelLabel: "{modelLabel}",
    trainingMode: ConversationAuthoringTrainingMode.Standard)
{
    TrainingConfigVersion = "2025-05-15-preview-ConvLevel",
    EvaluationOptions = new ConversationAuthoringEvaluationDetails
    {
        Kind = ConversationAuthoringEvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    },
    DataGenerationSettings = new AnalyzeConversationAuthoringDataGenerationSettings(
        enableDataGeneration: true,
        dataGenerationConnectionInfo: connectionInfo)
};

// Start the training operation
ConversationAuthoringProject projectClient = client.GetProject(projectName);
Operation<ConversationAuthoringTrainingJobResult> operation = projectClient.Train(
    waitUntil: WaitUntil.Completed,
    details: trainingJobDetails);

// Extract operation location header and print status
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

## Train a Model Async

To train a model asynchronously, call TrainAsync on the `ConversationAuthoringProject` client. The method returns an Operation<TrainingJobResult> object containing the status of the training job, and the operation-location header can be used to track the training process.

```C# Snippet:Sample6_ConversationsAuthoring_TrainAsync
string projectName = "{projectName}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

ConversationAuthoringTrainingJobDetails trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
    modelLabel: "{modelLabel}",
    trainingMode: ConversationAuthoringTrainingMode.Standard
)
{
    TrainingConfigVersion = "1.0",
    EvaluationOptions = new ConversationAuthoringEvaluationDetails
    {
        Kind = ConversationAuthoringEvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    }
};

Operation<ConversationAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
    waitUntil: WaitUntil.Completed,
    details: trainingJobDetails
);

// Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

## Train a Model with Data Generation Async

To train a model asynchronously with data generation, use the `TrainAsync` method on the `ConversationAuthoringProject` client.
By providing `DataGenerationSettings`, the service can generate additional training data using an external resource such as Azure OpenAI.
The method returns an `Operation<TrainingJobResult>` object, and the `operation-location` header can be used to track the training status.

```C# Snippet:Sample6_ConversationsAuthoring_TrainAsync_WithDataGeneration
string projectName = "{projectName}";

// Create connection info for data generation
var connectionInfo = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
    kind: AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
    deploymentName: "gpt-4o")
{
    ResourceId = "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
};

// Prepare training job details
var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
    modelLabel: "{modelLabel}",
    trainingMode: ConversationAuthoringTrainingMode.Standard)
{
    TrainingConfigVersion = "2025-05-15-preview-ConvLevel",
    EvaluationOptions = new ConversationAuthoringEvaluationDetails
    {
        Kind = ConversationAuthoringEvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    },
    DataGenerationSettings = new AnalyzeConversationAuthoringDataGenerationSettings(
        enableDataGeneration: true,
        dataGenerationConnectionInfo: connectionInfo)
};

// Start training
ConversationAuthoringProject projectClient = client.GetProject(projectName);
Operation<ConversationAuthoringTrainingJobResult> operation = await projectClient.TrainAsync(
    waitUntil: WaitUntil.Completed,
    details: trainingJobDetails);

// Extract and print operation location and status
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```
