# Retrieving Deployment Resources Unassignment Status in Azure AI Language

This sample demonstrates how to retrieve the status of deployment resources unassignment synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.

For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Retrieve Deployment Resources Unassignment Status Synchronously

To retrieve the status of deployment resources unassignment, call `GetUnassignDeploymentResourcesStatus` on the `TextAuthoringProject` client. The method returns a `Response<TextAuthoringDeploymentResourcesState>` containing the unassignment status.

```C# Snippet:Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatus
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

// Prepare the details for unassigning resources
var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new[]
    {
        "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    }
);

// Submit the unassign operation and get the job ID
Operation unassignOperation = projectClient.UnassignDeploymentResources(
    waitUntil: WaitUntil.Started,
    details: unassignDetails
);

string operationLocation = unassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

string jobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Unassign Job ID: {jobId}");

// Call the API to get unassign job status
Response<TextAuthoringDeploymentResourcesState> response =
    projectClient.GetUnassignDeploymentResourcesStatus(jobId);

Console.WriteLine($"Job Status: {response.Value.Status}");

if (response.Value.Errors != null && response.Value.Errors.Any())
{
    Console.WriteLine("Errors:");
    foreach (var error in response.Value.Errors)
    {
        Console.WriteLine($"- Code: {error.Code}, Message: {error.Message}");
    }
}
```

## Retrieve Deployment Resources Unassignment Status Asynchronously

To retrieve the status of deployment resources unassignment, call `GetUnassignDeploymentResourcesStatusAsync` on the `TextAuthoringProject` client. The method returns a `Response<TextAuthoringDeploymentResourcesState>` containing the unassignment status.

```C# Snippet:Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatusAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

// Prepare the details for unassigning resources
var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new[]
    {
        "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    }
);

// Submit the unassign operation and get the job ID
Operation unassignOperation = await projectClient.UnassignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: unassignDetails
);

string operationLocation = unassignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

string jobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Unassign Job ID: {jobId}");

// Call the API to get unassign job status
Response<TextAuthoringDeploymentResourcesState> response =
    await projectClient.GetUnassignDeploymentResourcesStatusAsync(jobId);

Console.WriteLine($"Job Status: {response.Value.Status}");

if (response.Value.Errors != null && response.Value.Errors.Any())
{
    Console.WriteLine("Errors:");
    foreach (var error in response.Value.Errors)
    {
        Console.WriteLine($"- Code: {error.Code}, Message: {error.Message}");
    }
}
```
