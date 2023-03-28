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

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (dynamic task in jobResults.tasks.items)
            {
                Console.WriteLine($"Task name: {task.taskName}");
                dynamic results = task.results;
                foreach (dynamic conversation in results.conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.id}");
                    Console.WriteLine("Conversation Items:");
                    foreach (dynamic conversationItem in conversation.conversationItems)
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.id}");
                        Console.WriteLine($"Sentiment: {conversationItem.sentiment}");

                        dynamic confidenceScores = conversationItem.confidenceScores;
                        Console.WriteLine($"Positive: {confidenceScores.positive}");
                        Console.WriteLine($"Neutral: {confidenceScores.neutral}");
                        Console.WriteLine($"Negative: {confidenceScores.negative}");
#if !SNIPPET
                        expectedSentiments.Add(conversationItem.sentiment);
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

            dynamic jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (dynamic task in jobResults.tasks.items)
            {
                Console.WriteLine($"Task name: {task.taskName}");
                dynamic results = task.results;
                foreach (dynamic conversation in results.conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.id}");
                    Console.WriteLine("Conversation Items:");
                    foreach (dynamic conversationItem in conversation.conversationItems)
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.id}");
                        Console.WriteLine($"Sentiment: {conversationItem.sentiment}");

                        dynamic confidenceScores = conversationItem.confidenceScores;
                        Console.WriteLine($"Positive: {confidenceScores.positive}");
                        Console.WriteLine($"Neutral: {confidenceScores.neutral}");
                        Console.WriteLine($"Negative: {confidenceScores.negative}");
#if !SNIPPET
                        expectedSentiments.Add(conversationItem.sentiment);
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
