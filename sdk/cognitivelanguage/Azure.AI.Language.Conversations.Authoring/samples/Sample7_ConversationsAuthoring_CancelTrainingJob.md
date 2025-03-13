# Cancelling a Training Job in Azure AI Language

This sample demonstrates how to cancel a training job using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Cancel a Training Job

To cancel a training job, call CancelTrainingJob on the `ConversationAuthoringProject` client. The method returns an Operation<TrainingJobResult> object, which contains the cancellation status, and the operation-location header can be used to track the cancellation process.

```C# Snippet:Sample7_ConversationsAuthoring_CancelTrainingJob
string projectName = "MyProject";
string jobId = "YourTrainingJobId";
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
