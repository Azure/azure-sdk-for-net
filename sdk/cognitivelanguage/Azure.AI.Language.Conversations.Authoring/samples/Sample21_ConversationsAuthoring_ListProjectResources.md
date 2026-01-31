# Listing Project Resources in Azure AI Language

This sample demonstrates how to retrieve the set of Azure resources assigned to a given project using the synchronous and asynchronous APIs of the `Azure.AI.Language.Conversations.Authoring` SDK.

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

## List Project Resources

To list all Azure resources assigned to a specific project, call `GetProjectResources` on the `ConversationAnalysisAuthoringClient`.

```C# Snippet:Sample21_ConversationsAuthoring_ListProjectResources
string projectName = "{projectName}";

// Retrieve resources assigned to this project
Pageable<ConversationAuthoringAssignedProjectResource> pageable =
    client.GetProjectResources(projectName);

foreach (ConversationAuthoringAssignedProjectResource resource in pageable)
{
    Console.WriteLine($"Resource ID: {resource.ResourceId}");
    Console.WriteLine($"Region: {resource.Region}");

    if (resource.AssignedAoaiResource != null)
    {
        Console.WriteLine($"AOAI Kind: {resource.AssignedAoaiResource.Kind}");
        Console.WriteLine($"AOAI Resource ID: {resource.AssignedAoaiResource.ResourceId}");
        Console.WriteLine($"AOAI Deployment Name: {resource.AssignedAoaiResource.DeploymentName}");
    }

    Console.WriteLine();
}
```

## List Project Resources Async

To list project resources asynchronously, call `GetProjectResourcesAsync`.

```C# Snippet:Sample21_ConversationsAuthoring_ListProjectResourcesAsync
string projectName = "{projectName}";

// Retrieve resources assigned to this project (async)
AsyncPageable<ConversationAuthoringAssignedProjectResource> pageable =
    client.GetProjectResourcesAsync(projectName);

await foreach (ConversationAuthoringAssignedProjectResource resource in pageable)
{
    Console.WriteLine($"Resource ID: {resource.ResourceId}");
    Console.WriteLine($"Region: {resource.Region}");

    if (resource.AssignedAoaiResource != null)
    {
        Console.WriteLine($"AOAI Kind: {resource.AssignedAoaiResource.Kind}");
        Console.WriteLine($"AOAI Resource ID: {resource.AssignedAoaiResource.ResourceId}");
        Console.WriteLine($"AOAI Deployment Name: {resource.AssignedAoaiResource.DeploymentName}");
    }

    Console.WriteLine();
}
```
