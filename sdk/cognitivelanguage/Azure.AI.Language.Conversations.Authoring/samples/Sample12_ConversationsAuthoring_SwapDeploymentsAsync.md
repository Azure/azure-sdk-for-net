# Swapping Deployments Asynchronously in Azure AI Language

This sample demonstrates how to asynchronously swap two deployments using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AnalyzeConversationClient`

To create an `AnalyzeConversationClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AnalyzeConversationClientOptions` instance.

```C# Snippet:CreateAnalyzeConversationClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AnalyzeConversationClientOptions options = new AnalyzeConversationClientOptions(AnalyzeConversationClientOptions.ServiceVersion.V2024_11_15_Preview);
AnalyzeConversationClient client = new AnalyzeConversationClient(endpoint, credential, options);
AnalyzeConversationAuthoring AnalyzeConversationClient = client.GetAnalyzeConversationAnalyzeConversationClient();
```

## Swap Deployments Asynchronously

To swap two deployments asynchronously, call SwapDeploymentsAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample14_ConversationsAuthoring_SwapDeploymentsAsync
Operation operation = await AnalyzeConversationClient.SwapDeploymentsAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: swapDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
Console.WriteLine($"Swap operation-location: {operationLocation}");
Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

Asynchronously swapping deployments allows for a seamless interchange of roles between deployment environments (e.g., production and staging), enabling smooth transitions and minimizing downtime during deployment updates.
