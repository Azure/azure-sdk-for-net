# Retrieving Deployment Resources Assignment Status Asynchronously in Azure AI Language

This sample demonstrates how to retrieve the status of deployment resources assignment asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Retrieve Deployment Resources Assignment Status Asynchronously

To retrieve the status of deployment resources assignment, call `GetAssignDeploymentResourcesStatusAsync` on the `TextAuthoringProject` client. The method returns a `Response<TextAuthoringDeploymentResourcesState>` containing the assignment status.

```C# Snippet:Sample17_TextAuthoring_GetAssignDeploymentResourcesStatusAsync
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

// Submit assignment operation
Operation assignOperation = await projectClient.AssignDeploymentResourcesAsync(
    waitUntil: WaitUntil.Started,
    details: assignDetails
);

string operationLocation = assignOperation.GetRawResponse().Headers.TryGetValue("Operation-Location", out var location)
    ? location
    : throw new InvalidOperationException("Operation-Location header not found.");

// Extract only the jobId part from the URL
string jobId = new Uri(location).Segments.Last().Split('?')[0];
Console.WriteLine($"Job ID: {jobId}");

// Call status API
Response<TextAuthoringDeploymentResourcesState> statusResponse = await projectClient.GetAssignDeploymentResourcesStatusAsync(jobId);

Console.WriteLine($"Deployment assignment status: {statusResponse.Value.Status}");
```
