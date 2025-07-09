// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core.TestFramework;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2025_05_15_Preview)]
        public void AnalyzeConversationalAI()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeAIConversation
            string projectName = "EmailApp";
            string deploymentName = "production";
        #if !SNIPPET
            projectName = TestEnvironment.ProjectName;
            deploymentName = TestEnvironment.DeploymentName;
        #endif

            AnalyzeConversationInput data = new ConversationalAITask(
                new ConversationalAIAnalysisInput(
                    conversations: new AIConversation[] {
                        new AIConversation(
                            id: "order",
                            modality: InputModality.Text,
                            language: "en-GB",
                            conversationItems: new ConversationalAIItem[]
                            {
                                new ConversationalAIItem(id: "1", participantId: "user", text: "Hi"),
                                new ConversationalAIItem(id: "2", participantId: "bot", text: "Hello, how can I help you?"),
                                new ConversationalAIItem(id: "3", participantId: "user", text: "Send an email to Carol about tomorrow's demo")
                            }
                        )
                    }),
                new AIConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            Response<AnalyzeConversationActionResult> response = client.AnalyzeConversation(data);
            ConversationalAITaskResult result = response.Value as ConversationalAITaskResult;
            ConversationalAIResult aiResult = result.Result;

            foreach (var conversation in aiResult?.Conversations ?? Enumerable.Empty<ConversationalAIAnalysis>())
            {
                Console.WriteLine($"Conversation ID: {conversation.Id}\n");

                Console.WriteLine("Intents:");
                foreach (var intent in conversation.Intents ?? Enumerable.Empty<ConversationalAIIntent>())
                {
                    Console.WriteLine($"  Name: {intent.Name}");
                    Console.WriteLine($"  Type: {intent.Type}");

                    Console.WriteLine("  Conversation Item Ranges:");
                    foreach (var range in intent.ConversationItemRanges ?? Enumerable.Empty<ConversationItemRange>())
                    {
                        Console.WriteLine($"    - Offset: {range.Offset}, Count: {range.Count}");
                    }

                    Console.WriteLine("\n  Entities (Scoped to Intent):");
                    foreach (var entity in intent.Entities ?? Enumerable.Empty<ConversationalAIEntity>())
                    {
                        Console.WriteLine($"    Name: {entity.Name}");
                        Console.WriteLine($"    Text: {entity.Text}");
                        Console.WriteLine($"    Confidence: {entity.ConfidenceScore}");
                        Console.WriteLine($"    Offset: {entity.Offset}, Length: {entity.Length}");
                        Console.WriteLine($"    Conversation Item ID: {entity.ConversationItemId}, Index: {entity.ConversationItemIndex}");

                        if (entity.Resolutions != null)
                        {
                            foreach (var res in entity.Resolutions.OfType<DateTimeResolution>())
                            {
                                Console.WriteLine($"    - [DateTimeResolution] SubKind: {res.DateTimeSubKind}, Timex: {res.Timex}, Value: {res.Value}");
                            }
                        }

                        if (entity.ExtraInformation != null)
                        {
                            foreach (var extra in entity.ExtraInformation.OfType<EntitySubtype>())
                            {
                                Console.WriteLine($"    - [EntitySubtype] Value: {extra.Value}");
                                foreach (var tag in extra.Tags ?? Enumerable.Empty<EntityTag>())
                                {
                                    Console.WriteLine($"      • Tag: {tag.Name}, Confidence: {tag.ConfidenceScore}");
                                }
                            }
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Global Entities:");
                foreach (var entity in conversation.Entities ?? Enumerable.Empty<ConversationalAIEntity>())
                {
                    Console.WriteLine($"  Name: {entity.Name}");
                    Console.WriteLine($"  Text: {entity.Text}");
                    Console.WriteLine($"  Confidence: {entity.ConfidenceScore}");
                    Console.WriteLine($"  Offset: {entity.Offset}, Length: {entity.Length}");
                    Console.WriteLine($"  Conversation Item ID: {entity.ConversationItemId}, Index: {entity.ConversationItemIndex}");

                    if (entity.ExtraInformation != null)
                    {
                        foreach (var extra in entity.ExtraInformation.OfType<EntitySubtype>())
                        {
                            Console.WriteLine($"    - [EntitySubtype] Value: {extra.Value}");
                            foreach (var tag in extra.Tags ?? Enumerable.Empty<EntityTag>())
                            {
                                Console.WriteLine($"      • Tag: {tag.Name}, Confidence: {tag.ConfidenceScore}");
                            }
                        }
                    }

                    Console.WriteLine();
                }

                Console.WriteLine(new string('-', 40));
            }
            #endregion
        }

        [AsyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2025_05_15_Preview)]
        public async Task AnalyzeConversationalAIAsync()
        {
            ConversationAnalysisClient client = Client;

            string projectName = TestEnvironment.ProjectName;
            string deploymentName = TestEnvironment.DeploymentName;

            AnalyzeConversationInput data = new ConversationalAITask(
                new ConversationalAIAnalysisInput(
                    conversations: new AIConversation[]
                    {
                        new AIConversation(
                            id: "order",
                            modality: InputModality.Text,
                            language: "en-GB",
                            conversationItems: new ConversationalAIItem[]
                            {
                                new ConversationalAIItem(id: "1", participantId: "user", text: "Hi"),
                                new ConversationalAIItem(id: "2", participantId: "bot", text: "Hello, how can I help you?"),
                                new ConversationalAIItem(id: "3", participantId: "user", text: "Send an email to Carol about tomorrow's demo")
                            }
                        )
                    }),
                new AIConversationLanguageUnderstandingActionContent(projectName, deploymentName)
                {
                    StringIndexType = StringIndexType.Utf16CodeUnit,
                });

            #region Snippet:ConversationAnalysis_AnalyzeAIConversationAsync
            Response<AnalyzeConversationActionResult> response = await client.AnalyzeConversationAsync(data);
            ConversationalAITaskResult taskResult = response.Value as ConversationalAITaskResult;
            #endregion

            ConversationalAIResult result = taskResult.Result;

            foreach (var conversation in result?.Conversations ?? Enumerable.Empty<ConversationalAIAnalysis>())
            {
                Console.WriteLine($"Conversation ID: {conversation.Id}\n");

                Console.WriteLine("Intents:");
                foreach (var intent in conversation.Intents ?? Enumerable.Empty<ConversationalAIIntent>())
                {
                    Console.WriteLine($"  Name: {intent.Name}");
                    Console.WriteLine($"  Type: {intent.Type}");

                    Console.WriteLine("  Conversation Item Ranges:");
                    foreach (var range in intent.ConversationItemRanges ?? Enumerable.Empty<ConversationItemRange>())
                    {
                        Console.WriteLine($"    - Offset: {range.Offset}, Count: {range.Count}");
                    }

                    Console.WriteLine("\n  Entities (Scoped to Intent):");
                    foreach (var entity in intent.Entities ?? Enumerable.Empty<ConversationalAIEntity>())
                    {
                        Console.WriteLine($"    Name: {entity.Name}");
                        Console.WriteLine($"    Text: {entity.Text}");
                        Console.WriteLine($"    Confidence: {entity.ConfidenceScore}");
                        Console.WriteLine($"    Offset: {entity.Offset}, Length: {entity.Length}");
                        Console.WriteLine($"    Conversation Item ID: {entity.ConversationItemId}, Index: {entity.ConversationItemIndex}");

                        if (entity.Resolutions != null)
                        {
                            foreach (var res in entity.Resolutions.OfType<DateTimeResolution>())
                            {
                                Console.WriteLine($"    - [DateTimeResolution] SubKind: {res.DateTimeSubKind}, Timex: {res.Timex}, Value: {res.Value}");
                            }
                        }

                        if (entity.ExtraInformation != null)
                        {
                            foreach (var extra in entity.ExtraInformation.OfType<EntitySubtype>())
                            {
                                Console.WriteLine($"    - [EntitySubtype] Value: {extra.Value}");
                                foreach (var tag in extra.Tags ?? Enumerable.Empty<EntityTag>())
                                {
                                    Console.WriteLine($"      • Tag: {tag.Name}, Confidence: {tag.ConfidenceScore}");
                                }
                            }
                        }

                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("Global Entities:");
                foreach (var entity in conversation.Entities ?? Enumerable.Empty<ConversationalAIEntity>())
                {
                    Console.WriteLine($"  Name: {entity.Name}");
                    Console.WriteLine($"  Text: {entity.Text}");
                    Console.WriteLine($"  Confidence: {entity.ConfidenceScore}");
                    Console.WriteLine($"  Offset: {entity.Offset}, Length: {entity.Length}");
                    Console.WriteLine($"  Conversation Item ID: {entity.ConversationItemId}, Index: {entity.ConversationItemIndex}");

                    if (entity.ExtraInformation != null)
                    {
                        foreach (var extra in entity.ExtraInformation.OfType<EntitySubtype>())
                        {
                            Console.WriteLine($"    - [EntitySubtype] Value: {extra.Value}");
                            foreach (var tag in extra.Tags ?? Enumerable.Empty<EntityTag>())
                            {
                                Console.WriteLine($"      • Tag: {tag.Name}, Confidence: {tag.ConfidenceScore}");
                            }
                        }
                    }

                    Console.WriteLine();
                }

                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
