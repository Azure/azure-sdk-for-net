# Training a Model in Azure AI Language

This sample demonstrates how to train a model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Train a Model

To train a model, call Train on the ConversationalAnalysisAuthoring client.

```C# Snippet:Sample6_ConversationsAuthoring_Train
string projectName = "MySampleProject";

var trainingJobConfig = new TrainingJobConfig(
    modelLabel: "MyModel",
    trainingMode: TrainingMode.Standard
)
{
    TrainingConfigVersion = "1.0",
    EvaluationOptions = new EvaluationConfig
    {
        Kind = EvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    }
};

Operation<TrainingJobResult> operation = authoringClient.Train(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: trainingJobConfig
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

To train a model, call Train on the ConversationalAnalysisAuthoring client. The method returns an Operation<TrainingJobResult> object containing the status of the training job, and the operation-location header can be used to track the training process.
