// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2023_04_01)]
        public void AnalyzeConversation_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;
            List<string> aspects = new();

            #region Snippet:AnalyzeConversation_ConversationSummarization
            var data = new
            {
                AnalysisInput = new
                {
                    Conversations = new[]
                    {
                        new
                        {
                            ConversationItems = new[]
                            {
                                new
                                {
                                    Text = "Hello, how can I help you?",
                                    Id = "1",
                                    Role = "Agent",
                                    ParticipantId = "Agent_1",
                                },
                                new
                                {
                                    Text = "How to upgrade Office? I am getting error messages the whole day.",
                                    Id = "2",
                                    Role = "Customer",
                                    ParticipantId = "Customer_1",
                                },
                                new
                                {
                                    Text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    Id = "3",
                                    Role = "Agent",
                                    ParticipantId = "Agent_1",
                                },
                            },
                            Id = "1",
                            Language = "en",
                            Modality = "text",
                        },
                    }
                },
                Tasks = new[]
                {
                    new
                    {
                        TaskName = "Issue task",
                        Kind = "ConversationalSummarizationTask",
                        Parameters = new
                        {
                            SummaryAspects = new[]
                            {
                                "issue",
                            }
                        },
                    },
                    new
                    {
                        TaskName = "Resolution task",
                        Kind = "ConversationalSummarizationTask",
                        Parameters = new
                        {
                            SummaryAspects = new[]
                            {
                                "resolution",
                            }
                        },
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversations(WaitUntil.Completed, RequestContent.Create(data, JsonPropertyNames.CamelCase));

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            foreach (dynamic task in jobResults.Tasks.Items)
            {
                Console.WriteLine($"Task name: {task.TaskName}");
                dynamic results = task.Results;
                foreach (dynamic conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (dynamic summary in conversation.Summaries)
                    {
                        Console.WriteLine($"Text: {summary.Text}");
                        Console.WriteLine($"Aspect: {summary.Aspect}");
#if !SNIPPET
                        aspects.Add(summary.Aspect);
#endif
                    }
                    if (results.Warnings != null)
                    {
                        Console.WriteLine("Warnings:");
                        foreach (dynamic warning in conversation.Warnings)
                        {
                            Console.WriteLine($"Code: {warning.Code}");
                            Console.WriteLine($"Message: {warning.Message}");
                        }
                    }
                    Console.WriteLine();
                }
                if (results.Errors != null)
                {
                    Console.WriteLine("Errors:");
                    foreach (dynamic error in results.Errors)
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
            }
            #endregion

            Assert.That(aspects, Contains.Item("issue").And.Contains("resolution"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeConversationAsync_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;
            List<string> aspects = new();

            var data = new
            {
                AnalysisInput = new
                {
                    Conversations = new[]
                    {
                        new
                        {
                            ConversationItems = new[]
                            {
                                new
                                {
                                    Text = "Hello, how can I help you?",
                                    Id = "1",
                                    Role = "Agent",
                                    ParticipantId = "Agent_1",
                                },
                                new
                                {
                                    Text = "How to upgrade Office? I am getting error messages the whole day.",
                                    Id = "2",
                                    Role = "Customer",
                                    ParticipantId = "Customer_1",
                                },
                                new
                                {
                                    Text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    Id = "3",
                                    Role = "Agent",
                                    ParticipantId = "Agent_1",
                                },
                            },
                            Id = "1",
                            Language = "en",
                            Modality = "text",
                        },
                    }
                },
                Tasks = new[]
                {
                    new
                    {
                        TaskName = "Issue task",
                        Kind = "ConversationalSummarizationTask",
                        Parameters = new
                        {
                            SummaryAspects = new[]
                            {
                                "issue",
                            }
                        },
                    },
                    new
                    {
                        TaskName = "Resolution task",
                        Kind = "ConversationalSummarizationTask",
                        Parameters = new
                        {
                            SummaryAspects = new[]
                            {
                                "resolution",
                            }
                        },
                    },
                },
            };

            #region Snippet:AnalyzeConversationAsync_ConversationSummarization
            Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationsAsync(WaitUntil.Completed, RequestContent.Create(data, JsonPropertyNames.CamelCase));
            #endregion

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            foreach (dynamic task in jobResults.Tasks.Items)
            {
                Console.WriteLine($"Task name: {task.TaskName}");
                dynamic results = task.Results;
                foreach (dynamic conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (dynamic summary in conversation.Summaries)
                    {
                        Console.WriteLine($"Text: {summary.Text}");
                        Console.WriteLine($"Aspect: {summary.Aspect}");
#if !SNIPPET
                        aspects.Add(summary.Aspect);
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