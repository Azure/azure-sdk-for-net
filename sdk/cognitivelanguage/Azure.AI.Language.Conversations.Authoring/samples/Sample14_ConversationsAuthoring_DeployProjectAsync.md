# Deploying a Project Asynchronously in Azure AI Language

This sample demonstrates how to deploy a project asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Deploy a Project Asynchronously

To deploy a project asynchronously, call `DeployProjectAsync` on the `ConversationAuthoringDeployment` client. This ensures that the trained model is deployed and available for use without blocking execution.

```C# Snippet:Sample14_ConversationsAuthoring_DeployProjectAsync
string projectName = "Test-data-labels";
string deploymentName = "staging";

ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

ConversationAuthoringCreateDeploymentDetails trainedModeDetails = new ConversationAuthoringCreateDeploymentDetails("m1");

Operation operation = await deploymentClient.DeployProjectAsync(
    waitUntil: WaitUntil.Completed,
    trainedModeDetails
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```
