# Importing a Project in Azure AI Language

This sample demonstrates how to import a project using the `Azure.AI.Language.Conversations.Authoring` SDK. You can define the project's metadata and assets to import it into the system.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Import a Project

To import a project, call ImportAsync on the AnalyzeConversationAuthoring client.

```C# Snippet:Sample2_ConversationsAuthoring_ImportAsync
string projectName = "MyImportedProjectAsync";

var projectMetadata = new CreateProjectDetails(
    projectKind: "Conversation",
    projectName: projectName,
    language: "en"
)
{
    Settings = new ProjectSettings(0.7F),
    Multilingual = true,
    Description = "Trying out CLU with assets"
};

var projectAssets = new ConversationExportedProjectAssets();

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

var exportedProject = new ExportedProject(
    projectFileVersion: "2023-10-01",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata
)
{
    Assets = projectAssets
};

Operation operation = await authoringClient.ImportAsync(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: exportedProject,
    exportedProjectFormat: ExportedProjectFormat.Conversation
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
```

To import a project, call ImportAsync on the AnalyzeConversationAuthoring client, which returns an Operation object that tracks the progress and completion of the import operation.
