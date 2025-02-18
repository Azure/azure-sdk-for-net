# Retrieving Project Metadata in Azure AI Language

This sample demonstrates how to retrieve metadata of a project using the `Azure.AI.Language.Conversations.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
string projectName = "MyNewProject";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Retrieve Project Metadata

To retrieve metadata of a project, call GetProject on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample4_ConversationsAuthoring_GetProject
string projectName = "MySampleProject";
ConversationAuthoringProjects projectAuthoringClient = client.GetProjects(projectName);

Response<ProjectMetadata> response = projectAuthoringClient.GetProject();
ProjectMetadata projectMetadata = response.Value;

Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
Console.WriteLine($"Last Trained DateTime: {projectMetadata.LastTrainedOn}");
Console.WriteLine($"Last Deployed DateTime: {projectMetadata.LastDeployedOn}");
Console.WriteLine($"Project Kind: {projectMetadata.ProjectKind}");
Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
Console.WriteLine($"Multilingual: {projectMetadata.Multilingual}");
Console.WriteLine($"Description: {projectMetadata.Description}");
Console.WriteLine($"Language: {projectMetadata.Language}");
```

To retrieve project metadata, call GetProject on the AnalyzeConversationAuthoring client. The method returns a ProjectMetadata object that contains detailed information about the project, such as its creation date, last modification date, description, and more.
