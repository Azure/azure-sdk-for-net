# Retrieving Deployment Resources Assignment Status in Azure AI Language

This sample demonstrates how to retrieve the status of deployment resources assignment synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.

For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Retrieve Deployment Resources Assignment Status Synchronously

To retrieve the status of deployment resources assignment, call `GetAssignDeploymentResourcesStatus` on the `TextAuthoringProject` client. The method returns a `Response<TextAuthoringDeploymentResourcesState>` containing the assignment status.

```C# Snippet:Sample17_TextAuthoring_GetAssignDeploymentResourcesStatus
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var resourceMetadata = new TextAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
    customDomain: "{customDomain}",
    region: "{Region}"
);

var assignDetails = new TextAuthoringAssignDeploymentResourcesDetails(
    new List<TextAuthoringResourceMetadata> { resourceMetadata }
);

// Submit assignment operation
Operation assignOperation = projectClient.AssignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: assignDetails
);

string operationLocation = assignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

// Extract only the jobId part from the URL
string jobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Job ID: {jobId}");

// Call status API
Response<TextAuthoringDeploymentResourcesState> statusResponse = projectClient.GetAssignDeploymentResourcesStatus(jobId);

Console.WriteLine($"Deployment assignment status: {statusResponse.Value.Status}");
```

## Retrieve Deployment Resources Assignment Status Asynchronously

To retrieve the status of deployment resources assignment, call `GetAssignDeploymentResourcesStatusAsync` on the `TextAuthoringProject` client. The method returns a `Response<TextAuthoringDeploymentResourcesState>` containing the assignment status.

```C# Snippet:Sample17_TextAuthoring_GetAssignDeploymentResourcesStatusAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var resourceMetadata = new TextAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}",
    customDomain: "{customDomain}",
    region: "{Region}"
);

var assignDetails = new TextAuthoringAssignDeploymentResourcesDetails(
    new List<TextAuthoringResourceMetadata> { resourceMetadata }
);

// Submit assignment operation
Operation assignOperation = await projectClient.AssignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: assignDetails
);

string operationLocation = assignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

// Extract only the jobId part from the URL
string jobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Job ID: {jobId}");

// Call status API
Response<TextAuthoringDeploymentResourcesState> statusResponse = await projectClient.GetAssignDeploymentResourcesStatusAsync(jobId);

Console.WriteLine($"Deployment assignment status: {statusResponse.Value.Status}");
```
