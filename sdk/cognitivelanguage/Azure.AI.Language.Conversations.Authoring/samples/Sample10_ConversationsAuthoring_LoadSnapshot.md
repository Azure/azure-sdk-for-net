# Loading a Snapshot in Azure AI Language

This sample demonstrates how to load a snapshot for a trained model using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Load a Snapshot

To load a snapshot for a specific trained model, call LoadSnapshot on the `ConversationAuthoringTrainedModel` client. This method initiates the snapshot loading process and provides an operation response that includes the status and metadata about the operation.

```C# Snippet:Sample10_ConversationsAuthoring_LoadSnapshot
string projectName = "{projectName}";
string trainedModelLabel = "{trainedModelLabel}";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Operation operation = trainedModelClient.LoadSnapshot(
    waitUntil: WaitUntil.Completed
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Snapshot loaded with operation status: {operation.GetRawResponse().Status}");
```

## Load a Snapshot Async

To load a snapshot for a specific trained model, call LoadSnapshotAsync on the `ConversationAuthoringTrainedModel` client. This method initiates the snapshot loading process and provides an operation response that includes the status and metadata about the operation.

```C# Snippet:Sample10_ConversationsAuthoring_LoadSnapshotAsync
string projectName = "{projectName}";
string trainedModelLabel = "{trainedModelLabel}";
ConversationAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Operation operation = await trainedModelClient.LoadSnapshotAsync(
    waitUntil: WaitUntil.Completed);

// Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Snapshot loaded with operation status: {operation.GetRawResponse().Status}");
```
