// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering.Authoring;
using Azure.Core;
using System.Linq;
using Azure.AI.Language.QuestionAnswering.Authoring.Tests;
using Castle.Components.DictionaryAdapter.Xml;

namespace Azure.AI.Language.QuestionAnswering.Authoring.Tests.Samples
{
    public partial class QuestionAnsweringAuthoringClientSamples
    {
        [RecordedTest]
        [SyncOnly]
        public void KnowledgeSources()
        {
            QuestionAnsweringAuthoringClient client = Client;

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateSources_UpdateSample
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

            Operation updateSourcesOperation = client.UpdateSources(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);

            // Updated Knowledge Sources can be retrieved as follows
            BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

            Console.WriteLine($"Sources: {sources}");
            #endregion
            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.That(sources.ToString().Contains(sourceUri));

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateQnas

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

            Operation updateQnasOperation = Client.UpdateQnas(WaitUntil.Completed, testProjectName, updateQnasRequestContent);

            // QnAs can be retrieved as follows
            BinaryData qnas = updateQnasOperation.GetRawResponse().Content;

            Console.WriteLine($"Qnas: {qnas}");
            #endregion
            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That(qnas.ToString().Contains(question));
            Assert.That(qnas.ToString().Contains(answer));

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateSynonyms
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
            Pageable<WordAlterations> synonyms = Client.GetSynonyms(testProjectName);

            Console.WriteLine("Synonyms: ");
            foreach (WordAlterations synonym in synonyms)
            {
                Console.WriteLine(synonym);
            }
            #endregion

            Assert.AreEqual(204, updateSynonymsResponse.Status);
            Assert.That(synonyms.Any(synonym => synonym.ToString().Contains("qnamaker")));
            Assert.That(synonyms.Any(synonym => synonym.ToString().Contains("qna maker")));

            #region Snippet:QuestionAnsweringAuthoringClient_AddFeedback
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
            QuestionAnsweringAuthoringClient client = Client;

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateSourcesAsync_UpdateSample
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

            Operation updateSourcesOperation = await client.UpdateSourcesAsync(WaitUntil.Completed, testProjectName, updateSourcesRequestContent);

            // Updated Knowledge Sources can be retrieved as follows
            BinaryData sources = updateSourcesOperation.GetRawResponse().Content;

            Console.WriteLine($"Sources: {sources}");
            #endregion

            Assert.True(updateSourcesOperation.HasCompleted);
            Assert.That(sources.ToString().Contains(sourceUri));

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateQnasAsync
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

            Operation updateQnasOperation = await Client.UpdateQnasAsync(WaitUntil.Completed, testProjectName, updateQnasRequestContent);

            // QnAs can be retrieved as follows
            BinaryData qnas = updateQnasOperation.GetRawResponse().Content;

            Console.WriteLine($"Qnas: {qnas}");
            #endregion

            Assert.True(updateQnasOperation.HasCompleted);
            Assert.AreEqual(200, updateQnasOperation.GetRawResponse().Status);
            Assert.That(qnas.ToString().Contains(question));
            Assert.That(qnas.ToString().Contains(answer));

            #region Snippet:QuestionAnsweringAuthoringClient_UpdateSynonymsAsync
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
            AsyncPageable<WordAlterations> synonyms = Client.GetSynonymsAsync(testProjectName);

            Console.WriteLine("Synonyms: ");
            await foreach (WordAlterations synonym in synonyms)
            {
                Console.WriteLine(synonym);
            }
            #endregion

            Assert.AreEqual(204, updateSynonymsResponse.Status);
            Assert.That((await synonyms.ToEnumerableAsync()).Any(synonym => synonym.ToString().Contains("qnamaker")));
            Assert.That((await synonyms.ToEnumerableAsync()).Any(synonym => synonym.ToString().Contains("qna maker")));

            #region Snippet:QuestionAnsweringAuthoringClient_AddFeedbackAsync
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
