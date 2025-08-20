# Exporting a Project Asynchronously in Azure AI Language

This sample demonstrates how to export a project asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK. You can specify the project's name and export format to retrieve the project data.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Export a Project Asynchronously

To export a project asynchronously, call ExportAsync on the ConversationAuthoringProject client, which returns an Operation object that tracks the progress and completion of the export operation..

```C# Snippet:Sample3_ConversationsAuthoring_ExportAsync
string projectName = "MyExportedProjectAsync";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = await projectClient.ExportAsync(
    waitUntil: WaitUntil.Completed,
    stringIndexType: StringIndexType.Utf16CodeUnit,
    exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
```
