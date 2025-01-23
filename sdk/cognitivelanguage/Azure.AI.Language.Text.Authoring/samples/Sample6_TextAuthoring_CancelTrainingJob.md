# Canceling a Training Job Synchronously in Azure AI Language

This sample demonstrates how to cancel a training job synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Cancel a Training Job Synchronously

To cancel a training job, call CancelTrainingJob on the TextAnalysisAuthoring client.

```C# Snippet:Sample6_TextAuthoring_CancelTrainingJob
string projectName = "LoanAgreements";
string jobId = "training-job-id"; // Replace with an actual job ID.

Operation<TrainingJobResult> operation = authoringClient.CancelTrainingJob(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    jobId: jobId
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
```

To cancel a training job, the CancelTrainingJob method sends a request with the project name and the job ID. The method returns an Operation<TrainingJobResult> object indicating the cancellation status.
