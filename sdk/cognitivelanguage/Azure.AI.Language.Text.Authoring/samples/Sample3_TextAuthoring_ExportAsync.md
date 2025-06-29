# Exporting Project Data Asynchronously in Azure AI Language

This sample demonstrates how to export project data asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Export Project Data Asynchronously

To export project data, call `ExportAsync` on the `TextAuthoringProject` client. The method returns an `Operation` that allows you to track the status of the export operation. You can also extract the `operation-location` header from the raw response to get the URL of the operation.

```C# Snippet:Sample3_TextAuthoring_ExportAsync
string projectName = "MyExportedProjectAsync";
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
