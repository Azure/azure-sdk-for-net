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
            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(exportOperation.HasCompleted, Is.True);
                Assert.That(!string.IsNullOrEmpty(exportedFileUrl), Is.True);
            });

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
            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(importOperation.HasCompleted, Is.True);
                Assert.That(importOperation.GetRawResponse().Status, Is.EqualTo(200));
            });

            #region Snippet:QuestionAnsweringAuthoringClient_GetProjectDetails
            Response projectDetails = client.GetProjectDetails(importedProjectName);

            Console.WriteLine(projectDetails.Content);
            #endregion

            Assert.That(projectDetails.Status, Is.EqualTo(200));
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
            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(exportOperation.HasCompleted, Is.True);
                Assert.That(!string.IsNullOrEmpty(exportedFileUrl), Is.True);
            });

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
            Assert.Multiple(() =>
            {
                #endregion

                Assert.That(importOperation.HasCompleted, Is.True);
                Assert.That(importOperation.GetRawResponse().Status, Is.EqualTo(200));
            });

            #region Snippet:QuestionAnsweringAuthoringClient_GetProjectDetailsAsync
            Response projectDetails = await client.GetProjectDetailsAsync(importedProjectName);

            Console.WriteLine(projectDetails.Content);
            #endregion

            Assert.That(projectDetails.Status, Is.EqualTo(200));
        }
    }
}
