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
        public async Task AnalyzeConversationAsync_PII()
        {
            ConversationAnalysisClient client = Client;

            List<TextConversationItem> conversationItems = new List<TextConversationItem>()
            {
                new TextConversationItem("1", "0", "Is john doe?"),
                new TextConversationItem("2", "1", "Hi John, how are you doing today?"),
                new TextConversationItem("3", "0", "Pretty good."),
            };

            List<TextConversation> input = new List<TextConversation>()
            {
                new TextConversation("1", "en", conversationItems)
            };

            ConversationPIITaskParameters param = new ConversationPIITaskParameters(false, "2022-05-15-preview", new List<ConversationPIICategory>() { ConversationPIICategory.All }, false, null);

            var pii = new AnalyzeConversationPIITask("1", AnalyzeConversationLROTaskKind.ConversationalPIITask, param);
            List<AnalyzeConversationLROTask> tasks = new List<AnalyzeConversationLROTask>()
            {
                pii
            };

            try
            {
                var x = await client.AnalyzeConversationAsync(input, tasks);
                await x.WaitForCompletionAsync();
                var y = x.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
