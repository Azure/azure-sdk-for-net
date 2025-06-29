# Unassigning Deployment Resources Synchronously in Azure AI Language

This sample demonstrates how to unassign deployment resources synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Unassign Deployment Resources Synchronously

To unassign deployment resources, call `UnassignDeploymentResources` on the `TextAuthoringProject` client. The method returns an `Operation` object containing the unassignment status.

```C# Snippet:Sample18_TextAuthoring_UnassignDeploymentResources
string projectName = "MyResourceProject";
TextAuthoringProject projectClient = client.GetProject(projectName);

var unassignDetails = new TextAuthoringUnassignDeploymentResourcesDetails(
    new List<string>
    {
        "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/my-resource-group/providers/Microsoft.CognitiveServices/accounts/my-cognitive-account"
    }
);

Operation operation = projectClient.UnassignDeploymentResources(
    waitUntil: WaitUntil.Completed,
    details: unassignDetails
);

Console.WriteLine($"Unassign operation completed with status: {operation.GetRawResponse().Status}");
```
