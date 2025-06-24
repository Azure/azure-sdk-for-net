# Importing a Project in Azure AI Language

This sample demonstrates how to import a project using the `Azure.AI.Language.Conversations.Authoring` SDK. You can define the project's metadata and assets to import it into the system.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Import a Project

To import a project, call ImportAsync on the ConversationAuthoringProject client, which returns an Operation object that tracks the progress and completion of the import operation..

```C# Snippet:Sample2_ConversationsAuthoring_ImportAsync
string projectName = "MyImportedProjectAsync";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

ConversationAuthoringCreateProjectDetails projectMetadata = new ConversationAuthoringCreateProjectDetails(
    projectKind: "Conversation",
    language: "en"
)
{
    Settings = new ConversationAuthoringProjectSettings(0.7F),
    Multilingual = true,
    Description = "Trying out CLU with assets"
};

ConversationExportedProjectAsset projectAssets = new ConversationExportedProjectAsset();

projectAssets.Intents.Add(new ConversationExportedIntent ( category : "intent1" ));
projectAssets.Intents.Add(new ConversationExportedIntent ( category : "intent2" ));

projectAssets.Entities.Add(new ConversationExportedEntity ( category : "entity1" ));

projectAssets.Utterances.Add(new ConversationExportedUtterance(
    text: "text1",
    intent: "intent1"
)
{
    Language = "en",
    Dataset = "dataset1"
});

projectAssets.Utterances[projectAssets.Utterances.Count - 1].Entities.Add(new ExportedUtteranceEntityLabel(
    category: "entity1",
    offset: 5,
    length: 5
));

projectAssets.Utterances.Add(new ConversationExportedUtterance(
    text: "text2",
    intent: "intent2"
)
{
    Language = "en",
    Dataset = "dataset1"
});

ConversationAuthoringExportedProject exportedProject = new ConversationAuthoringExportedProject(
    projectFileVersion: "2023-10-01",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata
)
{
    Assets = projectAssets
};

Operation operation = await projectClient.ImportAsync(
    waitUntil: WaitUntil.Completed,
    exportedProject: exportedProject,
    exportedProjectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
```
