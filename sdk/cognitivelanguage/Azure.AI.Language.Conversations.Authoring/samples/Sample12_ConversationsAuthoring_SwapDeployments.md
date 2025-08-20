# Swapping Deployments in Azure AI Language

This sample demonstrates how to swap two deployments using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Swap Deployments

To swap two deployments, call SwapDeployments on the `ConversationAuthoringDeployment` client. Swapping deployments allows you to interchange the roles of two deployment environments (e.g., production and staging) to facilitate smooth transitions and testing in production-like environments.

```C# Snippet:Sample14_ConversationsAuthoring_SwapDeployments
string projectName = "SampleProject";
string deploymentName1 = "deployment1";
string deploymentName2 = "deployment2";
ConversationAuthoringSwapDeploymentsDetails swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);
ConversationAuthoringProject projectClient = client.GetProject(projectName);
Operation operation = projectClient.SwapDeployments(
    waitUntil: WaitUntil.Completed,
    details: swapDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Swap operation-location: {operationLocation}");
Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```
