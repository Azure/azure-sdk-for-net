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

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (dynamic task in jobResults.tasks.items)
            {
                dynamic results = task.results;

                Console.WriteLine("Conversations:");
                foreach (dynamic conversation in results.conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.id}");
                    Console.WriteLine("Conversation Items:");
                    foreach (dynamic conversationItem in conversation.conversationItems)
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.id}");

                        Console.WriteLine($"Redacted Text: {conversationItem.redactedContent.text}");
#if !SNIPPET
                        expectedRedactedText.Add(conversationItem.redactedContent.text);
#endif

                        Console.WriteLine("Entities:");
                        foreach (dynamic entity in conversationItem.entities)
                        {
                            Console.WriteLine($"Text: {entity.text}");
                            Console.WriteLine($"Offset: {entity.offset}");
                            Console.WriteLine($"Category: {entity.category}");
                            Console.WriteLine($"Confidence Score: {entity.confidenceScore}");
                            Console.WriteLine($"Length: {entity.length}");
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

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (dynamic task in jobResults.tasks.items)
            {
                dynamic results = task.results;

                Console.WriteLine("Conversations:");
                foreach (dynamic conversation in results.conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.id}");
                    Console.WriteLine("Conversation Items:");
                    foreach (dynamic conversationItem in conversation.conversationItems)
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.id}");

                        Console.WriteLine($"Redacted Text: {conversationItem.redactedContent.text}");
#if !SNIPPET
                        expectedRedactedText.Add(conversationItem.redactedContent.text);
#endif

                        Console.WriteLine("Entities:");
                        foreach (dynamic entity in conversationItem.entities)
                        {
                            Console.WriteLine($"Text: {entity.text}");
                            Console.WriteLine($"Offset: {entity.offset}");
                            Console.WriteLine($"Category: {entity.category}");
                            Console.WriteLine($"Confidence Score: {entity.confidenceScore}");
                            Console.WriteLine($"Length: {entity.length}");
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
