# Importing Project Data Synchronously in Azure AI Language

This sample demonstrates how to import project data synchronously using the `Azure.AI.Language.Text.Authoring` SDK.

## Create an `AuthoringClient`

To create an `AuthoringClient`, you will need the service endpoint and credentials of your Language resource. You can specify the service version by providing an `AuthoringClientOptions` instance.

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
TextAnalysisAuthoring authoringClient = client.GetTextAnalysisAuthoringClient();
```

The values of the endpoint and apiKey variables can be retrieved from environment variables, configuration settings, or any other secure approach that works for your application.

## Import Project Data Synchronously

To import project data, call Import on the TextAnalysisAuthoring client.

```C# Snippet:Sample2_TextAuthoring_Import
string projectName = "LoanAgreements";

var projectMetadata = new CreateProjectDetails(
    projectKind: "CustomEntityRecognition",
    storageInputContainerName: "loanagreements",
    projectName: projectName,
    language: "en"
)
{
    Description = "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
    Multilingual = false,
    Settings = new ProjectSettings()
};

var projectAssets = new ExportedCustomEntityRecognitionProjectAssets
{
    Entities =
    {
        new ExportedEntity
        {
            Category = "Date"
        },
        new ExportedEntity
        {
            Category = "LenderName"
        },
        new ExportedEntity
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

var exportedProject = new ExportedProject(
    projectFileVersion: "2022-05-01",
    stringIndexType: StringIndexType.Utf16CodeUnit,
    metadata: projectMetadata
)
{
    Assets = projectAssets
};

Operation operation = authoringClient.Import(
    waitUntil: WaitUntil.Completed,
    projectName: projectName,
    body: exportedProject
);

string operationLocation = operation.GetRawResponse().Headers.TryGetValue("operation-location", out var location) ? location : null;
Console.WriteLine($"Operation Location: {operationLocation}");
Console.WriteLine($"Import completed with status: {operation.GetRawResponse().Status}");
```

To import project data synchronously, call Import on the TextAnalysisAuthoring client. The method returns an Operation object, allowing you to track the import's status and results.
