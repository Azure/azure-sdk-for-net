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
