// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core;
using System.Text.Json;

namespace Azure.AI.Language.QuestionAnswering.Tests.Samples
{
    public partial class QuestionAnsweringAuthoringClientSamples : QuestionAnsweringAuthoringLiveTestBase
    {
        [RecordedTest]
        [SyncOnly]
        public void ExportAndImport()
        {
            QuestionAnsweringAuthoringClient client = Client;
            string exportedProjectName = CreateTestProjectName();
            CreateProject(exportedProjectName);

            #region Snippet:QuestionAnsweringAuthoringClient_ExportProject
            Operation<BinaryData> exportOperation = client.Export(WaitUntil.Completed, exportedProjectName, format: "json");

            // retrieve export operation response, and extract url of exported file
            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
            string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
            #endregion

            Assert.True(exportOperation.HasCompleted);
            Assert.True(!string.IsNullOrEmpty(exportedFileUrl));

            #region Snippet:QuestionAnsweringAuthoringClient_ImportProject
            // Set import project name and request content
            string importedProjectName = "{ProjectNameToBeImported}";
#if !SNIPPET
            importedProjectName = CreateTestProjectName();
#endif
            RequestContent importRequestContent = RequestContent.Create(new
                {
                Metadata = new
                {
                    Description = "This is the description for a test project",
                    Language = "en",
                    DefaultAnswer = "No answer found for your question.",
                    MultilingualResource = false,
                    Settings = new
                    {
                        DefaultAnswer = "No answer found for your question."
                    }
                }
            });

            Operation<BinaryData> importOperation = client.Import(WaitUntil.Completed, importedProjectName, importRequestContent, format: "json");
#if !SNIPPET
            EnqueueProjectDeletion(importedProjectName);
#endif
            Console.WriteLine($"Operation status: {importOperation.GetRawResponse().Status}");
            #endregion

            Assert.True(importOperation.HasCompleted);
            Assert.AreEqual(200, importOperation.GetRawResponse().Status);

            #region Snippet:QuestionAnsweringAuthoringClient_GetProjectDetails
            Response projectDetails = client.GetProjectDetails(importedProjectName);

            Console.WriteLine(projectDetails.Content);
            #endregion

            Assert.AreEqual(200, projectDetails.Status);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task ExportAndImportAsync()
        {
            QuestionAnsweringAuthoringClient client = Client;
            string exportedProjectName = CreateTestProjectName();
            await CreateProjectAsync(exportedProjectName);

            #region Snippet:QuestionAnsweringAuthoringClient_ExportProjectAsync
            Operation<BinaryData> exportOperation = await client.ExportAsync(WaitUntil.Completed, exportedProjectName, format : "json");

            // retrieve export operation response, and extract url of exported file
            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
            string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();
            #endregion

            Assert.True(exportOperation.HasCompleted);
            Assert.True(!string.IsNullOrEmpty(exportedFileUrl));

            #region Snippet:QuestionAnsweringAuthoringClient_ImportProjectAsync
            // Set import project name and request content
            string importedProjectName = "{ProjectNameToBeImported}";
#if !SNIPPET
            importedProjectName = CreateTestProjectName();
#endif
            RequestContent importRequestContent = RequestContent.Create(new
            {
                Metadata = new
                {
                    Description = "This is the description for a test project",
                    Language = "en",
                    DefaultAnswer = "No answer found for your question.",
                    MultilingualResource = false,
                    Settings = new
                    {
                        DefaultAnswer = "No answer found for your question."
                    }
                }
            });

            Operation<BinaryData> importOperation = await client.ImportAsync(WaitUntil.Completed, importedProjectName, importRequestContent, format: "json");
#if !SNIPPET
            EnqueueProjectDeletion(importedProjectName);
#endif
            Console.WriteLine($"Operation status: {importOperation.GetRawResponse().Status}");
            #endregion

            Assert.True(importOperation.HasCompleted);
            Assert.AreEqual(200, importOperation.GetRawResponse().Status);

            #region Snippet:QuestionAnsweringAuthoringClient_GetProjectDetailsAsync
            Response projectDetails = await client.GetProjectDetailsAsync(importedProjectName);

            Console.WriteLine(projectDetails.Content);
            #endregion

            Assert.AreEqual(200, projectDetails.Status);
        }
    }
}
