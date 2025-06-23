# Training a Model in Azure AI Language

This sample demonstrates how to train a model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Train a Model

To train a model, call Train on the `ConversationAuthoringProject` client. The method returns an Operation<TrainingJobResult> object containing the status of the training job, and the operation-location header can be used to track the training process.

```C# Snippet:Sample6_ConversationsAuthoring_Train
string projectName = "MySampleProject";
ConversationAuthoringProject projectClient = client.GetProject(projectName);
ConversationAuthoringTrainingJobDetails trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
    modelLabel: "MyModel",
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
string projectName = "EmailAppEnglish";

// Create connection info for data generation
var connectionInfo = new AnalyzeConversationAuthoringDataGenerationConnectionInfo(
    kind: AnalyzeConversationAuthoringDataGenerationConnectionKind.AzureOpenAI,
    deploymentName: "gpt-4o")
{
    ResourceId = "/subscriptions/e54a2925-af7f-4b05-9ba1-2155c5fe8a8e/resourceGroups/gouri-eastus/providers/Microsoft.CognitiveServices/accounts/sdk-test-openai"
};

// Prepare training job details with evaluation and data generation settings
var trainingJobDetails = new ConversationAuthoringTrainingJobDetails(
    modelLabel: "ModelWithDG",
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
