# Deleting a Deployment from Specific Resources in Azure AI Language

This sample demonstrates how to remove an existing deployment from one or more Azure resources using the synchronous and asynchronous APIs of the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## Delete Deployment from Resources

To delete a deployment from specific Azure resources, first retrieve a deployment-scoped client using `GetDeployment`, then call `DeleteDeploymentFromResources` with the set of resource IDs to remove.

```C# Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResources
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";

// Get the deployment-scoped client
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

// Define the Azure resource IDs from which the deployment should be deleted
var deleteBody = new ConversationAuthoringProjectResourceIds
{
    AzureResourceIds =
    {
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
    }
};

// Begin delete operation
Operation operation =
    deploymentClient.DeleteDeploymentFromResources(WaitUntil.Started, deleteBody);

// Wait for completion
operation.WaitForCompletionResponse();

Console.WriteLine("Deployment delete-from-resources operation completed.");
```

## Delete Deployment from Resources Async

To delete a deployment from resources asynchronously, use `DeleteDeploymentFromResourcesAsync`.

```C# Snippet:Sample22_ConversationsAuthoring_DeleteDeploymentFromResourcesAsync
string projectName = "{projectName}";
string deploymentName = "{deploymentName}";

// Get the deployment-scoped client
ConversationAuthoringDeployment deploymentClient = client.GetDeployment(projectName, deploymentName);

// Define the Azure resource IDs from which the deployment should be deleted
var deleteBody = new ConversationAuthoringProjectResourceIds
{
    AzureResourceIds =
    {
        "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.CognitiveServices/accounts/{accountName}"
    }
};

// Begin the delete operation
Operation operation =
    await deploymentClient.DeleteDeploymentFromResourcesAsync(
        WaitUntil.Started,
        deleteBody);

// Wait for completion
await operation.WaitForCompletionResponseAsync();

Console.WriteLine("Deployment delete-from-resources async operation completed.");
```
