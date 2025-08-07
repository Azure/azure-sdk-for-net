# Cancelling a Training Job in Azure AI Language

This sample demonstrates how to cancel a training job using the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## Cancel a Training Job

To cancel a training job, call CancelTrainingJob on the `ConversationAuthoringProject` client. The method returns an Operation<TrainingJobResult> object, which contains the cancellation status, and the operation-location header can be used to track the cancellation process.

```C# Snippet:Sample7_ConversationsAuthoring_CancelTrainingJob
string projectName = "{projectName}";
string jobId = "{jobId}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation<ConversationAuthoringTrainingJobResult> cancelOperation = projectClient.CancelTrainingJob(
    waitUntil: WaitUntil.Completed,
    jobId: jobId
);

 // Extract the operation-location header
string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
```

## Cancel a Training Job Async

To cancel a training job asynchronously, call CancelTrainingJobAsync on the `ConversationAuthoringProject` client. The method returns an Operation<TrainingJobResult> object, which contains the cancellation status, and the operation-location header can be used to track the cancellation process.

```C# Snippet:Sample7_ConversationsAuthoring_CancelTrainingJobAsync
string projectName = "{projectName}";
string jobId = "{jobId}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation<ConversationAuthoringTrainingJobResult> cancelOperation = await projectClient.CancelTrainingJobAsync(
    waitUntil: WaitUntil.Completed,
    jobId: jobId
);

// Extract the operation-location header
string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
```
