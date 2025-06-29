# Creating a Project Synchronously in Azure AI Language

This sample demonstrates how to create a new project synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Create a Project Synchronously

To create a new project, call CreateProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample1_TextAuthoring_CreateProject
string projectName = "MyNewProject";
TextAuthoringProject projectClient = client.GetProject(projectName);
var projectData = new TextAuthoringCreateProjectDetails(
    projectKind: "customMultiLabelClassification",
    storageInputContainerName: "e2e0test0data",
    language: "en"
)
{
    Description = "Project description for a Custom Entity Recognition project",
    Multilingual = true
};

Response response = projectClient.CreateProject(projectData);

Console.WriteLine($"Project created with status: {response.Status}");
```

To create a project, the CreateProject method sends a request with the necessary project data (such as name, language, and project type). The method returns a Response object indicating the creation status.
