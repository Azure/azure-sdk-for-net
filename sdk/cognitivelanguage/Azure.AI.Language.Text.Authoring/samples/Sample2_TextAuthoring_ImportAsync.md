# Importing Project Data Asynchronously in Azure AI Language

This sample demonstrates how to import project data asynchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

## Import Project Data Asynchronously

To import project data, call ImportAsync on the TextAnalysisAuthoring client.

```C# Snippet:Sample2_TextAuthoring_ImportAsync
string projectName = "MyImportProjectAsync";
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

To import project data asynchronously, call ImportAsync on the TextAnalysisAuthoring client. The method returns an Operation object, allowing you to track the import's status and results.
