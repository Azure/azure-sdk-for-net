# Loading a Snapshot Synchronously in Azure AI Language

This sample demonstrates how to load a snapshot synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Load a Snapshot Synchronously

To load a snapshot, call LoadSnapshot on the TextAnalysisAuthoring client.

```C# Snippet:Sample10_TextAuthoring_LoadSnapshot
string projectName = "MySnapshotProject";
string trainedModelLabel = "model1";
TextAuthoringTrainedModel trainedModelClient = client.GetTrainedModel(projectName, trainedModelLabel);

Operation operation = trainedModelClient.LoadSnapshot(
    waitUntil: WaitUntil.Completed
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
```

To load a snapshot, the LoadSnapshot method sends a request with the project name and trained model label. The method returns an Operation object indicating the status of the snapshot loading.
