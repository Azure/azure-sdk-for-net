# Swapping Deployments Asynchronously in Azure AI Language

This sample demonstrates how to asynchronously swap two deployments using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```c# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your-api-key");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
ConversationalAnalysisAuthoring authoringClient = client.GetConversationalAnalysisAuthoringClient();
```

## Swap Deployments Asynchronously

To swap two deployments asynchronously, call SwapDeploymentsAsync on the ConversationalAnalysisAuthoring client.

```c#
string projectName = "SampleProject";
var swapConfig = new SwapDeploymentsConfig("production", "staging");

Operation operation = await authoringClient.SwapDeploymentsAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: swapConfig
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
Console.WriteLine($"Swap operation-location: {operationLocation}");
Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

Asynchronously swapping deployments allows for a seamless interchange of roles between deployment environments (e.g., production and staging), enabling smooth transitions and minimizing downtime during deployment updates.
