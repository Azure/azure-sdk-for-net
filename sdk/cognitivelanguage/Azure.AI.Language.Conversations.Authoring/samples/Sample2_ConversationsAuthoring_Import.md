# Importing a Project in Azure AI Language

This sample demonstrates how to import a project synchronously using the `Azure.AI.Language.Conversations.Authoring` SDK. You can define the project's metadata and assets before importing it into the service.

## Create a `ConversationAnalysisAuthoringClient`

To create a `ConversationAnalysisAuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing a `ConversationAnalysisAuthoringClientOptions` instance.

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

The values of the endpoint and apiKey variables can be retrieved from: Environment variables, configuration settings, or any other secure approach that works for your application.

Or you can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
For details on how to set up AAD authentication, refer to the [Create a client using AAD](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.md#create-a-client-using-azure-active-directory-authentication).

## Import a New Project

To import a project synchronously, call Import on the `ConversationAuthoringProject` client. The method returns an Operation object, which you can use to track the status of the operation. The operation-location header contains the location of the operation for further tracking.

```C# Snippet:Sample2_ConversationsAuthoring_Import
string projectName = "{projectName}";
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
    projectFileVersion: "2025-05-15-preview",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata
)
{
    Assets = projectAssets
};

Operation operation = projectClient.Import(
    waitUntil: WaitUntil.Completed,
    exportedProject: exportedProject,
    projectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

 // Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
```

## Import a Project Using Raw JSON

To import a project using raw JSON, define the JSON string matching the structure of `ConversationAuthoringExportedProject`. Then call `ImportAsync` on the `ConversationAuthoringProject` client.

```C# Snippet:Sample2_ConversationsAuthoring_ImportProjectAsRawJson
string projectName = "{projectName}";

string rawJson = """
{
  "projectFileVersion": "2025-05-15-preview",
  "stringIndexType": "Utf16CodeUnit",
  "metadata": {
    "projectKind": "Conversation",
    "language": "en-us",
    "settings": {
      "confidenceThreshold": 0.0
    },
    "projectName": "MyImportedProject",
    "multilingual": false,
    "description": ""
  },
  "assets": {
    "projectKind": "Conversation",
    "intents": [
      { "category": "IntentA" },
      { "category": "IntentB" }
    ],
    "entities": [
      {
        "category": "EntityA",
        "compositionSetting": "combineComponents"
      }
    ],
    "utterances": [
      {
        "text": "Example text one",
        "intent": "IntentB",
        "language": "en-us",
        "dataset": "Train",
        "entities": [
          { "category": "EntityA", "offset": 8, "length": 4 }
        ]
      },
      {
        "text": "Example text two",
        "intent": "IntentB",
        "language": "en-us",
        "dataset": "Train",
        "entities": [
          { "category": "EntityA", "offset": 8, "length": 3 }
        ]
      }
    ]
  }
}
""";

ConversationAuthoringProject projectClient = client.GetProject(projectName);

Operation operation = projectClient.Import(
    waitUntil: WaitUntil.Started,
    projectJson: rawJson,
    projectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Project import (raw JSON) completed with status: {operation.GetRawResponse().Status}");
```

## Import a New Project with Metadata and Assets

To import a project, construct a `ConversationAuthoringExportedProject` that includes the metadata and assets. Then call `Import` on the `ConversationAuthoringProject` client.

```C# Snippet:Sample2_ConversationsAuthoring_ImportProjectWithMetadataAndResources
string projectName = "{projectName}";

// Create metadata
ConversationAuthoringCreateProjectDetails projectMetadata = new ConversationAuthoringCreateProjectDetails(
    projectKind: "Conversation",
    language: "en-us")
{
    Settings = new ConversationAuthoringProjectSettings(0.7F),
    Multilingual = true,
    Description = "Trying out CLU",
    ProjectName = projectName
};

// Define intents and entities
ConversationExportedProjectAsset projectAssets = new ConversationExportedProjectAsset();

projectAssets.Intents.Add(new ConversationExportedIntent("Read")
{
    Description = "The read intent",
    AssociatedEntities = { new ConversationExportedAssociatedEntityLabel("Sender") }
});
projectAssets.Intents.Add(new ConversationExportedIntent("Delete")
{
    Description = "The delete intent"
});

projectAssets.Entities.Add(new ConversationExportedEntity("Sender")
{
    Description = "The description of Sender"
});

projectAssets.Entities.Add(new ConversationExportedEntity("Number")
{
    Description = "The description of Number",
    Regex = new ExportedEntityRegex
    {
        Expressions =
        {
            new ExportedEntityRegexExpression
            {
                RegexKey = "UK Phone numbers",
                Language = "en-us",
                RegexPattern = @"^\(?([0-9]{3})\)?[-.\s]?([0-9]{3})[-.\s]?([0-9]{4})$"
            }
        }
    }
});

// Add utterances
projectAssets.Utterances.Add(new ConversationExportedUtterance("Open Blake's email", "Read")
{
    Dataset = "Train",
    Entities = { new ExportedUtteranceEntityLabel("Sender", offset: 5, length: 5) }
});

projectAssets.Utterances.Add(new ConversationExportedUtterance("Delete last email", "Delete")
{
    Language = "en-gb",
    Dataset = "Test"
});

// Build the exported project
ConversationAuthoringExportedProject exportedProject = new ConversationAuthoringExportedProject(
    projectFileVersion: "2025-05-15-preview",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata)
{
    Assets = projectAssets
};

// Get project authoring client
ConversationAuthoringProject projectClient = client.GetProject(projectName);

// Start import operation
Operation operation = projectClient.Import(
    WaitUntil.Started,
    exportedProject,
    ConversationAuthoringExportedProjectFormat.Conversation
);

Console.WriteLine($"Project import request submitted with status: {operation.GetRawResponse().Status}");

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
    ? location : "Not found";
Console.WriteLine($"Operation Location: {operationLocation}");
```

## Import a Project Async

To import a project, call ImportAsync on the ConversationAuthoringProject client, which returns an Operation object that tracks the progress and completion of the import operation..

```C# Snippet:Sample2_ConversationsAuthoring_ImportAsync
string projectName = "{projectName}";
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

projectAssets.Intents.Add(new ConversationExportedIntent(category: "intent1"));
projectAssets.Intents.Add(new ConversationExportedIntent(category: "intent2"));

projectAssets.Entities.Add(new ConversationExportedEntity(category: "entity1"));

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
    projectFileVersion: "2025-05-15-preview",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata
)
{
    Assets = projectAssets
};

Operation operation = await projectClient.ImportAsync(
    waitUntil: WaitUntil.Completed,
    exportedProject: exportedProject,
    projectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

// Extract the operation-location header
string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");

Console.WriteLine($"Project import completed with status: {operation.GetRawResponse().Status}");
```


## Import a Project Using Raw JSON Async

To import a project using raw JSON asynchronously, define the JSON string matching the structure of `ConversationAuthoringExportedProject`. Then call `ImportAsync` on the `ConversationAuthoringProject` client.

```C# Snippet:Sample2_ConversationsAuthoring_ImportProjectAsRawJsonAsync
string projectName = "{projectName}";
ConversationAuthoringProject projectClient = client.GetProject(projectName);

string rawJson = """
{
  "projectFileVersion": "2025-05-15-preview",
  "stringIndexType": "Utf16CodeUnit",
  "metadata": {
    "projectKind": "Conversation",
    "language": "en-us",
    "settings": {
      "confidenceThreshold": 0.0
    },
    "projectName": "MyImportedProjectAsync",
    "multilingual": false,
    "description": ""
  },
  "assets": {
    "projectKind": "Conversation",
    "intents": [
      { "category": "IntentAlpha" },
      { "category": "IntentBeta" }
    ],
    "entities": [
      {
        "category": "EntityX",
        "compositionSetting": "combineComponents"
      }
    ],
    "utterances": [
      {
        "text": "Example input text A",
        "intent": "IntentBeta",
        "language": "en-us",
        "dataset": "Train",
        "entities": [
          { "category": "EntityX", "offset": 8, "length": 4 }
        ]
      },
      {
        "text": "Example input text B",
        "intent": "IntentBeta",
        "language": "en-us",
        "dataset": "Train",
        "entities": [
          { "category": "EntityX", "offset": 8, "length": 3 }
        ]
      }
    ]
  }
}
""";

Operation operation = await projectClient.ImportAsync(
    waitUntil: WaitUntil.Started,
    projectJson: rawJson,
    projectFormat: ConversationAuthoringExportedProjectFormat.Conversation
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Project import (raw JSON) completed with status: {operation.GetRawResponse().Status}");
```

## Import a New Project Async with Metadata and Assets

To import a project async, construct a `ConversationAuthoringExportedProject` that includes the metadata and assets. Then call `Import` on the `ConversationAuthoringProject` client.

```C# Snippet:Sample2_ConversationsAuthoring_ImportProjectAsync_WithMetadataAndAssets
string projectName = "{projectName}";

// Define project metadata
ConversationAuthoringCreateProjectDetails projectMetadata = new ConversationAuthoringCreateProjectDetails(
    projectKind: "Conversation",
    language: "en-us")
{
    Settings = new ConversationAuthoringProjectSettings(0.7F),
    Multilingual = true,
    Description = "Trying out CLU",
    ProjectName = projectName
};

// Define project assets
ConversationExportedProjectAsset projectAssets = new ConversationExportedProjectAsset();

projectAssets.Intents.Add(new ConversationExportedIntent("Read")
{
    Description = "The read intent",
    AssociatedEntities = { new ConversationExportedAssociatedEntityLabel("Sender") }
});
projectAssets.Intents.Add(new ConversationExportedIntent("Delete")
{
    Description = "The delete intent"
});

projectAssets.Entities.Add(new ConversationExportedEntity("Sender")
{
    Description = "The description of Sender"
});

projectAssets.Entities.Add(new ConversationExportedEntity("Number")
{
    Description = "The description of Number",
    Regex = new ExportedEntityRegex
    {
        Expressions =
        {
            new ExportedEntityRegexExpression
            {
                RegexKey = "UK Phone numbers",
                Language = "en-us",
                RegexPattern = @"^\(?([0-9]{3})\)?[-.\s]?([0-9]{3})[-.\s]?([0-9]{4})$"
            }
        }
    }
});

projectAssets.Utterances.Add(new ConversationExportedUtterance("Open Blake's email", "Read")
{
    Dataset = "Train",
    Entities = { new ExportedUtteranceEntityLabel("Sender", offset: 5, length: 5) }
});

projectAssets.Utterances.Add(new ConversationExportedUtterance("Delete last email", "Delete")
{
    Language = "en-gb",
    Dataset = "Test"
});

// Build the exported project
ConversationAuthoringExportedProject exportedProject = new ConversationAuthoringExportedProject(
    projectFileVersion: "2025-05-15-preview",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata)
{
    Assets = projectAssets
};

// Get project client
ConversationAuthoringProject projectClient = client.GetProject(projectName);

// Start import
Operation operation = await projectClient.ImportAsync(
    waitUntil: WaitUntil.Started,
    exportedProject,
    ConversationAuthoringExportedProjectFormat.Conversation
);

Console.WriteLine($"Project import submitted with status: {operation.GetRawResponse().Status}");

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out string location)
    ? location : "Not found";
Console.WriteLine($"Operation Location: {operationLocation}");
```
