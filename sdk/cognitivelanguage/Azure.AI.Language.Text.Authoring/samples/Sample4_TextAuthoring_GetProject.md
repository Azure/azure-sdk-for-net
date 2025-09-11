# Retrieving Project Metadata in Azure AI Language
This sample demonstrates how to retrieve metadata of a project synchronously using the Azure.AI.Language.Text.Authoring SDK.

## Create a TextAnalysisAuthoringClient

To create a `TextAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `TextAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

Or you can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Retrieve Project Metadata Synchronously
To retrieve metadata of a project, call GetProject on the TextAnalysisAuthoring client.

```C# Snippet:Sample4_TextAuthoring_GetProject
string projectName = "{projectName}";
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

## Retrieve Project Metadata Asynchronously

To retrieve metadata of a project, call GetProjectAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample4_TextAuthoring_GetProjectAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

Response<TextAuthoringProjectMetadata> response = await projectClient.GetProjectAsync();
TextAuthoringProjectMetadata projectMetadata = response.Value;

Console.WriteLine($"Project Name: {projectMetadata.ProjectName}");
Console.WriteLine($"Language: {projectMetadata.Language}");
Console.WriteLine($"Created DateTime: {projectMetadata.CreatedOn}");
Console.WriteLine($"Last Modified DateTime: {projectMetadata.LastModifiedOn}");
Console.WriteLine($"Description: {projectMetadata.Description}");
```

To retrieve project metadata asynchronously, call GetProjectAsync on the TextAnalysisAuthoring client. The method returns a ProjectMetadata object that contains detailed information about the project, such as its creation date, last modification date, description, and more.
