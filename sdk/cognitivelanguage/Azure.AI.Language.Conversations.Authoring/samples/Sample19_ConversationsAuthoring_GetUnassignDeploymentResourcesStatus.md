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
// Set project name and create client for the project
string projectName = "EmailApp";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

// Replace with your actual job ID retrieved from the unassign operation
string jobId = "your-job-id-here";

// Call the API to get unassign job status
Response<ConversationAuthoringDeploymentResourcesState> response =
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
