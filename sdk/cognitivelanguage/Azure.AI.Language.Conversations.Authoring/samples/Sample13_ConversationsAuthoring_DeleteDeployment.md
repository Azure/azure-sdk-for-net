# Deleting a Deployment in Azure AI Language

This sample demonstrates how to delete a deployment in a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

## Delete a Deployment

To delete a deployment, call DeleteDeployment on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample13_ConversationsAuthoring_DeleteDeployment
Operation operation = authoringClient.DeleteDeployment(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    deploymentName: deploymentName
);

// Extract operation-location from response headers
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : "Not found";
Console.WriteLine($"Delete operation-location: {operationLocation}");
Console.WriteLine($"Delete operation completed with status: {operation.GetRawResponse().Status}");
```

Deleting a deployment removes it from the specified project and ensures that resources associated with the deployment are released.
