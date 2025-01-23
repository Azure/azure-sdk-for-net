# Cancelling a Training Job in Azure AI Language

This sample demonstrates how to cancel a training job using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Cancel a Training Job

To cancel a training job, call CancelTrainingJob on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample7_ConversationsAuthoring_CancelTrainingJob
string projectName = "MyProject";
string jobId = "YourTrainingJobId";

Operation<TrainingJobResult> cancelOperation = authoringClient.CancelTrainingJob(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    jobId: jobId
);

 // Extract the operation-location header
string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
```

To cancel a training job, call CancelTrainingJob on the AnalyzeConversationAuthoring client. The method returns an Operation<TrainingJobResult> object, which contains the cancellation status, and the operation-location header can be used to track the cancellation process.
