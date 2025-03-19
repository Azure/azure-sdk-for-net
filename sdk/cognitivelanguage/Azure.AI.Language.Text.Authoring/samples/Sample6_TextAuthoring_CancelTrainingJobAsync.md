# Canceling a Training Job Asynchronously in Azure AI Language

This sample demonstrates how to cancel a training job asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Cancel a Training Job Asynchronously

To cancel a training job, call CancelTrainingJobAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample6_TextAuthoring_CancelTrainingJobAsync
string projectName = "LoanAgreements";
TextAuthoringProject projectClient = client.GetProject(projectName);

string jobId = "training-job-id"; // Replace with an actual job ID.

Operation<TextAuthoringTrainingJobResult> operation = await projectClient.CancelTrainingJobAsync(
    waitUntil: WaitUntil.Completed,
    jobId: jobId
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
```

To cancel a training job, the CancelTrainingJobAsync method sends a request with the project name and the job ID. The method returns an Operation<TrainingJobResult> object indicating the cancellation status.
