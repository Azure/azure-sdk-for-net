# Retrieving Delete-From-Resources Job Status for a Deployment in Azure AI Language

This sample demonstrates how to retrieve the status of a delete-from-resources operation for a deployment using the synchronous and asynchronous APIs of the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2025_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Get Delete-From-Resources Status

To check the status of a delete-from-resources operation, retrieve a deployment-scoped client with `GetDeployment`, then call `GetDeploymentDeleteFromResourcesStatus` with the corresponding job ID.

```C# Snippet:Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatus
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
string jobId = "{jobId}";

// Get the deployment-scoped client
ConversationAuthoringDeployment deploymentClient =
    client.GetDeployment(projectName, deploymentName);

// Retrieve the job status
Response<ConversationAuthoringDeploymentDeleteFromResourcesState> response =
    deploymentClient.GetDeploymentDeleteFromResourcesStatus(jobId);

ConversationAuthoringDeploymentDeleteFromResourcesState state = response.Value;

Console.WriteLine($"Job ID: {state.JobId}");
Console.WriteLine($"Status: {state.Status}");
Console.WriteLine($"Created On: {state.CreatedOn}");
Console.WriteLine($"Last Updated On: {state.LastUpdatedOn}");
Console.WriteLine($"Expires On: {state.ExpiresOn}");
```

## Get Delete-From-Resources Status Async

To retrieve job status asynchronously, call `GetDeploymentDeleteFromResourcesStatusAsync`.

```C# Snippet:Sample23_ConversationsAuthoring_GetDeploymentDeleteFromResourcesStatusAsync
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";
string jobId = "{jobId}";

// Get the deployment-scoped client
ConversationAuthoringDeployment deploymentClient =
    client.GetDeployment(projectName, deploymentName);

// Retrieve the job status asynchronously
Response<ConversationAuthoringDeploymentDeleteFromResourcesState> response =
    await deploymentClient.GetDeploymentDeleteFromResourcesStatusAsync(jobId);

ConversationAuthoringDeploymentDeleteFromResourcesState state = response.Value;

Console.WriteLine($"Job ID: {state.JobId}");
Console.WriteLine($"Status: {state.Status}");
Console.WriteLine($"Created On: {state.CreatedOn}");
Console.WriteLine($"Last Updated On: {state.LastUpdatedOn}");
Console.WriteLine($"Expires On: {state.ExpiresOn}");
```
