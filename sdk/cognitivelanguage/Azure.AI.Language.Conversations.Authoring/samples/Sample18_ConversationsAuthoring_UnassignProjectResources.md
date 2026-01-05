# Unassigning Project Resources in Azure AI Language

This sample demonstrates how to unassign previously assigned resources from a project using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Unassign Project Resources

To unassign project resources, call `UnassignProjectResources` on the `ConversationAuthoringProject` client. This detaches the project from the specified Cognitive Services resource.

```C# Snippet:Sample18_ConversationsAuthoring_UnassignProjectResources
// Set project name and create client for the project
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleUnassignIds = new ConversationAuthoringProjectResourceIds
{
    AzureResourceIds =
    {
        "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    }
};

// Start the operation
Operation sampleOperation = sampleProjectClient.UnassignProjectResources(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignIds
);

Console.WriteLine($"UnassignProjectResources initiated. Status: {sampleOperation.GetRawResponse().Status}");

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

## Unassign Project Resources Async

To unassign project resources asynchronously, call `UnassignProjectResourcesAsync` on the `ConversationAuthoringProject` client. This detaches the project from the specified Cognitive Services resource asynchronously.

```C# Snippet:Sample18_ConversationsAuthoring_UnassignProjectResourcesAsync
// Set project name and create client for the project
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleUnassignIds = new ConversationAuthoringProjectResourceIds
{
    AzureResourceIds =
    {
        "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    }
};

// Call the operation
Operation sampleOperation = await sampleProjectClient.UnassignProjectResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignIds
);

Console.WriteLine($"UnassignProjectResourcesAsync initiated. Status: {sampleOperation.GetRawResponse().Status}");

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
