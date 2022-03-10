﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering.Projects;
using Azure.Core;
using System.Linq;
using System.Threading;
using System.Text.Json;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringProjectsClientSamples : QuestionAnsweringProjectsLiveTestBase
    {
        [RecordedTest]
        [SyncOnly]
        public void ExportAndImport()
        {
            QuestionAnsweringProjectsClient client = Client;
            string exportedProjectName = CreateTestProjectName();
            CreateProject(exportedProjectName);

            #region Snippet:QuestionAnsweringProjectsClient_ExportProject
            Operation<BinaryData> exportOperation = client.Export(waitForCompletion: true, exportedProjectName, format: "json");

            // retrieve export operation response, and extract url of exported file
            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
            string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
            #endregion

            Assert.True(exportOperation.HasCompleted);
            Assert.True(!String.IsNullOrEmpty(exportedFileUrl));

            #region Snippet:QuestionAnsweringProjectsClient_ImportProject
            // Set import project name and request content
            string importedProjectName = "{ProjectNameToBeImported}";
#if !SNIPPET
            importedProjectName = "importedProject";
#endif
            RequestContent importRequestContent = RequestContent.Create(new
                {
                Metadata = new
                {
                    ProjectName = "NewProjectForExport",
                    Description = "This is the description for a test project",
                    Language = "en",
                    DefaultAnswer = "No answer found for your question.",
                    MultilingualResource = false,
                    CreatedDateTime = "2021-11-25T09=35=33Z",
                    LastModifiedDateTime = "2021-11-25T09=35=33Z",
                    Settings = new
                    {
                        DefaultAnswer = "No answer found for your question."
                    }
                }
            });

            Operation<BinaryData> importOperation = client.Import(waitForCompletion: true, importedProjectName, importRequestContent, format: "json");

            Console.WriteLine($"Operation status: {importOperation.GetRawResponse().Status}");
            #endregion

            Assert.True(importOperation.HasCompleted);
            Assert.AreEqual(200, importOperation.GetRawResponse().Status);

            #region Snippet:QuestionAnsweringProjectsClient_GetProjectDetails
            Response projectDetails = client.GetProjectDetails(importedProjectName);

            Console.WriteLine(projectDetails.Content);
            #endregion

            Assert.AreEqual(200, projectDetails.Status);

            DeleteProject(importedProjectName);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task ExportAndImportAsync()
        {
            QuestionAnsweringProjectsClient client = Client;
            string exportedProjectName = CreateTestProjectName();
            await CreateProjectAsync(exportedProjectName);

            #region Snippet:QuestionAnsweringProjectsClient_ExportProjectAsync
            Operation<BinaryData> exportOperation = await client.ExportAsync(waitForCompletion: true, exportedProjectName, format : "json");

            // retrieve export operation response, and extract url of exported file
            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
            string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
            #endregion

            Assert.True(exportOperation.HasCompleted);
            Assert.True(!String.IsNullOrEmpty(exportedFileUrl));

            #region Snippet:QuestionAnsweringProjectsClient_ImportProjectAsync
            // Set import project name and request content
            string importedProjectName = "{ProjectNameToBeImported}";
#if !SNIPPET
            importedProjectName = "importedProject";
#endif
            RequestContent importRequestContent = RequestContent.Create(new
            {
                Metadata = new
                {
                    ProjectName = "NewProjectForExport",
                    Description = "This is the description for a test project",
                    Language = "en",
                    DefaultAnswer = "No answer found for your question.",
                    MultilingualResource = false,
                    CreatedDateTime = "2021-11-25T09=35=33Z",
                    LastModifiedDateTime = "2021-11-25T09=35=33Z",
                    Settings = new
                    {
                        DefaultAnswer = "No answer found for your question."
                    }
                }
            });

            Operation<BinaryData> importOperation = await client.ImportAsync(waitForCompletion: true, importedProjectName, importRequestContent, format: "json");
            Console.WriteLine($"Operation status: {importOperation.GetRawResponse().Status}");
            #endregion

            Assert.True(importOperation.HasCompleted);
            Assert.AreEqual(200, importOperation.GetRawResponse().Status);

            #region Snippet:QuestionAnsweringProjectsClient_GetProjectDetailsAsync
            Response projectDetails = await client.GetProjectDetailsAsync(importedProjectName);

            Console.WriteLine(projectDetails.Content);
            #endregion

            Assert.AreEqual(200, projectDetails.Status);

            await DeleteProjectAsync(importedProjectName);
        }
    }
}
