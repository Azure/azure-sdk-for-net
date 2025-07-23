# Loading a Snapshot in Azure AI Language

This sample demonstrates how to load a snapshot synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Load a Snapshot Synchronously

To load a snapshot, call LoadSnapshot on the TextAnalysisAuthoring client.

```C# Snippet:Sample10_TextAuthoring_LoadSnapshot
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}";
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Operation operation = trainedModelClient.LoadSnapshot(
    waitUntil: WaitUntil.Completed
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
```

To load a snapshot, the LoadSnapshot method sends a request with the project name and trained model label. The method returns an Operation object indicating the status of the snapshot loading.

## Load a Snapshot Asynchronously

To load a snapshot, call LoadSnapshotAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample10_TextAuthoring_LoadSnapshotAsync
string projectName = "{projectName}";
string trainedModelLabel = "{modelLabel}"; // Replace with your actual model label.
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Operation operation = await trainedModelClient.LoadSnapshotAsync(
    waitUntil: WaitUntil.Completed
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
```

To load a snapshot, the LoadSnapshotAsync method sends a request with the project name and trained model label. The method returns an Operation object indicating the status of the snapshot loading.
