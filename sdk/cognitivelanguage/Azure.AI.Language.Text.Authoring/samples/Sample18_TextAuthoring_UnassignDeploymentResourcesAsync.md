# Unassigning Deployment Resources Asynchronously in Azure AI Language

This sample demonstrates how to unassign deployment resources asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.

For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Unassign Deployment Resources Asynchronously

To unassign deployment resources, call `UnassignDeploymentResourcesAsync` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the unassignment status.

```C# Snippet:Sample18_TextAuthoring_UnassignDeploymentResourcesAsync
string projectName = "{projectName}";
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
