# Unassigning Deployment Resources in Azure AI Language

This sample demonstrates how to unassign previously assigned resources from a project using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Unassign Deployment Resources

To unassign deployment resources, call `UnassignDeploymentResources` on the `ConversationAuthoringProject` client. This detaches the project from the specified Cognitive Services resource.

```C# Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResources
// Set project name and create client for the project
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleAssignedResourceIds = new List<string>
{
    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
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

## Unassign Deployment Resources Async

To unassign deployment resources asynchronously, call `UnassignDeploymentResourcesAsync` on the `ConversationAuthoringProject` client. This detaches the project from the specified Cognitive Services resource asynchronously.

```C# Snippet:Sample18_ConversationsAuthoring_UnassignDeploymentResourcesAsync
// Set project name and create client for the project
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleAssignedResourceIds = new List<string>
{
    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
};

// Build the unassignment details
var sampleUnassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(sampleAssignedResourceIds);

// Call the operation
Operation sampleOperation = await sampleProjectClient.UnassignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignDetails
);

Console.WriteLine($"UnassignDeploymentResourcesAsync initiated. Status: {sampleOperation.GetRawResponse().Status}");

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
