// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public void AnalyzeConversation_ConversationPII_Transcript()
        {
            ConversationAnalysisClient client = Client;
            List<string> expectedRedactedText = new();

            #region Snippet:AnalyzeConversation_ConversationPII_Transcript
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
                                    itn = "hi",
                                    maskedItn = "hi",
                                    text = "Hi",
                                    lexical = "hi",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "hi",
                                            offset = 4500000,
                                            duration = 2800000,
                                        },
                                    },
                                    id = "1",
                                    participantId = "speaker",
                                },
                                new
                                {
                                    itn = "jane doe",
                                    maskedItn = "jane doe",
                                    text = "Jane Doe",
                                    lexical = "jane doe",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "jane",
                                            offset = 7100000,
                                            duration = 4800000,
                                        },
                                        new
                                        {
                                            word = "doe",
                                            offset = 12000000,
                                            duration = 1700000,
                                        },
                                    },
                                    id = "3",
                                    participantId = "agent",
                                },
                                new
                                {
                                    itn = "hi jane what's your phone number",
                                    maskedItn = "hi jane what's your phone number",
                                    text = "Hi Jane, what's your phone number?",
                                    lexical = "hi jane what's your phone number",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                          word = "hi",
                                          offset = 7700000,
                                          duration= 3100000,
                                        },
                                        new
                                        {
                                          word= "jane",
                                          offset= 10900000,
                                          duration= 5700000,
                                        },
                                        new
                                        {
                                          word= "what's",
                                          offset= 17300000,
                                          duration= 2600000,
                                        },
                                        new
                                        {
                                          word= "your",
                                          offset= 20000000,
                                          duration= 1600000,
                                        },
                                        new
                                        {
                                          word= "phone",
                                          offset= 21700000,
                                          duration= 1700000,
                                        },
                                        new
                                        {
                                          word= "number",
                                          offset= 23500000,
                                          duration= 2300000,
                                        },
                                    },
                                    id = "2",
                                    participantId = "speaker",
                                },
                            },
                            id = "1",
                            language = "en",
                            modality = "transcript",
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
                            redactionSource = "lexical",
                            modelVersion = "2022-05-15-preview",
                            loggingOptOut = false,
                        },
                        kind = "ConversationalPIITask",
                        taskName = "analyze",
                    },
                },
            };

            Operation<BinaryData> analyzeConversationOperation = client.AnalyzeConversation(WaitUntil.Completed, RequestContent.Create(data));

            var jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (var task in jobResults.Tasks.Items)
            {
                var results = task.Results;

                Console.WriteLine("Conversations:");
                foreach (var conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Conversation Items:");
                    foreach (var conversationItem in conversation.ConversationItems)
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.Id}");

                        var redactedContent = conversationItem.RedactedContent;
                        Console.WriteLine($"Redacted Text: {redactedContent.Text}");
                        Console.WriteLine($"Redacted Lexical: {redactedContent.Lexical}");
                        Console.WriteLine($"Redacted MaskedItn: {redactedContent.MaskedItn}");
#if !SNIPPET
                        expectedRedactedText.Add((string)redactedContent.Text);
#endif

                        Console.WriteLine("Entities:");
                        foreach (var entity in conversationItem.Entities)
                        {
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
                            Console.WriteLine($"Length: {entity.Length}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
            #endregion

            Assert.That(expectedRedactedText, Is.EqualTo(new[] { "Hi", "**** Doe", "Hi ****, what's your phone number?" }));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2022_05_15_Preview)]
        public async Task AnalyzeConversationAsync_ConversationPII_Transcript()
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
                                    itn = "hi",
                                    maskedItn = "hi",
                                    text = "Hi",
                                    lexical = "hi",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "hi",
                                            offset = 4500000,
                                            duration = 2800000,
                                        },
                                    },
                                    id = "1",
                                    participantId = "speaker",
                                },
                                new
                                {
                                    itn = "jane doe",
                                    maskedItn = "jane doe",
                                    text = "Jane Doe",
                                    lexical = "jane doe",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                            word = "jane",
                                            offset = 7100000,
                                            duration = 4800000,
                                        },
                                        new
                                        {
                                            word = "doe",
                                            offset = 12000000,
                                            duration = 1700000,
                                        },
                                    },
                                    id = "2",
                                    participantId = "speaker",
                                },
                                new
                                {
                                    itn = "hi jane what's your phone number",
                                    maskedItn = "hi jane what's your phone number",
                                    text = "Hi Jane, what's your phone number?",
                                    lexical = "hi jane what's your phone number",
                                    audioTimings = new[]
                                    {
                                        new
                                        {
                                          word = "hi",
                                          offset = 7700000,
                                          duration= 3100000,
                                        },
                                        new
                                        {
                                          word= "jane",
                                          offset= 10900000,
                                          duration= 5700000,
                                        },
                                        new
                                        {
                                          word= "what's",
                                          offset= 17300000,
                                          duration= 2600000,
                                        },
                                        new
                                        {
                                          word= "your",
                                          offset= 20000000,
                                          duration= 1600000,
                                        },
                                        new
                                        {
                                          word= "phone",
                                          offset= 21700000,
                                          duration= 1700000,
                                        },
                                        new
                                        {
                                          word= "number",
                                          offset= 23500000,
                                          duration= 2300000,
                                        },
                                    },
                                    id = "3",
                                    participantId = "agent",
                                },
                            },
                            id = "1",
                            language = "en",
                            modality = "transcript",
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
                            redactionSource = "lexical",
                            modelVersion = "2022-05-15-preview",
                            loggingOptOut = false,
                        },
                        kind = "ConversationalPIITask",
                        taskName = "analyze",
                    },
                },
            };

            #region Snippet:AnalyzeConversationAsync_ConversationPII_Transcript
            Operation<BinaryData> analyzeConversationOperation = await client.AnalyzeConversationAsync(WaitUntil.Completed, RequestContent.Create(data));
            #endregion

            var jobResults = analyzeConversationOperation.Value.ToDynamic();
            foreach (var task in jobResults.Tasks.Items)
            {
                var results = task.Results;

                Console.WriteLine("Conversations:");
                foreach (var conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Conversation Items:");
                    foreach (var conversationItem in conversation.ConversationItems)
                    {
                        Console.WriteLine($"Conversation Item: #{conversationItem.Id}");

                        var redactedContent = conversationItem.RedactedContent;
                        Console.WriteLine($"Redacted Text: {redactedContent.Text}");
                        Console.WriteLine($"Redacted Lexical: {redactedContent.Lexical}");
                        Console.WriteLine($"Redacted MaskedItn: {redactedContent.MaskedItn}");
#if !SNIPPET
                        expectedRedactedText.Add((string)redactedContent.Text);
#endif

                        Console.WriteLine("Entities:");
                        foreach (var entity in conversationItem.Entities)
                        {
                            Console.WriteLine($"Text: {entity.Text}");
                            Console.WriteLine($"Offset: {entity.Offset}");
                            Console.WriteLine($"Category: {entity.Category}");
                            Console.WriteLine($"Confidence Score: {entity.ConfidenceScore}");
                            Console.WriteLine($"Length: {entity.Length}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }

            Assert.That(expectedRedactedText, Is.EqualTo(new[] { "Hi", "**** Doe", "Hi ****, what's your phone number?" }));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
