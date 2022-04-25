// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                new TextConversationItem("1", "Agent", "Hello, how can I help you?"),
                new TextConversationItem("2", "Customer", "How to upgrade Office? I am getting error messages the whole day."),
                new TextConversationItem("3", "Agent", "Press the upgrade button please. Then sign in and follow the instructions."),
            };

            List<TextConversation> input = new List<TextConversation>()
            {
                new TextConversation("1", "en", conversationItems)
            };

            List<AnalyzeConversationLROTask> tasks = new List<AnalyzeConversationLROTask>()
            {
                new AnalyzeConversationSummarizationTask()
            };

            var x = await client.AnalyzeConversationAsync(input, tasks);
        }
    }
}
