// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Castle.Core.Internal;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/29140")]
        public void SubmitJob_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:SubmitJob_ConversationSummarization_Input
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
                                    participantId = "Agent",
                                },
                                new
                                {
                                    text = "How to upgrade Office? I am getting error messages the whole day.",
                                    id = "2",
                                    participantId = "Customer",
                                },
                                new
                                {
                                    text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    id = "3",
                                    participantId = "Agent",
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
                        parameters = new
                        {
                            summaryAspects = new[]
                            {
                                "issue",
                                "resolution",
                            }
                        },
                        kind = "ConversationalSummarizationTask",
                        taskName = "1",
                    },
                },
            };
            #endregion

            #region Snippet:SubmitJob_StartAnalayzing
            Operation<BinaryData> analyzeConversationOperation = client.SubmitJob(WaitUntil.Started, RequestContent.Create(data));
            analyzeConversationOperation.WaitForCompletion();
            #endregion

            #region Snippet:SubmitJob_ConversationSummarization_Results
            using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
            JsonElement jobResults = result.RootElement;
            foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
            {
                JsonElement results = task.GetProperty("results");

                Console.WriteLine("Conversations:");
                foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
                {
                    Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
                    Console.WriteLine("Summaries:");
                    foreach (JsonElement summary in conversation.GetProperty("summaries").EnumerateArray())
                    {
                        Console.WriteLine($"Text: {summary.GetProperty("text").GetString()}");
                        Console.WriteLine($"Aspect: {summary.GetProperty("aspect").GetString()}");
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray().All(item => item.GetProperty("results").GetProperty("errors").EnumerateArray().IsNullOrEmpty()));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task SubmitJobAsync_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;

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
                                    participantId = "Agent",
                                },
                                new
                                {
                                    text = "How to upgrade Office? I am getting error messages the whole day.",
                                    id = "2",
                                    participantId = "Customer",
                                },
                                new
                                {
                                    text = "Press the upgrade button please. Then sign in and follow the instructions.",
                                    id = "3",
                                    participantId = "Agent",
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
                        parameters = new
                        {
                            summaryAspects = new[]
                            {
                                "issue",
                                "resolution",
                            }
                        },
                        kind = "ConversationalSummarizationTask",
                        taskName = "1",
                    },
                },
            };

            #region Snippet:SubmitJobAsync_StartAnalayzing
            Operation<BinaryData> analyzeConversationOperation = await client.SubmitJobAsync(WaitUntil.Started, RequestContent.Create(data));
            await analyzeConversationOperation.WaitForCompletionAsync();
            #endregion

            using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
            JsonElement jobResults = result.RootElement;
            foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
            {
                JsonElement results = task.GetProperty("results");

                Console.WriteLine("Conversations:");
                foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
                {
                    Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
                    Console.WriteLine("Summaries:");
                    foreach (JsonElement summary in conversation.GetProperty("summaries").EnumerateArray())
                    {
                        Console.WriteLine($"Text: {summary.GetProperty("text").GetString()}");
                        Console.WriteLine($"Aspect: {summary.GetProperty("aspect").GetString()}");
                    }
                    Console.WriteLine();
                }
            }

            Assert.That(jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray().All(item => item.GetProperty("results").GetProperty("errors").EnumerateArray().IsNullOrEmpty()));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
