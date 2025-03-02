# Deploying a Project Asynchronously in Azure AI Language

This sample demonstrates how to deploy a project asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = TestEnvironment.Endpoint;
AzureKeyCredential credential = new(TestEnvironment.ApiKey);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
```

## Deploy a Project Asynchronously

To deploy a project asynchronously, call `DeployProjectAsync` on the `ConversationAuthoringDeployment` client. This ensures that the trained model is deployed and available for use without blocking execution.

```C# Sample14_ConversationsAuthoring_DeployProjectAsync
string projectName = "Test-data-labels";
var deploymentName = "staging";

ConversationAuthoringDeployment deploymentAuthoringClient = client.GetDeployment(projectName, deploymentName);

CreateDeploymentDetails trainedModeDetails = new CreateDeploymentDetails("m1");

Operation operation = await deploymentAuthoringClient.DeployProjectAsync(
    waitUntil: WaitUntil.Completed,
    trainedModeDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
Console.WriteLine($"Deploy operation-location: {operationLocation}");
Console.WriteLine($"Deploy operation completed with status: {operation.GetRawResponse().Status}");
```
