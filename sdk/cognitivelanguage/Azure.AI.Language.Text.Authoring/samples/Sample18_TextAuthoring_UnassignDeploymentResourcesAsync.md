# Unassigning Deployment Resources Asynchronously in Azure AI Language

This sample demonstrates how to unassign deployment resources asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient` using AAD Authentication

To create a `AuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:TextAnalysisAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");;
DefaultAzureCredential credential = new DefaultAzureCredential();
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);
```

## Unassign Deployment Resources Asynchronously

To unassign deployment resources, call `UnassignDeploymentResourcesAsync` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the unassignment status.

```C# Snippet:Sample18_TextAuthoring_UnassignDeploymentResourcesAsync
string projectName = "MyResourceProjectAsync";
TextAuthoringProject projectClient = client.GetProject(projectName);

var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new List<string>
    {
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account"
    }
);

Operation operation = await projectClient.UnassignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Completed,
    details: unassignDetails
);

Console.WriteLine($"Unassign operation completed with status: {operation.GetRawResponse().Status}");
```
