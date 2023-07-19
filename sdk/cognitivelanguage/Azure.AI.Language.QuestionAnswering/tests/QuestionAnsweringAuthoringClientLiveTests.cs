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

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    public class QuestionAnsweringAuthoringClientLiveTests : QuestionAnsweringAuthoringLiveTestBase
    {
        public QuestionAnsweringAuthoringClientLiveTests(bool isAsync, QuestionAnsweringClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task SupportsAadAuthentication()
        {
            QuestionAnsweringAuthoringClient client = CreateClient<QuestionAnsweringAuthoringClient>(
               TestEnvironment.Endpoint,
               TestEnvironment.Credential,
               InstrumentClientOptions(
                    new QuestionAnsweringClientOptions()));

            string testProjectName = CreateTestProjectName();

            Response createProjectResponse = await CreateProjectAsync(testProjectName);
            Response projectDetailsResponse = await client.GetProjectDetailsAsync(testProjectName);

            Assert.AreEqual(201, createProjectResponse.Status);
            Assert.AreEqual(200, projectDetailsResponse.Status);

            await client.DeleteProjectAsync(WaitUntil.Completed, testProjectName);
        }

        [RecordedTest]
        public async Task CreateProject()
        {
            string testProjectName = CreateTestProjectName();
            Response createProjectResponse = await CreateProjectAsync(testProjectName);
            AsyncPageable<BinaryData> projects = Client.GetProjectsAsync();
            Response projectDetailsResponse = await Client.GetProjectDetailsAsync(testProjectName);

            Assert.AreEqual(201, createProjectResponse.Status);
            Assert.AreEqual(200, projectDetailsResponse.Status);
            Assert.That((await projects.ToEnumerableAsync()).Any(project => project.ToString().Contains(testProjectName)));
            Assert.That(projectDetailsResponse.Content.ToString().Contains(testProjectName));
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

            Operation<AsyncPageable<BinaryData>> updateSourcesOperation = await Client.UpdateSourcesAsync(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);

            string testDeploymentName = "production";
            Operation<BinaryData> deploymentOperation = await Client.DeployProjectAsync(WaitUntil.Completed, testProjectName, testDeploymentName);
            BinaryData deployment = deploymentOperation.Value;

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

            Operation<AsyncPageable<BinaryData>> updateQnasOperation = await Client.UpdateQnasAsync(WaitUntil.Completed, testProjectName, updateQnasRequestContent);
            AsyncPageable<BinaryData> sources = updateQnasOperation.Value;

            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(question)));
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(answer)));
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

            Operation<AsyncPageable<BinaryData>> updateSourcesOperation = await Client.UpdateSourcesAsync(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);
            AsyncPageable<BinaryData> sources = updateSourcesOperation.Value;

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.AreEqual(200, updateSourcesOperation.GetRawResponse().Status);
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(sourceUri)));
        }

        [RecordedTest]
        public async Task UpdateSynonyms()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            RequestContent updateSynonymsRequestContent = RequestContent.Create(
                new
                {
                    value = new[] {
                        new  {
                                alterations = new[]
                                {
                                    "qnamaker",
                                    "qna maker",
                                }
                             },
                        new  {
                                alterations = new[]
                                {
                                    "qna",
                                    "question and answer",
                                }
                             }
                    }
                });

            Response updateSynonymsResponse = await Client.UpdateSynonymsAsync(testProjectName, updateSynonymsRequestContent);

            // Synonyms can be retrieved as follows
            AsyncPageable<BinaryData> synonyms = Client.GetSynonymsAsync(testProjectName);

            Assert.AreEqual(204, updateSynonymsResponse.Status);
            Assert.That((await synonyms.ToEnumerableAsync()).Any(synonym => synonym.ToString().Contains("qnamaker")));
            Assert.That((await synonyms.ToEnumerableAsync()).Any(synonym => synonym.ToString().Contains("qna")));
        }

        [RecordedTest]
        public async Task Export()
        {
            string testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);

            string exportFormat = "json";
            Operation<BinaryData> exportOperation = await Client.ExportAsync(WaitUntil.Completed, testProjectName, exportFormat);

            JsonDocument operationValueJson = JsonDocument.Parse(exportOperation.Value);
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

            Operation<BinaryData> importOperation = await Client.ImportAsync(WaitUntil.Completed, testProjectName, importRequestContent, importFormat);
            EnqueueProjectDeletion(testProjectName);

            Response projectDetails = await Client.GetProjectDetailsAsync(testProjectName);

            Assert.True(importOperation.HasCompleted);
            Assert.AreEqual(200, importOperation.GetRawResponse().Status);
            Assert.AreEqual(200, projectDetails.Status);
            Assert.That(projectDetails.Content.ToString().Contains(testProjectName));
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
