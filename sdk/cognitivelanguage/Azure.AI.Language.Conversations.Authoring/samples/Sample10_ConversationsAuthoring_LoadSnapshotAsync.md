# Loading a Snapshot Asynchronously in Azure AI Language

This sample demonstrates how to load a snapshot for a trained model asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AnalyzeConversationClient`

To create an `AnalyzeConversationClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AnalyzeConversationClientOptions` instance.

```C# Snippet:CreateAnalyzeConversationClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AnalyzeConversationClientOptions options = new AnalyzeConversationClientOptions(AnalyzeConversationClientOptions.ServiceVersion.V2024_11_15_Preview);
AnalyzeConversationClient client = new AnalyzeConversationClient(endpoint, credential, options);
AnalyzeConversationAuthoring AnalyzeConversationClient = client.GetAnalyzeConversationAnalyzeConversationClient();
```

## Load a Snapshot Asynchronously

To load a snapshot for a specific trained model, call LoadSnapshotAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample10_ConversationsAuthoring_LoadSnapshotAsync
Operation operation = await AnalyzeConversationClient.LoadSnapshotAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Snapshot loaded with operation status: {operation.GetRawResponse().Status}");
```

To load a snapshot asynchronously, call LoadSnapshotAsync on the AnalyzeConversationAuthoring client. This method initiates the snapshot loading process and provides an operation response that includes the status and metadata about the operation.
