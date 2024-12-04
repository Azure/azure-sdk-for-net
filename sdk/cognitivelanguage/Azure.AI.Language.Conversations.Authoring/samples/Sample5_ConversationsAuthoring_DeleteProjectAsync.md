# Deleting a Project in Azure AI Language Asynchronously

This sample demonstrates how to delete a project asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Delete a Project Asynchronously

To delete a project, call DeleteProjectAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample5_ConversationsAuthoring_DeleteProjectAsync
string projectName = "MySampleProjectAsync";

Operation operation = await authoringClient.DeleteProjectAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a project, call DeleteProjectAsync on the AnalyzeConversationAuthoring client. The method returns an Operation object containing the status of the deletion request, and the operation-location header can be used to track the deletion process.
