# Retrieving Deployment Assignment Status in Azure AI Language

This sample demonstrates how to retrieve the status of a deployment assignment operation using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

To create a `ConversationAnalysisAuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:AnalyzeConversationAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
```

## Get Deployment Assignment Status

To retrieve the status of a deployment assignment operation, call `GetAssignDeploymentResourcesStatus` on the `ConversationAuthoringProject` client. This allows you to monitor the progress and outcome of the operation.

```C# Snippet:Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatus
string sampleProjectName = "SampleProject";
ConversationAuthoringProject sampleProjectClient = sampleClient.GetProject(sampleProjectName);

var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/sample-resource-group/providers/Microsoft.CognitiveServices/accounts/sample-account",
    customDomain: "sample-domain",
    region: "sample-region"
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
