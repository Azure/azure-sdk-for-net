// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public void AnalyzeConversation_ConversationSentiment()
        {
            ConversationAnalysisClient client = Client;
            List<string> expectedSentiments = new();

            #region Snippet:AnalyzeConversation_ConversationSentiment
            var data = new
            {
                displayName = "Sentiment analysis from a call center conversation",
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            id = "1",
                            language = "en",
                            modality = "transcript",
                            conversationItems = new[]
                            {
                                new
                                {
                                    participantId = "1",
                                    id = "1",
                                    text = "I like the service. I do not like the food",
                                    lexical = "i like the service i do not like the food",
                                    itn = "",
                                    maskedItn = "",
                                }
                            },
                        },
                    }
                },
                tasks = new[]
                {
                    new
                    {
                        taskName = "Conversation Sentiment Analysis",
                        kind = "ConversationalSentimentTask",
                        parameters = new
                        {
                            modelVersion = "latest",
                            predictionSource = "text",
                        },
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

            using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
            JsonElement jobResults = result.RootElement;
            foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
            {
                Console.WriteLine($"Task name: {task.GetProperty("taskName").GetString()}");
                JsonElement results = task.GetProperty("results");
                foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
                {
                    Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
                    Console.WriteLine("Conversation Items:");
                    foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");
                        Console.WriteLine($"Sentiment: {conversationItem.GetProperty("sentiment").GetString()}");

                        JsonElement confidenceScores = conversationItem.GetProperty("confidenceScores");
                        Console.WriteLine($"Positive: {confidenceScores.GetProperty("positive").GetSingle()}");
                        Console.WriteLine($"Neutral: {confidenceScores.GetProperty("neutral").GetSingle()}");
                        Console.WriteLine($"Negative: {confidenceScores.GetProperty("negative").GetSingle()}");
#if !SNIPPET
                        expectedSentiments.Add(conversationItem.GetProperty("sentiment").GetString());
#endif
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(expectedSentiments, Has.All.EqualTo("mixed"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeConversationAsync_ConversationSentiment()
        {
            ConversationAnalysisClient client = Client;
            List<string> expectedSentiments = new();

            var data = new
            {
                displayName = "Sentiment analysis from a call center conversation",
                analysisInput = new
                {
                    conversations = new[]
                    {
                        new
                        {
                            id = "1",
                            language = "en",
                            modality = "transcript",
                            conversationItems = new[]
                            {
                                new
                                {
                                    participantId = "1",
                                    id = "1",
                                    text = "I like the service. I do not like the food",
                                    lexical = "i like the service i do not like the food",
                                    itn = "",
                                    maskedItn = "",
                                }
                            },
                        },
                    }
                },
                tasks = new[]
                {
                    new
                    {
                        taskName = "Conversation Sentiment Analysis",
                        kind = "ConversationalSentimentTask",
                        parameters = new
                        {
                            modelVersion = "latest",
                            predictionSource = "text",
                        },
                    },
                },
            };

            #region Snippet:AnalyzeConversationAsync_ConversationSentiment
            Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
            #endregion

            using JsonDocument result = await JsonDocument.ParseAsync(analyzeConversationOperation.Value.ToStream());
            JsonElement jobResults = result.RootElement;
            foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
            {
                Console.WriteLine($"Task name: {task.GetProperty("taskName").GetString()}");
                JsonElement results = task.GetProperty("results");
                foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
                {
                    Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
                    Console.WriteLine("Conversation Items:");
                    foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");
                        Console.WriteLine($"Sentiment: {conversationItem.GetProperty("sentiment").GetString()}");

                        JsonElement confidenceScores = conversationItem.GetProperty("confidenceScores");
                        Console.WriteLine($"Positive: {confidenceScores.GetProperty("positive").GetSingle()}");
                        Console.WriteLine($"Neutral: {confidenceScores.GetProperty("neutral").GetSingle()}");
                        Console.WriteLine($"Negative: {confidenceScores.GetProperty("negative").GetSingle()}");
#if !SNIPPET
                        expectedSentiments.Add(conversationItem.GetProperty("sentiment").GetString());
#endif
                    }
                    Console.WriteLine();
                }
            }

            Assert.That(expectedSentiments, Has.All.EqualTo("mixed"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
