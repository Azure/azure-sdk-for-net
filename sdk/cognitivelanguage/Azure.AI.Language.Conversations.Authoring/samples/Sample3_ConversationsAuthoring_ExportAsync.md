# Exporting a Project Asynchronously in Azure AI Language

This sample demonstrates how to export a project asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK. You can specify the project's name and export format to retrieve the project data.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
string projectName = "MyNewProject";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Export a Project Asynchronously

To export a project asynchronously, call ExportAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample3_ConversationsAuthoring_ExportAsync
string projectName = "MyExportedProjectAsync";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);

Operation operation = await projectAuthoringClient.ExportAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    stringIndexType: StringIndexType.Utf16CodeUnit,
    exportedProjectFormat: AnalyzeConversationAuthoringExportedProjectFormat.Conversation
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
```

To export a project asynchronously, call ExportAsync on the AnalyzeConversationAuthoring client, which returns an Operation object that tracks the progress and completion of the export operation.
