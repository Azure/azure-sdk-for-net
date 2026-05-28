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

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Delete a Deployment

To delete a deployment, call DeleteDeployment on the `ConversationAuthoringDeployment` client. Deleting a deployment removes it from the specified project and ensures that resources associated with the deployment are released.

```C# Snippet:Sample13_ConversationsAuthoring_DeleteDeployment
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = deploymentClient.DeleteDeployment(
    waitUntil: WaitUntil.Completed
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```

## Delete a Deployment Async

To delete a deployment, call DeleteDeploymentAsync on the `ConversationAuthoringDeployment` client. Deleting a deployment asynchronously allows for non-blocking operations and ensures resources associated with the deployment are released efficiently.

```C# Snippet:Sample13_ConversationsAuthoring_DeleteDeploymentAsync
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

Operation operation = await deploymentClient.DeleteDeploymentAsync(
    waitUntil: WaitUntil.Completed
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```
