# Unassigning Deployment Resources in Azure AI Language

This sample demonstrates how to unassign deployment resources synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.

For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Unassign Deployment Resources Synchronously

To unassign deployment resources, call `UnassignDeploymentResources` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the unassignment status.

```C# Snippet:Sample18_TextAuthoring_UnassignDeploymentResources
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new List<string>
    {
        "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    }
);

Operation operation = projectClient.UnassignDeploymentResources(
    waitUntil: WaitUntil.Completed,
    details: unassignDetails
);

Console.WriteLine($"Unassign operation completed with status: {operation.GetRawResponse().Status}");
```

## Unassign Deployment Resources Asynchronously

To unassign deployment resources, call `UnassignDeploymentResourcesAsync` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the unassignment status.

```C# Snippet:Sample18_TextAuthoring_UnassignDeploymentResourcesAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new List<string>
    {
        "/subscriptions/{subscription}/resourceGroups/{resourcegroup}/providers/Microsoft.CognitiveServices/accounts/{sampleAccount}"
    }
);

Operation operation = await projectClient.UnassignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Completed,
    details: unassignDetails
);

Console.WriteLine($"Unassign operation completed with status: {operation.GetRawResponse().Status}");
```
