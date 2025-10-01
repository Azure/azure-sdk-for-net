# Checking the Status of Unassign Deployment Resources Operation in Azure AI Language

This sample demonstrates how to retrieve the status of a previously initiated Unassign Deployment Resources operation using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Get the Status of an Unassign Deployment Resources Job

To check the status of an unassign operation, call `GetUnassignDeploymentResourcesStatus` on the `ConversationAuthoringProject` client, passing the `jobId` you obtained from the `Operation-Location` header after starting the unassign operation.

```C# Snippet:Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatus
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleAssignedResourceIds = new List<string>
{
    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
};

// Build the unassignment details
var sampleUnassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(sampleAssignedResourceIds);

// Start the unassign operation
Operation sampleUnassignOperation = sampleProjectClient.UnassignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignDetails
);

Console.WriteLine($"UnassignDeploymentResources initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

// Extract jobId from Operation-Location
string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
    ? new Uri(location).Segments.Last().Split('?')[0]
    : throw new InvalidOperationException("Operation-Location header not found.");

Console.WriteLine($"Job ID: {sampleJobId}");

// Call the API to get unassign job status
Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse =
    sampleProjectClient.GetUnassignDeploymentResourcesStatus(sampleJobId);

Console.WriteLine($"Job Status: {sampleStatusResponse.Value.Status}");

if (sampleStatusResponse.Value.Errors != null && sampleStatusResponse.Value.Errors.Any())
{
    Console.WriteLine("Errors:");
    foreach (var sampleError in sampleStatusResponse.Value.Errors)
    {
        Console.WriteLine($"- Code: {sampleError.Code}, Message: {sampleError.Message}");
    }
}
```

## Get the Status of an Unassign Deployment Resources Job Async

To check the status of an unassign operation asynchronously, call `GetUnassignDeploymentResourcesStatusAsync` on the `ConversationAuthoringProject` client, passing the `jobId` you obtained from the `Operation-Location` header after starting the unassign operation.

```C# Snippet:Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatusAsync
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleAssignedResourceIds = new List<string>
{
    "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
};

// Build the unassignment details
var sampleUnassignDetails = new ConversationAuthoringUnassignDeploymentResourcesDetails(sampleAssignedResourceIds);

// Start the unassign operation
Operation sampleUnassignOperation = await sampleProjectClient.UnassignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignDetails
);

Console.WriteLine($"UnassignDeploymentResourcesAsync initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

// Extract jobId from Operation-Location
string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
    ? new Uri(location).Segments.Last().Split('?')[0]
    : throw new InvalidOperationException("Operation-Location header not found.");

Console.WriteLine($"Job ID: {sampleJobId}");

// Call the API to get unassign job status
Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse =
    await sampleProjectClient.GetUnassignDeploymentResourcesStatusAsync(sampleJobId);

Console.WriteLine($"Job Status: {sampleStatusResponse.Value.Status}");

if (sampleStatusResponse.Value.Errors != null && sampleStatusResponse.Value.Errors.Any())
{
    Console.WriteLine("Errors:");
    foreach (var sampleError in sampleStatusResponse.Value.Errors)
    {
        Console.WriteLine($"- Code: {sampleError.Code}, Message: {sampleError.Message}");
    }
}
```
