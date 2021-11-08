// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests
{
    public class ConversationAnalysisClientLiveTests : ConversationAnalysisTestBase<ConversationAnalysisClient>
    {
        public ConversationAnalysisClientLiveTests(bool isAsync, ConversationAnalysisClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }
        private static string EnglishText = "We'll have 2 plates of seared salmon nigiri.";
        private static string SpanishText = "Tendremos 2 platos de nigiri de salmón braseado.";
        private static List<string> ExpectedOutput = new List<string>()
        {
            "2 plates",
            "seared salmon nigiri"
        };

        [RecordedTest]
        public async Task AnalyzeConversation()
        {
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(
               TestEnvironment.ProjectName,
               TestEnvironment.DeploymentName,
               EnglishText);

            Response<AnalyzeConversationResult> response = await Client.AnalyzeConversationAsync(options);

            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("Order"));
            Assert.That(response.Value.Prediction.ProjectKind, Is.EqualTo(ProjectKind.Conversation));
        }

        [RecordedTest]
        public async Task AnalyzeConversationWithLanguage()
        {
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(
               TestEnvironment.ProjectName,
               TestEnvironment.DeploymentName,
               SpanishText)
            {
                Language = "es"
            };

            Response<AnalyzeConversationResult> response = await Client.AnalyzeConversationAsync(options);

            Assert.That(response.Value.Prediction.TopIntent, Is.EqualTo("Order"));
            Assert.That(response.Value.Prediction.ProjectKind, Is.EqualTo(ProjectKind.Conversation));
        }

        [RecordedTest]
        public async Task AnalyzeConversationsWithConversationPrediction()
        {
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(
               TestEnvironment.ProjectName,
               TestEnvironment.DeploymentName,
               EnglishText);

            Response<AnalyzeConversationResult> response = await Client.AnalyzeConversationAsync(options);

            ConversationPrediction conversationPrediction = response.Value.Prediction as ConversationPrediction;

            Assert.That(response.Value.Prediction.ProjectKind, Is.EqualTo(ProjectKind.Conversation));

            Assert.That(conversationPrediction.TopIntent, Is.EqualTo("Order"));

            IList<string> entitiesText = conversationPrediction.Entities.Select(entity => entity.Text).ToList();
            Assert.That(entitiesText, Has.Count.EqualTo(2));
            Assert.That(entitiesText, Is.EquivalentTo(ExpectedOutput));
        }

        [RecordedTest]
        public void AnalyzeConversationsInvalidArgument()
        {
            AnalyzeConversationOptions options = new AnalyzeConversationOptions(
              TestEnvironment.ProjectName,
              TestEnvironment.DeploymentName,
              "");

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await Client.AnalyzeConversationAsync(options);
            });

            Assert.That(ex.Status, Is.EqualTo(400));
            Assert.That(ex.ErrorCode, Is.EqualTo("InvalidArgument"));
        }
    }
}
