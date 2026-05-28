# Assigning Deployment Resources in Azure AI Language

This sample demonstrates how to assign resources to a project using the synchronous API of the `Azure.AI.Language.Conversations.Authoring` SDK.
It uses Azure Active Directory (Microsoft Entra ID) authentication via `DefaultAzureCredential`, which is required for resource assignment and unassignment operations.

## Create a `ConversationAnalysisAuthoringClient` using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Assign Deployment Resources

To assign deployment resources, call `AssignDeploymentResources` on the `ConversationAuthoringProject` client. This operation links the project to the specified Cognitive Services resource.

```C# Snippet:Sample16_ConversationsAuthoring_AssignDeploymentResources
// Arrange
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = client.GetProject(sampleProjectName);

var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
    customDomain: "{customDomain}",
    region: "{region}"
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

## Assign Deployment Resources Async

To assign deployment resources asynchronously, call `AssignDeploymentResourcesAsync` on the `ConversationAuthoringProject` client. This operation links the project to the specified Cognitive Services resource.

```C# Snippet:Sample16_ConversationsAuthoring_AssignDeploymentResourcesAsync
// Arrange
string sampleProjectName = "{projectName}";
ConversationAuthoringProject sampleProjectClient = client.GetProject(sampleProjectName);

var sampleResourceMetadata = new ConversationAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
    customDomain: "{customDomain}",
    region: "{region}"
);

var sampleAssignDetails = new ConversationAuthoringAssignDeploymentResourcesDetails(
    new List<ConversationAuthoringResourceMetadata> { sampleResourceMetadata }
);

// Act
Operation sampleOperation = await sampleProjectClient.AssignDeploymentResourcesAsync(
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
