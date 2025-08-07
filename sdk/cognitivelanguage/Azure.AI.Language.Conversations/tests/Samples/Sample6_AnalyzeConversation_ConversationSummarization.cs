// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
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

            MultiLanguageConversationInput input = new MultiLanguageConversationInput(
                new List<ConversationInput>
                {
                    new TextConversation("1", "en", new List<TextConversationItem>()
                    {
                        new TextConversationItem(
                            id: "1",
                            participantId: "Agent_1",
                            text: "Hello, how can I help you?")
                            {
                                Role = ParticipantRole.Agent
                            },
                        new TextConversationItem(
                            id: "2",
                            participantId: "Customer_1",
                            text: "How to upgrade Office? I am getting error messages the whole day.")
                        {
                            Role = ParticipantRole.Customer
                        },
                        new TextConversationItem(
                            id : "3",
                            participantId : "Agent_1",
                            text : "Press the upgrade button please. Then sign in and follow the instructions.")
                        {
                            Role = ParticipantRole.Agent
                        }
                    })
                });
            List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
                {
                    new SummarizationOperationAction()
                    {
                        ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
                        {
                            SummaryAspect.Issue,
                        }),
                        Name = "Issue task",
                    },
                    new SummarizationOperationAction()
                    {
                        ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
                        {
                            SummaryAspect.Resolution,
                        }),
                        Name = "Resolution task",
                    }
                };

            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);

            #region Snippet:AnalyzeConversation_ConversationSummarizationSync

            Response<AnalyzeConversationOperationState> analyzeConversationOperation = client.AnalyzeConversations(data);

            #endregion

            AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;

            foreach (AnalyzeConversationOperationResult operationResult in operationState.Actions.Items)
            {
                Console.WriteLine($"Operation action name: {operationResult.Name}");
                if (operationResult is SummarizationOperationResult summarizationOperationResult)
                {
                    SummaryResult results = summarizationOperationResult.Results;
                    foreach (ConversationsSummaryResult conversation in results.Conversations)
                    {
                        Console.WriteLine($"Conversation: #{conversation.Id}");
                        Console.WriteLine("Summaries:");
                        foreach (SummaryResultItem summary in conversation.Summaries)
                        {
                            Console.WriteLine($"Text: {summary.Text}");
                            Console.WriteLine($"Aspect: {summary.Aspect}");
#if !SNIPPET
                            aspects.Add(summary.Aspect);
#endif
                        }
                        if (conversation.Warnings != null && conversation.Warnings.Any())
                        {
                            Console.WriteLine("Warnings:");
                            foreach (InputWarning warning in conversation.Warnings)
                            {
                                Console.WriteLine($"Code: {warning.Code}");
                                Console.WriteLine($"Message: {warning.Message}");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                if (operationState.Errors != null && operationState.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (ConversationError error in operationState.Errors)
                    {
                        Console.WriteLine($"Error: {error.Code} - {error}");
                    }
                }
            }

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
            #region Snippet:AnalyzeConversation_ConversationSummarization

            MultiLanguageConversationInput input = new MultiLanguageConversationInput(
                new List<ConversationInput>
                {
                    new TextConversation("1", "en", new List<TextConversationItem>()
                    {
                        new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                        new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                        new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.")
                    })
                });
            List<AnalyzeConversationOperationAction> actions = new List<AnalyzeConversationOperationAction>
                {
                    new SummarizationOperationAction()
                    {
                        ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
                        {
                            SummaryAspect.Issue,
                        }),
                        Name = "Issue task",
                    },
                    new SummarizationOperationAction()
                    {
                        ActionContent = new ConversationSummarizationActionContent(new List<SummaryAspect>
                        {
                            SummaryAspect.Resolution,
                        }),
                        Name = "Resolution task",
                    }
                };
            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(input, actions);
            Response<AnalyzeConversationOperationState> analyzeConversationOperation = await client.AnalyzeConversationsAsync(data);

            AnalyzeConversationOperationState operationState = analyzeConversationOperation.Value;

            foreach (var operationResult in operationState.Actions.Items)
            {
                Console.WriteLine($"Operation action name: {operationResult.Name}");
                if (operationResult is SummarizationOperationResult summarizationOperationResult)
                {
                    SummaryResult results = summarizationOperationResult.Results;
                    foreach (ConversationsSummaryResult conversation in results.Conversations)
                    {
                        Console.WriteLine($"Conversation: #{conversation.Id}");
                        Console.WriteLine("Summaries:");
                        foreach (SummaryResultItem summary in conversation.Summaries)
                        {
                            Console.WriteLine($"Text: {summary.Text}");
                            Console.WriteLine($"Aspect: {summary.Aspect}");
#if !SNIPPET
                            aspects.Add(summary.Aspect);
#endif
                        }
                        if (conversation.Warnings != null && conversation.Warnings.Any())
                        {
                            Console.WriteLine("Warnings:");
                            foreach (InputWarning warning in conversation.Warnings)
                            {
                                Console.WriteLine($"Code: {warning.Code}");
                                Console.WriteLine($"Message: {warning.Message}");
                            }
                        }
                        Console.WriteLine();
                    }
                }
                if (operationState.Errors != null && operationState.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (ConversationError error in operationState.Errors)
                    {
                        Console.WriteLine($"Error: {error.Code} - {error}");
                    }
                }
            }
            #endregion
            Assert.That(aspects, Contains.Item("issue").And.Contains("resolution"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
