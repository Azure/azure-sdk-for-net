// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Dynamic;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public void AnalyzeConversation_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;
            List<string> aspects = new();

            #region Snippet:AnalyzeConversation_ConversationSummarization
            var data = new
            {
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            conversationItems = new[]
                            {
                                new
                                {
                                    text = "Hello, how can I help you?",
                                    id = "1",
                                    role = "Agent",
                                    participantId = "Agent_1",
                                },
                                new
                                {
                                    text = "How to upgrade Office? I am getting error messages the whole day.",
                                    id = "2",
                                    role = "Customer",
                                    participantId = "Customer_1",
                                },
                                new
                                {
                                    text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    id = "3",
                                    role = "Agent",
                                    participantId = "Agent_1",
                                },
                            },
                            id = "1",
                            language = "en",
                            modality = "text",
                        },
                    }
                },
                tasks = new[]
                {
                    new
                    {
                        taskName = "Issue task",
                        kind = "ConversationalSummarizationTask",
                        parameters = new
                        {
                            summaryAspects = new[]
                            {
                                "issue",
                            }
                        },
                    },
                    new
                    {
                        taskName = "Resolution task",
                        kind = "ConversationalSummarizationTask",
                        parameters = new
                        {
                            summaryAspects = new[]
                            {
                                "resolution",
                            }
                        },
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (dynamic task in jobResults.tasks.items)
            {
                Console.WriteLine($"Task name: {task.taskName}");
                dynamic results = task.results;
                foreach (dynamic conversation in results.conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.id}");
                    Console.WriteLine("Summaries:");
                    foreach (dynamic summary in conversation.summaries)
                    {
                        Console.WriteLine($"Text: {summary.text}");
                        Console.WriteLine($"Aspect: {summary.aspect}");
#if !SNIPPET
                        aspects.Add(summary.aspect);
#endif
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(aspects, Contains.Item("issue").And.Contains("resolution"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;
            List<string> aspects = new();

            var data = new
            {
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            conversationItems = new[]
                            {
                                new
                                {
                                    text = "Hello, how can I help you?",
                                    id = "1",
                                    role = "Agent",
                                    participantId = "Agent_1",
                                },
                                new
                                {
                                    text = "How to upgrade Office? I am getting error messages the whole day.",
                                    id = "2",
                                    role = "Customer",
                                    participantId = "Customer_1",
                                },
                                new
                                {
                                    text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    id = "3",
                                    role = "Agent",
                                    participantId = "Agent_1",
                                },
                            },
                            id = "1",
                            language = "en",
                            modality = "text",
                        },
                    }
                },
                tasks = new[]
                {
                    new
                    {
                        taskName = "Issue task",
                        kind = "ConversationalSummarizationTask",
                        parameters = new
                        {
                            summaryAspects = new[]
                            {
                                "issue",
                            }
                        },
                    },
                    new
                    {
                        taskName = "Resolution task",
                        kind = "ConversationalSummarizationTask",
                        parameters = new
                        {
                            summaryAspects = new[]
                            {
                                "resolution",
                            }
                        },
                    },
                },
            };

            #region Snippet:AnalyzeConversationAsync_ConversationSummarization
            Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
            #endregion

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (dynamic task in jobResults.tasks.items)
            {
                Console.WriteLine($"Task name: {task.taskName}");
                dynamic results = task.results;
                foreach (dynamic conversation in results.conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.id}");
                    Console.WriteLine("Summaries:");
                    foreach (dynamic summary in conversation.summaries)
                    {
                        Console.WriteLine($"Text: {summary.text}");
                        Console.WriteLine($"Aspect: {summary.aspect}");
#if !SNIPPET
                        aspects.Add(summary.aspect);
#endif
                    }
                    Console.WriteLine();
                }
            }

            Assert.That(aspects, Contains.Item("issue").And.Contains("resolution"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
