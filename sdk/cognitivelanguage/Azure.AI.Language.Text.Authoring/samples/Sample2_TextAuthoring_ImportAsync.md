# Importing Project Data Asynchronously in Azure AI Language

This sample demonstrates how to import project data asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Import Project Data Asynchronously

To import project data asynchronously, call ImportAsync on the TextAnalysisAuthoring client. The method returns an Operation object, allowing you to track the import's status and results.

```C# Snippet:Sample2_TextAuthoring_ImportAsync
string projectName = "{projectName}";
TextAuthoringProject projectClient = client.GetProject(projectName);
var projectMetadata = new TextAuthoringCreateProjectDetails(
    projectKind: "CustomEntityRecognition",
    storageInputContainerName: "test-data",
    language: "en"
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
    "projectKind": "CustomSingleLabelClassification",
    "storageInputContainerName": "single-class-example",
    "language": "en",
    "description": "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
    "multilingual": false,
    "settings": {}
  },
  "assets": {
    "projectKind": "CustomSingleLabelClassification",
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
    exportedProject: rawJson
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
```
