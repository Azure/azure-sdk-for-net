# Cancelling a Training Job Asynchronously in Azure AI Language

This sample demonstrates how to asynchronously cancel a training job using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AnalyzeConversationClient`

To create an `AnalyzeConversationClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AnalyzeConversationClientOptions` instance.

```C# Snippet:CreateAnalyzeConversationClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AnalyzeConversationClientOptions options = new AnalyzeConversationClientOptions(AnalyzeConversationClientOptions.ServiceVersion.V2024_11_15_Preview);
AnalyzeConversationClient client = new AnalyzeConversationClient(endpoint, credential, options);
AnalyzeConversationAuthoring AnalyzeConversationClient = client.GetAnalyzeConversationAnalyzeConversationClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Cancel a Training Job Asynchronously

To cancel a training job asynchronously, call CancelTrainingJobAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample7_ConversationsAuthoring_CancelTrainingJobAsync
string projectName = "MyProject";
string jobId = "YourTrainingJobId";

Operation<TrainingJobResult> cancelOperation = await AnalyzeConversationClient.CancelTrainingJobAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    jobId: jobId
);

 // Extract the operation-location header
string operationLocation = cancelOperation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Training job cancellation completed with status: {cancelOperation.GetRawResponse().Status}");
```

To cancel a training job asynchronously, call CancelTrainingJobAsync on the AnalyzeConversationAuthoring client. The method returns an Operation<TrainingJobResult> object, which contains the cancellation status, and the operation-location header can be used to track the cancellation process.
