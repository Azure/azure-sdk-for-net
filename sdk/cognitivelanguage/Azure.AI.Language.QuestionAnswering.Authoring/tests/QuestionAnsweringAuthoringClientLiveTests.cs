// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests
{
    public class QuestionAnsweringAuthoringClientLiveTests : QuestionAnsweringAuthoringLiveTestBase
    {
        public QuestionAnsweringAuthoringClientLiveTests(bool isAsync, QuestionAnsweringAuthoringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task CreateProject()
        {
            string testProjectName = CreateTestProjectName();
            Response createProjectResponse = await CreateProjectAsync(testProjectName);
            AsyncPageable<QuestionAnsweringProject> projects = Client.GetProjectsAsync();
            Response<QuestionAnsweringProject> projectDetailsResponse = await Client.GetProjectDetailsAsync(testProjectName);

            Assert.AreEqual(201, createProjectResponse.Status);
            Assert.AreEqual(200, projectDetailsResponse.GetRawResponse().Status);
            Assert.That((await projects.ToEnumerableAsync()).Any(project => project.ProjectName.Contains(testProjectName)));
            Assert.That(projectDetailsResponse.GetRawResponse().Content.ToString().Contains(testProjectName));
        }

        [RecordedTest]
        [AsyncOnly] // TODO: Remove once https://github.com/Azure/azure-sdk-for-net/issues/31325 is fixed.
        public async Task DeployProject()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            string sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
            RequestContent updateSourcesRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                displayName = "MicrosoftFAQ",
                                source = sourceUri,
                                sourceUri = sourceUri,
                                sourceKind = "url",
                                contentStructureKind = "unstructured",
                                refresh = false
                            }
                        }
                });

            Operation updateSourcesOperation = await Client.UpdateSourcesAsync(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);

            string testDeploymentName = "production";
            Operation deploymentOperation = await Client.DeployProjectAsync(WaitUntil.Completed, testProjectName, testDeploymentName);
            BinaryData deployment = deploymentOperation.GetRawResponse().Content;

            Assert.True(deploymentOperation.HasCompleted);
            Assert.That(deployment.ToString(), Contains.Substring(testDeploymentName));
        }

        [RecordedTest]
        [AsyncOnly] // TODO: Remove once https://github.com/Azure/azure-sdk-for-net/issues/31325 is fixed.
        public async Task UpdateQnAs()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            string question = "What is the easiest way to use azure services in my .NET project?";
            string answer = "Using Microsoft's Azure SDKs";
            RequestContent updateQnasRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                questions = new[]
                                    {
                                        question
                                    },
                                answer = answer
                            }
                        }
                });

            Operation updateQnasOperation = await Client.UpdateQnasAsync(WaitUntil.Completed, testProjectName, updateQnasRequestContent);
            BinaryData sources = updateQnasOperation.GetRawResponse().Content;

            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That(sources.ToString().Contains(question));
            Assert.That(sources.ToString().Contains(answer));
        }

        [RecordedTest]
        [AsyncOnly] // TODO: Remove once https://github.com/Azure/azure-sdk-for-net/issues/31325 is fixed.
        public async Task UpdateSources()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            string sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
            RequestContent updateSourcesRequestContent = RequestContent.Create(
                new[] {
                    new {
                            op = "add",
                            value = new
                            {
                                displayName = "MicrosoftFAQ",
                                source = sourceUri,
                                sourceUri = sourceUri,
                                sourceKind = "url",
                                contentStructureKind = "unstructured",
                                refresh = false
                            }
                        }
                });

            Operation updateSourcesOperation = await Client.UpdateSourcesAsync(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);
            BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.AreEqual(200, updateSourcesOperation.GetRawResponse().Status);
            Assert.That(sources.ToString().Contains(sourceUri));
        }

        [RecordedTest]
        public async Task Export()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            string exportFormat = "json";
            Operation exportOperation = await Client.ExportAsync(WaitUntil.Completed, testProjectName, exportFormat);

            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.GetRawResponse().Content);
            string exportedFileUrl = operationValueJson.RootElement.GetProperty("resultUrl").ToString();

            Assert.True(exportOperation.HasCompleted);
            Assert.AreEqual(200, exportOperation.GetRawResponse().Status);
            Assert.True(!String.IsNullOrEmpty(exportedFileUrl));
        }

        [RecordedTest]
        public async Task Import()
        {
            string testProjectName = CreateTestProjectName();
            string importFormat = "json";
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

            Operation importOperation = await Client.ImportAsync(WaitUntil.Completed, testProjectName, importRequestContent, importFormat);
            EnqueueProjectDeletion(testProjectName);

            Response<QuestionAnsweringProject> projectDetails = await Client.GetProjectDetailsAsync(testProjectName);

            Assert.True(importOperation.HasCompleted);
            Assert.AreEqual(200, importOperation.GetRawResponse().Status);
            Assert.AreEqual(200, projectDetails.GetRawResponse().Status);
            Assert.That(projectDetails.GetRawResponse().Content.ToString().Contains(testProjectName));
        }

        [RecordedTest]
        public async Task AddFeedback()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            RequestContent addFeedbackRequestContent = RequestContent.Create(
                new
                {
                    records = new[]
                    {
                        new
                        {
                            userId = "userX",
                            userQuestion = "what do you mean?",
                            qnaId = 1
                        }
                    }
                });

            Response addFeedbackResponse = await Client.AddFeedbackAsync(testProjectName, addFeedbackRequestContent);

            Assert.AreEqual(204, addFeedbackResponse.Status);
        }
    }
}
