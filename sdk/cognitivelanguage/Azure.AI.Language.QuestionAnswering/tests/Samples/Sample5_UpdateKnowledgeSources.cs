// Copyright (c) Microsoft Corporation. All rights reserved.
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
        // TODO: Make this test Sync once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
        public async Task KnowledgeSources()
        {
            QuestionAnsweringProjectsClient client = Client;

            #region Snippet:QuestionAnsweringProjectsClient_UpdateSources_UpdateSample
            // Set request content parameters for updating our new project's sources
            string sourceUri = "{KnowledgeSourceUri}";
            string testProjectName = "{ProjectName}";
#if !SNIPPET
            sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
            testProjectName = CreateTestProjectName();
            CreateProject(testProjectName);
#endif
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

#if SNIPPET
            Operation<BinaryData> updateSourcesOperation = client.UpdateSources(waitForCompletion: false, testProjectName, updateSourcesRequestContent);
            updateSourcesOperation.WaitForCompletion();
#else
            // TODO: Remove this region once slowdown bug is fixed. https://github.com/Azure/azure-sdk-for-net/issues/26696
            Operation<BinaryData> updateSourcesOperation = InstrumentOperation(client.UpdateSources(WaitUntil.Started, testProjectName, updateSourcesRequestContent));
            await updateSourcesOperation.WaitForCompletionAsync();
#endif

            // Knowledge Sources can be retrieved as follows
            Pageable<BinaryData> sources = client.GetSources(testProjectName);
            Console.WriteLine("Sources: ");
            foreach (BinaryData source in sources)
            {
                Console.WriteLine(source);
            }
            #endregion

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.That(sources.Any(source => source.ToString().Contains(sourceUri)));

            #region Snippet:QuestionAnsweringProjectsClient_UpdateQnas

            string question = "{NewQuestion}";
            string answer = "{NewAnswer}";
#if !SNIPPET
            question = "What is the easiest way to use azure services in my .NET project?";
            answer = "Using Microsoft's Azure SDKs";
#endif
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

            Operation<BinaryData> updateQnasOperation = Client.UpdateQnas(WaitUntil.Completed, testProjectName, updateQnasRequestContent);

            // QnAs can be retrieved as follows
            Pageable<BinaryData> qnas = Client.GetQnas(testProjectName);

            Console.WriteLine("Qnas: ");
            foreach (var qna in qnas)
            {
                Console.WriteLine(qna);
            }
            #endregion

            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That(qnas.Any(qna => qna.ToString().Contains(question)));
            Assert.That(qnas.Any(qna => qna.ToString().Contains(answer)));

            #region Snippet:QuestionAnsweringProjectsClient_UpdateSynonyms
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

            Response updateSynonymsResponse = Client.UpdateSynonyms(testProjectName, updateSynonymsRequestContent);

            // Synonyms can be retrieved as follows
            Pageable<BinaryData> synonyms = Client.GetSynonyms(testProjectName);

            Console.WriteLine("Synonyms: ");
            foreach (BinaryData synonym in synonyms)
            {
                Console.WriteLine(synonym);
            }
            #endregion

            Assert.AreEqual(204, updateSynonymsResponse.Status);
            Assert.That(synonyms.Any(synonym => synonym.ToString().Contains("qnamaker")));
            Assert.That(synonyms.Any(synonym => synonym.ToString().Contains("qna maker")));

            #region Snippet:QuestionAnsweringProjectsClient_AddFeedback
            RequestContent addFeedbackRequestContent = RequestContent.Create(
                new
                {
                    records = new[]
                    {
                        new
                        {
                            userId = "userX",
                            userQuestion = "{Follow-up Question}",
                            qnaId = 1
                        }
                    }
                });

            Response addFeedbackResponse = Client.AddFeedback(testProjectName, addFeedbackRequestContent);
            #endregion

            Assert.AreEqual(204, addFeedbackResponse.Status);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task KnowledgeSourcesAsync()
        {
            QuestionAnsweringProjectsClient client = Client;

            #region Snippet:QuestionAnsweringProjectsClient_UpdateSourcesAsync_UpdateSample
            // Set request content parameters for updating our new project's sources
            string sourceUri = "{KnowledgeSourceUri}";
            string testProjectName = "{ProjectName}";
#if !SNIPPET
            sourceUri = "https://www.microsoft.com/en-in/software-download/faq";
            testProjectName = CreateTestProjectName();
            await CreateProjectAsync(testProjectName);
#endif
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

            Operation<BinaryData> updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Started, testProjectName, updateSourcesRequestContent);
            await updateSourcesOperation.WaitForCompletionAsync();

            // Wait for operation completion
            Response<BinaryData> updateSourcesOperationResult = await updateSourcesOperation.WaitForCompletionAsync();

            Console.WriteLine($"Update Sources operation result: \n{updateSourcesOperationResult}");

            // Knowledge Sources can be retrieved as follows
            AsyncPageable<BinaryData> sources = client.GetSourcesAsync(testProjectName);
            Console.WriteLine("Sources: ");
            await foreach (BinaryData source in sources)
            {
                Console.WriteLine(source);
            }
            #endregion

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.That((await sources.ToEnumerableAsync()).Any(source => source.ToString().Contains(sourceUri)));

            #region Snippet:QuestionAnsweringProjectsClient_UpdateQnasAsync
            string question = "{NewQuestion}";
            string answer = "{NewAnswer}";
#if !SNIPPET
            question = "What is the easiest way to use azure services in my .NET project?";
            answer = "Using Microsoft's Azure SDKs";
#endif
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

            Operation<BinaryData> updateQnasOperation = await Client.UpdateQnasAsync(WaitUntil.Completed, testProjectName, updateQnasRequestContent);
            await updateQnasOperation.WaitForCompletionAsync();

            // QnAs can be retrieved as follows
            AsyncPageable<BinaryData> qnas = Client.GetQnasAsync(testProjectName);

            Console.WriteLine("Qnas: ");
            await foreach (var qna in qnas)
            {
                Console.WriteLine(qna);
            }
            #endregion

            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That((await qnas.ToEnumerableAsync()).Any(source => source.ToString().Contains(question)));
            Assert.That((await qnas.ToEnumerableAsync()).Any(source => source.ToString().Contains(answer)));

            #region Snippet:QuestionAnsweringProjectsClient_UpdateSynonymsAsync
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

            Console.WriteLine("Synonyms: ");
            await foreach (BinaryData synonym in synonyms)
            {
                Console.WriteLine(synonym);
            }
            #endregion

            Assert.AreEqual(204, updateSynonymsResponse.Status);
            Assert.That((await synonyms.ToEnumerableAsync()).Any(synonym => synonym.ToString().Contains("qnamaker")));
            Assert.That((await synonyms.ToEnumerableAsync()).Any(synonym => synonym.ToString().Contains("qna maker")));

            #region Snippet:QuestionAnsweringProjectsClient_AddFeedbackAsync
            RequestContent addFeedbackRequestContent = RequestContent.Create(
                new
                {
                    records = new[]
                    {
                        new
                        {
                            userId = "userX",
                            userQuestion = "{Follow-up question}",
                            qnaId = 1
                        }
                    }
                });

            Response addFeedbackResponse = await Client.AddFeedbackAsync(testProjectName, addFeedbackRequestContent);
            #endregion

            Assert.AreEqual(204, addFeedbackResponse.Status);
        }
    }
}
