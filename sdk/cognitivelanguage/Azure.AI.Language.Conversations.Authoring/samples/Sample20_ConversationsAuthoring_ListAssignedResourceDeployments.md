# Listing Deployments Assigned to Resources in Azure AI Language

This sample demonstrates how to list deployments that are assigned to Azure resources across your projects using the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## List Assigned Resource Deployments

To see which deployments are assigned to which resources across your projects, call `GetAssignedResourceDeployments` on the `ConversationAnalysisAuthoringClient`.
Each item in the result represents a project and the deployments associated with resources for that project.

```C# Snippet:Sample20_ConversationsAuthoring_ListAssignedResourceDeployments
// List all deployments assigned to resources across projects
Pageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
    client.GetAssignedResourceDeployments();

foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
{
    Console.WriteLine($"Project Name: {meta.ProjectName}");

    if (meta.DeploymentsMetadata != null)
    {
        foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
        {
            Console.WriteLine($"  Deployment Name: {deployment.DeploymentName}");
            Console.WriteLine($"  Last Deployed On: {deployment.LastDeployedOn}");
            Console.WriteLine($"  Deployment Expires On: {deployment.DeploymentExpiresOn}");
            Console.WriteLine();
        }
    }
}
```

## List Assigned Resource Deployments Async

To enumerate assigned resource deployments asynchronously, call `GetAssignedResourceDeploymentsAsync`.
This is useful when streaming results or when working with large numbers of projects or deployments.

```C# Snippet:Sample20_ConversationsAuthoring_ListAssignedResourceDeploymentsAsync
// List all deployments assigned to resources across projects (async)
AsyncPageable<ConversationAuthoringAssignedProjectDeploymentsMetadata> pageable =
    client.GetAssignedResourceDeploymentsAsync();

await foreach (ConversationAuthoringAssignedProjectDeploymentsMetadata meta in pageable)
{
    Console.WriteLine($"Project Name: {meta.ProjectName}");

    if (meta.DeploymentsMetadata != null)
    {
        foreach (ConversationAuthoringAssignedProjectDeploymentMetadata deployment in meta.DeploymentsMetadata)
        {
            Console.WriteLine($"  Deployment Name: {deployment.DeploymentName}");
            Console.WriteLine($"  Last Deployed On: {deployment.LastDeployedOn}");
            Console.WriteLine($"  Deployment Expires On: {deployment.DeploymentExpiresOn}");
            Console.WriteLine();
        }
    }
}
```
