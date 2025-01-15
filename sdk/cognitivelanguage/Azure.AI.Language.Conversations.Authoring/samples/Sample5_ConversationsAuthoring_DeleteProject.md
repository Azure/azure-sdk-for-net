# Deleting a Project in Azure AI Language

This sample demonstrates how to delete a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AnalyzeConversationClient`

To create an `AnalyzeConversationClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AnalyzeConversationClientOptions` instance.

```C# Snippet:CreateAnalyzeConversationClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AnalyzeConversationClientOptions options = new AnalyzeConversationClientOptions(AnalyzeConversationClientOptions.ServiceVersion.V2024_11_15_Preview);
AnalyzeConversationClient client = new AnalyzeConversationClient(endpoint, credential, options);
AnalyzeConversationAuthoring AnalyzeConversationClient = client.GetAnalyzeConversationAnalyzeConversationClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Delete a Project

To delete a project, call DeleteProject on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample5_ConversationsAuthoring_DeleteProject
string projectName = "MySampleProject";

Operation operation = AnalyzeConversationClient.DeleteProject(
    waitUntil: WaitUntil.Completed,
    projectName: projectName
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project deletion completed with status: {operation.GetRawResponse().Status}");
```

To delete a project, call DeleteProject on the AnalyzeConversationAuthoring client. The method returns an Operation object containing the status of the deletion request, and the operation-location header can be used to track the deletion process.
