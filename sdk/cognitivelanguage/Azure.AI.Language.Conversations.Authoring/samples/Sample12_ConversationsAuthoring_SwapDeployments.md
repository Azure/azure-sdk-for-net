# Swapping Deployments in Azure AI Language

This sample demonstrates how to swap two deployments using the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## Swap Deployments

To swap two deployments, call SwapDeployments on the `ConversationAuthoringDeployment` client. Swapping deployments allows you to interchange the roles of two deployment environments (e.g., production and staging) to facilitate smooth transitions and testing in production-like environments.

```C# Snippet:Sample14_ConversationsAuthoring_SwapDeployments
string projectName = "{projectName}";
string deploymentName1 = "{deploymentName1}";
string deploymentName2 = "{deploymentName2}";
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

## Swap Deployments Async

To swap two deployments asynchronously, call SwapDeploymentsAsync on the `ConversationAuthoringDeployment` client. Asynchronously swapping deployments allows for a seamless interchange of roles between deployment environments (e.g., production and staging), enabling smooth transitions and minimizing downtime during deployment updates.

```C# Snippet:Sample14_ConversationsAuthoring_SwapDeploymentsAsync
string projectName = "{projectName}";
string deploymentName1 = "{deploymentName1}";
string deploymentName2 = "{deploymentName2}";
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
