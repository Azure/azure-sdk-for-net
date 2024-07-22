// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
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
        [ServiceVersion(Min = ConversationAnalysisClientOptions.ServiceVersion.V2023_04_01)]
        public void AnalyzeConversation_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;
            List<string> aspects = new();

            #region Snippet:AnalyzeConversation_ConversationSummarization
            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(
                new MultiLanguageConversationInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            new TextConversationItem("1", "Agent_1", "Hello, how can I help you?")
                            {
                                Role = ParticipantRole.Agent
                            },
                            new TextConversationItem("2", "Customer_1", "How to upgrade Office? I am getting error messages the whole day.")
                            {
                                Role = ParticipantRole.Customer
                            },
                            new TextConversationItem("3", "Agent_1", "Press the upgrade button please. Then sign in and follow the instructions.")
                            {
                                Role = ParticipantRole.Agent
                            }
                        })
                    }),
                    new List<AnalyzeConversationOperationAction>
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
                    });

            Response<AnalyzeConversationOperationState> analyzeConversationOperation = client.AnalyzeConversationOperation(data);
            AnalyzeConversationOperationState jobResults = analyzeConversationOperation.Value;

            foreach (SummarizationOperationResult task in jobResults.Actions.Items.Cast<SummarizationOperationResult>())
            {
                Console.WriteLine($"Task name: {task.Name}");
                SummaryResult results = task.Results;
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
                if (results.Errors != null && results.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (DocumentError error in results.Errors)
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
        [ServiceVersion(Min = ConversationAnalysisClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeConversationAsync_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;
            List<string> aspects = new();

            AnalyzeConversationOperationInput data = new AnalyzeConversationOperationInput(
                new MultiLanguageConversationInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                            new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                            new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.")
                        })
                    }),
                    new List<AnalyzeConversationOperationAction>
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
                    });
            #region Snippet:AnalyzeConversationAsync_ConversationSummarization
            Response<AnalyzeConversationOperationState> analyzeConversationOperation = await client.AnalyzeConversationOperationAsync(data);
            #endregion

            AnalyzeConversationOperationState jobResults = analyzeConversationOperation.Value;

            foreach (SummarizationOperationResult task in jobResults.Actions.Items.Cast<SummarizationOperationResult>())
            {
                Console.WriteLine($"Task name: {task.Name}");
                SummaryResult results = task.Results;
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
                if (results.Errors != null && results.Errors.Any())
                {
                    Console.WriteLine("Errors:");
                    foreach (DocumentError error in results.Errors)
                    {
                        Console.WriteLine($"Error: {error}");
                    }
                }
            }

            Assert.That(aspects, Contains.Item("issue").And.Contains("resolution"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
