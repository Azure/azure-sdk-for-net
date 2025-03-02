# Creating a New Project in Azure AI Language (Asynchronous)

This sample demonstrates how to create a new project asynchronously using the `Azure.AI.Language.Conversations.Authoring` SDK. You can define the project's properties, such as name, language, kind, and description.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
string projectName = "MyNewProject";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);
```

The values of the `endpoint` and `apiKey` variables can be retrieved from: Environment variables, configuration settings, or any other secure approach that works for your application.

## Create a New Project

To create a new project, call `CreateProjectAsync` on the `ConversationAuthoringProject` client, which returns a `Response` object containing the status of the creation request.

```C# Snippet:Sample1_ConversationsAuthoring_CreateProjectAsync
string projectName = "MyNewProjectAsync";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);
var projectData = new
{
    projectName = projectName,
    language = "en",
    projectKind = "Conversation",
    description = "Project description",
    multilingual = true
};

using RequestContent content = RequestContent.Create(projectData);
Response response = await projectAuthoringClient.CreateProjectAsync(content);

Console.WriteLine($"Project created with status: {response.Status}");
```
