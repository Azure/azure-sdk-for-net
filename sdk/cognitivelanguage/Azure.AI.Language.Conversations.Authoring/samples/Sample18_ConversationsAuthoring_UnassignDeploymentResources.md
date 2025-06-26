# Unassigning Deployment Resources in Azure AI Language

This sample demonstrates how to unassign previously assigned resources from a project using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

To create a `ConversationAnalysisAuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:AnalyzeConversationAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
```

## Unassign Deployment Resources

To unassign deployment resources, call `UnassignDeploymentResources` on the `ConversationAuthoringProject` client. This detaches the project from the specified Cognitive Services resource.

```C# Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResources
// Set project name and create client for the project
string projectName = "EmailApp";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

// Define assigned resource ID to be unassigned
var assignedResourceIds = new List<string>
{
    "/subscriptions/b72743ec-8bb3-453f-83ad-a53e8a50712e/resourceGroups/language-sdk-rg/providers/Microsoft.CognitiveServices/accounts/sdk-test-02"
};

// Build the unassignment details
var unassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(assignedResourceIds);

// Start the operation
Operation operation = projectClient.UnassignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: unassignDetails
);

Console.WriteLine($"UnassignDeploymentResources initiated. Status: {operation.GetRawResponse().Status}");

// Print jobId from Operation-Location
if (operation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location))
{
    string jobId = new Uri(location).Segments.Last().Split('?')[0];
    Console.WriteLine($"Job ID: {jobId}");
}
else
{
    Console.WriteLine("Operation-Location header not found.");
}
```
