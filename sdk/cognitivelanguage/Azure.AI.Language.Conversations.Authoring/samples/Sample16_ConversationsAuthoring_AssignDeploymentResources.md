# Assigning Deployment Resources in Azure AI Language

This sample demonstrates how to assign resources to a project using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

To create a `ConversationAnalysisAuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:AnalyzeConversationAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
```

## Assign Deployment Resources

To assign deployment resources, call `AssignDeploymentResources` on the `ConversationAuthoringProject` client. This operation links the project to the specified Cognitive Services resource.

```C# Snippet:Sample16_ConversationsAuthoring_AssignDeploymentResources
// Arrange
string sampleProjectName = "SampleProject";
ConversationAuthoringProject sampleProjectClient = client.GetProject(sampleProjectName);

var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/sample-subscription/resourceGroups/sample-rg/providers/Microsoft.CognitiveServices/accounts/sample-account",
    customDomain: "sample-domain",
    region: "sample-region"
);

var sampleAssignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
    new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
);

// Act
Operation sampleOperation = sampleProjectClient.AssignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: sampleAssignDetails
);

// Output operation details
Console.WriteLine("Operation started successfully.");
Console.WriteLine($"Operation Status: {sampleOperation.GetRawResponse().Status}");

// Extract and print jobId from Operation-Location header
string sampleOperationLocation = sampleOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out string location)
    ? location
    : null;

if (!string.IsNullOrEmpty(sampleOperationLocation))
{
    string sampleJobId = new Uri(sampleOperationLocation).Segments.Last().Split('?')[0];
    Console.WriteLine($"Operation-Location: {sampleOperationLocation}");
    Console.WriteLine($"Job ID: {sampleJobId}");
}
else
{
    Console.WriteLine("Operation-Location header is null or empty.");
}
```
