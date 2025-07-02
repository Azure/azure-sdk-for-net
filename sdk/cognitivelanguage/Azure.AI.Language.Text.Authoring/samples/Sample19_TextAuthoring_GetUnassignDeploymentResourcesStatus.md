# Retrieving Deployment Resources Unassignment Status Synchronously in Azure AI Language

This sample demonstrates how to retrieve the status of deployment resources unassignment synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient` using AAD Authentication

To create a `AuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:TextAnalysisAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");;
DefaultAzureCredential credential = new DefaultAzureCredential();
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);
```

## Retrieve Deployment Resources Unassignment Status Synchronously

To retrieve the status of deployment resources unassignment, call `GetUnassignDeploymentResourcesStatus` on the `TextAuthoringProject` client. The method returns a `Response<TextAuthoringDeploymentResourcesState>` containing the unassignment status.

```C# Snippet:Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatus
string projectName = "MyResourceProject";
TextAuthoringProject projectClient = client.GetProject(projectName);

// Prepare the details for unassigning resources
var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new[]
    {
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account"
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
