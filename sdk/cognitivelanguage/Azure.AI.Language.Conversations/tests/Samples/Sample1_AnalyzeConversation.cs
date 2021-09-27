// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [RecordedTest]
        [SyncOnly]
        public void QueryKnowledgeBase()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversation

#if SNIPPET
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Menu",
                "production",
                "We'll have 2 plates of seared salmon nigiri.");
#else
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName,
                "We'll have 2 plates of seared salmon nigiri.");
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("Order"));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task QueryKnowledgeBaseAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationAsync
            AnalyzeConversationOptions options = new AnalyzeConversationOptions("We'll have 2 plates of seared salmon nigiri.");

#if SNIPPET
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Menu",
                "production",
                "We'll have 2 plates of seared salmon nigiri.");
#else
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName,
                "We'll have 2 plates of seared salmon nigiri.");
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("Order"));
        }
    }
}
