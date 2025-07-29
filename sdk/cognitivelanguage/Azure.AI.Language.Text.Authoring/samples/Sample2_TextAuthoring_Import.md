# Importing Project Data in Azure AI Language

This sample demonstrates how to import project data synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

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

## Import Project Data Synchronously

To import project data synchronously, call Import on the TextAnalysisAuthoring client. The method returns an Operation object, allowing you to track the import's status and results.

```C# Snippet:Sample2_TextAuthoring_Import
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);
var projectMetadata = new TextAuthoringCreateProjectDetails(
    projectKind: "{projectKind}",
    storageInputContainerName: "{storageInputContainerName}",
    language: "{language}"
)
{
    Description = "Sample dataset for Custom Entity Recognition",
    Multilingual = false,
    Settings = new TextAuthoringProjectSettings()
};

var projectAssets = new ExportedCustomEntityRecognitionProjectAsset
{
    Entities =
    {
        new TextAuthoringExportedEntity
        {
            Category = "Date"
        },
        new TextAuthoringExportedEntity
        {
            Category = "LenderName"
        },
        new TextAuthoringExportedEntity
        {
            Category = "LenderAddress"
        }
    },
    Documents =
    {
        new ExportedCustomEntityRecognitionDocument
        {
            Location = "01.txt",
            Language = "en-us",
            Dataset = "Train",
            Entities =
            {
                 new ExportedDocumentEntityRegion
                {
                    RegionOffset = 0,
                    RegionLength = 1793,
                    Labels =
                    {
                        new ExportedDocumentEntityLabel
                        {
                            Category = "Date",
                            Offset = 5,
                            Length = 9
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderName",
                            Offset = 273,
                            Length = 14
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderAddress",
                            Offset = 314,
                            Length = 15
                        }
                    }
                }
            }
        },
        new ExportedCustomEntityRecognitionDocument
        {
            Location = "02.txt",
            Language = "en-us",
            Dataset = "Train",
            Entities =
            {
                new ExportedDocumentEntityRegion
                {
                    RegionOffset = 0,
                    RegionLength = 1804,
                    Labels =
                    {
                        new ExportedDocumentEntityLabel
                        {
                            Category = "Date",
                            Offset = 5,
                            Length = 10
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderName",
                            Offset = 284,
                            Length = 10
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderAddress",
                            Offset = 321,
                            Length = 20
                        }
                    }
                }
            }
        }
    }
};

var exportedProject = new TextAuthoringExportedProject(
    projectFileVersion: "2025-05-15-preview",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata
)
{
    Assets = projectAssets
};

Operation operation = projectClient.Import(
    waitUntil: WaitUntil.Completed,
    body: exportedProject
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
```

## Import Project Data Using Raw JSON String Synchronously

To import project data from a raw JSON string synchronously, call Import on the TextAuthoringProject client. The method accepts a raw JSON string and returns an Operation object, allowing you to track the import's status and results.

```C# Snippet:Sample2_TextAuthoring_ImportRawString
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

string rawJson = """
{
  "projectFileVersion": "2025-05-15-preview",
  "stringIndexType": "Utf16CodeUnit",
  "metadata": {
    "projectKind": "{projectKind}",
    "storageInputContainerName": "{storageInputContainerName}",
    "language": "{language}",
    "description": "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
    "multilingual": false,
    "settings": {}
  },
  "assets": {
    "projectKind": "{projectKind}",
    "classes": [
      { "category": "Date" },
      { "category": "LenderName" },
      { "category": "LenderAddress" }
    ],
    "documents": [
      {
        "class": { "category": "Date" },
        "location": "01.txt",
        "language": "en"
      },
      {
        "class": { "category": "LenderName" },
        "location": "02.txt",
        "language": "en"
      }
    ]
  }
}
""";

Operation operation = projectClient.Import(
    waitUntil: WaitUntil.Started,
    projectJson: rawJson
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
```

## Import Project Data Asynchronously

To import project data asynchronously, call ImportAsync on the TextAnalysisAuthoring client. The method returns an Operation object, allowing you to track the import's status and results.

```C# Snippet:Sample2_TextAuthoring_ImportAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);
var projectMetadata = new TextAuthoringCreateProjectDetails(
    projectKind: "{projectKind}",
    storageInputContainerName: "{storageInputContainerName}",
    language: "{language}"
)
{
    Description = "Sample dataset for Custom Entity Recognition",
    Multilingual = false
};

var projectAssets = new ExportedCustomEntityRecognitionProjectAsset
{
    Entities =
    {
        new TextAuthoringExportedEntity
        {
            Category= "Date"
        },
        new TextAuthoringExportedEntity
        {
            Category= "LenderName"
        },
        new TextAuthoringExportedEntity
        {
            Category= "LenderAddress"
        }
    },
    Documents =
    {
        new ExportedCustomEntityRecognitionDocument
        {
            Location = "01.txt",
            Language = "en-us",
            Dataset = "Train",
            Entities =
            {
                 new ExportedDocumentEntityRegion
                {
                    RegionOffset = 0,
                    RegionLength = 1793,
                    Labels =
                    {
                        new ExportedDocumentEntityLabel
                        {
                            Category = "Date",
                            Offset = 5,
                            Length = 9
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderName",
                            Offset = 273,
                            Length = 14
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderAddress",
                            Offset = 314,
                            Length = 15
                        }
                    }
                }
            }
        },
        new ExportedCustomEntityRecognitionDocument
        {
            Location = "02.txt",
            Language = "en-us",
            Dataset = "Train",
            Entities =
            {
                new ExportedDocumentEntityRegion
                {
                    RegionOffset = 0,
                    RegionLength = 1804,
                    Labels =
                    {
                        new ExportedDocumentEntityLabel
                        {
                            Category = "Date",
                            Offset = 5,
                            Length = 10
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderName",
                            Offset = 284,
                            Length = 10
                        },
                        new ExportedDocumentEntityLabel
                        {
                            Category = "LenderAddress",
                            Offset = 321,
                            Length = 20
                        }
                    }
                }
            }
        }
    }
};

var exportedProject = new TextAuthoringExportedProject(
    projectFileVersion: "2022-05-01",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata)
{
    Assets = projectAssets
};

Operation operation = await projectClient.ImportAsync(
    waitUntil: WaitUntil.Completed,
    body: exportedProject
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
```

## Import Project Data from Raw JSON String Asynchronously

To import project data from a raw JSON string asynchronously, call ImportAsync on the TextAuthoringProject client. The method accepts a raw JSON string and returns an Operation object, allowing you to track the import's status and results.

```C# Snippet:Sample2_TextAuthoring_ImportRawStringAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);

string rawJson = """
{
  "projectFileVersion": "2025-05-15-preview",
  "stringIndexType": "Utf16CodeUnit",
  "metadata": {
    "projectKind": "{projectKind}",
    "storageInputContainerName": "{storageInputContainerName}",
    "language": "{language}",
    "description": "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
    "multilingual": false,
    "settings": {}
  },
  "assets": {
    "projectKind": "{projectKind}",
    "classes": [
      { "category": "Date" },
      { "category": "LenderName" },
      { "category": "LenderAddress" }
    ],
    "documents": [
      {
        "class": { "category": "Date" },
        "location": "01.txt",
        "language": "en"
      },
      {
        "class": { "category": "LenderName" },
        "location": "02.txt",
        "language": "en"
      }
    ]
  }
}
""";

Operation operation = await projectClient.ImportAsync(
    waitUntil: WaitUntil.Started,
    projectJson: rawJson
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
```
