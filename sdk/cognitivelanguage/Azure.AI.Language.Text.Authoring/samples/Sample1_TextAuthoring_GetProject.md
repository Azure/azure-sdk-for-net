# Retrieving Project Metadata Synchronously in Azure AI Language
This sample demonstrates how to retrieve metadata of a project synchronously using the Azure.AI.Language.Text.Authoring SDK.

## Create an AuthoringClient
To create an AuthoringClient, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an AuthoringClientOptions instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Retrieve Project Metadata Synchronously
To retrieve metadata of a project, call GetProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample1_TextAuthoring_GetProject
string projectName = "MyTextProject";
TextAuthoringProject projectClient = client.GetProject(projectName);

Response<TextAuthoringProjectMetadata> response = projectClient.GetProject();
TextAuthoringProjectMetadata projectMetadata = response.Value;

Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
Console.WriteLine($"Language: {projectMetadata.Language}");
Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
Console.WriteLine($"Description: {projectMetadata.Description}");
```

To retrieve project metadata synchronously, call GetProject on the TextAnalysisAuthoring client. The method returns a ProjectMetadata object that contains detailed information about the project, such as its creation date, last modification date, description, and more.
