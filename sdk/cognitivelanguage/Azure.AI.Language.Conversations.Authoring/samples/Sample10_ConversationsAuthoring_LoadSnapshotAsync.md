# Loading a Snapshot Asynchronously in Azure AI Language

This sample demonstrates how to load a snapshot for a trained model asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Load a Snapshot Asynchronously

To load a snapshot for a specific trained model, call LoadSnapshotAsync on the `ConversationAuthoringTrainedModel` client. This method initiates the snapshot loading process and provides an operation response that includes the status and metadata about the operation.

```C# Snippet:Sample10_ConversationsAuthoring_LoadSnapshotAsync
string projectName = "SampleProject";
string trainedModelLabel = "SampleModel";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Operation operation = await trainedModelClient.LoadSnapshotAsync(
    waitUntil: WaitUntil.Completed);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Snapshot loaded with operation status: {operation.GetRawResponse().Status}");
```
