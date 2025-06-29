# Retrieving Project Metadata Synchronously in Azure AI Language
This sample demonstrates how to retrieve metadata of a project synchronously using the Azure.AI.Language.Text.Authoring SDK.

## Create an AuthoringClient
To create an AuthoringClient, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an AuthoringClientOptions instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Retrieve Project Metadata Synchronously
To retrieve metadata of a project, call GetProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample4_TextAuthoring_GetProject
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
