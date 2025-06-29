# Checking the Status of Unassign Deployment Resources Operation in Azure AI Language

This sample demonstrates how to retrieve the status of a previously initiated Unassign Deployment Resources operation using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

To create a `ConversationAnalysisAuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:AnalyzeConversationAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
```

## Get the Status of an Unassign Deployment Resources Job

To check the status of an unassign operation, call `GetUnassignDeploymentResourcesStatus` on the `ConversationAuthoringProject` client, passing the `jobId` you obtained from the `Operation-Location` header after starting the unassign operation.

```C# Snippet:Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatus
string sampleProjectName = "SampleProject";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Define assigned resource ID to be unassigned
var sampleAssignedResourceIds = new List<string>
{
    "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group/providers/Microsoft.CognitiveServices/accounts/sample-account"
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
