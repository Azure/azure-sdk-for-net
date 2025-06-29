# Creating a New Project in Azure AI Language (Synchronous)

This sample demonstrates how to create a new project synchronously using the `Azure.AI.Language.Conversations.Authoring` SDK. You can define the project's properties, such as name, language, kind, and description.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the `endpoint` and apiKey variables can be retrieved from: Environment variables, configuration settings, or any other secure approach that works for your application.

## Create a New Project

To create a new project synchronously, call CreateProject on the `ConversationAuthoringProject` clientlet, which returns a Response object containing the status of the creation request.

```C# Snippet:Sample1_ConversationsAuthoring_CreateProject
string projectName = "MyNewProject";
ConversationAuthoringProject projectClient = client.GetProject(projectName);
ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
      projectKind: "Conversation",
      language: "en-us"
    )
{
    Multilingual = true,
    Description = "Project description"
};

Response response = projectClient.CreateProject(projectData);

Console.WriteLine($"Project created with status: {response.Status}");
```
