# Creating a New Project in Azure AI Language (Synchronous)

This sample demonstrates how to create a new project synchronously using the `Azure.AI.Language.Conversations.Authoring` SDK. You can define the project's properties, such as name, language, kind, and description.

## Create an `AnalyzeConversationClient`

To create an `AnalyzeConversationClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AnalyzeConversationClientOptions` instance.

```C# Snippet:CreateAnalyzeConversationClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AnalyzeConversationClientOptions options = new AnalyzeConversationClientOptions(AnalyzeConversationClientOptions.ServiceVersion.V2024_11_15_Preview);
AnalyzeConversationClient client = new AnalyzeConversationClient(endpoint, credential, options);
AnalyzeConversationAuthoring AnalyzeConversationClient = client.GetAnalyzeConversationAnalyzeConversationClient();
```

The values of the `endpoint` and apiKey variables can be retrieved from: Environment variables, configuration settings, or any other secure approach that works for your application.

## Create a New Project

To create a new project synchronously, call CreateProject on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample1_ConversationsAuthoring_CreateProject
string projectName = "MyNewProject";
var projectData = new
{
    projectName = projectName,
    language = "en",
    projectKind = "Conversation",
    description = "Project description",
    multilingual = true
};

using RequestContent content = RequestContent.Create(projectData);
Response response = AnalyzeConversationClient.CreateProject(projectName, content);

Console.WriteLine($"Project created with status: {response.Status}");
```

To create a project, call CreateProject on the AnalyzeConversationAuthoring client, which returns a Response object containing the status of the creation request.
