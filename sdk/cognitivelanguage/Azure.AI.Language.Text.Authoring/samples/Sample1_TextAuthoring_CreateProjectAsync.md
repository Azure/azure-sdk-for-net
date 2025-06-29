# Creating a Project Asynchronously in Azure AI Language

This sample demonstrates how to create a new project asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Create a Project Asynchronously

To create a new project, call CreateProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample1_TextAuthoring_CreateProjectAsync
string projectName = "MyNewProjectAsync";
TextAuthoringProject projectClient = client.GetProject(projectName);
var projectData = new TextAuthoringCreateProjectDetails(
    projectKind: "customMultiLabelClassification",
    storageInputContainerName: "test-data",
    language: "en"
)
{
    Description = "Project description for a Custom Entity Recognition project",
    Multilingual = true
};

Response response = await projectClient.CreateProjectAsync(projectData);

Console.WriteLine($"Project created with status: {response.Status}");
```

To create a project, the CreateProject method sends a request with the necessary project data (such as name, language, and project type). The method returns a Response object indicating the creation status.
