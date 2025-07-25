# Assigning Deployment Resources in Azure AI Language

This sample demonstrates how to assign deployment resources synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient using AAD Authentication

This operation is supported only via AAD authentication and requires the caller to be assigned the Cognitive Service Language Owner role for this assigned resource.

For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Assign Deployment Resources Synchronously

To assign deployment resources, call `AssignDeploymentResources` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the assignment status.

```C# Snippet:Sample16_TextAuthoring_AssignDeploymentResources
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

Operation operation = projectClient.AssignDeploymentResources(
    waitUntil: WaitUntil.Completed,
    details: assignDetails
);

Console.WriteLine($"Deployment resources assigned with status: {operation.GetRawResponse().Status}");
```

## Assign Deployment Resources Asynchronously

To assign deployment resources, call `AssignDeploymentResourcesAsync` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the assignment status.

```C# Snippet:Sample16_TextAuthoring_AssignDeploymentResourcesAsync
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

Operation operation = await projectClient.AssignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Completed,
    details: assignDetails
);

Console.WriteLine($"Deployment resources assigned with status: {operation.GetRawResponse().Status}");
```
