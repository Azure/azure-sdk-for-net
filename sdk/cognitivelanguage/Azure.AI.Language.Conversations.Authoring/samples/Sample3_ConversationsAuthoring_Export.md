# Exporting a Project in Azure AI Language

This sample demonstrates how to export a project using the `Azure.AI.Language.Conversations.Authoring` SDK. You can specify the project's name and export format to retrieve the project data.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Export a Project

To export a project, call Export on the ConversationAuthoringProject client, which returns an Operation object that tracks the progress and completion of the export operation.

```C# Snippet:Sample3_ConversationsAuthoring_Export
string projectName = "{projectName}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = projectClient.Export(
    waitUntil: WaitUntil.Completed,
    stringIndexType: StringIndexType.Utf16CodeUnit,
    exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
```

## Export a Project Async

To export a project asynchronously, call ExportAsync on the ConversationAuthoringProject client, which returns an Operation object that tracks the progress and completion of the export operation..

```C# Snippet:Sample3_ConversationsAuthoring_ExportAsync
string projectName = "{projectName}";
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
