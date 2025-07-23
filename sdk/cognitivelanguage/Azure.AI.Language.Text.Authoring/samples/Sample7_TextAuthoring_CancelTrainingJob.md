# Canceling a Training Job in Azure AI Language

This sample demonstrates how to cancel a training job synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Cancel a Training Job Synchronously

To cancel a training job, call CancelTrainingJob on the TextAnalysisAuthoring client.

```C# Snippet:Sample7_TextAuthoring_CancelTrainingJob
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

string jobId = "{jobId}"; // Replace with an actual job ID.

Operation<TextAuthoringTrainingJobResult> operation = projectClient.CancelTrainingJob(
    waitUntil: WaitUntil.Completed,
    jobId: jobId
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
```

To cancel a training job, the CancelTrainingJob method sends a request with the project name and the job ID. The method returns an Operation<TrainingJobResult> object indicating the cancellation status.

## Cancel a Training Job Asynchronously

To cancel a training job, call CancelTrainingJobAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample7_TextAuthoring_CancelTrainingJobAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

string jobId = "{jobId}"; // Replace with an actual job ID.

Operation<TextAuthoringTrainingJobResult> operation = await projectClient.CancelTrainingJobAsync(
    waitUntil: WaitUntil.Completed,
    jobId: jobId
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Training job cancellation completed with status: {operation.GetRawResponse().Status}");
```

To cancel a training job, the CancelTrainingJobAsync method sends a request with the project name and the job ID. The method returns an Operation<TrainingJobResult> object indicating the cancellation status.
