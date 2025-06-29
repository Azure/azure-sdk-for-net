// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.AI.Language.Text.Authoring;
using Azure.AI.Language.Text.Authoring.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Authoring.Tests.Samples
{
    public partial class Sample3_TextAuthoring_ExportAsync : SamplesBase<AuthoringClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task ImportAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);

            #region Snippet:Sample2_TextAuthoring_ImportAsync
            string projectName = "LoanAgreements";
            TextAuthoringProject projectClient = client.GetProject(projectName);
            var projectMetadata = new TextAuthoringCreateProjectDetails(
                projectKind: "CustomEntityRecognition",
                storageInputContainerName: "loanagreements",
                language: "en"
            )
            {
                Description = "This is a sample dataset provided by the Azure Language service team to help users get started with Custom named entity recognition. The provided sample dataset contains 20 loan agreements drawn up between two entities.",
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
    }
}
