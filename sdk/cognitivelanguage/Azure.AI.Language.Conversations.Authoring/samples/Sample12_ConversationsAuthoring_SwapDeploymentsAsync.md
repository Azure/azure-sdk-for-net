# Swapping Deployments Asynchronously in Azure AI Language

This sample demonstrates how to asynchronously swap two deployments using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Swap Deployments Asynchronously

To swap two deployments asynchronously, call SwapDeploymentsAsync on the `ConversationAuthoringDeployment` client. Asynchronously swapping deployments allows for a seamless interchange of roles between deployment environments (e.g., production and staging), enabling smooth transitions and minimizing downtime during deployment updates.

```C# Snippet:Sample14_ConversationsAuthoring_SwapDeploymentsAsync
string projectName = "SampleProject";
string deploymentName1 = "deployment1";
string deploymentName2 = "deployment2";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

ConversationAuthoringSwapDeploymentsDetails swapDetails = new ConversationAuthoringSwapDeploymentsDetails(deploymentName1, deploymentName2);

Operation operation = await projectClient.SwapDeploymentsAsync(
    waitUntil: WaitUntil.Completed,
    details: swapDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Swap operation-location: {operationLocation}");
Console.WriteLine($"Swap operation completed with status: {operation.GetRawResponse().Status}");
```
