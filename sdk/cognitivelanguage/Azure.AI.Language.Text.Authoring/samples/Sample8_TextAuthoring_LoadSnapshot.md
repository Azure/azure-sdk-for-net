# Loading a Snapshot Synchronously in Azure AI Language

This sample demonstrates how to load a snapshot synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

## Load a Snapshot Synchronously

To load a snapshot, call LoadSnapshot on the TextAnalysisAuthoring client.

```C# Snippet:Sample8_TextAuthoring_LoadSnapshot
string projectName = "LoanAgreements";
string trainedModelLabel = "ModelLabel"; // Replace with your actual model label.

Operation operation = authoringClient.LoadSnapshot(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    trainedModelLabel: trainedModelLabel
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Snapshot loading completed with status: {operation.GetRawResponse().Status}");
```

To load a snapshot, the LoadSnapshot method sends a request with the project name and trained model label. The method returns an Operation object indicating the status of the snapshot loading.
