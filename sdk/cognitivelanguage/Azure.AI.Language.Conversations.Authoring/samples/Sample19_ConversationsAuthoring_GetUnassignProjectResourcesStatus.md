# Checking the Status of Unassign Project Resources Operation in Azure AI Language

This sample demonstrates how to retrieve the status of a previously initiated Unassign Project Resources operation using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Get the Status of an Unassign Project Resources Job

To check the status of an unassign operation, call `GetUnassignProjectResourcesStatus` on the `ConversationAuthoringProject` client, passing the `jobId` you obtained from the `Operation-Location` header after starting the unassign operation.

```C# Snippet:Sample19_ConversationsAuthoring_GetUnassignProjectResourcesStatus
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

// Start the unassign operation
Operation sampleUnassignOperation = sampleProjectClient.UnassignProjectResources(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignIds
);

Console.WriteLine($"UnassignProjectResources initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

// Extract jobId from Operation-Location
string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
    ? new Uri(location).Segments.Last().Split('?')[0]
    : throw new InvalidOperationException("Operation-Location header not found.");

Console.WriteLine($"Job ID: {sampleJobId}");

// Call the API to get unassign job status
Response<ConversationAuthoringProjectResourcesState> sampleStatusResponse =
    sampleProjectClient.GetUnassignProjectResourcesStatus(sampleJobId);

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

## Get the Status of an Unassign Project Resources Job Async

To check the status of an unassign operation asynchronously, call `GetUnassignProjectResourcesStatusAsync` on the `ConversationAuthoringProject` client, passing the `jobId` you obtained from the `Operation-Location` header after starting the unassign operation.

```C# Snippet:Sample19_ConversationsAuthoring_GetUnassignProjectResourcesStatusAsync
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

// Start the unassign operation
Operation sampleUnassignOperation = await sampleProjectClient.UnassignProjectResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: sampleUnassignIds
);

Console.WriteLine($"UnassignProjectResourcesAsync initiated. Status: {sampleUnassignOperation.GetRawResponse().Status}");

// Extract jobId from Operation-Location
string sampleJobId = sampleUnassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
    ? new Uri(location).Segments.Last().Split('?')[0]
    : throw new InvalidOperationException("Operation-Location header not found.");

Console.WriteLine($"Job ID: {sampleJobId}");

// Call the API to get unassign job status
Response<ConversationAuthoringProjectResourcesState> sampleStatusResponse =
    await sampleProjectClient.GetUnassignProjectResourcesStatusAsync(sampleJobId);

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
