# Exporting Project Data in Azure AI Language

This sample demonstrates how to export project data synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create a TextAnalysisAuthoringClient

To create a `TextAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `TextAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Export Project Data Synchronously
To export project data, call `Export` on the `TextAuthoringProject` client. The method returns an `Operation` that allows you to track the status of the export operation. You can also extract the `operation-location` header from the raw response to get the URL of the operation.

```C# Snippet:Sample3_TextAuthoring_Export
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = projectClient.Export(
    waitUntil: WaitUntil.Completed,
    stringIndexType: StringIndexType.Utf16CodeUnit
);

// Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
```

## Export Project Data Asynchronously

To export project data, call `ExportAsync` on the `TextAuthoringProject` client. The method returns an `Operation` that allows you to track the status of the export operation. You can also extract the `operation-location` header from the raw response to get the URL of the operation.

```C# Snippet:Sample3_TextAuthoring_ExportAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = await projectClient.ExportAsync(
    waitUntil: WaitUntil.Completed,
    stringIndexType: StringIndexType.Utf16CodeUnit
);

// Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project export completed with status: {operation.GetRawResponse().Status}");
```
