# Swapping Deployments in Azure AI Language

This sample demonstrates how to swap two deployments using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

## Swap Deployments

To swap two deployments, call SwapDeployments on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample14_ConversationsAuthoring_SwapDeployments
Operation operation = authoringClient.SwapDeployments(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: swapDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
Console.WriteLine($"Swap operation-location: {operationLocation}");
Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```

Swapping deployments allows you to interchange the roles of two deployment environments (e.g., production and staging) to facilitate smooth transitions and testing in production-like environments.
