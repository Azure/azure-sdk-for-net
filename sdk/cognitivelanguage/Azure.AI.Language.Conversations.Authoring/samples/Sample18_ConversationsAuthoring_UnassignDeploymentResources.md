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
string sampleProjectName = "SampleProject";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleAssignedResourceIds = new List<string>
{
    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group/providers/Microsoft.CognitiveServices/accounts/sample-account"
};

// Build the unassignment details
var sampleUnassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(sampleAssignedResourceIds);

// Start the operation
Operation sampleOperation = sampleProjectClient.UnassignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignDetails
);

Console.WriteLine($"UnassignDeploymentResources initiated. Status: {sampleOperation.GetRawResponse().Status}");

// Print jobId from Operation-Location
if (sampleOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location))
{
    string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
    Console.WriteLine($"Job ID: {sampleJobId}");
}
else
{
    Console.WriteLine("Operation-Location header not found.");
}
```
