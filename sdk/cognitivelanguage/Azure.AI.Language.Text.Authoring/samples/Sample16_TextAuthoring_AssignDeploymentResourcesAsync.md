# Assigning Deployment Resources Asynchronously in Azure AI Language

This sample demonstrates how to assign deployment resources asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient` using AAD Authentication

To create a `AuthoringClient`, use the service endpoint of a custom subdomain Language resource and authenticate with `DefaultAzureCredential`.

```C# Snippet:TextAnalysisAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);
```

## Assign Deployment Resources Asynchronously

To assign deployment resources, call `AssignDeploymentResourcesAsync` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the assignment status.

```C# Snippet:Sample16_TextAuthoring_AssignDeploymentResourcesAsync
string projectName = "MyResourceProjectAsync";
TextAuthoringProject projectClient = client.GetProject(projectName);

var resourceMetadata = new TextAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account",
    customDomain: "my-custom-domain",
    region: "my-region"
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
