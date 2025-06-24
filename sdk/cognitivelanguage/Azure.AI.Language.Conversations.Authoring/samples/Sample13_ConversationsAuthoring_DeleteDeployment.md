# Deleting a Deployment in Azure AI Language

This sample demonstrates how to delete a deployment in a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

## Delete a Deployment

To delete a deployment, call DeleteDeployment on the `ConversationAuthoringDeployment` client. Deleting a deployment removes it from the specified project and ensures that resources associated with the deployment are released.

```C# Snippet:Sample13_ConversationsAuthoring_DeleteDeployment
string projectName = "SampleProject";
string deploymentName = "SampleDeployment";
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = deploymentClient.DeleteDeployment(
    waitUntil: WaitUntil.Completed
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```
