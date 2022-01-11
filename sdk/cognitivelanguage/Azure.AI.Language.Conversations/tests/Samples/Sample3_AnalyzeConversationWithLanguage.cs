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
        public void AnalyzeConversationWithLanguage()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguage

#if SNIPPET
            ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");
            AnalyzeConversationOptions options = new AnalyzeConversationOptions()
            {
                Language = "es"
            };
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Tendremos 2 platos de nigiri de salmón braseado.",
                conversationsProject,
                options);
#else
            AnalyzeConversationOptions options = new AnalyzeConversationOptions()
            {
                Language = "es"
            };
            Response<AnalyzeConversationResult> response = client.AnalyzeConversation(
                "Tendremos 2 platos de nigiri de salmón braseado.",
                TestEnvironment.Project,
                options);
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");

            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("Order"));
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task AnalyzeConversationWithLanguageAsync()
        {
            ConversationAnalysisClient client = Client;

            #region Snippet:ConversationAnalysis_AnalyzeConversationWithLanguageAsync

#if SNIPPET
            ConversationsProject conversationsProject = new ConversationsProject("Menu", "production");
            AnalyzeConversationOptions options = new AnalyzeConversationOptions()
            {
                Language = "es"
            };
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Tendremos 2 platos de nigiri de salmón braseado.",
                conversationsProject,
                options);
#else
            AnalyzeConversationOptions options = new AnalyzeConversationOptions()
            {
                Language = "es"
            };
            Response<AnalyzeConversationResult> response = await client.AnalyzeConversationAsync(
                "Tendremos 2 platos de nigiri de salmón braseado.",
                TestEnvironment.Project,
                options);
#endif

            Console.WriteLine($"Top intent: {response.Value.Prediction.TopIntent}");
            #endregion

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("Order"));
        }
    }
}
