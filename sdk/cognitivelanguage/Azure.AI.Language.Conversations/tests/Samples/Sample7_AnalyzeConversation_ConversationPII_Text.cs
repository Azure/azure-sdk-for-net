// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public void AnalyzeConversation_ConversationPII_Text()
        {
            ConversationAnalysisClient client = Client;
            List<string> expectedRedactedText = new();

            #region Snippet:AnalyzeConversation_ConversationPII_Text
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
                                    text = "Hi, I am John Doe.",
                                    id = "1",
                                    participantId = "0",
                                },
                                new
                                {
                                    text = "Hi John, how are you doing today?",
                                    id = "2",
                                    participantId = "1",
                                },
                                new
                                {
                                    text = "Pretty good.",
                                    id = "3",
                                    participantId = "0",
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
                            piiCategories = new[]
                            {
                                "All",
                            },
                            includeAudioRedaction = false,
                            modelVersion = "2022-05-15-preview",
                            loggingOptOut = false,
                        },
                        kind = "ConversationalPIITask",
                        taskName = "analyze",
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

            using JsonDocument result = JsonDocument.Parse(analyzeConversationOperation.Value.ToStream());
            JsonElement jobResults = result.RootElement;
            foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
            {
                JsonElement results = task.GetProperty("results");

                Console.WriteLine("Conversations:");
                foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
                {
                    Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
                    Console.WriteLine("Conversation Items:");
                    foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");

                        Console.WriteLine($"Redacted Text: {conversationItem.GetProperty("redactedContent").GetProperty("text").GetString()}");
#if !SNIPPET
                        expectedRedactedText.Add(conversationItem.GetProperty("redactedContent").GetProperty("text").GetString());
#endif

                        Console.WriteLine("Entities:");
                        foreach (JsonElement entity in conversationItem.GetProperty("entities").EnumerateArray())
                        {
                            Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                            Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                            Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                            Console.WriteLine($"Confidence Score: {entity.GetProperty("confidenceScore").GetSingle()}");
                            Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(expectedRedactedText, Is.EqualTo(new[] { "Hi, I am ********.", "Hi ****, how are you doing today?", "Pretty good." }));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationPII_Text()
        {
            ConversationAnalysisClient client = Client;
            List<string> expectedRedactedText = new();

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
                                    text = "Hi, I am John Doe.",
                                    id = "1",
                                    participantId = "0",
                                },
                                new
                                {
                                    text = "Hi John, how are you doing today?",
                                    id = "2",
                                    participantId = "1",
                                },
                                new
                                {
                                    text = "Pretty good.",
                                    id = "3",
                                    participantId = "0",
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
                            piiCategories = new[]
                            {
                                "All",
                            },
                            includeAudioRedaction = false,
                            modelVersion = "2022-05-15-preview",
                            loggingOptOut = false,
                        },
                        kind = "ConversationalPIITask",
                        taskName = "analyze",
                    },
                },
            };

            #region Snippet:AnalyzeConversationAsync_ConversationPII_Text
            Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
            #endregion

            using JsonDocument result = await JsonDocument.ParseAsync(analyzeConversationOperation.Value.ToStream());
            JsonElement jobResults = result.RootElement;
            foreach (JsonElement task in jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray())
            {
                JsonElement results = task.GetProperty("results");

                Console.WriteLine("Conversations:");
                foreach (JsonElement conversation in results.GetProperty("conversations").EnumerateArray())
                {
                    Console.WriteLine($"Conversation: #{conversation.GetProperty("id").GetString()}");
                    Console.WriteLine("Conversation Items:");
                    foreach (JsonElement conversationItem in conversation.GetProperty("conversationItems").EnumerateArray())
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.GetProperty("id").GetString()}");

                        Console.WriteLine($"Redacted Text: {conversationItem.GetProperty("redactedContent").GetProperty("text").GetString()}");
#if !SNIPPET
                        expectedRedactedText.Add(conversationItem.GetProperty("redactedContent").GetProperty("text").GetString());
#endif

                        Console.WriteLine("Entities:");
                        foreach (JsonElement entity in conversationItem.GetProperty("entities").EnumerateArray())
                        {
                            Console.WriteLine($"Text: {entity.GetProperty("text").GetString()}");
                            Console.WriteLine($"Offset: {entity.GetProperty("offset").GetInt32()}");
                            Console.WriteLine($"Category: {entity.GetProperty("category").GetString()}");
                            Console.WriteLine($"Confidence Score: {entity.GetProperty("confidenceScore").GetSingle()}");
                            Console.WriteLine($"Length: {entity.GetProperty("length").GetInt32()}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }

            Assert.That(expectedRedactedText, Is.EqualTo(new[] { "Hi, I am ********.", "Hi ****, how are you doing today?", "Pretty good." }));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
