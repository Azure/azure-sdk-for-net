# Canceling a Training Job Synchronously in Azure AI Language

This sample demonstrates how to cancel a training job synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Cancel a Training Job Synchronously

To cancel a training job, call CancelTrainingJob on the TextAnalysisAuthoring client.

```C# Snippet:Sample7_TextAuthoring_CancelTrainingJob
string projectName = "MyTrainingProject";
TextAuthoringProject projectClient = client.GetProject(projectName);

string jobId = "training-job-id"; // Replace with an actual job ID.

Operation<TextAuthoringTrainingJobResult> operation = projectClient.CancelTrainingJob(
    waitUntil: WaitUntil.Completed,
    jobId: jobId
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
```

To cancel a training job, the CancelTrainingJob method sends a request with the project name and the job ID. The method returns an Operation<TrainingJobResult> object indicating the cancellation status.
