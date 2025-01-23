# Training a Project Synchronously in Azure AI Language

This sample demonstrates how to train a project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Train a Project Synchronously

To train a project, call Train on the TextAnalysisAuthoring client.

```C# Snippet:Sample5_TextAuthoring_Train
string projectName = "LoanAgreements";

var trainingJobDetails = new TrainingJobDetails(
    modelLabel: "model1",
    trainingConfigVersion: "latest"
)
{
    EvaluationOptions = new EvaluationDetails
    {
        Kind = EvaluationKind.Percentage,
        TestingSplitPercentage = 20,
        TrainingSplitPercentage = 80
    }
};

Operation<TrainingJobResult> operation = authoringClient.Train(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: trainingJobDetails
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training completed with status: {operation.GetRawResponse().Status}");
```

To train a project, the Train method sends a request with the necessary training job configuration. The method returns an Operation<TrainingJobResult> object indicating the training status.
