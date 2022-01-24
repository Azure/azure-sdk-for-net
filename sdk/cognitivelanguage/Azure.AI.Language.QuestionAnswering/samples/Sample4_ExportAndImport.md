# Export and Import Question Answering Projects

This sample demonstrates how to export and import Question Answering projects. To get started, you'll need to create a Question Answering service endpoint and an API key. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) for links and instructions.

To export, import, or perform any other authoring actions for Question Answering projects, you need to first create a `QuestionAnsweringProjectsClient` using an endpoint and API key. These can be stored in an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:QuestionAnsweringProjectsClient_Create
Uri endpoint = new Uri("{LanguageEndpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{ApiKey}");

QuestionAnsweringProjectsClient client = new QuestionAnsweringProjectsClient(endpoint, credential);
```

Once you have created a client, you can call synchronous or asynchronous methods.

## Synchronous

### Exporting a Project

To export a Question Answering project, you will need to set your project name and choose an export format before calling c as shown below:

```C# Snippet:QuestionAnsweringProjectsClient_ExportProject
Operation<BinaryData> exportOperation = client.Export(waitForCompletion: true, exportedProjectName, format: "json");

// retrieve export operation response, and extract url of exported file
JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
```

### Importing a project

To import a project, you could provide the data of the exported project in the specified import format through a RequestContent instance as shown below. Alternatively, you can define a `fileUri` property in your request content, which would enable you to provide the URI for a publicly available file containing the details for the project to be imported.

```C# Snippet:QuestionAnsweringProjectsClient_ImportProject
// Set import project name and request content
string importedProjectName = "{ProjectNameToBeImported}";
RequestContent importRequestContent = RequestContent.Create(new
    {
    Metadata = new
    {
        ProjectName = "NewProjectForExport",
        Description = "This is the description for a test project",
        Language = "en",
        DefaultAnswer = "No answer found for your question.",
        MultilingualResource = false,
        CreatedDateTime = "2021-11-25T09=35=33Z",
        LastModifiedDateTime = "2021-11-25T09=35=33Z",
        Settings = new
        {
            DefaultAnswer = "No answer found for your question."
        }
    }
});

Operation<BinaryData> importOperation = client.Import(waitForCompletion: true, importedProjectName, importRequestContent, format: "json");

Console.WriteLine($"Operation status: {importOperation.GetRawResponse().Status}");
```

### Getting Project Details

To get information regarding a specific project, the `GetProjectDetails()` method can be used as follows:

```C# Snippet:QuestionAnsweringProjectsClient_GetProjectDetails
Response projectDetails = client.GetProjectDetails(importedProjectName);

Console.WriteLine(projectDetails.Content);
```

## Asynchronous

### Exporting a Project

```C# Snippet:QuestionAnsweringProjectsClient_ExportProjectAsync
Operation<BinaryData> exportOperation = await client.ExportAsync(waitForCompletion: true, exportedProjectName, format : "json");

// retrieve export operation response, and extract url of exported file
JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
```

### Importing a project

```C# Snippet:QuestionAnsweringProjectsClient_ImportProjectAsync
// Set import project name and request content
string importedProjectName = "{ProjectNameToBeImported}";
RequestContent importRequestContent = RequestContent.Create(new
{
    Metadata = new
    {
        ProjectName = "NewProjectForExport",
        Description = "This is the description for a test project",
        Language = "en",
        DefaultAnswer = "No answer found for your question.",
        MultilingualResource = false,
        CreatedDateTime = "2021-11-25T09=35=33Z",
        LastModifiedDateTime = "2021-11-25T09=35=33Z",
        Settings = new
        {
            DefaultAnswer = "No answer found for your question."
        }
    }
});

Operation<BinaryData> importOperation = await client.ImportAsync(waitForCompletion: true, importedProjectName, importRequestContent, format: "json");
Console.WriteLine($"Operation status: {importOperation.GetRawResponse().Status}");
```

### Getting Project Details

```C# Snippet:QuestionAnsweringProjectsClient_GetProjectDetailsAsync
Response projectDetails = await client.GetProjectDetailsAsync(importedProjectName);

Console.WriteLine(projectDetails.Content);
```
