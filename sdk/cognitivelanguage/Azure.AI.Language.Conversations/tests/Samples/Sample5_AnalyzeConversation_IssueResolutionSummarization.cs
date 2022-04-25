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
        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationAsync_IssueResolutionSummarization()
        {
            ConversationAnalysisClient client = Client;

            List<TextConversationItem> conversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "Agent", "Hello, how can I help you?") { Modality = "text" },
                new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day.") { Modality = "text" },
                new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions.") { Modality = "text" },
            };

            List<TextConversation> input = new List<TextConversation>()
            {
                new TextConversation("1", "en", conversationItems)
            };

            ConversationSummarizationTaskParameters param = new ConversationSummarizationTaskParameters(false, "2022-04-01", new List<SummaryAspect>() { SummaryAspect.Summary, SummaryAspect.Resolution });

            var issueSumTask = new AnalyzeConversationSummarizationTask("1", AnalyzeConversationLROTaskKind.ConversationalSummarizationTask, param);
            List<AnalyzeConversationLROTask> tasks = new List<AnalyzeConversationLROTask>()
            {
                issueSumTask
            };

            try
            {
                var x = await client.AnalyzeConversationAsync(input, tasks);
                var noncasted = x.Value.Tasks.Items.First();
                var casted = (AnalyzeConversationSummarizationResult)noncasted;
                var t = casted.Results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
