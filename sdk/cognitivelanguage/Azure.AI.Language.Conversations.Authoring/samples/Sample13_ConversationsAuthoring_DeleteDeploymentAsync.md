# Deleting a Deployment Asynchronously in Azure AI Language

This sample demonstrates how to delete a deployment asynchronously in a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Delete a Deployment Asynchronously

To delete a deployment, call DeleteDeploymentAsync on the `ConversationAuthoringDeployment` client. Deleting a deployment asynchronously allows for non-blocking operations and ensures resources associated with the deployment are released efficiently.

```C# Snippet:Sample13_ConversationsAuthoring_DeleteDeploymentAsync
string projectName = "SampleProject";
string deploymentName = "SampleDeployment";
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = await deploymentClient.DeleteDeploymentAsync(
    waitUntil: WaitUntil.Completed
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```
