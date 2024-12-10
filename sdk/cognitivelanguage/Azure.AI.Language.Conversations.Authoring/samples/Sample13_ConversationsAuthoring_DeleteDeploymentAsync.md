# Deleting a Deployment Asynchronously in Azure AI Language

This sample demonstrates how to delete a deployment asynchronously in a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

## Delete a Deployment Asynchronously

To delete a deployment, call DeleteDeploymentAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample13_ConversationsAuthoring_DeleteDeploymentAsync
Operation operation = await authoringClient.DeleteDeploymentAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    deploymentName: deploymentName
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```

Deleting a deployment asynchronously allows for non-blocking operations and ensures resources associated with the deployment are released efficiently.
