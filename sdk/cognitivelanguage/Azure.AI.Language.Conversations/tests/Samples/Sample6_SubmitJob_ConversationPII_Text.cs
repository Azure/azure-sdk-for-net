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
        public void SubmitJob_ConversationPII_Text()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:SubmitJob_ConversationPII_Text_Input
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
            #endregion

            Operation<BinaryData> analyzeConversationOperation = client.SubmitJob(WaitUntil.Started, RequestContent.Create(data));
            analyzeConversationOperation.WaitForCompletion();

            #region Snippet:SubmitJob_ConversationPII_Text_Results
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

            Assert.That(jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray().All(item => item.GetProperty("results").GetProperty("errors").EnumerateArray().IsNullOrEmpty()));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task SubmitJobAsync_ConversationPII_Text()
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

            Operation<BinaryData> analyzeConversationOperation = await client.SubmitJobAsync(WaitUntil.Started, RequestContent.Create(data));
            await analyzeConversationOperation.WaitForCompletionAsync();

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

            Assert.That(jobResults.GetProperty("tasks").GetProperty("items").EnumerateArray().All(item => item.GetProperty("results").GetProperty("errors").EnumerateArray().IsNullOrEmpty()));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
