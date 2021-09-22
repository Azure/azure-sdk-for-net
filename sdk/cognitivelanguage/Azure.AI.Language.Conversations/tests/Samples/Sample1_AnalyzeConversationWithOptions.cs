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
        public void AnalyzeConversationWithOptions()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithOptions

#if SNIPPET
            AnalyzeConversationOptions options = new AnalyzeConversationOptions("Menu",
                "production", "buy a ticket from new york to london.");
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(options);
#else
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName, "buy a ticket from new york to london.");
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(options);
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("BookFlight"));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task AnalyzeConversationWithOptionsAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithOptions

#if SNIPPET
            AnalyzeConversationOptions options = new AnalyzeConversationOptions("Menu",
                "production", "buy a ticket from new york to london.");
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(options);
#else
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(TestEnvironment.ProjectName,
                TestEnvironment.DeploymentName, "buy a ticket from new york to london.");
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(options);
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("BookFlight"));
        }
    }
}
