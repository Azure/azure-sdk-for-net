// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public void AnalyzeConversation()
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

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationAsync

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
