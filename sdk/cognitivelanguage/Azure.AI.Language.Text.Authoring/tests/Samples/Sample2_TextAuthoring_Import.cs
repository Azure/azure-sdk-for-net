// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection.Emit;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample2_TextAuthoring_Import : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void Import()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_TextAuthoring_Import
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
            #endregion
        }

        [Test]
        [SyncOnly]
        public void ImportRawString()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_TextAuthoring_ImportRawString
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
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ImportAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_TextAuthoring_ImportAsync
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
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ImportRawStringAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_TextAuthoring_ImportRawStringAsync
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
            #endregion
        }
    }
}
