// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void StartAnalyzeConversation_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:StartAnalyzeConversation_ConversationSummarization_Input
            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions."),
            };

            var input = new List<TextConversation>()
            {
                new TextConversation("1", "en", textConversationItems)
            };

            var conversationSummarizationTaskParameters = new ConversationSummarizationTaskParameters(new List<SummaryAspect>() { SummaryAspect.Issue, SummaryAspect.Resolution });

            var tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationSummarizationTask("1", AnalyzeConversationLROTaskKind.ConversationalSummarizationTask, conversationSummarizationTaskParameters),
            };
            #endregion

            #region Snippet:StartAnalyzeConversation_StartAnalayzing
            var analyzeConversationOperation = client.StartAnalyzeConversation(input, tasks);
            analyzeConversationOperation.WaitForCompletion();
            #endregion

            #region Snippet:StartAnalyzeConversation_ConversationSummarization_Results
            var jobResults = analyzeConversationOperation.Value;
            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationSummarization = result as AnalyzeConversationSummarizationResult;

                var results = analyzeConversationSummarization.Results;

                Console.WriteLine("Conversations:");
                foreach (var conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation #:{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (var summary in conversation.Summaries)
                    {
                        Console.WriteLine($"Text: {summary.Text}");
                        Console.WriteLine($"Aspect: {summary.Aspect}");
                    }
                    Console.WriteLine();
                }
            }
            #endregion
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task StartAnalyzeConversationAsync_ConversationSummarization()
        {
            ConversationAnalysisClient client = Client;

            var textConversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions."),
            };

            var input = new List<TextConversation>()
            {
                new TextConversation("1", "en", textConversationItems)
            };

            var conversationSummarizationTaskParameters = new ConversationSummarizationTaskParameters(new List<SummaryAspect>() { SummaryAspect.Issue, SummaryAspect.Resolution });

            var tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationSummarizationTask("1", AnalyzeConversationLROTaskKind.ConversationalSummarizationTask, conversationSummarizationTaskParameters),
            };

            #region Snippet:StartAnalyzeConversationAsync_StartAnalayzing
            var analyzeConversationOperation = await client.StartAnalyzeConversationAsync(input, tasks);
            await analyzeConversationOperation.WaitForCompletionAsync();
            #endregion

            var jobResults = analyzeConversationOperation.Value;
            foreach (var result in jobResults.Tasks.Items)
            {
                var analyzeConversationSummarization = result as AnalyzeConversationSummarizationResult;

                var results = analyzeConversationSummarization.Results;

                Console.WriteLine("Conversations:");
                foreach (var conversation in results.Conversations)
                {
                    Console.WriteLine($"Conversation #:{conversation.Id}");
                    Console.WriteLine("Summaries:");
                    foreach (var summary in conversation.Summaries)
                    {
                        Console.WriteLine($"Text: {summary.Text}");
                        Console.WriteLine($"Aspect: {summary.Aspect}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
