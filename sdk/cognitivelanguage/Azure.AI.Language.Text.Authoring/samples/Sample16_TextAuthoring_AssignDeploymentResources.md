# Assigning Deployment Resources Synchronously in Azure AI Language

This sample demonstrates how to assign deployment resources synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Assign Deployment Resources Synchronously

To assign deployment resources, call `AssignDeploymentResources` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the assignment status.

```C# Snippet:Sample16_TextAuthoring_AssignDeploymentResources
string projectName = "MyResourceProject";
TextAuthoringProject projectClient = client.GetProject(projectName);

var resourceMetadata = new TextAuthoringResourceMetadata(
    azureResourceId: "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account",
    customDomain: "my-custom-domain",
    region: "my-region"
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
