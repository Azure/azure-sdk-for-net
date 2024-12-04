# Loading a Snapshot in Azure AI Language

This sample demonstrates how to load a snapshot for a trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

## Load a Snapshot

To load a snapshot for a specific trained model, call LoadSnapshot on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample10_ConversationsAuthoring_LoadSnapshot
Operation operation = authoringClient.LoadSnapshot(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Snapshot loaded with operation status: {operation.GetRawResponse().Status}");
```

To load a snapshot, call LoadSnapshot on the AnalyzeConversationAuthoring client. This method initiates the snapshot loading process and provides an operation response that includes the status and metadata about the operation.
