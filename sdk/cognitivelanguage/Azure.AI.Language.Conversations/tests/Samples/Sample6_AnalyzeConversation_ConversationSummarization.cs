// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationsClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2023_04_01)]
        public void AnalyzeConversation_ConversationSummarization()
        {
            ConversationsClient client = Client;
            List<string> aspects = new();

            #region Snippet:AnalyzeConversation_ConversationSummarization
            var data = new AnalyzeConversationJobsInput(
                new MultiLanguageConversationAnalysisInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            AILanguageConversationsModelFactory.TextConversationItem("1", "Agent_1", "Hello, how can I help you?", role: ParticipantRole.Agent),
                            AILanguageConversationsModelFactory.TextConversationItem("2", "Customer_1", "How to upgrade Office? I am getting error messages the whole day.", role: ParticipantRole.Customer),
                            AILanguageConversationsModelFactory.TextConversationItem("3", "Agent_1", "Press the upgrade button please. Then sign in and follow the instructions.", role: ParticipantRole.Agent)
                        })
                    }),
                    new List<AnalyzeConversationJobTask>
                    {
                        new AnalyzeConversationSummarizationTask()
                        {
                            Parameters = new ConversationSummarizationTaskContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Issue,
                            }),
                            TaskName = "Issue task",
                        },
                        new AnalyzeConversationSummarizationTask()
                        {
                            Parameters = new ConversationSummarizationTaskContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Resolution,
                            }),
                            TaskName = "Resolution task",
                        }
                    });

            Response<AnalyzeConversationJobState> analyzeConversationOperation = client.AnalyzeConversationsOperation(data);

            dynamic jobResults = analyzeConversationOperation.Value;
            foreach (dynamic task in jobResults.Tasks.Items)
            {
                Console.WriteLine($"Task name: {task.TaskName}");
                dynamic results = task.Results;
                foreach (dynamic conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (dynamic summary in conversation.Summaries)
                    {
                        Console.WriteLine($"Text: {summary.Text}");
                        Console.WriteLine($"Aspect: {summary.Aspect}");
#if !SNIPPET
                        aspects.Add(summary.Aspect);
#endif
                    }
                    if (results.Warnings != null)
                    {
                        Console.WriteLine("Warnings:");
                        foreach (dynamic warning in conversation.Warnings)
                        {
                            Console.WriteLine($"Code: {warning.Code}");
                            Console.WriteLine($"Message: {warning.Message}");
                        }
                    }
                    Console.WriteLine();
                }
                if (results.Errors != null)
                {
                    Console.WriteLine("Errors:");
                    foreach (dynamic error in results.Errors)
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
        [ServiceVersion(Min = ConversationsClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeConversationAsync_ConversationSummarization()
        {
            ConversationsClient client = Client;
            List<string> aspects = new();

            var data = new AnalyzeConversationJobsInput(
                new MultiLanguageConversationAnalysisInput(
                    new List<ConversationInput>
                    {
                        new TextConversation("1", "en", new List<TextConversationItem>()
                        {
                            AILanguageConversationsModelFactory.TextConversationItem("1", "Agent", "Hello, how can I help you?", role: ParticipantRole.Agent),
                            AILanguageConversationsModelFactory.TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day.", role: ParticipantRole.Customer),
                            AILanguageConversationsModelFactory.TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.", role: ParticipantRole.Agent)
                        })
                    }),
                    new List<AnalyzeConversationJobTask>
                    {
                        new AnalyzeConversationSummarizationTask()
                        {
                            Parameters = new ConversationSummarizationTaskContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Issue,
                            }),
                            TaskName = "Issue task",
                        },
                        new AnalyzeConversationSummarizationTask()
                        {
                            Parameters = new ConversationSummarizationTaskContent(new List<SummaryAspect>
                            {
                                SummaryAspect.Resolution,
                            }),
                            TaskName = "Resolution task",
                        }
                    });

            #region Snippet:AnalyzeConversationAsync_ConversationSummarization
            var analyzeConversationOperation = await client.AnalyzeConversationsOperationAsync(data);
            #endregion

            AnalyzeConversationJobState jobResults = analyzeConversationOperation.Value;
            foreach (dynamic task in jobResults.Tasks.Items)
            {
                Console.WriteLine($"Task name: {task.TaskName}");
                dynamic results = task.Results;
                foreach (dynamic conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation: #{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (dynamic summary in conversation.Summaries)
                    {
                        Console.WriteLine($"Text: {summary.Text}");
                        Console.WriteLine($"Aspect: {summary.Aspect}");
#if !SNIPPET
                        aspects.Add(summary.Aspect);
#endif
                    }
                    Console.WriteLine();
                }
            }

            Assert.That(aspects, Contains.Item("issue").And.Contains("resolution"));
            Assert.That(analyzeConversationOperation.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
