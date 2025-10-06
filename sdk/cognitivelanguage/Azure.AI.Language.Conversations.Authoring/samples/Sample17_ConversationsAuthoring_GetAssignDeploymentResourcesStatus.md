# Retrieving Deployment Assignment Status in Azure AI Language

This sample demonstrates how to retrieve the status of a deployment assignment operation using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Get Deployment Assignment Status

To retrieve the status of a deployment assignment operation, call `GetAssignDeploymentResourcesStatus` on the `ConversationAuthoringProject` client. This allows you to monitor the progress and outcome of the operation.

```C# Snippet:Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatus
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
    customDomain: "{customDomain}",
    region: "{region}"
);

var sampleAssignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
    new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
);

// Submit assignment operation
Operation sampleAssignOperation = sampleProjectClient.AssignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: sampleAssignDetails
);

string sampleOperationLocation = sampleAssignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

// Extract only the jobId part from the URL
string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Job ID: {sampleJobId}");

// Call status API
Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse = sampleProjectClient.GetAssignDeploymentResourcesStatus(sampleJobId);

Console.WriteLine($"Deployment assignment status: {sampleStatusResponse.Value.Status}");
```

## Get Deployment Assignment Status Async

To retrieve the status of a deployment assignment operation asynchronously, call `GetAssignDeploymentResourcesStatusAsync` on the `ConversationAuthoringProject` client. This allows you to monitor the progress and outcome of the operation.

```C# Snippet:Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatusAsync
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

// Build resource metadata
var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
    customDomain: "{customDomain}",
    region: "{region}"
);

var sampleAssignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
    new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
);

// Submit assignment operation
Operation sampleAssignOperation = await sampleProjectClient.AssignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: sampleAssignDetails
);

string sampleOperationLocation = sampleAssignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

// Extract only the jobId part from the URL
string sampleJobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Job ID: {sampleJobId}");

// Call status API
Response<ConversationAuthoringDeploymentResourcesState> sampleStatusResponse = await sampleProjectClient.GetAssignDeploymentResourcesStatusAsync(sampleJobId);

Assert.IsNotNull(sampleStatusResponse);
Console.WriteLine($"Deployment assignment status: {sampleStatusResponse.Value.Status}");
```
